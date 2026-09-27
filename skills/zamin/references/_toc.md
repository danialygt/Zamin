# فهرست مستندات زمین (TOC)

نقشه کامل فایل‌های `framework-docs/` برای انسان و ایجنت.

## ریشه

| فایل | توضیح |
|---|---|
| [overview.md](overview.md) | معرفی زمین، معماری ماژول‌ها، مفاهیم پایه، و نقطه‌ی شروع پیشنهادی برای ایجنت |
| [_toc.md](_toc.md) | همین فهرست — نقشه کامل مستندات |

## Patterns

| فایل | توضیح |
|---|---|
| [patterns/dependency-injection.md](patterns/dependency-injection.md) | Recipeهای ثبت DI، bootstrap هاست، کش، ترجمه، auth، و Worker DAL بر اساس اپلیکیشن |
| [patterns/common-recipes.md](patterns/common-recipes.md) | Recipeهای کاربردی CQRS، دامنه، repository، BaseController و سرویس‌های مشترک |
| [patterns/unused-types.md](patterns/unused-types.md) | تایپ‌های زمین بدون نمونه استفاده در اپلیکیشن (بدون Recipe واقعی) |

### فایل‌های کمکی مرحله قبل (منبع خام patterns)

| فایل | توضیح |
|---|---|
| [patterns/general-recipes.md](patterns/general-recipes.md) | پیش‌نویس کلی recipes قبل از بازنویسی نهایی |
| [patterns/_inventory.json](patterns/_inventory.json) | موجودی تایپ‌های used/unused استخراج‌شده از نمونه‌های کاربردی |
| [patterns/by-namespace/](patterns/by-namespace/) | یادداشت خام الگوی هر namespace استفاده‌شده در اپلیکیشن |

## API Reference

