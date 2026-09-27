# Zamin.Utilities

مرجع API برای namespace `Zamin.Utilities`.

- **Type count (this file):** 1

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Utilities.ZaminServices`

- **Kind:** `class`
- **Source:** `Onion/src/1.Utilities/Zamin.Utilities/ZaminServices.cs`

کلاس «ZaminServices» در namespace Zamin.Utilities. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین. وابستگی‌های سازنده (DI): ITranslator translator, ILoggerFactory loggerFactory, IJsonSerializer serializer, IUserInfoService userInfoService, ICacheAdapter cacheAdapter, IMapperAdapter mapperFacade. مرتبط: DI: ITranslator translator, ILoggerFactory loggerFactory, IJsonSerializer serializer, IUserInfoService userInfoService, ICacheAdapter cacheAdapter.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/common-recipes.md#recipe-zamin-services)

#### Members

##### `Translator` (field)

```csharp
public readonly ITranslator Translator;
```

فیلد «Translator» در ZaminServices با امضای `public readonly ITranslator Translator;`. برای نگهداری وضعیت داخلی/قابل‌دسترس نوع استفاده می‌شود.

##### `CacheAdapter` (field)

```csharp
public readonly ICacheAdapter CacheAdapter;
```

فیلد «CacheAdapter» در ZaminServices با امضای `public readonly ICacheAdapter CacheAdapter;`. برای نگهداری وضعیت داخلی/قابل‌دسترس نوع استفاده می‌شود.

##### `MapperFacade` (field)

```csharp
public readonly IMapperAdapter MapperFacade;
```

فیلد «MapperFacade» در ZaminServices با امضای `public readonly IMapperAdapter MapperFacade;`. برای نگهداری وضعیت داخلی/قابل‌دسترس نوع استفاده می‌شود.

##### `LoggerFactory` (field)

```csharp
public readonly ILoggerFactory LoggerFactory;
```

فیلد «LoggerFactory» در ZaminServices با امضای `public readonly ILoggerFactory LoggerFactory;`. برای نگهداری وضعیت داخلی/قابل‌دسترس نوع استفاده می‌شود.

##### `Serializer` (field)

```csharp
public readonly IJsonSerializer Serializer;
```

فیلد «Serializer» در ZaminServices با امضای `public readonly IJsonSerializer Serializer;`. برای نگهداری وضعیت داخلی/قابل‌دسترس نوع استفاده می‌شود.

##### `UserInfoService` (field)

```csharp
public readonly IUserInfoService UserInfoService;
```

فیلد «UserInfoService» در ZaminServices با امضای `public readonly IUserInfoService UserInfoService;`. برای نگهداری وضعیت داخلی/قابل‌دسترس نوع استفاده می‌شود.

##### `.ctor` (constructor)

```csharp
public ZaminServices(ITranslator translator,
            ILoggerFactory loggerFactory,
            IJsonSerializer serializer,
            IUserInfoService userInfoService,
            ICacheAdapter cacheAdapter,
            IMapperAdapter mapperFacade)
```

سازنده ZaminServices. پارامترها از طریق تزریق وابستگی تأمین می‌شوند. پارامترها:
- translator (ITranslator): ورودی از نوع ITranslator.
- loggerFactory (ILoggerFactory): لاگر برای ثبت رویدادها و خطاها.
- serializer (IJsonSerializer): ورودی از نوع IJsonSerializer.
- userInfoService (IUserInfoService): ورودی از نوع IUserInfoService.
- cacheAdapter (ICacheAdapter): ورودی از نوع ICacheAdapter.
- mapperFacade (IMapperAdapter): ورودی از نوع IMapperAdapter.
