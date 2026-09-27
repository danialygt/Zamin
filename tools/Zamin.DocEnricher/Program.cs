using System.Collections.Concurrent;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Xml.Linq;

var repoRoot = args.Length > 0 ? Path.GetFullPath(args[0]) : FindRepoRoot();
var rawDir = args.Length > 1 ? Path.GetFullPath(args[1]) : Path.Combine(repoRoot, "framework-docs", "raw-extraction");
var outDir = args.Length > 2 ? Path.GetFullPath(args[2]) : Path.Combine(repoRoot, "framework-docs", "enriched");

Directory.CreateDirectory(outDir);
foreach (var f in Directory.EnumerateFiles(outDir, "*.json"))
    File.Delete(f);
var summaryMd = Path.Combine(outDir, "_summary.md");
if (File.Exists(summaryMd)) File.Delete(summaryMd);

var jsonOpts = new JsonSerializerOptions
{
    PropertyNameCaseInsensitive = true,
    PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
    ReadCommentHandling = JsonCommentHandling.Skip,
    AllowTrailingCommas = true,
};
var writeOpts = new JsonSerializerOptions
{
    WriteIndented = true,
    DefaultIgnoreCondition = JsonIgnoreCondition.Never,
    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
    PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
};

var rawFiles = Directory.GetFiles(rawDir, "*.json")
    .Where(f => !Path.GetFileName(f).StartsWith('_'))
    .OrderBy(f => f, StringComparer.OrdinalIgnoreCase)
    .ToList();

Console.WriteLine($"Raw files: {rawFiles.Count}");
Console.WriteLine($"Output   : {outDir}");

var stats = new Stats();
var reviewItems = new ConcurrentBag<ReviewItem>();

foreach (var rawPath in rawFiles)
{
    try
    {
        var rawText = File.ReadAllText(rawPath, Encoding.UTF8);
        var rawDoc = JsonSerializer.Deserialize<RawNamespaceDoc>(rawText, jsonOpts)
                     ?? throw new InvalidOperationException("null deserialize");

        // Build type lookup within namespace for related-type hints
        // (Entity / Entity<TId> both strip to "Entity" — keep first)
        var typeIndex = rawDoc.Types
            .GroupBy(t => StripGenerics(t.TypeName), StringComparer.Ordinal)
            .ToDictionary(g => g.Key, g => g.First(), StringComparer.Ordinal);

        var enrichedTypes = new List<EnrichedType>();
        foreach (var t in rawDoc.Types)
        {
            var et = EnrichType(t, typeIndex, stats, reviewItems);
            enrichedTypes.Add(et);
        }

        var enriched = new EnrichedNamespaceDoc
        {
            Namespace = rawDoc.Namespace,
            TypeCount = enrichedTypes.Count,
            Types = enrichedTypes,
        };

        ApplyCuratedOverrides(enriched);

        var outPath = Path.Combine(outDir, Path.GetFileName(rawPath));
        File.WriteAllText(outPath, JsonSerializer.Serialize(enriched, writeOpts), Encoding.UTF8);
        Console.WriteLine($"  {rawDoc.Namespace}: {enrichedTypes.Count} types");
    }
    catch (Exception ex)
    {
        Console.Error.WriteLine($"ERROR {rawPath}: {ex.Message}");
        reviewItems.Add(new ReviewItem
        {
            Namespace = Path.GetFileNameWithoutExtension(rawPath),
            TypeName = "(file)",
            MemberName = "",
            Reason = $"enrichment_failed: {ex.Message}",
        });
    }
}

WriteSummary(summaryMd, stats, reviewItems.OrderBy(r => r.Namespace).ThenBy(r => r.TypeName).ToList(), rawFiles.Count);
Console.WriteLine();
Console.WriteLine($"Done. existing={stats.ExistingCount} generated={stats.GeneratedCount} completed={stats.CompletedExistingCount} review={reviewItems.Count}");
Console.WriteLine($"Summary: {summaryMd}");

// ───────────────────────── enrichment ─────────────────────────

static EnrichedType EnrichType(
    RawType t,
    Dictionary<string, RawType> typeIndex,
    Stats stats,
    ConcurrentBag<ReviewItem> review)
{
    var related = BuildRelatedContext(t, typeIndex);
    var (doc, source, completed) = BuildDocForType(t, related, stats, review);

    var members = new List<EnrichedMember>();
    foreach (var m in t.Members)
        members.Add(EnrichMember(t, m, related, stats, review));

    return new EnrichedType
    {
        TypeName = t.TypeName,
        Kind = t.Kind,
        Namespace = t.Namespace,
        SourceFile = t.SourceFile,
        BaseTypes = t.BaseTypes ?? [],
        GenericConstraints = t.GenericConstraints ?? "",
        Attributes = t.Attributes ?? [],
        XmlDoc = t.XmlDoc ?? "",
        InjectedDependencies = t.InjectedDependencies ?? [],
        Members = members,
        GeneratedDoc = doc,
        Source = source,
        DocCompleted = completed,
    };
}

static EnrichedMember EnrichMember(
    RawType owner,
    RawMember m,
    string related,
    Stats stats,
    ConcurrentBag<ReviewItem> review)
{
    var (doc, source, completed) = BuildDocForMember(owner, m, related, stats, review);
    return new EnrichedMember
    {
        Name = m.Name,
        Kind = m.Kind,
        Signature = m.Signature ?? "",
        XmlDoc = m.XmlDoc ?? "",
        BodySummary = m.BodySummary ?? "",
        Attributes = m.Attributes ?? [],
        GeneratedDoc = doc,
        Source = source,
        DocCompleted = completed,
    };
}

static (GeneratedDoc doc, string source, bool completed) BuildDocForType(
    RawType t, string related, Stats stats, ConcurrentBag<ReviewItem> review)
{
    var xml = t.XmlDoc?.Trim() ?? "";
    if (!string.IsNullOrWhiteSpace(xml))
    {
        var parsed = XmlDocParser.Parse(xml);
        var incomplete = IsIncompleteTypeDoc(parsed, t);
        if (!incomplete)
        {
            Interlocked.Increment(ref stats.ExistingCount);
            return (FromExisting(parsed, xml, isType: true, t.TypeName, t.Kind), "existing", false);
        }

        // complete incomplete existing
        var generated = GenerateTypeDoc(t, related);
        var merged = MergeDocs(FromExisting(parsed, xml, isType: true, t.TypeName, t.Kind), generated);
        Interlocked.Increment(ref stats.CompletedExistingCount);
        MaybeFlagReview(t, null, generated, review);
        return (merged, "existing", true);
    }

    var gen = GenerateTypeDoc(t, related);
    Interlocked.Increment(ref stats.GeneratedCount);
    MaybeFlagReview(t, null, gen, review);
    return (gen, "generated", false);
}

static (GeneratedDoc doc, string source, bool completed) BuildDocForMember(
    RawType owner, RawMember m, string related, Stats stats, ConcurrentBag<ReviewItem> review)
{
    var xml = m.XmlDoc?.Trim() ?? "";
    if (!string.IsNullOrWhiteSpace(xml))
    {
        var parsed = XmlDocParser.Parse(xml);
        var incomplete = IsIncompleteMemberDoc(parsed, m);
        if (!incomplete)
        {
            Interlocked.Increment(ref stats.ExistingCount);
            return (FromExisting(parsed, xml, isType: false, m.Name, m.Kind), "existing", false);
        }

        var generated = GenerateMemberDoc(owner, m, related);
        var merged = MergeDocs(FromExisting(parsed, xml, isType: false, m.Name, m.Kind), generated);
        Interlocked.Increment(ref stats.CompletedExistingCount);
        MaybeFlagReview(owner, m, generated, review);
        return (merged, "existing", true);
    }

    // error kind from extractor — skip meaningful gen
    if (string.Equals(m.Kind, "error", StringComparison.OrdinalIgnoreCase))
    {
        Interlocked.Increment(ref stats.GeneratedCount);
        return (new GeneratedDoc
        {
            Fa = "خطا در استخراج این عضو؛ نیاز به بازبینی دارد.",
            En = "Extraction error for this member; needs review.",
        }, "generated", false);
    }

    var gen = GenerateMemberDoc(owner, m, related);
    Interlocked.Increment(ref stats.GeneratedCount);
    MaybeFlagReview(owner, m, gen, review);
    return (gen, "generated", false);
}

static bool IsIncompleteTypeDoc(ParsedXmlDoc parsed, RawType t)
{
    if (string.IsNullOrWhiteSpace(parsed.Summary)) return true;
    // very short / placeholder
    if (parsed.Summary.Length < 8) return true;
    return false;
}

static bool IsIncompleteMemberDoc(ParsedXmlDoc parsed, RawMember m)
{
    if (string.IsNullOrWhiteSpace(parsed.Summary)) return true;
    if (parsed.Summary.Length < 6) return true;

    var parameters = ParamParser.Parse(m.Signature ?? "");
    // has params in signature but none documented (and not empty param list)
    if (parameters.Count > 0 && parsed.Params.Count == 0
        && (m.Kind is "method" or "constructor" or "operator" or "conversion_operator"))
        return true;

    var ret = ReturnTypeParser.GetReturnType(m.Signature ?? "", m.Kind ?? "");
    if (!string.IsNullOrEmpty(ret) && ret is not ("void" or "Task" or "ValueTask")
        && string.IsNullOrWhiteSpace(parsed.Returns)
        && m.Kind is "method" or "operator")
        return true;

    return false;
}

static GeneratedDoc FromExisting(ParsedXmlDoc parsed, string rawXml, bool isType, string name, string kind)
{
    var fa = BuildStructuredFaFromXml(parsed, rawXml);
    var en = BuildStructuredEnFromXml(parsed, name, kind, isType);
    return new GeneratedDoc { Fa = fa, En = en };
}

