using System.Collections.Concurrent;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

static string FindRepoRoot()
{
    var dir = new DirectoryInfo(AppContext.BaseDirectory);
    while (dir != null)
    {
        if (File.Exists(Path.Combine(dir.FullName, "Directory.Build.props"))
            && Directory.Exists(Path.Combine(dir.FullName, "Onion")))
            return dir.FullName;
        dir = dir.Parent;
    }

    // Fallback: tools/Zamin.SourceExtractor -> repo root
    var fromCwd = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "..", ".."));
    if (Directory.Exists(Path.Combine(fromCwd, "Onion")))
        return fromCwd;

    throw new InvalidOperationException("Could not locate Zamin repository root.");
}

var repoRoot = args.Length > 0 ? Path.GetFullPath(args[0]) : FindRepoRoot();
var outputDir = args.Length > 1
    ? Path.GetFullPath(args[1])
    : Path.Combine(repoRoot, "framework-docs", "raw-extraction");

Directory.CreateDirectory(outputDir);
foreach (var existing in Directory.EnumerateFiles(outputDir, "*.json"))
    File.Delete(existing);
var errorsPath = Path.Combine(outputDir, "_errors.log");
if (File.Exists(errorsPath))
    File.Delete(errorsPath);

var errorLog = new ConcurrentBag<string>();
void LogError(string message)
{
    var line = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}";
    Console.Error.WriteLine(line);
    errorLog.Add(line);
}

Console.WriteLine($"Repo root : {repoRoot}");
Console.WriteLine($"Output dir: {outputDir}");

var excludePathFragments = new[]
{
    $"{Path.DirectorySeparatorChar}bin{Path.DirectorySeparatorChar}",
    $"{Path.DirectorySeparatorChar}obj{Path.DirectorySeparatorChar}",
    $"{Path.DirectorySeparatorChar}tools{Path.DirectorySeparatorChar}",
    $"{Path.DirectorySeparatorChar}framework-docs{Path.DirectorySeparatorChar}",
};

bool IsFrameworkSource(string fullPath)
{
    var normalized = fullPath.Replace('/', Path.DirectorySeparatorChar);
    foreach (var frag in excludePathFragments)
    {
        if (normalized.Contains(frag, StringComparison.OrdinalIgnoreCase))
            return false;
    }

    // Exclude sample apps / backup projects, keep framework libraries only
    if (normalized.Contains($"{Path.DirectorySeparatorChar}sample{Path.DirectorySeparatorChar}", StringComparison.OrdinalIgnoreCase))
        return false;
    if (normalized.Contains(".Sample", StringComparison.OrdinalIgnoreCase))
        return false;
    if (normalized.Contains(" - Backup.", StringComparison.OrdinalIgnoreCase))
        return false;

    return true;
}

var csFiles = Directory.EnumerateFiles(repoRoot, "*.cs", SearchOption.AllDirectories)
    .Where(IsFrameworkSource)
    .OrderBy(f => f, StringComparer.OrdinalIgnoreCase)
    .ToList();

Console.WriteLine($"Scanning {csFiles.Count} .cs files...");

// Key: namespace + "|" + type name (including nested Type.Outer.Inner)
var typesByKey = new ConcurrentDictionary<string, ExtractedType>(StringComparer.Ordinal);

foreach (var file in csFiles)
{
    try
    {
        var text = File.ReadAllText(file);
        var tree = CSharpSyntaxTree.ParseText(text, path: file, encoding: Encoding.UTF8);
        var root = tree.GetCompilationUnitRoot();

        foreach (var typeDecl in root.DescendantNodes().OfType<BaseTypeDeclarationSyntax>())
        {
            try
            {
                if (!IsPublicOrProtected(typeDecl.Modifiers))
                    continue;

                // Skip local/nested private-context types that aren't public/protected
                if (IsInNonExtractableContext(typeDecl))
                    continue;

                var ns = GetNamespace(typeDecl);
                var typeName = GetFullTypeName(typeDecl);
                var key = ns + "|" + typeName;

                var extracted = ExtractType(typeDecl, ns, typeName, file, repoRoot);
                typesByKey.AddOrUpdate(
                    key,
                    extracted,
                    (_, existing) => MergePartial(existing, extracted));
            }
            catch (Exception ex)
            {
                LogError($"Type extract failed in {file}: {ex.Message}");
            }
        }
    }
    catch (Exception ex)
    {
        LogError($"File parse failed: {file} :: {ex.Message}");
    }
}

