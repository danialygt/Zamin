# Zamin.Extensions.DependencyInjection (Part 2/7)

مرجع API برای namespace `Zamin.Extensions.DependencyInjection`.

- **Type count (this file):** 3
- **Parts:** [Part 1](./Zamin.Extensions.DependencyInjection.Part1.md) · **Part 2** · [Part 3](./Zamin.Extensions.DependencyInjection.Part3.md) · [Part 4](./Zamin.Extensions.DependencyInjection.Part4.md) · [Part 5](./Zamin.Extensions.DependencyInjection.Part5.md) · [Part 6](./Zamin.Extensions.DependencyInjection.Part6.md) · [Part 7](./Zamin.Extensions.DependencyInjection.Part7.md)

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Extensions.DependencyInjection.AutoMapperServiceCollectionExtensions`

- **Kind:** `class`
- **Source:** `Extentsions/ObjectMappers/Zamin.Extensions.ObjectMappers.AutoMapper/Zamin.Extensions.ObjectMappers.AutoMapper/Extensions/DependencyInjection/AutoMapperServiceCollectionExtensions.cs`

کلاس «AutoMapperServiceCollectionExtensions» در namespace Zamin.Extensions.DependencyInjection. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/dependency-injection.md#recipe-add-zamin-api-core)

#### Members

##### `AddZaminAutoMapperProfiles` (method)

```csharp
public static IServiceCollection AddZaminAutoMapperProfiles(this IServiceCollection services,
                                                          IConfiguration configuration,
                                                          string sectionName)
