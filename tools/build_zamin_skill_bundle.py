#!/usr/bin/env python3
"""Build a single self-contained dist/zamin.skill.md from enriched + patterns."""

from __future__ import annotations

import json
import re
from pathlib import Path

ROOT = Path(__file__).resolve().parents[1]
ENRICHED = ROOT / "framework-docs" / "enriched"
INDEX = ROOT / "framework-docs" / "raw-extraction" / "_index.json"
PATTERNS = ROOT / "skills" / "zamin" / "references" / "patterns"
OVERVIEW = ROOT / "skills" / "zamin" / "references" / "overview.md"
OUT = ROOT / "dist" / "zamin.skill.md"
README = ROOT / "dist" / "README.md"

MAX_DOC_CHARS = 280
MAX_SIG_LINES = 3


def load_json(path: Path) -> dict:
    return json.loads(path.read_text(encoding="utf-8-sig"))


def clean_sig(sig: str | None) -> str:
    if not sig or not str(sig).strip():
        return ""
    s = str(sig).replace("\r\n", "\n").replace("\r", "\n").strip()
    lines = s.split("\n")
    if len(lines) > MAX_SIG_LINES:
        return lines[0].rstrip() + " // …"
    return " ".join(x.strip() for x in lines)


def short_doc(text: str | None) -> str:
    if not text or not str(text).strip():
        return "مستندات کافی موجود نیست"
    t = str(text).replace("\r\n", " ").replace("\n", " ").replace("\r", " ")
    t = re.sub(r"\s+", " ", t).strip()
    t = re.sub(r"</?summary>|</?param[^>]*>|</?returns>", "", t)
    if len(t) > MAX_DOC_CHARS:
        t = t[: MAX_DOC_CHARS - 1].rstrip() + "…"
    return t


def strip_external_links(md: str) -> str:
    md = re.sub(
        r"\[([^\]]+)\]\((?:\.\./|\./)?(?:[\w./\-]+\.md(?:#[\w\-]+)?)\)",
        r"\1",
        md,
    )
    md = re.sub(
        r"\[([^\]]+)\]\((?:api-reference|patterns|references|framework-docs)/[^)]+\)",
        r"\1",
        md,
    )
    replacements = {
        "`framework-docs/patterns/by-namespace` / `general-recipes.md`": "بخش Patterns همین فایل",
        "`framework-docs/patterns/by-namespace`": "بخش Patterns همین فایل",
        "`framework-docs/raw-extraction`": "فهرست استخراج",
        "`api-reference/`": "بخش API Reference همین فایل",
        "`api-reference`": "بخش API Reference همین فایل",
        "(`api-reference/` و enrichment)": "(بخش API Reference همین فایل)",
        "`api-reference/` / enrichment": "بخش API Reference همین فایل",
        "جزئیات بیشتر در api-reference برای": "جزئیات در بخش API Reference برای",
        "نگاه کنید به common-recipes": "نگاه کنید به Recipeهای مشترک در همین فایل",
        "مشاهده در patterns": "مشاهده در بخش Patterns همین فایل",
        "جزئیات در `unused-types.md` آمده است": "جزئیات در بخش «تایپ‌های بدون نمونه‌ی عملی» همین فایل آمده است",
        "فقط اشاره متنی در general-recipes؛ snippet کامل Worker در مرحله قبل استخراج نشده است": "snippet کامل Worker در منابع الگو موجود نیست",
        "فایل‌های `framework-docs/patterns/by-namespace` / `general-recipes.md`": "بخش Patterns همین فایل",
    }
    for a, b in replacements.items():
        md = md.replace(a, b)
    return md


def demote_headings(md: str, add: int = 1) -> str:
    def repl(m: re.Match) -> str:
        level = len(m.group(1))
        return "#" * min(6, level + add) + m.group(2)

    return re.sub(r"^(#{1,6})(\s+.*)$", repl, md, flags=re.M)


