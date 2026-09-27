# Zamin.Infra.Data.Sql.Commands (Part 4/4)

مرجع API برای namespace `Zamin.Infra.Data.Sql.Commands`.

- **Type count (this file):** 1
- **Parts:** [Part 1](./Zamin.Infra.Data.Sql.Commands.Part1.md) · [Part 2](./Zamin.Infra.Data.Sql.Commands.Part2.md) · [Part 3](./Zamin.Infra.Data.Sql.Commands.Part3.md) · **Part 4**

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Infra.Data.Sql.Commands.BaseEntityFrameworkUnitOfWork<TDbContext>`

- **Kind:** `class`
- **Base / interfaces:** `IUnitOfWork`
- **Constraints:** `where TDbContext : BaseCommandDbContext`
- **Source:** `Onion/src/3.Infra/Data/Zamin.Infra.Data.Sql.Commands/BaseEntityFrameworkUnitOfWork.cs`

کلاس «BaseEntityFrameworkUnitOfWork<TDbContext>» در namespace Zamin.Infra.Data.Sql.Commands. موجودیت دامنه با هویت و قابلیت auditable. ارث‌بری/پیاده‌سازی: IUnitOfWork. قیود جنریک: where TDbContext : BaseCommandDbContext. وابستگی‌های سازنده (DI): TDbContext dbContext. مرتبط: IUnitOfWork | DI: TDbContext dbContext.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/common-recipes.md#recipe-command-repository)

#### Members

##### `_dbContext` (field)

```csharp
protected readonly TDbContext _dbContext;
```

فیلد «_dbContext» در BaseEntityFrameworkUnitOfWork<TDbContext> با امضای `protected readonly TDbContext _dbContext;`. برای نگهداری وضعیت داخلی/قابل‌دسترس نوع استفاده می‌شود.

##### `.ctor` (constructor)

```csharp
public BaseEntityFrameworkUnitOfWork(TDbContext dbContext)
```

سازنده BaseEntityFrameworkUnitOfWork<TDbContext>. برای ایجاد نمونه با مقادیر اولیه‌ی مشخص. پارامترها:
- dbContext (TDbContext): ورودی از نوع TDbContext.
پیش‌شرط: وابستگی‌ها/مقادیر ورودی باید معتبر باشند تا فیلدهای داخلی به‌درستی مقداردهی شوند.

##### `BeginTransaction` (method)

```csharp
public void BeginTransaction()
```

متد «BeginTransaction» در BaseEntityFrameworkUnitOfWork<TDbContext>. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
بدون پارامتر ورودی.
مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: IUnitOfWork | DI: TDbContext dbContext

##### `Commit` (method)

```csharp
public int Commit()
```

متد «Commit» در BaseEntityFrameworkUnitOfWork<TDbContext>. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
بدون پارامتر ورودی.
مقدار بازگشتی: `int`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: IUnitOfWork | DI: TDbContext dbContext

##### `CommitAsync` (method)

```csharp
public async Task<int> CommitAsync()
```

متد «CommitAsync» در BaseEntityFrameworkUnitOfWork<TDbContext>. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد. به‌صورت ناهمگام اجرا می‌شود.
بدون پارامتر ورودی.
مقدار بازگشتی: `Task<int>` — نتیجه ناهمگام عملیات.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: IUnitOfWork | DI: TDbContext dbContext

##### `CommitTransaction` (method)

```csharp
public void CommitTransaction()
```

متد «CommitTransaction» در BaseEntityFrameworkUnitOfWork<TDbContext>. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
بدون پارامتر ورودی.
مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: IUnitOfWork | DI: TDbContext dbContext

##### `RollbackTransaction` (method)

```csharp
public void RollbackTransaction()
```

متد «RollbackTransaction» در BaseEntityFrameworkUnitOfWork<TDbContext>. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
بدون پارامتر ورودی.
مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: IUnitOfWork | DI: TDbContext dbContext
