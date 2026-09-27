# Zamin.Extensions.UsersManagement.Extensions

مرجع API برای namespace `Zamin.Extensions.UsersManagement.Extensions`.

- **Type count (this file):** 1

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Extensions.UsersManagement.Extensions.ClaimExtensions`

- **Kind:** `class`
- **Source:** `Extentsions/UsersManagement/Zamin.Extensions.UsersManagement/Zamin.Extensions.UsersManagement/Extensions/ClaimExtensions.cs`

کلاس «ClaimExtensions» در namespace Zamin.Extensions.UsersManagement.Extensions. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

#### Members

##### `GetClaim` (method)

```csharp
public static string GetClaim(this ClaimsPrincipal userClaimsPrincipal, string claimType)
```

متد «GetClaim» در ClaimExtensions. داده یا وضعیت مرتبط را بازیابی می‌کند.
پارامترها:
- userClaimsPrincipal (ClaimsPrincipal): ورودی از نوع ClaimsPrincipal.
- claimType (string): ورودی از نوع string.

مقدار بازگشتی: `string`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
