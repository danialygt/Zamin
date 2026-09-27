# Zamin.Utilities.DateTimes (Part 2/9)

مرجع API برای namespace `Zamin.Utilities.DateTimes`.

- **Type count (this file):** 1
- **Parts:** [Part 1](./Zamin.Utilities.DateTimes.Part1.md) · **Part 2** · [Part 3](./Zamin.Utilities.DateTimes.Part3.md) · [Part 4](./Zamin.Utilities.DateTimes.Part4.md) · [Part 5](./Zamin.Utilities.DateTimes.Part5.md) · [Part 6](./Zamin.Utilities.DateTimes.Part6.md) · [Part 7](./Zamin.Utilities.DateTimes.Part7.md) · [Part 8](./Zamin.Utilities.DateTimes.Part8.md) · [Part 9](./Zamin.Utilities.DateTimes.Part9.md)

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Utilities.DateTimes.DateTimeUtils`

- **Kind:** `class`
- **Source:** `Onion/src/1.Utilities/Zamin.Utilities/DateTimes/DateTimeUtils.cs`

متدهای کمکی جهت کار با تاریخ میلادی

#### Members

##### `IranStandardTime` (field)

```csharp
public static readonly TimeZoneInfo IranStandardTime;
```

Iran Standard Time

##### `Epoch` (field)

```csharp
public static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
```

Epoch represented as DateTime

##### `GetAge` (method)

```csharp
public static int GetAge(this DateTimeOffset birthday, DateTime comparisonBase, DateTimeOffsetPart dateTimeOffsetPart = DateTimeOffsetPart.IranLocalDateTime)
```

محاسبه سن
پارامترها:
- birthday: تاریخ تولد
- comparisonBase: مبنای محاسبه مانند هم اکنون
- dateTimeOffsetPart: کدام جزء این وهله مورد استفاده قرار گیرد؟
مقدار بازگشتی: سن

##### `GetAge` (method)

```csharp
public static int GetAge(this DateTimeOffset birthday)
```

محاسبه سن مبنای محاسبه هم اکنون
پارامترها:
- birthday: تاریخ تولد
مقدار بازگشتی: سن

##### `GetAge` (method)

```csharp
public static int GetAge(this DateTime birthday, DateTime comparisonBase)
```

محاسبه سن
پارامترها:
- birthday: تاریخ تولد
- comparisonBase: مبنای محاسبه مانند هم اکنون
مقدار بازگشتی: سن

##### `GetAge` (method)

```csharp
public static int GetAge(this DateTime birthday)
```

محاسبه سن مبنای محاسبه هم اکنون
پارامترها:
- birthday: تاریخ تولد
مقدار بازگشتی: سن

##### `GetDateTimeOffsetPart` (method)

```csharp
public static DateTime GetDateTimeOffsetPart(
        this DateTimeOffset dateTimeOffset,
        DateTimeOffsetPart dataDateTimeOffsetPart)
```

دریافت جزء زمانی ویژه‌ی این وهله

پارامترها:
- dateTimeOffset (DateTimeOffset): ورودی از نوع DateTimeOffset.
- dataDateTimeOffsetPart (DateTimeOffsetPart): ورودی از نوع DateTimeOffsetPart.

مقدار بازگشتی: `DateTime`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `GetNow` (method)

```csharp
public static DateTime GetNow(this DateTimeKind dataDateTimeKind)
```

بازگشت زمان جاری با توجه به نوع زمان
پارامترها:
- dataDateTimeKind: نوع زمان ورودی
مقدار بازگشتی: هم اکنون

##### `ToIranTimeZoneDateTimeOffset` (method)

```csharp
public static DateTimeOffset ToIranTimeZoneDateTimeOffset(this DateTimeOffset dateTimeOffset)
```

تبدیل منطقه زمانی این وهله به منطقه زمانی ایران

پارامترها:
- dateTimeOffset (DateTimeOffset): ورودی از نوع DateTimeOffset.

مقدار بازگشتی: `DateTimeOffset`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `ToIranTimeZoneDateTime` (method)

```csharp
public static DateTime ToIranTimeZoneDateTime(this DateTime dateTime)
```

تبدیل منطقه زمانی این وهله به منطقه زمانی ایران

پارامترها:
- dateTime (DateTime): ورودی از نوع DateTime.

مقدار بازگشتی: `DateTime`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `ToEpochMilliseconds` (method)

```csharp
public static long ToEpochMilliseconds(this DateTime dateTime)
```

Converts a given DateTime to milliseconds from Epoch.
پارامترها:
- dateTime: A given DateTime
مقدار بازگشتی: Milliseconds since Epoch

##### `ToEpochSeconds` (method)

```csharp
public static long ToEpochSeconds(this DateTime dateTime)
```

Converts a given DateTime to seconds from Epoch.
پارامترها:
- dateTime: A given DateTime
مقدار بازگشتی: The Unix time stamp

##### `IsBetween` (method)

```csharp
public static bool IsBetween(this DateTime date, DateTime startDate, DateTime endDate, bool compareTime = false)
```

Checks the given date is between the two provided dates

پارامترها:
- date (DateTime): ورودی از نوع DateTime.
- startDate (DateTime): ورودی از نوع DateTime.
- endDate (DateTime): ورودی از نوع DateTime.
- compareTime (bool): ورودی اختیاری از نوع bool (دارای مقدار پیش‌فرض).

مقدار بازگشتی: `bool`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `IsLastDayOfTheMonth` (method)

```csharp
public static bool IsLastDayOfTheMonth(this DateTime dateTime)
```

Returns whether the given date is the last day of the month

پارامترها:
- dateTime (DateTime): ورودی از نوع DateTime.

مقدار بازگشتی: `bool`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `IsWeekend` (method)

```csharp
public static bool IsWeekend(this DateTime value)
```

Returns whether the given date falls in a weekend

پارامترها:
- value (DateTime): مقدار مورد بررسی/ورود.

مقدار بازگشتی: `bool`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `IsLeapYear` (method)

```csharp
public static bool IsLeapYear(this DateTime value)
```

Determines if a given year is a LeapYear or not.

پارامترها:
- value (DateTime): مقدار مورد بررسی/ورود.

مقدار بازگشتی: `bool`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `ToDateTimeOffset` (method)

```csharp
public static DateTimeOffset ToDateTimeOffset(this DateTime dt, TimeSpan offset)
```

Converts a DateTime to a DateTimeOffset
پارامترها:
- dt: Source DateTime.
- offset: Offset

مقدار بازگشتی: `DateTimeOffset`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `ToDateTimeOffset` (method)

```csharp
public static DateTimeOffset ToDateTimeOffset(this DateTime dt, double offsetInHours = 0)
```

Converts a DateTime to a DateTimeOffset
پارامترها:
- dt: Source DateTime.
- offsetInHours: Offset

مقدار بازگشتی: `DateTimeOffset`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
