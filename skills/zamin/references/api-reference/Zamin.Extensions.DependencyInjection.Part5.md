# Zamin.Extensions.DependencyInjection (Part 5/7)

مرجع API برای namespace `Zamin.Extensions.DependencyInjection`.

- **Type count (this file):** 2
- **Parts:** [Part 1](./Zamin.Extensions.DependencyInjection.Part1.md) · [Part 2](./Zamin.Extensions.DependencyInjection.Part2.md) · [Part 3](./Zamin.Extensions.DependencyInjection.Part3.md) · [Part 4](./Zamin.Extensions.DependencyInjection.Part4.md) · **Part 5** · [Part 6](./Zamin.Extensions.DependencyInjection.Part6.md) · [Part 7](./Zamin.Extensions.DependencyInjection.Part7.md)

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Extensions.DependencyInjection.PollingPublisherServiceCollectionExtensions`

- **Kind:** `class`
- **Source:** `Extentsions/Events/Zamin.Extensions.Events.PollingPublisher/Zamin.Extensions.Events.PollingPublisher.Dal.Dapper/Extensions/DependencyInjection/PollingPublisherServiceCollectionExtensions.cs;Extentsions/Events/Zamin.Extensions.Events.PollingPublisher/Zamin.Extensions.Events.PollingPublisher/Extensions/DependencyInjection/PollingPublisherServiceCollectionExtensions.cs`

کلاس «PollingPublisherServiceCollectionExtensions» در namespace Zamin.Extensions.DependencyInjection. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/dependency-injection.md#recipe-add-zamin-api-core)

#### Members

##### `AddZaminPollingPublisherDalSql` (method)

```csharp
public static IServiceCollection AddZaminPollingPublisherDalSql(this IServiceCollection services, IConfiguration configuration)
```

متد «AddZaminPollingPublisherDalSql» در PollingPublisherServiceCollectionExtensions. سرویس‌ها/قابلیت مرتبط را به IServiceCollection ثبت می‌کند. گزینه‌های تنظیمات را Configure می‌کند.
پارامترها:
- services (IServiceCollection): مجموعه سرویس‌های DI که باید گسترش یابد.
- configuration (IConfiguration): پیکربندی برنامه برای خواندن تنظیمات.

مقدار بازگشتی: `IServiceCollection`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `AddZaminPollingPublisherDalSql` (method)

```csharp
public static IServiceCollection AddZaminPollingPublisherDalSql(this IServiceCollection services, IConfiguration configuration, string sectionName)
```

متد «AddZaminPollingPublisherDalSql» در PollingPublisherServiceCollectionExtensions. سرویس‌ها/قابلیت مرتبط را به IServiceCollection ثبت می‌کند.
پارامترها:
- services (IServiceCollection): مجموعه سرویس‌های DI که باید گسترش یابد.
- configuration (IConfiguration): پیکربندی برنامه برای خواندن تنظیمات.
- sectionName (string): ورودی از نوع string.

مقدار بازگشتی: `IServiceCollection`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `AddZaminPollingPublisherDalSql` (method)

```csharp
public static IServiceCollection AddZaminPollingPublisherDalSql(this IServiceCollection services, Action<PollingPublisherDalRedisOptions> setupAction)
```

متد «AddZaminPollingPublisherDalSql» در PollingPublisherServiceCollectionExtensions. سرویس‌ها/قابلیت مرتبط را به IServiceCollection ثبت می‌کند. گزینه‌های تنظیمات را Configure می‌کند.
پارامترها:
- services (IServiceCollection): مجموعه سرویس‌های DI که باید گسترش یابد.
- setupAction (Action<PollingPublisherDalRedisOptions>): ورودی از نوع Action<PollingPublisherDalRedisOptions>.

مقدار بازگشتی: `IServiceCollection`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `AddZaminPollingPublisher` (method)

```csharp
public static IServiceCollection AddZaminPollingPublisher(this IServiceCollection services, IConfiguration configuration)
```

متد «AddZaminPollingPublisher» در PollingPublisherServiceCollectionExtensions. سرویس‌ها/قابلیت مرتبط را به IServiceCollection ثبت می‌کند. گزینه‌های تنظیمات را Configure می‌کند.
پارامترها:
- services (IServiceCollection): مجموعه سرویس‌های DI که باید گسترش یابد.
- configuration (IConfiguration): پیکربندی برنامه برای خواندن تنظیمات.

مقدار بازگشتی: `IServiceCollection`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `AddZaminPollingPublisher` (method)

```csharp
public static IServiceCollection AddZaminPollingPublisher(this IServiceCollection services, IConfiguration configuration, string sectionName)
```

متد «AddZaminPollingPublisher» در PollingPublisherServiceCollectionExtensions. سرویس‌ها/قابلیت مرتبط را به IServiceCollection ثبت می‌کند.
پارامترها:
- services (IServiceCollection): مجموعه سرویس‌های DI که باید گسترش یابد.
- configuration (IConfiguration): پیکربندی برنامه برای خواندن تنظیمات.
- sectionName (string): ورودی از نوع string.

مقدار بازگشتی: `IServiceCollection`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `AddZaminPollingPublisher` (method)

```csharp
public static IServiceCollection AddZaminPollingPublisher(this IServiceCollection services, Action<PollingPublisherOptions> setupAction)
```

متد «AddZaminPollingPublisher» در PollingPublisherServiceCollectionExtensions. سرویس‌ها/قابلیت مرتبط را به IServiceCollection ثبت می‌کند. گزینه‌های تنظیمات را Configure می‌کند.
پارامترها:
- services (IServiceCollection): مجموعه سرویس‌های DI که باید گسترش یابد.
- setupAction (Action<PollingPublisherOptions>): ورودی از نوع Action<PollingPublisherOptions>.

مقدار بازگشتی: `IServiceCollection`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

### `Zamin.Extensions.DependencyInjection.ProviderExtensions`

- **Kind:** `class`
- **Source:** `Utilities/Auth/ApiAuthentication/Zamin.Utilities.Auth.ApiAuthentication/Extensions/ProviderExtensions.cs`

کلاس «ProviderExtensions» در namespace Zamin.Extensions.DependencyInjection. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/dependency-injection.md#recipe-add-zamin-api-core)

#### Members

##### `AddProviderHttpClient` (method)

```csharp
public static string AddProviderHttpClient(this ProviderOption provider, IServiceCollection services)
```

متد «AddProviderHttpClient» در ProviderExtensions. سرویس‌ها/قابلیت مرتبط را به IServiceCollection ثبت می‌کند.
پارامترها:
- provider (ProviderOption): ورودی از نوع ProviderOption.
- services (IServiceCollection): مجموعه سرویس‌های DI که باید گسترش یابد.

مقدار بازگشتی: `string`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `GetUserInfoClaims` (method)

```csharp
public static async Task<List<Claim>> GetUserInfoClaims(this ProviderOption provider, HttpContext httpContext, string httpClientName)
```

متد «GetUserInfoClaims» در ProviderExtensions. داده یا وضعیت مرتبط را بازیابی می‌کند. handler/سرویس را از DI با GetRequiredService برمی‌دارد. به‌صورت ناهمگام اجرا می‌شود.
پارامترها:
- provider (ProviderOption): ورودی از نوع ProviderOption.
- httpContext (HttpContext): ورودی از نوع HttpContext.
- httpClientName (string): ورودی از نوع string.

مقدار بازگشتی: `Task<List<Claim>>` — نتیجه ناهمگام عملیات.
استثناها (قابل تشخیص از کد):
- ArgumentNullException (throw new)
- ArgumentNullException
پیش‌شرط/وابستگی: سرویس/handler مربوطه باید در DI ثبت شده باشد وگرنه InvalidOperationException رخ می‌دهد

##### `UserInfoEndpointCaller` (method)

```csharp
public static async Task<List<Claim>> UserInfoEndpointCaller(this ProviderOption provider, HttpContext httpContext, HttpClient client, string token)
```

متد «UserInfoEndpointCaller» در ProviderExtensions. میان‌افزار یا پیکربندی pipeline را به اپلیکیشن اضافه می‌کند. handler/سرویس را از DI با GetRequiredService برمی‌دارد. به‌صورت ناهمگام اجرا می‌شود.
پارامترها:
- provider (ProviderOption): ورودی از نوع ProviderOption.
- httpContext (HttpContext): ورودی از نوع HttpContext.
- client (HttpClient): ورودی از نوع HttpClient.
- token (string): ورودی از نوع string.

مقدار بازگشتی: `Task<List<Claim>>` — نتیجه ناهمگام عملیات.
استثناها (قابل تشخیص از کد):
- ArgumentNullException (throw new)
- InvalidOperationException (throw new)
- ArgumentNullException
- InvalidOperationException
پیش‌شرط/وابستگی: سرویس/handler مربوطه باید در DI ثبت شده باشد وگرنه InvalidOperationException رخ می‌دهد

##### `CallUserInfoEndpoint` (method)

```csharp
public static async Task<List<Claim>> CallUserInfoEndpoint(this ProviderOption provider, HttpClient client, string token)
```

متد «CallUserInfoEndpoint» در ProviderExtensions. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد. به‌صورت ناهمگام اجرا می‌شود.
پارامترها:
- provider (ProviderOption): ورودی از نوع ProviderOption.
- client (HttpClient): ورودی از نوع HttpClient.
- token (string): ورودی از نوع string.

مقدار بازگشتی: `Task<List<Claim>>` — نتیجه ناهمگام عملیات.
استثناها (قابل تشخیص از کد):
- Exception (throw new)
