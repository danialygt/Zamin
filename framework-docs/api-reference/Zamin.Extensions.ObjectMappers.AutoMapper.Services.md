# Zamin.Extensions.ObjectMappers.AutoMapper.Services

مرجع API برای namespace `Zamin.Extensions.ObjectMappers.AutoMapper.Services`.

- **Type count (this file):** 1

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Extensions.ObjectMappers.AutoMapper.Services.AutoMapperAdapter`

- **Kind:** `class`
- **Base / interfaces:** `IMapperAdapter`
- **Source:** `Extentsions/ObjectMappers/Zamin.Extensions.ObjectMappers.AutoMapper/Zamin.Extensions.ObjectMappers.AutoMapper/Services/AutoMapperAdapter.cs`

کلاس «AutoMapperAdapter» در namespace Zamin.Extensions.ObjectMappers.AutoMapper.Services. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین. ارث‌بری/پیاده‌سازی: IMapperAdapter. وابستگی‌های سازنده (DI): IMapper mapper, ILogger<AutoMapperAdapter> logger. مرتبط: IMapperAdapter | DI: IMapper mapper, ILogger<AutoMapperAdapter> logger.

#### Members

##### `.ctor` (constructor)

```csharp
public AutoMapperAdapter(IMapper mapper, ILogger<AutoMapperAdapter> logger)
```

سازنده AutoMapperAdapter. پارامترها از طریق تزریق وابستگی تأمین می‌شوند. پارامترها:
- mapper (IMapper): ورودی از نوع IMapper.
- logger (ILogger<AutoMapperAdapter>): لاگر برای ثبت رویدادها و خطاها.
پیش‌شرط: وابستگی‌ها/مقادیر ورودی باید معتبر باشند تا فیلدهای داخلی به‌درستی مقداردهی شوند.

##### `Map` (method)

```csharp
public TDestination Map<TSource, TDestination>(TSource source)
```

متد «Map» در AutoMapperAdapter. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- source (TSource): ورودی از نوع TSource.

مقدار بازگشتی: `TDestination`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: IMapperAdapter | DI: IMapper mapper, ILogger<AutoMapperAdapter> logger