var byNamespace = typesByKey.Values
    .GroupBy(t => t.Namespace, StringComparer.Ordinal)
    .OrderBy(g => g.Key, StringComparer.Ordinal)
    .ToList();

var jsonOptions = new JsonSerializerOptions
{
    WriteIndented = true,
    DefaultIgnoreCondition = JsonIgnoreCondition.Never,
    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
    PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
};

var indexEntries = new List<IndexEntry>();

foreach (var group in byNamespace)
{
    var ns = group.Key;
    var types = group
        .OrderBy(t => t.TypeName, StringComparer.Ordinal)
        .ToList();

    var fileName = SanitizeFileName(ns) + ".json";
    var path = Path.Combine(outputDir, fileName);

    var doc = new NamespaceDocument
    {
        Namespace = ns,
        TypeCount = types.Count,
        Types = types,
    };

    File.WriteAllText(path, JsonSerializer.Serialize(doc, jsonOptions), Encoding.UTF8);
    indexEntries.Add(new IndexEntry
    {
        Namespace = ns,
        File = fileName,
        TypeCount = types.Count,
    });

    Console.WriteLine($"  {ns}: {types.Count} type(s) -> {fileName}");
}

var index = new IndexDocument
{
    GeneratedAt = DateTime.UtcNow.ToString("O"),
    RepoRoot = repoRoot,
    SourceFileCount = csFiles.Count,
    NamespaceCount = indexEntries.Count,
    TotalTypes = indexEntries.Sum(e => e.TypeCount),
    Namespaces = indexEntries,
};

File.WriteAllText(
    Path.Combine(outputDir, "_index.json"),
    JsonSerializer.Serialize(index, jsonOptions),
    Encoding.UTF8);

File.WriteAllLines(errorsPath, errorLog.OrderBy(x => x));

Console.WriteLine();
Console.WriteLine($"Done. Namespaces={index.NamespaceCount}, Types={index.TotalTypes}, Errors={errorLog.Count}");
Console.WriteLine($"Index: {Path.Combine(outputDir, "_index.json")}");

// ───────────────────────── extraction helpers ─────────────────────────

static bool IsPublicOrProtected(SyntaxTokenList modifiers)
{
    return modifiers.Any(m => m.IsKind(SyntaxKind.PublicKeyword)
                           || m.IsKind(SyntaxKind.ProtectedKeyword));
}

static bool IsInNonExtractableContext(BaseTypeDeclarationSyntax typeDecl)
{
    // Nested types: only extract if every enclosing type is also public/protected
    foreach (var enclosing in typeDecl.Ancestors().OfType<BaseTypeDeclarationSyntax>())
    {
        if (!IsPublicOrProtected(enclosing.Modifiers))
            return true;
    }
    return false;
}

static string GetNamespace(SyntaxNode node)
{
    var fileScoped = node.Ancestors().OfType<FileScopedNamespaceDeclarationSyntax>().FirstOrDefault();
    if (fileScoped != null)
        return fileScoped.Name.ToString();

    var parts = new Stack<string>();
    foreach (var ns in node.Ancestors().OfType<NamespaceDeclarationSyntax>())
        parts.Push(ns.Name.ToString());

    return parts.Count == 0 ? "" : string.Join(".", parts);
}

static string GetFullTypeName(BaseTypeDeclarationSyntax typeDecl)
{
    var parts = new Stack<string>();
    parts.Push(typeDecl.Identifier.Text + GetTypeParameterListText(typeDecl));
    foreach (var enclosing in typeDecl.Ancestors().OfType<BaseTypeDeclarationSyntax>())
        parts.Push(enclosing.Identifier.Text + GetTypeParameterListText(enclosing));
    return string.Join(".", parts);
}