| فایل | توضیح |
|---|---|
| [Zamin.Core.ApplicationServices.Commands (Part 1/3)](api-reference/Zamin.Core.ApplicationServices.Commands.Part1.md) | مرجع تایپ‌های `Zamin.Core.ApplicationServices.Commands` (3 تایپ): `CommandDispatcher`, `CommandDispatcherDecorator`, `CommandDispatcherDomainExceptionHandlerDecorator` |
| [Zamin.Core.ApplicationServices.Commands (Part 2/3)](api-reference/Zamin.Core.ApplicationServices.Commands.Part2.md) | مرجع تایپ‌های `Zamin.Core.ApplicationServices.Commands` (2 تایپ): `CommandDispatcherValidationDecorator`, `CommandHandler<TCommand, TData>` |
| [Zamin.Core.ApplicationServices.Commands (Part 3/3)](api-reference/Zamin.Core.ApplicationServices.Commands.Part3.md) | مرجع تایپ‌های `Zamin.Core.ApplicationServices.Commands` (1 تایپ): `CommandHandler<TCommand>` |
| [Zamin.Core.ApplicationServices.Events](api-reference/Zamin.Core.ApplicationServices.Events.md) | مرجع تایپ‌های `Zamin.Core.ApplicationServices.Events` (4 تایپ): `EventDispatcher`, `EventDispatcherDecorator`, `EventDispatcherDomainExceptionHandlerDecorator`, `EventDispatcherValidationDecorator` |
| [Zamin.Core.ApplicationServices.Queries (Part 1/2)](api-reference/Zamin.Core.ApplicationServices.Queries.Part1.md) | مرجع تایپ‌های `Zamin.Core.ApplicationServices.Queries` (4 تایپ): `QueryDispatcher`, `QueryDispatcherDecorator`, `QueryDispatcherDomainExceptionHandlerDecorator`, `QueryDispatcherValidationDecorator` |
| [Zamin.Core.ApplicationServices.Queries (Part 2/2)](api-reference/Zamin.Core.ApplicationServices.Queries.Part2.md) | مرجع تایپ‌های `Zamin.Core.ApplicationServices.Queries` (1 تایپ): `QueryHandler<TQuery, TData>` |
| [Zamin.Core.Contracts.ApplicationServices.Commands](api-reference/Zamin.Core.Contracts.ApplicationServices.Commands.md) | مرجع تایپ‌های `Zamin.Core.Contracts.ApplicationServices.Commands` (3 تایپ): `ICommandDispatcher`, `ICommandHandler<TCommand, TData>`, `ICommandHandler<TCommand>` |
| [Zamin.Core.Contracts.ApplicationServices.Events](api-reference/Zamin.Core.Contracts.ApplicationServices.Events.md) | مرجع تایپ‌های `Zamin.Core.Contracts.ApplicationServices.Events` (2 تایپ): `IDomainEventHandler<TDomainEvent>`, `IEventDispatcher` |
| [Zamin.Core.Contracts.ApplicationServices.Queries](api-reference/Zamin.Core.Contracts.ApplicationServices.Queries.md) | مرجع تایپ‌های `Zamin.Core.Contracts.ApplicationServices.Queries` (2 تایپ): `IQueryDispatcher`, `IQueryHandler<TQuery, TData>` |
| [Zamin.Core.Contracts.Data.Commands (Part 1/2)](api-reference/Zamin.Core.Contracts.Data.Commands.Part1.md) | مرجع تایپ‌های `Zamin.Core.Contracts.Data.Commands` (1 تایپ): `ICommandRepository<TEntity,TId>` |
| [Zamin.Core.Contracts.Data.Commands (Part 2/2)](api-reference/Zamin.Core.Contracts.Data.Commands.Part2.md) | مرجع تایپ‌های `Zamin.Core.Contracts.Data.Commands` (2 تایپ): `IDomainEventStore`, `IUnitOfWork` |
| [Zamin.Core.Contracts.Data.Queries](api-reference/Zamin.Core.Contracts.Data.Queries.md) | مرجع تایپ‌های `Zamin.Core.Contracts.Data.Queries` (1 تایپ): `IQueryRepository` |
| [Zamin.Core.Domain.Entities (Part 1/2)](api-reference/Zamin.Core.Domain.Entities.Part1.md) | مرجع تایپ‌های `Zamin.Core.Domain.Entities` (5 تایپ): `AggregateRoot`, `AggregateRoot<TId>`, `Entity`, `Entity<TId>`, `IAggregateRoot` |
| [Zamin.Core.Domain.Entities (Part 2/2)](api-reference/Zamin.Core.Domain.Entities.Part2.md) | مرجع تایپ‌های `Zamin.Core.Domain.Entities` (1 تایپ): `IAuditableEntity` |
| [Zamin.Core.Domain.Events](api-reference/Zamin.Core.Domain.Events.md) | مرجع تایپ‌های `Zamin.Core.Domain.Events` (1 تایپ): `IDomainEvent` |
| [Zamin.Core.Domain.Exceptions](api-reference/Zamin.Core.Domain.Exceptions.md) | مرجع تایپ‌های `Zamin.Core.Domain.Exceptions` (3 تایپ): `DomainStateException`, `InvalidEntityStateException`, `InvalidValueObjectStateException` |
| [Zamin.Core.Domain.Toolkits.ValueObjects (Part 1/4)](api-reference/Zamin.Core.Domain.Toolkits.ValueObjects.Part1.md) | مرجع تایپ‌های `Zamin.Core.Domain.Toolkits.ValueObjects` (2 تایپ): `Description`, `LegalNationalId` |
| [Zamin.Core.Domain.Toolkits.ValueObjects (Part 2/4)](api-reference/Zamin.Core.Domain.Toolkits.ValueObjects.Part2.md) | مرجع تایپ‌های `Zamin.Core.Domain.Toolkits.ValueObjects` (1 تایپ): `NationalCode` |
| [Zamin.Core.Domain.Toolkits.ValueObjects (Part 3/4)](api-reference/Zamin.Core.Domain.Toolkits.ValueObjects.Part3.md) | مرجع تایپ‌های `Zamin.Core.Domain.Toolkits.ValueObjects` (1 تایپ): `Priority` |
| [Zamin.Core.Domain.Toolkits.ValueObjects (Part 4/4)](api-reference/Zamin.Core.Domain.Toolkits.ValueObjects.Part4.md) | مرجع تایپ‌های `Zamin.Core.Domain.Toolkits.ValueObjects` (1 تایپ): `Title` |
| [Zamin.Core.Domain.ValueObjects](api-reference/Zamin.Core.Domain.ValueObjects.md) | مرجع تایپ‌های `Zamin.Core.Domain.ValueObjects` (2 تایپ): `BaseValueObject<TValueObject>`, `BusinessId` |
| [Zamin.Core.RequestResponse.Commands](api-reference/Zamin.Core.RequestResponse.Commands.md) | مرجع تایپ‌های `Zamin.Core.RequestResponse.Commands` (4 تایپ): `CommandResult`, `CommandResult<TData>`, `ICommand`, `ICommand<TData>` |
| [Zamin.Core.RequestResponse.Common](api-reference/Zamin.Core.RequestResponse.Common.md) | مرجع تایپ‌های `Zamin.Core.RequestResponse.Common` (3 تایپ): `ApplicationServiceResult`, `ApplicationServiceStatus`, `IApplicationServiceResult` |
| [Zamin.Core.RequestResponse.Endpoints](api-reference/Zamin.Core.RequestResponse.Endpoints.md) | مرجع تایپ‌های `Zamin.Core.RequestResponse.Endpoints` (1 تایپ): `IWebRequest` |
| [Zamin.Core.RequestResponse.Queries (Part 1/2)](api-reference/Zamin.Core.RequestResponse.Queries.Part1.md) | مرجع تایپ‌های `Zamin.Core.RequestResponse.Queries` (5 تایپ): `IPageQuery<TData>`, `IQuery<TData>`, `PageQuery<TData>`, `PageQueryRecord<TData>`, `PagedData<T>` |
| [Zamin.Core.RequestResponse.Queries (Part 2/2)](api-reference/Zamin.Core.RequestResponse.Queries.Part2.md) | مرجع تایپ‌های `Zamin.Core.RequestResponse.Queries` (1 تایپ): `QueryResult<TData>` |
| [Zamin.EndPoints.Web.Controllers](api-reference/Zamin.EndPoints.Web.Controllers.md) | مرجع تایپ‌های `Zamin.EndPoints.Web.Controllers` (1 تایپ): `BaseController` |
| [Zamin.EndPoints.Web.Extensions](api-reference/Zamin.EndPoints.Web.Extensions.md) | مرجع تایپ‌های `Zamin.EndPoints.Web.Extensions` (2 تایپ): `ClaimExtensions`, `HttpContextExtensions` |
| [Zamin.EndPoints.Web.Extensions.ModelBinding](api-reference/Zamin.EndPoints.Web.Extensions.ModelBinding.md) | مرجع تایپ‌های `Zamin.EndPoints.Web.Extensions.ModelBinding` (1 تایپ): `NonValidatingValidatorExtensions` |
| [Zamin.EndPoints.Web.Filters](api-reference/Zamin.EndPoints.Web.Filters.md) | مرجع تایپ‌های `Zamin.EndPoints.Web.Filters` (5 تایپ): `CamelCaseJsonAttribute`, `CamelCaseJsonFilter`, `PascalCaseJsonAttribute`, `PascalCaseJsonFilter`, `ValidateModelStateAttribute` |
| [Zamin.EndPoints.Web.Middlewares.ApiExceptionHandler](api-reference/Zamin.EndPoints.Web.Middlewares.ApiExceptionHandler.md) | مرجع تایپ‌های `Zamin.EndPoints.Web.Middlewares.ApiExceptionHandler` (4 تایپ): `ApiError`, `ApiExceptionMiddleware`, `ApiExceptionMiddlewareExtensions`, `ApiExceptionOptions` |
| [Zamin.EndPoints.Web.ModelBinding](api-reference/Zamin.EndPoints.Web.ModelBinding.md) | مرجع تایپ‌های `Zamin.EndPoints.Web.ModelBinding` (1 تایپ): `NonValidatingValidator` |
| [Zamin.Extensions.Caching.Abstractions](api-reference/Zamin.Extensions.Caching.Abstractions.md) | مرجع تایپ‌های `Zamin.Extensions.Caching.Abstractions` (2 تایپ): `FakeCacheAdapter`, `ICacheAdapter` |
| [Zamin.Extensions.Caching.Distributed.Redis.Options](api-reference/Zamin.Extensions.Caching.Distributed.Redis.Options.md) | مرجع تایپ‌های `Zamin.Extensions.Caching.Distributed.Redis.Options` (1 تایپ): `DistributedRedisCacheOptions` |
| [Zamin.Extensions.Caching.Distributed.Redis.Services](api-reference/Zamin.Extensions.Caching.Distributed.Redis.Services.md) | مرجع تایپ‌های `Zamin.Extensions.Caching.Distributed.Redis.Services` (1 تایپ): `DistributedRedisCacheAdapter` |
| [Zamin.Extensions.Caching.Distributed.Sql.Options](api-reference/Zamin.Extensions.Caching.Distributed.Sql.Options.md) | مرجع تایپ‌های `Zamin.Extensions.Caching.Distributed.Sql.Options` (1 تایپ): `DistributedSqlCacheOptions` |
| [Zamin.Extensions.Caching.Distributed.Sql.Services](api-reference/Zamin.Extensions.Caching.Distributed.Sql.Services.md) | مرجع تایپ‌های `Zamin.Extensions.Caching.Distributed.Sql.Services` (1 تایپ): `DistributedSqlCacheAdapter` |
| [Zamin.Extensions.Caching.InMemory.Services](api-reference/Zamin.Extensions.Caching.InMemory.Services.md) | مرجع تایپ‌های `Zamin.Extensions.Caching.InMemory.Services` (1 تایپ): `InMemoryCacheAdapter` |
| [Zamin.Extensions.ChangeDataLog.Abstractions](api-reference/Zamin.Extensions.ChangeDataLog.Abstractions.md) | مرجع تایپ‌های `Zamin.Extensions.ChangeDataLog.Abstractions` (4 تایپ): `DatabaseChangeType`, `EntityChageInterceptorItem`, `IEntityChageInterceptorItemRepository`, `PropertyChangeLogItem` |
| [Zamin.Extensions.ChangeDataLog.Sql](api-reference/Zamin.Extensions.ChangeDataLog.Sql.md) | مرجع تایپ‌های `Zamin.Extensions.ChangeDataLog.Sql` (1 تایپ): `DapperEntityChangeInterceptorItemRepository` |
| [Zamin.Extensions.ChangeDataLog.Sql.Options](api-reference/Zamin.Extensions.ChangeDataLog.Sql.Options.md) | مرجع تایپ‌های `Zamin.Extensions.ChangeDataLog.Sql.Options` (2 تایپ): `ChangeDataLogHamsterOptions`, `ChangeDataLogSqlOptions` |
| [Zamin.Extensions.DependencyInjection.Abstractions](api-reference/Zamin.Extensions.DependencyInjection.Abstractions.md) | مرجع تایپ‌های `Zamin.Extensions.DependencyInjection.Abstractions` (3 تایپ): `IScopeLifetime`, `ISingletoneLifetime`, `ITransientLifetime` |
| [Zamin.Extensions.DependencyInjection.Extensions.DependencyInjection](api-reference/Zamin.Extensions.DependencyInjection.Extensions.DependencyInjection.md) | مرجع تایپ‌های `Zamin.Extensions.DependencyInjection.Extensions.DependencyInjection` (1 تایپ): `DependencyInjectionServiceCollectionExtensions` |
| [Zamin.Extensions.DependencyInjection (Part 1/7)](api-reference/Zamin.Extensions.DependencyInjection.Part1.md) | مرجع تایپ‌های `Zamin.Extensions.DependencyInjection` (5 تایپ): `AddApiConfigurationExtensions`, `AddApplicationServicesExtensions`, `AddDataAccessExtentsions`, `AddZaminServicesExtensions`, `ApiAuthenticationServiceCollectionExtensions` |
| [Zamin.Extensions.DependencyInjection (Part 2/7)](api-reference/Zamin.Extensions.DependencyInjection.Part2.md) | مرجع تایپ‌های `Zamin.Extensions.DependencyInjection` (3 تایپ): `AutoMapperServiceCollectionExtensions`, `ChageDatalogServiceCollectionExtensions`, `DistributedRedisCacheServiceCollectionExtensions` |
| [Zamin.Extensions.DependencyInjection (Part 3/7)](api-reference/Zamin.Extensions.DependencyInjection.Part3.md) | مرجع تایپ‌های `Zamin.Extensions.DependencyInjection` (5 تایپ): `DistributedSqlCacheServiceCollectionExtensions`, `EPPlusExcelSerializerServiceCollectionExtensions`, `Extensions`, `InMemoryCachingServiceCollectionExtensions`, `JwtTokenExtensions` |
| [Zamin.Extensions.DependencyInjection (Part 4/7)](api-reference/Zamin.Extensions.DependencyInjection.Part4.md) | مرجع تایپ‌های `Zamin.Extensions.DependencyInjection` (4 تایپ): `MessageInboxServiceCollectionExtensions`, `MicrosoftSerializerServiceCollectionExtensions`, `NewtonSoftSerializerServiceCollectionExtensions`, `ParrotTranslatorServiceCollectionExtensions` |
| [Zamin.Extensions.DependencyInjection (Part 5/7)](api-reference/Zamin.Extensions.DependencyInjection.Part5.md) | مرجع تایپ‌های `Zamin.Extensions.DependencyInjection` (2 تایپ): `PollingPublisherServiceCollectionExtensions`, `ProviderExtensions` |
| [Zamin.Extensions.DependencyInjection (Part 6/7)](api-reference/Zamin.Extensions.DependencyInjection.Part6.md) | مرجع تایپ‌های `Zamin.Extensions.DependencyInjection` (3 تایپ): `RabbitMqMessageBusServiceCollectionExtensions`, `ReferenceTokenExtensions`, `ScalarServiceCollectionExtensions` |
| [Zamin.Extensions.DependencyInjection (Part 7/7)](api-reference/Zamin.Extensions.DependencyInjection.Part7.md) | مرجع تایپ‌های `Zamin.Extensions.DependencyInjection` (4 تایپ): `SerilogServiceCollectionExtensions`, `ServiceCollectionExtensions`, `SoftwarePartDetectorServiceCollectionExtensions`, `UserInfoServiceCollectionExtensions` |
| [Zamin.Extensions.DependencyInjection.Options](api-reference/Zamin.Extensions.DependencyInjection.Options.md) | مرجع تایپ‌های `Zamin.Extensions.DependencyInjection.Options` (1 تایپ): `DependencyInjectionOption` |
| [Zamin.Extensions.Events.Abstractions](api-reference/Zamin.Extensions.Events.Abstractions.md) | مرجع تایپ‌های `Zamin.Extensions.Events.Abstractions` (2 تایپ): `IOutBoxEventItemRepository`, `OutBoxEventItem` |
| [Zamin.Extensions.Events.Outbox.Dal.EF.Configs](api-reference/Zamin.Extensions.Events.Outbox.Dal.EF.Configs.md) | مرجع تایپ‌های `Zamin.Extensions.Events.Outbox.Dal.EF.Configs` (1 تایپ): `OutBoxEventItemConfig` |
| [Zamin.Extensions.Events.Outbox.Dal.EF.Interceptors](api-reference/Zamin.Extensions.Events.Outbox.Dal.EF.Interceptors.md) | مرجع تایپ‌های `Zamin.Extensions.Events.Outbox.Dal.EF.Interceptors` (1 تایپ): `AddOutBoxEventItemInterceptor` |
| [Zamin.Extensions.Events.Outbox.Dal.EF](api-reference/Zamin.Extensions.Events.Outbox.Dal.EF.md) | مرجع تایپ‌های `Zamin.Extensions.Events.Outbox.Dal.EF` (1 تایپ): `BaseOutboxCommandDbContext` |
| [Zamin.Extensions.Events.PollingPublisher.Dal.Dapper.DataAccess](api-reference/Zamin.Extensions.Events.PollingPublisher.Dal.Dapper.DataAccess.md) | مرجع تایپ‌های `Zamin.Extensions.Events.PollingPublisher.Dal.Dapper.DataAccess` (1 تایپ): `SqlOutBoxEventItemRepository` |
| [Zamin.Extensions.Events.PollingPublisher.Dal.Dapper.Options](api-reference/Zamin.Extensions.Events.PollingPublisher.Dal.Dapper.Options.md) | مرجع تایپ‌های `Zamin.Extensions.Events.PollingPublisher.Dal.Dapper.Options` (1 تایپ): `PollingPublisherDalRedisOptions` |
| [Zamin.Extensions.Events.PollingPublisher](api-reference/Zamin.Extensions.Events.PollingPublisher.md) | مرجع تایپ‌های `Zamin.Extensions.Events.PollingPublisher` (1 تایپ): `PoolingPublisherBackgroundService` |
| [Zamin.Extensions.Events.PollingPublisher.Options](api-reference/Zamin.Extensions.Events.PollingPublisher.Options.md) | مرجع تایپ‌های `Zamin.Extensions.Events.PollingPublisher.Options` (1 تایپ): `PollingPublisherOptions` |
| [Zamin.Extensions.Logger.Abstractions](api-reference/Zamin.Extensions.Logger.Abstractions.md) | مرجع تایپ‌های `Zamin.Extensions.Logger.Abstractions` (1 تایپ): `ZaminEventId` |
| [Zamin.Extensions.MessageBus.Abstractions.Fakes](api-reference/Zamin.Extensions.MessageBus.Abstractions.Fakes.md) | مرجع تایپ‌های `Zamin.Extensions.MessageBus.Abstractions.Fakes` (3 تایپ): `FakeMessageConsumer`, `FakeReceiveMessageBus`, `FakeSendMessageBus` |
| [Zamin.Extensions.MessageBus.Abstractions](api-reference/Zamin.Extensions.MessageBus.Abstractions.md) | مرجع تایپ‌های `Zamin.Extensions.MessageBus.Abstractions` (5 تایپ): `IMessageConsumer`, `IMessageInboxItemRepository`, `IReceiveMessageBus`, `ISendMessageBus`, `Parcel` |
| [Zamin.Extensions.MessageBus.MessageInbox.Dal.Dapper](api-reference/Zamin.Extensions.MessageBus.MessageInbox.Dal.Dapper.md) | مرجع تایپ‌های `Zamin.Extensions.MessageBus.MessageInbox.Dal.Dapper` (1 تایپ): `SqlMessageInboxItemRepository` |
| [Zamin.Extensions.MessageBus.MessageInbox.Dal.Dapper.Options](api-reference/Zamin.Extensions.MessageBus.MessageInbox.Dal.Dapper.Options.md) | مرجع تایپ‌های `Zamin.Extensions.MessageBus.MessageInbox.Dal.Dapper.Options` (1 تایپ): `MessageInboxDalDapperOptions` |
| [Zamin.Extensions.MessageBus.MessageInbox](api-reference/Zamin.Extensions.MessageBus.MessageInbox.md) | مرجع تایپ‌های `Zamin.Extensions.MessageBus.MessageInbox` (1 تایپ): `InboxMessageConsumer` |
| [Zamin.Extensions.MessageBus.MessageInbox.Options](api-reference/Zamin.Extensions.MessageBus.MessageInbox.Options.md) | مرجع تایپ‌های `Zamin.Extensions.MessageBus.MessageInbox.Options` (1 تایپ): `MessageInboxOptions` |
| [Zamin.Extensions.MessageBus.RabbitMQ](api-reference/Zamin.Extensions.MessageBus.RabbitMQ.md) | مرجع تایپ‌های `Zamin.Extensions.MessageBus.RabbitMQ` (3 تایپ): `RabbitMqReceiveMessageBus`, `RabbitMqSendMessageBus`, `RabbitMqSendMessageBusConstants` |
| [Zamin.Extensions.MessageBus.RabbitMQ.Options](api-reference/Zamin.Extensions.MessageBus.RabbitMQ.Options.md) | مرجع تایپ‌های `Zamin.Extensions.MessageBus.RabbitMQ.Options` (1 تایپ): `RabbitMqOptions` |
| [Zamin.Extensions.ObjectMappers.Abstractions](api-reference/Zamin.Extensions.ObjectMappers.Abstractions.md) | مرجع تایپ‌های `Zamin.Extensions.ObjectMappers.Abstractions` (1 تایپ): `IMapperAdapter` |
| [Zamin.Extensions.ObjectMappers.AutoMapper.Options](api-reference/Zamin.Extensions.ObjectMappers.AutoMapper.Options.md) | مرجع تایپ‌های `Zamin.Extensions.ObjectMappers.AutoMapper.Options` (1 تایپ): `AutoMapperOption` |
| [Zamin.Extensions.ObjectMappers.AutoMapper.Services](api-reference/Zamin.Extensions.ObjectMappers.AutoMapper.Services.md) | مرجع تایپ‌های `Zamin.Extensions.ObjectMappers.AutoMapper.Services` (1 تایپ): `AutoMapperAdapter` |
| [Zamin.Extensions.ObjectMappers.Mapster.Services](api-reference/Zamin.Extensions.ObjectMappers.Mapster.Services.md) | مرجع تایپ‌های `Zamin.Extensions.ObjectMappers.Mapster.Services` (2 تایپ): `IObjectMapper`, `Mapster` |
| [Zamin.Extensions.Serializers.Abstractions](api-reference/Zamin.Extensions.Serializers.Abstractions.md) | مرجع تایپ‌های `Zamin.Extensions.Serializers.Abstractions` (2 تایپ): `IExcelSerializer`, `IJsonSerializer` |
| [Zamin.Extensions.Serializers.EPPlus.Extensions](api-reference/Zamin.Extensions.Serializers.EPPlus.Extensions.md) | مرجع تایپ‌های `Zamin.Extensions.Serializers.EPPlus.Extensions` (2 تایپ): `ExcelExtensions`, `LinqExtensions` |
| [Zamin.Extensions.Serializers.EPPlus.Services](api-reference/Zamin.Extensions.Serializers.EPPlus.Services.md) | مرجع تایپ‌های `Zamin.Extensions.Serializers.EPPlus.Services` (1 تایپ): `EPPlusExcelSerializer` |
| [Zamin.Extensions.Serializers.Microsoft.Services](api-reference/Zamin.Extensions.Serializers.Microsoft.Services.md) | مرجع تایپ‌های `Zamin.Extensions.Serializers.Microsoft.Services` (1 تایپ): `MicrosoftSerializer` |
| [Zamin.Extensions.Serializers.NewtonSoft.Services](api-reference/Zamin.Extensions.Serializers.NewtonSoft.Services.md) | مرجع تایپ‌های `Zamin.Extensions.Serializers.NewtonSoft.Services` (1 تایپ): `NewtonSoftSerializer` |
| [Zamin.Extensions.Translations.Abstractions](api-reference/Zamin.Extensions.Translations.Abstractions.md) | مرجع تایپ‌های `Zamin.Extensions.Translations.Abstractions` (1 تایپ): `ITranslator` |
| [Zamin.Extensions.Translations.Parrot.Database](api-reference/Zamin.Extensions.Translations.Parrot.Database.md) | مرجع تایپ‌های `Zamin.Extensions.Translations.Parrot.Database` (1 تایپ): `ParrotSqlRepository` |
| [Zamin.Extensions.Translations.Parrot.DataModel](api-reference/Zamin.Extensions.Translations.Parrot.DataModel.md) | مرجع تایپ‌های `Zamin.Extensions.Translations.Parrot.DataModel` (1 تایپ): `LocalizationRecord` |
| [Zamin.Extensions.Translations.Parrot.Options](api-reference/Zamin.Extensions.Translations.Parrot.Options.md) | مرجع تایپ‌های `Zamin.Extensions.Translations.Parrot.Options` (2 تایپ): `DefaultTranslationOption`, `ParrotTranslatorOptions` |
| [Zamin.Extensions.Translations.Parrot.Services](api-reference/Zamin.Extensions.Translations.Parrot.Services.md) | مرجع تایپ‌های `Zamin.Extensions.Translations.Parrot.Services` (1 تایپ): `ParrotTranslator` |
| [Zamin.Extensions.UsersManagement.Abstractions (Part 1/2)](api-reference/Zamin.Extensions.UsersManagement.Abstractions.Part1.md) | مرجع تایپ‌های `Zamin.Extensions.UsersManagement.Abstractions` (1 تایپ): `FakeUserInfoService` |
| [Zamin.Extensions.UsersManagement.Abstractions (Part 2/2)](api-reference/Zamin.Extensions.UsersManagement.Abstractions.Part2.md) | مرجع تایپ‌های `Zamin.Extensions.UsersManagement.Abstractions` (1 تایپ): `IUserInfoService` |
| [Zamin.Extensions.UsersManagement.Extensions](api-reference/Zamin.Extensions.UsersManagement.Extensions.md) | مرجع تایپ‌های `Zamin.Extensions.UsersManagement.Extensions` (1 تایپ): `ClaimExtensions` |
| [Zamin.Extensions.UsersManagement.Options](api-reference/Zamin.Extensions.UsersManagement.Options.md) | مرجع تایپ‌های `Zamin.Extensions.UsersManagement.Options` (1 تایپ): `UserManagementOptions` |
| [Zamin.Extensions.UsersManagement.Services](api-reference/Zamin.Extensions.UsersManagement.Services.md) | مرجع تایپ‌های `Zamin.Extensions.UsersManagement.Services` (1 تایپ): `WebUserInfoService` |
| [Zamin.Infra.Data.Sql.Commands.Extensions (Part 1/2)](api-reference/Zamin.Infra.Data.Sql.Commands.Extensions.Part1.md) | مرجع تایپ‌های `Zamin.Infra.Data.Sql.Commands.Extensions` (4 تایپ): `AuditableShadowProperties`, `ChangeTrackerExtensions`, `DbCommandExtension`, `ModelBuilderExtensions` |
| [Zamin.Infra.Data.Sql.Commands.Extensions (Part 2/2)](api-reference/Zamin.Infra.Data.Sql.Commands.Extensions.Part2.md) | مرجع تایپ‌های `Zamin.Infra.Data.Sql.Commands.Extensions` (1 تایپ): `RowVersionShadowProperty` |
| [Zamin.Infra.Data.Sql.Commands.Interceptors](api-reference/Zamin.Infra.Data.Sql.Commands.Interceptors.md) | مرجع تایپ‌های `Zamin.Infra.Data.Sql.Commands.Interceptors` (3 تایپ): `AddAuditDataInterceptor`, `AddChangeDataLogInterceptor`, `SetPersianYeKeInterceptor` |
| [Zamin.Infra.Data.Sql.Commands (Part 1/4)](api-reference/Zamin.Infra.Data.Sql.Commands.Part1.md) | مرجع تایپ‌های `Zamin.Infra.Data.Sql.Commands` (1 تایپ): `BaseCommandDbContext` |
| [Zamin.Infra.Data.Sql.Commands (Part 2/4)](api-reference/Zamin.Infra.Data.Sql.Commands.Part2.md) | مرجع تایپ‌های `Zamin.Infra.Data.Sql.Commands` (1 تایپ): `BaseCommandRepository<TEntity, TDbContext, TId>` |
| [Zamin.Infra.Data.Sql.Commands (Part 3/4)](api-reference/Zamin.Infra.Data.Sql.Commands.Part3.md) | مرجع تایپ‌های `Zamin.Infra.Data.Sql.Commands` (2 تایپ): `BaseCommandRepository<TEntity, TDbContext, TId>`, `BaseCommandRepository<TEntity, TDbContext>` |
| [Zamin.Infra.Data.Sql.Commands (Part 4/4)](api-reference/Zamin.Infra.Data.Sql.Commands.Part4.md) | مرجع تایپ‌های `Zamin.Infra.Data.Sql.Commands` (1 تایپ): `BaseEntityFrameworkUnitOfWork<TDbContext>` |
| [Zamin.Infra.Data.Sql.Commands.ValueConversions](api-reference/Zamin.Infra.Data.Sql.Commands.ValueConversions.md) | مرجع تایپ‌های `Zamin.Infra.Data.Sql.Commands.ValueConversions` (5 تایپ): `BusinessIdConversion`, `DescriptionConversion`, `LegalNationalIdConversion`, `NationalCodeConversion`, `TitleConversion` |
| [Zamin.Infra.Data.Sql.Queries](api-reference/Zamin.Infra.Data.Sql.Queries.md) | مرجع تایپ‌های `Zamin.Infra.Data.Sql.Queries` (3 تایپ): `BaseQueryDbContext`, `BaseQueryRepository<TDbContext>`, `QueryRepositoryExtensions` |
| [Zamin.Utilities.Auth.ApiAuthentication.Extensions](api-reference/Zamin.Utilities.Auth.ApiAuthentication.Extensions.md) | مرجع تایپ‌های `Zamin.Utilities.Auth.ApiAuthentication.Extensions` (1 تایپ): `ClaimsPrincipalExtentions` |
| [Zamin.Utilities.Auth.ApiAuthentication.Models](api-reference/Zamin.Utilities.Auth.ApiAuthentication.Models.md) | مرجع تایپ‌های `Zamin.Utilities.Auth.ApiAuthentication.Models` (1 تایپ): `ClaimCacheModel` |
| [Zamin.Utilities.Auth.ApiAuthentication.Options (Part 1/3)](api-reference/Zamin.Utilities.Auth.ApiAuthentication.Options.Part1.md) | مرجع تایپ‌های `Zamin.Utilities.Auth.ApiAuthentication.Options` (5 تایپ): `ApiAuthenticationOption`, `CacheExpirationType`, `CacheKeyFormat`, `EndpointsPathOption`, `JwtTokenConfigOption` |
| [Zamin.Utilities.Auth.ApiAuthentication.Options (Part 2/3)](api-reference/Zamin.Utilities.Auth.ApiAuthentication.Options.Part2.md) | مرجع تایپ‌های `Zamin.Utilities.Auth.ApiAuthentication.Options` (4 تایپ): `ProviderOption`, `RefrenceTokenConfigOption`, `RegisterUserInfoClaimsOption`, `TokenType` |
| [Zamin.Utilities.Auth.ApiAuthentication.Options (Part 3/3)](api-reference/Zamin.Utilities.Auth.ApiAuthentication.Options.Part3.md) | مرجع تایپ‌های `Zamin.Utilities.Auth.ApiAuthentication.Options` (2 تایپ): `UserClaimAddonOption`, `UserClaimRuleOption` |
| [Zamin.Utilities.DateTimes (Part 1/9)](api-reference/Zamin.Utilities.DateTimes.Part1.md) | مرجع تایپ‌های `Zamin.Utilities.DateTimes` (1 تایپ): `DateTimeOffsetPart` |
| [Zamin.Utilities.DateTimes (Part 2/9)](api-reference/Zamin.Utilities.DateTimes.Part2.md) | مرجع تایپ‌های `Zamin.Utilities.DateTimes` (1 تایپ): `DateTimeUtils` |
| [Zamin.Utilities.DateTimes (Part 3/9)](api-reference/Zamin.Utilities.DateTimes.Part3.md) | مرجع تایپ‌های `Zamin.Utilities.DateTimes` (1 تایپ): `FriendlyPersianDateUtils` |
| [Zamin.Utilities.DateTimes (Part 4/9)](api-reference/Zamin.Utilities.DateTimes.Part4.md) | مرجع تایپ‌های `Zamin.Utilities.DateTimes` (1 تایپ): `PersianCulture` |
| [Zamin.Utilities.DateTimes (Part 5/9)](api-reference/Zamin.Utilities.DateTimes.Part5.md) | مرجع تایپ‌های `Zamin.Utilities.DateTimes` (1 تایپ): `PersianCulture` |
| [Zamin.Utilities.DateTimes (Part 6/9)](api-reference/Zamin.Utilities.DateTimes.Part6.md) | مرجع تایپ‌های `Zamin.Utilities.DateTimes` (1 تایپ): `PersianDateTimeUtils` |
| [Zamin.Utilities.DateTimes (Part 7/9)](api-reference/Zamin.Utilities.DateTimes.Part7.md) | مرجع تایپ‌های `Zamin.Utilities.DateTimes` (1 تایپ): `PersianDateTimeUtils` |
| [Zamin.Utilities.DateTimes (Part 8/9)](api-reference/Zamin.Utilities.DateTimes.Part8.md) | مرجع تایپ‌های `Zamin.Utilities.DateTimes` (4 تایپ): `PersianDay`, `PersianMonth`, `PersianNumbersUtils`, `PersianYear` |
| [Zamin.Utilities.DateTimes (Part 9/9)](api-reference/Zamin.Utilities.DateTimes.Part9.md) | مرجع تایپ‌های `Zamin.Utilities.DateTimes` (3 تایپ): `RegexUtils`, `TimeConstants`, `UnicodeConstants` |
| [Zamin.Utilities.Extensions (Part 1/4)](api-reference/Zamin.Utilities.Extensions.Part1.md) | مرجع تایپ‌های `Zamin.Utilities.Extensions` (3 تایپ): `DateTimeExtensions`, `EnumExtensions`, `GuidExtensions` |
| [Zamin.Utilities.Extensions (Part 2/4)](api-reference/Zamin.Utilities.Extensions.Part2.md) | مرجع تایپ‌های `Zamin.Utilities.Extensions` (2 تایپ): `LinqExtensions`, `ObjectExtensions` |
| [Zamin.Utilities.Extensions (Part 3/4)](api-reference/Zamin.Utilities.Extensions.Part3.md) | مرجع تایپ‌های `Zamin.Utilities.Extensions` (1 تایپ): `StringExtensions` |
| [Zamin.Utilities.Extensions (Part 4/4)](api-reference/Zamin.Utilities.Extensions.Part4.md) | مرجع تایپ‌های `Zamin.Utilities.Extensions` (2 تایپ): `StringValidatorExtensions`, `TypeExtentsions` |
| [Zamin.Utilities.Guards.GuardClauses (Part 1/4)](api-reference/Zamin.Utilities.Guards.GuardClauses.Part1.md) | مرجع تایپ‌های `Zamin.Utilities.Guards.GuardClauses` (4 تایپ): `EmptyGuardClause`, `EqualGuardClause`, `ExclusiveBetweenGuardClause`, `GreaterThanGuardClause` |
| [Zamin.Utilities.Guards.GuardClauses (Part 2/4)](api-reference/Zamin.Utilities.Guards.GuardClauses.Part2.md) | مرجع تایپ‌های `Zamin.Utilities.Guards.GuardClauses` (4 تایپ): `GreaterThanOrEqualGuardClause`, `InclusiveBetweenGuardClause`, `LengthGuardClause`, `LessThanGuardClause` |
| [Zamin.Utilities.Guards.GuardClauses (Part 3/4)](api-reference/Zamin.Utilities.Guards.GuardClauses.Part3.md) | مرجع تایپ‌های `Zamin.Utilities.Guards.GuardClauses` (5 تایپ): `LessThanOrEqualGuardClause`, `MatchGuardClause`, `MaximumLengthGuardClause`, `MinimumLengthGuardClause`, `NotEmptyGuardClause` |
| [Zamin.Utilities.Guards.GuardClauses (Part 4/4)](api-reference/Zamin.Utilities.Guards.GuardClauses.Part4.md) | مرجع تایپ‌های `Zamin.Utilities.Guards.GuardClauses` (3 تایپ): `NotEqualGuardClause`, `NotNullGuardClause`, `NullGuardClause` |
| [Zamin.Utilities.Guards](api-reference/Zamin.Utilities.Guards.md) | مرجع تایپ‌های `Zamin.Utilities.Guards` (1 تایپ): `Guard` |
| [Zamin.Utilities](api-reference/Zamin.Utilities.md) | مرجع تایپ‌های `Zamin.Utilities` (1 تایپ): `ZaminServices` |
| [Zamin.Utilities.Resources.Translators (Part 1/4)](api-reference/Zamin.Utilities.Resources.Translators.Part1.md) | مرجع تایپ‌های `Zamin.Utilities.Resources.Translators` (1 تایپ): `TranslatorKeys` |
| [Zamin.Utilities.Resources.Translators (Part 2/4)](api-reference/Zamin.Utilities.Resources.Translators.Part2.md) | مرجع تایپ‌های `Zamin.Utilities.Resources.Translators` (1 تایپ): `TranslatorKeys` |
| [Zamin.Utilities.Resources.Translators (Part 3/4)](api-reference/Zamin.Utilities.Resources.Translators.Part3.md) | مرجع تایپ‌های `Zamin.Utilities.Resources.Translators` (1 تایپ): `TranslatorValues` |
| [Zamin.Utilities.Resources.Translators (Part 4/4)](api-reference/Zamin.Utilities.Resources.Translators.Part4.md) | مرجع تایپ‌های `Zamin.Utilities.Resources.Translators` (1 تایپ): `TranslatorValues` |
| [Zamin.Utilities.ScalarRegistration.Options](api-reference/Zamin.Utilities.ScalarRegistration.Options.md) | مرجع تایپ‌های `Zamin.Utilities.ScalarRegistration.Options` (1 تایپ): `ScalarOption` |
| [Zamin.Utilities.SerilogRegistration.Enrichers](api-reference/Zamin.Utilities.SerilogRegistration.Enrichers.md) | مرجع تایپ‌های `Zamin.Utilities.SerilogRegistration.Enrichers` (2 تایپ): `ZaminApplicaitonEnricher`, `ZaminUserInfoEnricher` |
| [Zamin.Utilities.SerilogRegistration.Extensions](api-reference/Zamin.Utilities.SerilogRegistration.Extensions.md) | مرجع تایپ‌های `Zamin.Utilities.SerilogRegistration.Extensions` (1 تایپ): `SerilogExtensions` |
| [Zamin.Utilities.SerilogRegistration.Options](api-reference/Zamin.Utilities.SerilogRegistration.Options.md) | مرجع تایپ‌های `Zamin.Utilities.SerilogRegistration.Options` (1 تایپ): `SerilogApplicationEnricherOptions` |
| [Zamin.Utilities.Sinks.Elasticsearch](api-reference/Zamin.Utilities.Sinks.Elasticsearch.md) | مرجع تایپ‌های `Zamin.Utilities.Sinks.Elasticsearch` (1 تایپ): `LoggerConfigurationZaminElasticsearchExtensions` |
| [Zamin.Utilities.SoftwarePartDetector.Attributes](api-reference/Zamin.Utilities.SoftwarePartDetector.Attributes.md) | مرجع تایپ‌های `Zamin.Utilities.SoftwarePartDetector.Attributes` (1 تایپ): `SoftwarePartControllerOptionAttribute` |
| [Zamin.Utilities.SoftwarePartDetector.Authentications](api-reference/Zamin.Utilities.SoftwarePartDetector.Authentications.md) | مرجع تایپ‌های `Zamin.Utilities.SoftwarePartDetector.Authentications` (2 تایپ): `ISoftwarePartAuthentication`, `SoftwarePartAuthentication` |
| [Zamin.Utilities.SoftwarePartDetector.DataModel](api-reference/Zamin.Utilities.SoftwarePartDetector.DataModel.md) | مرجع تایپ‌های `Zamin.Utilities.SoftwarePartDetector.DataModel` (4 تایپ): `SoftwarePart`, `SoftwarePartAction`, `SoftwarePartController`, `SoftwarePartType` |
| [Zamin.Utilities.SoftwarePartDetector](api-reference/Zamin.Utilities.SoftwarePartDetector.md) | مرجع تایپ‌های `Zamin.Utilities.SoftwarePartDetector` (2 تایپ): `ControllersAndActionDetector`, `SoftwarePartDetector` |
| [Zamin.Utilities.SoftwarePartDetector.Options](api-reference/Zamin.Utilities.SoftwarePartDetector.Options.md) | مرجع تایپ‌های `Zamin.Utilities.SoftwarePartDetector.Options` (2 تایپ): `OAuthOption`, `SoftwarePartDetectorOptions` |
| [Zamin.Utilities.SoftwarePartDetector.Publishers](api-reference/Zamin.Utilities.SoftwarePartDetector.Publishers.md) | مرجع تایپ‌های `Zamin.Utilities.SoftwarePartDetector.Publishers` (2 تایپ): `ISoftwarePartPublisher`, `SoftwarePartWebPublisher` |
| [Zamin.Utilities.SoftwarePartDetector.Services](api-reference/Zamin.Utilities.SoftwarePartDetector.Services.md) | مرجع تایپ‌های `Zamin.Utilities.SoftwarePartDetector.Services` (1 تایپ): `SoftwarePartDetectorService` |

## منابع داده

| مسیر | توضیح |
|---|---|
| [enriched/](enriched/) | JSON غنی‌شده‌ی هر namespace (مرجع کامل API + generated_doc) |
| [enriched/_summary.md](enriched/_summary.md) | خلاصه آمار enrichment |
| [raw-extraction/](raw-extraction/) | استخراج خام بدون بازنویسی مستندات |
