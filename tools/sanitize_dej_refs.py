#!/usr/bin/env python3
"""Sanitize framework-docs and skills/zamin: remove Dej/دژ branding; keep Zamin usage patterns."""

from __future__ import annotations

import re
import shutil
from pathlib import Path

ROOT = Path(__file__).resolve().parents[1]
TARGETS = [ROOT / "framework-docs", ROOT / "skills" / "zamin"]
TEXT_SUFFIXES = {".md", ".json", ".txt", ".csv", ".yml", ".yaml"}

# Ordered replacements (longer / more specific first)
REPLACEMENTS: list[tuple[str, str]] = [
    # Paths / namespaces
    (r"D:\\Sources\\dej\\dej\\src", "application source"),
    (r"D:/Sources/dej/dej/src", "application source"),
    (r"Dej\.Endpoints\.API\.Extentions\.DependencyInjection", "MyApp.Endpoints.DependencyInjection"),
    (r"Dej\.Core\.Domain\.Common\.ValueObjects", "MyApp.Domain.ValueObjects"),
    (r"DejCommandDbContext", "AppCommandDbContext"),
    (r"DejQueryDbContext", "AppQueryDbContext"),
    (r"AddDejUserInfoService", "AddAppUserInfoService"),
    (r"DejBusinessMetrics", "AppBusinessMetrics"),
    (r'"dej\.status"', '"app.status"'),
    (r"dej\.status", "app.status"),
    (r'AddZaminApiCore\("Zamin", "Dej"\)', 'AddZaminApiCore("Zamin", "MyApp")'),
    (r'AddZaminApiCore\("Zamin", "dej"\)', 'AddZaminApiCore("Zamin", "MyApp")'),
    # Domain samples from product apps → neutral samples (protect SoftwarePart*)
    (r"SoftwarePart", "<<<SOFTWAREPART>>>"),
    (r"ISoftwareCommandRepository", "ISampleCommandRepository"),
    (r"ISoftwareValidationsDomainService", "ISampleValidationService"),
    (r"SoftwareCreateCommand", "SampleCreateCommand"),
    (r"SoftwareUpdateCommand", "SampleUpdateCommand"),
    (r"SoftwareDeleteCommand", "SampleDeleteCommand"),
    (r"SoftwareCreateHandler", "SampleCreateHandler"),
    (r"SoftwareCreateParameter", "SampleCreateParameter"),
    (r"SoftwareGetDetailQuery", "SampleGetDetailQuery"),
    (r"SoftwareController", "SampleController"),
    (r"SoftwareQr", "SampleDetailDto"),
    (r"SoftwareName", "SampleName"),
    (r"\bSoftwares\b", "Samples"),
    (r"\bSoftware\b", "Sample"),
    (r"<<<SOFTWAREPART>>>", "SoftwarePart"),
    (r"IUserQueryRepository", "ISampleQueryRepository"),
    (r"UserGetPagedFilterQueryHandler", "SampleGetPagedFilterQueryHandler"),
    (r"UserGetPagedFilterQuery", "SampleGetPagedFilterQuery"),
    (r"UserListItemQr", "SampleListItemDto"),
    (r"UserQueryRepository", "SampleQueryRepository"),
    (r"ISliderCommandRepository", "ISampleCommandRepository"),
    (r"\bSlider\b", "Sample"),
    (r"LoggingCommandDispatcherDecorator", "LoggingCommandDispatcherDecorator"),
    (r"LoggingQueryDispatcherDecorator", "LoggingQueryDispatcherDecorator"),
    # Prose / headings
    (r"الگوی مرتبط در Dej", "الگوی استفاده مرتبط"),
    (r"الگوی مرتبط در دژ", "الگوی استفاده مرتبط"),
    (r"unused_in_dej", "without_usage_sample"),
    (r"Unused in Dej \(unused_in_dej\)", "Types without a usage sample"),
    (r"Unused types — تایپ‌های زمین بدون نمونه واقعی در دژ",
     "Unused types — تایپ‌های زمین بدون نمونه‌ی عملی استفاده"),
    (r"Dependency Injection — الگوهای ثبت سرویس زمین در دژ",
     "Dependency Injection — الگوهای ثبت سرویس زمین"),
    (r"Common recipes — الگوهای کاربردی زمین در دژ",
     "Common recipes — الگوهای کاربردی زمین"),
    (r"General recipes — Zamin usage in Dej",
     "General recipes — Zamin usage patterns"),
    (r"Zamin usage in Dej", "Zamin usage patterns"),
    (r"patterns observed in Dej", "documented usage patterns"),
    (r"observed in Dej", "documented in usage patterns"),
    (r"seen in Dej", "shown in usage patterns"),
    (r"in Dej", "in application code"),
    (r"In Dej", "In application code"),
    (r"from Dej", "from application usage"),
    (r"From Dej", "From application usage"),
    (r"via Dej", "via application patterns"),
    (r"Dej-proven", "battle-tested"),
    (r"Dej coupling", "Application-specific coupling"),
    (r"no real usage sample in Dej", "no practical usage sample available"),
    (r"no Recipe from Dej", "no usage recipe available"),
    (r"Recipe from Dej", "usage recipe"),
    (r"Types observed in Dej", "Types observed in usage patterns"),
    (r"Types observed:", "Types in this pattern:"),
    (r"Typical Dej command flow", "Typical command flow"),
    (r"How Dej wires it", "How to wire it"),
    (r"Dej hosts", "Application hosts"),
    (r"Dej registers", "The application registers"),
    (r"Dej also defines", "Applications may also define"),
    (r"dominant Dej style", "dominant application style"),
    (r"Related real VO pattern in Dej", "Related value-object pattern"),
    (r"under dej/src", "under application source"),
    (r"name collisions with Dej domain/API", "name collisions with application domain/API"),
    (r"\+\s*Dej `LoggingCommandDispatcherDecorator`", "+ app `LoggingCommandDispatcherDecorator`"),
    (r"Register Dej logging decorators", "Register application logging decorators"),
    (r"// \.\.\. Dej middlewares, auth \.\.\.", "// ... application middlewares, auth ..."),
    (r"کاربرد واقعی در دژ", "نمونه‌ی عملی استفاده"),
    (r"در پروژه‌ی دژ", "در کد نمونه کاربرد"),
    (r"پروژه‌ی دژ", "کد نمونه کاربرد"),
    (r"پروژه دژ", "کد نمونه کاربرد"),
    (r"از دژ", "از نمونه‌های کاربردی"),
    (r"در دژ", "در الگوی کاربردی"),
    (r"به دژ", "به الگوی کاربردی"),
    (r"با دژ", "با الگوی کاربردی"),
    (r"که دژ", "که الگوی کاربردی"),
    (r"دژ ", "الگوی کاربردی "),
    (r" دژ", " الگوی کاربردی"),
    (r"\bDej\b", "MyApp"),
    (r"\bdej\b", "myapp"),
    (r"دژ", "الگوی کاربردی"),
]