static string GetTypeParameterListText(BaseTypeDeclarationSyntax typeDecl)
{
    return typeDecl switch
    {
        TypeDeclarationSyntax td when td.TypeParameterList != null => td.TypeParameterList.ToString(),
        _ => "",
    };
}

static string GetKind(BaseTypeDeclarationSyntax typeDecl)
{
    return typeDecl switch
    {
        ClassDeclarationSyntax => "class",
        InterfaceDeclarationSyntax => "interface",
        StructDeclarationSyntax s when s.Modifiers.Any(m => m.IsKind(SyntaxKind.RecordKeyword)) => "record_struct",
        StructDeclarationSyntax => "struct",
        RecordDeclarationSyntax r when r.ClassOrStructKeyword.IsKind(SyntaxKind.StructKeyword) => "record_struct",
        RecordDeclarationSyntax => "record",
        EnumDeclarationSyntax => "enum",
        _ => typeDecl.GetType().Name.Replace("DeclarationSyntax", "").ToLowerInvariant(),
    };
}

static ExtractedType ExtractType(BaseTypeDeclarationSyntax typeDecl, string ns, string typeName, string file, string repoRoot)
{
    var result = new ExtractedType
    {
        TypeName = typeName,
        Kind = GetKind(typeDecl),
        Namespace = ns,
        SourceFile = Relativize(file, repoRoot),
        Attributes = ExtractAttributes(typeDecl.AttributeLists),
        XmlDoc = ExtractXmlDoc(typeDecl),
        BaseTypes = ExtractBaseTypes(typeDecl),
        GenericConstraints = ExtractConstraints(typeDecl),
        InjectedDependencies = [],
        Members = [],
    };

    if (typeDecl is TypeDeclarationSyntax td)
    {
        foreach (var member in td.Members)
        {
            try
            {
                ExtractMember(member, result);
            }
            catch (Exception ex)
            {
                // bubbled via caller log if needed — store as synthetic error member note
                result.Members.Add(new ExtractedMember
                {
                    Name = member.GetType().Name,
                    Kind = "error",
                    Signature = "",
                    XmlDoc = "",
                    BodySummary = $"extract_error: {ex.Message}",
                    Attributes = [],
                });
            }
        }

        // Record primary constructor parameters as fields/props when present
        if (typeDecl is RecordDeclarationSyntax rd && rd.ParameterList != null)
        {
            foreach (var param in rd.ParameterList.Parameters)
            {
                result.Members.Add(new ExtractedMember
                {
                    Name = param.Identifier.Text,
                    Kind = "primary_constructor_parameter",
                    Signature = param.ToString(),
                    XmlDoc = ExtractXmlDoc(param),
                    BodySummary = "",
                    Attributes = ExtractAttributes(param.AttributeLists),
                });
            }
        }
    }
    else if (typeDecl is EnumDeclarationSyntax ed)
    {
        foreach (var member in ed.Members)
        {
            result.Members.Add(new ExtractedMember
            {
                Name = member.Identifier.Text,
                Kind = "enum_member",
                Signature = member.ToString().Trim(),
                XmlDoc = ExtractXmlDoc(member),
                BodySummary = "",
                Attributes = ExtractAttributes(member.AttributeLists),
            });
        }
    }

    return result;
}

