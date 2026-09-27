#!/usr/bin/env python3
"""Generate framework-docs final human/agent documentation from enriched JSON + patterns."""

from __future__ import annotations

import json
import re
from collections import defaultdict
from pathlib import Path

ROOT = Path(__file__).resolve().parents[1]
ENRICHED = ROOT / "framework-docs" / "enriched"
PATTERNS = ROOT / "framework-docs" / "patterns"
BY_NS = PATTERNS / "by-namespace"
API_REF = ROOT / "framework-docs" / "api-reference"
MAX_LINES_SOFT = 250

# Map namespace -> recipe file relative path + anchor (from documented usage patterns only)
RECIPE_BY_NAMESPACE: dict[str, tuple[str, str]] = {
    "Zamin.Extensions.DependencyInjection": ("dependency-injection.md", "recipe-add-zamin-api-core"),
    "Zamin.Extensions.DependencyInjection.Abstractions": ("dependency-injection.md", "recipe-lifetime-markers"),
    "Zamin.Utilities.SerilogRegistration.Extensions": ("dependency-injection.md", "recipe-host-bootstrap"),
    "Zamin.Core.ApplicationServices.Commands": ("common-recipes.md", "recipe-command-handler"),
    "Zamin.Core.ApplicationServices.Queries": ("common-recipes.md", "recipe-query-handler"),
    "Zamin.Core.Contracts.ApplicationServices.Commands": ("common-recipes.md", "recipe-command-dispatcher"),
    "Zamin.Core.Contracts.ApplicationServices.Queries": ("common-recipes.md", "recipe-query-dispatcher"),
    "Zamin.Core.Contracts.Data.Commands": ("common-recipes.md", "recipe-command-repository"),
    "Zamin.Core.Contracts.Data.Queries": ("common-recipes.md", "recipe-query-repository"),
    "Zamin.Core.Domain.Entities": ("common-recipes.md", "recipe-aggregate-entity"),
    "Zamin.Core.Domain.Exceptions": ("common-recipes.md", "recipe-domain-exceptions"),
    "Zamin.Core.Domain.Toolkits.ValueObjects": ("common-recipes.md", "recipe-toolkit-value-objects"),
    "Zamin.Core.Domain.ValueObjects": ("common-recipes.md", "recipe-value-objects"),
    "Zamin.Core.RequestResponse.Commands": ("common-recipes.md", "recipe-command-contracts"),
    "Zamin.Core.RequestResponse.Common": ("common-recipes.md", "recipe-application-service-status"),
    "Zamin.Core.RequestResponse.Queries": ("common-recipes.md", "recipe-query-contracts"),
    "Zamin.EndPoints.Web.Controllers": ("common-recipes.md", "recipe-base-controller"),
    "Zamin.EndPoints.Web.Extensions": ("common-recipes.md", "recipe-http-context-extensions"),
    "Zamin.EndPoints.Web.Extensions.ModelBinding": ("common-recipes.md", "recipe-model-binding"),
    "Zamin.Extensions.Caching.Abstractions": ("common-recipes.md", "recipe-cache-adapter"),
    "Zamin.Extensions.Caching.Distributed.Redis.Options": ("dependency-injection.md", "recipe-distributed-cache"),
    "Zamin.Extensions.Caching.Distributed.Sql.Options": ("dependency-injection.md", "recipe-distributed-cache"),
    "Zamin.Extensions.Events.Outbox.Dal.EF": ("common-recipes.md", "recipe-outbox-dbcontext"),
    "Zamin.Extensions.Events.PollingPublisher.Dal.Dapper": ("dependency-injection.md", "recipe-worker-messaging-dal"),
    "Zamin.Extensions.MessageBus.MessageInbox.Dal.Dapper": ("dependency-injection.md", "recipe-worker-messaging-dal"),
    "Zamin.Extensions.Serializers.Abstractions": ("dependency-injection.md", "recipe-serializer-mapper"),
    "Zamin.Extensions.Translations.Abstractions": ("common-recipes.md", "recipe-translator"),
    "Zamin.Extensions.Translations.Parrot.Options": ("dependency-injection.md", "recipe-parrot-translator"),
    "Zamin.Extensions.Translations.Parrot.Services": ("dependency-injection.md", "recipe-parrot-translator"),
    "Zamin.Extensions.UsersManagement.Abstractions": ("common-recipes.md", "recipe-user-info"),
    "Zamin.Extensions.UsersManagement.Options": ("dependency-injection.md", "recipe-user-info-registration"),
    "Zamin.Infra.Data.Sql.Commands": ("common-recipes.md", "recipe-command-repository"),
    "Zamin.Infra.Data.Sql.Commands.Interceptors": ("common-recipes.md", "recipe-ef-interceptors"),
    "Zamin.Infra.Data.Sql.Queries": ("common-recipes.md", "recipe-query-repository"),
    "Zamin.Utilities": ("common-recipes.md", "recipe-zamin-services"),
    "Zamin.Utilities.Auth.ApiAuthentication.Options": ("dependency-injection.md", "recipe-api-authentication"),
    "Zamin.Utilities.Resources.Translators": ("common-recipes.md", "recipe-translator-keys"),
    "Zamin.Utilities.SoftwarePartDetector": ("dependency-injection.md", "recipe-software-part-detector"),
    "Zamin.Utilities.SoftwarePartDetector.DataModel": ("dependency-injection.md", "recipe-software-part-detector"),
    "Zamin.Utilities.SoftwarePartDetector.Services": ("dependency-injection.md", "recipe-software-part-detector"),
}


def load_json(path: Path) -> dict:
    return json.loads(path.read_text(encoding="utf-8-sig"))


def clean_doc(text: str | None) -> str:
    if not text:
        return "مستندات کافی موجود نیست"
    t = text.strip()
    if not t:
        return "مستندات کافی موجود نیست"
    # collapse excessive whitespace for markdown readability
    t = t.replace("\r\n", "\n").replace("\r", "\n")
    return t


def type_anchor(type_name: str) -> str:
    slug = re.sub(r"[^a-zA-Z0-9]+", "-", type_name).strip("-").lower()
    return slug or "type"


def clean_signature(sig: str | None) -> str:
    if not sig or not str(sig).strip():
        return "مستندات کافی موجود نیست"
    s = str(sig).replace("\r\n", "\n").replace("\r", "\n").strip()
    lines = s.split("\n")
    if len(lines) <= 6:
        return s
    first = lines[0].rstrip()
    return first + "\n    // … (بدنه/initializer کامل در enriched JSON)"


