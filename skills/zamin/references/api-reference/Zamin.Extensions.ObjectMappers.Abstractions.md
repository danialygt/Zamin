# Zamin.Extensions.ObjectMappers.Abstractions

مرجع API برای namespace `Zamin.Extensions.ObjectMappers.Abstractions`.

- **Type count (this file):** 1

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Extensions.ObjectMappers.Abstractions.IMapperAdapter`

- **Kind:** `interface`
- **Source:** `Extentsions/Zamin.Extensions.Abstractions/Zamin.Extensions.ObjectMappers.Abstractions/IMapperAdapter.cs`

قرارداد (اینترفیس) «IMapperAdapter» در namespace Zamin.Extensions.ObjectMappers.Abstractions. قرارداد رفتار برای مصرف‌کنندگان و پیاده‌سازی‌های جایگزین.

#### Members

##### `Map` (method)

```csharp
TDestination Map<TSource, TDestination>(TSource source)
```

متد «Map» در IMapperAdapter. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- source (TSource): ورودی از نوع TSource.

مقدار بازگشتی: `TDestination`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
