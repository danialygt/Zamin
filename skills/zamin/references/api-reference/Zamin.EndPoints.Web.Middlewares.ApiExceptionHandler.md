# Zamin.EndPoints.Web.Middlewares.ApiExceptionHandler

مرجع API برای namespace `Zamin.EndPoints.Web.Middlewares.ApiExceptionHandler`.

- **Type count (this file):** 4

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.EndPoints.Web.Middlewares.ApiExceptionHandler.ApiError`

- **Kind:** `class`
- **Source:** `Onion/src/4.EndPoints/Zamin.EndPoints.Web/Middlewares/ApiExceptionHandler/ApiError.cs`

کلاس «ApiError» در namespace Zamin.EndPoints.Web.Middlewares.ApiExceptionHandler. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین.

#### Members

##### `Id` (property)

```csharp
public string Id { get; set; }
```

پراپرتی «Id» از نوع `string` در ApiError. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `Status` (property)

```csharp
public short Status { get; set; }
```

پراپرتی «Status» از نوع `short` در ApiError. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `Code` (property)

```csharp
public string Code { get; set; }
```

پراپرتی «Code» از نوع `string` در ApiError. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `Links` (property)

```csharp
public string Links { get; set; }
```

پراپرتی «Links» از نوع `string` در ApiError. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `Title` (property)

```csharp
public string Title { get; set; }
```

پراپرتی «Title» از نوع `string` در ApiError. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `Detail` (property)

```csharp
public string Detail { get; set; }
```

پراپرتی «Detail» از نوع `string` در ApiError. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

### `Zamin.EndPoints.Web.Middlewares.ApiExceptionHandler.ApiExceptionMiddleware`

- **Kind:** `class`
- **Source:** `Onion/src/4.EndPoints/Zamin.EndPoints.Web/Middlewares/ApiExceptionHandler/ApiExceptionMiddleware.cs`

کلاس «ApiExceptionMiddleware» در namespace Zamin.EndPoints.Web.Middlewares.ApiExceptionHandler. استثنای دامنه/چارچوب برای اعلام نقض قاعده یا خطای قابل‌کنترل. وابستگی‌های سازنده (DI): ApiExceptionOptions options, RequestDelegate next, ILogger<ApiExceptionMiddleware> logger, IJsonSerializer serializer, ITranslator translator. مرتبط: DI: ApiExceptionOptions options, RequestDelegate next, ILogger<ApiExceptionMiddleware> logger, IJsonSerializer serializer, ITranslator translator.

#### Members

##### `.ctor` (constructor)

```csharp
public ApiExceptionMiddleware(ApiExceptionOptions options, RequestDelegate next,
            ILogger<ApiExceptionMiddleware> logger, IJsonSerializer serializer,ITranslator translator
            )
```

سازنده ApiExceptionMiddleware. پارامترها از طریق تزریق وابستگی تأمین می‌شوند. پارامترها:
- options (ApiExceptionOptions): ورودی از نوع ApiExceptionOptions.
- next (RequestDelegate): ورودی از نوع RequestDelegate.
- logger (ILogger<ApiExceptionMiddleware>): لاگر برای ثبت رویدادها و خطاها.
- serializer (IJsonSerializer): ورودی از نوع IJsonSerializer.
- translator (ITranslator): ورودی از نوع ITranslator.
پیش‌شرط: وابستگی‌ها/مقادیر ورودی باید معتبر باشند تا فیلدهای داخلی به‌درستی مقداردهی شوند.

##### `Invoke` (method)

```csharp
public async Task Invoke(HttpContext context)
```

متد «Invoke» در ApiExceptionMiddleware. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد. خطاها را در بلوک try/catch مدیریت می‌کند. به‌صورت ناهمگام اجرا می‌شود.
پارامترها:
- context (HttpContext): ورودی از نوع HttpContext.

مقدار بازگشتی: `Task` — عملیات ناهمگام بدون نتیجه داده‌ای.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: DI: ApiExceptionOptions options, RequestDelegate next, ILogger<ApiExceptionMiddleware> logger, IJsonSerializer serializer, ITranslator translator

### `Zamin.EndPoints.Web.Middlewares.ApiExceptionHandler.ApiExceptionMiddlewareExtensions`

- **Kind:** `class`
- **Source:** `Onion/src/4.EndPoints/Zamin.EndPoints.Web/Middlewares/ApiExceptionHandler/ApiExceptionMiddlewareExtensions.cs`

کلاس «ApiExceptionMiddlewareExtensions» در namespace Zamin.EndPoints.Web.Middlewares.ApiExceptionHandler. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

#### Members

##### `UseApiExceptionHandler` (method)

```csharp
public static IApplicationBuilder UseApiExceptionHandler(this IApplicationBuilder builder)
```

متد «UseApiExceptionHandler» در ApiExceptionMiddlewareExtensions. میان‌افزار یا پیکربندی pipeline را به اپلیکیشن اضافه می‌کند.
پارامترها:
- builder (IApplicationBuilder): ورودی از نوع IApplicationBuilder.

مقدار بازگشتی: `IApplicationBuilder`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `UseApiExceptionHandler` (method)

```csharp
public static IApplicationBuilder UseApiExceptionHandler(this IApplicationBuilder builder,
            Action<ApiExceptionOptions> configureOptions)
```

متد «UseApiExceptionHandler» در ApiExceptionMiddlewareExtensions. میان‌افزار یا پیکربندی pipeline را به اپلیکیشن اضافه می‌کند.
پارامترها:
- builder (IApplicationBuilder): ورودی از نوع IApplicationBuilder.
- configureOptions (Action<ApiExceptionOptions>): ورودی از نوع Action<ApiExceptionOptions>.

مقدار بازگشتی: `IApplicationBuilder`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

### `Zamin.EndPoints.Web.Middlewares.ApiExceptionHandler.ApiExceptionOptions`

- **Kind:** `class`
- **Source:** `Onion/src/4.EndPoints/Zamin.EndPoints.Web/Middlewares/ApiExceptionHandler/ApiExceptionOptions.cs`

کلاس «ApiExceptionOptions» در namespace Zamin.EndPoints.Web.Middlewares.ApiExceptionHandler. مدل تنظیمات قابل بایند شدن از configuration.

#### Members

##### `AddResponseDetails` (property)

```csharp
public Action<HttpContext, Exception, ApiError> AddResponseDetails { get; set; }
```

پراپرتی «AddResponseDetails» از نوع `Action<HttpContext, Exception, ApiError>` در ApiExceptionOptions. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `DetermineLogLevel` (property)

```csharp
public Func<Exception, LogLevel> DetermineLogLevel { get; set; }
```

پراپرتی «DetermineLogLevel» از نوع `Func<Exception, LogLevel>` در ApiExceptionOptions. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.
