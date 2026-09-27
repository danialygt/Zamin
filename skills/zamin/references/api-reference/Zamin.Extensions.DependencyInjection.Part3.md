# Zamin.Extensions.DependencyInjection (Part 3/7)

مرجع API برای namespace `Zamin.Extensions.DependencyInjection`.

- **Type count (this file):** 5
- **Parts:** [Part 1](./Zamin.Extensions.DependencyInjection.Part1.md) · [Part 2](./Zamin.Extensions.DependencyInjection.Part2.md) · **Part 3** · [Part 4](./Zamin.Extensions.DependencyInjection.Part4.md) · [Part 5](./Zamin.Extensions.DependencyInjection.Part5.md) · [Part 6](./Zamin.Extensions.DependencyInjection.Part6.md) · [Part 7](./Zamin.Extensions.DependencyInjection.Part7.md)

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Extensions.DependencyInjection.DistributedSqlCacheServiceCollectionExtensions`

- **Kind:** `class`
- **Source:** `Extentsions/Caching/Zamin.Extensions.Caching.Distributed.Sql/Zamin.Extensions.Caching.Distributed.Sql/Extensions/DependencyInjection/DistributedSqlCacheServiceCollectionExtensions.cs`

کلاس «DistributedSqlCacheServiceCollectionExtensions» در namespace Zamin.Extensions.DependencyInjection. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/dependency-injection.md#recipe-add-zamin-api-core)

#### Members

##### `AddZaminSqlDistributedCache` (method)

```csharp
public static IServiceCollection AddZaminSqlDistributedCache(this IServiceCollection services,
                                                                  IConfiguration configuration,
                                                                  string sectionName)
```

متد «AddZaminSqlDistributedCache» در DistributedSqlCacheServiceCollectionExtensions. سرویس‌ها/قابلیت مرتبط را به IServiceCollection ثبت می‌کند.
پارامترها:
- services (IServiceCollection): مجموعه سرویس‌های DI که باید گسترش یابد.
- configuration (IConfiguration): پیکربندی برنامه برای خواندن تنظیمات.
- sectionName (string): ورودی از نوع string.

مقدار بازگشتی: `IServiceCollection`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `AddZaminSqlDistributedCache` (method)

```csharp
public static IServiceCollection AddZaminSqlDistributedCache(this IServiceCollection services, IConfiguration configuration)
```

متد «AddZaminSqlDistributedCache» در DistributedSqlCacheServiceCollectionExtensions. سرویس‌ها/قابلیت مرتبط را به IServiceCollection ثبت می‌کند. گزینه‌های تنظیمات را Configure می‌کند. سرویس‌ها را با lifetime مشخص در DI ثبت می‌کند.
پارامترها:
- services (IServiceCollection): مجموعه سرویس‌های DI که باید گسترش یابد.
- configuration (IConfiguration): پیکربندی برنامه برای خواندن تنظیمات.

مقدار بازگشتی: `IServiceCollection`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `AddZaminSqlDistributedCache` (method)

```csharp
public static IServiceCollection AddZaminSqlDistributedCache(this IServiceCollection services,
                                                            Action<DistributedSqlCacheOptions> setupAction)
```

متد «AddZaminSqlDistributedCache» در DistributedSqlCacheServiceCollectionExtensions. سرویس‌ها/قابلیت مرتبط را به IServiceCollection ثبت می‌کند. گزینه‌های تنظیمات را Configure می‌کند. سرویس‌ها را با lifetime مشخص در DI ثبت می‌کند.
پارامترها:
- services (IServiceCollection): مجموعه سرویس‌های DI که باید گسترش یابد.
- setupAction (Action<DistributedSqlCacheOptions>): ورودی از نوع Action<DistributedSqlCacheOptions>.

مقدار بازگشتی: `IServiceCollection`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

### `Zamin.Extensions.DependencyInjection.EPPlusExcelSerializerServiceCollectionExtensions`

- **Kind:** `class`
- **Source:** `Extentsions/Serializers/Zamin.Extensions.Serializers.EPPlus/Zamin.Extensions.Serializers.EPPlus/Extensions/DependencyInjection/EPPlusExcelSerializerServiceCollectionExtensions.cs`

کلاس «EPPlusExcelSerializerServiceCollectionExtensions» در namespace Zamin.Extensions.DependencyInjection. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/dependency-injection.md#recipe-add-zamin-api-core)

#### Members

##### `AddEPPlusExcelSerializer` (method)

```csharp
public static IServiceCollection AddEPPlusExcelSerializer(this IServiceCollection services)
```

متد «AddEPPlusExcelSerializer» در EPPlusExcelSerializerServiceCollectionExtensions. سرویس‌ها/قابلیت مرتبط را به IServiceCollection ثبت می‌کند. سرویس‌ها را با lifetime مشخص در DI ثبت می‌کند.
پارامترها:
- services (IServiceCollection): مجموعه سرویس‌های DI که باید گسترش یابد.

مقدار بازگشتی: `IServiceCollection`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

### `Zamin.Extensions.DependencyInjection.Extensions`

- **Kind:** `class`
- **Source:** `Onion/src/4.EndPoints/Zamin.EndPoints.Web/Extentions/DependencyInjection/Extentions.cs`

کلاس «Extensions» در namespace Zamin.Extensions.DependencyInjection. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/dependency-injection.md#recipe-add-zamin-api-core)

#### Members

##### `AddZaminDependencies` (method)

```csharp
public static IServiceCollection AddZaminDependencies(this IServiceCollection services,
        params string[] assemblyNamesForSearch)