static string BuildStructuredFaFromXml(ParsedXmlDoc parsed, string rawXml)
{
    // Prefer structured rebuild from tags; fall back to cleaned raw ///
    if (!string.IsNullOrWhiteSpace(parsed.Summary) || parsed.Params.Count > 0 || !string.IsNullOrWhiteSpace(parsed.Returns))
    {
        var sb = new StringBuilder();
        if (!string.IsNullOrWhiteSpace(parsed.Summary))
            sb.AppendLine(parsed.Summary.Trim());
        if (parsed.Params.Count > 0)
        {
            sb.AppendLine("پارامترها:");
            foreach (var (n, d) in parsed.Params)
                sb.AppendLine($"- {n}: {(string.IsNullOrWhiteSpace(d) ? "(بدون توضیح)" : d.Trim())}");
        }
        if (!string.IsNullOrWhiteSpace(parsed.Returns))
            sb.AppendLine($"مقدار بازگشتی: {parsed.Returns.Trim()}");
        if (parsed.Exceptions.Count > 0)
        {
            sb.AppendLine("استثناها:");
            foreach (var (n, d) in parsed.Exceptions)
                sb.AppendLine($"- {n}: {(string.IsNullOrWhiteSpace(d) ? "" : d.Trim())}");
        }
        if (!string.IsNullOrWhiteSpace(parsed.Remarks))
            sb.AppendLine($"نکات: {parsed.Remarks.Trim()}");
        return sb.ToString().Trim();
    }
    return XmlDocParser.StripSlashes(rawXml);
}

static string BuildStructuredEnFromXml(ParsedXmlDoc parsed, string name, string kind, bool isType)
{
    // Existing Zamin docs are often Persian-only. Produce a clear English counterpart.
    var summary = parsed.Summary?.Trim() ?? "";
    string enSummary;
    if (string.IsNullOrWhiteSpace(summary))
        enSummary = DefaultEnSummary(name, kind, isType);
    else if (LooksLikePersian(summary))
        enSummary = TranslateCommonFaToEn(summary, name, kind, isType);
    else
        enSummary = summary;

    var sb = new StringBuilder();
    sb.AppendLine(enSummary);
    if (parsed.Params.Count > 0)
    {
        sb.AppendLine("Parameters:");
        foreach (var (n, d) in parsed.Params)
        {
            string desc;
            if (string.IsNullOrWhiteSpace(d)) desc = "See signature.";
            else if (LooksLikePersian(d)) desc = TranslateCommonFaToEn(d, n, "param", false);
            else desc = d.Trim();
            sb.AppendLine($"- {n}: {desc}");
        }
    }
    if (!string.IsNullOrWhiteSpace(parsed.Returns))
    {
        var r = parsed.Returns.Trim();
        sb.AppendLine($"Returns: {(LooksLikePersian(r) ? TranslateCommonFaToEn(r, name, "returns", false) : r)}");
    }
    if (parsed.Exceptions.Count > 0)
    {
        sb.AppendLine("Exceptions:");
        foreach (var (n, d) in parsed.Exceptions)
            sb.AppendLine($"- {n}: {(string.IsNullOrWhiteSpace(d) || LooksLikePersian(d) ? "Thrown as documented in source XML." : d.Trim())}");
    }
    return sb.ToString().Trim();
}

/// <summary>Lightweight FA→EN for common Zamin XML phrases; falls back to descriptive paraphrase.</summary>
static string TranslateCommonFaToEn(string fa, string name, string kind, bool isType)
{
    var t = CollapseWs(fa);

    // High-value known phrases from the Zamin codebase
    var map = new (string fa, string en)[]
    {
        ("کلاس پایه برای تمامی Entityها موجود در سامانه", "Base class for all entities in the system."),
        ("شناسه عددی Entityها صرفا برای ذخیره در دیتابیس و سادگی کار مورد استفاده قرار بگیرید.", "Numeric entity Id used mainly for database storage and simplicity."),
        ("شناسه Entity شناسه اصلی Entity که در همه جا باید مورد استفاده قرار گیرد BusinessId است. تمامی ارتباطات به کمک این شناسه باید برقرار شود.", "Primary business identifier (BusinessId) that should be used everywhere; all references must use this Id."),
        ("پیاده سازی الگوی AggregateRoot", "Implements the Aggregate Root pattern."),
        ("یک Event جدید به مجموعه Eventهای موجود در این Aggregate اضافه می‌کند.", "Adds a new domain event to this aggregate's event collection."),
        ("لیستی از Eventهای رخداده برای Aggregate را به صورت فقط خواندی و غیر قابل تغییر را بازگشت می‌دهد", "Returns a read-only, immutable list of domain events that occurred on this aggregate."),
        ("Eventهای موجود در این Aggregate را پاک می‌کند", "Clears domain events currently held by this aggregate."),
        ("سازنده Aggregate برای ایجاد Aggregate از روی Eventها", "Aggregate constructor used to rehydrate the aggregate from existing events."),
        ("در صورتی که Event از قبل وجود داشته باشد توسط این پارامتر به Aggregate ارسال می‌گردد", "Pre-existing events supplied to rebuild the aggregate."),
    };

    foreach (var (src, en) in map)
    {
        if (t.Contains(src, StringComparison.Ordinal) || src.Contains(t, StringComparison.Ordinal))
            return en;
        // fuzzy: if summary starts with first 20 chars of known phrase
        if (src.Length > 20 && t.StartsWith(src[..20], StringComparison.Ordinal))
            return en;
    }

    if (isType)
        return $"Author XML for {kind} '{name}': {Truncate(t, 280)}";
    if (kind == "returns")
        return $"Return value as documented by author: {Truncate(t, 200)}";
    if (kind == "param")
        return $"Parameter '{name}' as documented by author: {Truncate(t, 200)}";
    return $"Author XML for {kind} '{name}': {Truncate(t, 280)}";
}

static GeneratedDoc MergeDocs(GeneratedDoc existing, GeneratedDoc generated)
{
    // Keep author's meaning; append generated sections that were missing (params/returns/exceptions).
    return new GeneratedDoc
    {
        Fa = MergeLang(existing.Fa, generated.Fa),
        En = MergeLang(existing.En, generated.En),
    };
}

static string MergeLang(string existing, string generated)
{
    if (string.IsNullOrWhiteSpace(existing)) return generated.Trim();
    if (string.IsNullOrWhiteSpace(generated)) return existing.Trim();

    var e = existing.Trim();
    var g = generated.Trim();
    // Avoid duplicating the whole text
    if (e.Contains(g, StringComparison.Ordinal) || g.Contains(e, StringComparison.Ordinal))
        return e.Length >= g.Length ? e : g;

    // Append useful generated parts not already present
    var extras = new List<string>();
    foreach (var marker in new[] { "پارامترها:", "Parameters:", "مقدار بازگشتی:", "Returns:", "استثناها:", "Exceptions:", "پیش‌شرط", "Preconditions", "وابستگی", "Dependencies" })
    {
        if (!e.Contains(marker, StringComparison.OrdinalIgnoreCase) && g.Contains(marker, StringComparison.OrdinalIgnoreCase))
        {
            var idx = g.IndexOf(marker, StringComparison.OrdinalIgnoreCase);
            extras.Add(g[idx..].Trim());
            break; // take from first missing section onward once
        }
    }

    if (extras.Count == 0)
        return e;

    return (e + "\n\n" + string.Join("\n\n", extras)).Trim();
}

static GeneratedDoc GenerateTypeDoc(RawType t, string related)
{
    var name = t.TypeName;
    var kind = t.Kind ?? "class";
    var bases = t.BaseTypes is { Count: > 0 } ? string.Join(", ", t.BaseTypes) : "";
    var deps = t.InjectedDependencies is { Count: > 0 } ? string.Join(", ", t.InjectedDependencies) : "";
    var attrs = t.Attributes is { Count: > 0 } ? string.Join(", ", t.Attributes) : "";

    var roleFa = kind switch
    {
        "interface" => "قرارداد (اینترفیس)",
        "enum" => "شمارشی (enum)",
        "struct" or "record_struct" => "ساختار",
        "record" => "رکورد",
        _ => "کلاس",
    };
    var roleEn = kind switch
    {
        "interface" => "interface contract",
        "enum" => "enumeration",
        "struct" or "record_struct" => "struct",
        "record" => "record",
        _ => "class",
    };

    var fa = new StringBuilder();
    fa.Append($"{roleFa} «{name}» در namespace {t.Namespace}. ");
    fa.Append(InferTypePurposeFa(t));
    if (!string.IsNullOrEmpty(bases))
        fa.Append($" ارث‌بری/پیاده‌سازی: {bases}.");
    if (!string.IsNullOrEmpty(t.GenericConstraints))
        fa.Append($" قیود جنریک: {CollapseWs(t.GenericConstraints)}.");
    if (!string.IsNullOrEmpty(deps))
        fa.Append($" وابستگی‌های سازنده (DI): {deps}.");
    if (!string.IsNullOrEmpty(attrs))
        fa.Append($" اتریبیوت‌ها: {attrs}.");
    if (!string.IsNullOrWhiteSpace(related))
        fa.Append($" مرتبط: {related}.");

    var en = new StringBuilder();
    en.Append($"{Capitalize(roleEn)} '{name}' in namespace {t.Namespace}. ");
    en.Append(InferTypePurposeEn(t));
    if (!string.IsNullOrEmpty(bases))
        en.Append($" Base/implemented types: {bases}.");
    if (!string.IsNullOrEmpty(t.GenericConstraints))
        en.Append($" Generic constraints: {CollapseWs(t.GenericConstraints)}.");
    if (!string.IsNullOrEmpty(deps))
        en.Append($" Constructor-injected dependencies: {deps}.");
    if (!string.IsNullOrEmpty(attrs))
        en.Append($" Attributes: {attrs}.");
    if (!string.IsNullOrWhiteSpace(related))
        en.Append($" Related: {related}.");

    return new GeneratedDoc { Fa = fa.ToString().Trim(), En = en.ToString().Trim() };
}

