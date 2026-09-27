# Zamin — نمای کلی مستندات

زمین (Zamin) یک فریمورک .NET مبتنی بر معماری لایه‌ای/پیازی است که قراردادها و پیاده‌سازی‌های آماده برای Command/Query، دامنه (Aggregate/Entity/ValueObject)، زیرساخت SQL، EndPointهای وب، و مجموعه‌ای از Extensionها (کش، پیام، ترجمه، DI، و …) را فراهم می‌کند. این مجموعه مستندات از استخراج سورس زمین به‌همراه الگوهای صحیح استفاده‌ی مستندشده تولید شده است.

طبق `raw-extraction/_index.json`، استخراج شامل **249** فایل سورس، **97** namespace و **258** تایپ است. توضیحات تایپ/اعضا در `framework-docs/enriched/` غنی‌سازی شده‌اند (XML نویسنده در صورت وجود حفظ شده؛ در غیر این صورت `generated_doc`).

هر جا داده کافی برای ادعا وجود نداشته باشد، در این مستندات صریحاً با عبارت «مستندات کافی موجود نیست» مشخص شده و چیزی حدس زده نشده است.

## معماری کلی (بر اساس namespaceهای استخراج‌شده)

ماژول‌های اصلی زمین از روی پیشوند namespaceها قابل گروه‌بندی‌اند. ارتباط عملی لایه‌ها به‌صورت جریان HTTP → EndPoints.Web (`BaseController`) → ApplicationServices (Dispatcher/Handler) → Domain → Infra.Data.Sql (+ Extensionهای Outbox/Cache/… ) دیده شده است.

### Core (17 namespace)

هسته: ApplicationServices (Commands/Queries/Events)، Contracts، Domain (Entities/ValueObjects/Exceptions/Events)، و RequestResponse.

- [`Zamin.Core.ApplicationServices.Commands`](api-reference/Zamin.Core.ApplicationServices.Commands.Part1.md) (3 بخش)
- [`Zamin.Core.ApplicationServices.Events`](api-reference/Zamin.Core.ApplicationServices.Events.md)
- [`Zamin.Core.ApplicationServices.Queries`](api-reference/Zamin.Core.ApplicationServices.Queries.Part1.md) (2 بخش)
- [`Zamin.Core.Contracts.ApplicationServices.Commands`](api-reference/Zamin.Core.Contracts.ApplicationServices.Commands.md)
- [`Zamin.Core.Contracts.ApplicationServices.Events`](api-reference/Zamin.Core.Contracts.ApplicationServices.Events.md)
- [`Zamin.Core.Contracts.ApplicationServices.Queries`](api-reference/Zamin.Core.Contracts.ApplicationServices.Queries.md)
- [`Zamin.Core.Contracts.Data.Commands`](api-reference/Zamin.Core.Contracts.Data.Commands.Part1.md) (2 بخش)
- [`Zamin.Core.Contracts.Data.Queries`](api-reference/Zamin.Core.Contracts.Data.Queries.md)
- [`Zamin.Core.Domain.Entities`](api-reference/Zamin.Core.Domain.Entities.Part1.md) (2 بخش)
- [`Zamin.Core.Domain.Events`](api-reference/Zamin.Core.Domain.Events.md)
- [`Zamin.Core.Domain.Exceptions`](api-reference/Zamin.Core.Domain.Exceptions.md)
- [`Zamin.Core.Domain.Toolkits.ValueObjects`](api-reference/Zamin.Core.Domain.Toolkits.ValueObjects.Part1.md) (4 بخش)
- [`Zamin.Core.Domain.ValueObjects`](api-reference/Zamin.Core.Domain.ValueObjects.md)
- [`Zamin.Core.RequestResponse.Commands`](api-reference/Zamin.Core.RequestResponse.Commands.md)
- [`Zamin.Core.RequestResponse.Common`](api-reference/Zamin.Core.RequestResponse.Common.md)
- [`Zamin.Core.RequestResponse.Endpoints`](api-reference/Zamin.Core.RequestResponse.Endpoints.md)
- [`Zamin.Core.RequestResponse.Queries`](api-reference/Zamin.Core.RequestResponse.Queries.Part1.md) (2 بخش)

