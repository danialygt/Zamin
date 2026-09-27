# Zamin.Extensions.DependencyInjection (Part 7/7)

مرجع API برای namespace `Zamin.Extensions.DependencyInjection`.

- **Type count (this file):** 4
- **Parts:** [Part 1](./Zamin.Extensions.DependencyInjection.Part1.md) · [Part 2](./Zamin.Extensions.DependencyInjection.Part2.md) · [Part 3](./Zamin.Extensions.DependencyInjection.Part3.md) · [Part 4](./Zamin.Extensions.DependencyInjection.Part4.md) · [Part 5](./Zamin.Extensions.DependencyInjection.Part5.md) · [Part 6](./Zamin.Extensions.DependencyInjection.Part6.md) · **Part 7**

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Extensions.DependencyInjection.SerilogServiceCollectionExtensions`

- **Kind:** `class`
- **Source:** `Utilities/SerilogRegistration/Zamin.Utilities.SerilogRegistration/Extensions/DependencyInjection/SerilogServiceCollectionExtensions.cs`

کلاس «SerilogServiceCollectionExtensions» در namespace Zamin.Extensions.DependencyInjection. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/dependency-injection.md#recipe-add-zamin-api-core)

#### Members

##### `AddZaminSerilog` (method)

```csharp
public static WebApplicationBuilder AddZaminSerilog(this WebApplicationBuilder builder, IConfiguration configuration, params Type[] enrichersType)
```

متد «AddZaminSerilog» در SerilogServiceCollectionExtensions. سرویس‌ها/قابلیت مرتبط را به IServiceCollection ثبت می‌کند. گزینه‌های تنظیمات را Configure می‌کند.
پارامترها:
- builder (WebApplicationBuilder): ورودی از نوع WebApplicationBuilder.
- configuration (IConfiguration): پیکربندی برنامه برای خواندن تنظیمات.

مقدار بازگشتی: `WebApplicationBuilder`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `AddZaminSerilog` (method)

```csharp
public static WebApplicationBuilder AddZaminSerilog(this WebApplicationBuilder builder, IConfiguration configuration, string sectionName, params Type[] enrichersType)
```

متد «AddZaminSerilog» در SerilogServiceCollectionExtensions. سرویس‌ها/قابلیت مرتبط را به IServiceCollection ثبت می‌کند.
پارامترها:
- builder (WebApplicationBuilder): ورودی از نوع WebApplicationBuilder.
- configuration (IConfiguration): پیکربندی برنامه برای خواندن تنظیمات.
- sectionName (string): ورودی از نوع string.

مقدار بازگشتی: `WebApplicationBuilder`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `AddZaminSerilog` (method)

```csharp
public static WebApplicationBuilder AddZaminSerilog(this WebApplicationBuilder builder, Action<SerilogApplicationEnricherOptions> setupAction, params Type[] enrichersType)
```

متد «AddZaminSerilog» در SerilogServiceCollectionExtensions. سرویس‌ها/قابلیت مرتبط را به IServiceCollection ثبت می‌کند. گزینه‌های تنظیمات را Configure می‌کند.
پارامترها:
- builder (WebApplicationBuilder): ورودی از نوع WebApplicationBuilder.
- setupAction (Action<SerilogApplicationEnricherOptions>): ورودی از نوع Action<SerilogApplicationEnricherOptions>.

مقدار بازگشتی: `WebApplicationBuilder`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

### `Zamin.Extensions.DependencyInjection.ServiceCollectionExtensions`

- **Kind:** `class`
- **Source:** `Extentsions/ObjectMappers/Zamin.Extensions.ObjectMappers.Mapster/Zamin.Extensions.ObjectMappers.Mapster/Zamin.Extensions.ObjectMappers.Mapster/Extensions/MapsterMapperServiceCollectionExtensions.cs`

کلاس «ServiceCollectionExtensions» در namespace Zamin.Extensions.DependencyInjection. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/dependency-injection.md#recipe-add-zamin-api-core)

#### Members

##### `AddMapsterMappings` (method)

```csharp
public static IServiceCollection AddMapsterMappings(this IServiceCollection services, params Assembly[] assembliesToScan)
```

متد «AddMapsterMappings» در ServiceCollectionExtensions. سرویس‌ها/قابلیت مرتبط را به IServiceCollection ثبت می‌کند. سرویس‌ها را با lifetime مشخص در DI ثبت می‌کند.
پارامترها:
- services (IServiceCollection): مجموعه سرویس‌های DI که باید گسترش یابد.

مقدار بازگشتی: `IServiceCollection`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

### `Zamin.Extensions.DependencyInjection.SoftwarePartDetectorServiceCollectionExtensions`

- **Kind:** `class`
- **Source:** `Utilities/SoftwarePartDetector/Zamin.Utilities.SoftwarepartDetector/Extensions/DependencyInjection/SoftwarePartDetectorServiceCollectionExtensions.cs`

کلاس «SoftwarePartDetectorServiceCollectionExtensions» در namespace Zamin.Extensions.DependencyInjection. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/dependency-injection.md#recipe-add-zamin-api-core)

#### Members

##### `AddSoftwarePartDetector` (method)

```csharp
public static IServiceCollection AddSoftwarePartDetector(this IServiceCollection services, IConfiguration configuration, string sectionName)
```

متد «AddSoftwarePartDetector» در SoftwarePartDetectorServiceCollectionExtensions. سرویس‌ها/قابلیت مرتبط را به IServiceCollection ثبت می‌کند.
پارامترها:
- services (IServiceCollection): مجموعه سرویس‌های DI که باید گسترش یابد.
- configuration (IConfiguration): پیکربندی برنامه برای خواندن تنظیمات.
- sectionName (string): ورودی از نوع string.

مقدار بازگشتی: `IServiceCollection`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `AddSoftwarePartDetector` (method)

```csharp
public static IServiceCollection AddSoftwarePartDetector(this IServiceCollection services, IConfiguration configuration)
```

متد «AddSoftwarePartDetector» در SoftwarePartDetectorServiceCollectionExtensions. سرویس‌ها/قابلیت مرتبط را به IServiceCollection ثبت می‌کند. گزینه‌های تنظیمات را Configure می‌کند.
پارامترها:
- services (IServiceCollection): مجموعه سرویس‌های DI که باید گسترش یابد.
- configuration (IConfiguration): پیکربندی برنامه برای خواندن تنظیمات.

مقدار بازگشتی: `IServiceCollection`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `AddSoftwarePartDetector` (method)

```csharp
public static IServiceCollection AddSoftwarePartDetector(this IServiceCollection services, Action<SoftwarePartDetectorOptions> setupAction)
```

متد «AddSoftwarePartDetector» در SoftwarePartDetectorServiceCollectionExtensions. سرویس‌ها/قابلیت مرتبط را به IServiceCollection ثبت می‌کند. گزینه‌های تنظیمات را Configure می‌کند.
پارامترها:
- services (IServiceCollection): مجموعه سرویس‌های DI که باید گسترش یابد.
- setupAction (Action<SoftwarePartDetectorOptions>): ورودی از نوع Action<SoftwarePartDetectorOptions>.

مقدار بازگشتی: `IServiceCollection`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

### `Zamin.Extensions.DependencyInjection.UserInfoServiceCollectionExtensions`

- **Kind:** `class`
- **Source:** `Extentsions/UsersManagement/Zamin.Extensions.UsersManagement/Zamin.Extensions.UsersManagement/Extensions/DependencyInjection/UserInfoServiceCollectionExtensions.cs`

کلاس «UserInfoServiceCollectionExtensions» در namespace Zamin.Extensions.DependencyInjection. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/dependency-injection.md#recipe-add-zamin-api-core)

#### Members

##### `AddZaminWebUserInfoService` (method)

```csharp
public static IServiceCollection AddZaminWebUserInfoService(this IServiceCollection services, IConfiguration configuration, bool useFake = false)
```

متد «AddZaminWebUserInfoService» در UserInfoServiceCollectionExtensions. سرویس‌ها/قابلیت مرتبط را به IServiceCollection ثبت می‌کند. گزینه‌های تنظیمات را Configure می‌کند. سرویس‌ها را با lifetime مشخص در DI ثبت می‌کند.
پارامترها:
- services (IServiceCollection): مجموعه سرویس‌های DI که باید گسترش یابد.
- configuration (IConfiguration): پیکربندی برنامه برای خواندن تنظیمات.
- useFake (bool): ورودی اختیاری از نوع bool (دارای مقدار پیش‌فرض).

مقدار بازگشتی: `IServiceCollection`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `AddZaminWebUserInfoService` (method)

```csharp
public static IServiceCollection AddZaminWebUserInfoService(this IServiceCollection services, IConfiguration configuration, string sectionName, bool useFake = false)
```

متد «AddZaminWebUserInfoService» در UserInfoServiceCollectionExtensions. سرویس‌ها/قابلیت مرتبط را به IServiceCollection ثبت می‌کند.
پارامترها:
- services (IServiceCollection): مجموعه سرویس‌های DI که باید گسترش یابد.
- configuration (IConfiguration): پیکربندی برنامه برای خواندن تنظیمات.
- sectionName (string): ورودی از نوع string.
- useFake (bool): ورودی اختیاری از نوع bool (دارای مقدار پیش‌فرض).

مقدار بازگشتی: `IServiceCollection`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `AddZaminWebUserInfoService` (method)

```csharp
public static IServiceCollection AddZaminWebUserInfoService(this IServiceCollection services, Action<UserManagementOptions> setupAction, bool useFake = false)
```

متد «AddZaminWebUserInfoService» در UserInfoServiceCollectionExtensions. سرویس‌ها/قابلیت مرتبط را به IServiceCollection ثبت می‌کند. گزینه‌های تنظیمات را Configure می‌کند. سرویس‌ها را با lifetime مشخص در DI ثبت می‌کند.
پارامترها:
- services (IServiceCollection): مجموعه سرویس‌های DI که باید گسترش یابد.
- setupAction (Action<UserManagementOptions>): ورودی از نوع Action<UserManagementOptions>.
- useFake (bool): ورودی اختیاری از نوع bool (دارای مقدار پیش‌فرض).

مقدار بازگشتی: `IServiceCollection`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
