# Zamin.Core.Contracts.Data.Commands (Part 2/2)

مرجع API برای namespace `Zamin.Core.Contracts.Data.Commands`.

- **Type count (this file):** 2
- **Parts:** [Part 1](./Zamin.Core.Contracts.Data.Commands.Part1.md) · **Part 2**

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Core.Contracts.Data.Commands.IDomainEventStore`

- **Kind:** `interface`
- **Source:** `Onion/src/2.Core/Zamin.Core.Contracts/Data/Commands/IDomainEventStore.cs`

در صورت نیاز به ذخیره و بازیابی eventها از این اینترفیس استفاده می‌شود.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/common-recipes.md#recipe-command-repository)

#### Members

##### `Save` (method)

```csharp
void Save<TEvent>(string aggregateName, string aggregateId, IEnumerable<TEvent> events) where TEvent : IDomainEvent
```

متد «Save» در IDomainEventStore. وضعیت را به‌روز یا ذخیره می‌کند.
پارامترها:
- aggregateName (string): ورودی از نوع string.
- aggregateId (string): ورودی از نوع string.
- events (IEnumerable<TEvent>): رویداد دامنه/پیام برای پردازش.

مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `SaveAsync` (method)

```csharp
Task SaveAsync<TEvent>(string aggregateName, string aggregateId, IEnumerable<TEvent> events) where TEvent : IDomainEvent
```

متد «SaveAsync» در IDomainEventStore. وضعیت را به‌روز یا ذخیره می‌کند.
پارامترها:
- aggregateName (string): ورودی از نوع string.
- aggregateId (string): ورودی از نوع string.
- events (IEnumerable<TEvent>): رویداد دامنه/پیام برای پردازش.

مقدار بازگشتی: `Task` — عملیات ناهمگام بدون نتیجه داده‌ای.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

### `Zamin.Core.Contracts.Data.Commands.IUnitOfWork`

- **Kind:** `interface`
- **Source:** `Onion/src/2.Core/Zamin.Core.Contracts/Data/Commands/IUnitOfWork.cs`

تعریف Interface برای الگوی UnitOfWork جهت مدیریت تراکنش‌ها با دیتابیس در این قسمت انجام شده است تعریف کامل این الگو در کتاب P of EAA وجود دارد و تعریف اولیه را در آدرس زیر می‌توان مشاهده کرد https://martinfowler.com/eaaCatalog/unitOfWork.html

- **Recipe:** [الگوی استفاده مرتبط](../patterns/common-recipes.md#recipe-command-repository)

#### Members

##### `BeginTransaction` (method)

```csharp
void BeginTransaction()
```

در صورت نیاز به کنترل تراکنش‌ها از این متد جهت شروع تراکنش استفاده می‌شود.

##### `CommitTransaction` (method)

```csharp
void CommitTransaction()
```

در صورت کنترل دستی تراکنش از این متد جهت پایان موفقیت آمیز تراکنش استفاده می‌شود.

##### `RollbackTransaction` (method)

```csharp
void RollbackTransaction()
```

در صورت بروز خطا در فرایند‌ها از این متد جهت بازگشت تغییرات استفاده می‌شود.

##### `Commit` (method)

```csharp
int Commit()
```

برای تایید تراکنشی که اتوماتیک توسط سیستم ایجاد شده است از این متد استفاده می‌شود.

مقدار بازگشتی: `int`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `CommitAsync` (method)

```csharp
Task<int> CommitAsync()
```

برای تایید تراکنشی که اتوماتیک توسط سیستم ایجاد شده است از این متد استفاده می‌شود.

مقدار بازگشتی: `Task<int>` — نتیجه ناهمگام عملیات.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
