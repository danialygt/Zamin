# Zamin.Infra.Data.Sql.Commands (Part 2/4)

مرجع API برای namespace `Zamin.Infra.Data.Sql.Commands`.

- **Type count (this file):** 1
- **Parts:** [Part 1](./Zamin.Infra.Data.Sql.Commands.Part1.md) · **Part 2** · [Part 3](./Zamin.Infra.Data.Sql.Commands.Part3.md) · [Part 4](./Zamin.Infra.Data.Sql.Commands.Part4.md)

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Infra.Data.Sql.Commands.BaseCommandRepository<TEntity, TDbContext, TId>` — اعضای بخش 1/2

- **Kind:** `class`
- **Base / interfaces:** `ICommandRepository<TEntity, TId>`, `IUnitOfWork`
- **Constraints:** `where TEntity : AggregateRoot<TId> where TDbContext : BaseCommandDbContext where TId : struct,           IComparable,           IComparable<TId>,           IConvertible,           IEquatable<TId>,           IFormattable`
- **Source:** `Onion/src/3.Infra/Data/Zamin.Infra.Data.Sql.Commands/BaseCommandRepository.cs`

کلاس «BaseCommandRepository<TEntity, TDbContext, TId>» در namespace Zamin.Infra.Data.Sql.Commands. موجودیت دامنه با هویت و قابلیت auditable. ارث‌بری/پیاده‌سازی: ICommandRepository<TEntity, TId>, IUnitOfWork. قیود جنریک: where TEntity : AggregateRoot<TId> where TDbContext : BaseCommandDbContext where TId : struct, IComparable, IComparable<TId>, IConvertible, IEquatable<TId>, IFormattable. وابستگی‌های سازنده (DI): TDbContext dbContext. مرتبط: ICommandRepository<TEntity, TId> | IUnitOfWork | DI: TDbContext dbContext.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/common-recipes.md#recipe-command-repository)

#### Members

##### `_dbContext` (field)

```csharp
protected readonly TDbContext _dbContext;
```

فیلد «_dbContext» در BaseCommandRepository<TEntity, TDbContext, TId> با امضای `protected readonly TDbContext _dbContext;`. برای نگهداری وضعیت داخلی/قابل‌دسترس نوع استفاده می‌شود.

##### `.ctor` (constructor)

```csharp
public BaseCommandRepository(TDbContext dbContext)
```

سازنده BaseCommandRepository<TEntity, TDbContext, TId>. برای ایجاد نمونه با مقادیر اولیه‌ی مشخص. پارامترها:
- dbContext (TDbContext): ورودی از نوع TDbContext.
پیش‌شرط: وابستگی‌ها/مقادیر ورودی باید معتبر باشند تا فیلدهای داخلی به‌درستی مقداردهی شوند.

##### `Delete` (method)

```csharp
public void Delete(TId id)
```

متد «Delete» در BaseCommandRepository<TEntity, TDbContext, TId>. مورد یا وضعیت را حذف/پاک می‌کند.
پارامترها:
- id (TId): ورودی از نوع TId.

مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: ICommandRepository<TEntity, TId> | IUnitOfWork | DI: TDbContext dbContext

##### `Delete` (method)

```csharp
public void Delete(TEntity entity)
```

متد «Delete» در BaseCommandRepository<TEntity, TDbContext, TId>. مورد یا وضعیت را حذف/پاک می‌کند.
پارامترها:
- entity (TEntity): ورودی از نوع TEntity.

مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: ICommandRepository<TEntity, TId> | IUnitOfWork | DI: TDbContext dbContext

##### `DeleteGraph` (method)

```csharp
public void DeleteGraph(TId id)
```

متد «DeleteGraph» در BaseCommandRepository<TEntity, TDbContext, TId>. مورد یا وضعیت را حذف/پاک می‌کند.
پارامترها:
- id (TId): ورودی از نوع TId.

مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: ICommandRepository<TEntity, TId> | IUnitOfWork | DI: TDbContext dbContext

##### `Insert` (method)

```csharp
public void Insert(TEntity entity)
```

متد «Insert» در BaseCommandRepository<TEntity, TDbContext, TId>. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- entity (TEntity): ورودی از نوع TEntity.

مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: ICommandRepository<TEntity, TId> | IUnitOfWork | DI: TDbContext dbContext

##### `InsertAsync` (method)

```csharp
public async Task InsertAsync(TEntity entity)
```

متد «InsertAsync» در BaseCommandRepository<TEntity, TDbContext, TId>. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد. به‌صورت ناهمگام اجرا می‌شود.
پارامترها:
- entity (TEntity): ورودی از نوع TEntity.

مقدار بازگشتی: `Task` — عملیات ناهمگام بدون نتیجه داده‌ای.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: ICommandRepository<TEntity, TId> | IUnitOfWork | DI: TDbContext dbContext

##### `Get` (method)

```csharp
public TEntity Get(TId id)
```

متد «Get» در BaseCommandRepository<TEntity, TDbContext, TId>. داده یا وضعیت مرتبط را بازیابی می‌کند.
پارامترها:
- id (TId): ورودی از نوع TId.

مقدار بازگشتی: `TEntity`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: ICommandRepository<TEntity, TId> | IUnitOfWork | DI: TDbContext dbContext

##### `Get` (method)

```csharp
public TEntity Get(BusinessId businessId)
```

متد «Get» در BaseCommandRepository<TEntity, TDbContext, TId>. داده یا وضعیت مرتبط را بازیابی می‌کند.
پارامترها:
- businessId (BusinessId): ورودی از نوع BusinessId.

مقدار بازگشتی: `TEntity`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: ICommandRepository<TEntity, TId> | IUnitOfWork | DI: TDbContext dbContext

##### `GetAsync` (method)

```csharp
public async Task<TEntity> GetAsync(TId id)
```

متد «GetAsync» در BaseCommandRepository<TEntity, TDbContext, TId>. داده یا وضعیت مرتبط را بازیابی می‌کند. به‌صورت ناهمگام اجرا می‌شود.
پارامترها:
- id (TId): ورودی از نوع TId.

مقدار بازگشتی: `Task<TEntity>` — نتیجه ناهمگام عملیات.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: ICommandRepository<TEntity, TId> | IUnitOfWork | DI: TDbContext dbContext

##### `GetAsync` (method)

```csharp
public async Task<TEntity> GetAsync(BusinessId businessId)
```

متد «GetAsync» در BaseCommandRepository<TEntity, TDbContext, TId>. داده یا وضعیت مرتبط را بازیابی می‌کند. به‌صورت ناهمگام اجرا می‌شود.
پارامترها:
- businessId (BusinessId): ورودی از نوع BusinessId.

مقدار بازگشتی: `Task<TEntity>` — نتیجه ناهمگام عملیات.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: ICommandRepository<TEntity, TId> | IUnitOfWork | DI: TDbContext dbContext
