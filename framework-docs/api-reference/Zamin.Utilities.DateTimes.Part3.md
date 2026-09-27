# Zamin.Utilities.DateTimes (Part 3/9)

مرجع API برای namespace `Zamin.Utilities.DateTimes`.

- **Type count (this file):** 1
- **Parts:** [Part 1](./Zamin.Utilities.DateTimes.Part1.md) · [Part 2](./Zamin.Utilities.DateTimes.Part2.md) · **Part 3** · [Part 4](./Zamin.Utilities.DateTimes.Part4.md) · [Part 5](./Zamin.Utilities.DateTimes.Part5.md) · [Part 6](./Zamin.Utilities.DateTimes.Part6.md) · [Part 7](./Zamin.Utilities.DateTimes.Part7.md) · [Part 8](./Zamin.Utilities.DateTimes.Part8.md) · [Part 9](./Zamin.Utilities.DateTimes.Part9.md)

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Utilities.DateTimes.FriendlyPersianDateUtils`

- **Kind:** `class`
- **Source:** `Onion/src/1.Utilities/Zamin.Utilities/DateTimes/FriendlyPersianDateUtils.cs`

نمایش دوستانه‌ی یک تاریخ و ساعت انگلیسی به شمسی

#### Members

##### `ToPersianDateTextify` (method)

```csharp
public static string ToPersianDateTextify(int persianYear, int persianMonth, int persianDay)
```

نمایش فارسی روز دریافتی شمسی مانند سه شنبه ۲۱ دی ۱۳۹۵

پارامترها:
- persianYear (int): ورودی از نوع int.
- persianMonth (int): ورودی از نوع int.
- persianDay (int): ورودی از نوع int.

مقدار بازگشتی: `string`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `ToPersianDateTextify` (method)

```csharp
public static string ToPersianDateTextify(this DateTime dt)
```

نمایش فارسی روز دریافتی مانند سه شنبه ۲۱ دی ۱۳۹۵

پارامترها:
- dt (DateTime): ورودی از نوع DateTime.

مقدار بازگشتی: `string`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `ToPersianDateTextify` (method)

```csharp
public static string ToPersianDateTextify(this DateTime? dt)
```

نمایش فارسی روز دریافتی مانند سه شنبه ۲۱ دی ۱۳۹۵

پارامترها:
- dt (DateTime?): ورودی از نوع DateTime?.

مقدار بازگشتی: `string`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `ToPersianDateTextify` (method)

```csharp
public static string ToPersianDateTextify(this DateTimeOffset dt, DateTimeOffsetPart dateTimeOffsetPart = DateTimeOffsetPart.IranLocalDateTime)
```

نمایش فارسی روز دریافتی مانند سه شنبه ۲۱ دی ۱۳۹۵
پارامترها:
- dt: تاریخ و زمان
- dateTimeOffsetPart: کدام جزء این وهله مورد استفاده قرار گیرد؟

مقدار بازگشتی: `string`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `ToPersianDateTextify` (method)

```csharp
public static string ToPersianDateTextify(this DateTimeOffset? dt, DateTimeOffsetPart dateTimeOffsetPart = DateTimeOffsetPart.IranLocalDateTime)
```

نمایش فارسی روز دریافتی مانند سه شنبه ۲۱ دی ۱۳۹۵
پارامترها:
- dt: تاریخ و زمان
- dateTimeOffsetPart: کدام جزء این وهله مورد استفاده قرار گیرد؟

مقدار بازگشتی: `string`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `ToFriendlyPersianDateTextify` (method)

```csharp
public static string ToFriendlyPersianDateTextify(this DateTime dt, DateTime comparisonBase, bool appendHhMm = true)
```

نمایش دوستانه‌ی یک تاریخ و ساعت انگلیسی به شمسی مانند ۱۰ روز قبل، سه شنبه ۲۱ دی ۱۳۹۵، ساعت ۱۰:۲۰
پارامترها:
- dt: تاریخ ورودی
- comparisonBase: مبنای مقایسه مانند هم اکنون
- appendHhMm: آیا ساعت نیز به نتیجه‌اضافه شود؟
مقدار بازگشتی: نمایش دوستانه

##### `ToFriendlyPersianDateTextify` (method)

```csharp
public static string ToFriendlyPersianDateTextify(this DateTime dt, bool appendHhMm = true)
```

نمایش دوستانه‌ی یک تاریخ و ساعت انگلیسی به شمسی مبنای محاسبه هم اکنون مانند ۱۰ روز قبل، سه شنبه ۲۱ دی ۱۳۹۵، ساعت ۱۰:۲۰
پارامترها:
- dt: تاریخ ورودی
- appendHhMm: آیا ساعت نیز به نتیجه‌اضافه شود؟
مقدار بازگشتی: نمایش دوستانه

##### `ToFriendlyPersianDateTextify` (method)

```csharp
public static string ToFriendlyPersianDateTextify(this DateTimeOffset dt, DateTime comparisonBase, DateTimeOffsetPart dateTimeOffsetPart = DateTimeOffsetPart.IranLocalDateTime, bool appendHhMm = true)
```

نمایش دوستانه‌ی یک تاریخ و ساعت انگلیسی به شمسی مانند ۱۰ روز قبل، سه شنبه ۲۱ دی ۱۳۹۵، ساعت ۱۰:۲۰
پارامترها:
- dt: تاریخ ورودی
- comparisonBase: مبنای مقایسه مانند هم اکنون
- dateTimeOffsetPart: کدام جزء این وهله مورد استفاده قرار گیرد؟
- appendHhMm: آیا ساعت نیز به نتیجه‌اضافه شود؟
مقدار بازگشتی: نمایش دوستانه

##### `ToFriendlyPersianDateTextify` (method)

```csharp
public static string ToFriendlyPersianDateTextify(this DateTimeOffset dt, bool appendHhMm = true)
```

نمایش دوستانه‌ی یک تاریخ و ساعت انگلیسی به شمسی مبنای محاسبه هم اکنون مانند ۱۰ روز قبل، سه شنبه ۲۱ دی ۱۳۹۵، ساعت ۱۰:۲۰
پارامترها:
- dt: تاریخ ورودی
- appendHhMm: آیا ساعت نیز به نتیجه‌اضافه شود؟
مقدار بازگشتی: نمایش دوستانه

##### `ToFriendlyPersianDateTextify` (method)

```csharp
public static string ToFriendlyPersianDateTextify(this DateTime? dt, DateTime comparisonBase)
```

نمایش دوستانه‌ی یک تاریخ و ساعت انگلیسی به شمسی مانند ۱۰ روز قبل، سه شنبه ۲۱ دی ۱۳۹۵، ساعت ۱۰:۲۰
پارامترها:
- dt: تاریخ ورودی
- comparisonBase: مبنای مقایسه مانند هم اکنون
مقدار بازگشتی: نمایش دوستانه

##### `ToFriendlyPersianDateTextify` (method)

```csharp
public static string ToFriendlyPersianDateTextify(this DateTime? dt)
```

نمایش دوستانه‌ی یک تاریخ و ساعت انگلیسی به شمسی مبنای محاسبه هم اکنون مانند ۱۰ روز قبل، سه شنبه ۲۱ دی ۱۳۹۵، ساعت ۱۰:۲۰
پارامترها:
- dt: تاریخ ورودی
مقدار بازگشتی: نمایش دوستانه

##### `ToFriendlyPersianDateTextify` (method)

```csharp
public static string ToFriendlyPersianDateTextify(this DateTimeOffset? dt, DateTime comparisonBase, DateTimeOffsetPart dateTimeOffsetPart = DateTimeOffsetPart.IranLocalDateTime)
```

نمایش دوستانه‌ی یک تاریخ و ساعت انگلیسی به شمسی مانند ۱۰ روز قبل، سه شنبه ۲۱ دی ۱۳۹۵، ساعت ۱۰:۲۰
پارامترها:
- dt: تاریخ ورودی
- comparisonBase: مبنای مقایسه مانند هم اکنون
- dateTimeOffsetPart: کدام جزء این وهله مورد استفاده قرار گیرد؟
مقدار بازگشتی: نمایش دوستانه

##### `ToFriendlyPersianDateTextify` (method)

```csharp
public static string ToFriendlyPersianDateTextify(this DateTimeOffset? dt)
```

نمایش دوستانه‌ی یک تاریخ و ساعت انگلیسی به شمسی مبنای محاسبه هم اکنون مانند ۱۰ روز قبل، سه شنبه ۲۱ دی ۱۳۹۵، ساعت ۱۰:۲۰
پارامترها:
- dt: تاریخ ورودی
مقدار بازگشتی: نمایش دوستانه