static GeneratedDoc GenerateMemberDoc(RawType owner, RawMember m, string related)
{
    var kind = m.Kind ?? "method";
    var sig = m.Signature ?? "";
    var body = m.BodySummary ?? "";
    var parameters = ParamParser.Parse(sig);
    var returns = ReturnTypeParser.GetReturnType(sig, kind);
    var throws = ThrowAnalyzer.FindThrows(body);
    var nullGuards = ThrowAnalyzer.FindNullGuards(body);

    var fa = new StringBuilder();
    var en = new StringBuilder();

    switch (kind)
    {
        case "property":
            WritePropertyDocs(owner, m, fa, en);
            break;
        case "field":
            WriteFieldDocs(owner, m, fa, en);
            break;
        case "constructor":
            WriteCtorDocs(owner, m, parameters, body, throws, fa, en);
            break;
        case "event":
            fa.Append($"رویداد «{m.Name}» روی {owner.TypeName}. برای اطلاع‌رسانی تغییرات/رخدادهای مرتبط استفاده می‌شود.");
            en.Append($"Event '{m.Name}' on {owner.TypeName}. Used to notify related state changes or occurrences.");
            break;
        case "enum_member":
            fa.Append($"مقدار شمارشی «{m.Name}» در enum {owner.TypeName}.");
            en.Append($"Enum member '{m.Name}' of {owner.TypeName}.");
            break;
        case "primary_constructor_parameter":
            fa.Append($"پارامتر سازنده اصلی رکورد/کلاس «{m.Name}» با امضای `{sig}`.");
            en.Append($"Primary constructor parameter '{m.Name}' with signature `{sig}`.");
            break;
        case "indexer":
            WriteMethodishDocs(owner, m, "indexer", parameters, returns, body, throws, nullGuards, related, fa, en);
            break;
        case "operator":
        case "conversion_operator":
            WriteMethodishDocs(owner, m, kind, parameters, returns, body, throws, nullGuards, related, fa, en);
            break;
        default: // method
            WriteMethodishDocs(owner, m, "method", parameters, returns, body, throws, nullGuards, related, fa, en);
            break;
    }

    return new GeneratedDoc { Fa = fa.ToString().Trim(), En = en.ToString().Trim() };
}

static void WritePropertyDocs(RawType owner, RawMember m, StringBuilder fa, StringBuilder en)
{
    var access = m.Signature ?? "";
    var hasGet = access.Contains("get;", StringComparison.Ordinal) || access.Contains("get ", StringComparison.Ordinal);
    var hasSet = access.Contains("set;", StringComparison.Ordinal) || access.Contains("set ", StringComparison.Ordinal)
                 || access.Contains("init;", StringComparison.Ordinal);
    var type = PropertyTypeParser.GetType(access);

    var purpose = InferMemberPurposeFa(m.Name, "property", owner);
    fa.Append($"پراپرتی «{m.Name}» از نوع `{type}` در {owner.TypeName}. {purpose}");
    if (hasGet && hasSet) fa.Append(" قابل خواندن و نوشتن است.");
    else if (hasGet) fa.Append(" فقط‌خواندنی است.");
    else if (hasSet) fa.Append(" قابل تنظیم است.");
    if (!string.IsNullOrWhiteSpace(m.BodySummary))
        fa.Append(" منطق دسترسی از روی بدنه accessor قابل مشاهده است.");

    var purposeEn = InferMemberPurposeEn(m.Name, "property", owner);
    en.Append($"Property '{m.Name}' of type `{type}` on {owner.TypeName}. {purposeEn}");
    if (hasGet && hasSet) en.Append(" Readable and writable.");
    else if (hasGet) en.Append(" Read-only.");
    else if (hasSet) en.Append(" Settable.");
    if (!string.IsNullOrWhiteSpace(m.BodySummary))
        en.Append(" Accessor logic is visible in the implementation body.");
}

static void WriteFieldDocs(RawType owner, RawMember m, StringBuilder fa, StringBuilder en)
{
    fa.Append($"فیلد «{m.Name}» در {owner.TypeName} با امضای `{m.Signature}`. برای نگهداری وضعیت داخلی/قابل‌دسترس نوع استفاده می‌شود.");
    en.Append($"Field '{m.Name}' on {owner.TypeName} with signature `{m.Signature}`. Holds type state exposed at this accessibility level.");
}

static void WriteCtorDocs(
    RawType owner, RawMember m, List<ParamInfo> parameters, string body,
    List<string> throws, StringBuilder fa, StringBuilder en)
{
            fa.Append($"سازنده {owner.TypeName}. ");
    en.Append($"Constructor for {owner.TypeName}. ");

    if (parameters.Count == 0)
    {
        fa.Append("بدون پارامتر؛ معمولاً برای ORM، serialization یا مقداردهی اولیه محافظت‌شده استفاده می‌شود. ");
        en.Append("Parameterless; typically used for ORM/serialization or protected initialization. ");
    }
    else
    {
        var looksLikeDi = parameters.Any(p =>
            p.Type.StartsWith('I') && p.Type.Length > 2 && char.IsUpper(p.Type[1])
            || p.Type.Contains("IServiceProvider", StringComparison.Ordinal)
            || p.Type.Contains("ILogger", StringComparison.Ordinal)
            || p.Type.Contains("IOptions", StringComparison.Ordinal)
            || p.Type.Contains("ZaminServices", StringComparison.Ordinal));

        if (looksLikeDi)
        {
            fa.Append("پارامترها از طریق تزریق وابستگی تأمین می‌شوند. ");
            en.Append("Parameters are expected via dependency injection. ");
        }
        else
        {
            fa.Append("برای ایجاد نمونه با مقادیر اولیه‌ی مشخص. ");
            en.Append("Creates an instance with the provided initial values. ");
        }

        fa.AppendLine("پارامترها:");
        en.AppendLine("Parameters:");
        foreach (var p in parameters)
        {
            fa.AppendLine($"- {p.Name} ({p.Type}): {InferParamMeaningFa(p, owner, m)}");
            en.AppendLine($"- {p.Name} ({p.Type}): {InferParamMeaningEn(p, owner, m)}");
        }
    }

    if (ThrowsAny(throws))
    {
        fa.AppendLine("استثناها (از روی بدنه):");
        en.AppendLine("Exceptions (from body):");
        foreach (var th in throws.Distinct())
        {
            fa.AppendLine($"- {th}");
            en.AppendLine($"- {th}");
        }
    }

    if (BodyAssignsFields(body))
    {
        fa.Append("پیش‌شرط: وابستگی‌ها/مقادیر ورودی باید معتبر باشند تا فیلدهای داخلی به‌درستی مقداردهی شوند.");
        en.Append(" Preconditions/dependencies: injected/input values must be valid so internal fields can be assigned correctly.");
    }
}

static void WriteMethodishDocs(
    RawType owner, RawMember m, string kind,
    List<ParamInfo> parameters, string returns, string body,
    List<string> throws, List<string> nullGuards, string related,
    StringBuilder fa, StringBuilder en)
{
    var purposeFa = InferMemberPurposeFa(m.Name, kind, owner);
    var purposeEn = InferMemberPurposeEn(m.Name, kind, owner);
    var labelFa = kind switch
    {
        "indexer" => "ایندکسر",
        "operator" => "عملگر",
        "conversion_operator" => "عملگر تبدیل",
        _ => "متد",
    };
    var labelEn = kind switch
    {
        "indexer" => "Indexer",
        "operator" => "Operator",
        "conversion_operator" => "Conversion operator",
        _ => "Method",
    };

    fa.Append($"{labelFa} «{m.Name}» در {owner.TypeName}. {purposeFa}");
    en.Append($"{labelEn} '{m.Name}' on {owner.TypeName}. {purposeEn}");

    // Body-derived behavior hints
    var behaviorFa = InferBehaviorFromBodyFa(body, m.Name);
    var behaviorEn = InferBehaviorFromBodyEn(body, m.Name);
    if (!string.IsNullOrWhiteSpace(behaviorFa)) fa.Append(" ").Append(behaviorFa);
    if (!string.IsNullOrWhiteSpace(behaviorEn)) en.Append(" ").Append(behaviorEn);

    if (parameters.Count > 0)
    {
        fa.AppendLine().AppendLine("پارامترها:");
        en.AppendLine().AppendLine("Parameters:");
        foreach (var p in parameters)
        {
            fa.AppendLine($"- {p.Name} ({p.Type}): {InferParamMeaningFa(p, owner, m)}");
            en.AppendLine($"- {p.Name} ({p.Type}): {InferParamMeaningEn(p, owner, m)}");
        }
    }
    else
    {
        fa.AppendLine().Append("بدون پارامتر ورودی.");
        en.AppendLine().Append("No input parameters.");
    }

    fa.AppendLine();
    en.AppendLine();
    if (string.IsNullOrEmpty(returns) || returns is "void")
    {
        fa.AppendLine("مقدار بازگشتی: ندارد (void).");
        en.AppendLine("Returns: nothing (void).");
    }
    else if (returns is "Task" or "ValueTask")
    {
        fa.AppendLine($"مقدار بازگشتی: `{returns}` — عملیات ناهمگام بدون نتیجه داده‌ای.");
        en.AppendLine($"Returns: `{returns}` — asynchronous operation with no data payload.");
    }
    else if (returns.StartsWith("Task<", StringComparison.Ordinal) || returns.StartsWith("ValueTask<", StringComparison.Ordinal))
    {
        fa.AppendLine($"مقدار بازگشتی: `{returns}` — نتیجه ناهمگام عملیات.");
        en.AppendLine($"Returns: `{returns}` — asynchronous result of the operation.");
    }
    else
    {
        fa.AppendLine($"مقدار بازگشتی: `{returns}`.");
        en.AppendLine($"Returns: `{returns}`.");
    }

    var allThrows = throws.Concat(nullGuards).Distinct(StringComparer.Ordinal).ToList();
    if (allThrows.Count > 0)
    {
        fa.AppendLine("استثناها (قابل تشخیص از کد):");
        en.AppendLine("Exceptions (detectable from code):");
        foreach (var th in allThrows)
        {
            fa.AppendLine($"- {th}");
            en.AppendLine($"- {th}");
        }
    }
    else
    {
        fa.AppendLine("استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).");
        en.AppendLine("No explicit throw in the body (callees may still throw).");
    }

    var preFa = InferPreconditionsFa(owner, m, body, parameters);
    var preEn = InferPreconditionsEn(owner, m, body, parameters);
    if (!string.IsNullOrWhiteSpace(preFa))
    {
        fa.AppendLine($"پیش‌شرط/وابستگی: {preFa}");
        en.AppendLine($"Preconditions/dependencies: {preEn}");
    }

    if (!string.IsNullOrWhiteSpace(related))
    {
        fa.AppendLine($"انواع مرتبط: {related}");
        en.AppendLine($"Related types: {related}");
    }
}

