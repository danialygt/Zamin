# Zamin.Utilities.Extensions (Part 1/4)

مرجع API برای namespace `Zamin.Utilities.Extensions`.

- **Type count (this file):** 3
- **Parts:** **Part 1** · [Part 2](./Zamin.Utilities.Extensions.Part2.md) · [Part 3](./Zamin.Utilities.Extensions.Part3.md) · [Part 4](./Zamin.Utilities.Extensions.Part4.md)

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Utilities.Extensions.DateTimeExtensions`

- **Kind:** `class`
- **Source:** `Onion/src/1.Utilities/Zamin.Utilities/Extensions/DateTimeExtensions.cs`

کلاس «DateTimeExtensions» در namespace Zamin.Utilities.Extensions. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

#### Members

##### `ToUnixTimeMillisecond` (method)

```csharp
public static long ToUnixTimeMillisecond(this DateTime dateTime, TimeZoneInfo timeZoneInfo)
```

متد «ToUnixTimeMillisecond» در DateTimeExtensions. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- dateTime (DateTime): ورودی از نوع DateTime.
- timeZoneInfo (TimeZoneInfo): ورودی از نوع TimeZoneInfo.

مقدار بازگشتی: `long`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `ToUnixTimeMillisecond` (method)

```csharp
public static long? ToUnixTimeMillisecond(this DateTime? dateTime, TimeZoneInfo timeZoneInfo)
```

متد «ToUnixTimeMillisecond» در DateTimeExtensions. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- dateTime (DateTime?): ورودی از نوع DateTime?.
- timeZoneInfo (TimeZoneInfo): ورودی از نوع TimeZoneInfo.

مقدار بازگشتی: `long?`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `ToDateTime` (method)

```csharp
public static DateTime ToDateTime(this long unixTimeMilliseconds, TimeZoneInfo timeZoneInfo)
```

متد «ToDateTime» در DateTimeExtensions. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- unixTimeMilliseconds (long): ورودی از نوع long.
- timeZoneInfo (TimeZoneInfo): ورودی از نوع TimeZoneInfo.

مقدار بازگشتی: `DateTime`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `ToDateTime` (method)

```csharp
public static DateTime? ToDateTime(this long? unixTimeMilliseconds, TimeZoneInfo timeZoneInfo)
```

متد «ToDateTime» در DateTimeExtensions. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- unixTimeMilliseconds (long?): ورودی از نوع long?.
- timeZoneInfo (TimeZoneInfo): ورودی از نوع TimeZoneInfo.

مقدار بازگشتی: `DateTime?`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `ToLocalUnixTimeMillisecond` (method)

```csharp
public static long ToLocalUnixTimeMillisecond(this DateTime dateTime)
```

متد «ToLocalUnixTimeMillisecond» در DateTimeExtensions. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- dateTime (DateTime): ورودی از نوع DateTime.

مقدار بازگشتی: `long`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `ToLocalUnixTimeMillisecond` (method)

```csharp
public static long? ToLocalUnixTimeMillisecond(this DateTime? dateTime)
```

متد «ToLocalUnixTimeMillisecond» در DateTimeExtensions. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- dateTime (DateTime?): ورودی از نوع DateTime?.

مقدار بازگشتی: `long?`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `ToLocalDateTime` (method)

```csharp
public static DateTime ToLocalDateTime(this long unixTimeMilliseconds)
```

متد «ToLocalDateTime» در DateTimeExtensions. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- unixTimeMilliseconds (long): ورودی از نوع long.

مقدار بازگشتی: `DateTime`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `ToLocalDateTime` (method)

```csharp
public static DateTime? ToLocalDateTime(this long? unixTimeMilliseconds)
```

متد «ToLocalDateTime» در DateTimeExtensions. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- unixTimeMilliseconds (long?): ورودی از نوع long?.

مقدار بازگشتی: `DateTime?`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `ToUtcUnixTimeMillisecond` (method)

```csharp
public static long ToUtcUnixTimeMillisecond(this DateTime dateTime)
```

متد «ToUtcUnixTimeMillisecond» در DateTimeExtensions. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- dateTime (DateTime): ورودی از نوع DateTime.

مقدار بازگشتی: `long`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `ToUtcUnixTimeMillisecond` (method)

```csharp
public static long? ToUtcUnixTimeMillisecond(this DateTime? dateTime)
```

متد «ToUtcUnixTimeMillisecond» در DateTimeExtensions. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- dateTime (DateTime?): ورودی از نوع DateTime?.

مقدار بازگشتی: `long?`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `ToUtcDateTime` (method)

```csharp
public static DateTime ToUtcDateTime(this long unixTimeMilliseconds)
```

متد «ToUtcDateTime» در DateTimeExtensions. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- unixTimeMilliseconds (long): ورودی از نوع long.

مقدار بازگشتی: `DateTime`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `ToUtcDateTime` (method)

```csharp
public static DateTime? ToUtcDateTime(this long? unixTimeMilliseconds)
```

متد «ToUtcDateTime» در DateTimeExtensions. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- unixTimeMilliseconds (long?): ورودی از نوع long?.

مقدار بازگشتی: `DateTime?`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

### `Zamin.Utilities.Extensions.EnumExtensions`

- **Kind:** `class`
- **Source:** `Onion/src/1.Utilities/Zamin.Utilities/Extensions/EnumExtensions.cs`

کلاس «EnumExtensions» در namespace Zamin.Utilities.Extensions. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

#### Members

##### `GetEnumDescription` (method)

```csharp
public static string GetEnumDescription(this Enum enumValue)
```

برای دریافت توضیحات یک ویژگی از enum اگر [Description] داشته باشد از این متد استفاده می‌شود.
پارامترها:
- enumValue: مقداری که قرار است توضحیات آن دریافت شود
مقدار بازگشتی: متن داخل [Description] در صورتی که وجود داشته باشد و در غیراین صورت عنوان enums ارسال شده

### `Zamin.Utilities.Extensions.GuidExtensions`

- **Kind:** `class`
- **Source:** `Onion/src/1.Utilities/Zamin.Utilities/Extensions/GuidExtensions.cs`

کلاس «GuidExtensions» در namespace Zamin.Utilities.Extensions. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

#### Members

##### `IsNullOrEmpty` (method)

```csharp
public static bool IsNullOrEmpty(this Guid? guid)
```

متد «IsNullOrEmpty» در GuidExtensions. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- guid (Guid?): ورودی از نوع Guid?.

مقدار بازگشتی: `bool`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `IsEmpty` (method)

```csharp
public static bool IsEmpty(this Guid guid)
```

متد «IsEmpty» در GuidExtensions. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- guid (Guid): ورودی از نوع Guid.

مقدار بازگشتی: `bool`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