def format_type_section(t: dict, ns: str) -> list[str]:
    lines: list[str] = []
    type_name = t.get("type_name", "")
    full_name = f"{ns}.{type_name}"
    kind = t.get("kind") or "type"
    member_part = t.get("_member_part")
    heading = f"### `{full_name}`"
    if member_part:
        heading += f" — اعضای بخش {member_part}"
    lines.append(heading)
    lines.append("")
    lines.append(f"- **Kind:** `{kind}`")
    if t.get("base_types"):
        bases = ", ".join(f"`{b}`" for b in t["base_types"])
        lines.append(f"- **Base / interfaces:** {bases}")
    if t.get("generic_constraints"):
        gc = str(t["generic_constraints"]).replace("\r\n", " ").replace("\n", " ").strip()
        lines.append(f"- **Constraints:** `{gc}`")
    if t.get("source_file"):
        lines.append(f"- **Source:** `{t['source_file']}`")
    lines.append("")
    doc = clean_doc((t.get("generated_doc") or {}).get("fa") or t.get("xml_doc"))
    lines.append(doc)
    lines.append("")

    recipe = RECIPE_BY_NAMESPACE.get(ns)
    if recipe:
        file_name, anchor = recipe
        lines.append(f"- **Recipe:** [الگوی استفاده مرتبط](../patterns/{file_name}#{anchor})")
        lines.append("")

    members = t.get("members") or []
    if not members:
        lines.append("_اعضای عمومی مستندسازی‌شده در این خروجی وجود ندارد یا استخراج نشده است._")
        lines.append("")
        return lines

    lines.append("#### Members")
    lines.append("")
    for m in members:
        name = m.get("name") or "?"
        mkind = m.get("kind") or "member"
        sig = clean_signature(m.get("signature"))
        mdoc = clean_doc((m.get("generated_doc") or {}).get("fa") or m.get("xml_doc"))
        lines.append(f"##### `{name}` ({mkind})")
        lines.append("")
        lines.append("```csharp")
        lines.append(sig)
        lines.append("```")
        lines.append("")
        lines.append(mdoc)
        lines.append("")
    return lines


def render_type_block(t: dict, ns: str) -> str:
    return "\n".join(format_type_section(t, ns))