static string InferTypePurposeFa(RawType t)
{
    var n = t.TypeName;
    var ns = t.Namespace ?? "";
    var bases = string.Join(" ", t.BaseTypes ?? []);

    if (t.Kind == "interface")
    {
        if (n.Contains("Repository", StringComparison.OrdinalIgnoreCase))
            return "قرارداد دسترسی به داده برای ذخیره و بازیابی aggregate/entity.";
        if (n.Contains("Handler", StringComparison.OrdinalIgnoreCase))
            return "قرارداد پردازش یک درخواست/رویداد در لایه اپلیکیشن.";
        if (n.Contains("Dispatcher", StringComparison.OrdinalIgnoreCase))
            return "قرارداد مسیریابی و ارسال فرمان/کوئری/رویداد به handler مناسب.";
        if (n.StartsWith('I'))
            return "قرارداد رفتار برای مصرف‌کنندگان و پیاده‌سازی‌های جایگزین.";
    }

    if (n.Contains("Dispatcher", StringComparison.OrdinalIgnoreCase))
        return "مسئول یافتن و فراخوانی handler مناسب برای فرمان/کوئری/رویداد.";
    if (n.Contains("Handler", StringComparison.OrdinalIgnoreCase))
        return "پیاده‌سازی use-case یا واکنش به رویداد.";
    if (n.Contains("Decorator", StringComparison.OrdinalIgnoreCase))
        return "دکوریتور برای افزودن رفتار عرضی (اعتبارسنجی، لاگ، مدیریت خطا) به dispatcher/handler.";
    if (n.Contains("Options", StringComparison.OrdinalIgnoreCase) || ns.Contains("Options", StringComparison.OrdinalIgnoreCase))
        return "مدل تنظیمات قابل بایند شدن از configuration.";
    if (n.Contains("Extension", StringComparison.OrdinalIgnoreCase) || n.EndsWith("Extensions", StringComparison.Ordinal))
        return "متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.";
    if (n.Contains("Guard", StringComparison.OrdinalIgnoreCase))
        return "کمک‌کننده اعتبارسنجی ورودی و پیش‌شرط‌ها.";
    if (bases.Contains("Entity") || n.Contains("Entity", StringComparison.OrdinalIgnoreCase))
        return "موجودیت دامنه با هویت و قابلیت auditable.";
    if (bases.Contains("AggregateRoot") || n.Contains("Aggregate", StringComparison.OrdinalIgnoreCase))
        return "ریشه aggregate دامنه؛ مسئول ثبات درونی و ثبت domain eventها.";
    if (n.Contains("ValueObject", StringComparison.OrdinalIgnoreCase) || ns.Contains("ValueObjects", StringComparison.Ordinal))
        return "شیء مقدار دامنه با برابری مبتنی بر مقدار.";
    if (n.Contains("Exception", StringComparison.OrdinalIgnoreCase))
        return "استثنای دامنه/چارچوب برای اعلام نقض قاعده یا خطای قابل‌کنترل.";
    if (n.Contains("Interceptor", StringComparison.OrdinalIgnoreCase))
        return "رهگیر EF/زیرساخت برای اعمال منطق هنگام ذخیره یا تغییر داده.";
    if (n.Contains("Controller", StringComparison.OrdinalIgnoreCase))
        return "کنترلر endpoint برای دریافت درخواست HTTP و ارجاع به لایه اپلیکیشن.";

    return $"تعریف {t.Kind} عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین.";
}

static string InferTypePurposeEn(RawType t)
{
    var n = t.TypeName;
    var ns = t.Namespace ?? "";
    var bases = string.Join(" ", t.BaseTypes ?? []);

    if (t.Kind == "interface")
    {
        if (n.Contains("Repository", StringComparison.OrdinalIgnoreCase))
            return "Data-access contract for persisting and loading aggregates/entities.";
        if (n.Contains("Handler", StringComparison.OrdinalIgnoreCase))
            return "Contract for handling an application request or event.";
        if (n.Contains("Dispatcher", StringComparison.OrdinalIgnoreCase))
            return "Contract for routing commands/queries/events to the matching handler.";
        if (n.StartsWith('I'))
            return "Behavioral contract for consumers and alternate implementations.";
    }

    if (n.Contains("Dispatcher", StringComparison.OrdinalIgnoreCase))
        return "Resolves and invokes the appropriate handler for a command/query/event.";
    if (n.Contains("Handler", StringComparison.OrdinalIgnoreCase))
        return "Implements a use-case or reacts to an event.";
    if (n.Contains("Decorator", StringComparison.OrdinalIgnoreCase))
        return "Decorator that adds cross-cutting behavior (validation, logging, error handling) to a dispatcher/handler.";
    if (n.Contains("Options", StringComparison.OrdinalIgnoreCase) || ns.Contains("Options", StringComparison.OrdinalIgnoreCase))
        return "Options model bindable from configuration.";
    if (n.Contains("Extension", StringComparison.OrdinalIgnoreCase) || n.EndsWith("Extensions", StringComparison.Ordinal))
        return "Extension methods for service registration or API convenience.";
    if (n.Contains("Guard", StringComparison.OrdinalIgnoreCase))
        return "Helper for validating inputs and enforcing preconditions.";
    if (bases.Contains("Entity") || n.Contains("Entity", StringComparison.OrdinalIgnoreCase))
        return "Domain entity with identity and auditing support.";
    if (bases.Contains("AggregateRoot") || n.Contains("Aggregate", StringComparison.OrdinalIgnoreCase))
        return "Domain aggregate root responsible for consistency and domain events.";
    if (n.Contains("ValueObject", StringComparison.OrdinalIgnoreCase) || ns.Contains("ValueObjects", StringComparison.Ordinal))
        return "Domain value object with value-based equality.";
    if (n.Contains("Exception", StringComparison.OrdinalIgnoreCase))
        return "Domain/framework exception signaling a rule violation or controlled failure.";
    if (n.Contains("Interceptor", StringComparison.OrdinalIgnoreCase))
        return "EF/infrastructure interceptor applying logic during save or data change.";
    if (n.Contains("Controller", StringComparison.OrdinalIgnoreCase))
        return "HTTP endpoint controller that forwards requests to the application layer.";

    return $"Public/protected {t.Kind} definition in the Zamin framework layer.";
}

static string InferMemberPurposeFa(string name, string kind, RawType owner)
{
    if (name is ".ctor") return "نمونه را مقداردهی اولیه می‌کند.";
    if (Starts(name, "Add") && (owner.TypeName.Contains("Extension", StringComparison.OrdinalIgnoreCase)
        || owner.Namespace.Contains("DependencyInjection", StringComparison.OrdinalIgnoreCase)))
        return "سرویس‌ها/قابلیت مرتبط را به IServiceCollection ثبت می‌کند.";
    if (Starts(name, "Use") && (owner.TypeName.Contains("Extension", StringComparison.OrdinalIgnoreCase)
        || owner.Namespace.Contains("DependencyInjection", StringComparison.OrdinalIgnoreCase)))
        return "میان‌افزار یا پیکربندی pipeline را به اپلیکیشن اضافه می‌کند.";
    if (Starts(name, "Send")) return "درخواست را به handler مناسب مسیریابی و اجرا می‌کند.";
    if (Starts(name, "Execute") || Starts(name, "Query")) return "کوئری/عملیات را به handler مناسب مسیریابی و اجرا می‌کند.";
    if (Starts(name, "Publish")) return "رویداد/پیام را منتشر می‌کند.";
    if (Starts(name, "Handle")) return "منطق اصلی پردازش درخواست/رویداد را اجرا می‌کند.";
    if (Starts(name, "Validate")) return "ورودی را اعتبارسنجی می‌کند.";
    if (Starts(name, "Consume")) return "پیام دریافتی را مصرف و به handler مناسب تحویل می‌دهد.";
    if (Starts(name, "Enrich")) return "اطلاعات کمکی را به رویداد لاگ اضافه می‌کند.";
    if (Starts(name, "Detect")) return "اجزای نرم‌افزاری (کنترلر/اکشن و ...) را کشف می‌کند.";
    if (Starts(name, "MarkAs")) return "وضعیت آیتم را در ذخیره‌گاه علامت‌گذاری می‌کند.";
    if (Starts(name, "Get") || Starts(name, "Find") || Starts(name, "Load") || Starts(name, "Read"))
        return "داده یا وضعیت مرتبط را بازیابی می‌کند.";
    if (Starts(name, "Set") || Starts(name, "Update") || Starts(name, "Save") || Starts(name, "Write") || name.Equals("Add", StringComparison.OrdinalIgnoreCase))
        return "وضعیت را به‌روز یا ذخیره می‌کند.";
    if (Starts(name, "Create") || Starts(name, "Build") || Starts(name, "From") || Starts(name, "Clone"))
        return "نمونه یا نتیجه جدیدی می‌سازد.";
    if (Starts(name, "Delete") || Starts(name, "Remove") || Starts(name, "Clear"))
        return "مورد یا وضعیت را حذف/پاک می‌کند.";
    if (Starts(name, "OnResult") || Starts(name, "OnAction"))
        return "در چرخه فیلتر MVC/Minimal API اجرا می‌شود و خروجی/درخواست را تنظیم می‌کند.";
    if (Starts(name, "ToDataTable") || Starts(name, "ToExcel") || Starts(name, "ToQueryString") || Starts(name, "Fa2En"))
        return "تبدیل/نرمال‌سازی داده را طبق نام متد انجام می‌دهد.";
    if (Starts(name, "Equals") || name is "GetHashCode" or "ToString" || name is "CompareTo")
        return "بخشی از قرارداد برابری/نمایش شیء را پیاده می‌کند.";
    if (owner.TypeName.Contains("Guard", StringComparison.OrdinalIgnoreCase))
        return "در صورت نقض شرط، استثنا پرتاب می‌کند تا از ادامه با ورودی نامعتبر جلوگیری شود.";
    if (kind == "property")
        return "وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد.";
    return "عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.";
}

