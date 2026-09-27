#!/usr/bin/env python3
import re
from pathlib import Path

ROOT = Path(__file__).resolve().parents[1]
ROOTS = [ROOT / "framework-docs", ROOT / "skills" / "zamin"]

QUERY_SNIPPET = """```csharp
// SampleGetPagedFilterQueryHandler.cs
public sealed class SampleGetPagedFilterQueryHandler(
    ZaminServices zaminServices,
    ISampleQueryRepository queryRepository)
    : QueryHandler<SampleGetPagedFilterQuery, PagedData<SampleListItemDto>>(zaminServices)
{
    public override async Task<QueryResult<PagedData<SampleListItemDto>>> Handle(SampleGetPagedFilterQuery query)
    {
        var queryResult = await queryRepository.ExecuteAsync(query);
        return Result(queryResult);
    }
}
```"""

FILE_STORAGE_BLOCK = re.compile(
    r"```csharp\n(?://[^\n]*\n)?public sealed class SampleGetPagedFilterQueryHandler\(ZaminServices zaminServices,\s*\n"
    r"\s*ISampleQueryRepository queryRepository,\s*\n"
    r"\s*IFileStorageService fileStorageService\)\s*\n"
    r"\s*: QueryHandler<SampleGetPagedFilterQuery, PagedData<SampleListItemDto>>\(zaminServices\)\s*\n"
    r"\{.*?\n\}\s*\n```",
    re.S,
)

REPLACEMENTS = [
    (r"ProjectTranslation\.VALIDATION_ERROR_MODIFY_PRIMARY", '"Cannot modify primary sample"'),
    (r"ProjectTranslation\.VALIDATION_ERROR_NOT_VALID", '"Value is not valid"'),
    (r"ProjectTranslation\.VALIDATION_ERROR_USER_DATA_NOT_EXIST", '"User data not found"'),
    (r"ProjectTranslation\.USER_ID", '"UserId"'),
    (r"ProjectTranslation", "AppMessages"),
    (r'"WebUserInfo"', '"UserInfo"'),
    (r"AddWorkerUserInfoService", "AddAppWorkerUserInfoService"),
    (r"MyApp contracts mark", "Application contracts mark"),
    (r"MyApp contracts inherit", "Application contracts inherit"),
    (r"MyApp query contracts inherit", "Application query contracts inherit"),
    (r"MyApp code typically", "Application code typically"),
    (r"MyApp project translations", "Application translations"),
    (r"MyApp domain/API also define", "Application domain/API may also define"),
    (r"MyApp/Zamin user-info", "application/Zamin user-info"),
    (r"MyApp wrapper over Zamin", "application wrapper over Zamin"),
    (r"No public type name hits required for usage — MyApp calls:", "No public type name hits required for usage — the host calls:"),
    (r"alongside MyApp rate limiter", "alongside the application rate limiter"),
    (r"SecondaryHost `UserController", "`UserController"),
    (r"SecondaryHost and WorkerService", "secondary API host and WorkerService"),
]


def main() -> None:
    for root in ROOTS:
        for path in root.rglob("*.md"):
            text = path.read_text(encoding="utf-8-sig")
            out = FILE_STORAGE_BLOCK.sub(QUERY_SNIPPET, text)
            for old, new in REPLACEMENTS:
                out = re.sub(old, new, out)
            if out != text:
                path.write_text(out, encoding="utf-8")

    pat = re.compile(r"dej|دژ", re.I)
    for root in ROOTS:
        total = 0
        for path in root.rglob("*"):
            if not path.is_file() or path.suffix.lower() not in {".md", ".json", ".txt"}:
                continue
            total += len(pat.findall(path.read_text(encoding="utf-8-sig")))
        print(f"{root}: remaining={total}")

    for needle in ("IFileStorageService", "ProjectTranslation", "dej", "دژ"):
        count = 0
        for root in ROOTS:
            for path in root.rglob("*.md"):
                count += path.read_text(encoding="utf-8-sig").count(needle)
        print(f"{needle}: {count}")


if __name__ == "__main__":
    main()
