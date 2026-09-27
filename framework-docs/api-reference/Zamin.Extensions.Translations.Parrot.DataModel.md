# Zamin.Extensions.Translations.Parrot.DataModel

مرجع API برای namespace `Zamin.Extensions.Translations.Parrot.DataModel`.

- **Type count (this file):** 1

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Extensions.Translations.Parrot.DataModel.LocalizationRecord`

- **Kind:** `class`
- **Source:** `Extentsions/Translations/Zamin.Extensions.Translations.Parrot/Zamin.Extensions.Translations.Parrot/DataModel/LocalizationRecord.cs`

کلاس «LocalizationRecord» در namespace Zamin.Extensions.Translations.Parrot.DataModel. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین.

#### Members

##### `Id` (property)

```csharp
public long Id { get; set; }
```

پراپرتی «Id» از نوع `long` در LocalizationRecord. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `BusinessId` (property)

```csharp
public Guid BusinessId { get; set; }
```

پراپرتی «BusinessId» از نوع `Guid` در LocalizationRecord. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `Key` (property)

```csharp
public string Key { get; set; }
```

پراپرتی «Key» از نوع `string` در LocalizationRecord. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `Value` (property)

```csharp
public string Value { get; set; }
```

پراپرتی «Value» از نوع `string` در LocalizationRecord. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `Culture` (property)

```csharp
public string Culture { get; set; }
```

پراپرتی «Culture» از نوع `string` در LocalizationRecord. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `CorrespondingValueNotFound` (property)

```csharp
public bool CorrespondingValueNotFound => ...
```

پراپرتی «CorrespondingValueNotFound» از نوع `bool` در LocalizationRecord. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. منطق دسترسی از روی بدنه accessor قابل مشاهده است.

##### `ToString` (method)

```csharp
public override string ToString()
```

متد «ToString» در LocalizationRecord. بخشی از قرارداد برابری/نمایش شیء را پیاده می‌کند.
بدون پارامتر ورودی.
مقدار بازگشتی: `string`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