static string InferMemberPurposeEn(string name, string kind, RawType owner)
{
    if (name is ".ctor") return "Initializes the instance.";
    if (Starts(name, "Add") && (owner.TypeName.Contains("Extension", StringComparison.OrdinalIgnoreCase)
        || owner.Namespace.Contains("DependencyInjection", StringComparison.OrdinalIgnoreCase)))
        return "Registers related services/features into IServiceCollection.";
    if (Starts(name, "Use") && (owner.TypeName.Contains("Extension", StringComparison.OrdinalIgnoreCase)
        || owner.Namespace.Contains("DependencyInjection", StringComparison.OrdinalIgnoreCase)))
        return "Adds middleware or pipeline configuration to the application.";
    if (Starts(name, "Send")) return "Routes the request to the matching handler and executes it.";
    if (Starts(name, "Execute") || Starts(name, "Query")) return "Routes the query/operation to the matching handler and executes it.";
    if (Starts(name, "Publish")) return "Publishes an event/message.";
    if (Starts(name, "Handle")) return "Runs the core handling logic for the request/event.";
    if (Starts(name, "Validate")) return "Validates the input.";
    if (Starts(name, "Consume")) return "Consumes an incoming message and dispatches it to the matching handler.";
    if (Starts(name, "Enrich")) return "Adds contextual information to the log event.";
    if (Starts(name, "Detect")) return "Discovers software parts (controllers/actions, etc.).";
    if (Starts(name, "MarkAs")) return "Marks item state in the store.";
    if (Starts(name, "Get") || Starts(name, "Find") || Starts(name, "Load") || Starts(name, "Read"))
        return "Retrieves related data or state.";
    if (Starts(name, "Set") || Starts(name, "Update") || Starts(name, "Save") || Starts(name, "Write") || name.Equals("Add", StringComparison.OrdinalIgnoreCase))
        return "Updates or persists state.";
    if (Starts(name, "Create") || Starts(name, "Build") || Starts(name, "From") || Starts(name, "Clone"))
        return "Creates a new instance or result.";
    if (Starts(name, "Delete") || Starts(name, "Remove") || Starts(name, "Clear"))
        return "Removes or clears the item/state.";
    if (Starts(name, "OnResult") || Starts(name, "OnAction"))
        return "Runs in the MVC/endpoint filter pipeline and adjusts the request/result.";
    if (Starts(name, "ToDataTable") || Starts(name, "ToExcel") || Starts(name, "ToQueryString") || Starts(name, "Fa2En"))
        return "Performs the data conversion/normalization implied by the method name.";
    if (Starts(name, "Equals") || name is "GetHashCode" or "ToString" or "CompareTo")
        return "Implements equality/display contract members.";
    if (owner.TypeName.Contains("Guard", StringComparison.OrdinalIgnoreCase))
        return "Throws when a precondition fails to prevent continuing with invalid input.";
    if (kind == "property")
        return "Exposes related state or configuration for this member.";
    return "Performs the operation declared by the signature on this type.";
}

static string InferParamMeaningFa(ParamInfo p, RawType owner, RawMember m)
{
    var n = p.Name;
    var t = p.Type;
    if (t.Contains("CancellationToken", StringComparison.Ordinal)) return "توکن لغو عملیات ناهمگام.";
    if (t.Contains("IServiceProvider", StringComparison.Ordinal)) return "ارائه‌دهنده سرویس برای resolve کردن وابستگی‌ها.";
    if (t.Contains("ILogger", StringComparison.Ordinal)) return "لاگر برای ثبت رویدادها و خطاها.";
    if (t.Contains("IConfiguration", StringComparison.Ordinal)) return "پیکربندی برنامه برای خواندن تنظیمات.";
    if (t.Contains("IServiceCollection", StringComparison.Ordinal)) return "مجموعه سرویس‌های DI که باید گسترش یابد.";
    if (t.Contains("IOptions", StringComparison.Ordinal)) return "گزینه‌های typed تنظیمات.";
    if (t.Contains("ZaminServices", StringComparison.Ordinal)) return "بسته‌ی سرویس‌های مشترک زمین (ترجمه، کاربر، و ...).";
    if (n.Equals("command", StringComparison.OrdinalIgnoreCase) || t.Contains("ICommand", StringComparison.Ordinal))
        return "فرمان ورودی برای اجرا.";
    if (n.Equals("query", StringComparison.OrdinalIgnoreCase) || t.Contains("IQuery", StringComparison.Ordinal))
        return "کوئری ورودی برای اجرا.";
    if (n.Contains("event", StringComparison.OrdinalIgnoreCase) || t.Contains("Event", StringComparison.Ordinal))
        return "رویداد دامنه/پیام برای پردازش.";
    if (n is "message" or "msg") return "پیام متنی خطا یا توضیح نقض شرط.";
    if (n is "value" or "input" or "arg") return "مقدار مورد بررسی/ورود.";
    if (n is "targetValue" or "target") return "مقدار مبنا برای مقایسه.";
    if (owner.TypeName.Contains("Guard", StringComparison.OrdinalIgnoreCase) && n == "guard")
        return "نمونه‌ی Guard برای فراخوانی زنجیره‌ای extension method.";
    if (p.HasDefault) return $"ورودی اختیاری از نوع {t} (دارای مقدار پیش‌فرض).";
    return $"ورودی از نوع {t}.";
}

static string InferParamMeaningEn(ParamInfo p, RawType owner, RawMember m)
{
    var n = p.Name;
    var t = p.Type;
    if (t.Contains("CancellationToken", StringComparison.Ordinal)) return "Token used to cancel the asynchronous operation.";
    if (t.Contains("IServiceProvider", StringComparison.Ordinal)) return "Service provider used to resolve dependencies.";
    if (t.Contains("ILogger", StringComparison.Ordinal)) return "Logger for diagnostics and error reporting.";
    if (t.Contains("IConfiguration", StringComparison.Ordinal)) return "Application configuration used to read settings.";
    if (t.Contains("IServiceCollection", StringComparison.Ordinal)) return "DI service collection to extend.";
    if (t.Contains("IOptions", StringComparison.Ordinal)) return "Typed options snapshot/wrapper.";
    if (t.Contains("ZaminServices", StringComparison.Ordinal)) return "Zamin shared services facade (translation, user, etc.).";
    if (n.Equals("command", StringComparison.OrdinalIgnoreCase) || t.Contains("ICommand", StringComparison.Ordinal))
        return "Incoming command to execute.";
    if (n.Equals("query", StringComparison.OrdinalIgnoreCase) || t.Contains("IQuery", StringComparison.Ordinal))
        return "Incoming query to execute.";
    if (n.Contains("event", StringComparison.OrdinalIgnoreCase) || t.Contains("Event", StringComparison.Ordinal))
        return "Domain/event message to process.";
    if (n is "message" or "msg") return "Error/violation message text.";
    if (n is "value" or "input" or "arg") return "Value under validation or input.";
    if (n is "targetValue" or "target") return "Comparison baseline value.";
    if (owner.TypeName.Contains("Guard", StringComparison.OrdinalIgnoreCase) && n == "guard")
        return "Guard instance for fluent extension-method chaining.";
    if (p.HasDefault) return $"Optional {t} input (has default).";
    return $"Input of type {t}.";
}

static string InferBehaviorFromBodyFa(string body, string name)
{
    if (string.IsNullOrWhiteSpace(body)) return "";
    var hints = new List<string>();
    if (body.Contains("GetRequiredService", StringComparison.Ordinal))
        hints.Add("handler/سرویس را از DI با GetRequiredService برمی‌دارد.");
    if (body.Contains("Stopwatch", StringComparison.Ordinal) || body.Contains("Elapsed", StringComparison.Ordinal))
        hints.Add("زمان اجرا را اندازه‌گیری و لاگ می‌کند.");
    if (body.Contains("LogError", StringComparison.Ordinal) || body.Contains("LogDebug", StringComparison.Ordinal) || body.Contains("LogInformation", StringComparison.Ordinal))
        hints.Add("جزئیات اجرا را لاگ می‌کند.");
    if (body.Contains("try", StringComparison.Ordinal) && body.Contains("catch", StringComparison.Ordinal))
        hints.Add("خطاها را در بلوک try/catch مدیریت می‌کند.");
    if (body.Contains("Configure<", StringComparison.Ordinal) || body.Contains("Configure(", StringComparison.Ordinal))
        hints.Add("گزینه‌های تنظیمات را Configure می‌کند.");
    if (body.Contains("AddScoped", StringComparison.Ordinal) || body.Contains("AddSingleton", StringComparison.Ordinal) || body.Contains("AddTransient", StringComparison.Ordinal))
        hints.Add("سرویس‌ها را با lifetime مشخص در DI ثبت می‌کند.");
    if (body.Contains("await ", StringComparison.Ordinal))
        hints.Add("به‌صورت ناهمگام اجرا می‌شود.");
    return hints.Count == 0 ? "" : string.Join(" ", hints);
}

static string InferBehaviorFromBodyEn(string body, string name)
{
    if (string.IsNullOrWhiteSpace(body)) return "";
    var hints = new List<string>();
    if (body.Contains("GetRequiredService", StringComparison.Ordinal))
        hints.Add("Resolves the handler/service from DI via GetRequiredService.");
    if (body.Contains("Stopwatch", StringComparison.Ordinal) || body.Contains("Elapsed", StringComparison.Ordinal))
        hints.Add("Measures and logs execution time.");
    if (body.Contains("LogError", StringComparison.Ordinal) || body.Contains("LogDebug", StringComparison.Ordinal) || body.Contains("LogInformation", StringComparison.Ordinal))
        hints.Add("Logs execution details.");
    if (body.Contains("try", StringComparison.Ordinal) && body.Contains("catch", StringComparison.Ordinal))
        hints.Add("Handles failures in a try/catch block.");
    if (body.Contains("Configure<", StringComparison.Ordinal) || body.Contains("Configure(", StringComparison.Ordinal))
        hints.Add("Configures options bindings.");
    if (body.Contains("AddScoped", StringComparison.Ordinal) || body.Contains("AddSingleton", StringComparison.Ordinal) || body.Contains("AddTransient", StringComparison.Ordinal))
        hints.Add("Registers services with an explicit DI lifetime.");
    if (body.Contains("await ", StringComparison.Ordinal))
        hints.Add("Runs asynchronously.");
    return hints.Count == 0 ? "" : string.Join(" ", hints);
}