### EndPoints (6 namespace)

لایه وب: Controllers پایه، ModelBinding، Filters، Middleware مدیریت استثناء.

- [`Zamin.EndPoints.Web.Controllers`](api-reference/Zamin.EndPoints.Web.Controllers.md)
- [`Zamin.EndPoints.Web.Extensions`](api-reference/Zamin.EndPoints.Web.Extensions.md)
- [`Zamin.EndPoints.Web.Extensions.ModelBinding`](api-reference/Zamin.EndPoints.Web.Extensions.ModelBinding.md)
- [`Zamin.EndPoints.Web.Filters`](api-reference/Zamin.EndPoints.Web.Filters.md)
- [`Zamin.EndPoints.Web.Middlewares.ApiExceptionHandler`](api-reference/Zamin.EndPoints.Web.Middlewares.ApiExceptionHandler.md)
- [`Zamin.EndPoints.Web.ModelBinding`](api-reference/Zamin.EndPoints.Web.ModelBinding.md)

### Infra (5 namespace)

زیرساخت داده SQL برای Command و Query (Repository، Interceptor، ValueConversion).

- [`Zamin.Infra.Data.Sql.Commands.Extensions`](api-reference/Zamin.Infra.Data.Sql.Commands.Extensions.Part1.md) (2 بخش)
- [`Zamin.Infra.Data.Sql.Commands.Interceptors`](api-reference/Zamin.Infra.Data.Sql.Commands.Interceptors.md)
- [`Zamin.Infra.Data.Sql.Commands`](api-reference/Zamin.Infra.Data.Sql.Commands.Part1.md) (4 بخش)
- [`Zamin.Infra.Data.Sql.Commands.ValueConversions`](api-reference/Zamin.Infra.Data.Sql.Commands.ValueConversions.md)
- [`Zamin.Infra.Data.Sql.Queries`](api-reference/Zamin.Infra.Data.Sql.Queries.md)

### Extensions (48 namespace)

افزونه‌ها: DI، Caching، MessageBus، Events (Outbox/PollingPublisher)، Translations، Serializers، ObjectMappers، UsersManagement، ChangeDataLog، Logger.

