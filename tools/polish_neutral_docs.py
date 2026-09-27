#!/usr/bin/env python3
"""Second-pass polish: neutralize awkward 'الگوی کاربردی' / MyApp prose after Dej scrub."""

from __future__ import annotations

import re
from pathlib import Path

ROOT = Path(__file__).resolve().parents[1]
TARGETS = [ROOT / "framework-docs", ROOT / "skills" / "zamin"]

UNUSED_TYPES_HEADER = """# Unused types — تایپ‌های زمین بدون نمونه‌ی عملی استفاده

> نمونه‌ی عملی استفاده در دسترس نیست؛ مستندات فقط بر پایه‌ی امضا و پیاده‌سازی خود زمین است
> (`api-reference/` و enrichment). برای این تایپ‌ها Recipe ترکیبی ارائه نشده است.

Zamin types from `framework-docs/raw-extraction` with **no whole-word identifier match**
in scanned application sources (excluding bin/obj/_Migrations).

Document these types from enrichment/XML / `api-reference` only.

## Scan notes

- Packages may still be referenced in `.csproj` while types stay unused.
- Some hosts contain **commented** registrations (RabbitMQ / PollingPublisher / MessageInbox / ChangeDataLog) — related types remain unused at runtime call-sites.
- `Zamin.Utilities.Guards.Guard`: comment-only hits (`// Guard: ...`); treated as unused.
- `Zamin.Utilities.SoftwarePartDetector.DataModel`: name collisions with application domain/API types are possible; not treated as confirmed framework DataModel usage without a clear call-site.
- Extension-only modules used without naming extracted types are covered under `by-namespace` (e.g. `AddNonValidatingValidator`, `AddZaminPollingPublisherDalSql`).

## Counts

- Unused type rows in inventory: **188** (plus Guard false-positive note).
- Namespaces with zero type-name hits: see groups below.

"""