static void ExtractMember(MemberDeclarationSyntax member, ExtractedType owner)
{
    switch (member)
    {
        case MethodDeclarationSyntax method:
            if (!IsPublicOrProtected(method.Modifiers) && !owner.Kind.Equals("interface", StringComparison.Ordinal))
                return;
            // Interface members without modifiers are public
            if (owner.Kind.Equals("interface", StringComparison.Ordinal)
                && method.Modifiers.Any(m => m.IsKind(SyntaxKind.PrivateKeyword) || m.IsKind(SyntaxKind.InternalKeyword)))
                return;

            {
                var xml = ExtractXmlDoc(method);
                var body = string.IsNullOrWhiteSpace(xml) ? GetMethodBody(method) : "";
                owner.Members.Add(new ExtractedMember
                {
                    Name = method.Identifier.Text,
                    Kind = "method",
                    Signature = BuildMethodSignature(method),
                    XmlDoc = xml,
                    BodySummary = body,
                    Attributes = ExtractAttributes(method.AttributeLists),
                });
            }
            break;

        case ConstructorDeclarationSyntax ctor:
            if (!IsPublicOrProtected(ctor.Modifiers))
                return;
            {
                var xml = ExtractXmlDoc(ctor);
                var body = string.IsNullOrWhiteSpace(xml) ? GetConstructorBody(ctor) : "";
                var sig = BuildConstructorSignature(ctor, owner.TypeName);
                owner.Members.Add(new ExtractedMember
                {
                    Name = ".ctor",
                    Kind = "constructor",
                    Signature = sig,
                    XmlDoc = xml,
                    BodySummary = body,
                    Attributes = ExtractAttributes(ctor.AttributeLists),
                });

                // DI: constructor parameters
                foreach (var p in ctor.ParameterList.Parameters)
                {
                    var dep = $"{p.Type?.ToString() ?? "?"} {p.Identifier.Text}";
                    if (!owner.InjectedDependencies.Contains(dep, StringComparer.Ordinal))
                        owner.InjectedDependencies.Add(dep);
                }
            }
            break;

        case PropertyDeclarationSyntax prop:
            if (!IsAccessibleProperty(prop, owner.Kind))
                return;
            {
                var xml = ExtractXmlDoc(prop);
                var body = string.IsNullOrWhiteSpace(xml) ? GetPropertyBody(prop) : "";
                owner.Members.Add(new ExtractedMember
                {
                    Name = prop.Identifier.Text,
                    Kind = "property",
                    Signature = BuildPropertySignature(prop),
                    XmlDoc = xml,
                    BodySummary = body,
                    Attributes = ExtractAttributes(prop.AttributeLists),
                });
            }
            break;

        case FieldDeclarationSyntax field:
            if (!IsPublicOrProtected(field.Modifiers))
                return;
            foreach (var variable in field.Declaration.Variables)
            {
                owner.Members.Add(new ExtractedMember
                {
                    Name = variable.Identifier.Text,
                    Kind = "field",
                    Signature = BuildFieldSignature(field, variable),
                    XmlDoc = ExtractXmlDoc(field),
                    BodySummary = "",
                    Attributes = ExtractAttributes(field.AttributeLists),
                });
            }
            break;

        case EventFieldDeclarationSyntax evt:
            if (!IsPublicOrProtected(evt.Modifiers) && !owner.Kind.Equals("interface", StringComparison.Ordinal))
                return;
            foreach (var variable in evt.Declaration.Variables)
            {
                owner.Members.Add(new ExtractedMember
                {
                    Name = variable.Identifier.Text,
                    Kind = "event",
                    Signature = $"{ModifiersText(evt.Modifiers)}event {evt.Declaration.Type} {variable.Identifier.Text}".Trim(),
                    XmlDoc = ExtractXmlDoc(evt),
                    BodySummary = "",
                    Attributes = ExtractAttributes(evt.AttributeLists),
                });
            }
            break;

        case EventDeclarationSyntax evtDecl:
            if (!IsPublicOrProtected(evtDecl.Modifiers) && !owner.Kind.Equals("interface", StringComparison.Ordinal))
                return;
            owner.Members.Add(new ExtractedMember
            {
                Name = evtDecl.Identifier.Text,
                Kind = "event",
                Signature = $"{ModifiersText(evtDecl.Modifiers)}event {evtDecl.Type} {evtDecl.Identifier.Text}".Trim(),
                XmlDoc = ExtractXmlDoc(evtDecl),
                BodySummary = "",
                Attributes = ExtractAttributes(evtDecl.AttributeLists),
            });
            break;

        case IndexerDeclarationSyntax indexer:
            if (!IsPublicOrProtected(indexer.Modifiers) && !owner.Kind.Equals("interface", StringComparison.Ordinal))
                return;
            {
                var xml = ExtractXmlDoc(indexer);
                var body = string.IsNullOrWhiteSpace(xml) ? indexer.ToString() : "";
                owner.Members.Add(new ExtractedMember
                {
                    Name = "this",
                    Kind = "indexer",
                    Signature = BuildIndexerSignature(indexer),
                    XmlDoc = xml,
                    BodySummary = body,
                    Attributes = ExtractAttributes(indexer.AttributeLists),
                });
            }
            break;

        case OperatorDeclarationSyntax op:
            if (!IsPublicOrProtected(op.Modifiers))
                return;
            {
                var xml = ExtractXmlDoc(op);
                var body = string.IsNullOrWhiteSpace(xml) ? GetOperatorBody(op) : "";
                owner.Members.Add(new ExtractedMember
                {
                    Name = op.OperatorToken.Text,
                    Kind = "operator",
                    Signature = BuildOperatorSignature(op),
                    XmlDoc = xml,
                    BodySummary = body,
                    Attributes = ExtractAttributes(op.AttributeLists),
                });
            }
            break;

        case ConversionOperatorDeclarationSyntax conv:
            if (!IsPublicOrProtected(conv.Modifiers))
                return;
            {
                var xml = ExtractXmlDoc(conv);
                var body = string.IsNullOrWhiteSpace(xml)
                    ? (conv.Body?.ToString() ?? conv.ExpressionBody?.ToString() ?? "")
                    : "";
                owner.Members.Add(new ExtractedMember
                {
                    Name = conv.Type.ToString(),
                    Kind = "conversion_operator",
                    Signature = $"{ModifiersText(conv.Modifiers)}{conv.ImplicitOrExplicitKeyword} operator {conv.Type}{conv.ParameterList}".Trim(),
                    XmlDoc = xml,
                    BodySummary = body,
                    Attributes = ExtractAttributes(conv.AttributeLists),
                });
            }
            break;

        case DestructorDeclarationSyntax:
        case BaseTypeDeclarationSyntax:
            // Nested types handled by DescendantNodes walk
            break;
    }
}