- [`Zamin.Extensions.Caching.Abstractions`](api-reference/Zamin.Extensions.Caching.Abstractions.md)
- [`Zamin.Extensions.Caching.Distributed.Redis.Options`](api-reference/Zamin.Extensions.Caching.Distributed.Redis.Options.md)
- [`Zamin.Extensions.Caching.Distributed.Redis.Services`](api-reference/Zamin.Extensions.Caching.Distributed.Redis.Services.md)
- [`Zamin.Extensions.Caching.Distributed.Sql.Options`](api-reference/Zamin.Extensions.Caching.Distributed.Sql.Options.md)
- [`Zamin.Extensions.Caching.Distributed.Sql.Services`](api-reference/Zamin.Extensions.Caching.Distributed.Sql.Services.md)
- [`Zamin.Extensions.Caching.InMemory.Services`](api-reference/Zamin.Extensions.Caching.InMemory.Services.md)
- [`Zamin.Extensions.ChangeDataLog.Abstractions`](api-reference/Zamin.Extensions.ChangeDataLog.Abstractions.md)
- [`Zamin.Extensions.ChangeDataLog.Sql`](api-reference/Zamin.Extensions.ChangeDataLog.Sql.md)
- [`Zamin.Extensions.ChangeDataLog.Sql.Options`](api-reference/Zamin.Extensions.ChangeDataLog.Sql.Options.md)
- [`Zamin.Extensions.DependencyInjection.Abstractions`](api-reference/Zamin.Extensions.DependencyInjection.Abstractions.md)
- [`Zamin.Extensions.DependencyInjection.Extensions.DependencyInjection`](api-reference/Zamin.Extensions.DependencyInjection.Extensions.DependencyInjection.md)
- [`Zamin.Extensions.DependencyInjection`](api-reference/Zamin.Extensions.DependencyInjection.Part1.md) (7 بخش)
- [`Zamin.Extensions.DependencyInjection.Options`](api-reference/Zamin.Extensions.DependencyInjection.Options.md)
- [`Zamin.Extensions.Events.Abstractions`](api-reference/Zamin.Extensions.Events.Abstractions.md)
- [`Zamin.Extensions.Events.Outbox.Dal.EF.Configs`](api-reference/Zamin.Extensions.Events.Outbox.Dal.EF.Configs.md)
- [`Zamin.Extensions.Events.Outbox.Dal.EF.Interceptors`](api-reference/Zamin.Extensions.Events.Outbox.Dal.EF.Interceptors.md)
- [`Zamin.Extensions.Events.Outbox.Dal.EF`](api-reference/Zamin.Extensions.Events.Outbox.Dal.EF.md)
- [`Zamin.Extensions.Events.PollingPublisher.Dal.Dapper.DataAccess`](api-reference/Zamin.Extensions.Events.PollingPublisher.Dal.Dapper.DataAccess.md)
- [`Zamin.Extensions.Events.PollingPublisher.Dal.Dapper.Options`](api-reference/Zamin.Extensions.Events.PollingPublisher.Dal.Dapper.Options.md)
- [`Zamin.Extensions.Events.PollingPublisher`](api-reference/Zamin.Extensions.Events.PollingPublisher.md)
- [`Zamin.Extensions.Events.PollingPublisher.Options`](api-reference/Zamin.Extensions.Events.PollingPublisher.Options.md)
- [`Zamin.Extensions.Logger.Abstractions`](api-reference/Zamin.Extensions.Logger.Abstractions.md)
- [`Zamin.Extensions.MessageBus.Abstractions.Fakes`](api-reference/Zamin.Extensions.MessageBus.Abstractions.Fakes.md)
- [`Zamin.Extensions.MessageBus.Abstractions`](api-reference/Zamin.Extensions.MessageBus.Abstractions.md)
- [`Zamin.Extensions.MessageBus.MessageInbox.Dal.Dapper`](api-reference/Zamin.Extensions.MessageBus.MessageInbox.Dal.Dapper.md)
- [`Zamin.Extensions.MessageBus.MessageInbox.Dal.Dapper.Options`](api-reference/Zamin.Extensions.MessageBus.MessageInbox.Dal.Dapper.Options.md)
- [`Zamin.Extensions.MessageBus.MessageInbox`](api-reference/Zamin.Extensions.MessageBus.MessageInbox.md)
- [`Zamin.Extensions.MessageBus.MessageInbox.Options`](api-reference/Zamin.Extensions.MessageBus.MessageInbox.Options.md)
- [`Zamin.Extensions.MessageBus.RabbitMQ`](api-reference/Zamin.Extensions.MessageBus.RabbitMQ.md)
- [`Zamin.Extensions.MessageBus.RabbitMQ.Options`](api-reference/Zamin.Extensions.MessageBus.RabbitMQ.Options.md)
- [`Zamin.Extensions.ObjectMappers.Abstractions`](api-reference/Zamin.Extensions.ObjectMappers.Abstractions.md)
- [`Zamin.Extensions.ObjectMappers.AutoMapper.Options`](api-reference/Zamin.Extensions.ObjectMappers.AutoMapper.Options.md)
- [`Zamin.Extensions.ObjectMappers.AutoMapper.Services`](api-reference/Zamin.Extensions.ObjectMappers.AutoMapper.Services.md)
- [`Zamin.Extensions.ObjectMappers.Mapster.Services`](api-reference/Zamin.Extensions.ObjectMappers.Mapster.Services.md)
- [`Zamin.Extensions.Serializers.Abstractions`](api-reference/Zamin.Extensions.Serializers.Abstractions.md)
- [`Zamin.Extensions.Serializers.EPPlus.Extensions`](api-reference/Zamin.Extensions.Serializers.EPPlus.Extensions.md)
- [`Zamin.Extensions.Serializers.EPPlus.Services`](api-reference/Zamin.Extensions.Serializers.EPPlus.Services.md)
- [`Zamin.Extensions.Serializers.Microsoft.Services`](api-reference/Zamin.Extensions.Serializers.Microsoft.Services.md)
- [`Zamin.Extensions.Serializers.NewtonSoft.Services`](api-reference/Zamin.Extensions.Serializers.NewtonSoft.Services.md)
- [`Zamin.Extensions.Translations.Abstractions`](api-reference/Zamin.Extensions.Translations.Abstractions.md)
- [`Zamin.Extensions.Translations.Parrot.Database`](api-reference/Zamin.Extensions.Translations.Parrot.Database.md)
- [`Zamin.Extensions.Translations.Parrot.DataModel`](api-reference/Zamin.Extensions.Translations.Parrot.DataModel.md)
- [`Zamin.Extensions.Translations.Parrot.Options`](api-reference/Zamin.Extensions.Translations.Parrot.Options.md)
- [`Zamin.Extensions.Translations.Parrot.Services`](api-reference/Zamin.Extensions.Translations.Parrot.Services.md)
- [`Zamin.Extensions.UsersManagement.Abstractions`](api-reference/Zamin.Extensions.UsersManagement.Abstractions.Part1.md) (2 بخش)
- [`Zamin.Extensions.UsersManagement.Extensions`](api-reference/Zamin.Extensions.UsersManagement.Extensions.md)
- [`Zamin.Extensions.UsersManagement.Options`](api-reference/Zamin.Extensions.UsersManagement.Options.md)
- [`Zamin.Extensions.UsersManagement.Services`](api-reference/Zamin.Extensions.UsersManagement.Services.md)

