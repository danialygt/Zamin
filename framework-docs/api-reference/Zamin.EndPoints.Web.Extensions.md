# Zamin.EndPoints.Web.Extensions

مرجع API برای namespace `Zamin.EndPoints.Web.Extensions`.

- **Type count (this file):** 2

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.EndPoints.Web.Extensions.ClaimExtensions`

- **Kind:** `class`
- **Source:** `Onion/src/4.EndPoints/Zamin.EndPoints.Web/Extentions/ClaimExtensions.cs`

کلاس «ClaimExtensions» در namespace Zamin.EndPoints.Web.Extensions. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/common-recipes.md#recipe-http-context-extensions)

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

### `Zamin.EndPoints.Web.Extensions.HttpContextExtensions`

- **Kind:** `class`
- **Source:** `Onion/src/4.EndPoints/Zamin.EndPoints.Web/Extentions/HttpContextExtentions.cs`

کلاس «HttpContextExtensions» در namespace Zamin.EndPoints.Web.Extensions. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/common-recipes.md#recipe-http-context-extensions)

#### Members

##### `CommandDispatcher` (method)

```csharp
public static ICommandDispatcher CommandDispatcher(this HttpContext httpContext)
```

متد «CommandDispatcher» در HttpContextExtensions. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- httpContext (HttpContext): ورودی از نوع HttpContext.

مقدار بازگشتی: `ICommandDispatcher`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `QueryDispatcher` (method)

```csharp
public static IQueryDispatcher QueryDispatcher(this HttpContext httpContext)
```

متد «QueryDispatcher» در HttpContextExtensions. کوئری/عملیات را به handler مناسب مسیریابی و اجرا می‌کند.
پارامترها:
- httpContext (HttpContext): ورودی از نوع HttpContext.

مقدار بازگشتی: `IQueryDispatcher`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `EventDispatcher` (method)

```csharp
public static IEventDispatcher EventDispatcher(this HttpContext httpContext)
```

متد «EventDispatcher» در HttpContextExtensions. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- httpContext (HttpContext): ورودی از نوع HttpContext.

مقدار بازگشتی: `IEventDispatcher`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `ZaminApplicationContext` (method)

```csharp
public static ZaminServices ZaminApplicationContext(this HttpContext httpContext)
```

متد «ZaminApplicationContext» در HttpContextExtensions. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- httpContext (HttpContext): ورودی از نوع HttpContext.

مقدار بازگشتی: `ZaminServices`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
