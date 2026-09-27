# Zamin.Core.Domain.Toolkits.ValueObjects (Part 2/4)

مرجع API برای namespace `Zamin.Core.Domain.Toolkits.ValueObjects`.

- **Type count (this file):** 1
- **Parts:** [Part 1](./Zamin.Core.Domain.Toolkits.ValueObjects.Part1.md) · **Part 2** · [Part 3](./Zamin.Core.Domain.Toolkits.ValueObjects.Part3.md) · [Part 4](./Zamin.Core.Domain.Toolkits.ValueObjects.Part4.md)

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Core.Domain.Toolkits.ValueObjects.NationalCode`

- **Kind:** `class`
- **Base / interfaces:** `BaseValueObject<NationalCode>`
- **Source:** `Onion/src/2.Core/Zamin.Core.Domain.Toolkits/ValueObjects/NationalCode.cs`

کلاس «NationalCode» در namespace Zamin.Core.Domain.Toolkits.ValueObjects. شیء مقدار دامنه با برابری مبتنی بر مقدار. ارث‌بری/پیاده‌سازی: BaseValueObject<NationalCode>. وابستگی‌های سازنده (DI): string value. مرتبط: BaseValueObject<NationalCode> | DI: string value.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/common-recipes.md#recipe-toolkit-value-objects)

#### Members

##### `Value` (property)

```csharp
public string Value { get; private set; }
```

پراپرتی «Value» از نوع `string` در NationalCode. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `FromString` (method)

```csharp
public static NationalCode FromString(string value)
```

متد «FromString» در NationalCode. نمونه یا نتیجه جدیدی می‌سازد.
پارامترها:
- value (string): مقدار مورد بررسی/ورود.

مقدار بازگشتی: `NationalCode`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: BaseValueObject<NationalCode> | DI: string value

##### `.ctor` (constructor)

```csharp
public NationalCode(string value)
```

سازنده NationalCode. برای ایجاد نمونه با مقادیر اولیه‌ی مشخص. پارامترها:
- value (string): مقدار مورد بررسی/ورود.
استثناها (از روی بدنه):
- InvalidValueObjectStateException (throw new)

##### `GetEqualityComponents` (method)

```csharp
protected override IEnumerable<object> GetEqualityComponents()
```

متد «GetEqualityComponents» در NationalCode. داده یا وضعیت مرتبط را بازیابی می‌کند.
بدون پارامتر ورودی.
مقدار بازگشتی: `IEnumerable<object>`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: BaseValueObject<NationalCode> | DI: string value

##### `string` (conversion_operator)

```csharp
public static explicit operator string(NationalCode title)
```

عملگر تبدیل «string» در NationalCode. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- title (NationalCode): ورودی از نوع NationalCode.

مقدار بازگشتی: `explicit`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
انواع مرتبط: BaseValueObject<NationalCode> | DI: string value

##### `NationalCode` (conversion_operator)

```csharp
public static implicit operator NationalCode(string value)
```

عملگر تبدیل «NationalCode» در NationalCode. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- value (string): مقدار مورد بررسی/ورود.

مقدار بازگشتی: `implicit`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
انواع مرتبط: BaseValueObject<NationalCode> | DI: string value

##### `ToString` (method)

```csharp
public override string ToString()
```

متد «ToString» در NationalCode. بخشی از قرارداد برابری/نمایش شیء را پیاده می‌کند.
بدون پارامتر ورودی.
مقدار بازگشتی: `string`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: BaseValueObject<NationalCode> | DI: string value