### Utilities (21 namespace)

ابزارهای مشترک: `ZaminServices`، Auth.ApiAuthentication، Serilog، Guards، DateTimes، SoftwarePartDetector، Resources.Translators، و …

- [`Zamin.Utilities.Auth.ApiAuthentication.Extensions`](api-reference/Zamin.Utilities.Auth.ApiAuthentication.Extensions.md)
- [`Zamin.Utilities.Auth.ApiAuthentication.Models`](api-reference/Zamin.Utilities.Auth.ApiAuthentication.Models.md)
- [`Zamin.Utilities.Auth.ApiAuthentication.Options`](api-reference/Zamin.Utilities.Auth.ApiAuthentication.Options.Part1.md) (3 بخش)
- [`Zamin.Utilities.DateTimes`](api-reference/Zamin.Utilities.DateTimes.Part1.md) (9 بخش)
- [`Zamin.Utilities.Extensions`](api-reference/Zamin.Utilities.Extensions.Part1.md) (4 بخش)
- [`Zamin.Utilities.Guards.GuardClauses`](api-reference/Zamin.Utilities.Guards.GuardClauses.Part1.md) (4 بخش)
- [`Zamin.Utilities.Guards`](api-reference/Zamin.Utilities.Guards.md)
- [`Zamin.Utilities`](api-reference/Zamin.Utilities.md)
- [`Zamin.Utilities.Resources.Translators`](api-reference/Zamin.Utilities.Resources.Translators.Part1.md) (4 بخش)
- [`Zamin.Utilities.ScalarRegistration.Options`](api-reference/Zamin.Utilities.ScalarRegistration.Options.md)
- [`Zamin.Utilities.SerilogRegistration.Enrichers`](api-reference/Zamin.Utilities.SerilogRegistration.Enrichers.md)
- [`Zamin.Utilities.SerilogRegistration.Extensions`](api-reference/Zamin.Utilities.SerilogRegistration.Extensions.md)
- [`Zamin.Utilities.SerilogRegistration.Options`](api-reference/Zamin.Utilities.SerilogRegistration.Options.md)
- [`Zamin.Utilities.Sinks.Elasticsearch`](api-reference/Zamin.Utilities.Sinks.Elasticsearch.md)
- [`Zamin.Utilities.SoftwarePartDetector.Attributes`](api-reference/Zamin.Utilities.SoftwarePartDetector.Attributes.md)
- [`Zamin.Utilities.SoftwarePartDetector.Authentications`](api-reference/Zamin.Utilities.SoftwarePartDetector.Authentications.md)
- [`Zamin.Utilities.SoftwarePartDetector.DataModel`](api-reference/Zamin.Utilities.SoftwarePartDetector.DataModel.md)
- [`Zamin.Utilities.SoftwarePartDetector`](api-reference/Zamin.Utilities.SoftwarePartDetector.md)
- [`Zamin.Utilities.SoftwarePartDetector.Options`](api-reference/Zamin.Utilities.SoftwarePartDetector.Options.md)
- [`Zamin.Utilities.SoftwarePartDetector.Publishers`](api-reference/Zamin.Utilities.SoftwarePartDetector.Publishers.md)
- [`Zamin.Utilities.SoftwarePartDetector.Services`](api-reference/Zamin.Utilities.SoftwarePartDetector.Services.md)

