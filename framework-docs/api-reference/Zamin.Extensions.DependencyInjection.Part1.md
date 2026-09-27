# Zamin.Extensions.DependencyInjection (Part 1/7)

مرجع API برای namespace `Zamin.Extensions.DependencyInjection`.

- **Type count (this file):** 5
- **Parts:** **Part 1** · [Part 2](./Zamin.Extensions.DependencyInjection.Part2.md) · [Part 3](./Zamin.Extensions.DependencyInjection.Part3.md) · [Part 4](./Zamin.Extensions.DependencyInjection.Part4.md) · [Part 5](./Zamin.Extensions.DependencyInjection.Part5.md) · [Part 6](./Zamin.Extensions.DependencyInjection.Part6.md) · [Part 7](./Zamin.Extensions.DependencyInjection.Part7.md)

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Extensions.DependencyInjection.AddApiConfigurationExtensions`

- **Kind:** `class`
- **Source:** `Onion/src/4.EndPoints/Zamin.EndPoints.Web/Extentions/DependencyInjection/AddApiConfigurationExtentions.cs`

کلاس «AddApiConfigurationExtensions» در namespace Zamin.Extensions.DependencyInjection. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/dependency-injection.md#recipe-add-zamin-api-core)

#### Members

##### `AddZaminApiCore` (method)

```csharp
public static IServiceCollection AddZaminApiCore(this IServiceCollection services, params string[] assemblyNamesForLoad)
```

متد «AddZaminApiCore» در AddApiConfigurationExtensions. سرویس‌ها/قابلیت مرتبط را به IServiceCollection ثبت می‌کند.
پارامترها:
- services (IServiceCollection): مجموعه سرویس‌های DI که باید گسترش یابد.

مقدار بازگشتی: `IServiceCollection`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `UseZaminApiExceptionHandler` (method)

```csharp
public static void UseZaminApiExceptionHandler(this IApplicationBuilder app)
```

متد «UseZaminApiExceptionHandler» در AddApiConfigurationExtensions. میان‌افزار یا پیکربندی pipeline را به اپلیکیشن اضافه می‌کند.
پارامترها:
- app (IApplicationBuilder): ورودی از نوع IApplicationBuilder.

مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

### `Zamin.Extensions.DependencyInjection.AddApplicationServicesExtensions`

- **Kind:** `class`
- **Source:** `Onion/src/4.EndPoints/Zamin.EndPoints.Web/Extentions/DependencyInjection/AddApplicationServicesExtentions.cs`

کلاس «AddApplicationServicesExtensions» در namespace Zamin.Extensions.DependencyInjection. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/dependency-injection.md#recipe-add-zamin-api-core)

#### Members

##### `AddZaminApplicationServices` (method)

```csharp
public static IServiceCollection AddZaminApplicationServices(this IServiceCollection services,
                                                                 IEnumerable<Assembly> assembliesForSearch)
```

متد «AddZaminApplicationServices» در AddApplicationServicesExtensions. سرویس‌ها/قابلیت مرتبط را به IServiceCollection ثبت می‌کند.
پارامترها:
- services (IServiceCollection): مجموعه سرویس‌های DI که باید گسترش یابد.
- assembliesForSearch (IEnumerable<Assembly>): ورودی از نوع IEnumerable<Assembly>.

مقدار بازگشتی: `IServiceCollection`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

### `Zamin.Extensions.DependencyInjection.AddDataAccessExtentsions`

- **Kind:** `class`
- **Source:** `Onion/src/4.EndPoints/Zamin.EndPoints.Web/Extentions/DependencyInjection/AddDataAccessExtentsions.cs`

توابع کمکی جهت ثبت نیازمندی‌های لایه داده

- **Recipe:** [الگوی استفاده مرتبط](../patterns/dependency-injection.md#recipe-add-zamin-api-core)

#### Members

##### `AddZaminDataAccess` (method)

```csharp
public static IServiceCollection AddZaminDataAccess(
        this IServiceCollection services,
        IEnumerable<Assembly> assembliesForSearch)
```

متد «AddZaminDataAccess» در AddDataAccessExtentsions. سرویس‌ها/قابلیت مرتبط را به IServiceCollection ثبت می‌کند.
پارامترها:
- services (IServiceCollection): مجموعه سرویس‌های DI که باید گسترش یابد.
- assembliesForSearch (IEnumerable<Assembly>): ورودی از نوع IEnumerable<Assembly>.

مقدار بازگشتی: `IServiceCollection`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `AddRepositories` (method)

```csharp
public static IServiceCollection AddRepositories(this IServiceCollection services,
        IEnumerable<Assembly> assembliesForSearch)
