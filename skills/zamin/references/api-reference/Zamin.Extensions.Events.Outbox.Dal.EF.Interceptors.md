# Zamin.Extensions.Events.Outbox.Dal.EF.Interceptors

مرجع API برای namespace `Zamin.Extensions.Events.Outbox.Dal.EF.Interceptors`.

- **Type count (this file):** 1

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Extensions.Events.Outbox.Dal.EF.Interceptors.AddOutBoxEventItemInterceptor`

- **Kind:** `class`
- **Base / interfaces:** `SaveChangesInterceptor`
- **Source:** `Extentsions/Events/Zamin.Extensions.Events.Outbox/Zamin.Extensions.Events.Outbox.Dal.EF/Interceptors/AddOutBoxEventItemInterceptor.cs`

کلاس «AddOutBoxEventItemInterceptor» در namespace Zamin.Extensions.Events.Outbox.Dal.EF.Interceptors. رهگیر EF/زیرساخت برای اعمال منطق هنگام ذخیره یا تغییر داده. ارث‌بری/پیاده‌سازی: SaveChangesInterceptor. مرتبط: SaveChangesInterceptor.

#### Members

##### `SavingChanges` (method)

```csharp
public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
```

متد «SavingChanges» در AddOutBoxEventItemInterceptor. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- eventData (DbContextEventData): رویداد دامنه/پیام برای پردازش.
- result (InterceptionResult<int>): ورودی از نوع InterceptionResult<int>.

مقدار بازگشتی: `InterceptionResult<int>`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
انواع مرتبط: SaveChangesInterceptor

##### `SavingChangesAsync` (method)

```csharp
public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
```

متد «SavingChangesAsync» در AddOutBoxEventItemInterceptor. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- eventData (DbContextEventData): رویداد دامنه/پیام برای پردازش.
- result (InterceptionResult<int>): ورودی از نوع InterceptionResult<int>.
- cancellationToken (CancellationToken): توکن لغو عملیات ناهمگام.

مقدار بازگشتی: `ValueTask<InterceptionResult<int>>` — نتیجه ناهمگام عملیات.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
انواع مرتبط: SaveChangesInterceptor
