# Zamin.Core.Domain.Toolkits.ValueObjects (Part 3/4)

مرجع API برای namespace `Zamin.Core.Domain.Toolkits.ValueObjects`.

- **Type count (this file):** 1
- **Parts:** [Part 1](./Zamin.Core.Domain.Toolkits.ValueObjects.Part1.md) · [Part 2](./Zamin.Core.Domain.Toolkits.ValueObjects.Part2.md) · **Part 3** · [Part 4](./Zamin.Core.Domain.Toolkits.ValueObjects.Part4.md)

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Core.Domain.Toolkits.ValueObjects.Priority`

- **Kind:** `class`
- **Base / interfaces:** `BaseValueObject<Priority>`
- **Source:** `Onion/src/2.Core/Zamin.Core.Domain.Toolkits/ValueObjects/Priority.cs`

کلاس «Priority» در namespace Zamin.Core.Domain.Toolkits.ValueObjects. شیء مقدار دامنه با برابری مبتنی بر مقدار. ارث‌بری/پیاده‌سازی: BaseValueObject<Priority>. وابستگی‌های سازنده (DI): int value. مرتبط: BaseValueObject<Priority> | DI: int value.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/common-recipes.md#recipe-toolkit-value-objects)

#### Members

##### `Value` (property)

```csharp
public int Value { get; private set; }
```

پراپرتی «Value» از نوع `int` در Priority. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `FromInt` (method)

```csharp
public static Priority FromInt(int value)
```

متد «FromInt» در Priority. نمونه یا نتیجه جدیدی می‌سازد.
پارامترها:
- value (int): مقدار مورد بررسی/ورود.

مقدار بازگشتی: `Priority`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: BaseValueObject<Priority> | DI: int value

##### `.ctor` (constructor)

```csharp
public Priority(int value)
```

سازنده Priority. برای ایجاد نمونه با مقادیر اولیه‌ی مشخص. پارامترها:
- value (int): مقدار مورد بررسی/ورود.
استثناها (از روی بدنه):
- InvalidValueObjectStateException (throw new)

##### `GetEqualityComponents` (method)

```csharp
protected override IEnumerable<object> GetEqualityComponents()
```

متد «GetEqualityComponents» در Priority. داده یا وضعیت مرتبط را بازیابی می‌کند.
بدون پارامتر ورودی.
مقدار بازگشتی: `IEnumerable<object>`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: BaseValueObject<Priority> | DI: int value

##### `+` (operator)

```csharp
public static Priority operator +(Priority priority, int addNum)
```

عملگر «+» در Priority. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- priority (Priority): ورودی از نوع Priority.
- addNum (int): ورودی از نوع int.

مقدار بازگشتی: `Priority`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
انواع مرتبط: BaseValueObject<Priority> | DI: int value

##### `-` (operator)

```csharp
public static Priority operator -(Priority priority, int addNum)
```

عملگر «-» در Priority. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- priority (Priority): ورودی از نوع Priority.
- addNum (int): ورودی از نوع int.

مقدار بازگشتی: `Priority`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
انواع مرتبط: BaseValueObject<Priority> | DI: int value

##### `<` (operator)

```csharp
public static bool operator <(Priority priority01, Priority priority02)
```

عملگر «<» در Priority. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- priority01 (Priority): ورودی از نوع Priority.
- priority02 (Priority): ورودی از نوع Priority.

مقدار بازگشتی: `bool`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
انواع مرتبط: BaseValueObject<Priority> | DI: int value

##### `>` (operator)

```csharp
public static bool operator >(Priority priority01, Priority priority02)
```

عملگر «>» در Priority. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- priority01 (Priority): ورودی از نوع Priority.
- priority02 (Priority): ورودی از نوع Priority.

مقدار بازگشتی: `bool`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
انواع مرتبط: BaseValueObject<Priority> | DI: int value

##### `<=` (operator)

```csharp
public static bool operator <=(Priority priority01, Priority priority02)
```

عملگر «<=» در Priority. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- priority01 (Priority): ورودی از نوع Priority.
- priority02 (Priority): ورودی از نوع Priority.

مقدار بازگشتی: `bool`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
انواع مرتبط: BaseValueObject<Priority> | DI: int value

##### `>=` (operator)

```csharp
public static bool operator >=(Priority priority01, Priority priority02)
```

عملگر «>=» در Priority. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- priority01 (Priority): ورودی از نوع Priority.
- priority02 (Priority): ورودی از نوع Priority.

مقدار بازگشتی: `bool`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
انواع مرتبط: BaseValueObject<Priority> | DI: int value

##### `int` (conversion_operator)

```csharp
public static explicit operator int(Priority priority)
```

عملگر تبدیل «int» در Priority. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- priority (Priority): ورودی از نوع Priority.

مقدار بازگشتی: `explicit`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
انواع مرتبط: BaseValueObject<Priority> | DI: int value

##### `Priority` (conversion_operator)

```csharp
public static implicit operator Priority(int value)
```

عملگر تبدیل «Priority» در Priority. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- value (int): مقدار مورد بررسی/ورود.

مقدار بازگشتی: `implicit`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
انواع مرتبط: BaseValueObject<Priority> | DI: int value

##### `Increase` (method)

```csharp
public Priority Increase(int increasedValue)
```

متد «Increase» در Priority. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- increasedValue (int): ورودی از نوع int.

مقدار بازگشتی: `Priority`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: BaseValueObject<Priority> | DI: int value

##### `Decrease` (method)

```csharp
public Priority Decrease(int increasedValue)
```

متد «Decrease» در Priority. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- increasedValue (int): ورودی از نوع int.

مقدار بازگشتی: `Priority`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: BaseValueObject<Priority> | DI: int value