static bool IsAccessibleProperty(PropertyDeclarationSyntax prop, string ownerKind)
{
    if (ownerKind.Equals("interface", StringComparison.Ordinal))
    {
        return !prop.Modifiers.Any(m => m.IsKind(SyntaxKind.PrivateKeyword) || m.IsKind(SyntaxKind.InternalKeyword));
    }

    if (IsPublicOrProtected(prop.Modifiers))
        return true;

    // Explicit interface implementation — skip (not public API surface of the type itself)
    if (prop.ExplicitInterfaceSpecifier != null)
        return false;

    return false;
}

static string BuildMethodSignature(MethodDeclarationSyntax method)
{
    var sb = new StringBuilder();
    var mods = ModifiersText(method.Modifiers);
    if (!string.IsNullOrEmpty(mods))
        sb.Append(mods);
    sb.Append(method.ReturnType).Append(' ');
    if (method.ExplicitInterfaceSpecifier != null)
        sb.Append(method.ExplicitInterfaceSpecifier);
    sb.Append(method.Identifier.Text);
    if (method.TypeParameterList != null)
        sb.Append(method.TypeParameterList);
    sb.Append(method.ParameterList);
    if (method.ConstraintClauses.Count > 0)
    {
        sb.Append(' ');
        sb.Append(string.Join(" ", method.ConstraintClauses.Select(c => c.ToString())));
    }
    return sb.ToString().Trim();
}

static string BuildConstructorSignature(ConstructorDeclarationSyntax ctor, string typeName)
{
    var simpleName = typeName.Contains('.') ? typeName[(typeName.LastIndexOf('.') + 1)..] : typeName;
    // Strip generic arity display from nested names for ctor: Entity<TId> -> Entity
    simpleName = Regex.Replace(simpleName, @"<[^>]+>", "");
    return $"{ModifiersText(ctor.Modifiers)}{simpleName}{ctor.ParameterList}".Trim();
}

static string BuildPropertySignature(PropertyDeclarationSyntax prop)
{
    var accessors = prop.AccessorList != null
        ? " { " + string.Join(" ", prop.AccessorList.Accessors.Select(a =>
        {
            var am = ModifiersText(a.Modifiers);
            return $"{am}{a.Keyword};".Trim();
        })) + " }"
        : (prop.ExpressionBody != null ? " => ..." : "");

    return $"{ModifiersText(prop.Modifiers)}{prop.Type} {prop.Identifier.Text}{accessors}".Trim();
}

