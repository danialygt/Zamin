# Zamin.Extensions.Caching.Distributed.Sql.Services

مرجع API برای namespace `Zamin.Extensions.Caching.Distributed.Sql.Services`.

- **Type count (this file):** 1

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Extensions.Caching.Distributed.Sql.Services.DistributedSqlCacheAdapter`

- **Kind:** `class`
- **Base / interfaces:** `ICacheAdapter`
- **Source:** `Extentsions/Caching/Zamin.Extensions.Caching.Distributed.Sql/Zamin.Extensions.Caching.Distributed.Sql/Services/DistributedSqlCacheAdapter.cs`

کلاس «DistributedSqlCacheAdapter» در namespace Zamin.Extensions.Caching.Distributed.Sql.Services. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین. ارث‌بری/پیاده‌سازی: ICacheAdapter. وابستگی‌های سازنده (DI): IDistributedCache cache, IJsonSerializer serializer, ILogger<DistributedSqlCacheAdapter> logger. مرتبط: ICacheAdapter | DI: IDistributedCache cache, IJsonSerializer serializer, ILogger<DistributedSqlCacheAdapter> logger.

#### Members

##### `.ctor` (constructor)

```csharp
public DistributedSqlCacheAdapter(IDistributedCache cache,
                                      IJsonSerializer serializer,
                                      ILogger<DistributedSqlCacheAdapter> logger)
```

سازنده DistributedSqlCacheAdapter. پارامترها از طریق تزریق وابستگی تأمین می‌شوند. پارامترها:
- cache (IDistributedCache): ورودی از نوع IDistributedCache.
- serializer (IJsonSerializer): ورودی از نوع IJsonSerializer.
- logger (ILogger<DistributedSqlCacheAdapter>): لاگر برای ثبت رویدادها و خطاها.
پیش‌شرط: وابستگی‌ها/مقادیر ورودی باید معتبر باشند تا فیلدهای داخلی به‌درستی مقداردهی شوند.

##### `Add` (method)

```csharp
public void Add<TInput>(string key, TInput obj, DateTime? absoluteExpiration, TimeSpan? slidingExpiration)
```

متد «Add» در DistributedSqlCacheAdapter. وضعیت را به‌روز یا ذخیره می‌کند.
پارامترها:
- key (string): ورودی از نوع string.
- obj (TInput): ورودی از نوع TInput.
- absoluteExpiration (DateTime?): ورودی از نوع DateTime?.
- slidingExpiration (TimeSpan?): ورودی از نوع TimeSpan?.

مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: ICacheAdapter | DI: IDistributedCache cache, IJsonSerializer serializer, ILogger<DistributedSqlCacheAdapter> logger

##### `Get` (method)

```csharp
public TOutput Get<TOutput>(string key)
```

متد «Get» در DistributedSqlCacheAdapter. داده یا وضعیت مرتبط را بازیابی می‌کند.
پارامترها:
- key (string): ورودی از نوع string.

مقدار بازگشتی: `TOutput`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: ICacheAdapter | DI: IDistributedCache cache, IJsonSerializer serializer, ILogger<DistributedSqlCacheAdapter> logger

##### `RemoveCache` (method)

```csharp
public void RemoveCache(string key)
```

متد «RemoveCache» در DistributedSqlCacheAdapter. مورد یا وضعیت را حذف/پاک می‌کند.
پارامترها:
- key (string): ورودی از نوع string.

مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: ICacheAdapter | DI: IDistributedCache cache, IJsonSerializer serializer, ILogger<DistributedSqlCacheAdapter> logger
