# Zamin.Extensions.Caching.Distributed.Redis.Services

مرجع API برای namespace `Zamin.Extensions.Caching.Distributed.Redis.Services`.

- **Type count (this file):** 1

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Extensions.Caching.Distributed.Redis.Services.DistributedRedisCacheAdapter`

- **Kind:** `class`
- **Base / interfaces:** `ICacheAdapter`
- **Source:** `Extentsions/Caching/Zamin.Extensions.Caching.Distributed.Redis/Zamin.Extensions.Caching.Distributed.Redis/Services/DistributedRedisCacheAdapter.cs`

کلاس «DistributedRedisCacheAdapter» در namespace Zamin.Extensions.Caching.Distributed.Redis.Services. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین. ارث‌بری/پیاده‌سازی: ICacheAdapter. وابستگی‌های سازنده (DI): IDistributedCache cache, IJsonSerializer serializer, ILogger<DistributedRedisCacheAdapter> logger. مرتبط: ICacheAdapter | DI: IDistributedCache cache, IJsonSerializer serializer, ILogger<DistributedRedisCacheAdapter> logger.

#### Members

##### `.ctor` (constructor)

```csharp
public DistributedRedisCacheAdapter(IDistributedCache cache,
                                        IJsonSerializer serializer,
                                        ILogger<DistributedRedisCacheAdapter> logger)
```

سازنده DistributedRedisCacheAdapter. پارامترها از طریق تزریق وابستگی تأمین می‌شوند. پارامترها:
- cache (IDistributedCache): ورودی از نوع IDistributedCache.
- serializer (IJsonSerializer): ورودی از نوع IJsonSerializer.
- logger (ILogger<DistributedRedisCacheAdapter>): لاگر برای ثبت رویدادها و خطاها.
پیش‌شرط: وابستگی‌ها/مقادیر ورودی باید معتبر باشند تا فیلدهای داخلی به‌درستی مقداردهی شوند.

##### `Add` (method)

```csharp
public void Add<TInput>(string key, TInput obj, DateTime? absoluteExpiration, TimeSpan? slidingExpiration)
```

متد «Add» در DistributedRedisCacheAdapter. وضعیت را به‌روز یا ذخیره می‌کند.
پارامترها:
- key (string): ورودی از نوع string.
- obj (TInput): ورودی از نوع TInput.
- absoluteExpiration (DateTime?): ورودی از نوع DateTime?.
- slidingExpiration (TimeSpan?): ورودی از نوع TimeSpan?.

مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: ICacheAdapter | DI: IDistributedCache cache, IJsonSerializer serializer, ILogger<DistributedRedisCacheAdapter> logger

##### `Get` (method)

```csharp
public TOutput Get<TOutput>(string key)
```

متد «Get» در DistributedRedisCacheAdapter. داده یا وضعیت مرتبط را بازیابی می‌کند.
پارامترها:
- key (string): ورودی از نوع string.

مقدار بازگشتی: `TOutput`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: ICacheAdapter | DI: IDistributedCache cache, IJsonSerializer serializer, ILogger<DistributedRedisCacheAdapter> logger

##### `RemoveCache` (method)

```csharp
public void RemoveCache(string key)
```

متد «RemoveCache» در DistributedRedisCacheAdapter. مورد یا وضعیت را حذف/پاک می‌کند.
پارامترها:
- key (string): ورودی از نوع string.

مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: ICacheAdapter | DI: IDistributedCache cache, IJsonSerializer serializer, ILogger<DistributedRedisCacheAdapter> logger