## مفاهیم پایه‌ای برای درک فریمورک

این مفاهیم از الگوهای مشاهده‌شده در اپلیکیشن و تایپ‌های Core استخراج شده‌اند:

1. **CQRS سبک:** فرمان‌ها (`ICommand` / `CommandHandler` / `ICommandDispatcher`) و کوئری‌ها (`IQuery` / `QueryHandler` / `IQueryDispatcher`) مسیرهای جدا دارند.
2. **دامنه غنی:** `AggregateRoot`/`Entity` + ValueObjectها؛ نقضInvariant با `InvalidEntityStateException` / `InvalidValueObjectStateException`.
3. **نتیجه اپلیکیشن:** `CommandResult` / `QueryResult` و `ApplicationServiceStatus`.
4. **ثبت وابستگی:** `AddZaminApiCore` برای کشف handlerها و lifetime markerها؛ decoratorهای dispatcher قابل جایگزینی‌اند.
5. **`ZaminServices`:** کانتینر سرویس‌های مشترک تزریق‌شونده به handlerها (مثلاً دسترسی به `UserInfoService`).
6. **جداسازی خواندن/نوشتن داده:** `BaseOutboxCommandDbContext` / `BaseCommandRepository` در برابر `BaseQueryDbContext` / `BaseQueryRepository`.
7. **EndPoint نازک:** کنترلر از `BaseController` ارث می‌برد و فقط به helperهای Create/Edit/Delete/Query متکی است.

## نقطه‌ی شروع پیشنهادی برای ایجنت

اگر می‌خواهید با زمین در پروژه‌ای شبیه اپلیکیشن کد بزنید، این ترتیب را دنبال کنید:

1. همین فایل (`overview.md`) و سپس [`_toc.md`](_toc.md) برای نقشه کامل.
2. [`patterns/dependency-injection.md`](patterns/dependency-injection.md) — نحوه bootstrap و ثبت سرویس.
3. [`patterns/common-recipes.md`](patterns/common-recipes.md) — برش عمودی command/query، Aggregate، Repository، BaseController.
4. api-reference برای تایپ‌هایی که لمس می‌کنید، حداقل:
   - `Zamin.Core.ApplicationServices.Commands` / `Queries`
   - `Zamin.Core.RequestResponse.Commands` / `Queries`
   - `Zamin.Core.Domain.Entities` / `ValueObjects` / `Exceptions`
   - `Zamin.Infra.Data.Sql.Commands` / `Queries`
   - `Zamin.EndPoints.Web.Controllers`
   - `Zamin.Utilities` (`ZaminServices`)
5. قبل از استفاده از تایپ‌های ناآشنا، [`patterns/unused-types.md`](patterns/unused-types.md) را چک کنید؛ اگر در اپلیکیشن استفاده نشده‌اند، نمونه واقعی در این ریپو ندارید و فقط به XML/enriched تکیه کنید.

## آمار غنی‌سازی مستندات API

- Namespaces processed: **97**
- Items with original author XML kept as primary (`source: existing`): **197** (= 131 unmodified + 66 completed)
  - Unmodified meaning preserved: **131**
  - Completed/supplemented where XML was incomplete (missing params/returns): **66**
- Items fully generated (`source: generated`): **1137**
- Human-review candidates: **22**

تعداد فایل‌های api-reference تولیدشده در این مرحله: **136**.
