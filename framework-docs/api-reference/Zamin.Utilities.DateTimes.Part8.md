# Zamin.Utilities.DateTimes (Part 8/9)

مرجع API برای namespace `Zamin.Utilities.DateTimes`.

- **Type count (this file):** 4
- **Parts:** [Part 1](./Zamin.Utilities.DateTimes.Part1.md) · [Part 2](./Zamin.Utilities.DateTimes.Part2.md) · [Part 3](./Zamin.Utilities.DateTimes.Part3.md) · [Part 4](./Zamin.Utilities.DateTimes.Part4.md) · [Part 5](./Zamin.Utilities.DateTimes.Part5.md) · [Part 6](./Zamin.Utilities.DateTimes.Part6.md) · [Part 7](./Zamin.Utilities.DateTimes.Part7.md) · **Part 8** · [Part 9](./Zamin.Utilities.DateTimes.Part9.md)

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Utilities.DateTimes.PersianDay`

- **Kind:** `class`
- **Source:** `Onion/src/1.Utilities/Zamin.Utilities/DateTimes/PersianDay.cs`

اجزای روز شمسی

#### Members

##### `Year` (property)

```csharp
public int Year { set; get; }
```

سال شمسی

##### `Month` (property)

```csharp
public int Month { set; get; }
```

ماه شمسی

##### `Day` (property)

```csharp
public int Day { set; get; }
```

روز شمسی

##### `.ctor` (constructor)

```csharp
public PersianDay()
```

اجزای روز شمسی

##### `.ctor` (constructor)

```csharp
public PersianDay(int year, int month, int day)
```

اجزای روز شمسی

پارامترها:
- year (int): ورودی از نوع int.
- month (int): ورودی از نوع int.
- day (int): ورودی از نوع int.

##### `ToString` (method)

```csharp
public override string ToString()
```

ToString()

مقدار بازگشتی: `string`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: DI: int year, int month, int day

##### `Equals` (method)

```csharp
public override bool Equals(object obj)
```

Equals
پارامترها:
- obj: (بدون توضیح)

مقدار بازگشتی: `bool`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: DI: int year, int month, int day

##### `GetHashCode` (method)

```csharp
public override int GetHashCode()
```

متد «GetHashCode» در PersianDay. داده یا وضعیت مرتبط را بازیابی می‌کند.
بدون پارامتر ورودی.
مقدار بازگشتی: `int`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: DI: int year, int month, int day

### `Zamin.Utilities.DateTimes.PersianMonth`

- **Kind:** `class`
- **Source:** `Onion/src/1.Utilities/Zamin.Utilities/DateTimes/PersianMonth.cs`

اجزای ماه شمسی

#### Members

##### `StartDate` (property)

```csharp
public DateTime StartDate { set; get; }
```

اولین روز ماه شمسی

##### `EndDate` (property)

```csharp
public DateTime EndDate { set; get; }
```

آخرین روز ماه شمسی

### `Zamin.Utilities.DateTimes.PersianNumbersUtils`

- **Kind:** `class`
- **Source:** `Onion/src/1.Utilities/Zamin.Utilities/DateTimes/PersianNumbersUtils.cs`

Converts English digits of a given number to their equivalent Persian digits.

#### Members

##### `ToPersianNumbers` (method)

```csharp
public static string ToPersianNumbers(this int number, string format = "")
```

Converts English digits of a given number to their equivalent Persian digits.

پارامترها:
- number (int): ورودی از نوع int.
- format (string): ورودی اختیاری از نوع string (دارای مقدار پیش‌فرض).

مقدار بازگشتی: `string`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `ToPersianNumbers` (method)

```csharp
public static string ToPersianNumbers(this long number, string format = "")
```

Converts English digits of a given number to their equivalent Persian digits.

پارامترها:
- number (long): ورودی از نوع long.
- format (string): ورودی اختیاری از نوع string (دارای مقدار پیش‌فرض).

مقدار بازگشتی: `string`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `ToPersianNumbers` (method)

```csharp
public static string ToPersianNumbers(this int? number, string format = "")
```

Converts English digits of a given number to their equivalent Persian digits.

پارامترها:
- number (int?): ورودی از نوع int?.
- format (string): ورودی اختیاری از نوع string (دارای مقدار پیش‌فرض).

مقدار بازگشتی: `string`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `ToPersianNumbers` (method)

```csharp
public static string ToPersianNumbers(this long? number, string format = "")
```

Converts English digits of a given number to their equivalent Persian digits.

پارامترها:
- number (long?): ورودی از نوع long?.
- format (string): ورودی اختیاری از نوع string (دارای مقدار پیش‌فرض).

مقدار بازگشتی: `string`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `ToPersianNumbers` (method)

```csharp
public static string ToPersianNumbers(this string data)
```

Converts English digits of a given string to their equivalent Persian digits.
پارامترها:
- data: English number

مقدار بازگشتی: `string`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `ToEnglishNumbers` (method)

```csharp
public static string ToEnglishNumbers(this string data)
```

Converts Persian and Arabic digits of a given string to their equivalent English digits.
پارامترها:
- data: Persian number

مقدار بازگشتی: `string`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

### `Zamin.Utilities.DateTimes.PersianYear`

- **Kind:** `class`
- **Source:** `Onion/src/1.Utilities/Zamin.Utilities/DateTimes/PersianYear.cs`

اجزای سال شمسی

#### Members

##### `StartDate` (property)

```csharp
public DateTime StartDate { set; get; }
```

اولین روز سال شمسی

##### `EndDate` (property)

```csharp
public DateTime EndDate { set; get; }
```

آخرین روز سال شمسی
