# Zamin.Core.Domain.ValueObjects

مرجع API برای namespace `Zamin.Core.Domain.ValueObjects`.

- **Type count (this file):** 2

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Core.Domain.ValueObjects.BaseValueObject<TValueObject>`

- **Kind:** `class`
- **Base / interfaces:** `IEquatable<TValueObject>`
- **Constraints:** `where TValueObject : BaseValueObject<TValueObject>`
- **Source:** `Onion/src/2.Core/Zamin.Core.Domain/ValueObjects/BaseValueObject.cs`

کلاس پایه برای همه ValueObjectها توضحیات کاملی در مورد دلایل وجود ValueObjectها را در لینک زیر مشاهده می‌کند https://martinfowler.com/bliki/ValueObject.html

- **Recipe:** [الگوی استفاده مرتبط](../patterns/common-recipes.md#recipe-value-objects)

#### Members

##### `Equals` (method)

```csharp
public bool Equals(TValueObject other)
```

متد «Equals» در BaseValueObject<TValueObject>. بخشی از قرارداد برابری/نمایش شیء را پیاده می‌کند.
پارامترها:
- other (TValueObject): ورودی از نوع TValueObject.

مقدار بازگشتی: `bool`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
انواع مرتبط: IEquatable<TValueObject>

##### `Equals` (method)

```csharp
public override bool Equals(object obj)
```

متد «Equals» در BaseValueObject<TValueObject>. بخشی از قرارداد برابری/نمایش شیء را پیاده می‌کند.
پارامترها:
- obj (object): ورودی از نوع object.

مقدار بازگشتی: `bool`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
انواع مرتبط: IEquatable<TValueObject>

##### `GetHashCode` (method)

```csharp
public override int GetHashCode()
```

متد «GetHashCode» در BaseValueObject<TValueObject>. داده یا وضعیت مرتبط را بازیابی می‌کند.
بدون پارامتر ورودی.
مقدار بازگشتی: `int`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
انواع مرتبط: IEquatable<TValueObject>

##### `GetEqualityComponents` (method)

```csharp
protected abstract IEnumerable<object> GetEqualityComponents()
```

متد «GetEqualityComponents» در BaseValueObject<TValueObject>. داده یا وضعیت مرتبط را بازیابی می‌کند.
بدون پارامتر ورودی.
مقدار بازگشتی: `IEnumerable<object>`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
انواع مرتبط: IEquatable<TValueObject>

##### `==` (operator)

```csharp
public static bool operator ==(BaseValueObject<TValueObject> right, BaseValueObject<TValueObject> left)
```

عملگر «==» در BaseValueObject<TValueObject>. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- right (BaseValueObject<TValueObject>): ورودی از نوع BaseValueObject<TValueObject>.
- left (BaseValueObject<TValueObject>): ورودی از نوع BaseValueObject<TValueObject>.

مقدار بازگشتی: `bool`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
انواع مرتبط: IEquatable<TValueObject>

##### `!=` (operator)

```csharp
public static bool operator !=(BaseValueObject<TValueObject> right, BaseValueObject<TValueObject> left)
```

عملگر «!=» در BaseValueObject<TValueObject>. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- right (BaseValueObject<TValueObject>): ورودی از نوع BaseValueObject<TValueObject>.
- left (BaseValueObject<TValueObject>): ورودی از نوع BaseValueObject<TValueObject>.

مقدار بازگشتی: `bool`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
انواع مرتبط: IEquatable<TValueObject>

### `Zamin.Core.Domain.ValueObjects.BusinessId`

- **Kind:** `class`
- **Base / interfaces:** `BaseValueObject<BusinessId>`
- **Source:** `Onion/src/2.Core/Zamin.Core.Domain/ValueObjects/‌BusinessId.cs`

کلاس «BusinessId» در namespace Zamin.Core.Domain.ValueObjects. شیء مقدار دامنه با برابری مبتنی بر مقدار. ارث‌بری/پیاده‌سازی: BaseValueObject<BusinessId>. وابستگی‌های سازنده (DI): string value. مرتبط: BaseValueObject<BusinessId> (same namespace) | DI: string value.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/common-recipes.md#recipe-value-objects)

#### Members

##### `FromString` (method)

```csharp
public static BusinessId FromString(string value)
```

متد «FromString» در BusinessId. نمونه یا نتیجه جدیدی می‌سازد.
پارامترها:
- value (string): مقدار مورد بررسی/ورود.

مقدار بازگشتی: `BusinessId`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: BaseValueObject<BusinessId> (same namespace) | DI: string value

##### `FromGuid` (method)

```csharp
public static BusinessId FromGuid(Guid value)
```

متد «FromGuid» در BusinessId. نمونه یا نتیجه جدیدی می‌سازد.
پارامترها:
- value (Guid): مقدار مورد بررسی/ورود.

مقدار بازگشتی: `BusinessId`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: BaseValueObject<BusinessId> (same namespace) | DI: string value

##### `.ctor` (constructor)

```csharp
public BusinessId(string value)
```

سازنده BusinessId. برای ایجاد نمونه با مقادیر اولیه‌ی مشخص. پارامترها:
- value (string): مقدار مورد بررسی/ورود.
استثناها (از روی بدنه):
- InvalidValueObjectStateException (throw new)

##### `Value` (property)

```csharp
public Guid Value { get; private set; }
```

پراپرتی «Value» از نوع `Guid` در BusinessId. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `ToString` (method)

```csharp
public override string ToString()
```

متد «ToString» در BusinessId. بخشی از قرارداد برابری/نمایش شیء را پیاده می‌کند.
بدون پارامتر ورودی.
مقدار بازگشتی: `string`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: BaseValueObject<BusinessId> (same namespace) | DI: string value

##### `GetEqualityComponents` (method)

```csharp
protected override IEnumerable<object> GetEqualityComponents()
```

متد «GetEqualityComponents» در BusinessId. داده یا وضعیت مرتبط را بازیابی می‌کند.
بدون پارامتر ورودی.
مقدار بازگشتی: `IEnumerable<object>`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: BaseValueObject<BusinessId> (same namespace) | DI: string value

##### `string` (conversion_operator)

```csharp
public static explicit operator string(BusinessId title)
```

عملگر تبدیل «string» در BusinessId. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- title (BusinessId): ورودی از نوع BusinessId.

مقدار بازگشتی: `explicit`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
انواع مرتبط: BaseValueObject<BusinessId> (same namespace) | DI: string value

##### `BusinessId` (conversion_operator)

```csharp
public static implicit operator BusinessId(string value)
```

عملگر تبدیل «BusinessId» در BusinessId. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- value (string): مقدار مورد بررسی/ورود.

مقدار بازگشتی: `implicit`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
انواع مرتبط: BaseValueObject<BusinessId> (same namespace) | DI: string value

##### `Guid` (conversion_operator)

```csharp
public static explicit operator Guid(BusinessId title)
```

عملگر تبدیل «Guid» در BusinessId. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- title (BusinessId): ورودی از نوع BusinessId.

مقدار بازگشتی: `explicit`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
انواع مرتبط: BaseValueObject<BusinessId> (same namespace) | DI: string value

##### `BusinessId` (conversion_operator)

```csharp
public static implicit operator BusinessId(Guid value)
```

عملگر تبدیل «BusinessId» در BusinessId. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- value (Guid): مقدار مورد بررسی/ورود.

مقدار بازگشتی: `implicit`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
انواع مرتبط: BaseValueObject<BusinessId> (same namespace) | DI: string value
