# Zamin.Core.Contracts.Data.Commands (Part 1/2)

مرجع API برای namespace `Zamin.Core.Contracts.Data.Commands`.

- **Type count (this file):** 1
- **Parts:** **Part 1** · [Part 2](./Zamin.Core.Contracts.Data.Commands.Part2.md)

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Core.Contracts.Data.Commands.ICommandRepository<TEntity,TId>`

- **Kind:** `interface`
- **Base / interfaces:** `IUnitOfWork`
- **Constraints:** `where TEntity : AggregateRoot<TId> where TId : struct,           IComparable,           IComparable<TId>,           IConvertible,           IEquatable<TId>,           IFormattable`
- **Source:** `Onion/src/2.Core/Zamin.Core.Contracts/Data/Commands/ICommandRepository.cs`

در صورتی که داده‌ها به صورت عادی ذخیره سازی شوند از این Interface جهت تعیین اعمال اصلی موجود در بخش ذخیره سازی داده‌ها استفاده می‌شود.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/common-recipes.md#recipe-command-repository)

#### Members

##### `Delete` (method)

```csharp
void Delete(TId id)
```

یک شی را با شناسه حذف می کند
پارامترها:
- id: شناسه

##### `DeleteGraph` (method)

```csharp
void DeleteGraph(TId id)
```

حذف یک شی به همراه تمامی فرزندان آن را انجام می دهد
پارامترها:
- id: شناسه

##### `Delete` (method)

```csharp
void Delete(TEntity entity)
```

یک شی را دریافت کرده و از دیتابیس حذف می‌کند
پارامترها:
- entity: (بدون توضیح)

##### `Insert` (method)

```csharp
void Insert(TEntity entity)
```

داده‌های جدید را به دیتابیس اضافه می‌کند
پارامترها:
- entity: نمونه داده‌ای که باید به دیتابیس اضافه شود.

##### `InsertAsync` (method)

```csharp
Task InsertAsync(TEntity entity)
```

داده‌های جدید را به دیتابیس اضافه می‌کند
پارامترها:
- entity: نمونه داده‌ای که باید به دیتابیس اضافه شود.

##### `Get` (method)

```csharp
TEntity Get(TId id)
```

یک شی را با شناسه از دیتابیس یافته و بازگشت می‌دهد.
پارامترها:
- id: شناسه شی مورد نیاز
مقدار بازگشتی: نمونه ساخته شده از شی

##### `GetAsync` (method)

```csharp
Task<TEntity> GetAsync(TId id)
```

متد «GetAsync» در ICommandRepository<TEntity,TId>. داده یا وضعیت مرتبط را بازیابی می‌کند.
پارامترها:
- id (TId): ورودی از نوع TId.

مقدار بازگشتی: `Task<TEntity>` — نتیجه ناهمگام عملیات.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
انواع مرتبط: IUnitOfWork (same namespace)

##### `Get` (method)

```csharp
TEntity Get(BusinessId businessId)
```

متد «Get» در ICommandRepository<TEntity,TId>. داده یا وضعیت مرتبط را بازیابی می‌کند.
پارامترها:
- businessId (BusinessId): ورودی از نوع BusinessId.

مقدار بازگشتی: `TEntity`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
انواع مرتبط: IUnitOfWork (same namespace)

##### `GetAsync` (method)

```csharp
Task<TEntity> GetAsync(BusinessId businessId)
```

متد «GetAsync» در ICommandRepository<TEntity,TId>. داده یا وضعیت مرتبط را بازیابی می‌کند.
پارامترها:
- businessId (BusinessId): ورودی از نوع BusinessId.

مقدار بازگشتی: `Task<TEntity>` — نتیجه ناهمگام عملیات.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
انواع مرتبط: IUnitOfWork (same namespace)

##### `GetGraph` (method)

```csharp
TEntity GetGraph(TId id)
```

متد «GetGraph» در ICommandRepository<TEntity,TId>. داده یا وضعیت مرتبط را بازیابی می‌کند.
پارامترها:
- id (TId): ورودی از نوع TId.

مقدار بازگشتی: `TEntity`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
انواع مرتبط: IUnitOfWork (same namespace)

##### `GetGraphAsync` (method)

```csharp
Task<TEntity> GetGraphAsync(TId id)
```

متد «GetGraphAsync» در ICommandRepository<TEntity,TId>. داده یا وضعیت مرتبط را بازیابی می‌کند.
پارامترها:
- id (TId): ورودی از نوع TId.

مقدار بازگشتی: `Task<TEntity>` — نتیجه ناهمگام عملیات.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
انواع مرتبط: IUnitOfWork (same namespace)

##### `GetGraph` (method)

```csharp
TEntity GetGraph(BusinessId businessId)
```

متد «GetGraph» در ICommandRepository<TEntity,TId>. داده یا وضعیت مرتبط را بازیابی می‌کند.
پارامترها:
- businessId (BusinessId): ورودی از نوع BusinessId.

مقدار بازگشتی: `TEntity`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
انواع مرتبط: IUnitOfWork (same namespace)

##### `GetGraphAsync` (method)

```csharp
Task<TEntity> GetGraphAsync(BusinessId businessId)
```

متد «GetGraphAsync» در ICommandRepository<TEntity,TId>. داده یا وضعیت مرتبط را بازیابی می‌کند.
پارامترها:
- businessId (BusinessId): ورودی از نوع BusinessId.

مقدار بازگشتی: `Task<TEntity>` — نتیجه ناهمگام عملیات.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
انواع مرتبط: IUnitOfWork (same namespace)

##### `Exists` (method)

```csharp
bool Exists(Expression<Func<TEntity, bool>> expression)
```

متد «Exists» در ICommandRepository<TEntity,TId>. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- expression (Expression<Func<TEntity, bool>>): ورودی از نوع Expression<Func<TEntity, bool>>.

مقدار بازگشتی: `bool`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
انواع مرتبط: IUnitOfWork (same namespace)

##### `ExistsAsync` (method)

```csharp
Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression)
```

متد «ExistsAsync» در ICommandRepository<TEntity,TId>. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- expression (Expression<Func<TEntity, bool>>): ورودی از نوع Expression<Func<TEntity, bool>>.

مقدار بازگشتی: `Task<bool>` — نتیجه ناهمگام عملیات.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
انواع مرتبط: IUnitOfWork (same namespace)