static string InferPreconditionsFa(RawType owner, RawMember m, string body, List<ParamInfo> parameters)
{
    var parts = new List<string>();
    if (owner.InjectedDependencies is { Count: > 0 } && m.Kind is "method" or "property")
        parts.Add("نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند");
    if (body.Contains("_commandDispatcher", StringComparison.Ordinal) || body.Contains("SetCommandDispatcher", StringComparison.Ordinal))
        parts.Add("قبل از Send باید SetCommandDispatcher فراخوانی شده باشد");
    if (body.Contains("_queryDispatcher", StringComparison.Ordinal) || body.Contains("SetQueryDispatcher", StringComparison.Ordinal))
        parts.Add("قبل از Execute باید SetQueryDispatcher فراخوانی شده باشد");
    if (body.Contains("_eventDispatcher", StringComparison.Ordinal) || body.Contains("SetEventDispatcher", StringComparison.Ordinal))
        parts.Add("قبل از Publish باید SetEventDispatcher فراخوانی شده باشد");
    if (body.Contains("GetRequiredService", StringComparison.Ordinal))
        parts.Add("سرویس/handler مربوطه باید در DI ثبت شده باشد وگرنه InvalidOperationException رخ می‌دهد");
    if (owner.TypeName.Contains("Guard", StringComparison.OrdinalIgnoreCase))
        parts.Add("برای جلوگیری از ادامه با داده نامعتبر، معمولاً در ابتدای متدهای عمومی فراخوانی می‌شود");
    return string.Join("؛ ", parts);
}

static string InferPreconditionsEn(RawType owner, RawMember m, string body, List<ParamInfo> parameters)
{
    var parts = new List<string>();
    if (owner.InjectedDependencies is { Count: > 0 } && m.Kind is "method" or "property")
        parts.Add("instance should be resolved via DI so constructor dependencies are available");
    if (body.Contains("_commandDispatcher", StringComparison.Ordinal) || body.Contains("SetCommandDispatcher", StringComparison.Ordinal))
        parts.Add("SetCommandDispatcher must be called before Send");
    if (body.Contains("_queryDispatcher", StringComparison.Ordinal) || body.Contains("SetQueryDispatcher", StringComparison.Ordinal))
        parts.Add("SetQueryDispatcher must be called before Execute");
    if (body.Contains("_eventDispatcher", StringComparison.Ordinal) || body.Contains("SetEventDispatcher", StringComparison.Ordinal))
        parts.Add("SetEventDispatcher must be called before Publish");
    if (body.Contains("GetRequiredService", StringComparison.Ordinal))
        parts.Add("the required service/handler must be registered in DI or InvalidOperationException is thrown");
    if (owner.TypeName.Contains("Guard", StringComparison.OrdinalIgnoreCase))
        parts.Add("typically called at the start of public methods to block invalid input");
    return string.Join("; ", parts);
}

static void ApplyCuratedOverrides(EnrichedNamespaceDoc doc)
{
    foreach (var t in doc.Types)
    {
        foreach (var m in t.Members)
        {
            var key = $"{t.TypeName}|{m.Name}|{m.Signature}";
            if (!GetCurated().TryGetValue(SimplifyKey(t.TypeName, m.Name, m.Signature), out var overrideDoc))
                continue;
            m.GeneratedDoc = overrideDoc;
            m.Source = string.IsNullOrWhiteSpace(m.XmlDoc) ? "generated" : m.Source;
            // curated items are intentionally refined — keep them out of generic incompleteness
        }
    }
}

static string SimplifyKey(string typeName, string member, string signature)
{
    var hasData = signature.Contains("CommandResult<TData>", StringComparison.Ordinal)
               || signature.Contains("QueryResult<TData>", StringComparison.Ordinal)
               || signature.Contains(", TData>", StringComparison.Ordinal)
               || (signature.Contains("TData", StringComparison.Ordinal) && signature.Contains("Send<", StringComparison.Ordinal));
    var variant = hasData ? "withData" : "noData";
    return $"{StripGenerics(typeName)}|{member}|{variant}";
}

static Dictionary<string, GeneratedDoc> GetCurated() => new(StringComparer.Ordinal)
{
    ["CommandDispatcher|Send|noData"] = new GeneratedDoc
    {
        Fa = """
متد Send فرمان بدون دادهٔ بازگشتی را به ICommandHandler<TCommand> مسیریابی می‌کند.
پارامترها:
- command (TCommand): فرمان ورودی که باید class و ICommand باشد.
مقدار بازگشتی: Task<CommandResult> نتیجه اجرای handler.
استثناها (قابل تشخیص از کد):
- InvalidOperationException: وقتی handler متناظر در DI ثبت نشده باشد (GetRequiredService)؛ پس از لاگ خطا دوباره throw می‌شود.
سایر استثناهای handler نیز به بالا منتشر می‌شوند.
پیش‌شرط/وابستگی: ICommandHandler<TCommand> باید در DI ثبت شده باشد؛ نمونه CommandDispatcher باید از DI ساخته شود (IServiceProvider، ILogger).
در finally مدت اجرا با Stopwatch اندازه‌گیری و لاگ performance ثبت می‌شود.
""",
        En = """
Send routes a non-generic command to ICommandHandler<TCommand> and awaits Handle.
Parameters:
- command (TCommand): incoming command; must be a class implementing ICommand.
Returns: Task<CommandResult> from the handler.
Exceptions (from code):
- InvalidOperationException when the matching handler is not registered in DI (GetRequiredService); logged then rethrown.
Other handler exceptions propagate.
Preconditions/dependencies: ICommandHandler<TCommand> must be registered; CommandDispatcher must be DI-constructed (IServiceProvider, ILogger).
Finally block measures elapsed time with Stopwatch and writes a performance log.
"""
    },
    ["CommandDispatcher|Send|withData"] = new GeneratedDoc
    {
        Fa = """
متد Send فرمان دارای دادهٔ بازگشتی را به ICommandHandler<TCommand, TData> مسیریابی می‌کند.
پارامترها:
- command (TCommand): فرمان ورودی که ICommand<TData> را پیاده می‌کند.
مقدار بازگشتی: Task<CommandResult<TData>> شامل وضعیت و دادهٔ نتیجه.
استثناها (قابل تشخیص از کد):
- هر Exception از resolve/اجرای handler لاگ و سپس دوباره throw می‌شود (برخلاف overload بدون TData که فقط InvalidOperationException را catch می‌کند).
پیش‌شرط/وابستگی: ثبت ICommandHandler<TCommand, TData> در DI؛ ساخت Dispatcher از DI.
""",
        En = """
Send routes a command with a result payload to ICommandHandler<TCommand, TData>.
Parameters:
- command (TCommand): command implementing ICommand<TData>.
Returns: Task<CommandResult<TData>> with status and data.
Exceptions (from code):
- Any Exception from resolve/execution is logged and rethrown (unlike the non-generic overload which catches only InvalidOperationException).
Preconditions/dependencies: ICommandHandler<TCommand, TData> registered in DI; dispatcher resolved via DI.
"""
    },
    ["CommandDispatcherValidationDecorator|Send|noData"] = new GeneratedDoc
    {
        Fa = """
دکوریتور اعتبارسنجی قبل از ارسال فرمان: اگر IValidator<TCommand> در DI باشد، Validate اجرا می‌شود؛ در صورت نامعتبر بودن، CommandResult با Status=ValidationError و پیام‌های FluentValidation برمی‌گردد و Send داخلی فراخوانی نمی‌شود. اگر validator نباشد فقط لاگ می‌شود و فرمان ادامه می‌یابد.
پارامترها:
- command (TCommand): فرمان برای اعتبارسنجی و اجرا.
مقدار بازگشتی: Task<CommandResult> (خطای اعتبارسنجی یا نتیجه dispatcher داخلی).
استثناها: استثنای صریح در این متد نیست؛ خطاهای validator به‌صورت نتیجه برمی‌گردند. خطاهای لایه بعدی ممکن است throw شوند.
پیش‌شرط: SetCommandDispatcher باید قبلاً فراخوانی شده باشد؛ Order این دکوریتور = 1 (قبل از DomainException handler).
""",
        En = """
Validation decorator before command dispatch: if IValidator<TCommand> exists in DI, runs Validate; on failure returns CommandResult with Status=ValidationError and FluentValidation messages without calling the inner Send. If no validator is registered, logs and continues.
Parameters:
- command (TCommand): command to validate then execute.
Returns: Task<CommandResult> (validation failure or inner dispatcher result).
Exceptions: none thrown here for validation failures (returned as result); inner pipeline may throw.
Preconditions: SetCommandDispatcher must have been called; Order = 1 (runs before domain-exception decorator).
"""
    },
    ["CommandDispatcherValidationDecorator|Send|withData"] = new GeneratedDoc
    {
        Fa = """
همان منطق اعتبارسنجی دکوریتور برای فرمان‌های دارای TData؛ در خطا CommandResult<TData> با ValidationError برمی‌گردد، در موفقیت به _commandDispatcher.Send<TCommand,TData> تفویض می‌شود.
پارامترها:
- command (TCommand): فرمان ICommand<TData>.
مقدار بازگشتی: Task<CommandResult<TData>>.
پیش‌شرط: SetCommandDispatcher؛ ثبت اختیاری IValidator<TCommand>.
""",
        En = """
Same validation decorator logic for commands with TData; on failure returns CommandResult<TData> with ValidationError, otherwise delegates to _commandDispatcher.Send<TCommand,TData>.
Parameters:
- command (TCommand): ICommand<TData> command.
Returns: Task<CommandResult<TData>>.
Preconditions: SetCommandDispatcher called; optional IValidator<TCommand> registration.
"""
    },
    ["CommandDispatcherDomainExceptionHandlerDecorator|Send|noData"] = new GeneratedDoc
    {
        Fa = """
دکوریتور مدیریت DomainStateException: Send داخلی را فراخوانی می‌کند؛ اگر DomainStateException (یا AggregateException با Inner از همان نوع) رخ دهد، آن را به CommandResult با Status=InvalidDomainState و پیام ترجمه‌شده (ITranslator در صورت وجود) تبدیل می‌کند به‌جای پرتاب استثنا. سایر AggregateExceptionها دوباره throw می‌شوند.
پارامترها:
- command (TCommand): فرمان در حال اجرا.
مقدار بازگشتی: Task<CommandResult> موفق یا معادل خطای دامنه.
استثناها: DomainStateException بلعیده و به نتیجه تبدیل می‌شود؛ سایر استثناها propagate می‌شوند.
پیش‌شرط: SetCommandDispatcher؛ Order = 2. وابستگی اختیاری ITranslator برای متن پیام.
""",
        En = """
Domain exception decorator: calls inner Send; on DomainStateException (or AggregateException whose inner is DomainStateException) converts it to CommandResult with Status=InvalidDomainState and a translated message (via ITranslator when available) instead of throwing. Other AggregateExceptions are rethrown.
Parameters:
- command (TCommand): command being executed.
Returns: Task<CommandResult> success or domain-error result.
Exceptions: DomainStateException is swallowed into the result; other exceptions propagate.
Preconditions: SetCommandDispatcher; Order = 2. Optional ITranslator for message text.
"""
    },
    ["CommandDispatcherDomainExceptionHandlerDecorator|Send|withData"] = new GeneratedDoc
    {
        Fa = """
نسخهٔ دارای TData از دکوریتور DomainStateException؛ خطاهای دامنه به CommandResult<TData> با InvalidDomainState نگاشت می‌شوند.
پارامترها:
- command (TCommand): فرمان ICommand<TData>.
مقدار بازگشتی: Task<CommandResult<TData>>.
پیش‌شرط: SetCommandDispatcher؛ Order = 2.
""",
        En = """
TData variant of the DomainStateException decorator; domain failures map to CommandResult<TData> with InvalidDomainState.
Parameters:
- command (TCommand): ICommand<TData> command.
Returns: Task<CommandResult<TData>>.
Preconditions: SetCommandDispatcher; Order = 2.
"""
    },
};

