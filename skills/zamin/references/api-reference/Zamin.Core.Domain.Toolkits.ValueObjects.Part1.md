# Zamin.Core.Domain.Toolkits.ValueObjects (Part 1/4)

مرجع API برای namespace `Zamin.Core.Domain.Toolkits.ValueObjects`.

- **Type count (this file):** 2
- **Parts:** **Part 1** · [Part 2](./Zamin.Core.Domain.Toolkits.ValueObjects.Part2.md) · [Part 3](./Zamin.Core.Domain.Toolkits.ValueObjects.Part3.md) · [Part 4](./Zamin.Core.Domain.Toolkits.ValueObjects.Part4.md)

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Core.Domain.Toolkits.ValueObjects.Description`

- **Kind:** `class`
- **Base / interfaces:** `BaseValueObject<Description>`
- **Source:** `Onion/src/2.Core/Zamin.Core.Domain.Toolkits/ValueObjects/Description.cs`

کلاس «Description» در namespace Zamin.Core.Domain.Toolkits.ValueObjects. شیء مقدار دامنه با برابری مبتنی بر مقدار. ارث‌بری/پیاده‌سازی: BaseValueObject<Description>. مرتبط: BaseValueObject<Description>.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/common-recipes.md#recipe-toolkit-value-objects)

#### Members

##### `Value` (property)

```csharp
public string Value { get; private set; }
```

پراپرتی «Value» از نوع `string` در Description. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `FromString` (method)

```csharp
public static Description FromString(string value)
```

متد «FromString» در Description. نمونه یا نتیجه جدیدی می‌سازد.
پارامترها:
- value (string): مقدار مورد بررسی/ورود.

مقدار بازگشتی: `Description`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
انواع مرتبط: BaseValueObject<Description>

##### `GetEqualityComponents` (method)

```csharp
protected override IEnumerable<object> GetEqualityComponents()
```

متد «GetEqualityComponents» در Description. داده یا وضعیت مرتبط را بازیابی می‌کند.
بدون پارامتر ورودی.
مقدار بازگشتی: `IEnumerable<object>`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
انواع مرتبط: BaseValueObject<Description>

##### `string` (conversion_operator)

```csharp
public static explicit operator string(Description description)
```

عملگر تبدیل «string» در Description. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- description (Description): ورودی از نوع Description.

مقدار بازگشتی: `explicit`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
انواع مرتبط: BaseValueObject<Description>

##### `Description` (conversion_operator)

```csharp
public static implicit operator Description(string value)
```

عملگر تبدیل «Description» در Description. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- value (string): مقدار مورد بررسی/ورود.

مقدار بازگشتی: `implicit`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
انواع مرتبط: BaseValueObject<Description>

### `Zamin.Core.Domain.Toolkits.ValueObjects.LegalNationalId`

- **Kind:** `class`
- **Base / interfaces:** `BaseValueObject<LegalNationalId>`
- **Source:** `Onion/src/2.Core/Zamin.Core.Domain.Toolkits/ValueObjects/LegalNationalId.cs`

کلاس «LegalNationalId» در namespace Zamin.Core.Domain.Toolkits.ValueObjects. شیء مقدار دامنه با برابری مبتنی بر مقدار. ارث‌بری/پیاده‌سازی: BaseValueObject<LegalNationalId>. مرتبط: BaseValueObject<LegalNationalId>.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/common-recipes.md#recipe-toolkit-value-objects)

#### Members

##### `Value` (property)

```csharp
public string Value { get; private set; }
```

پراپرتی «Value» از نوع `string` در LegalNationalId. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `FromString` (method)

```csharp
public static LegalNationalId FromString(string value)
```

متد «FromString» در LegalNationalId. نمونه یا نتیجه جدیدی می‌سازد.
پارامترها:
- value (string): مقدار مورد بررسی/ورود.

مقدار بازگشتی: `LegalNationalId`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
انواع مرتبط: BaseValueObject<LegalNationalId>

##### `GetEqualityComponents` (method)

```csharp
protected override IEnumerable<object> GetEqualityComponents()
```

متد «GetEqualityComponents» در LegalNationalId. داده یا وضعیت مرتبط را بازیابی می‌کند.
بدون پارامتر ورودی.
مقدار بازگشتی: `IEnumerable<object>`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
انواع مرتبط: BaseValueObject<LegalNationalId>

##### `string` (conversion_operator)

```csharp
public static explicit operator string(LegalNationalId title)
```

عملگر تبدیل «string» در LegalNationalId. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- title (LegalNationalId): ورودی از نوع LegalNationalId.

مقدار بازگشتی: `explicit`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
انواع مرتبط: BaseValueObject<LegalNationalId>

##### `LegalNationalId` (conversion_operator)

```csharp
public static implicit operator LegalNationalId(string value)
```

عملگر تبدیل «LegalNationalId» در LegalNationalId. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- value (string): مقدار مورد بررسی/ورود.

مقدار بازگشتی: `implicit`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
انواع مرتبط: BaseValueObject<LegalNationalId>

##### `ToString` (method)

```csharp
public override string ToString()
```

متد «ToString» در LegalNationalId. بخشی از قرارداد برابری/نمایش شیء را پیاده می‌کند.
بدون پارامتر ورودی.
مقدار بازگشتی: `string`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
انواع مرتبط: BaseValueObject<LegalNationalId>
