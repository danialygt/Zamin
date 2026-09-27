# Zamin.Utilities.DateTimes (Part 7/9)

مرجع API برای namespace `Zamin.Utilities.DateTimes`.

- **Type count (this file):** 1
- **Parts:** [Part 1](./Zamin.Utilities.DateTimes.Part1.md) · [Part 2](./Zamin.Utilities.DateTimes.Part2.md) · [Part 3](./Zamin.Utilities.DateTimes.Part3.md) · [Part 4](./Zamin.Utilities.DateTimes.Part4.md) · [Part 5](./Zamin.Utilities.DateTimes.Part5.md) · [Part 6](./Zamin.Utilities.DateTimes.Part6.md) · **Part 7** · [Part 8](./Zamin.Utilities.DateTimes.Part8.md) · [Part 9](./Zamin.Utilities.DateTimes.Part9.md)

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Utilities.DateTimes.PersianDateTimeUtils` — اعضای بخش 2/2

- **Kind:** `class`
- **Source:** `Onion/src/1.Utilities/Zamin.Utilities/DateTimes/PersianDateTimeUtils.cs`

Represents PersianDateTime utils.

#### Members

##### `ToPersianYearMonthDay` (method)

```csharp
public static PersianDay ToPersianYearMonthDay(this DateTimeOffset? gregorianDate, DateTimeOffsetPart dateTimeOffsetPart = DateTimeOffsetPart.IranLocalDateTime)
```

تبدیل تاریخ میلادی به شمسی و دریافت اجزای سال، ماه و روز نتیجه‌ی حاصل‌
پارامترها:
- gregorianDate: تاریخ و زمان
- dateTimeOffsetPart: کدام جزء این وهله مورد استفاده قرار گیرد؟

مقدار بازگشتی: `PersianDay`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `ToPersianYearMonthDay` (method)

```csharp
public static PersianDay ToPersianYearMonthDay(this DateTime? gregorianDate)
```

تبدیل تاریخ میلادی به شمسی و دریافت اجزای سال، ماه و روز نتیجه‌ی حاصل‌

پارامترها:
- gregorianDate (DateTime?): ورودی از نوع DateTime?.

مقدار بازگشتی: `PersianDay`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `ToPersianYearMonthDay` (method)

```csharp
public static PersianDay ToPersianYearMonthDay(this DateTimeOffset gregorianDate, DateTimeOffsetPart dateTimeOffsetPart = DateTimeOffsetPart.IranLocalDateTime)
```

تبدیل تاریخ میلادی به شمسی و دریافت اجزای سال، ماه و روز نتیجه‌ی حاصل‌
پارامترها:
- gregorianDate: تاریخ و زمان
- dateTimeOffsetPart: کدام جزء این وهله مورد استفاده قرار گیرد؟

مقدار بازگشتی: `PersianDay`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `ToPersianYearMonthDay` (method)

```csharp
public static PersianDay ToPersianYearMonthDay(this DateTime gregorianDate)
```

تبدیل تاریخ میلادی به شمسی و دریافت اجزای سال، ماه و روز نتیجه‌ی حاصل‌

پارامترها:
- gregorianDate (DateTime): ورودی از نوع DateTime.

مقدار بازگشتی: `PersianDay`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `ToShortPersianDateString` (method)

```csharp
public static string ToShortPersianDateString(this DateTimeOffset? dt, DateTimeOffsetPart dateTimeOffsetPart = DateTimeOffsetPart.IranLocalDateTime)
```

تبدیل تاریخ میلادی به شمسی با قالبی مانند 1395/10/21
پارامترها:
- dt: تاریخ و زمان
- dateTimeOffsetPart: کدام جزء این وهله مورد استفاده قرار گیرد؟
مقدار بازگشتی: تاریخ شمسی

##### `ToShortPersianDateString` (method)

```csharp
public static string ToShortPersianDateString(this DateTimeOffset dt, DateTimeOffsetPart dateTimeOffsetPart = DateTimeOffsetPart.IranLocalDateTime)
```

تبدیل تاریخ میلادی به شمسی با قالبی مانند 1395/10/21
پارامترها:
- dt: تاریخ و زمان
- dateTimeOffsetPart: کدام جزء این وهله مورد استفاده قرار گیرد؟
مقدار بازگشتی: تاریخ شمسی

##### `ToShortPersianDateString` (method)

```csharp
public static string ToShortPersianDateString(this DateTime dt)
```

تبدیل تاریخ میلادی به شمسی با قالبی مانند 1395/10/21
مقدار بازگشتی: تاریخ شمسی

پارامترها:
- dt (DateTime): ورودی از نوع DateTime.

مقدار بازگشتی: `string`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `ToShortPersianDateString` (method)

```csharp
public static string ToShortPersianDateString(this DateTime? dt)
```

تبدیل تاریخ میلادی به شمسی با قالبی مانند 1395/10/21
مقدار بازگشتی: تاریخ شمسی

پارامترها:
- dt (DateTime?): ورودی از نوع DateTime?.

مقدار بازگشتی: `string`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `ToShortPersianDateTimeString` (method)

```csharp
public static string ToShortPersianDateTimeString(this DateTime dt)
```

تبدیل تاریخ میلادی به شمسی با قالبی مانند 1395/10/21 10:20
مقدار بازگشتی: تاریخ شمسی

پارامترها:
- dt (DateTime): ورودی از نوع DateTime.

مقدار بازگشتی: `string`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `ToShortPersianDateTimeString` (method)

```csharp
public static string ToShortPersianDateTimeString(this DateTime? dt)
```

تبدیل تاریخ میلادی به شمسی با قالبی مانند 1395/10/21 10:20
مقدار بازگشتی: تاریخ شمسی

پارامترها:
- dt (DateTime?): ورودی از نوع DateTime?.

مقدار بازگشتی: `string`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `ToShortPersianDateTimeString` (method)

```csharp
public static string ToShortPersianDateTimeString(this DateTimeOffset? dt, DateTimeOffsetPart dateTimeOffsetPart = DateTimeOffsetPart.IranLocalDateTime)
```

تبدیل تاریخ میلادی به شمسی با قالبی مانند 1395/10/21 10:20
پارامترها:
- dt: تاریخ و زمان
- dateTimeOffsetPart: کدام جزء این وهله مورد استفاده قرار گیرد؟
مقدار بازگشتی: تاریخ شمسی

##### `ToShortPersianDateTimeString` (method)

```csharp
public static string ToShortPersianDateTimeString(this DateTimeOffset dt, DateTimeOffsetPart dateTimeOffsetPart = DateTimeOffsetPart.IranLocalDateTime)
```

تبدیل تاریخ میلادی به شمسی با قالبی مانند 1395/10/21 10:20
پارامترها:
- dt: تاریخ و زمان
- dateTimeOffsetPart: کدام جزء این وهله مورد استفاده قرار گیرد؟
مقدار بازگشتی: تاریخ شمسی

##### `CorrectReverseDate` (method)

```csharp
public static string CorrectReverseDate(string reverseDate)
```

رشته شامل تاریخ شمسی به صورت سال/ماه/روز را به روز/ماه/سال تبدیل می‌کند
پارامترها:
- reverseDate: رشته تاریخ شمسی معکوس

مقدار بازگشتی: `string`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