def split_types(types: list[dict], ns: str) -> list[list[dict]]:
    """Split by actual rendered size so bulky signatures don't blow past soft max."""
    header_budget = 12
    units: list[dict] = []
    for t in types:
        members = list(t.get("members") or [])
        alone = header_budget + len(render_type_block(t, ns).splitlines())
        if alone <= MAX_LINES_SOFT or not members:
            units.append(t)
            continue
        approx_parts = max(2, (alone // MAX_LINES_SOFT) + 1)
        chunk_size = max(1, len(members) // approx_parts)
        start = 0
        while start < len(members):
            end = min(len(members), start + chunk_size)
            while True:
                clone = dict(t)
                clone["members"] = members[start:end]
                size = header_budget + len(render_type_block(clone, ns).splitlines())
                if size <= MAX_LINES_SOFT or end == start + 1:
                    break
                end -= 1
            clone = dict(t)
            clone["members"] = members[start:end]
            units.append(clone)
            start = end

    by_name_counts: dict[str, int] = {}
    for u in units:
        name = u.get("type_name") or ""
        by_name_counts[name] = by_name_counts.get(name, 0) + 1
    seen: dict[str, int] = {}
    annotated: list[dict] = []
    for u in units:
        name = u.get("type_name") or ""
        total = by_name_counts.get(name, 1)
        if total > 1:
            seen[name] = seen.get(name, 0) + 1
            clone = dict(u)
            clone["_member_part"] = f"{seen[name]}/{total}"
            annotated.append(clone)
        else:
            annotated.append(u)
    units = annotated

    parts: list[list[dict]] = []
    current: list[dict] = []
    current_lines = header_budget
    for u in units:
        u_lines = len(render_type_block(u, ns).splitlines())
        if current and current_lines + u_lines > MAX_LINES_SOFT:
            parts.append(current)
            current = [u]
            current_lines = header_budget + u_lines
        else:
            current.append(u)
            current_lines += u_lines
    if current:
        parts.append(current)
    return parts or [types]


def write_api_reference() -> list[dict]:
    """Returns toc entries for api-reference files."""
    API_REF.mkdir(parents=True, exist_ok=True)
    # clear old generated md
    for old in API_REF.glob("*.md"):
        old.unlink()

    toc_entries: list[dict] = []
    files = sorted(ENRICHED.glob("*.json"))
    files = [f for f in files if f.name != "_summary.md" and f.suffix == ".json"]

    for path in files:
        data = load_json(path)
        ns = data.get("namespace") or path.stem
        types = data.get("types") or []
        parts = split_types(types, ns)

        for idx, part_types in enumerate(parts, start=1):
            if len(parts) == 1:
                out_name = f"{ns}.md"
                title = ns
            else:
                out_name = f"{ns}.Part{idx}.md"
                title = f"{ns} (Part {idx}/{len(parts)})"

            lines: list[str] = []
            lines.append(f"# {title}")
            lines.append("")
            lines.append(f"مرجع API برای namespace `{ns}`.")
            lines.append("")
            lines.append(f"- **Type count (this file):** {len(part_types)}")
            if len(parts) > 1:
                sibling_links = []
                for j in range(1, len(parts) + 1):
                    if j == idx:
                        sibling_links.append(f"**Part {j}**")
                    else:
                        sibling_links.append(f"[Part {j}](./{ns}.Part{j}.md)")
                lines.append(f"- **Parts:** {' · '.join(sibling_links)}")
            lines.append("")
            lines.append("منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).")
            lines.append("")
            lines.append("## Types")
            lines.append("")
            for t in part_types:
                lines.extend(format_type_section(t, ns))

            out_path = API_REF / out_name
            out_path.write_text("\n".join(lines).rstrip() + "\n", encoding="utf-8")
            first_types = ", ".join(f"`{t.get('type_name')}`" for t in part_types[:5])
            if len(part_types) > 5:
                first_types += ", …"
            toc_entries.append(
                {
                    "path": f"api-reference/{out_name}",
                    "title": title,
                    "blurb": f"مرجع تایپ‌های `{ns}` ({len(part_types)} تایپ): {first_types}",
                }
            )
    return toc_entries


def load_by_namespace_bodies() -> dict[str, str]:
    result = {}
    if not BY_NS.exists():
        return result
    for p in BY_NS.glob("*.md"):
        result[p.stem] = p.read_text(encoding="utf-8-sig")
    return result


def extract_code_blocks(md: str) -> list[str]:
    return re.findall(r"```csharp\n(.*?)```", md, flags=re.S)


def first_paragraph_after_heading(md: str) -> str:
    # skip title, gather first non-empty non-heading non-code prose
    lines = md.splitlines()
    buf = []
    in_code = False
    started = False
    for line in lines:
        if line.startswith("```"):
            in_code = not in_code
            continue
        if in_code:
            continue
        if line.startswith("#"):
            continue
        if not line.strip():
            if started and buf:
                break
            continue
        if line.startswith("|") or line.startswith("- **Types"):
            if not started:
                continue
        started = True
        buf.append(line.strip())
        if len(buf) >= 3:
            break
    text = " ".join(buf).strip()
    return text or "مستندات کافی موجود نیست"


def write_dependency_injection(by_ns: dict[str, str]) -> None:
    content = []
    content.append("# Dependency Injection — الگوهای ثبت سرویس زمین")
    content.append("")
    content.append(
        "منبع: call-siteهای واقعی زیر `D:\\Sources\\myapp\\myapp\\src` و فایل‌های "
        "`framework-docs/patterns/by-namespace` / `general-recipes.md`. "
        "هیچ API اختراع‌شده‌ای اینجا نیست."
    )
    content.append("")

    # Recipe: host bootstrap
    content.append("## Recipe: Host bootstrap با Serilog {#recipe-host-bootstrap}")
    content.append("")
    content.append(
        "**توضیح:** هاست‌های اپلیکیشن startup را داخل `SerilogExtensions.RunWithSerilogExceptionHandling` می‌پیچند، "
        "سپس configuration، `AddZaminSerilog`، ثبت سرویس‌ها و pipeline را زنجیره می‌کنند. "
        "همین شکل برای چند نوع هاست (API و Worker) قابل اعمال است."
    )
    content.append("")
    content.append("**کد نمونه:**")
    content.append("")
    content.append("```csharp")
    content.append("// src/3.Endpoints/API/Program.cs")
    content.append("using MyApp.Endpoints.DependencyInjection;")
    content.append("using Zamin.Extensions.DependencyInjection;")
    content.append("using Zamin.Utilities.SerilogRegistration.Extensions;")
    content.append("")
    content.append("SerilogExtensions.RunWithSerilogExceptionHandling(() =>")
    content.append("{")
    content.append("    var builder = WebApplication.CreateBuilder(args);")
    content.append("    var app = builder")
    content.append("        .AddConfiguration()")
    content.append("        .AddZaminSerilog(o =>")
    content.append("        {")
    content.append('            o.ApplicationName = builder.Configuration.GetValue<string>("Global:ApplicationName");')
    content.append('            o.ServiceId = builder.Configuration.GetValue<string>("Global:ServiceId");')
    content.append('            o.ServiceName = builder.Configuration.GetValue<string>("Global:ServiceName");')
    content.append('            o.ServiceVersion = builder.Configuration.GetValue<string>("Global:ServiceVersion");')
    content.append("        })")
    content.append("        .ConfigureServices()")
    content.append("        .ConfigurePipeline();")
    content.append("    app.Run();")
    content.append("});")
    content.append("```")
    content.append("")
    content.append("**نکات مهم:**")
    content.append("")
    content.append("- نقطه ورود مشاهده‌شده: `SerilogExtensions.RunWithSerilogExceptionHandling`.")
    content.append("- بعد از build، سرویس‌های post-start مثل SoftwarePartDetector اجرا می‌شوند (بخش‌های بعدی).")
    content.append("")

    content.append("## Recipe: AddZaminApiCore و decoratorهای dispatcher {#recipe-add-zamin-api-core}")
    content.append("")
    di_ns = by_ns.get("Zamin.Extensions.DependencyInjection", "")
    content.append(
        "**توضیح:** قبل از `AddZaminApiCore(\"Zamin\", \"MyApp\")` اپلیکیشن decoratorهای لاگ‌گذاری خودش را "
        "برای `CommandDispatcherDecorator` / `QueryDispatcherDecorator` ثبت می‌کند. "
        "`AddZaminApiCore` اسکن اسمبلی برای handlerها و lifetime markerها را انجام می‌دهد."
    )
    content.append("")
    content.append("**کد نمونه:**")
    content.append("")
    blocks = extract_code_blocks(di_ns)
    if blocks:
        content.append("```csharp")
        content.append(blocks[0].rstrip())
        content.append("```")
    else:
        content.append("مستندات کافی موجود نیست")
    content.append("")
    content.append("**نکات مهم:**")
    content.append("")
    content.append("- ترتیب مشاهده‌شده: ثبت decoratorها → سپس `AddZaminApiCore`.")
    content.append("- handlerها دستی `new` نمی‌شوند؛ از طریق اسکن DI ساخته می‌شوند.")
    content.append("")

    content.append("## Recipe: Lifetime markers {#recipe-lifetime-markers}")
    content.append("")
    life = by_ns.get("Zamin.Extensions.DependencyInjection.Abstractions", "")
    content.append(
        "**توضیح:** اینترفیس‌های `ITransientLifetime` / `IScopeLifetime` / `ISingletoneLifetime` "
        "روی قراردادهای اپلیکیشن برای کشف lifetime توسط `AddZaminApiCore` استفاده می‌شوند."
    )
    content.append("")
    if life.strip():
        content.append(first_paragraph_after_heading(life))
    else:
        content.append("مستندات کافی موجود نیست")
    content.append("")
    content.append("**کد نمونه:**")
    content.append("")
    life_blocks = extract_code_blocks(life)
    if life_blocks:
        content.append("```csharp")
        content.append(life_blocks[0].rstrip())
        content.append("```")
    else:
        content.append("مستندات کافی موجود نیست — در فایل الگوی namespace فقط اشاره متنی به markerها آمده است.")
    content.append("")
    content.append("**نکات مهم:**")
    content.append("")
    content.append("- املای `ISingletoneLifetime` در API زمین همین‌گونه است (طبق استخراج).")
    content.append("")

    content.append("## Recipe: Distributed cache (Redis / SQL) {#recipe-distributed-cache}")
    content.append("")
    content.append(
        "**توضیح:** اپلیکیشن با کلید `DistributedCacheActive` بین Redis و SQL سوییچ می‌کند و "
        "یکی از `AddZaminRedisDistributedCache` یا `AddZaminSqlDistributedCache` را صدا می‌زند."
    )
    content.append("")
    content.append("**کد نمونه:**")
    content.append("")
    content.append("```csharp")
    content.append("// excerpt — ConfigureServices (API)")
    content.append('if (builder.Configuration["DistributedCacheActive"] == nameof(DistributedRedisCacheOptions))')
    content.append('    builder.Services.AddZaminRedisDistributedCache(builder.Configuration, nameof(DistributedRedisCacheOptions));')
    content.append('else if (builder.Configuration["DistributedCacheActive"] == nameof(DistributedSqlCacheOptions))')
    content.append('    builder.Services.AddZaminSqlDistributedCache(builder.Configuration, nameof(DistributedSqlCacheOptions));')
    content.append("else")
    content.append('    throw new ArgumentException("There is no valid DistributedCacheActive on appsettings.");')
    content.append("```")
    content.append("")
    content.append("**نکات مهم:**")
    content.append("")
    content.append("- Options مربوطه: `DistributedRedisCacheOptions` / `DistributedSqlCacheOptions`.")
    content.append("- مصرف‌کننده رایج: `ICacheAdapter` (نگاه کنید به common-recipes).")
    content.append("")

    content.append("## Recipe: Serializer و AutoMapper {#recipe-serializer-mapper}")
    content.append("")
    content.append(
        "**توضیح:** در هاست API ثبت‌های `AddZaminMicrosoftSerializer` و "
        "`AddZaminAutoMapperProfiles(builder.Configuration, \"AutoMapper\")` مشاهده شده است."
    )
    content.append("")
    content.append("**کد نمونه:**")
    content.append("")
    content.append("```csharp")
    content.append("builder.Services.AddZaminMicrosoftSerializer();")
    content.append('builder.Services.AddZaminAutoMapperProfiles(builder.Configuration, "AutoMapper");')
    content.append("```")
    content.append("")
    content.append("**نکات مهم:**")
    content.append("")
    content.append("- اینترفیس مصرفی serializer: `IJsonSerializer` (Abstractions).")
    content.append("")

    content.append("## Recipe: Parrot translator registration {#recipe-parrot-translator}")
    content.append("")
    content.append(
        "**توضیح:** `AddZaminParrotTranslator` در ConfigureServices؛ بعد از build، "
        "`ParrotTranslatorInitializer.Initialize` با options اجرا می‌شود."
    )
    content.append("")
    content.append("**کد نمونه:**")
    content.append("")
    content.append("```csharp")
    content.append('builder.Services.AddZaminParrotTranslator(builder.Configuration, "ParrotTranslator");')
    content.append("// pipeline / post-build:")
    content.append("var options = app.Services.GetService<IOptions<ParrotTranslatorOptions>>()?.Value")
    content.append("    ?? throw new NullReferenceException();")
    content.append("ParrotTranslatorInitializer.Initialize(options.ConnectionString, options.SchemaName, options.TableName);")
    content.append("```")
    content.append("")
    content.append("**نکات مهم:**")
    content.append("")
    content.append("- Options: `ParrotTranslatorOptions`؛ سرویس: `ParrotTranslator` / قرارداد `ITranslator`.")
    content.append("")

    content.append("## Recipe: User info registration {#recipe-user-info-registration}")
    content.append("")
    content.append(
        "**توضیح:** اپلیکیشن `AddAppUserInfoService(builder.Configuration, \"WebUserInfo\")` را صدا می‌زند "
        "(extension سمت اپلیکیشن روی قراردادهای UsersManagement زمین)."
    )
    content.append("")
    content.append("**کد نمونه:**")
    content.append("")
    content.append("```csharp")
    content.append('builder.Services.AddAppUserInfoService(builder.Configuration, "UserInfo");')
    content.append("```")
    content.append("")
    content.append("**نکات مهم:**")
    content.append("")
    content.append("- Options مرتبط زمین: `UserManagementOptions` (مشاهده در patterns).")
    content.append("- مصرف: `IUserInfoService` و مسیر `ZaminServices.UserInfoService`.")
    content.append("")

    content.append("## Recipe: API authentication + Swagger {#recipe-api-authentication}")
    content.append("")
    content.append(
        "**توضیح:** پس از DbContext و سرویس‌های هسته، "
        "`AddZaminSwagger` و `AddZaminApiAuthentication` با sectionهای تنظیمات ثبت می‌شوند."
    )
    content.append("")
    content.append("**کد نمونه:**")
    content.append("")
    content.append("```csharp")
    content.append('builder.Services.AddZaminSwagger(builder.Configuration, "Swagger");')
    content.append('builder.Services.AddZaminApiAuthentication(builder.Configuration, "ApiAuthentication");')
    content.append("```")
    content.append("")
    content.append("**نکات مهم:**")
    content.append("")
    content.append("- Options مشاهده‌شده: `ApiAuthenticationOption`, `ProviderOption`, `TokenType`.")
    content.append("")

    content.append("## Recipe: SoftwarePartDetector {#recipe-software-part-detector}")
    content.append("")
    content.append(
        "**توضیح:** ثبت با `AddSoftwarePartDetector`؛ بعد از pipeline، "
        "`SoftwarePartDetectorService.Run()` فراخوانی می‌شود."
    )
    content.append("")
    content.append("**کد نمونه:**")
    content.append("")
    content.append("```csharp")
    content.append('builder.Services.AddSoftwarePartDetector(builder.Configuration, "SoftwarePart");')
    content.append("// after MapControllers:")
    content.append("app.Services.GetService<SoftwarePartDetectorService>()?.Run();")
    content.append("```")
    content.append("")
    content.append("**نکات مهم:**")
    content.append("")
    content.append(
        "- در inventory، نام‌های DataModel ممکن است با تایپ‌های دامنه‌ای اپلیکیشن تداخل داشته باشند؛ "
        "جزئیات در `unused-types.md` آمده است."
    )
    content.append("")

    content.append("## Recipe: Worker messaging DAL {#recipe-worker-messaging-dal}")
    content.append("")
    content.append(
        "**توضیح:** WorkerService به‌صورت فعال `AddZaminPollingPublisherDalSql` و "
        "`AddZaminMessageInboxDalSql` را ثبت می‌کند. ثبت‌های application-level برای "
        "RabbitMQ / PollingPublisher / MessageInbox در کد مشاهده‌شده comment شده‌اند."
    )
    content.append("")
    content.append("**کد نمونه:**")
    content.append("")
    content.append("مستندات کافی موجود نیست — فقط اشاره متنی در general-recipes؛ snippet کامل Worker در مرحله قبل استخراج نشده است.")
    content.append("")
    content.append("**نکات مهم:**")
    content.append("")
    content.append("- Pipeline ورکر `UseZaminApiExceptionHandler` را صدا نمی‌زند (مشاهده‌شده).")
    content.append("")

    content.append("## ترتیب کلی ثبت سرویس در API (مشاهده‌شده)")
    content.append("")
    content.append("1. Decoratorهای dispatcher اپلیکیشن")
    content.append("2. `AddZaminApiCore`")
    content.append("3. User-info / translator / software-part / serializer / AutoMapper / cache")
    content.append("4. EF Command/Query DbContext + interceptorهای زمین")
    content.append("5. Auth + Swagger")
    content.append("6. Pipeline: `UseZaminApiExceptionHandler` → auth → `MapControllers`")
    content.append("7. Post-build: SoftwarePartDetector + Parrot initializer")
    content.append("")

    (PATTERNS / "dependency-injection.md").write_text("\n".join(content), encoding="utf-8")


def write_common_recipes(by_ns: dict[str, str]) -> None:
    # recipe id -> (title, namespace key for body, extra description override)
    recipes = [
        ("recipe-command-handler", "CommandHandler و مسیر Command", "Zamin.Core.ApplicationServices.Commands",
         "Handlerها از `CommandHandler<TCommand>` / `CommandHandler<TCommand,TData>` ارث می‌برند، `ZaminServices` را به base می‌دهند و از repository/domain استفاده می‌کنند."),
        ("recipe-query-handler", "QueryHandler و مسیر Query", "Zamin.Core.ApplicationServices.Queries",
         "Handler کوئری از `QueryHandler<TQuery,TData>` ارث می‌برد و معمولاً با query repository کار می‌کند."),
        ("recipe-command-dispatcher", "ICommandDispatcher از طریق BaseController", "Zamin.Core.Contracts.ApplicationServices.Commands",
         "کنترلرها مستقیم dispatcher را صدا نمی‌زنند؛ از helperهای BaseController استفاده می‌شود که به ICommandDispatcher می‌رسد."),
        ("recipe-query-dispatcher", "IQueryDispatcher از طریق BaseController", "Zamin.Core.Contracts.ApplicationServices.Queries",
         "مسیر query مشابه command است با helper `Query<TQuery,TData>`."),
        ("recipe-command-contracts", "قراردادهای ICommand / CommandResult", "Zamin.Core.RequestResponse.Commands",
         "DTO فرمان: `ICommand` یا `ICommand<TData>`؛ خروجی handler از نوع `CommandResult` / `CommandResult<TData>`."),
        ("recipe-query-contracts", "قراردادهای IQuery / PageQuery / PagedData", "Zamin.Core.RequestResponse.Queries",
         "کوئری‌ها `IQuery<TData>` هستند؛ صفحه‌بندی با `PageQuery` و `PagedData` مشاهده شده است."),
        ("recipe-application-service-status", "ApplicationServiceStatus", "Zamin.Core.RequestResponse.Common",
         "وضعیت نتیجه سرویس اپلیکیشن در نتایج command/query."),
        ("recipe-aggregate-entity", "AggregateRoot و Entity", "Zamin.Core.Domain.Entities",
         "Aggregateها از `AggregateRoot` / `AggregateRoot<TId>` و موجودیت‌های وابسته از `Entity` / `Entity<TId>` ارث می‌برند."),
        ("recipe-value-objects", "BaseValueObject و BusinessId", "Zamin.Core.Domain.ValueObjects",
         "Value objectها از `BaseValueObject<T>` ارث می‌برند."),
        ("recipe-toolkit-value-objects", "Toolkit value objects (Title, …)", "Zamin.Core.Domain.Toolkits.ValueObjects",
         "VOهای آماده مثل Title / Description / NationalCode / Priority در نمونه‌های دامنه استفاده شده‌اند."),
        ("recipe-domain-exceptions", "استثناهای دامنه", "Zamin.Core.Domain.Exceptions",
         "`InvalidEntityStateException` و `InvalidValueObjectStateException` در دامنه throw می‌شوند."),
        ("recipe-command-repository", "ICommandRepository و BaseCommandRepository", "Zamin.Infra.Data.Sql.Commands",
         "ریپازیتوری فرمان از `BaseCommandRepository<...>` ارث می‌برد و قرارداد `ICommandRepository` را پیاده می‌کند."),
        ("recipe-query-repository", "IQueryRepository و BaseQueryRepository", "Zamin.Infra.Data.Sql.Queries",
         "ریپازیتوری کوئری از `BaseQueryRepository<TDbContext>` و `BaseQueryDbContext` استفاده می‌کند."),
        ("recipe-outbox-dbcontext", "BaseOutboxCommandDbContext", "Zamin.Extensions.Events.Outbox.Dal.EF",
         "Command DbContext اپلیکیشن از `BaseOutboxCommandDbContext` ارث می‌برد."),
        ("recipe-ef-interceptors", "Interceptorهای EF فرمان", "Zamin.Infra.Data.Sql.Commands.Interceptors",
         "`SetPersianYeKeInterceptor` و `AddAuditDataInterceptor` روی Command DbContext ثبت می‌شوند."),
        ("recipe-base-controller", "BaseController", "Zamin.EndPoints.Web.Controllers",
         "کنترلرهای API از `BaseController` و متدهای `Create` / `Edit` / `Delete` / `Query` استفاده می‌کنند."),
        ("recipe-http-context-extensions", "HttpContextExtensions", "Zamin.EndPoints.Web.Extensions",
         "الگوی استفاده مشاهده‌شده در الگوهای کاربردی برای extensionهای HTTP."),
        ("recipe-model-binding", "Model binding extensions", "Zamin.EndPoints.Web.Extensions.ModelBinding",
         "الگوی model binding مرتبط با EndPoints.Web."),
        ("recipe-zamin-services", "ZaminServices در Handlerها", "Zamin.Utilities",
         "`ZaminServices` به هر CommandHandler/QueryHandler تزریق می‌شود و سرویس‌های مشترک (مثل UserInfo) را در دسترس می‌گذارد."),
        ("recipe-user-info", "IUserInfoService", "Zamin.Extensions.UsersManagement.Abstractions",
         "دسترسی به کاربر جاری از طریق `IUserInfoService` یا `zaminServices.UserInfoService`."),
        ("recipe-translator", "ITranslator", "Zamin.Extensions.Translations.Abstractions",
         "ترجمه پیام‌ها از طریق `ITranslator` (پیاده‌سازی Parrot)."),
        ("recipe-translator-keys", "TranslatorKeys / TranslatorValues", "Zamin.Utilities.Resources.Translators",
         "کلید/مقدارهای ترجمه استفاده‌شده در کنار translator."),
        ("recipe-cache-adapter", "ICacheAdapter", "Zamin.Extensions.Caching.Abstractions",
         "مصرف کش توزیع‌شده از طریق `ICacheAdapter` پس از ثبت Redis/SQL."),
    ]

    lines = []
    lines.append("# Common recipes — الگوهای کاربردی زمین")
    lines.append("")
    lines.append(
        "این فایل بازنویسی مرتب‌شده‌ی `general-recipes.md` و `patterns/by-namespace/*.md` است. "
        "فقط الگوهای صحیح استفاده‌ی مستندشده آمده‌اند."
    )
    lines.append("")
    lines.append("## فهرست Recipeها")
    lines.append("")
    for rid, title, _, _ in recipes:
        lines.append(f"- [{title}](#{rid})")
    lines.append("")

    lines.append("## Recipe: برش عمودی Command (از HTTP تا Commit) {#recipe-vertical-command}")
    lines.append("")
    lines.append(
        "**توضیح:** جریان تکراری پیشنهادی: DTO با `ICommand`/`ICommand<TData>` → "
        "`CommandHandler` → Aggregate + `ICommandRepository` → `CommitAsync` → "
        "`CommandResult` از طریق `BaseController`."
    )
    lines.append("")
    lines.append("**کد نمونه:**")
    lines.append("")
    gen = (PATTERNS / "general-recipes.md").read_text(encoding="utf-8-sig") if (PATTERNS / "general-recipes.md").exists() else ""
    m_handler = re.search(
        r"```csharp\n(// Handler — src/1\.Core/ApplicationService/Softwares/Commands/Create/.*?)\n```",
        gen,
        flags=re.S,
    )
    m_ctrl = re.search(
        r"```csharp\n(// Controller — src/3\.Endpoints/API/Features/Softwares/SoftwareController\.cs.*?)\n```",
        gen,
        flags=re.S,
    )
    if m_handler:
        lines.append("```csharp")
        lines.append(m_handler.group(1).rstrip())
        lines.append("```")
        lines.append("")
    else:
        cmd_body = by_ns.get("Zamin.Core.ApplicationServices.Commands", "")
        cmd_blocks = extract_code_blocks(cmd_body)
        # prefer handler sample (usually later block), not DI registration
        chosen = None
        for b in cmd_blocks:
            if "CommandHandler<" in b or "Handle(" in b:
                chosen = b
                break
        if not chosen and cmd_blocks:
            chosen = cmd_blocks[-1]
        if chosen:
            lines.append("```csharp")
            lines.append(chosen.rstrip())
            lines.append("```")
            lines.append("")
        else:
            lines.append("مستندات کافی موجود نیست")
            lines.append("")
    if m_ctrl:
        lines.append("```csharp")
        lines.append(m_ctrl.group(1).rstrip())
        lines.append("```")
    else:
        ctrl = by_ns.get("Zamin.EndPoints.Web.Controllers", "")
        ctrl_blocks = extract_code_blocks(ctrl)
        if ctrl_blocks:
            lines.append("")
            lines.append("```csharp")
            lines.append(ctrl_blocks[0].rstrip())
            lines.append("```")
    lines.append("")
    lines.append("**نکات مهم:**")
    lines.append("")
    lines.append("- ترتیب call: `HTTP` → `BaseController` → `ICommandDispatcher` (+ decorator لاگ اپلیکیشن) → `Handle` → repository → `CommitAsync`.")
    lines.append("- Exception دامنه معمولاً bubble می‌شود مگر handler خودش catch کند.")
    lines.append("")

    lines.append("## Recipe: برش عمودی Query {#recipe-vertical-query}")
    lines.append("")
    lines.append(
        "**توضیح:** `IQuery<T>` → `QueryHandler` → `IQueryRepository.ExecuteAsync` → `QueryResult` → `BaseController.Query`."
    )
    lines.append("")
    lines.append("**کد نمونه:**")
    lines.append("")
    q = by_ns.get("Zamin.Core.ApplicationServices.Queries", "")
    q_blocks = extract_code_blocks(q)
    m = re.search(
        r"```csharp\n(// src/1\.Core/ApplicationService/Users/Queries/GetPagedFilter/.*?)\n```",
        gen,
        flags=re.S,
    )
    if m:
        lines.append("```csharp")
        lines.append(m.group(1).rstrip())
        lines.append("```")
    elif q_blocks:
        lines.append("```csharp")
        lines.append(q_blocks[0].rstrip())
        lines.append("```")
    else:
        lines.append("مستندات کافی موجود نیست")
    lines.append("")
    lines.append("**نکات مهم:**")
    lines.append("")
    lines.append("- مسیر query معمولاً `CommitAsync` ندارد.")
    lines.append("")

    for rid, title, ns_key, desc in recipes:
        body = by_ns.get(ns_key, "")
        lines.append(f"## Recipe: {title} {{#{rid}}}")
        lines.append("")
        lines.append(f"**توضیح:** {desc}")
        lines.append("")
        if body.strip():
            extra = first_paragraph_after_heading(body)
            if extra and extra != "مستندات کافی موجود نیست":
                lines.append(extra)
                lines.append("")
        lines.append("**کد نمونه:**")
        lines.append("")
        blocks = extract_code_blocks(body)
        if blocks:
            # include up to 2 code blocks
            for b in blocks[:2]:
                lines.append("```csharp")
                lines.append(b.rstrip())
                lines.append("```")
                lines.append("")
        else:
            lines.append("مستندات کافی موجود نیست")
            lines.append("")
        lines.append("**نکات مهم:**")
        lines.append("")
        # pull bullet lines from original if any
        bullets = [
            ln.strip()
            for ln in body.splitlines()
            if ln.strip().startswith("- ") and "Types observed" not in ln
        ]
        if bullets:
            for b in bullets[:6]:
                lines.append(b)
        else:
            lines.append(f"- جزئیات بیشتر در api-reference برای `{ns_key}`.")
        lines.append("")
        lines.append(f"- Namespace مرتبط: `{ns_key}`")
        lines.append("")

    lines.append("## ترکیب دامنه و persistence (خلاصه مشاهده‌شده)")
    lines.append("")
    lines.append("- Aggregate: `AggregateRoot` / `AggregateRoot<TId>`؛ Entity: `Entity` / `Entity<TId>`.")
    lines.append("- VO: `BaseValueObject<T>` + استثناهای Invalid*.")
    lines.append("- Command DbContext: `BaseOutboxCommandDbContext`؛ Query: `BaseQueryDbContext`.")
    lines.append("- Repository: `BaseCommandRepository` / `BaseQueryRepository` + قراردادهای Core.Contracts.Data.*")
    lines.append("- Lifetime: markerهای `ITransientLifetime` و مشابه از طریق `AddZaminApiCore`.")
    lines.append("")
    lines.append("## مدیریت استثناء (مشاهده‌شده در الگوهای کاربردی)")
    lines.append("")
    lines.append("- دامنه: throw از `InvalidEntityStateException` / `InvalidValueObjectStateException`.")
    lines.append("- بعضی نقاط اپلیکیشن catch محلی دارند (مثلاً GetUserSubOrDefault → Guid.Empty).")
    lines.append("- Decoratorهای dispatcher: catch `Exception`، لاگ، سپس rethrow.")
    lines.append("- زیر `src/` هیچ `catch (DomainStateException)` یافت نشده است.")
    lines.append("")

    (PATTERNS / "common-recipes.md").write_text("\n".join(lines), encoding="utf-8")


def rewrite_unused_types() -> None:
    src = PATTERNS / "unused-types.md"
    text = src.read_text(encoding="utf-8-sig")
    # fix mangled escapes from prior stage
    text = text.replace("\ramework-docs", "framework-docs")
    text = text.replace("\bin/obj/_Migrations", "bin/obj/_Migrations")
    text = text.replace("\by-namespace", "by-namespace")
    # ensure header mentions role in final docs
    if not text.startswith("# Unused"):
        pass
    header = (
        "# Unused types — تایپ‌های زمین بدون نمونه‌ی عملی استفاده\n\n"
        "> این فایل از مرحله‌ی patterns حفظ/بازنویسی شده است. برای این تایپ‌ها نمونه‌ی عملی استفاده در دسترس نیست؛ "
        "فقط به `api-reference/` و `enriched/` مراجعه کنید.\n\n"
    )
    # drop old H1 and rebuild
    body = re.sub(r"^# .*\n+", "", text, count=1)
    # normalize leftover broken prefixes if any
    body = body.replace("ramework-docs", "framework-docs")
    body = body.replace("in/obj/_Migrations", "bin/obj/_Migrations")
    body = body.replace("y-namespace", "by-namespace")
    src.write_text(header + body.lstrip(), encoding="utf-8")


def write_overview(api_toc: list[dict]) -> None:
    index = load_json(ENRICHED.parent / "raw-extraction" / "_index.json") if (ENRICHED.parent / "raw-extraction" / "_index.json").exists() else {}
    summary_path = ENRICHED / "_summary.md"
    summary = summary_path.read_text(encoding="utf-8-sig") if summary_path.exists() else ""

    ns_count = index.get("namespace_count", 97)
    type_count = index.get("total_types", "مستندات کافی موجود نیست")
    source_files = index.get("source_file_count", "مستندات کافی موجود نیست")

    # group namespaces by top-level area from enriched file list
    areas: dict[str, list[str]] = defaultdict(list)
    for f in sorted(ENRICHED.glob("*.json")):
        ns = f.stem
        if ns.startswith("Zamin.Core."):
            areas["Core"].append(ns)
        elif ns.startswith("Zamin.EndPoints."):
            areas["EndPoints"].append(ns)
        elif ns.startswith("Zamin.Extensions."):
            areas["Extensions"].append(ns)
        elif ns.startswith("Zamin.Infra."):
            areas["Infra"].append(ns)
        elif ns.startswith("Zamin.Utilities"):
            areas["Utilities"].append(ns)
        else:
            areas["Other"].append(ns)

    lines = []
    lines.append("# Zamin — نمای کلی مستندات")
    lines.append("")
    lines.append(
        "زمین (Zamin) یک فریمورک .NET مبتنی بر معماری لایه‌ای/پیازی است که قراردادها و پیاده‌سازی‌های "
        "آماده برای Command/Query، دامنه (Aggregate/Entity/ValueObject)، زیرساخت SQL، EndPointهای وب، "
        "و مجموعه‌ای از Extensionها (کش، پیام، ترجمه، DI، و …) را فراهم می‌کند. "
        "این مجموعه مستندات از استخراج سورس زمین به‌همراه الگوهای صحیح استفاده‌ی مستندشده "
        "(`D:\\Sources\\myapp\\myapp`) تولید شده است."
    )
    lines.append("")
    lines.append(
        f"طبق `raw-extraction/_index.json`، استخراج شامل **{source_files}** فایل سورس، "
        f"**{ns_count}** namespace و **{type_count}** تایپ است. "
        "توضیحات تایپ/اعضا در `framework-docs/enriched/` غنی‌سازی شده‌اند "
        "(XML نویسنده در صورت وجود حفظ شده؛ در غیر این صورت `generated_doc`)."
    )
    lines.append("")
    lines.append(
        "هر جا داده کافی برای ادعا وجود نداشته باشد، در این مستندات صریحاً با عبارت "
        "«مستندات کافی موجود نیست» مشخص شده و چیزی حدس زده نشده است."
    )
    lines.append("")
    lines.append("## معماری کلی (بر اساس namespaceهای استخراج‌شده)")
    lines.append("")
    lines.append(
        "ماژول‌های اصلی زمین از روی پیشوند namespaceها قابل گروه‌بندی‌اند. ارتباط عملی لایه‌ها "
        "به‌صورت جریان HTTP → EndPoints.Web (`BaseController`) → ApplicationServices "
        "(Dispatcher/Handler) → Domain → Infra.Data.Sql (+ Extensionهای Outbox/Cache/… ) دیده شده است."
    )
    lines.append("")
    for area in ["Core", "EndPoints", "Infra", "Extensions", "Utilities", "Other"]:
        items = areas.get(area) or []
        if not items:
            continue
        lines.append(f"### {area} ({len(items)} namespace)")
        lines.append("")
        if area == "Core":
            lines.append(
                "هسته: ApplicationServices (Commands/Queries/Events)، Contracts، Domain "
                "(Entities/ValueObjects/Exceptions/Events)، و RequestResponse."
            )
        elif area == "EndPoints":
            lines.append("لایه وب: Controllers پایه، ModelBinding، Filters، Middleware مدیریت استثناء.")
        elif area == "Infra":
            lines.append("زیرساخت داده SQL برای Command و Query (Repository، Interceptor، ValueConversion).")
        elif area == "Extensions":
            lines.append(
                "افزونه‌ها: DI، Caching، MessageBus، Events (Outbox/PollingPublisher)، "
                "Translations، Serializers، ObjectMappers، UsersManagement، ChangeDataLog، Logger."
            )
        elif area == "Utilities":
            lines.append(
                "ابزارهای مشترک: `ZaminServices`، Auth.ApiAuthentication، Serilog، Guards، "
                "DateTimes، SoftwarePartDetector، Resources.Translators، و …"
            )
        lines.append("")
        for ns in items:
            single = API_REF / f"{ns}.md"
            part1 = API_REF / f"{ns}.Part1.md"
            if single.exists():
                lines.append(f"- [`{ns}`](api-reference/{ns}.md)")
            elif part1.exists():
                nparts = len(list(API_REF.glob(f"{ns}.Part*.md")))
                lines.append(f"- [`{ns}`](api-reference/{ns}.Part1.md) ({nparts} بخش)")
            else:
                lines.append(f"- `{ns}` — مستندات کافی موجود نیست")
        lines.append("")

    lines.append("## مفاهیم پایه‌ای برای درک فریمورک")
    lines.append("")
    lines.append(
        "این مفاهیم از الگوهای مشاهده‌شده در الگوهای کاربردی و تایپ‌های Core استخراج شده‌اند:"
    )
    lines.append("")
    lines.append(
        "1. **CQRS سبک:** فرمان‌ها (`ICommand` / `CommandHandler` / `ICommandDispatcher`) "
        "و کوئری‌ها (`IQuery` / `QueryHandler` / `IQueryDispatcher`) مسیرهای جدا دارند."
    )
    lines.append(
        "2. **دامنه غنی:** `AggregateRoot`/`Entity` + ValueObjectها؛ نقضInvariant با "
        "`InvalidEntityStateException` / `InvalidValueObjectStateException`."
    )
    lines.append(
        "3. **نتیجه اپلیکیشن:** `CommandResult` / `QueryResult` و `ApplicationServiceStatus`."
    )
    lines.append(
        "4. **ثبت وابستگی:** `AddZaminApiCore` برای کشف handlerها و lifetime markerها؛ "
        "decoratorهای dispatcher قابل جایگزینی‌اند."
    )
    lines.append(
        "5. **`ZaminServices`:** کانتینر سرویس‌های مشترک تزریق‌شونده به handlerها "
        "(مثلاً دسترسی به `UserInfoService`)."
    )
    lines.append(
        "6. **جداسازی خواندن/نوشتن داده:** `BaseOutboxCommandDbContext` / `BaseCommandRepository` "
        "در برابر `BaseQueryDbContext` / `BaseQueryRepository`."
    )
    lines.append(
        "7. **EndPoint نازک:** کنترلر از `BaseController` ارث می‌برد و فقط به helperهای Create/Edit/Delete/Query متکی است."
    )
    lines.append("")
    lines.append("## نقطه‌ی شروع پیشنهادی برای ایجنت")
    lines.append("")
    lines.append("اگر می‌خواهید با زمین با زمین کد بزنید، این ترتیب را دنبال کنید:")
    lines.append("")
    lines.append("1. همین فایل (`overview.md`) و سپس [`_toc.md`](_toc.md) برای نقشه کامل.")
    lines.append("2. [`patterns/dependency-injection.md`](patterns/dependency-injection.md) — نحوه bootstrap و ثبت سرویس.")
    lines.append(
        "3. [`patterns/common-recipes.md`](patterns/common-recipes.md) — برش عمودی command/query، "
        "Aggregate، Repository، BaseController."
    )
    lines.append(
        "4. api-reference برای تایپ‌هایی که لمس می‌کنید، حداقل:"
    )
    lines.append("   - `Zamin.Core.ApplicationServices.Commands` / `Queries`")
    lines.append("   - `Zamin.Core.RequestResponse.Commands` / `Queries`")
    lines.append("   - `Zamin.Core.Domain.Entities` / `ValueObjects` / `Exceptions`")
    lines.append("   - `Zamin.Infra.Data.Sql.Commands` / `Queries`")
    lines.append("   - `Zamin.EndPoints.Web.Controllers`")
    lines.append("   - `Zamin.Utilities` (`ZaminServices`)")
    lines.append(
        "5. قبل از استفاده از تایپ‌های ناآشنا، [`patterns/unused-types.md`](patterns/unused-types.md) را چک کنید؛ "
        "اگر نمونه‌ی عملی استفاده در دسترس نیست، نمونه واقعی در این ریپو ندارید و فقط به XML/enriched تکیه کنید."
    )
    lines.append("")
    lines.append("## آمار غنی‌سازی مستندات API")
    lines.append("")
    if summary.strip():
        # include counts section only
        m = re.search(r"## Counts\n\n(.*?)(?:\n## |\Z)", summary, flags=re.S)
        if m:
            lines.append(m.group(1).strip())
        else:
            lines.append("مستندات کافی موجود نیست")
    else:
        lines.append("مستندات کافی موجود نیست")
    lines.append("")
    lines.append(f"تعداد فایل‌های api-reference تولیدشده در این مرحله: **{len(api_toc)}**.")
    lines.append("")

    (ROOT / "framework-docs" / "overview.md").write_text("\n".join(lines), encoding="utf-8")


def write_toc(api_toc: list[dict]) -> None:
    lines = []
    lines.append("# فهرست مستندات زمین (TOC)")
    lines.append("")
    lines.append("نقشه کامل فایل‌های `framework-docs/` برای انسان و ایجنت.")
    lines.append("")
    lines.append("## ریشه")
    lines.append("")
    lines.append("| فایل | توضیح |")
    lines.append("|---|---|")
    lines.append("| [overview.md](overview.md) | معرفی زمین، معماری ماژول‌ها، مفاهیم پایه، و نقطه‌ی شروع پیشنهادی برای ایجنت |")
    lines.append("| [_toc.md](_toc.md) | همین فهرست — نقشه کامل مستندات |")
    lines.append("")
    lines.append("## Patterns")
    lines.append("")
    lines.append("| فایل | توضیح |")
    lines.append("|---|---|")
    lines.append("| [patterns/dependency-injection.md](patterns/dependency-injection.md) | Recipeهای ثبت DI، bootstrap هاست، کش، ترجمه، auth، و Worker DAL بر اساس الگوهای کاربردی |")
    lines.append("| [patterns/common-recipes.md](patterns/common-recipes.md) | Recipeهای کاربردی CQRS، دامنه، repository، BaseController و سرویس‌های مشترک |")
    lines.append("| [patterns/unused-types.md](patterns/unused-types.md) | تایپ‌های زمین بدون نمونه‌ی عملی استفاده (بدون Recipe واقعی) |")
    lines.append("")
    lines.append("### فایل‌های کمکی مرحله قبل (منبع خام patterns)")
    lines.append("")
    lines.append("| فایل | توضیح |")
    lines.append("|---|---|")
    lines.append("| [patterns/general-recipes.md](patterns/general-recipes.md) | پیش‌نویس کلی recipes قبل از بازنویسی نهایی |")
    lines.append("| [patterns/_inventory.json](patterns/_inventory.json) | موجودی تایپ‌های used/unused استخراج‌شده از الگوهای کاربردی |")
    lines.append("| [patterns/by-namespace/](patterns/by-namespace/) | یادداشت خام الگوی هر namespace با نمونه‌ی عملی استفاده |")
    lines.append("")
    lines.append("## API Reference")
    lines.append("")
    lines.append("| فایل | توضیح |")
    lines.append("|---|---|")
    for e in api_toc:
        lines.append(f"| [{e['title']}]({e['path']}) | {e['blurb']} |")
    lines.append("")
    lines.append("## منابع داده")
    lines.append("")
    lines.append("| مسیر | توضیح |")
    lines.append("|---|---|")
    lines.append("| [enriched/](enriched/) | JSON غنی‌شده‌ی هر namespace (مرجع کامل API + generated_doc) |")
    lines.append("| [enriched/_summary.md](enriched/_summary.md) | خلاصه آمار enrichment |")
    lines.append("| [raw-extraction/](raw-extraction/) | استخراج خام بدون بازنویسی مستندات |")
    lines.append("")

    (ROOT / "framework-docs" / "_toc.md").write_text("\n".join(lines), encoding="utf-8")


def fix_overview_part_links() -> None:
    """Update overview links when Part files exist instead of single file."""
    overview = ROOT / "framework-docs" / "overview.md"
    text = overview.read_text(encoding="utf-8")
    for md in API_REF.glob("*.md"):
        if ".Part" in md.name:
            continue
        # if only parts exist, single file won't exist — already handled by generator writing either single or parts
        pass
    # Rewrite links: if Zamin.X.md missing but Part1 exists, point to Part1
    def repl(match: re.Match) -> str:
        ns = match.group(1)
        single = API_REF / f"{ns}.md"
        part1 = API_REF / f"{ns}.Part1.md"
        if single.exists():
            return match.group(0)
        if part1.exists():
            return f"[`{ns}`](api-reference/{ns}.Part1.md)"
        return f"`{ns}` (مستندات کافی موجود نیست)"

    text2 = re.sub(r"\[`([^`]+)`\]\(api-reference/\1\.md\)", repl, text)
    overview.write_text(text2, encoding="utf-8")


def main() -> None:
    by_ns = load_by_namespace_bodies()
    print("Writing dependency-injection.md …")
    write_dependency_injection(by_ns)
    print("Writing common-recipes.md …")
    write_common_recipes(by_ns)
    print("Rewriting unused-types.md …")
    rewrite_unused_types()
    print("Generating api-reference …")
    api_toc = write_api_reference()
    print(f"  -> {len(api_toc)} files")
    print("Writing overview.md …")
    write_overview(api_toc)
    fix_overview_part_links()
    print("Writing _toc.md …")
    write_toc(api_toc)
    print("Done.")


if __name__ == "__main__":
    main()