```

متد «AddZaminAutoMapperProfiles» در AutoMapperServiceCollectionExtensions. سرویس‌ها/قابلیت مرتبط را به IServiceCollection ثبت می‌کند.
پارامترها:
- services (IServiceCollection): مجموعه سرویس‌های DI که باید گسترش یابد.
- configuration (IConfiguration): پیکربندی برنامه برای خواندن تنظیمات.
- sectionName (string): ورودی از نوع string.

مقدار بازگشتی: `IServiceCollection`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `AddZaminAutoMapperProfiles` (method)

```csharp
public static IServiceCollection AddZaminAutoMapperProfiles(this IServiceCollection services, IConfiguration configuration)
```

متد «AddZaminAutoMapperProfiles» در AutoMapperServiceCollectionExtensions. سرویس‌ها/قابلیت مرتبط را به IServiceCollection ثبت می‌کند. سرویس‌ها را با lifetime مشخص در DI ثبت می‌کند.
پارامترها:
- services (IServiceCollection): مجموعه سرویس‌های DI که باید گسترش یابد.
- configuration (IConfiguration): پیکربندی برنامه برای خواندن تنظیمات.

مقدار بازگشتی: `IServiceCollection`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `AddZaminAutoMapperProfiles` (method)

```csharp
public static IServiceCollection AddZaminAutoMapperProfiles(this IServiceCollection services, Action<AutoMapperOption> setupAction)
```

متد «AddZaminAutoMapperProfiles» در AutoMapperServiceCollectionExtensions. سرویس‌ها/قابلیت مرتبط را به IServiceCollection ثبت می‌کند. سرویس‌ها را با lifetime مشخص در DI ثبت می‌کند.
پارامترها:
- services (IServiceCollection): مجموعه سرویس‌های DI که باید گسترش یابد.
- setupAction (Action<AutoMapperOption>): ورودی از نوع Action<AutoMapperOption>.

مقدار بازگشتی: `IServiceCollection`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

### `Zamin.Extensions.DependencyInjection.ChageDatalogServiceCollectionExtensions`

- **Kind:** `class`
- **Source:** `Extentsions/Databases/Zamin.Extensions.ChangeDataLog/Zamin.Extensions.ChangeDataLog.Hamster/Extensions/DependencyInjection/ChageDatalogServiceCollectionExtensions.cs;Extentsions/Databases/Zamin.Extensions.ChangeDataLog/Zamin.Extensions.ChangeDataLog.Sql/Extensions/DependencyInjection/ChageDatalogServiceCollectionExtensions.cs`

کلاس «ChageDatalogServiceCollectionExtensions» در namespace Zamin.Extensions.DependencyInjection. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/dependency-injection.md#recipe-add-zamin-api-core)

#### Members

##### `AddZaminHamsterChageDatalog` (method)

```csharp
public static IServiceCollection AddZaminHamsterChageDatalog(this IServiceCollection services, IConfiguration configuration)
```

متد «AddZaminHamsterChageDatalog» در ChageDatalogServiceCollectionExtensions. سرویس‌ها/قابلیت مرتبط را به IServiceCollection ثبت می‌کند. گزینه‌های تنظیمات را Configure می‌کند.
پارامترها:
- services (IServiceCollection): مجموعه سرویس‌های DI که باید گسترش یابد.
- configuration (IConfiguration): پیکربندی برنامه برای خواندن تنظیمات.

مقدار بازگشتی: `IServiceCollection`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `AddZaminHamsterChageDatalog` (method)

```csharp
public static IServiceCollection AddZaminHamsterChageDatalog(this IServiceCollection services, IConfiguration configuration, string sectionName)
```

متد «AddZaminHamsterChageDatalog» در ChageDatalogServiceCollectionExtensions. سرویس‌ها/قابلیت مرتبط را به IServiceCollection ثبت می‌کند.
پارامترها:
- services (IServiceCollection): مجموعه سرویس‌های DI که باید گسترش یابد.
- configuration (IConfiguration): پیکربندی برنامه برای خواندن تنظیمات.
- sectionName (string): ورودی از نوع string.

مقدار بازگشتی: `IServiceCollection`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `AddZaminHamsterChageDatalog` (method)

```csharp
public static IServiceCollection AddZaminHamsterChageDatalog(this IServiceCollection services, Action<ChangeDataLogHamsterOptions> setupAction)
```

متد «AddZaminHamsterChageDatalog» در ChageDatalogServiceCollectionExtensions. سرویس‌ها/قابلیت مرتبط را به IServiceCollection ثبت می‌کند. گزینه‌های تنظیمات را Configure می‌کند.
پارامترها:
- services (IServiceCollection): مجموعه سرویس‌های DI که باید گسترش یابد.
- setupAction (Action<ChangeDataLogHamsterOptions>): ورودی از نوع Action<ChangeDataLogHamsterOptions>.

مقدار بازگشتی: `IServiceCollection`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `AddZaminChageDatalogDalSql` (method)

```csharp
public static IServiceCollection AddZaminChageDatalogDalSql(this IServiceCollection services, IConfiguration configuration)
```

متد «AddZaminChageDatalogDalSql» در ChageDatalogServiceCollectionExtensions. سرویس‌ها/قابلیت مرتبط را به IServiceCollection ثبت می‌کند. گزینه‌های تنظیمات را Configure می‌کند. سرویس‌ها را با lifetime مشخص در DI ثبت می‌کند.
پارامترها:
- services (IServiceCollection): مجموعه سرویس‌های DI که باید گسترش یابد.
- configuration (IConfiguration): پیکربندی برنامه برای خواندن تنظیمات.

مقدار بازگشتی: `IServiceCollection`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `AddZaminChageDatalogDalSql` (method)

```csharp
public static IServiceCollection AddZaminChageDatalogDalSql(this IServiceCollection services, IConfiguration configuration, string sectionName)
```

متد «AddZaminChageDatalogDalSql» در ChageDatalogServiceCollectionExtensions. سرویس‌ها/قابلیت مرتبط را به IServiceCollection ثبت می‌کند.
پارامترها:
- services (IServiceCollection): مجموعه سرویس‌های DI که باید گسترش یابد.
- configuration (IConfiguration): پیکربندی برنامه برای خواندن تنظیمات.
- sectionName (string): ورودی از نوع string.

مقدار بازگشتی: `IServiceCollection`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `AddZaminChageDatalogDalSql` (method)

```csharp
public static IServiceCollection AddZaminChageDatalogDalSql(this IServiceCollection services, Action<ChangeDataLogSqlOptions> setupAction)
```

متد «AddZaminChageDatalogDalSql» در ChageDatalogServiceCollectionExtensions. سرویس‌ها/قابلیت مرتبط را به IServiceCollection ثبت می‌کند. گزینه‌های تنظیمات را Configure می‌کند. سرویس‌ها را با lifetime مشخص در DI ثبت می‌کند.
پارامترها:
- services (IServiceCollection): مجموعه سرویس‌های DI که باید گسترش یابد.
- setupAction (Action<ChangeDataLogSqlOptions>): ورودی از نوع Action<ChangeDataLogSqlOptions>.

مقدار بازگشتی: `IServiceCollection`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

### `Zamin.Extensions.DependencyInjection.DistributedRedisCacheServiceCollectionExtensions`

- **Kind:** `class`
- **Source:** `Extentsions/Caching/Zamin.Extensions.Caching.Distributed.Redis/Zamin.Extensions.Caching.Distributed.Redis/Extensions/DependencyInjection/DistributedRedisCacheServiceCollectionExtensions.cs`

کلاس «DistributedRedisCacheServiceCollectionExtensions» در namespace Zamin.Extensions.DependencyInjection. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/dependency-injection.md#recipe-add-zamin-api-core)

#### Members

##### `AddZaminRedisDistributedCache` (method)

```csharp
public static IServiceCollection AddZaminRedisDistributedCache(this IServiceCollection services,
                                                                   IConfiguration configuration,
                                                                   string sectionName)