static string BuildFieldSignature(FieldDeclarationSyntax field, VariableDeclaratorSyntax variable)
{
    var init = variable.Initializer != null ? $" {variable.Initializer}" : "";
    return $"{ModifiersText(field.Modifiers)}{field.Declaration.Type} {variable.Identifier.Text}{init};".Trim();
}

static string BuildIndexerSignature(IndexerDeclarationSyntax indexer)
{
    var accessors = indexer.AccessorList != null
        ? " { " + string.Join(" ", indexer.AccessorList.Accessors.Select(a =>
            $"{ModifiersText(a.Modifiers)}{a.Keyword};".Trim())) + " }"
        : "";
    return $"{ModifiersText(indexer.Modifiers)}{indexer.Type} this{indexer.ParameterList}{accessors}".Trim();
}

static string BuildOperatorSignature(OperatorDeclarationSyntax op)
{
    return $"{ModifiersText(op.Modifiers)}{op.ReturnType} operator {op.OperatorToken}{op.ParameterList}".Trim();
}

static string ModifiersText(SyntaxTokenList modifiers)
{
    if (modifiers.Count == 0) return "";
    return string.Join(" ", modifiers.Select(m => m.Text)) + " ";
}

static string GetMethodBody(MethodDeclarationSyntax method)
{
    if (method.Body != null) return method.Body.ToFullString().Trim();
    if (method.ExpressionBody != null) return method.ExpressionBody.ToFullString().Trim() + ";";
    return ""; // abstract / interface / partial without body
}

static string GetConstructorBody(ConstructorDeclarationSyntax ctor)
{
    if (ctor.Body != null) return ctor.Body.ToFullString().Trim();
    if (ctor.ExpressionBody != null) return ctor.ExpressionBody.ToFullString().Trim() + ";";
    return "";
}

static string GetPropertyBody(PropertyDeclarationSyntax prop)
{
    if (prop.ExpressionBody != null)
        return prop.ExpressionBody.ToFullString().Trim() + ";";
    if (prop.AccessorList != null)
    {
        // Keep full accessor implementations when present (not just ; )
        var hasBody = prop.AccessorList.Accessors.Any(a => a.Body != null || a.ExpressionBody != null);
        if (hasBody)
            return prop.AccessorList.ToFullString().Trim();
    }
    return "";
}

static string GetOperatorBody(OperatorDeclarationSyntax op)
{
    if (op.Body != null) return op.Body.ToFullString().Trim();
    if (op.ExpressionBody != null) return op.ExpressionBody.ToFullString().Trim() + ";";
    return "";
}

static List<string> ExtractBaseTypes(BaseTypeDeclarationSyntax typeDecl)
{
    if (typeDecl.BaseList == null)
        return [];

    return typeDecl.BaseList.Types
        .Select(t => t.Type.ToString())
        .ToList();
}

static string ExtractConstraints(BaseTypeDeclarationSyntax typeDecl)
{
    if (typeDecl is not TypeDeclarationSyntax td || td.ConstraintClauses.Count == 0)
        return "";
    return string.Join(" ", td.ConstraintClauses.Select(c => c.ToString()));
}

static List<string> ExtractAttributes(SyntaxList<AttributeListSyntax> attributeLists)
{
    var list = new List<string>();
    foreach (var attrList in attributeLists)
    {
        foreach (var attr in attrList.Attributes)
            list.Add(attr.ToString());
    }
    return list;
}

static string ExtractXmlDoc(SyntaxNode node)
{
    var trivia = node.GetLeadingTrivia();
    var sb = new StringBuilder();
    foreach (var t in trivia)
    {
        if (t.IsKind(SyntaxKind.SingleLineDocumentationCommentTrivia)
            || t.IsKind(SyntaxKind.MultiLineDocumentationCommentTrivia))
        {
            sb.Append(t.ToFullString());
        }
        else if (t.IsKind(SyntaxKind.DocumentationCommentExteriorTrivia))
        {
            sb.Append(t.ToFullString());
        }
    }

    // Also walk structured trivia
    foreach (var t in trivia)
    {
        if (t.HasStructure && t.GetStructure() is DocumentationCommentTriviaSyntax doc)
        {
            var text = doc.ToFullString();
            if (!sb.ToString().Contains(text, StringComparison.Ordinal))
                sb.Append(text);
        }
    }

    return NormalizeXmlDoc(sb.ToString());
}