```

متد «AddZaminDependencies» در Extensions. سرویس‌ها/قابلیت مرتبط را به IServiceCollection ثبت می‌کند.
پارامترها:
- services (IServiceCollection): مجموعه سرویس‌های DI که باید گسترش یابد.

مقدار بازگشتی: `IServiceCollection`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `AddCustomeDepenecies` (method)

```csharp
public static IServiceCollection AddCustomeDepenecies(this IServiceCollection services, IEnumerable<Assembly> assemblies)
```

متد «AddCustomeDepenecies» در Extensions. سرویس‌ها/قابلیت مرتبط را به IServiceCollection ثبت می‌کند.
پارامترها:
- services (IServiceCollection): مجموعه سرویس‌های DI که باید گسترش یابد.
- assemblies (IEnumerable<Assembly>): ورودی از نوع IEnumerable<Assembly>.

مقدار بازگشتی: `IServiceCollection`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `AddWithTransientLifetime` (method)

```csharp
public static IServiceCollection AddWithTransientLifetime(this IServiceCollection services,
        IEnumerable<Assembly> assembliesForSearch,
        params Type[] assignableTo)
```

متد «AddWithTransientLifetime» در Extensions. سرویس‌ها/قابلیت مرتبط را به IServiceCollection ثبت می‌کند.
پارامترها:
- services (IServiceCollection): مجموعه سرویس‌های DI که باید گسترش یابد.
- assembliesForSearch (IEnumerable<Assembly>): ورودی از نوع IEnumerable<Assembly>.

مقدار بازگشتی: `IServiceCollection`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `AddWithScopedLifetime` (method)

```csharp
public static IServiceCollection AddWithScopedLifetime(this IServiceCollection services,
       IEnumerable<Assembly> assembliesForSearch,
       params Type[] assignableTo)
```

متد «AddWithScopedLifetime» در Extensions. سرویس‌ها/قابلیت مرتبط را به IServiceCollection ثبت می‌کند.
پارامترها:
- services (IServiceCollection): مجموعه سرویس‌های DI که باید گسترش یابد.
- assembliesForSearch (IEnumerable<Assembly>): ورودی از نوع IEnumerable<Assembly>.

مقدار بازگشتی: `IServiceCollection`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `AddWithSingletonLifetime` (method)

```csharp
public static IServiceCollection AddWithSingletonLifetime(this IServiceCollection services,
        IEnumerable<Assembly> assembliesForSearch,
        params Type[] assignableTo)
```

متد «AddWithSingletonLifetime» در Extensions. سرویس‌ها/قابلیت مرتبط را به IServiceCollection ثبت می‌کند.
پارامترها:
- services (IServiceCollection): مجموعه سرویس‌های DI که باید گسترش یابد.
- assembliesForSearch (IEnumerable<Assembly>): ورودی از نوع IEnumerable<Assembly>.

مقدار بازگشتی: `IServiceCollection`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

### `Zamin.Extensions.DependencyInjection.InMemoryCachingServiceCollectionExtensions`

- **Kind:** `class`
- **Source:** `Extentsions/Caching/Zamin.Extensions.Caching.InMemory/Zamin.Extensions.Caching.InMemory/Extensions/DependencyInjection/InMemoryCachingServiceCollectionExtensions.cs`

کلاس «InMemoryCachingServiceCollectionExtensions» در namespace Zamin.Extensions.DependencyInjection. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/dependency-injection.md#recipe-add-zamin-api-core)

#### Members

##### `AddZaminInMemoryCaching` (method)

```csharp
public static IServiceCollection AddZaminInMemoryCaching(this IServiceCollection services)
```

متد «AddZaminInMemoryCaching» در InMemoryCachingServiceCollectionExtensions. سرویس‌ها/قابلیت مرتبط را به IServiceCollection ثبت می‌کند. سرویس‌ها را با lifetime مشخص در DI ثبت می‌کند.
پارامترها:
- services (IServiceCollection): مجموعه سرویس‌های DI که باید گسترش یابد.

مقدار بازگشتی: `IServiceCollection`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

### `Zamin.Extensions.DependencyInjection.JwtTokenExtensions`

- **Kind:** `class`
- **Source:** `Utilities/Auth/ApiAuthentication/Zamin.Utilities.Auth.ApiAuthentication/Extensions/JwtTokenExtensions.cs`

کلاس «JwtTokenExtensions» در namespace Zamin.Extensions.DependencyInjection. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/dependency-injection.md#recipe-add-zamin-api-core)

#### Members

##### `AddJwtTokenSupoort` (method)

```csharp
public static AuthenticationBuilder AddJwtTokenSupoort(this AuthenticationBuilder authenticationBuilder,
                                                           IServiceCollection services,
                                                           ProviderOption provider)
```

متد «AddJwtTokenSupoort» در JwtTokenExtensions. سرویس‌ها/قابلیت مرتبط را به IServiceCollection ثبت می‌کند. به‌صورت ناهمگام اجرا می‌شود.
پارامترها:
- authenticationBuilder (AuthenticationBuilder): ورودی از نوع AuthenticationBuilder.
- services (IServiceCollection): مجموعه سرویس‌های DI که باید گسترش یابد.
- provider (ProviderOption): ورودی از نوع ProviderOption.

مقدار بازگشتی: `AuthenticationBuilder`.
استثناها (قابل تشخیص از کد):
- ArgumentNullException (throw new)
- ArgumentNullException
