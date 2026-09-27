# Zamin.Core.Domain.Entities (Part 1/2)

مرجع API برای namespace `Zamin.Core.Domain.Entities`.

- **Type count (this file):** 5
- **Parts:** **Part 1** · [Part 2](./Zamin.Core.Domain.Entities.Part2.md)

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Core.Domain.Entities.AggregateRoot`

- **Kind:** `class`
- **Base / interfaces:** `AggregateRoot<long>`
- **Source:** `Onion/src/2.Core/Zamin.Core.Domain/Entities/AggregateRoot.cs`

کلاس «AggregateRoot» در namespace Zamin.Core.Domain.Entities. ریشه aggregate دامنه؛ مسئول ثبات درونی و ثبت domain eventها. ارث‌بری/پیاده‌سازی: AggregateRoot<long>. مرتبط: AggregateRoot<long> (same namespace).

- **Recipe:** [الگوی استفاده مرتبط](../patterns/common-recipes.md#recipe-aggregate-entity)

_اعضای عمومی مستندسازی‌شده در این خروجی وجود ندارد یا استخراج نشده است._

### `Zamin.Core.Domain.Entities.AggregateRoot<TId>`

- **Kind:** `class`
- **Base / interfaces:** `Entity<TId>`, `IAggregateRoot`
- **Constraints:** `where TId : struct,           IComparable,           IComparable<TId>,           IConvertible,           IEquatable<TId>,           IFormattable`
- **Source:** `Onion/src/2.Core/Zamin.Core.Domain/Entities/AggregateRoot.cs`

پیاده سازی الگوی AggregateRoot توضیحات کامل در مورد این الگو را در آدرس زیر می‌توانید مشاهده نمایید https://martinfowler.com/bliki/DDD_Aggregate.html

- **Recipe:** [الگوی استفاده مرتبط](../patterns/common-recipes.md#recipe-aggregate-entity)

#### Members

##### `.ctor` (constructor)

```csharp
protected AggregateRoot()
```

سازنده AggregateRoot<TId>. بدون پارامتر؛ معمولاً برای ORM، serialization یا مقداردهی اولیه محافظت‌شده استفاده می‌شود. پیش‌شرط: وابستگی‌ها/مقادیر ورودی باید معتبر باشند تا فیلدهای داخلی به‌درستی مقداردهی شوند.

##### `.ctor` (constructor)

```csharp
public AggregateRoot(IEnumerable<IDomainEvent> events)
```

سازنده Aggregate برای ایجاد Aggregate از روی Eventها
پارامترها:
- events: در صورتی که Event از قبل وجود داشته باشد توسط این پارامتر به Aggregate ارسال می‌گردد

##### `Apply` (method)

```csharp
protected void Apply(IDomainEvent @event)
```

متد «Apply» در AggregateRoot<TId>. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- event (IDomainEvent): رویداد دامنه/پیام برای پردازش.

مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: Entity<TId> (same namespace) | IAggregateRoot (same namespace) | DI: IEnumerable<IDomainEvent> events

##### `AddEvent` (method)

```csharp
protected void AddEvent(IDomainEvent @event)
```

یک Event جدید به مجموعه Eventهای موجود در این Aggregate اضافه می‌کند. مسئولیت ساخت و ارسال Event به عهده خود Aggregateها می‌باشد.
پارامترها:
- event: (بدون توضیح)

##### `GetEvents` (method)

```csharp
public IEnumerable<IDomainEvent> GetEvents()
```

لیستی از Eventهای رخداده برای Aggregate را به صورت فقط خواندی و غیر قابل تغییر را بازگشت می‌دهد
مقدار بازگشتی: لیست Eventها

##### `ClearEvents` (method)

```csharp
public void ClearEvents()
```

Eventهای موجود در این Aggregate را پاک می‌کند

### `Zamin.Core.Domain.Entities.Entity`

- **Kind:** `class`
- **Base / interfaces:** `Entity<long>`
- **Source:** `Onion/src/2.Core/Zamin.Core.Domain/Entities/Entity.cs`

کلاس «Entity» در namespace Zamin.Core.Domain.Entities. موجودیت دامنه با هویت و قابلیت auditable. ارث‌بری/پیاده‌سازی: Entity<long>. مرتبط: Entity<long> (same namespace).

- **Recipe:** [الگوی استفاده مرتبط](../patterns/common-recipes.md#recipe-aggregate-entity)

_اعضای عمومی مستندسازی‌شده در این خروجی وجود ندارد یا استخراج نشده است._

### `Zamin.Core.Domain.Entities.Entity<TId>`

- **Kind:** `class`
- **Base / interfaces:** `IAuditableEntity`
- **Constraints:** `where TId : struct,           IComparable,           IComparable<TId>,           IConvertible,           IEquatable<TId>,           IFormattable`
- **Source:** `Onion/src/2.Core/Zamin.Core.Domain/Entities/Entity.cs`

کلاس پایه برای تمامی Entityها موجود در سامانه

- **Recipe:** [الگوی استفاده مرتبط](../patterns/common-recipes.md#recipe-aggregate-entity)

#### Members

##### `Id` (property)

```csharp
public TId Id { get; protected set; }
```

شناسه عددی Entityها صرفا برای ذخیره در دیتابیس و سادگی کار مورد استفاده قرار بگیرید.

##### `BusinessId` (property)

```csharp
public BusinessId BusinessId { get; protected set; }
```

شناسه Entity شناسه اصلی Entity که در همه جا باید مورد استفاده قرار گیرد BusinessId است. تمامی ارتباطات به کمک این شناسه باید برقرار شود.

##### `.ctor` (constructor)

```csharp
protected Entity()
```

سازنده پیش‌فرض به صورت Protected تعریف شده است. با توجه به اینکه این نیاز است هنگام ساخت خواص اساسی Entity ایجاد شود، هیچ شی بدون پر کردن این خواص نباید ایجاد شود. بار جلو گیری از این مورد برای همه Entityها باید سازنده‌هایی تعریف شود که مقدار ورودی دارند. برای اینکه بتوان از همین Entityها برای فرایند ذخیره سازی و بازیابی از دیتابیس به کمک ORMها استفاده کرد، ضروری است که سازنده پیش‌فرض با سطح دسترسی بالا مثل Protected یا Private ایجاد شود.

##### `Equals` (method)

```csharp
public bool Equals(Entity<TId>? other)
```

متد «Equals» در Entity<TId>. بخشی از قرارداد برابری/نمایش شیء را پیاده می‌کند.
پارامترها:
- other (Entity<TId>?): ورودی از نوع Entity<TId>?.

مقدار بازگشتی: `bool`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
انواع مرتبط: IAuditableEntity (same namespace)

##### `Equals` (method)

```csharp
public override bool Equals(object? obj)
```

متد «Equals» در Entity<TId>. بخشی از قرارداد برابری/نمایش شیء را پیاده می‌کند.
پارامترها:
- obj (object?): ورودی از نوع object?.

مقدار بازگشتی: `bool`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
انواع مرتبط: IAuditableEntity (same namespace)

##### `GetHashCode` (method)

```csharp
public override int GetHashCode()
```

متد «GetHashCode» در Entity<TId>. داده یا وضعیت مرتبط را بازیابی می‌کند.
بدون پارامتر ورودی.
مقدار بازگشتی: `int`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
انواع مرتبط: IAuditableEntity (same namespace)

##### `==` (operator)

```csharp
public static bool operator ==(Entity<TId> left, Entity<TId> right)
```

عملگر «==» در Entity<TId>. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- left (Entity<TId>): ورودی از نوع Entity<TId>.
- right (Entity<TId>): ورودی از نوع Entity<TId>.

مقدار بازگشتی: `bool`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
انواع مرتبط: IAuditableEntity (same namespace)

##### `!=` (operator)

```csharp
public static bool operator !=(Entity<TId> left, Entity<TId> right)
```

عملگر «!=» در Entity<TId>. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- left (Entity<TId>): ورودی از نوع Entity<TId>.
- right (Entity<TId>): ورودی از نوع Entity<TId>.

مقدار بازگشتی: `bool`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
انواع مرتبط: IAuditableEntity (same namespace)

### `Zamin.Core.Domain.Entities.IAggregateRoot`

- **Kind:** `interface`
- **Source:** `Onion/src/2.Core/Zamin.Core.Domain/Entities/IAggregateRoot.cs`

قرارداد (اینترفیس) «IAggregateRoot» در namespace Zamin.Core.Domain.Entities. قرارداد رفتار برای مصرف‌کنندگان و پیاده‌سازی‌های جایگزین.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/common-recipes.md#recipe-aggregate-entity)

#### Members

##### `ClearEvents` (method)

```csharp
void ClearEvents()
```

متد «ClearEvents» در IAggregateRoot. مورد یا وضعیت را حذف/پاک می‌کند.
بدون پارامتر ورودی.
مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `GetEvents` (method)

```csharp
IEnumerable<IDomainEvent> GetEvents()
```

متد «GetEvents» در IAggregateRoot. داده یا وضعیت مرتبط را بازیابی می‌کند.
بدون پارامتر ورودی.
مقدار بازگشتی: `IEnumerable<IDomainEvent>`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
