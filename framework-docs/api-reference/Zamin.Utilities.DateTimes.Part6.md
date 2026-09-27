# Zamin.Utilities.DateTimes (Part 6/9)

مرجع API برای namespace `Zamin.Utilities.DateTimes`.

- **Type count (this file):** 1
- **Parts:** [Part 1](./Zamin.Utilities.DateTimes.Part1.md) · [Part 2](./Zamin.Utilities.DateTimes.Part2.md) · [Part 3](./Zamin.Utilities.DateTimes.Part3.md) · [Part 4](./Zamin.Utilities.DateTimes.Part4.md) · [Part 5](./Zamin.Utilities.DateTimes.Part5.md) · **Part 6** · [Part 7](./Zamin.Utilities.DateTimes.Part7.md) · [Part 8](./Zamin.Utilities.DateTimes.Part8.md) · [Part 9](./Zamin.Utilities.DateTimes.Part9.md)

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Utilities.DateTimes.PersianDateTimeUtils` — اعضای بخش 1/2

- **Kind:** `class`
- **Source:** `Onion/src/1.Utilities/Zamin.Utilities/DateTimes/PersianDateTimeUtils.cs`

Represents PersianDateTime utils.

#### Members

##### `IsValidPersianDate` (method)

```csharp
public static bool IsValidPersianDate(int persianYear, int persianMonth, int persianDay)
```

تعیین اعتبار تاریخ شمسی
پارامترها:
- persianYear: سال شمسی
- persianMonth: ماه شمسی
- persianDay: روز شمسی

مقدار بازگشتی: `bool`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `IsValidPersianDateTime` (method)

```csharp
public static bool IsValidPersianDateTime(this string persianDateTime)
```

تعیین اعتبار تاریخ و زمان رشته‌ای شمسی با قالب‌های پشتیبانی شده‌ی ۹۰/۸/۱۴ , 1395/11/3 17:30 , ۱۳۹۰/۸/۱۴ , ۹۰-۸-۱۴ , ۱۳۹۰-۸-۱۴
پارامترها:
- persianDateTime: تاریخ و زمان شمسی

مقدار بازگشتی: `bool`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `ToGregorianDateTime` (method)

```csharp
public static DateTime? ToGregorianDateTime(this string persianDateTime)
```

تبدیل تاریخ و زمان رشته‌ای شمسی به میلادی با قالب‌های پشتیبانی شده‌ی ۹۰/۸/۱۴ , 1395/11/3 17:30 , ۱۳۹۰/۸/۱۴ , ۹۰-۸-۱۴ , ۱۳۹۰-۸-۱۴ در اینجا اگر رشته‌ی مدنظر قابل تبدیل نباشد، مقدار نال را دریافت خواهید کرد
پارامترها:
- persianDateTime: تاریخ و زمان شمسی
مقدار بازگشتی: تاریخ و زمان میلادی

##### `ToGregorianDateTimeOffset` (method)

```csharp
public static DateTimeOffset? ToGregorianDateTimeOffset(this string persianDateTime)
```

تبدیل تاریخ و زمان رشته‌ای شمسی به میلادی با قالب‌های پشتیبانی شده‌ی ۹۰/۸/۱۴ , 1395/11/3 17:30 , ۱۳۹۰/۸/۱۴ , ۹۰-۸-۱۴ , ۱۳۹۰-۸-۱۴ در اینجا اگر رشته‌ی مدنظر قابل تبدیل نباشد، مقدار نال را دریافت خواهید کرد
پارامترها:
- persianDateTime: تاریخ و زمان شمسی
مقدار بازگشتی: تاریخ و زمان میلادی

##### `ToLongPersianDateString` (method)

```csharp
public static string ToLongPersianDateString(this DateTime dt)
```

تبدیل تاریخ میلادی به شمسی با قالبی مانند 21 دی 1395
مقدار بازگشتی: تاریخ شمسی

پارامترها:
- dt (DateTime): ورودی از نوع DateTime.

مقدار بازگشتی: `string`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `ToLongPersianDateString` (method)

```csharp
public static string ToLongPersianDateString(this DateTime? dt)
```

تبدیل تاریخ میلادی به شمسی با قالبی مانند 21 دی 1395
مقدار بازگشتی: تاریخ شمسی

پارامترها:
- dt (DateTime?): ورودی از نوع DateTime?.

مقدار بازگشتی: `string`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `ToLongPersianDateString` (method)

```csharp
public static string ToLongPersianDateString(this DateTimeOffset? dt, DateTimeOffsetPart dateTimeOffsetPart = DateTimeOffsetPart.IranLocalDateTime)
```

تبدیل تاریخ میلادی به شمسی با قالبی مانند 21 دی 1395
پارامترها:
- dt: تاریخ و زمان
- dateTimeOffsetPart: کدام جزء این وهله مورد استفاده قرار گیرد؟
مقدار بازگشتی: تاریخ شمسی

##### `ToLongPersianDateString` (method)

```csharp
public static string ToLongPersianDateString(this DateTimeOffset dt, DateTimeOffsetPart dateTimeOffsetPart = DateTimeOffsetPart.IranLocalDateTime)
```

تبدیل تاریخ میلادی به شمسی با قالبی مانند 21 دی 1395
پارامترها:
- dt: تاریخ و زمان
- dateTimeOffsetPart: کدام جزء این وهله مورد استفاده قرار گیرد؟
مقدار بازگشتی: تاریخ شمسی

##### `ToLongPersianDateTimeString` (method)

```csharp
public static string ToLongPersianDateTimeString(this DateTime dt)
```

تبدیل تاریخ میلادی به شمسی با قالبی مانند 21 دی 1395، 10:20:02 ق.ظ
مقدار بازگشتی: تاریخ شمسی

پارامترها:
- dt (DateTime): ورودی از نوع DateTime.

مقدار بازگشتی: `string`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `ToLongPersianDateTimeString` (method)

```csharp
public static string ToLongPersianDateTimeString(this DateTime? dt)
```

تبدیل تاریخ میلادی به شمسی با قالبی مانند 21 دی 1395، 10:20:02 ق.ظ
مقدار بازگشتی: تاریخ شمسی

پارامترها:
- dt (DateTime?): ورودی از نوع DateTime?.

مقدار بازگشتی: `string`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `ToLongPersianDateTimeString` (method)

```csharp
public static string ToLongPersianDateTimeString(this DateTimeOffset? dt, DateTimeOffsetPart dateTimeOffsetPart = DateTimeOffsetPart.IranLocalDateTime)
```

تبدیل تاریخ میلادی به شمسی با قالبی مانند 21 دی 1395، 10:20:02 ق.ظ
پارامترها:
- dt: تاریخ و زمان
- dateTimeOffsetPart: کدام جزء این وهله مورد استفاده قرار گیرد؟
مقدار بازگشتی: تاریخ شمسی

##### `ToLongPersianDateTimeString` (method)

```csharp
public static string ToLongPersianDateTimeString(this DateTimeOffset dt, DateTimeOffsetPart dateTimeOffsetPart = DateTimeOffsetPart.IranLocalDateTime)
```

تبدیل تاریخ میلادی به شمسی با قالبی مانند 21 دی 1395، 10:20:02 ق.ظ
پارامترها:
- dt: تاریخ و زمان
- dateTimeOffsetPart: کدام جزء این وهله مورد استفاده قرار گیرد؟
مقدار بازگشتی: تاریخ شمسی

##### `ToPersianDateTimeString` (method)

```csharp
public static string ToPersianDateTimeString(this DateTime dateTime, string format)
```

تبدیل تاریخ میلادی به شمسی
مقدار بازگشتی: تاریخ شمسی

پارامترها:
- dateTime (DateTime): ورودی از نوع DateTime.
- format (string): ورودی از نوع string.

مقدار بازگشتی: `string`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
