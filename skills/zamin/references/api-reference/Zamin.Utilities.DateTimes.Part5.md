# Zamin.Utilities.DateTimes (Part 5/9)

مرجع API برای namespace `Zamin.Utilities.DateTimes`.

- **Type count (this file):** 1
- **Parts:** [Part 1](./Zamin.Utilities.DateTimes.Part1.md) · [Part 2](./Zamin.Utilities.DateTimes.Part2.md) · [Part 3](./Zamin.Utilities.DateTimes.Part3.md) · [Part 4](./Zamin.Utilities.DateTimes.Part4.md) · **Part 5** · [Part 6](./Zamin.Utilities.DateTimes.Part6.md) · [Part 7](./Zamin.Utilities.DateTimes.Part7.md) · [Part 8](./Zamin.Utilities.DateTimes.Part8.md) · [Part 9](./Zamin.Utilities.DateTimes.Part9.md)

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Utilities.DateTimes.PersianCulture` — اعضای بخش 2/2

- **Kind:** `class`
- **Source:** `Onion/src/1.Utilities/Zamin.Utilities/DateTimes/PersianCulture.cs`

فرهنگ فارسی سفارشی سازی شده

#### Members

##### `GetPersianWeekDayName` (method)

```csharp
public static string GetPersianWeekDayName(this DateTime? dt)
```

گرفتن نام فارسی روزهای هفته

پارامترها:
- dt (DateTime?): ورودی از نوع DateTime?.

مقدار بازگشتی: `string`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `GetPersianWeekDayName` (method)

```csharp
public static string GetPersianWeekDayName(this DateTimeOffset? dt, DateTimeOffsetPart dateTimeOffsetPart = DateTimeOffsetPart.IranLocalDateTime)
```

گرفتن نام فارسی روزهای هفته
پارامترها:
- dt: تاریخ و زمان
- dateTimeOffsetPart: کدام جزء این وهله مورد استفاده قرار گیرد؟

مقدار بازگشتی: `string`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `GetPersianWeekDayName` (method)

```csharp
public static string GetPersianWeekDayName(this DateTimeOffset dt, DateTimeOffsetPart dateTimeOffsetPart = DateTimeOffsetPart.IranLocalDateTime)
```

گرفتن نام فارسی روزهای هفته
پارامترها:
- dt: تاریخ و زمان
- dateTimeOffsetPart: کدام جزء این وهله مورد استفاده قرار گیرد؟

مقدار بازگشتی: `string`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `GetPersianYear` (method)

```csharp
public static int GetPersianYear(this DateTime dateTime)
```

Returns the year part of this DateTime localized in Persian calendar.
پارامترها:
- dateTime: The DateTime to extend.
مقدار بازگشتی: An integer between 1 and 9999 representing the year part of this DateTime.

##### `GetPersianYearStartAndEndDates` (method)

```csharp
public static PersianYear GetPersianYearStartAndEndDates(this int persianYear)
```

تاریخ روزهای ابتدا و انتهای سال شمسی را بازگشت می‌دهد

پارامترها:
- persianYear (int): ورودی از نوع int.

مقدار بازگشتی: `PersianYear`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `GetPersianYearStartAndEndDates` (method)

```csharp
public static PersianYear GetPersianYearStartAndEndDates(this DateTime dateTime)
```

سال شمسی معادل را محاسبه کرده و سپس تاریخ روزهای ابتدا و انتهای آن سال شمسی را بازگشت می‌دهد

پارامترها:
- dateTime (DateTime): ورودی از نوع DateTime.

مقدار بازگشتی: `PersianYear`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `GetPersianYearStartAndEndDates` (method)

```csharp
public static PersianYear GetPersianYearStartAndEndDates(this DateTimeOffset dateTimeOffset, DateTimeOffsetPart dateTimeOffsetPart = DateTimeOffsetPart.IranLocalDateTime)
```

سال شمسی معادل را محاسبه کرده و سپس تاریخ روزهای ابتدا و انتهای آن سال شمسی را بازگشت می‌دهد

پارامترها:
- dateTimeOffset (DateTimeOffset): ورودی از نوع DateTimeOffset.
- dateTimeOffsetPart (DateTimeOffsetPart): ورودی اختیاری از نوع DateTimeOffsetPart (دارای مقدار پیش‌فرض).

مقدار بازگشتی: `PersianYear`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `GetPersianMonthStartAndEndDates` (method)

```csharp
public static PersianMonth GetPersianMonthStartAndEndDates(this int persianYear, int persianMonth)
```

تاریخ روزهای ابتدا و انتهای ماه شمسی را بازگشت می‌دهد

پارامترها:
- persianYear (int): ورودی از نوع int.
- persianMonth (int): ورودی از نوع int.

مقدار بازگشتی: `PersianMonth`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `GetPersianMonthStartAndEndDates` (method)

```csharp
public static PersianMonth GetPersianMonthStartAndEndDates(this DateTime dateTime)
```

ماه شمسی معادل را محاسبه کرده و سپس تاریخ روزهای ابتدا و انتهای آن ماه شمسی را بازگشت می‌دهد

پارامترها:
- dateTime (DateTime): ورودی از نوع DateTime.

مقدار بازگشتی: `PersianMonth`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `GetPersianMonthStartAndEndDates` (method)

```csharp
public static PersianMonth GetPersianMonthStartAndEndDates(this DateTimeOffset dateTimeOffset, DateTimeOffsetPart dateTimeOffsetPart = DateTimeOffsetPart.IranLocalDateTime)
```

ماه شمسی معادل را محاسبه کرده و سپس تاریخ روزهای ابتدا و انتهای آن ماه شمسی را بازگشت می‌دهد

پارامترها:
- dateTimeOffset (DateTimeOffset): ورودی از نوع DateTimeOffset.
- dateTimeOffsetPart (DateTimeOffsetPart): ورودی اختیاری از نوع DateTimeOffsetPart (دارای مقدار پیش‌فرض).

مقدار بازگشتی: `PersianMonth`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `GetPersianMonthLastDay` (method)

```csharp
public static int GetPersianMonthLastDay(this int persianYear, int persianMonth)
```

شماره آخرین روز ماه شمسی را بر می‌گرداند
پارامترها:
- persianYear: سال شمسی
- persianMonth: ماه شمسی
مقدار بازگشتی: شماره آخرین روز ماه
