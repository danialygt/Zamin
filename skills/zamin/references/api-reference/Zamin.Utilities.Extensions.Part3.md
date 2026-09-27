# Zamin.Utilities.Extensions (Part 3/4)

مرجع API برای namespace `Zamin.Utilities.Extensions`.

- **Type count (this file):** 1
- **Parts:** [Part 1](./Zamin.Utilities.Extensions.Part1.md) · [Part 2](./Zamin.Utilities.Extensions.Part2.md) · **Part 3** · [Part 4](./Zamin.Utilities.Extensions.Part4.md)

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Utilities.Extensions.StringExtensions`

- **Kind:** `class`
- **Source:** `Onion/src/1.Utilities/Zamin.Utilities/Extensions/StringExtensions.cs`

کلاس «StringExtensions» در namespace Zamin.Utilities.Extensions. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

#### Members

##### `ArabicYeChar` (field)

```csharp
public const char ArabicYeChar = (char)1610;
```

فیلد «ArabicYeChar» در StringExtensions با امضای `public const char ArabicYeChar = (char)1610;`. برای نگهداری وضعیت داخلی/قابل‌دسترس نوع استفاده می‌شود.

##### `PersianYeChar` (field)

```csharp
public const char PersianYeChar = (char)1740;
```

فیلد «PersianYeChar» در StringExtensions با امضای `public const char PersianYeChar = (char)1740;`. برای نگهداری وضعیت داخلی/قابل‌دسترس نوع استفاده می‌شود.

##### `ArabicKeChar` (field)

```csharp
public const char ArabicKeChar = (char)1603;
```

فیلد «ArabicKeChar» در StringExtensions با امضای `public const char ArabicKeChar = (char)1603;`. برای نگهداری وضعیت داخلی/قابل‌دسترس نوع استفاده می‌شود.

##### `PersianKeChar` (field)

```csharp
public const char PersianKeChar = (char)1705;
```

فیلد «PersianKeChar» در StringExtensions با امضای `public const char PersianKeChar = (char)1705;`. برای نگهداری وضعیت داخلی/قابل‌دسترس نوع استفاده می‌شود.

##### `ApplyCorrectYeKe` (method)

```csharp
public static string ApplyCorrectYeKe(this object data)
```

متد «ApplyCorrectYeKe» در StringExtensions. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- data (object): ورودی از نوع object.

مقدار بازگشتی: `string`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `ApplyCorrectYeKe` (method)

```csharp
public static string ApplyCorrectYeKe(this string data)
```

متد «ApplyCorrectYeKe» در StringExtensions. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- data (string): ورودی از نوع string.

مقدار بازگشتی: `string`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `ToSafeLong` (method)

```csharp
public static long ToSafeLong(this string input, long replacement = long.MinValue)
```

متد «ToSafeLong» در StringExtensions. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- input (string): مقدار مورد بررسی/ورود.
- replacement (long): ورودی اختیاری از نوع long (دارای مقدار پیش‌فرض).

مقدار بازگشتی: `long`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `ToSafeNullableLong` (method)

```csharp
public static long? ToSafeNullableLong(this string input)
```

متد «ToSafeNullableLong» در StringExtensions. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- input (string): مقدار مورد بررسی/ورود.

مقدار بازگشتی: `long?`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `ToSafeInt` (method)

```csharp
public static int ToSafeInt(this string input, int replacement = int.MinValue)
```

متد «ToSafeInt» در StringExtensions. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- input (string): مقدار مورد بررسی/ورود.
- replacement (int): ورودی اختیاری از نوع int (دارای مقدار پیش‌فرض).

مقدار بازگشتی: `int`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `ToSafeNullableInt` (method)

```csharp
public static int? ToSafeNullableInt(this string input)
```

متد «ToSafeNullableInt» در StringExtensions. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- input (string): مقدار مورد بررسی/ورود.

مقدار بازگشتی: `int?`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `ToStringOrEmpty` (method)

```csharp
public static string ToStringOrEmpty(this string? input)
```

متد «ToStringOrEmpty» در StringExtensions. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- input (string?): مقدار مورد بررسی/ورود.

مقدار بازگشتی: `string`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `ToUnderscoreCase` (method)

```csharp
public static string ToUnderscoreCase(this string input)
```

متد «ToUnderscoreCase» در StringExtensions. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- input (string): مقدار مورد بررسی/ورود.

مقدار بازگشتی: `string`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `ToByteArray` (method)

```csharp
public static byte[] ToByteArray(this string input)
```

متد «ToByteArray» در StringExtensions. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- input (string): مقدار مورد بررسی/ورود.

مقدار بازگشتی: `byte[]`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `FromByteArray` (method)

```csharp
public static string FromByteArray(this byte[] input)
```

متد «FromByteArray» در StringExtensions. نمونه یا نتیجه جدیدی می‌سازد.
بدون پارامتر ورودی.
مقدار بازگشتی: `string`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `ToNumeric` (method)

```csharp
public static string ToNumeric(this int value)
```

متد «ToNumeric» در StringExtensions. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- value (int): مقدار مورد بررسی/ورود.

مقدار بازگشتی: `string`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `ToCurrency` (method)

```csharp
public static string ToCurrency(this int value)
```

متد «ToCurrency» در StringExtensions. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- value (int): مقدار مورد بررسی/ورود.

مقدار بازگشتی: `string`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `En2Fa` (method)

```csharp
public static string En2Fa(this string str)
```

متد «En2Fa» در StringExtensions. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- str (string): ورودی از نوع string.

مقدار بازگشتی: `string`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `Fa2En` (method)

```csharp
public static string Fa2En(this string str)
```

متد «Fa2En» در StringExtensions. تبدیل/نرمال‌سازی داده را طبق نام متد انجام می‌دهد.
پارامترها:
- str (string): ورودی از نوع string.

مقدار بازگشتی: `string`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
