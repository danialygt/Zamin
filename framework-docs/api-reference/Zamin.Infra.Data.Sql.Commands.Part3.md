# Zamin.Infra.Data.Sql.Commands (Part 3/4)

مرجع API برای namespace `Zamin.Infra.Data.Sql.Commands`.

- **Type count (this file):** 2
- **Parts:** [Part 1](./Zamin.Infra.Data.Sql.Commands.Part1.md) · [Part 2](./Zamin.Infra.Data.Sql.Commands.Part2.md) · **Part 3** · [Part 4](./Zamin.Infra.Data.Sql.Commands.Part4.md)

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Infra.Data.Sql.Commands.BaseCommandRepository<TEntity, TDbContext, TId>` — اعضای بخش 2/2

- **Kind:** `class`
- **Base / interfaces:** `ICommandRepository<TEntity, TId>`, `IUnitOfWork`
- **Constraints:** `where TEntity : AggregateRoot<TId> where TDbContext : BaseCommandDbContext where TId : struct,           IComparable,           IComparable<TId>,           IConvertible,           IEquatable<TId>,           IFormattable`
- **Source:** `Onion/src/3.Infra/Data/Zamin.Infra.Data.Sql.Commands/BaseCommandRepository.cs`

کلاس «BaseCommandRepository<TEntity, TDbContext, TId>» در namespace Zamin.Infra.Data.Sql.Commands. موجودیت دامنه با هویت و قابلیت auditable. ارث‌بری/پیاده‌سازی: ICommandRepository<TEntity, TId>, IUnitOfWork. قیود جنریک: where TEntity : AggregateRoot<TId> where TDbContext : BaseCommandDbContext where TId : struct, IComparable, IComparable<TId>, IConvertible, IEquatable<TId>, IFormattable. وابستگی‌های سازنده (DI): TDbContext dbContext. مرتبط: ICommandRepository<TEntity, TId> | IUnitOfWork | DI: TDbContext dbContext.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/common-recipes.md#recipe-command-repository)

#### Members

##### `GetGraph` (method)

```csharp
public TEntity GetGraph(TId id)
```

متد «GetGraph» در BaseCommandRepository<TEntity, TDbContext, TId>. داده یا وضعیت مرتبط را بازیابی می‌کند.
پارامترها:
- id (TId): ورودی از نوع TId.

مقدار بازگشتی: `TEntity`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: ICommandRepository<TEntity, TId> | IUnitOfWork | DI: TDbContext dbContext

##### `GetGraph` (method)

```csharp
public TEntity GetGraph(BusinessId businessId)
```

متد «GetGraph» در BaseCommandRepository<TEntity, TDbContext, TId>. داده یا وضعیت مرتبط را بازیابی می‌کند.
پارامترها:
- businessId (BusinessId): ورودی از نوع BusinessId.

مقدار بازگشتی: `TEntity`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: ICommandRepository<TEntity, TId> | IUnitOfWork | DI: TDbContext dbContext

##### `GetGraphAsync` (method)

```csharp
public async Task<TEntity> GetGraphAsync(TId id)
```

متد «GetGraphAsync» در BaseCommandRepository<TEntity, TDbContext, TId>. داده یا وضعیت مرتبط را بازیابی می‌کند. به‌صورت ناهمگام اجرا می‌شود.
پارامترها:
- id (TId): ورودی از نوع TId.

مقدار بازگشتی: `Task<TEntity>` — نتیجه ناهمگام عملیات.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: ICommandRepository<TEntity, TId> | IUnitOfWork | DI: TDbContext dbContext

##### `GetGraphAsync` (method)

```csharp
public async Task<TEntity> GetGraphAsync(BusinessId businessId)
```

متد «GetGraphAsync» در BaseCommandRepository<TEntity, TDbContext, TId>. داده یا وضعیت مرتبط را بازیابی می‌کند. به‌صورت ناهمگام اجرا می‌شود.
پارامترها:
- businessId (BusinessId): ورودی از نوع BusinessId.

مقدار بازگشتی: `Task<TEntity>` — نتیجه ناهمگام عملیات.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: ICommandRepository<TEntity, TId> | IUnitOfWork | DI: TDbContext dbContext

##### `Exists` (method)

```csharp
public bool Exists(Expression<Func<TEntity, bool>> expression)
```

متد «Exists» در BaseCommandRepository<TEntity, TDbContext, TId>. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- expression (Expression<Func<TEntity, bool>>): ورودی از نوع Expression<Func<TEntity, bool>>.

مقدار بازگشتی: `bool`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: ICommandRepository<TEntity, TId> | IUnitOfWork | DI: TDbContext dbContext

##### `ExistsAsync` (method)

```csharp
public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression)
```

متد «ExistsAsync» در BaseCommandRepository<TEntity, TDbContext, TId>. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد. به‌صورت ناهمگام اجرا می‌شود.
پارامترها:
- expression (Expression<Func<TEntity, bool>>): ورودی از نوع Expression<Func<TEntity, bool>>.

مقدار بازگشتی: `Task<bool>` — نتیجه ناهمگام عملیات.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: ICommandRepository<TEntity, TId> | IUnitOfWork | DI: TDbContext dbContext

##### `Commit` (method)

```csharp
public int Commit()
```

متد «Commit» در BaseCommandRepository<TEntity, TDbContext, TId>. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
بدون پارامتر ورودی.
مقدار بازگشتی: `int`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: ICommandRepository<TEntity, TId> | IUnitOfWork | DI: TDbContext dbContext

##### `CommitAsync` (method)

```csharp
public Task<int> CommitAsync()
```

متد «CommitAsync» در BaseCommandRepository<TEntity, TDbContext, TId>. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
بدون پارامتر ورودی.
مقدار بازگشتی: `Task<int>` — نتیجه ناهمگام عملیات.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: ICommandRepository<TEntity, TId> | IUnitOfWork | DI: TDbContext dbContext

##### `BeginTransaction` (method)

```csharp
public void BeginTransaction()
```

متد «BeginTransaction» در BaseCommandRepository<TEntity, TDbContext, TId>. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
بدون پارامتر ورودی.
مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: ICommandRepository<TEntity, TId> | IUnitOfWork | DI: TDbContext dbContext

##### `CommitTransaction` (method)

```csharp
public void CommitTransaction()
```

متد «CommitTransaction» در BaseCommandRepository<TEntity, TDbContext, TId>. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
بدون پارامتر ورودی.
مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: ICommandRepository<TEntity, TId> | IUnitOfWork | DI: TDbContext dbContext

##### `RollbackTransaction` (method)

```csharp
public void RollbackTransaction()
```

متد «RollbackTransaction» در BaseCommandRepository<TEntity, TDbContext, TId>. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
بدون پارامتر ورودی.
مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: ICommandRepository<TEntity, TId> | IUnitOfWork | DI: TDbContext dbContext

### `Zamin.Infra.Data.Sql.Commands.BaseCommandRepository<TEntity, TDbContext>`

- **Kind:** `class`
- **Base / interfaces:** `BaseCommandRepository<TEntity, TDbContext, long>`
- **Constraints:** `where TEntity : AggregateRoot where TDbContext : BaseCommandDbContext`
- **Source:** `Onion/src/3.Infra/Data/Zamin.Infra.Data.Sql.Commands/BaseCommandRepository.cs`

کلاس «BaseCommandRepository<TEntity, TDbContext>» در namespace Zamin.Infra.Data.Sql.Commands. موجودیت دامنه با هویت و قابلیت auditable. ارث‌بری/پیاده‌سازی: BaseCommandRepository<TEntity, TDbContext, long>. قیود جنریک: where TEntity : AggregateRoot where TDbContext : BaseCommandDbContext. وابستگی‌های سازنده (DI): TDbContext dbContext. مرتبط: BaseCommandRepository<TEntity, TDbContext, long> (same namespace) | DI: TDbContext dbContext.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/common-recipes.md#recipe-command-repository)

#### Members

##### `.ctor` (constructor)

```csharp
public BaseCommandRepository(TDbContext dbContext)
```

سازنده BaseCommandRepository<TEntity, TDbContext>. برای ایجاد نمونه با مقادیر اولیه‌ی مشخص. پارامترها:
- dbContext (TDbContext): ورودی از نوع TDbContext.