def overview_section() -> str:
    raw = OVERVIEW.read_text(encoding="utf-8-sig")
    buf: list[str] = []
    skip_ns_lists = False
    idx = load_json(INDEX)
    for line in raw.splitlines():
        if line.startswith("# "):
            continue
        if line.startswith("## معماری کلی"):
            buf.append(line)
            buf.append("")
            buf.append(
                "ماژول‌های زمین در گروه‌های **Core**، **EndPoints**، **Infra**، "
                "**Extensions** و **Utilities** سازمان یافته‌اند. جریان رایج: "
                "HTTP → `BaseController` → Dispatcher/Handler → Domain → "
                "Sql Command/Query (+ Extensionهای Outbox/Cache/…)."
            )
            buf.append("")
            buf.append(
                "فهرست کامل namespaceها و تایپ‌ها در بخش **API Reference** همین فایل آمده است."
            )
            buf.append("")
            skip_ns_lists = True
            continue
        if skip_ns_lists:
            if line.startswith("## مفاهیم") or line.startswith("## نقطه‌ی شروع") or line.startswith("## آمار"):
                skip_ns_lists = False
            else:
                continue
        if line.startswith("## آمار"):
            buf.append("## آمار استخراج")
            buf.append("")
            buf.append(
                f"- Namespaceها: **{idx['namespace_count']}** · تایپ‌ها: **{idx['total_types']}** · "
                f"فایل‌های سورس اسکن‌شده: **{idx['source_file_count']}**"
            )
            buf.append("")
            break
        # neutralize leftover source-path mentions from overview
        if "raw-extraction/_index.json" in line or "enriched/" in line or "framework-docs" in line:
            if "استخراج شامل" in line or "طبق" in line:
                buf.append(
                    f"استخراج سورس زمین شامل **{idx['source_file_count']}** فایل سورس، "
                    f"**{idx['namespace_count']}** namespace و **{idx['total_types']}** تایپ است. "
                    "توضیحات تایپ/اعضا از enrichment (XML نویسنده یا generated_doc) آمده‌اند."
                )
                buf.append("")
                continue
            continue
        buf.append(line)
    text = "\n".join(buf).strip()
    text = strip_external_links(text)
    text = re.sub(r"\[`([^`]+)`\]\([^)]+\)", r"`\1`", text)
    text = re.sub(r"\[([^\]]+)\]\([^)]+\)", r"\1", text)
    # agent start bullets that pointed to other files
    text = text.replace("[`_toc.md`](_toc.md)", "فهرست داخلی همین فایل (تیترها)")
    text = text.replace(
        "[`patterns/dependency-injection.md`](patterns/dependency-injection.md)",
        "بخش Patterns → Dependency Injection",
    )
    text = text.replace(
        "[`patterns/common-recipes.md`](patterns/common-recipes.md)",
        "بخش Patterns → Common recipes",
    )
    text = text.replace(
        "[`patterns/unused-types.md`](patterns/unused-types.md)",
        "بخش «تایپ‌های بدون نمونه‌ی عملی»",
    )
    text = strip_external_links(text)
    return demote_headings(text, 1)


def build_api_reference() -> tuple[str, set[str], int]:
    idx = load_json(INDEX)
    lines: list[str] = [
        "## API Reference",
        "",
        (
            f"مرجع فشرده برای **{idx['namespace_count']}** namespace و **{idx['total_types']}** تایپ. "
            "برای یافتن یک ماژول، تیتر `### Namespace:` یا نام کامل تایپ را جستجو کنید."
        ),
        "",
    ]
    documented = 0
    documented_keys: set[str] = set()

    for f in sorted(ENRICHED.glob("*.json")):
        data = load_json(f)
        ns = data.get("namespace") or f.stem
        types = data.get("types") or []
        lines.append(f"### Namespace: `{ns}`")
        lines.append("")
        if not types:
            lines.append("_تایپی در enrichment برای این namespace ثبت نشده است._")
            lines.append("")
            continue
        for t in types:
            tname = t.get("type_name") or "?"
            kind = t.get("kind") or "type"
            full = f"{ns}.{tname}"
            documented += 1
            documented_keys.add(f"{ns}::{tname}")
            lines.append(f"#### `{full}` ({kind})")
            lines.append("")
            lines.append(short_doc((t.get("generated_doc") or {}).get("fa") or t.get("xml_doc")))
            bases = t.get("base_types") or []
            if bases:
                lines.append("")
                lines.append("- **Base:** " + ", ".join(f"`{b}`" for b in bases[:8]))
            members = t.get("members") or []
            if members:
                lines.append("")
                lines.append(f"**اعضا ({len(members)}):**")
                lines.append("")
                for m in members:
                    mname = m.get("name") or "?"
                    mkind = m.get("kind") or "member"
                    sig = clean_sig(m.get("signature"))
                    if sig:
                        # escape backticks in sig lightly
                        sig_safe = sig.replace("`", "'")
                        lines.append(f"- `{mname}` ({mkind}): `{sig_safe}`")
                    else:
                        lines.append(f"- `{mname}` ({mkind})")
            else:
                lines.append("")
                lines.append("_اعضای عمومی استخراج‌شده ندارد._")
            lines.append("")

    return "\n".join(lines), documented_keys, documented


