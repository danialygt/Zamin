# Zamin.Extensions.Events.Outbox.Dal.EF

مرجع API برای namespace `Zamin.Extensions.Events.Outbox.Dal.EF`.

- **Type count (this file):** 1

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Extensions.Events.Outbox.Dal.EF.BaseOutboxCommandDbContext`

- **Kind:** `class`
- **Base / interfaces:** `BaseCommandDbContext`
- **Source:** `Extentsions/Events/Zamin.Extensions.Events.Outbox/Zamin.Extensions.Events.Outbox.Dal.EF/BaseOutboxCommandDbContext.cs`

کلاس «BaseOutboxCommandDbContext» در namespace Zamin.Extensions.Events.Outbox.Dal.EF. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین. ارث‌بری/پیاده‌سازی: BaseCommandDbContext. وابستگی‌های سازنده (DI): DbContextOptions options. مرتبط: BaseCommandDbContext | DI: DbContextOptions options.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/common-recipes.md#recipe-outbox-dbcontext)

#### Members

##### `OutBoxEventItems` (property)

```csharp
public DbSet<OutBoxEventItem> OutBoxEventItems { get; set; }
```

پراپرتی «OutBoxEventItems» از نوع `DbSet<OutBoxEventItem>` در BaseOutboxCommandDbContext. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `.ctor` (constructor)

```csharp
public BaseOutboxCommandDbContext(DbContextOptions options)
```

سازنده BaseOutboxCommandDbContext. برای ایجاد نمونه با مقادیر اولیه‌ی مشخص. پارامترها:
- options (DbContextOptions): ورودی از نوع DbContextOptions.

##### `.ctor` (constructor)

```csharp
protected BaseOutboxCommandDbContext()
```

سازنده BaseOutboxCommandDbContext. بدون پارامتر؛ معمولاً برای ORM، serialization یا مقداردهی اولیه محافظت‌شده استفاده می‌شود.

##### `OnConfiguring` (method)

```csharp
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
```

متد «OnConfiguring» در BaseOutboxCommandDbContext. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- optionsBuilder (DbContextOptionsBuilder): ورودی از نوع DbContextOptionsBuilder.

مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: BaseCommandDbContext | DI: DbContextOptions options

##### `OnModelCreating` (method)

```csharp
protected override void OnModelCreating(ModelBuilder builder)
```

متد «OnModelCreating» در BaseOutboxCommandDbContext. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- builder (ModelBuilder): ورودی از نوع ModelBuilder.

مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: BaseCommandDbContext | DI: DbContextOptions options
