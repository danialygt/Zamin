# Dependency Injection — الگوهای ثبت سرویس زمین

منبع: نمونه‌های کاربردی مستندشده و فایل‌های `framework-docs/patterns/by-namespace` / `general-recipes.md`. هیچ API اختراع‌شده‌ای اینجا نیست.

## Recipe: Host bootstrap با Serilog {#recipe-host-bootstrap}

**توضیح:** هاست‌های اپلیکیشن startup را داخل `SerilogExtensions.RunWithSerilogExceptionHandling` می‌پیچند، سپس configuration، `AddZaminSerilog`، ثبت سرویس‌ها و pipeline را زنجیره می‌کنند. همین شکل برای چند نوع هاست (API و Worker) قابل اعمال است.

**کد نمونه:**

```csharp
// src/Endpoints/API/Program.cs
using MyApp.Endpoints.DependencyInjection;
using Zamin.Extensions.DependencyInjection;
using Zamin.Utilities.SerilogRegistration.Extensions;

SerilogExtensions.RunWithSerilogExceptionHandling(() =>
{
    var builder = WebApplication.CreateBuilder(args);
    var app = builder
        .AddConfiguration()
        .AddZaminSerilog(o =>
        {
            o.ApplicationName = builder.Configuration.GetValue<string>("Global:ApplicationName");
            o.ServiceId = builder.Configuration.GetValue<string>("Global:ServiceId");
            o.ServiceName = builder.Configuration.GetValue<string>("Global:ServiceName");
            o.ServiceVersion = builder.Configuration.GetValue<string>("Global:ServiceVersion");
        })
        .ConfigureServices()
        .ConfigurePipeline();
    app.Run();
});
```

**نکات مهم:**

- نقطه ورود مشاهده‌شده: `SerilogExtensions.RunWithSerilogExceptionHandling`.
- بعد از build، سرویس‌های post-start مثل SoftwarePartDetector اجرا می‌شوند (بخش‌های بعدی).

## Recipe: AddZaminApiCore و decoratorهای dispatcher {#recipe-add-zamin-api-core}

**توضیح:** قبل از `AddZaminApiCore("Zamin", "MyApp")` اپلیکیشن decoratorهای لاگ‌گذاری خودش را برای `CommandDispatcherDecorator` / `QueryDispatcherDecorator` ثبت می‌کند. `AddZaminApiCore` اسکن اسمبلی برای handlerها و lifetime markerها را انجام می‌دهد.

**کد نمونه:**

```csharp
// HostingExtensions.ConfigureServices
builder.Services.AddTransient<CommandDispatcherDecorator, LoggingCommandDispatcherDecorator>();
builder.Services.AddTransient<QueryDispatcherDecorator, LoggingQueryDispatcherDecorator>();
builder.Services.AddZaminApiCore("Zamin", "MyApp");
```

**نکات مهم:**

- ترتیب مشاهده‌شده: ثبت decoratorها → سپس `AddZaminApiCore`.
- handlerها دستی `new` نمی‌شوند؛ از طریق اسکن DI ساخته می‌شوند.

## Recipe: Lifetime markers {#recipe-lifetime-markers}

**توضیح:** اینترفیس‌های `ITransientLifetime` / `IScopeLifetime` / `ISingletoneLifetime` روی قراردادهای اپلیکیشن برای کشف lifetime توسط `AddZaminApiCore` استفاده می‌شوند.

**Types in this pattern:** `ITransientLifetime`, `IScopeLifetime`, `ISingletoneLifetime`.

**کد نمونه:**

```csharp
// src/Contracts/Services/ISampleAppService.cs
public interface ISampleAppService : ITransientLifetime
```

**نکات مهم:**

- املای `ISingletoneLifetime` در API زمین همین‌گونه است (طبق استخراج).

## Recipe: Distributed cache (Redis / SQL) {#recipe-distributed-cache}

**توضیح:** اپلیکیشن با کلید `DistributedCacheActive` بین Redis و SQL سوییچ می‌کند و یکی از `AddZaminRedisDistributedCache` یا `AddZaminSqlDistributedCache` را صدا می‌زند.

**کد نمونه:**

```csharp
// excerpt — ConfigureServices (API)
if (builder.Configuration["DistributedCacheActive"] == nameof(DistributedRedisCacheOptions))
    builder.Services.AddZaminRedisDistributedCache(builder.Configuration, nameof(DistributedRedisCacheOptions));
else if (builder.Configuration["DistributedCacheActive"] == nameof(DistributedSqlCacheOptions))
    builder.Services.AddZaminSqlDistributedCache(builder.Configuration, nameof(DistributedSqlCacheOptions));
else
    throw new ArgumentException("There is no valid DistributedCacheActive on appsettings.");
```

