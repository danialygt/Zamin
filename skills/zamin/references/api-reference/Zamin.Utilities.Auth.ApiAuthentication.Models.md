# Zamin.Utilities.Auth.ApiAuthentication.Models

مرجع API برای namespace `Zamin.Utilities.Auth.ApiAuthentication.Models`.

- **Type count (this file):** 1

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Utilities.Auth.ApiAuthentication.Models.ClaimCacheModel`

- **Kind:** `class`
- **Source:** `Utilities/Auth/ApiAuthentication/Zamin.Utilities.Auth.ApiAuthentication/Models/ClaimCacheModel.cs`

کلاس «ClaimCacheModel» در namespace Zamin.Utilities.Auth.ApiAuthentication.Models. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین. وابستگی‌های سازنده (DI): string type, string value, string? valueType, string? issuer, string? originalIssuer, ClaimsIdentity? subject. اتریبیوت‌ها: Obsolete("این کلاس deprecated شده است. از تنظیمات استاندارد ASP.NET Core برای Authentication استفاده کنید."). مرتبط: DI: string type, string value, string? valueType, string? issuer, string? originalIssuer.

#### Members

##### `Type` (property)

```csharp
public string Type { get; set; }
```

پراپرتی «Type» از نوع `string` در ClaimCacheModel. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `Value` (property)

```csharp
public string Value { get; set; }
```

پراپرتی «Value» از نوع `string` در ClaimCacheModel. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `ValueType` (property)

```csharp
public string? ValueType { get; set; }
```

پراپرتی «ValueType» از نوع `string?` در ClaimCacheModel. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `Issuer` (property)

```csharp
public string? Issuer { get; set; }
```

پراپرتی «Issuer» از نوع `string?` در ClaimCacheModel. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `OriginalIssuer` (property)

```csharp
public string? OriginalIssuer { get; set; }
```

پراپرتی «OriginalIssuer» از نوع `string?` در ClaimCacheModel. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `Subject` (property)

```csharp
public ClaimsIdentity? Subject { get; set; }
```

پراپرتی «Subject» از نوع `ClaimsIdentity?` در ClaimCacheModel. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `.ctor` (constructor)

```csharp
public ClaimCacheModel()
```

سازنده ClaimCacheModel. بدون پارامتر؛ معمولاً برای ORM، serialization یا مقداردهی اولیه محافظت‌شده استفاده می‌شود.

##### `.ctor` (constructor)

```csharp
public ClaimCacheModel(string type, string value, string? valueType, string? issuer, string? originalIssuer, ClaimsIdentity? subject)
```

سازنده ClaimCacheModel. برای ایجاد نمونه با مقادیر اولیه‌ی مشخص. پارامترها:
- type (string): ورودی از نوع string.
- value (string): مقدار مورد بررسی/ورود.
- valueType (string?): ورودی از نوع string?.
- issuer (string?): ورودی از نوع string?.
- originalIssuer (string?): ورودی از نوع string?.
- subject (ClaimsIdentity?): ورودی از نوع ClaimsIdentity?.

##### `FromClaim` (method)

```csharp
public static ClaimCacheModel FromClaim(Claim claim)
```

متد «FromClaim» در ClaimCacheModel. نمونه یا نتیجه جدیدی می‌سازد.
پارامترها:
- claim (Claim): ورودی از نوع Claim.

مقدار بازگشتی: `ClaimCacheModel`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: DI: string type, string value, string? valueType, string? issuer, string? originalIssuer

##### `ToClaim` (method)

```csharp
public Claim ToClaim()
```

متد «ToClaim» در ClaimCacheModel. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
بدون پارامتر ورودی.
مقدار بازگشتی: `Claim`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: DI: string type, string value, string? valueType, string? issuer, string? originalIssuer
