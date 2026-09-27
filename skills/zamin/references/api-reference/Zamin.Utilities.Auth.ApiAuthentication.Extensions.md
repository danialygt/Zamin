# Zamin.Utilities.Auth.ApiAuthentication.Extensions

مرجع API برای namespace `Zamin.Utilities.Auth.ApiAuthentication.Extensions`.

- **Type count (this file):** 1

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Utilities.Auth.ApiAuthentication.Extensions.ClaimsPrincipalExtentions`

- **Kind:** `class`
- **Source:** `Utilities/Auth/ApiAuthentication/Zamin.Utilities.Auth.ApiAuthentication/Extensions/ClaimsPrincipalExtentions.cs`

کلاس «ClaimsPrincipalExtentions» در namespace Zamin.Utilities.Auth.ApiAuthentication.Extensions. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین.

#### Members

##### `HasSubClaim` (method)

```csharp
public static bool HasSubClaim(this ClaimsPrincipal? principal, string userIdentifierClaimType)
```

متد «HasSubClaim» در ClaimsPrincipalExtentions. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- principal (ClaimsPrincipal?): ورودی از نوع ClaimsPrincipal?.
- userIdentifierClaimType (string): ورودی از نوع string.

مقدار بازگشتی: `bool`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `CreateClaimsIdentity` (method)

```csharp
public static ClaimsIdentity CreateClaimsIdentity(this ClaimsPrincipal? principal, List<Claim> claims)
```

متد «CreateClaimsIdentity» در ClaimsPrincipalExtentions. نمونه یا نتیجه جدیدی می‌سازد.
پارامترها:
- principal (ClaimsPrincipal?): ورودی از نوع ClaimsPrincipal?.
- claims (List<Claim>): ورودی از نوع List<Claim>.

مقدار بازگشتی: `ClaimsIdentity`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `ClonePrincipalWithConvertedClaims` (method)

```csharp
public static ClaimsPrincipal? ClonePrincipalWithConvertedClaims(this ClaimsPrincipal? principal, ProviderOption provider)
```

متد «ClonePrincipalWithConvertedClaims» در ClaimsPrincipalExtentions. نمونه یا نتیجه جدیدی می‌سازد.
پارامترها:
- principal (ClaimsPrincipal?): ورودی از نوع ClaimsPrincipal?.
- provider (ProviderOption): ورودی از نوع ProviderOption.

مقدار بازگشتی: `ClaimsPrincipal?`.
استثناها (قابل تشخیص از کد):
- ArgumentNullException (throw new)
- ArgumentNullException
