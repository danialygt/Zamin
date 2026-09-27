#!/usr/bin/env python3
import re
from pathlib import Path

p = Path("dist/zamin.skill.md")
t = p.read_text(encoding="utf-8")
report = []
report.append(f"bytes={p.stat().st_size}")
report.append(f"lines={t.count(chr(10)) + 1}")
report.append(f"namespaces={len(re.findall(r'^### Namespace:', t, re.M))}")
report.append(f"types={len(re.findall(r'^#### `', t, re.M))}")
report.append(f"frontmatter={t.startswith('---')}")
report.append(f"has_how_to={'## نحوه استفاده' in t}")
report.append(f"has_overview={'## Overview' in t}")
report.append(f"has_api={'## API Reference' in t}")
report.append(f"has_patterns={'## Patterns' in t}")
report.append(f"has_unused={'تایپ‌های بدون نمونه‌ی عملی' in t}")
report.append(f"has_verify={'## پوشش مستندات' in t}")
report.append(f"dej_hits={len(re.findall(r'dej|دژ', t, flags=re.I))}")
smells = []
for pat in [
    r"skills/zamin",
    r"framework-docs/",
    r"\]\(api-reference/",
    r"\]\(patterns/",
    r"\]\(\.\./",
    r"references/",
]:
    n = len(re.findall(pat, t))
    if n:
        smells.append(f"{pat}={n}")
report.append("smells=" + (",".join(smells) if smells else "none"))
report.append(f"sample_handler={'SampleCreateHandler' in t}")
report.append(f"add_zamin_api={'AddZaminApiCore' in t}")
report.append(f"readme={Path('dist/README.md').exists()}")
for line in t.splitlines():
    if "تایپ‌های استخراج" in line or "تایپ‌های مستندشده" in line or "پوشش:" in line:
        report.append(line)
Path("dist/_verify.txt").write_text("\n".join(report) + "\n", encoding="utf-8")
print("\n".join(report))