PROSE_FIXES: list[tuple[str, str]] = [
    (r"هاست‌های الگوی کاربردی", "هاست‌های اپلیکیشن"),
    (r"قبل از `AddZaminApiCore\(\"Zamin\", \"MyApp\"\)` الگوی کاربردی decoratorها",
     "قبل از `AddZaminApiCore(\"Zamin\", \"MyApp\")` اپلیکیشن decoratorها"),
    (r"الگوی کاربردی با کلید", "اپلیکیشن با کلید"),
    (r"الگوی کاربردی `AddAppUserInfoService", "اپلیکیشن `AddAppUserInfoService"),
    (r"جریان تکراری الگوی کاربردی", "جریان تکراری پیشنهادی"),
    (r"decorator لاگ الگوی کاربردی", "decorator لاگ اپلیکیشن"),
    (r"فقط الگوهایی که در الگوی کاربردی مشاهده شده‌اند آمده‌اند",
     "فقط الگوهای صحیح استفاده‌ی مستندشده آمده‌اند"),
    (r"ارتباط عملی آن‌ها در الگوی کاربردی به‌صورت",
     "ارتباط عملی لایه‌ها به‌صورت"),
    (r"الگوهای استفاده‌ی واقعی در کد نمونه کاربرد \(`D:\\Sources\\myapp\\myapp`\)",
     "الگوهای صحیح استفاده‌ی مستندشده"),
    (r"الگوهای استفاده‌ی واقعی در کد نمونه کاربرد",
     "الگوهای صحیح استفاده‌ی مستندشده"),
    (r"از نمونه‌های کاربردی وجود ندارد", "در دسترس نیست"),
    (r"Recipe از نمونه‌های کاربردی وجود ندارد", "نمونه‌ی عملی / Recipe ترکیبی در دسترس نیست"),
    (r"no real MyApp usage sample", "no practical usage sample available"),
    (r"MyApp-like vertical slice", "typical vertical slice"),
    (r"Zamin-via-MyApp", "Zamin via documented recipes"),
    (r"patterns are battle-tested, not “official Zamin docs\.” Other products may differ; skill should be treated as Zamin-via-MyApp\.",
     "patterns are battle-tested recipes for correct Zamin composition; treat them as usage guidance, not a substitute for reading api-reference."),
    (r"Application-specific coupling — patterns are battle-tested, not “official Zamin docs\.” Other products may differ; skill should be treated as Zamin via application patterns\.",
     "Patterns document correct composition; always cross-check signatures in api-reference."),
    (r"call-siteهای واقعی زیر `application source` و فایل‌های",
     "نمونه‌های کاربردی مستندشده و فایل‌های"),
    (r"منبع: call-siteهای واقعی زیر `application source`",
     "منبع: نمونه‌های کاربردی مستندشده"),
    (r"همین شکل در IdentityServer و WorkerService هم دیده شده است\.",
     "همین شکل برای چند نوع هاست (API و Worker) قابل اعمال است."),
    (r"extension سمت الگوی کاربردی روی قراردادهای",
     "extension سمت اپلیکیشن روی قراردادهای"),
    (r"extension سمت دژ", "extension سمت اپلیکیشن"),
    (r"Decoratorهای dispatcher الگوی کاربردی", "Decoratorهای dispatcher اپلیکیشن"),
    (r"تایپ‌های دامنه‌ای الگوی کاربردی", "تایپ‌های دامنه‌ای اپلیکیشن"),
    (r"IPolicyEvaluationDataProvider", "ISampleAppService"),
    (r"Policies/Services/ISampleAppService\.cs", "Contracts/Services/ISampleAppService.cs"),
    (r"softwareCommandRepository", "sampleCommandRepository"),
    (r"softwareValidationDomainService", "sampleValidationService"),
    (r"Sample software = Sample\.Create", "Sample entity = Sample.Create"),
    (r"InsertAsync\(software\)", "InsertAsync(entity)"),
    (r"CommitAsync\(\);\n\n        return await OkAsync\(software\.BusinessId\.Value\)",
     "CommitAsync();\n\n        return await OkAsync(entity.BusinessId.Value)"),
    (r"return await OkAsync\(software\.BusinessId\.Value\)",
     "return await OkAsync(entity.BusinessId.Value)"),
]


def polish_unused_types(path: Path) -> None:
    text = path.read_text(encoding="utf-8-sig")
    # Drop duplicated blockquotes / old header until ## without_usage_sample or first ###
    m = re.search(r"^## without_usage_sample by namespace\s*$", text, re.M)
    if not m:
        m = re.search(r"^### Zamin\.Core\.ApplicationServices\.Commands\s*$", text, re.M)
        if m:
            body = text[m.start():]
            text = UNUSED_TYPES_HEADER + "## without_usage_sample by namespace\n\n" + body
        else:
            text = UNUSED_TYPES_HEADER + text
    else:
        text = UNUSED_TYPES_HEADER + text[m.start():]
    path.write_text(text, encoding="utf-8")


def polish_file(path: Path) -> bool:
    raw = path.read_text(encoding="utf-8-sig")
    out = raw
    for old, new in PROSE_FIXES:
        out = re.sub(old, new, out)
    # generic leftover awkward phrase
    out = out.replace("الگوی کاربردی ", "اپلیکیشن ")
    out = out.replace(" الگوی کاربردی", " اپلیکیشن")
    if out != raw:
        path.write_text(out, encoding="utf-8")
        return True
    return False


def main() -> None:
    for root in TARGETS:
        for path in root.rglob("*.md"):
            if path.name == "unused-types.md":
                polish_unused_types(path)
            polish_file(path)
    # final dej check
    pat = re.compile(r"dej|دژ", re.I)
    for root in TARGETS:
        n = 0
        for path in root.rglob("*"):
            if not path.is_file() or path.suffix.lower() not in {".md", ".json", ".txt"}:
                continue
            t = path.read_text(encoding="utf-8-sig")
            n += len(pat.findall(t))
        print(root, "dej/دژ matches:", n)


if __name__ == "__main__":
    main()