```

متد «AddZaminRedisDistributedCache» در DistributedRedisCacheServiceCollectionExtensions. سرویس‌ها/قابلیت مرتبط را به IServiceCollection ثبت می‌کند.
پارامترها:
- services (IServiceCollection): مجموعه سرویس‌های DI که باید گسترش یابد.
- configuration (IConfiguration): پیکربندی برنامه برای خواندن تنظیمات.
- sectionName (string): ورودی از نوع string.

مقدار بازگشتی: `IServiceCollection`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `AddZaminRedisDistributedCache` (method)

```csharp
public static IServiceCollection AddZaminRedisDistributedCache(this IServiceCollection services, IConfiguration configuration)
```

متد «AddZaminRedisDistributedCache» در DistributedRedisCacheServiceCollectionExtensions. سرویس‌ها/قابلیت مرتبط را به IServiceCollection ثبت می‌کند. گزینه‌های تنظیمات را Configure می‌کند. سرویس‌ها را با lifetime مشخص در DI ثبت می‌کند.
پارامترها:
- services (IServiceCollection): مجموعه سرویس‌های DI که باید گسترش یابد.
- configuration (IConfiguration): پیکربندی برنامه برای خواندن تنظیمات.

مقدار بازگشتی: `IServiceCollection`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `AddZaminRedisDistributedCache` (method)

```csharp
public static IServiceCollection AddZaminRedisDistributedCache(this IServiceCollection services,
                                                              Action<DistributedRedisCacheOptions> setupAction)
```

متد «AddZaminRedisDistributedCache» در DistributedRedisCacheServiceCollectionExtensions. سرویس‌ها/قابلیت مرتبط را به IServiceCollection ثبت می‌کند. گزینه‌های تنظیمات را Configure می‌کند. سرویس‌ها را با lifetime مشخص در DI ثبت می‌کند.
پارامترها:
- services (IServiceCollection): مجموعه سرویس‌های DI که باید گسترش یابد.
- setupAction (Action<DistributedRedisCacheOptions>): ورودی از نوع Action<DistributedRedisCacheOptions>.

مقدار بازگشتی: `IServiceCollection`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
