# Zamin.Core.RequestResponse.Queries (Part 2/2)

مرجع API برای namespace `Zamin.Core.RequestResponse.Queries`.

- **Type count (this file):** 1
- **Parts:** [Part 1](./Zamin.Core.RequestResponse.Queries.Part1.md) · **Part 2**

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Core.RequestResponse.Queries.QueryResult<TData>`

- **Kind:** `class`
- **Base / interfaces:** `ApplicationServiceResult`
- **Source:** `Onion/src/2.Core/Zamin.Core.RequestResponse/Queries/QueryResult.cs`

نتیجه یک کوئری را بازگشت می‌دهد

- **Recipe:** [الگوی استفاده مرتبط](../patterns/common-recipes.md#recipe-query-contracts)

#### Members

##### `_data` (field)

```csharp
public TData? _data;
```

فیلد «_data» در QueryResult<TData> با امضای `public TData? _data;`. برای نگهداری وضعیت داخلی/قابل‌دسترس نوع استفاده می‌شود.

##### `Data` (property)

```csharp
public TData? Data { get; }
```

پراپرتی «Data» از نوع `TData?` در QueryResult<TData>. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. فقط‌خواندنی است. منطق دسترسی از روی بدنه accessor قابل مشاهده است.