```

متد «AddRepositories» در AddDataAccessExtentsions. سرویس‌ها/قابلیت مرتبط را به IServiceCollection ثبت می‌کند.
پارامترها:
- services (IServiceCollection): مجموعه سرویس‌های DI که باید گسترش یابد.
- assembliesForSearch (IEnumerable<Assembly>): ورودی از نوع IEnumerable<Assembly>.

مقدار بازگشتی: `IServiceCollection`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `AddUnitOfWorks` (method)

```csharp
public static IServiceCollection AddUnitOfWorks(this IServiceCollection services,
        IEnumerable<Assembly> assembliesForSearch)
```

متد «AddUnitOfWorks» در AddDataAccessExtentsions. سرویس‌ها/قابلیت مرتبط را به IServiceCollection ثبت می‌کند.
پارامترها:
- services (IServiceCollection): مجموعه سرویس‌های DI که باید گسترش یابد.
- assembliesForSearch (IEnumerable<Assembly>): ورودی از نوع IEnumerable<Assembly>.

مقدار بازگشتی: `IServiceCollection`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

### `Zamin.Extensions.DependencyInjection.AddZaminServicesExtensions`

- **Kind:** `class`
- **Source:** `Onion/src/4.EndPoints/Zamin.EndPoints.Web/Extentions/DependencyInjection/AddZaminServicesExtentions.cs`

کلاس «AddZaminServicesExtensions» در namespace Zamin.Extensions.DependencyInjection. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/dependency-injection.md#recipe-add-zamin-api-core)

#### Members

##### `AddZaminUntilityServices` (method)

```csharp
public static IServiceCollection AddZaminUntilityServices(
        this IServiceCollection services)
```

متد «AddZaminUntilityServices» در AddZaminServicesExtensions. سرویس‌ها/قابلیت مرتبط را به IServiceCollection ثبت می‌کند. سرویس‌ها را با lifetime مشخص در DI ثبت می‌کند.
پارامترها:
- services (IServiceCollection): مجموعه سرویس‌های DI که باید گسترش یابد.

مقدار بازگشتی: `IServiceCollection`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

### `Zamin.Extensions.DependencyInjection.ApiAuthenticationServiceCollectionExtensions`

- **Kind:** `class`
- **Source:** `Utilities/Auth/ApiAuthentication/Zamin.Utilities.Auth.ApiAuthentication/Extensions/DependencyInjection/ApiAuthenticationServiceCollectionExtensions.cs`

کلاس «ApiAuthenticationServiceCollectionExtensions» در namespace Zamin.Extensions.DependencyInjection. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/dependency-injection.md#recipe-add-zamin-api-core)

#### Members

##### `AddZaminApiAuthentication` (method)

```csharp
public static IServiceCollection AddZaminApiAuthentication(this IServiceCollection services, IConfiguration configuration, string sectionName)
```

متد «AddZaminApiAuthentication» در ApiAuthenticationServiceCollectionExtensions. سرویس‌ها/قابلیت مرتبط را به IServiceCollection ثبت می‌کند.
پارامترها:
- services (IServiceCollection): مجموعه سرویس‌های DI که باید گسترش یابد.
- configuration (IConfiguration): پیکربندی برنامه برای خواندن تنظیمات.
- sectionName (string): ورودی از نوع string.

مقدار بازگشتی: `IServiceCollection`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `AddZaminApiAuthentication` (method)

```csharp
public static IServiceCollection AddZaminApiAuthentication(this IServiceCollection services, IConfiguration configuration)
```

متد «AddZaminApiAuthentication» در ApiAuthenticationServiceCollectionExtensions. سرویس‌ها/قابلیت مرتبط را به IServiceCollection ثبت می‌کند. گزینه‌های تنظیمات را Configure می‌کند.
پارامترها:
- services (IServiceCollection): مجموعه سرویس‌های DI که باید گسترش یابد.
- configuration (IConfiguration): پیکربندی برنامه برای خواندن تنظیمات.

مقدار بازگشتی: `IServiceCollection`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `AddZaminApiAuthentication` (method)

```csharp
public static IServiceCollection AddZaminApiAuthentication(this IServiceCollection services, Action<ApiAuthenticationOption> action)
```

متد «AddZaminApiAuthentication» در ApiAuthenticationServiceCollectionExtensions. سرویس‌ها/قابلیت مرتبط را به IServiceCollection ثبت می‌کند. گزینه‌های تنظیمات را Configure می‌کند.
پارامترها:
- services (IServiceCollection): مجموعه سرویس‌های DI که باید گسترش یابد.
- action (Action<ApiAuthenticationOption>): ورودی از نوع Action<ApiAuthenticationOption>.

مقدار بازگشتی: `IServiceCollection`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