static void MaybeFlagReview(RawType t, RawMember? m, GeneratedDoc doc, ConcurrentBag<ReviewItem> review)
{
    if (m != null && GetCurated().ContainsKey(SimplifyKey(t.TypeName, m.Name, m.Signature ?? "")))
        return;

    var body = m?.BodySummary ?? "";
    var reasons = new List<string>();

    if (body.Length > 1200)
        reasons.Add("بدنه بسیار طولانی/پیچیده");
    if (Regex.Matches(body, @"\bif\b").Count >= 8)
        reasons.Add("شاخه‌بندی زیاد (ifهای متعدد)");
    if (body.Contains("GetMethod(", StringComparison.Ordinal)
        || body.Contains("Activator.", StringComparison.Ordinal)
        || body.Contains("Expression<", StringComparison.Ordinal)
        || body.Contains("MakeGenericMethod", StringComparison.Ordinal))
        reasons.Add("استفاده از reflection/expression");
    if (body.Contains("dynamic ", StringComparison.Ordinal) || body.Contains("(dynamic)", StringComparison.Ordinal))
        reasons.Add("استفاده از dynamic");
    if ((t.TypeName.Contains("Dispatcher", StringComparison.OrdinalIgnoreCase)
         || t.TypeName.Contains("Decorator", StringComparison.OrdinalIgnoreCase))
        && m is { Kind: "method", Name: "Send" or "Publish" or "Execute" or "QueryAsync" or "ExecuteAsync" }
        && body.Length > 500)
        reasons.Add("منطق مرکزی dispatcher/decorator");
    if (string.IsNullOrWhiteSpace(body) && m is { Kind: "method" }
        && string.IsNullOrWhiteSpace(m.XmlDoc)
        && !(m.Signature?.Contains("abstract", StringComparison.Ordinal) ?? false)
        && t.Kind != "interface"
        && body.Length == 0
        && (m.Signature?.Contains("=>", StringComparison.Ordinal) != true))
    {
        // only flag if signature suggests it should have had a body
        if (!(m.Signature?.Contains(";", StringComparison.Ordinal) ?? true))
            reasons.Add("متد بدون بدنه و بدون XML");
    }

    if (doc.En.Contains("Performs the operation declared by the signature", StringComparison.Ordinal)
        && body.Length > 600)
        reasons.Add("توضیح تولیدشده عمومی روی منطق غیربدیهی");

    if (reasons.Count == 0) return;

    review.Add(new ReviewItem
    {
        Namespace = t.Namespace,
        TypeName = t.TypeName,
        MemberName = m?.Name ?? "(type)",
        Kind = m?.Kind ?? t.Kind,
        Reason = string.Join("؛ ", reasons),
        SourceFile = t.SourceFile,
    });
}

static string BuildRelatedContext(RawType t, Dictionary<string, RawType> typeIndex)
{
    var parts = new List<string>();
    foreach (var b in t.BaseTypes ?? [])
    {
        var key = StripGenerics(b);
        parts.Add(typeIndex.ContainsKey(key) ? $"{b} (same namespace)" : b);
    }
    if (t.InjectedDependencies is { Count: > 0 })
        parts.Add("DI: " + string.Join(", ", t.InjectedDependencies.Take(5)));
    return string.Join(" | ", parts);
}

static void WriteSummary(string path, Stats stats, List<ReviewItem> review, int nsCount)
{
    var sb = new StringBuilder();
    sb.AppendLine("# Zamin API Doc Enrichment Summary");
    sb.AppendLine();
    sb.AppendLine($"Generated at (UTC): {DateTime.UtcNow:O}");
    sb.AppendLine();
    sb.AppendLine("## Counts");
    sb.AppendLine();
    sb.AppendLine($"- Namespaces processed: **{nsCount}**");
    sb.AppendLine($"- Items kept from existing XML (`source: existing`, unmodified meaning): **{stats.ExistingCount}**");
    sb.AppendLine($"- Existing XML completed/supplemented (`source: existing`, `doc_completed: true`): **{stats.CompletedExistingCount}**");
    sb.AppendLine($"- Items fully generated by model/tool (`source: generated`): **{stats.GeneratedCount}**");
    sb.AppendLine($"- Human-review candidates: **{review.Count}**");
    sb.AppendLine();
    sb.AppendLine("## Notes");
    sb.AppendLine();
    sb.AppendLine("- Raw files under `framework-docs/raw-extraction/` were left untouched.");
    sb.AppendLine("- Each enriched item includes `generated_doc.fa`, `generated_doc.en`, and `source` (`existing` | `generated`).");
    sb.AppendLine("- Exception/precondition notes are only claimed when detectable from signature/body patterns.");
    sb.AppendLine();
    sb.AppendLine("## Human review list");
    sb.AppendLine();
    if (review.Count == 0)
    {
        sb.AppendLine("_No items flagged._");
    }
    else
    {
        sb.AppendLine("| Namespace | Type | Member | Kind | Reason | Source file |");
        sb.AppendLine("|---|---|---|---|---|---|");
        foreach (var r in review)
        {
            sb.AppendLine($"| {Esc(r.Namespace)} | {Esc(r.TypeName)} | {Esc(r.MemberName)} | {Esc(r.Kind)} | {Esc(r.Reason)} | {Esc(r.SourceFile)} |");
        }
    }

    File.WriteAllText(path, sb.ToString(), Encoding.UTF8);

    static string Esc(string? s) => (s ?? "").Replace("|", "\\|").Replace("\n", " ").Replace("\r", "");
}

// ───────────────────────── helpers ─────────────────────────

static string FindRepoRoot()
{
    var dir = new DirectoryInfo(AppContext.BaseDirectory);
    while (dir != null)
    {
        if (Directory.Exists(Path.Combine(dir.FullName, "Onion"))
            && Directory.Exists(Path.Combine(dir.FullName, "framework-docs")))
            return dir.FullName;
        dir = dir.Parent;
    }
    throw new InvalidOperationException("Repo root not found");
}

static string StripGenerics(string name)
{
    var i = name.IndexOf('<');
    return i < 0 ? name : name[..i];
}

static string CollapseWs(string s) => Regex.Replace(s, @"\s+", " ").Trim();

static bool Starts(string name, string prefix) =>
    name.StartsWith(prefix, StringComparison.OrdinalIgnoreCase);

static bool ThrowsAny(List<string> throws) => throws.Count > 0;

static bool BodyAssignsFields(string body) =>
    body.Contains(" = ", StringComparison.Ordinal) && (body.Contains("this.", StringComparison.Ordinal) || body.Contains("_", StringComparison.Ordinal));

static bool LooksLikePersian(string text) =>
    text.Any(c => c is >= '\u0600' and <= '\u06FF');

static string EnglishFromPersianHints(string persianSummary, string name, string kind, bool isType)
{
    // Keep author intent: provide a concise English counterpart without claiming literal translation.
    var role = isType ? kind : kind;
    return $"Documents {role} '{name}'. Original XML summary (FA): {Truncate(CollapseWs(persianSummary), 240)}";
}

static string DefaultEnSummary(string name, string kind, bool isType) =>
    isType ? $"Description of {kind} '{name}'." : $"Description of {kind} '{name}'.";

static string Capitalize(string s) =>
    string.IsNullOrEmpty(s) ? s : char.ToUpperInvariant(s[0]) + s[1..];

static string Truncate(string s, int max) =>
    s.Length <= max ? s : s[..max] + "…";

// ───────────────────────── analyzers ─────────────────────────

static class ThrowAnalyzer
{
    static readonly Regex ThrowNew = new(@"throw\s+new\s+([A-Za-z0-9_.<>,\s]+?)\s*\(", RegexOptions.Compiled);
    static readonly Regex ThrowExpr = new(@"throw\s+([A-Za-z0-9_]+)\s*;", RegexOptions.Compiled);

    public static List<string> FindThrows(string body)
    {
        var list = new List<string>();
        if (string.IsNullOrWhiteSpace(body)) return list;
        foreach (Match m in ThrowNew.Matches(body))
            list.Add(Collapse(m.Groups[1].Value.Trim()) + " (throw new)");
        foreach (Match m in ThrowExpr.Matches(body))
            list.Add(m.Groups[1].Value + " (rethrow/throw)");
        return list;
    }

    public static List<string> FindNullGuards(string body)
    {
        var list = new List<string>();
        if (string.IsNullOrWhiteSpace(body)) return list;
        if (body.Contains("ArgumentNullException", StringComparison.Ordinal))
            list.Add("ArgumentNullException");
        if (body.Contains("ArgumentException", StringComparison.Ordinal))
            list.Add("ArgumentException");
        if (body.Contains("ArgumentOutOfRangeException", StringComparison.Ordinal))
            list.Add("ArgumentOutOfRangeException");
        if (body.Contains("InvalidOperationException", StringComparison.Ordinal))
            list.Add("InvalidOperationException");
        if (body.Contains("NullReferenceException", StringComparison.Ordinal))
            list.Add("NullReferenceException");
        return list.Distinct().ToList();
    }

    static string Collapse(string s) => Regex.Replace(s, @"\s+", "");
}