**نکات مهم:**

- Options مربوطه: `DistributedRedisCacheOptions` / `DistributedSqlCacheOptions`.
- مصرف‌کننده رایج: `ICacheAdapter` (نگاه کنید به common-recipes).

## Recipe: Serializer و AutoMapper {#recipe-serializer-mapper}

**توضیح:** در هاست API ثبت‌های `AddZaminMicrosoftSerializer` و `AddZaminAutoMapperProfiles(builder.Configuration, "AutoMapper")` مشاهده شده است.

**کد نمونه:**

```csharp
builder.Services.AddZaminMicrosoftSerializer();
builder.Services.AddZaminAutoMapperProfiles(builder.Configuration, "AutoMapper");
```

**نکات مهم:**

- اینترفیس مصرفی serializer: `IJsonSerializer` (Abstractions).

## Recipe: Parrot translator registration {#recipe-parrot-translator}

**توضیح:** `AddZaminParrotTranslator` در ConfigureServices؛ بعد از build، `ParrotTranslatorInitializer.Initialize` با options اجرا می‌شود.

**کد نمونه:**

```csharp
builder.Services.AddZaminParrotTranslator(builder.Configuration, "ParrotTranslator");
// pipeline / post-build:
var options = app.Services.GetService<IOptions<ParrotTranslatorOptions>>()?.Value
    ?? throw new NullReferenceException();
ParrotTranslatorInitializer.Initialize(options.ConnectionString, options.SchemaName, options.TableName);
```

**نکات مهم:**

- Options: `ParrotTranslatorOptions`؛ سرویس: `ParrotTranslator` / قرارداد `ITranslator`.

## Recipe: User info registration {#recipe-user-info-registration}

**توضیح:** اپلیکیشن `AddAppUserInfoService(builder.Configuration, "UserInfo")` را صدا می‌زند (extension سمت اپلیکیشن روی قراردادهای UsersManagement زمین).

**کد نمونه:**

```csharp
builder.Services.AddAppUserInfoService(builder.Configuration, "UserInfo");
```

**نکات مهم:**

- Options مرتبط زمین: `UserManagementOptions` (مشاهده در patterns).
- مصرف: `IUserInfoService` و مسیر `ZaminServices.UserInfoService`.

## Recipe: API authentication + Swagger {#recipe-api-authentication}

**توضیح:** پس از DbContext و سرویس‌های هسته، `AddZaminSwagger` و `AddZaminApiAuthentication` با sectionهای تنظیمات ثبت می‌شوند.

**کد نمونه:**

```csharp
builder.Services.AddZaminSwagger(builder.Configuration, "Swagger");
builder.Services.AddZaminApiAuthentication(builder.Configuration, "ApiAuthentication");
```

**نکات مهم:**

- Options مشاهده‌شده: `ApiAuthenticationOption`, `ProviderOption`, `TokenType`.

## Recipe: SoftwarePartDetector {#recipe-software-part-detector}

**توضیح:** ثبت با `AddSoftwarePartDetector`؛ بعد از pipeline، `SoftwarePartDetectorService.Run()` فراخوانی می‌شود.

**کد نمونه:**

```csharp
builder.Services.AddSoftwarePartDetector(builder.Configuration, "SoftwarePart");
// after MapControllers:
app.Services.GetService<SoftwarePartDetectorService>()?.Run();
```

**نکات مهم:**

- در inventory، نام‌های DataModel ممکن است با تایپ‌های دامنه‌ای اپلیکیشن تداخل داشته باشند؛ جزئیات در `unused-types.md` آمده است.

## Recipe: Worker messaging DAL {#recipe-worker-messaging-dal}

**توضیح:** WorkerService به‌صورت فعال `AddZaminPollingPublisherDalSql` و `AddZaminMessageInboxDalSql` را ثبت می‌کند. ثبت‌های application-level برای RabbitMQ / PollingPublisher / MessageInbox در کد مشاهده‌شده comment شده‌اند.

**کد نمونه:**

مستندات کافی موجود نیست — فقط اشاره متنی در general-recipes؛ snippet کامل Worker در مرحله قبل استخراج نشده است.

**نکات مهم:**

- Pipeline ورکر `UseZaminApiExceptionHandler` را صدا نمی‌زند (مشاهده‌شده).

## ترتیب کلی ثبت سرویس در API (مشاهده‌شده)

1. Decoratorهای dispatcher اپلیکیشن
2. `AddZaminApiCore`
3. User-info / translator / software-part / serializer / AutoMapper / cache
4. EF Command/Query DbContext + interceptorهای زمین
5. Auth + Swagger
6. Pipeline: `UseZaminApiExceptionHandler` → auth → `MapControllers`
7. Post-build: SoftwarePartDetector + Parrot initializer
