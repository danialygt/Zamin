# Zamin.Extensions.Caching.InMemory.Services

مرجع API برای namespace `Zamin.Extensions.Caching.InMemory.Services`.

- **Type count (this file):** 1

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Extensions.Caching.InMemory.Services.InMemoryCacheAdapter`

- **Kind:** `class`
- **Base / interfaces:** `ICacheAdapter`
- **Source:** `Extentsions/Caching/Zamin.Extensions.Caching.InMemory/Zamin.Extensions.Caching.InMemory/Services/InMemoryCacheAdapter.cs`

کلاس «InMemoryCacheAdapter» در namespace Zamin.Extensions.Caching.InMemory.Services. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین. ارث‌بری/پیاده‌سازی: ICacheAdapter. وابستگی‌های سازنده (DI): IMemoryCache memoryCache, IJsonSerializer jsonSerializer, ILogger<InMemoryCacheAdapter> logger. مرتبط: ICacheAdapter | DI: IMemoryCache memoryCache, IJsonSerializer jsonSerializer, ILogger<InMemoryCacheAdapter> logger.

#### Members

##### `.ctor` (constructor)

```csharp
public InMemoryCacheAdapter(IMemoryCache memoryCache,
                                IJsonSerializer jsonSerializer,
                                ILogger<InMemoryCacheAdapter> logger)
```

سازنده InMemoryCacheAdapter. پارامترها از طریق تزریق وابستگی تأمین می‌شوند. پارامترها:
- memoryCache (IMemoryCache): ورودی از نوع IMemoryCache.
- jsonSerializer (IJsonSerializer): ورودی از نوع IJsonSerializer.
- logger (ILogger<InMemoryCacheAdapter>): لاگر برای ثبت رویدادها و خطاها.
پیش‌شرط: وابستگی‌ها/مقادیر ورودی باید معتبر باشند تا فیلدهای داخلی به‌درستی مقداردهی شوند.

##### `Add` (method)

```csharp
public void Add<TInput>(string key, TInput obj, DateTime? absoluteExpiration, TimeSpan? slidingExpiration)
```

متد «Add» در InMemoryCacheAdapter. وضعیت را به‌روز یا ذخیره می‌کند.
پارامترها:
- key (string): ورودی از نوع string.
- obj (TInput): ورودی از نوع TInput.
- absoluteExpiration (DateTime?): ورودی از نوع DateTime?.
- slidingExpiration (TimeSpan?): ورودی از نوع TimeSpan?.

مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: ICacheAdapter | DI: IMemoryCache memoryCache, IJsonSerializer jsonSerializer, ILogger<InMemoryCacheAdapter> logger

##### `Get` (method)

```csharp
public TOutput Get<TOutput>(string key)
```

متد «Get» در InMemoryCacheAdapter. داده یا وضعیت مرتبط را بازیابی می‌کند.
پارامترها:
- key (string): ورودی از نوع string.

مقدار بازگشتی: `TOutput`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: ICacheAdapter | DI: IMemoryCache memoryCache, IJsonSerializer jsonSerializer, ILogger<InMemoryCacheAdapter> logger

##### `RemoveCache` (method)

```csharp
public void RemoveCache(string key)
```

متد «RemoveCache» در InMemoryCacheAdapter. مورد یا وضعیت را حذف/پاک می‌کند.
پارامترها:
- key (string): ورودی از نوع string.

مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: ICacheAdapter | DI: IMemoryCache memoryCache, IJsonSerializer jsonSerializer, ILogger<InMemoryCacheAdapter> logger
