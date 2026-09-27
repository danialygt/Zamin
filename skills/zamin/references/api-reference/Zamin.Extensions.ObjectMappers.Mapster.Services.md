# Zamin.Extensions.ObjectMappers.Mapster.Services

مرجع API برای namespace `Zamin.Extensions.ObjectMappers.Mapster.Services`.

- **Type count (this file):** 2

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Extensions.ObjectMappers.Mapster.Services.IObjectMapper`

- **Kind:** `interface`
- **Source:** `Extentsions/ObjectMappers/Zamin.Extensions.ObjectMappers.Mapster/Zamin.Extensions.ObjectMappers.Mapster/Zamin.Extensions.ObjectMappers.Mapster/Services/IObjectMapper.cs`

قرارداد (اینترفیس) «IObjectMapper» در namespace Zamin.Extensions.ObjectMappers.Mapster.Services. قرارداد رفتار برای مصرف‌کنندگان و پیاده‌سازی‌های جایگزین.

#### Members

##### `Map` (method)

```csharp
TDestination Map<TSource, TDestination>(TSource source)
```

متد «Map» در IObjectMapper. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- source (TSource): ورودی از نوع TSource.

مقدار بازگشتی: `TDestination`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `Map` (method)

```csharp
TDestination Map<TDestination>(object source)
```

متد «Map» در IObjectMapper. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- source (object): ورودی از نوع object.

مقدار بازگشتی: `TDestination`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `MapCollection` (method)

```csharp
IEnumerable<TDestination> MapCollection<TSource, TDestination>(IEnumerable<TSource> source)
```

متد «MapCollection» در IObjectMapper. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- source (IEnumerable<TSource>): ورودی از نوع IEnumerable<TSource>.

مقدار بازگشتی: `IEnumerable<TDestination>`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `RegisterMap` (method)

```csharp
void RegisterMap<TSource, TDestination>(Action<TypeAdapterSetter<TSource, TDestination>> configAction)
```

متد «RegisterMap» در IObjectMapper. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- configAction (Action<TypeAdapterSetter<TSource, TDestination>>): ورودی از نوع Action<TypeAdapterSetter<TSource, TDestination>>.

مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

### `Zamin.Extensions.ObjectMappers.Mapster.Services.Mapster`

- **Kind:** `class`
- **Base / interfaces:** `Abstractions.IMapperAdapter`, `IObjectMapper`
- **Source:** `Extentsions/ObjectMappers/Zamin.Extensions.ObjectMappers.Mapster/Zamin.Extensions.ObjectMappers.Mapster/Zamin.Extensions.ObjectMappers.Mapster/Services/Mapster.cs`

کلاس «Mapster» در namespace Zamin.Extensions.ObjectMappers.Mapster.Services. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین. ارث‌بری/پیاده‌سازی: Abstractions.IMapperAdapter, IObjectMapper. وابستگی‌های سازنده (DI): ILogger<Mapster> logger. مرتبط: Abstractions.IMapperAdapter | IObjectMapper (same namespace) | DI: ILogger<Mapster> logger.

#### Members

##### `.ctor` (constructor)

```csharp
public Mapster(ILogger<Mapster> logger)
```

سازنده Mapster. پارامترها از طریق تزریق وابستگی تأمین می‌شوند. پارامترها:
- logger (ILogger<Mapster>): لاگر برای ثبت رویدادها و خطاها.
پیش‌شرط: وابستگی‌ها/مقادیر ورودی باید معتبر باشند تا فیلدهای داخلی به‌درستی مقداردهی شوند.

##### `Map` (method)

```csharp
public TDestination Map<TDestination>(object source)
```

متد «Map» در Mapster. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- source (object): ورودی از نوع object.

مقدار بازگشتی: `TDestination`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: Abstractions.IMapperAdapter | IObjectMapper (same namespace) | DI: ILogger<Mapster> logger

##### `Map` (method)

```csharp
public TDestination Map<TSource, TDestination>(TSource source)
```

متد «Map» در Mapster. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- source (TSource): ورودی از نوع TSource.

مقدار بازگشتی: `TDestination`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: Abstractions.IMapperAdapter | IObjectMapper (same namespace) | DI: ILogger<Mapster> logger

##### `MapCollection` (method)

```csharp
public IEnumerable<TDestination> MapCollection<TSource, TDestination>(IEnumerable<TSource> source)
```

متد «MapCollection» در Mapster. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- source (IEnumerable<TSource>): ورودی از نوع IEnumerable<TSource>.

مقدار بازگشتی: `IEnumerable<TDestination>`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: Abstractions.IMapperAdapter | IObjectMapper (same namespace) | DI: ILogger<Mapster> logger

##### `RegisterMap` (method)

```csharp
public void RegisterMap<TSource, TDestination>(Action<TypeAdapterSetter<TSource, TDestination>> configAction)
```

متد «RegisterMap» در Mapster. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- configAction (Action<TypeAdapterSetter<TSource, TDestination>>): ورودی از نوع Action<TypeAdapterSetter<TSource, TDestination>>.

مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: Abstractions.IMapperAdapter | IObjectMapper (same namespace) | DI: ILogger<Mapster> logger
