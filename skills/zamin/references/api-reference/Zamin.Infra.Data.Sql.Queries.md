# Zamin.Infra.Data.Sql.Queries

مرجع API برای namespace `Zamin.Infra.Data.Sql.Queries`.

- **Type count (this file):** 3

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Infra.Data.Sql.Queries.BaseQueryDbContext`

- **Kind:** `class`
- **Base / interfaces:** `DbContext`
- **Source:** `Onion/src/3.Infra/Data/Zamin.Infra.Data.Sql.Queries/BaseQueryDbContext.cs`

کلاس «BaseQueryDbContext» در namespace Zamin.Infra.Data.Sql.Queries. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین. ارث‌بری/پیاده‌سازی: DbContext. وابستگی‌های سازنده (DI): DbContextOptions options. مرتبط: DbContext | DI: DbContextOptions options.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/common-recipes.md#recipe-query-repository)

#### Members

##### `.ctor` (constructor)

```csharp
public BaseQueryDbContext(DbContextOptions options)
```

سازنده BaseQueryDbContext. برای ایجاد نمونه با مقادیر اولیه‌ی مشخص. پارامترها:
- options (DbContextOptions): ورودی از نوع DbContextOptions.

##### `OnConfiguring` (method)

```csharp
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
```

متد «OnConfiguring» در BaseQueryDbContext. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- optionsBuilder (DbContextOptionsBuilder): ورودی از نوع DbContextOptionsBuilder.

مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: DbContext | DI: DbContextOptions options

##### `OnModelCreating` (method)

```csharp
protected override void OnModelCreating(ModelBuilder modelBuilder)
```

متد «OnModelCreating» در BaseQueryDbContext. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- modelBuilder (ModelBuilder): ورودی از نوع ModelBuilder.

مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: DbContext | DI: DbContextOptions options

##### `SaveChanges` (method)

```csharp
public override int SaveChanges()
```

متد «SaveChanges» در BaseQueryDbContext. وضعیت را به‌روز یا ذخیره می‌کند.
بدون پارامتر ورودی.
مقدار بازگشتی: `int`.
استثناها (قابل تشخیص از کد):
- NotSupportedException (throw new)
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: DbContext | DI: DbContextOptions options

##### `SaveChanges` (method)

```csharp
public override int SaveChanges(bool acceptAllChangesOnSuccess)
```

متد «SaveChanges» در BaseQueryDbContext. وضعیت را به‌روز یا ذخیره می‌کند.
پارامترها:
- acceptAllChangesOnSuccess (bool): ورودی از نوع bool.

مقدار بازگشتی: `int`.
استثناها (قابل تشخیص از کد):
- NotSupportedException (throw new)
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: DbContext | DI: DbContextOptions options

##### `SaveChangesAsync` (method)

```csharp
public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
```

متد «SaveChangesAsync» در BaseQueryDbContext. وضعیت را به‌روز یا ذخیره می‌کند.
پارامترها:
- acceptAllChangesOnSuccess (bool): ورودی از نوع bool.
- cancellationToken (CancellationToken): توکن لغو عملیات ناهمگام.

مقدار بازگشتی: `Task<int>` — نتیجه ناهمگام عملیات.
استثناها (قابل تشخیص از کد):
- NotSupportedException (throw new)
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: DbContext | DI: DbContextOptions options

##### `SaveChangesAsync` (method)

```csharp
public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
```

متد «SaveChangesAsync» در BaseQueryDbContext. وضعیت را به‌روز یا ذخیره می‌کند.
پارامترها:
- cancellationToken (CancellationToken): توکن لغو عملیات ناهمگام.

مقدار بازگشتی: `Task<int>` — نتیجه ناهمگام عملیات.
استثناها (قابل تشخیص از کد):
- NotSupportedException (throw new)
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: DbContext | DI: DbContextOptions options

### `Zamin.Infra.Data.Sql.Queries.BaseQueryRepository<TDbContext>`

- **Kind:** `class`
- **Base / interfaces:** `IQueryRepository`
- **Constraints:** `where TDbContext : BaseQueryDbContext`
- **Source:** `Onion/src/3.Infra/Data/Zamin.Infra.Data.Sql.Queries/BaseQueryRepository.cs`

کلاس «BaseQueryRepository<TDbContext>» در namespace Zamin.Infra.Data.Sql.Queries. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین. ارث‌بری/پیاده‌سازی: IQueryRepository. قیود جنریک: where TDbContext : BaseQueryDbContext. وابستگی‌های سازنده (DI): TDbContext dbContext. مرتبط: IQueryRepository | DI: TDbContext dbContext.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/common-recipes.md#recipe-query-repository)

#### Members

##### `_dbContext` (field)

```csharp
protected readonly TDbContext _dbContext;
```

فیلد «_dbContext» در BaseQueryRepository<TDbContext> با امضای `protected readonly TDbContext _dbContext;`. برای نگهداری وضعیت داخلی/قابل‌دسترس نوع استفاده می‌شود.

##### `.ctor` (constructor)

```csharp
public BaseQueryRepository(TDbContext dbContext)
```

سازنده BaseQueryRepository<TDbContext>. برای ایجاد نمونه با مقادیر اولیه‌ی مشخص. پارامترها:
- dbContext (TDbContext): ورودی از نوع TDbContext.
پیش‌شرط: وابستگی‌ها/مقادیر ورودی باید معتبر باشند تا فیلدهای داخلی به‌درستی مقداردهی شوند.

### `Zamin.Infra.Data.Sql.Queries.QueryRepositoryExtensions`

- **Kind:** `class`
- **Source:** `Onion/src/3.Infra/Data/Zamin.Infra.Data.Sql.Queries/QueryRepositoryExtensions.cs`

کلاس «QueryRepositoryExtensions» در namespace Zamin.Infra.Data.Sql.Queries. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/common-recipes.md#recipe-query-repository)

#### Members

##### `ToPagedData` (method)

```csharp
public static async Task<PagedData<TResult>> ToPagedData<TEntity, TQuery, TResult>(this IQueryable<TEntity> entities, PageQuery<PagedData<TQuery>> query, Func<TEntity, TResult> selectFunc)
```

متد «ToPagedData» در QueryRepositoryExtensions. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد. به‌صورت ناهمگام اجرا می‌شود.
پارامترها:
- entities (IQueryable<TEntity>): کوئری ورودی برای اجرا.
- query (PageQuery<PagedData<TQuery>>): کوئری ورودی برای اجرا.
- selectFunc (Func<TEntity, TResult>): ورودی از نوع Func<TEntity, TResult>.

مقدار بازگشتی: `Task<PagedData<TResult>>` — نتیجه ناهمگام عملیات.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
