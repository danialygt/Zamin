# Zamin.Utilities.DateTimes (Part 4/9)

مرجع API برای namespace `Zamin.Utilities.DateTimes`.

- **Type count (this file):** 1
- **Parts:** [Part 1](./Zamin.Utilities.DateTimes.Part1.md) · [Part 2](./Zamin.Utilities.DateTimes.Part2.md) · [Part 3](./Zamin.Utilities.DateTimes.Part3.md) · **Part 4** · [Part 5](./Zamin.Utilities.DateTimes.Part5.md) · [Part 6](./Zamin.Utilities.DateTimes.Part6.md) · [Part 7](./Zamin.Utilities.DateTimes.Part7.md) · [Part 8](./Zamin.Utilities.DateTimes.Part8.md) · [Part 9](./Zamin.Utilities.DateTimes.Part9.md)

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Utilities.DateTimes.PersianCulture` — اعضای بخش 1/2

- **Kind:** `class`
- **Source:** `Onion/src/1.Utilities/Zamin.Utilities/DateTimes/PersianCulture.cs`

فرهنگ فارسی سفارشی سازی شده

#### Members

##### `PersianDayWeekNames` (field)

```csharp
public static readonly IDictionary<DayOfWeek, string> PersianDayWeekNames = new Dictionary<DayOfWeek, string>
    // … (بدنه/initializer کامل در enriched JSON)
```

معادل فارسی روزهای هفته میلادی

##### `PersianMonthDayNumberNames` (field)

```csharp
public static readonly IDictionary<int, string> PersianMonthDayNumberNames = new Dictionary<int, string>
    // … (بدنه/initializer کامل در enriched JSON)
```

عدد به حروف روزهای شمسی

##### `PersianMonthNames` (field)

```csharp
public static readonly IDictionary<int, string> PersianMonthNames = new Dictionary<int, string>
    // … (بدنه/initializer کامل در enriched JSON)
```

نام فارسی ماه‌های شمسی

##### `Instance` (property)

```csharp
public static CultureInfo Instance { get; }
```

وهله‌ی یکتای فرهنگ فارسی سفارشی سازی شده

##### `GetPersianDayOfMonth` (method)

```csharp
public static int GetPersianDayOfMonth(this DateTime dateTime)
```

Returns the day-of-month part of this DateTime localized in Persian calendar.
پارامترها:
- dateTime: The DateTime to extend.
مقدار بازگشتی: An integer between 1 and 31 representing the day-of-month part of this DateTime.

##### `GetPersianMonth` (method)

```csharp
public static int GetPersianMonth(this DateTime dateTime)
```

Returns the month part of this DateTime localized in Persian calendar.
پارامترها:
- dateTime: The DateTime to extend.
مقدار بازگشتی: An integer between 1 and 12 representing the month part of this DateTime.

##### `GetPersianMonthDayNumberName` (method)

```csharp
public static string GetPersianMonthDayNumberName(this int dayNumber)
```

عدد به حروف روزهای شمسی

پارامترها:
- dayNumber (int): ورودی از نوع int.

مقدار بازگشتی: `string`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `GetPersianMonthName` (method)

```csharp
public static string GetPersianMonthName(this int monthNumber)
```

نام فارسی ماه‌های شمسی

پارامترها:
- monthNumber (int): ورودی از نوع int.

مقدار بازگشتی: `string`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `GetPersianWeekDayName` (method)

```csharp
public static string GetPersianWeekDayName(this DayOfWeek dayOfWeek)
```

دریافت معادل فارسی نام روز هفته‌ی میلادی

پارامترها:
- dayOfWeek (DayOfWeek): ورودی از نوع DayOfWeek.

مقدار بازگشتی: `string`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `GetPersianWeekDayName` (method)

```csharp
public static string GetPersianWeekDayName(int persianYear, int persianMonth, int persianDay)
```

گرفتن نام فارسی روزهای هفته

پارامترها:
- persianYear (int): ورودی از نوع int.
- persianMonth (int): ورودی از نوع int.
- persianDay (int): ورودی از نوع int.

مقدار بازگشتی: `string`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `GetPersianWeekDayName` (method)

```csharp
public static string GetPersianWeekDayName(this DateTime dt)
```

گرفتن نام فارسی روزهای هفته

پارامترها:
- dt (DateTime): ورودی از نوع DateTime.

مقدار بازگشتی: `string`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
