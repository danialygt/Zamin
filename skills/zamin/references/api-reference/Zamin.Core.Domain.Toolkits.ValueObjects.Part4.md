# Zamin.Core.Domain.Toolkits.ValueObjects (Part 4/4)

مرجع API برای namespace `Zamin.Core.Domain.Toolkits.ValueObjects`.

- **Type count (this file):** 1
- **Parts:** [Part 1](./Zamin.Core.Domain.Toolkits.ValueObjects.Part1.md) · [Part 2](./Zamin.Core.Domain.Toolkits.ValueObjects.Part2.md) · [Part 3](./Zamin.Core.Domain.Toolkits.ValueObjects.Part3.md) · **Part 4**

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Core.Domain.Toolkits.ValueObjects.Title`

- **Kind:** `class`
- **Base / interfaces:** `BaseValueObject<Title>`
- **Source:** `Onion/src/2.Core/Zamin.Core.Domain.Toolkits/ValueObjects/Title.cs`

کلاس «Title» در namespace Zamin.Core.Domain.Toolkits.ValueObjects. شیء مقدار دامنه با برابری مبتنی بر مقدار. ارث‌بری/پیاده‌سازی: BaseValueObject<Title>. مرتبط: BaseValueObject<Title>.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/common-recipes.md#recipe-toolkit-value-objects)

#### Members

##### `Value` (property)

```csharp
public string Value { get; private set; }
```

پراپرتی «Value» از نوع `string` در Title. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `FromString` (method)

```csharp
public static Title FromString(string value)
```

متد «FromString» در Title. نمونه یا نتیجه جدیدی می‌سازد.
پارامترها:
- value (string): مقدار مورد بررسی/ورود.

مقدار بازگشتی: `Title`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
انواع مرتبط: BaseValueObject<Title>

##### `GetEqualityComponents` (method)

```csharp
protected override IEnumerable<object> GetEqualityComponents()
```

متد «GetEqualityComponents» در Title. داده یا وضعیت مرتبط را بازیابی می‌کند.
بدون پارامتر ورودی.
مقدار بازگشتی: `IEnumerable<object>`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
انواع مرتبط: BaseValueObject<Title>

##### `string` (conversion_operator)

```csharp
public static explicit operator string(Title title)
```

عملگر تبدیل «string» در Title. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- title (Title): ورودی از نوع Title.

مقدار بازگشتی: `explicit`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
انواع مرتبط: BaseValueObject<Title>

##### `Title` (conversion_operator)

```csharp
public static implicit operator Title(string value)
```

عملگر تبدیل «Title» در Title. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- value (string): مقدار مورد بررسی/ورود.

مقدار بازگشتی: `implicit`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
انواع مرتبط: BaseValueObject<Title>

##### `ToString` (method)

```csharp
public override string ToString()
```

متد «ToString» در Title. بخشی از قرارداد برابری/نمایش شیء را پیاده می‌کند.
بدون پارامتر ورودی.
مقدار بازگشتی: `string`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
انواع مرتبط: BaseValueObject<Title>