# After generic Softwares→Samples, fix path fragments that may look odd
PATH_FIXES: list[tuple[str, str]] = [
    (r"src/1\.Core/ApplicationService/Samples/Commands/Create/",
     "src/Application/Samples/Commands/Create/"),
    (r"src/3\.Endpoints/API/Features/Samples/",
     "src/Endpoints/API/Features/Samples/"),
    (r"src/1\.Core/ApplicationService/Users/Queries/GetPagedFilter/",
     "src/Application/Samples/Queries/GetPagedFilter/"),
    (r"src/1\.Core/Domain/Samples/Entities/",
     "src/Domain/Samples/Entities/"),
    (r"src/2\.Infra/Data/Sql\.Queries/Common/",
     "src/Infra/Sql.Queries/Common/"),
    (r"src/2\.Infra/Data/Sql\.Commands/",
     "src/Infra/Sql.Commands/"),
    (r"src/3\.Endpoints/API/Extentions/DependencyInjection/",
     "src/Endpoints/API/DependencyInjection/"),
    (r"src/3\.Endpoints/API/Program\.cs",
     "src/Endpoints/API/Program.cs"),
]


def sanitize_text(text: str) -> str:
    out = text
    for old, new in REPLACEMENTS:
        out = re.sub(old, new, out)
    for old, new in PATH_FIXES:
        out = re.sub(old, new, out)
    # Collapse accidental duplicate headers from unused-types rewrites
    out = re.sub(
        r"(> این فایل از مرحله‌ی patterns حفظ/بازنویسی شده است\. برای این تایپ‌ها Recipe از الگوی کاربردی وجود ندارد؛ فقط به `api-reference/` و `enriched/` مراجعه کنید\.\n\n)+",
        "> برای این تایپ‌ها نمونه‌ی عملی استفاده در دسترس نیست؛ مستندات فقط بر پایه‌ی امضا و پیاده‌سازی خود زمین "
        "(`api-reference/` / enrichment) است.\n\n",
        out,
    )
    return out


def should_process(path: Path) -> bool:
    return path.suffix.lower() in TEXT_SUFFIXES


def process_tree(root: Path) -> tuple[int, int]:
    changed = 0
    scanned = 0
    for path in root.rglob("*"):
        if not path.is_file() or not should_process(path):
            continue
        scanned += 1
        raw = path.read_text(encoding="utf-8-sig")
        new = sanitize_text(raw)
        if new != raw:
            path.write_text(new, encoding="utf-8")
            changed += 1
    return scanned, changed


def count_matches(root: Path) -> int:
    pat = re.compile(r"dej|دژ", re.I)
    n = 0
    for path in root.rglob("*"):
        if not path.is_file() or not should_process(path):
            continue
        try:
            t = path.read_text(encoding="utf-8-sig")
        except Exception:
            continue
        n += len(pat.findall(t))
    return n


def main() -> None:
    before = {str(t): count_matches(t) for t in TARGETS}
    print("Before:", before)
    for t in TARGETS:
        scanned, changed = process_tree(t)
        print(f"{t.name}: scanned={scanned} changed={changed}")
    after = {str(t): count_matches(t) for t in TARGETS}
    print("After:", after)


if __name__ == "__main__":
    main()
