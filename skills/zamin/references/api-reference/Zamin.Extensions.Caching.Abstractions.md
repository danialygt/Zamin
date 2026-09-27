# Zamin.Extensions.Caching.Abstractions

مرجع API برای namespace `Zamin.Extensions.Caching.Abstractions`.

- **Type count (this file):** 2

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Extensions.Caching.Abstractions.FakeCacheAdapter`

- **Kind:** `class`
- **Base / interfaces:** `ICacheAdapter`
- **Source:** `Extentsions/Zamin.Extensions.Abstractions/Zamin.Extensions.Chaching.Abstractions/FakeCacheAdapter.cs`

کلاس «FakeCacheAdapter» در namespace Zamin.Extensions.Caching.Abstractions. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین. ارث‌بری/پیاده‌سازی: ICacheAdapter. مرتبط: ICacheAdapter (same namespace).

- **Recipe:** [الگوی استفاده مرتبط](../patterns/common-recipes.md#recipe-cache-adapter)

#### Members

##### `Add` (method)

```csharp
public void Add<TInput>(string key, TInput obj, DateTime? AbsoluteExpiration, TimeSpan? SlidingExpiration)
```

متد «Add» در FakeCacheAdapter. وضعیت را به‌روز یا ذخیره می‌کند.
پارامترها:
- key (string): ورودی از نوع string.
- obj (TInput): ورودی از نوع TInput.
- AbsoluteExpiration (DateTime?): ورودی از نوع DateTime?.
- SlidingExpiration (TimeSpan?): ورودی از نوع TimeSpan?.

مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
انواع مرتبط: ICacheAdapter (same namespace)

##### `Get` (method)

```csharp
public TOutput Get<TOutput>(string key)
```

متد «Get» در FakeCacheAdapter. داده یا وضعیت مرتبط را بازیابی می‌کند.
پارامترها:
- key (string): ورودی از نوع string.

مقدار بازگشتی: `TOutput`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
انواع مرتبط: ICacheAdapter (same namespace)

##### `RemoveCache` (method)

```csharp
public void RemoveCache(string key)
```

متد «RemoveCache» در FakeCacheAdapter. مورد یا وضعیت را حذف/پاک می‌کند.
پارامترها:
- key (string): ورودی از نوع string.

مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
انواع مرتبط: ICacheAdapter (same namespace)

### `Zamin.Extensions.Caching.Abstractions.ICacheAdapter`

- **Kind:** `interface`
- **Source:** `Extentsions/Zamin.Extensions.Abstractions/Zamin.Extensions.Chaching.Abstractions/ICacheAdapter.cs`

قرارداد (اینترفیس) «ICacheAdapter» در namespace Zamin.Extensions.Caching.Abstractions. قرارداد رفتار برای مصرف‌کنندگان و پیاده‌سازی‌های جایگزین.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/common-recipes.md#recipe-cache-adapter)

#### Members

##### `Add` (method)

```csharp
void Add<TInput>(string key, TInput obj, DateTime? AbsoluteExpiration, TimeSpan? SlidingExpiration)
```

متد «Add» در ICacheAdapter. وضعیت را به‌روز یا ذخیره می‌کند.
پارامترها:
- key (string): ورودی از نوع string.
- obj (TInput): ورودی از نوع TInput.
- AbsoluteExpiration (DateTime?): ورودی از نوع DateTime?.
- SlidingExpiration (TimeSpan?): ورودی از نوع TimeSpan?.

مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `Get` (method)

```csharp
TOutput Get<TOutput>(string key)
```

متد «Get» در ICacheAdapter. داده یا وضعیت مرتبط را بازیابی می‌کند.
پارامترها:
- key (string): ورودی از نوع string.

مقدار بازگشتی: `TOutput`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `RemoveCache` (method)

```csharp
void RemoveCache(string key)
```

متد «RemoveCache» در ICacheAdapter. مورد یا وضعیت را حذف/پاک می‌کند.
پارامترها:
- key (string): ورودی از نوع string.

مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