static string NormalizeXmlDoc(string raw)
{
    if (string.IsNullOrWhiteSpace(raw))
        return "";

    // Preserve exact /// content; trim only trailing whitespace/newlines at ends
    var lines = raw.Replace("\r\n", "\n").Replace('\r', '\n').Split('\n');
    var kept = lines
        .Select(l => l.TrimEnd())
        .Where(l => l.TrimStart().StartsWith("///", StringComparison.Ordinal) || l.Contains("///", StringComparison.Ordinal))
        .ToList();

    if (kept.Count == 0)
    {
        // Fallback: keep full structured doc trivia text
        return raw.Trim();
    }

    return string.Join("\n", kept).Trim();
}

static ExtractedType MergePartial(ExtractedType a, ExtractedType b)
{
    // Prefer non-empty xml_doc / constraints / attributes
    var merged = new ExtractedType
    {
        TypeName = a.TypeName,
        Kind = a.Kind,
        Namespace = a.Namespace,
        SourceFile = string.IsNullOrEmpty(a.SourceFile) ? b.SourceFile : a.SourceFile + ";" + b.SourceFile,
        Attributes = a.Attributes.Union(b.Attributes, StringComparer.Ordinal).ToList(),
        XmlDoc = string.IsNullOrWhiteSpace(a.XmlDoc) ? b.XmlDoc : a.XmlDoc,
        BaseTypes = a.BaseTypes.Union(b.BaseTypes, StringComparer.Ordinal).ToList(),
        GenericConstraints = string.IsNullOrWhiteSpace(a.GenericConstraints) ? b.GenericConstraints : a.GenericConstraints,
        InjectedDependencies = a.InjectedDependencies.Union(b.InjectedDependencies, StringComparer.Ordinal).ToList(),
        Members = a.Members.Concat(b.Members)
            .GroupBy(m => m.Kind + "|" + m.Name + "|" + m.Signature, StringComparer.Ordinal)
            .Select(g => g.First())
            .ToList(),
    };
    return merged;
}

static string Relativize(string fullPath, string repoRoot)
{
    try
    {
        return Path.GetRelativePath(repoRoot, fullPath).Replace('\\', '/');
    }
    catch
    {
        return fullPath.Replace('\\', '/');
    }
}

static string SanitizeFileName(string ns)
{
    if (string.IsNullOrWhiteSpace(ns))
        return "_global";
    // Keep dots; replace only illegal filename chars
    foreach (var c in Path.GetInvalidFileNameChars())
        ns = ns.Replace(c, '_');
    return ns;
}

// ───────────────────────── DTOs ─────────────────────────

sealed class NamespaceDocument
{
    public string Namespace { get; set; } = "";
    public int TypeCount { get; set; }
    public List<ExtractedType> Types { get; set; } = [];
}

sealed class ExtractedType
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
    public List<ExtractedMember> Members { get; set; } = [];
}

sealed class ExtractedMember
{
    public string Name { get; set; } = "";
    public string Kind { get; set; } = "";
    public string Signature { get; set; } = "";
    public string XmlDoc { get; set; } = "";
    public string BodySummary { get; set; } = "";
    public List<string> Attributes { get; set; } = [];
}

sealed class IndexDocument
{
    public string GeneratedAt { get; set; } = "";
    public string RepoRoot { get; set; } = "";
    public int SourceFileCount { get; set; }
    public int NamespaceCount { get; set; }
    public int TotalTypes { get; set; }
    public List<IndexEntry> Namespaces { get; set; } = [];
}

sealed class IndexEntry
{
    public string Namespace { get; set; } = "";
    public string File { get; set; } = "";
    public int TypeCount { get; set; }
}
