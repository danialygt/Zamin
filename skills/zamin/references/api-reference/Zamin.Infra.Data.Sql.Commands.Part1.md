# Zamin.Infra.Data.Sql.Commands (Part 1/4)

مرجع API برای namespace `Zamin.Infra.Data.Sql.Commands`.

- **Type count (this file):** 1
- **Parts:** **Part 1** · [Part 2](./Zamin.Infra.Data.Sql.Commands.Part2.md) · [Part 3](./Zamin.Infra.Data.Sql.Commands.Part3.md) · [Part 4](./Zamin.Infra.Data.Sql.Commands.Part4.md)

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Infra.Data.Sql.Commands.BaseCommandDbContext`

- **Kind:** `class`
- **Base / interfaces:** `DbContext`
- **Source:** `Onion/src/3.Infra/Data/Zamin.Infra.Data.Sql.Commands/BaseCommandDbContext.cs`

کلاس «BaseCommandDbContext» در namespace Zamin.Infra.Data.Sql.Commands. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین. ارث‌بری/پیاده‌سازی: DbContext. وابستگی‌های سازنده (DI): DbContextOptions options. مرتبط: DbContext | DI: DbContextOptions options.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/common-recipes.md#recipe-command-repository)

#### Members

##### `_transaction` (field)

```csharp
protected IDbContextTransaction _transaction;
```

فیلد «_transaction» در BaseCommandDbContext با امضای `protected IDbContextTransaction _transaction;`. برای نگهداری وضعیت داخلی/قابل‌دسترس نوع استفاده می‌شود.

##### `.ctor` (constructor)

```csharp
public BaseCommandDbContext(DbContextOptions options)
```

سازنده BaseCommandDbContext. برای ایجاد نمونه با مقادیر اولیه‌ی مشخص. پارامترها:
- options (DbContextOptions): ورودی از نوع DbContextOptions.

##### `.ctor` (constructor)

```csharp
protected BaseCommandDbContext()
```

سازنده BaseCommandDbContext. بدون پارامتر؛ معمولاً برای ORM، serialization یا مقداردهی اولیه محافظت‌شده استفاده می‌شود.

##### `BeginTransaction` (method)

```csharp
public void BeginTransaction()
```

متد «BeginTransaction» در BaseCommandDbContext. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
بدون پارامتر ورودی.
مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: DbContext | DI: DbContextOptions options

##### `RollbackTransaction` (method)

```csharp
public void RollbackTransaction()
```

متد «RollbackTransaction» در BaseCommandDbContext. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
بدون پارامتر ورودی.
مقدار بازگشتی: ندارد (void).
استثناها (قابل تشخیص از کد):
- NullReferenceException (throw new)
- NullReferenceException
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: DbContext | DI: DbContextOptions options

##### `CommitTransaction` (method)

```csharp
public void CommitTransaction()
```

متد «CommitTransaction» در BaseCommandDbContext. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
بدون پارامتر ورودی.
مقدار بازگشتی: ندارد (void).
استثناها (قابل تشخیص از کد):
- NullReferenceException (throw new)
- NullReferenceException
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: DbContext | DI: DbContextOptions options

##### `GetShadowPropertyValue` (method)

```csharp
public T GetShadowPropertyValue<T>(object entity, string propertyName) where T : IConvertible
```

متد «GetShadowPropertyValue» در BaseCommandDbContext. داده یا وضعیت مرتبط را بازیابی می‌کند.
پارامترها:
- entity (object): ورودی از نوع object.
- propertyName (string): ورودی از نوع string.

مقدار بازگشتی: `T`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: DbContext | DI: DbContextOptions options

##### `GetShadowPropertyValue` (method)

```csharp
public object GetShadowPropertyValue(object entity, string propertyName)
```

متد «GetShadowPropertyValue» در BaseCommandDbContext. داده یا وضعیت مرتبط را بازیابی می‌کند.
پارامترها:
- entity (object): ورودی از نوع object.
- propertyName (string): ورودی از نوع string.

مقدار بازگشتی: `object`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: DbContext | DI: DbContextOptions options

##### `OnModelCreating` (method)

```csharp
protected override void OnModelCreating(ModelBuilder builder)
```

متد «OnModelCreating» در BaseCommandDbContext. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- builder (ModelBuilder): ورودی از نوع ModelBuilder.

مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: DbContext | DI: DbContextOptions options

##### `ConfigureConventions` (method)

```csharp
protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
```

متد «ConfigureConventions» در BaseCommandDbContext. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- configurationBuilder (ModelConfigurationBuilder): ورودی از نوع ModelConfigurationBuilder.

مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: DbContext | DI: DbContextOptions options

##### `GetIncludePaths` (method)

```csharp
public IEnumerable<string> GetIncludePaths(Type clrEntityType)
```

متد «GetIncludePaths» در BaseCommandDbContext. داده یا وضعیت مرتبط را بازیابی می‌کند.
پارامترها:
- clrEntityType (Type): ورودی از نوع Type.

مقدار بازگشتی: `IEnumerable<string>`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: DbContext | DI: DbContextOptions options