static class ParamParser
{
    public static List<ParamInfo> Parse(string signature)
    {
        var list = new List<ParamInfo>();
        if (string.IsNullOrWhiteSpace(signature)) return list;

        // Take the last (...) parameter list (handles generics in name carefully enough for our corpus)
        var open = signature.LastIndexOf('(');
        var close = signature.LastIndexOf(')');
        if (open < 0 || close <= open) return list;
        var inside = signature[(open + 1)..close].Trim();
        if (string.IsNullOrWhiteSpace(inside)) return list;

        foreach (var raw in SplitParams(inside))
        {
            var p = raw.Trim();
            if (string.IsNullOrEmpty(p)) continue;
            p = Regex.Replace(p, @"^(this|ref|out|in|params)\s+", "", RegexOptions.None);
            var hasDefault = p.Contains('=');
            if (hasDefault) p = p.Split('=')[0].Trim();

            // attributes on params
            p = Regex.Replace(p, @"\[[^\]]*\]\s*", "");

            var parts = p.Split((char[]?)null, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length < 2) continue;
            var name = parts[^1].TrimStart('@');
            var type = string.Join(" ", parts[..^1]);
            list.Add(new ParamInfo { Name = name, Type = type, HasDefault = hasDefault });
        }
        return list;
    }

    static IEnumerable<string> SplitParams(string inside)
    {
        var sb = new StringBuilder();
        var depth = 0;
        foreach (var ch in inside)
        {
            if (ch is '<' or '(' or '[') depth++;
            else if (ch is '>' or ')' or ']') depth = Math.Max(0, depth - 1);

            if (ch == ',' && depth == 0)
            {
                yield return sb.ToString();
                sb.Clear();
            }
            else sb.Append(ch);
        }
        if (sb.Length > 0) yield return sb.ToString();
    }
}

static class ReturnTypeParser
{
    public static string GetReturnType(string signature, string kind)
    {
        if (kind is "constructor" or "field" or "event" or "enum_member" or "primary_constructor_parameter")
            return "";
        if (kind == "property")
            return PropertyTypeParser.GetType(signature);

        var s = signature.Trim();
        // strip attributes at start
        while (s.StartsWith('['))
        {
            var end = s.IndexOf(']');
            if (end < 0) break;
            s = s[(end + 1)..].TrimStart();
        }

        // remove modifiers
        s = Regex.Replace(s,
            @"\b(public|protected|private|internal|static|virtual|override|abstract|async|sealed|partial|extern|new|unsafe|required)\b\s*",
            "", RegexOptions.None);

        // operator forms
        if (s.Contains(" operator ", StringComparison.Ordinal))
        {
            var beforeOp = s.Split(new[] { " operator " }, StringSplitOptions.None)[0].Trim();
            return beforeOp;
        }

        // method: ReturnType Name<...>(
        var nameIdx = FindMethodNameIndex(s);
        if (nameIdx <= 0) return "";
        return s[..nameIdx].Trim();
    }

    static int FindMethodNameIndex(string s)
    {
        var paren = s.IndexOf('(');
        if (paren < 0) return -1;
        // walk left from '(' skipping generics
        var i = paren - 1;
        while (i >= 0 && char.IsWhiteSpace(s[i])) i--;
        if (i >= 0 && s[i] == '>')
        {
            var depth = 0;
            for (; i >= 0; i--)
            {
                if (s[i] == '>') depth++;
                else if (s[i] == '<')
                {
                    depth--;
                    if (depth == 0) { i--; break; }
                }
            }
            while (i >= 0 && char.IsWhiteSpace(s[i])) i--;
        }
        var end = i;
        while (i >= 0 && (char.IsLetterOrDigit(s[i]) || s[i] is '_' or '@')) i--;
        return i + 1 <= end ? i + 1 : -1;
    }
}

static class PropertyTypeParser
{
    public static string GetType(string signature)
    {
        var s = Regex.Replace(signature ?? "",
            @"\b(public|protected|private|internal|static|virtual|override|abstract|sealed|partial|new|required|unsafe)\b\s*",
            "");
        var brace = s.IndexOf('{');
        var arrow = s.IndexOf("=>", StringComparison.Ordinal);
        var cut = s.Length;
        if (brace >= 0) cut = Math.Min(cut, brace);
        if (arrow >= 0) cut = Math.Min(cut, arrow);
        s = s[..cut].Trim();
        var parts = s.Split((char[]?)null, StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length < 2) return s;
        return string.Join(" ", parts[..^1]);
    }
}

static class XmlDocParser
{
    public static ParsedXmlDoc Parse(string raw)
    {
        var result = new ParsedXmlDoc();
        if (string.IsNullOrWhiteSpace(raw)) return result;

        var cleaned = StripSlashes(raw);
        // Wrap fragments into a root
        var xml = "<root>" + EscapeInvalid(cleaned) + "</root>";
        try
        {
            var doc = XDocument.Parse(xml, LoadOptions.PreserveWhitespace);
            result.Summary = InnerText(doc.Root?.Element("summary"));
            result.Returns = InnerText(doc.Root?.Element("returns"));
            result.Remarks = InnerText(doc.Root?.Element("remarks"));
            foreach (var p in doc.Root?.Elements("param") ?? [])
            {
                var name = (string?)p.Attribute("name") ?? "";
                if (string.IsNullOrWhiteSpace(name)) name = $"param_{result.Params.Count}";
                result.Params[name] = InnerText(p);
            }
            foreach (var e in doc.Root?.Elements("exception") ?? [])
            {
                var name = (string?)e.Attribute("cref") ?? "";
                name = name.Replace("T:", "");
                if (string.IsNullOrWhiteSpace(name)) name = $"exception_{result.Exceptions.Count}";
                result.Exceptions[name] = InnerText(e);
            }
        }
        catch
        {
            result.Summary = cleaned;
        }
        return result;
    }

    public static string StripSlashes(string raw)
    {
        var lines = raw.Replace("\r\n", "\n").Replace('\r', '\n').Split('\n');
        var sb = new StringBuilder();
        foreach (var line in lines)
        {
            var t = line.TrimStart();
            if (t.StartsWith("///", StringComparison.Ordinal))
                t = t[3..];
            else if (t.StartsWith("/**", StringComparison.Ordinal) || t.StartsWith("*/", StringComparison.Ordinal) || t.StartsWith('*'))
                t = t.TrimStart('/', '*');
            sb.AppendLine(t);
        }
        return sb.ToString().Trim();
    }

    static string InnerText(XElement? el)
    {
        if (el == null) return "";
        return CollapseWs(string.Concat(el.Nodes().Select(n => n.ToString())));
        static string CollapseWs(string s) => Regex.Replace(System.Net.WebUtility.HtmlDecode(s)
            .Replace("<see cref=\"", "")
            .Replace("\" />", "")
            .Replace("\"/>", ""),
            @"\s+", " ").Trim();
    }

    static string EscapeInvalid(string s)
    {
        // Common XML doc issues: unescaped & < outside tags — light fix for &
        return Regex.Replace(s, @"&(?!(lt|gt|amp|quot|apos);)", "&amp;");
    }
}

// ───────────────────────── models ─────────────────────────

sealed class Stats
{
    public int ExistingCount;
    public int GeneratedCount;
    public int CompletedExistingCount;
}

sealed class ReviewItem
{
    public string Namespace { get; set; } = "";
    public string TypeName { get; set; } = "";
    public string MemberName { get; set; } = "";
    public string Kind { get; set; } = "";
    public string Reason { get; set; } = "";
    public string SourceFile { get; set; } = "";
}

sealed class ParamInfo
{
    public string Name { get; set; } = "";
    public string Type { get; set; } = "";
    public bool HasDefault { get; set; }
}

sealed class ParsedXmlDoc
{
    public string Summary { get; set; } = "";
    public string Returns { get; set; } = "";
    public string Remarks { get; set; } = "";
    public Dictionary<string, string> Params { get; set; } = new(StringComparer.Ordinal);
    public Dictionary<string, string> Exceptions { get; set; } = new(StringComparer.Ordinal);
}

sealed class GeneratedDoc
{
    public string Fa { get; set; } = "";
    public string En { get; set; } = "";
}

sealed class RawNamespaceDoc
{
    public string Namespace { get; set; } = "";
    public int TypeCount { get; set; }
    public List<RawType> Types { get; set; } = [];
}

sealed class RawType
{
    public string TypeName { get; set; } = "";
    public string Kind { get; set; } = "";
    public string Namespace { get; set; } = "";
    public string SourceFile { get; set; } = "";
    public List<string> BaseTypes { get; set; } = [];
    public string GenericConstraints { get; set; } = "";
    public List<string> Attributes { get; set; } = [];
    public string XmlDoc { get; set; } = "";
    public List<string> InjectedDependencies { get; set; } = [];
    public List<RawMember> Members { get; set; } = [];
}

sealed class RawMember
{
    public string Name { get; set; } = "";
    public string Kind { get; set; } = "";
    public string Signature { get; set; } = "";
    public string XmlDoc { get; set; } = "";
    public string BodySummary { get; set; } = "";
    public List<string> Attributes { get; set; } = [];
}

sealed class EnrichedNamespaceDoc
{
    public string Namespace { get; set; } = "";
    public int TypeCount { get; set; }
    public List<EnrichedType> Types { get; set; } = [];
}

sealed class EnrichedType
{
    public string TypeName { get; set; } = "";
    public string Kind { get; set; } = "";
    public string Namespace { get; set; } = "";
    public string SourceFile { get; set; } = "";
    public List<string> BaseTypes { get; set; } = [];
    public string GenericConstraints { get; set; } = "";
    public List<string> Attributes { get; set; } = [];
    public string XmlDoc { get; set; } = "";
    public List<string> InjectedDependencies { get; set; } = [];
    public List<EnrichedMember> Members { get; set; } = [];
    public GeneratedDoc GeneratedDoc { get; set; } = new();
    public string Source { get; set; } = "generated";
    public bool DocCompleted { get; set; }
}

sealed class EnrichedMember
{
    public string Name { get; set; } = "";
    public string Kind { get; set; } = "";
    public string Signature { get; set; } = "";
    public string XmlDoc { get; set; } = "";
    public string BodySummary { get; set; } = "";
    public List<string> Attributes { get; set; } = [];
    public GeneratedDoc GeneratedDoc { get; set; } = new();
    public string Source { get; set; } = "generated";
    public bool DocCompleted { get; set; }
}