def patterns_section() -> str:
    chunks: list[str] = [
        "## Patterns — الگوهای صحیح استفاده",
        "",
        "قبل از نوشتن کد مبتنی بر زمین، Recipe مرتبط را بخوانید. "
        "الگوی ترکیب (composition) بر حدس زدن از روی امضا اولویت دارد.",
        "",
    ]
    for name, title in [
        ("dependency-injection.md", "Dependency Injection و bootstrap"),
        ("common-recipes.md", "Common recipes (CQRS، دامنه، Repository، Controller)"),
    ]:
        body = (PATTERNS / name).read_text(encoding="utf-8-sig")
        body = strip_external_links(body)
        body = re.sub(r"^# .*\n+", "", body, count=1)
        body = demote_headings(body, 1)
        chunks.append(f"### {title}")
        chunks.append("")
        chunks.append(body.strip())
        chunks.append("")

    unused = (PATTERNS / "unused-types.md").read_text(encoding="utf-8-sig")
    unused = strip_external_links(unused)
    unused = re.sub(r"^# .*\n+", "", unused, count=1)
    m = re.search(r"^## without_usage_sample by namespace\s*$", unused, re.M)
    list_body = unused[m.start() :] if m else unused
    chunks.append("### تایپ‌های بدون نمونه‌ی عملی استفاده")
    chunks.append("")
    chunks.append(
        "نمونه‌ی عملی استفاده در دسترس نیست؛ مستندات فقط بر پایه‌ی امضا و پیاده‌سازی خود زمین "
        "(بخش API Reference همین فایل) است. با احتیاط و بدون اختراع الگوی فراخوانی استفاده کنید."
    )
    chunks.append("")
    chunks.append(demote_headings(list_body.strip(), 1))
    chunks.append("")
    return "\n".join(chunks)


def verify_coverage(documented_count: int) -> list[str]:
    idx = load_json(INDEX)
    expected = idx["total_types"]
    notes = [
        f"- تایپ‌های استخراج‌شده از سورس زمین: **{expected}**",
        f"- تایپ‌های مستندشده در این فایل: **{documented_count}**",
    ]
    missing_ns = []
    mismatches = []
    for item in idx.get("namespaces") or []:
        ns = item["namespace"]
        ef = ENRICHED / f"{ns}.json"
        if not ef.exists():
            missing_ns.append(ns)
            continue
        got = len(load_json(ef).get("types") or [])
        want = item.get("type_count")
        if want is not None and got != want:
            mismatches.append(f"`{ns}` index={want} enriched={got}")
    if missing_ns:
        notes.append("- namespaceهای بدون enriched: " + ", ".join(f"`{n}`" for n in missing_ns))
    if mismatches:
        notes.append("- اختلاف شمارش: " + "; ".join(mismatches[:10]))
    if documented_count == expected and not missing_ns and not mismatches:
        notes.append("- پوشش: **کامل** (تعداد تایپ‌ها با استخراج خام برابر است).")
    elif documented_count < expected:
        notes.append(f"- پوشش ناقص: {expected - documented_count} تایپ کمتر از استخراج.")
    else:
        notes.append("- پوشش: تعداد مستند با استخراج هم‌خوان یا بیشتر است.")
    return notes


