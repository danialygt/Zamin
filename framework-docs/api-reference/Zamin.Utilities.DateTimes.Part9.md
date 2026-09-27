# Zamin.Utilities.DateTimes (Part 9/9)

مرجع API برای namespace `Zamin.Utilities.DateTimes`.

- **Type count (this file):** 3
- **Parts:** [Part 1](./Zamin.Utilities.DateTimes.Part1.md) · [Part 2](./Zamin.Utilities.DateTimes.Part2.md) · [Part 3](./Zamin.Utilities.DateTimes.Part3.md) · [Part 4](./Zamin.Utilities.DateTimes.Part4.md) · [Part 5](./Zamin.Utilities.DateTimes.Part5.md) · [Part 6](./Zamin.Utilities.DateTimes.Part6.md) · [Part 7](./Zamin.Utilities.DateTimes.Part7.md) · [Part 8](./Zamin.Utilities.DateTimes.Part8.md) · **Part 9**

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Utilities.DateTimes.RegexUtils`

- **Kind:** `class`
- **Source:** `Onion/src/1.Utilities/Zamin.Utilities/DateTimes/RegexUtils.cs`

متدهای کمکی مبتنی بر عبارات باقاعده

#### Members

##### `MatchTimeout` (field)

```csharp
public static readonly TimeSpan MatchTimeout = TimeSpan.FromSeconds(3);
```

زمان انقضای پردازش عبارت باقاعده

##### `ContainsFarsi` (method)

```csharp
public static bool ContainsFarsi(this string txt)
```

آیا عبارت مدنظر حاوی حروف و اعداد فارسی است؟

پارامترها:
- txt (string): ورودی از نوع string.

مقدار بازگشتی: `bool`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `ContainsOnlyFarsiLetters` (method)

```csharp
public static bool ContainsOnlyFarsiLetters(this string txt)
```

آیا عبارت مدنظر فقط حاوی حروف فارسی است؟

پارامترها:
- txt (string): ورودی از نوع string.

مقدار بازگشتی: `bool`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `StripHtmlTags` (method)

```csharp
public static string StripHtmlTags(this string text)
```

حذف تگ‌های یک عبارت

پارامترها:
- text (string): ورودی از نوع string.

مقدار بازگشتی: `string`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `WrapInDirectionalDiv` (method)

```csharp
public static string WrapInDirectionalDiv(this string body, string fontFamily = "tahoma", string fontSize = "9pt")
```

اگر متن شما حاوی یک عبارت فارسی باشد آن‌را داخل یک بلاک اچ تی ام ال راست به چپ محصور می‌کند <div style="text-align: right; font-family:{fontFamily}; font-size:{fontSize};" dir="rtl">{body}</div> در غیراینصورت در <div style="text-align: left; font-family:{fontFamily}; font-size:{fontSize};" dir="ltr">{body}</div>

پارامترها:
- body (string): ورودی از نوع string.
- fontFamily (string): ورودی اختیاری از نوع string (دارای مقدار پیش‌فرض).
- fontSize (string): ورودی اختیاری از نوع string (دارای مقدار پیش‌فرض).

مقدار بازگشتی: `string`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `ContainsOnlyPersianNumbers` (method)

```csharp
public static bool ContainsOnlyPersianNumbers(this string text)
```

آیا عبارت مدنظر فقط حاوی اعداد فارسی است؟

پارامترها:
- text (string): ورودی از نوع string.

مقدار بازگشتی: `bool`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

### `Zamin.Utilities.DateTimes.TimeConstants`

- **Kind:** `class`
- **Source:** `Onion/src/1.Utilities/Zamin.Utilities/DateTimes/TimeConstants.cs`

Time Constants

#### Members

##### `Day` (field)

```csharp
public const int Day = 24 * Hour;
```

Day = 24 * Hour

##### `Hour` (field)

```csharp
public const int Hour = 60 * Minute;
```

Hour = 60 * Minute

##### `Minute` (field)

```csharp
public const int Minute = 60 * Second;
```

Minute = 60 * Second

##### `Month` (field)

```csharp
public const int Month = 30 * Day;
```

Month = 30 * Day

##### `Second` (field)

```csharp
public const int Second = 1;
```

Second = 1

### `Zamin.Utilities.DateTimes.UnicodeConstants`

- **Kind:** `class`
- **Source:** `Onion/src/1.Utilities/Zamin.Utilities/DateTimes/UnicodeConstants.cs`

Unicode Constants

#### Members

##### `RleChar` (field)

```csharp
public const char RleChar = (char)0x202B;
```

<summary>

 </summary>

##### `ApplyRle` (method)

```csharp
public static string ApplyRle(this string text)
```

Applies RLE to the text if it contains Persian words.

پارامترها:
- text (string): ورودی از نوع string.

مقدار بازگشتی: `string`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
