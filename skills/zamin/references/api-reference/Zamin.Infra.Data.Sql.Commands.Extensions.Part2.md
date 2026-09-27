# Zamin.Infra.Data.Sql.Commands.Extensions (Part 2/2)

مرجع API برای namespace `Zamin.Infra.Data.Sql.Commands.Extensions`.

- **Type count (this file):** 1
- **Parts:** [Part 1](./Zamin.Infra.Data.Sql.Commands.Extensions.Part1.md) · **Part 2**

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Infra.Data.Sql.Commands.Extensions.RowVersionShadowProperty`

- **Kind:** `class`
- **Source:** `Onion/src/3.Infra/Data/Zamin.Infra.Data.Sql.Commands/Extensions/RowVersionShadowProperty.cs`

کلاس «RowVersionShadowProperty» در namespace Zamin.Infra.Data.Sql.Commands.Extensions. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین.

#### Members

##### `RowVersion` (field)

```csharp
public static readonly string RowVersion = nameof(RowVersion);
```

فیلد «RowVersion» در RowVersionShadowProperty با امضای `public static readonly string RowVersion = nameof(RowVersion);`. برای نگهداری وضعیت داخلی/قابل‌دسترس نوع استفاده می‌شود.

##### `AddRowVersionShadowProperty` (method)

```csharp
public static void AddRowVersionShadowProperty<TEntity>(this EntityTypeBuilder<TEntity> builder) where TEntity : class
```

متد «AddRowVersionShadowProperty» در RowVersionShadowProperty. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- builder (EntityTypeBuilder<TEntity>): ورودی از نوع EntityTypeBuilder<TEntity>.

مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