def build() -> None:
    OUT.parent.mkdir(parents=True, exist_ok=True)
    api_body, _keys, documented_count = build_api_reference()
    coverage_notes = verify_coverage(documented_count)

    parts: list[str] = [
        "---",
        "name: zamin",
        "description: >-",
        "  این اسکیل باید هر زمان که کاربر یا ایجنت قصد نوشتن، ویرایش یا بررسی کدی دارد که از فریمورک زمین (Zamin)",
        "  استفاده می‌کند یا می‌خواهد استفاده کند، فعال شود. شامل مرجع API فشرده، الگوهای صحیح استفاده (CQRS،",
        "  Domain، Repository، BaseController، DI/bootstrap) و فهرست تایپ‌های بدون نمونه‌ی عملی است.",
        "  Use whenever writing, reviewing, or wiring Zamin.* code—do not invent Zamin APIs from memory.",
        "---",
        "",
        "# Zamin — اسکیل تک‌فایلی",
        "",
        "## نحوه استفاده",
        "",
        "این فایل **خودکفا** است؛ به هیچ فایل جانبی نیاز ندارد. قبل از نوشتن یا تغییر هر کدی که با زمین سروکار دارد:",
        "",
        "1. در صورت نیاز، بخش **Overview** را برای معماری و مفاهیم پایه بخوانید.",
        "2. بخش **API Reference** مربوط به namespace/تایپ مورد نظر را پیدا کنید (جستجو روی `### Namespace:` یا نام تایپ).",
        "3. اگر در بخش **Patterns** برای همان موضوع Recipe وجود دارد، آن را بخوانید و **ترتیب فراخوانی و ترکیب** را از Recipe بگیرید؛ امضا را از API Reference.",
        "4. اگر تایپ در بخش **تایپ‌های بدون نمونه‌ی عملی استفاده** آمده است، فقط بر اساس API Reference عمل کنید و الگوی فراخوانی اختراع نکنید.",
        "",
        "### قوانین کوتاه",
        "",
        "- Handlerها را `new` نکنید؛ با `AddZaminApiCore` کشف می‌شوند.",
        "- `CommandHandler` / `QueryHandler` معمولاً `ZaminServices` می‌گیرند.",
        "- کنترلر نازک: ارث از `BaseController` و helperهای `Create` / `Edit` / `Delete` / `Query`.",
        "- اگر داده کافی نبود، حدس نزنید؛ صریحاً کمبود مستند را اعلام کنید.",
        "",
        "---",
        "",
        "## Overview",
        "",
        overview_section().strip(),
        "",
        "---",
        "",
        api_body.strip(),
        "",
        "---",
        "",
        patterns_section().strip(),
        "",
        "---",
        "",
        "## پوشش مستندات (verification)",
        "",
    ]
    parts.extend(coverage_notes)
    parts.append("")

    text = "\n".join(parts)
    # safety scrub
    text = re.sub(r"(?i)dej|دژ", "اپلیکیشن", text)
    text = text.replace("skills/zamin/", "")
    text = text.replace("framework-docs/enriched/", "enrichment ")
    text = text.replace("framework-docs/", "")

    OUT.write_text(text, encoding="utf-8")

    README.write_text(
        """# نصب اسکیل زمین (Zamin)

## چه چیزی لازم است؟

فقط **یک فایل**: [`zamin.skill.md`](zamin.skill.md)

هیچ فایل یا پوشه‌ی دیگری از این بسته برای کار کردن اسکیل لازم نیست.

## نصب

1. فایل `zamin.skill.md` را در پوشه‌ی skills پروژه‌ی مقصد کپی کنید.
   - در Cursor معمولاً محتوا را در `.cursor/skills/zamin/SKILL.md` قرار دهید
     (نام پوشه/فایل را مطابق قرارداد ابزار ایجنتی خود تنظیم کنید).
2. در ابزارهایی که اسکیل تک‌فایلی می‌پذیرند، کافی است همین فایل را به مسیر skills اضافه کنید.
3. کار دیگری لازم نیست: مرجع API، الگوهای استفاده، و فهرست تایپ‌های بدون نمونه، همه داخل همین فایل هستند.

## استفاده

هر زمان که قرار است کدی با فریمورک **زمین (Zamin)** نوشته، ویرایش یا بررسی شود، ایجنت باید این اسکیل را فعال کند؛ ابتدا بخش «نحوه استفاده»، سپس API Reference و Patterns مرتبط را بخواند.

## یادداشت

نسخه‌ی چندفایلی آرشیو (`skills/zamin/` و `framework-docs/`) در ریپوی منبع نگه داشته می‌شود؛ برای توزیع و نصب در پروژه‌ی جدید فقط `dist/zamin.skill.md` را کپی کنید.
""",
        encoding="utf-8",
    )

    lines = text.count("\n") + 1
    size_kb = OUT.stat().st_size / 1024
    print(f"Wrote {OUT}")
    print(f"lines={lines} size_kb={size_kb:.1f} types={documented_count}")
    for n in coverage_notes:
        print(n)


if __name__ == "__main__":
    build()
