# Unused types — تایپ‌های زمین بدون نمونه‌ی عملی استفاده

> نمونه‌ی عملی استفاده در دسترس نیست؛ مستندات فقط بر پایه‌ی امضا و پیاده‌سازی خود زمین است
> (`api-reference/` و enrichment). برای این تایپ‌ها Recipe ترکیبی ارائه نشده است.

Zamin types from `framework-docs/raw-extraction` with **no whole-word identifier match**
in scanned application sources (excluding bin/obj/_Migrations).

Document these types from enrichment/XML / `api-reference` only.

## Scan notes

- Packages may still be referenced in `.csproj` while types stay unused.
- Some hosts contain **commented** registrations (RabbitMQ / PollingPublisher / MessageInbox / ChangeDataLog) — related types remain unused at runtime call-sites.
- `Zamin.Utilities.Guards.Guard`: comment-only hits (`// Guard: ...`); treated as unused.
- `Zamin.Utilities.SoftwarePartDetector.DataModel`: name collisions with application domain/API types are possible; not treated as confirmed framework DataModel usage without a clear call-site.
- Extension-only modules used without naming extracted types are covered under `by-namespace` (e.g. `AddNonValidatingValidator`, `AddZaminPollingPublisherDalSql`).

## Counts

- Unused type rows in inventory: **188** (plus Guard false-positive note).
- Namespaces with zero type-name hits: see groups below.

## without_usage_sample by namespace

### Zamin.Core.ApplicationServices.Commands

- `CommandDispatcherDomainExceptionHandlerDecorator` (class)
- `CommandDispatcherValidationDecorator` (class)

### Zamin.Core.ApplicationServices.Events

- `EventDispatcher` (class)
- `EventDispatcherDecorator` (class)
- `EventDispatcherDomainExceptionHandlerDecorator` (class)
- `EventDispatcherValidationDecorator` (class)

### Zamin.Core.ApplicationServices.Queries

- `QueryDispatcherDomainExceptionHandlerDecorator` (class)
- `QueryDispatcherValidationDecorator` (class)

### Zamin.Core.Contracts.ApplicationServices.Commands

- `ICommandHandler<TCommand, TData>` (interface)
- `ICommandHandler<TCommand>` (interface)

### Zamin.Core.Contracts.ApplicationServices.Events

- `IDomainEventHandler<TDomainEvent>` (interface)
- `IEventDispatcher` (interface)

### Zamin.Core.Contracts.ApplicationServices.Queries

- `IQueryHandler<TQuery, TData>` (interface)

### Zamin.Core.Contracts.Data.Commands

- `IDomainEventStore` (interface)
- `IUnitOfWork` (interface)

### Zamin.Core.Domain.Entities

- `IAggregateRoot` (interface)
- `IAuditableEntity` (interface)

### Zamin.Core.Domain.Events

- `IDomainEvent` (interface)

### Zamin.Core.Domain.Exceptions

- `DomainStateException` (class)

### Zamin.Core.Domain.Toolkits.ValueObjects

- `LegalNationalId` (class)

### Zamin.Core.RequestResponse.Common

- `ApplicationServiceResult` (class)
- `IApplicationServiceResult` (interface)

### Zamin.Core.RequestResponse.Endpoints

- `IWebRequest` (interface)

### Zamin.Core.RequestResponse.Queries

- `IPageQuery<TData>` (interface)
- `PageQueryRecord<TData>` (record)

### Zamin.EndPoints.Web.Extensions

- `ClaimExtensions` (class)

### Zamin.EndPoints.Web.Extensions.ModelBinding

- `NonValidatingValidatorExtensions` (class)

### Zamin.EndPoints.Web.Filters

- `CamelCaseJsonAttribute` (class)
- `CamelCaseJsonFilter` (class)
- `PascalCaseJsonAttribute` (class)
- `PascalCaseJsonFilter` (class)
- `ValidateModelStateAttribute` (class)

### Zamin.EndPoints.Web.Middlewares.ApiExceptionHandler

- `ApiError` (class)
- `ApiExceptionMiddleware` (class)
- `ApiExceptionMiddlewareExtensions` (class)
- `ApiExceptionOptions` (class)

### Zamin.EndPoints.Web.ModelBinding

- `NonValidatingValidator` (class)

### Zamin.Extensions.Caching.Abstractions

- `FakeCacheAdapter` (class)

### Zamin.Extensions.Caching.Distributed.Redis.Services

- `DistributedRedisCacheAdapter` (class)

### Zamin.Extensions.Caching.Distributed.Sql.Services

- `DistributedSqlCacheAdapter` (class)

### Zamin.Extensions.Caching.InMemory.Services

- `InMemoryCacheAdapter` (class)

### Zamin.Extensions.ChangeDataLog.Abstractions

- `DatabaseChangeType` (enum)
- `EntityChageInterceptorItem` (class)
- `IEntityChageInterceptorItemRepository` (interface)
- `PropertyChangeLogItem` (class)

### Zamin.Extensions.ChangeDataLog.Sql

- `DapperEntityChangeInterceptorItemRepository` (class)

### Zamin.Extensions.ChangeDataLog.Sql.Options

- `ChangeDataLogHamsterOptions` (record)
- `ChangeDataLogSqlOptions` (record)

### Zamin.Extensions.DependencyInjection

- `AddApiConfigurationExtensions` (class)
- `AddApplicationServicesExtensions` (class)
- `AddDataAccessExtentsions` (class)
- `AddZaminServicesExtensions` (class)
- `ApiAuthenticationServiceCollectionExtensions` (class)
- `AutoMapperServiceCollectionExtensions` (class)
- `ChageDatalogServiceCollectionExtensions` (class)
- `DistributedRedisCacheServiceCollectionExtensions` (class)
- `DistributedSqlCacheServiceCollectionExtensions` (class)
- `EPPlusExcelSerializerServiceCollectionExtensions` (class)
- `InMemoryCachingServiceCollectionExtensions` (class)
- `JwtTokenExtensions` (class)
- `MessageInboxServiceCollectionExtensions` (class)
- `MicrosoftSerializerServiceCollectionExtensions` (class)
- `NewtonSoftSerializerServiceCollectionExtensions` (class)
- `ParrotTranslatorServiceCollectionExtensions` (class)
- `PollingPublisherServiceCollectionExtensions` (class)
- `ProviderExtensions` (class)
- `RabbitMqMessageBusServiceCollectionExtensions` (class)
- `ReferenceTokenExtensions` (class)
- `ScalarServiceCollectionExtensions` (class)
- `SerilogServiceCollectionExtensions` (class)
- `SoftwarePartDetectorServiceCollectionExtensions` (class)

### Zamin.Extensions.DependencyInjection.Extensions.DependencyInjection

- `DependencyInjectionServiceCollectionExtensions` (class)

### Zamin.Extensions.DependencyInjection.Options

- `DependencyInjectionOption` (class)

### Zamin.Extensions.Events.Abstractions

- `IOutBoxEventItemRepository` (interface)
- `OutBoxEventItem` (class)

### Zamin.Extensions.Events.Outbox.Dal.EF.Configs

- `OutBoxEventItemConfig` (class)

### Zamin.Extensions.Events.Outbox.Dal.EF.Interceptors

- `AddOutBoxEventItemInterceptor` (class)

### Zamin.Extensions.Events.PollingPublisher

- `PoolingPublisherBackgroundService` (class)

### Zamin.Extensions.Events.PollingPublisher.Dal.Dapper.DataAccess

- `SqlOutBoxEventItemRepository` (class)

### Zamin.Extensions.Events.PollingPublisher.Dal.Dapper.Options

- `PollingPublisherDalRedisOptions` (class)

### Zamin.Extensions.Events.PollingPublisher.Options

- `PollingPublisherOptions` (class)

### Zamin.Extensions.Logger.Abstractions

- `ZaminEventId` (class)

### Zamin.Extensions.MessageBus.Abstractions

- `IMessageConsumer` (interface)
- `IMessageInboxItemRepository` (interface)
- `IReceiveMessageBus` (interface)
- `ISendMessageBus` (interface)
- `Parcel` (class)

### Zamin.Extensions.MessageBus.Abstractions.Fakes

- `FakeMessageConsumer` (class)
- `FakeReceiveMessageBus` (class)
- `FakeSendMessageBus` (class)

### Zamin.Extensions.MessageBus.MessageInbox

- `InboxMessageConsumer` (class)

### Zamin.Extensions.MessageBus.MessageInbox.Dal.Dapper

- `SqlMessageInboxItemRepository` (class)

### Zamin.Extensions.MessageBus.MessageInbox.Dal.Dapper.Options

- `MessageInboxDalDapperOptions` (class)

### Zamin.Extensions.MessageBus.MessageInbox.Options

- `MessageInboxOptions` (class)

### Zamin.Extensions.MessageBus.RabbitMQ

- `RabbitMqReceiveMessageBus` (class)
- `RabbitMqSendMessageBus` (class)
- `RabbitMqSendMessageBusConstants` (class)

### Zamin.Extensions.MessageBus.RabbitMQ.Options

- `RabbitMqOptions` (class)

### Zamin.Extensions.ObjectMappers.Abstractions

- `IMapperAdapter` (interface)

### Zamin.Extensions.ObjectMappers.AutoMapper.Options

- `AutoMapperOption` (class)

### Zamin.Extensions.ObjectMappers.AutoMapper.Services

- `AutoMapperAdapter` (class)

### Zamin.Extensions.ObjectMappers.Mapster.Services

- `IObjectMapper` (interface)
- `Mapster` (class)

### Zamin.Extensions.Serializers.Abstractions

- `IExcelSerializer` (interface)

### Zamin.Extensions.Serializers.EPPlus.Extensions

- `ExcelExtensions` (class)
- `LinqExtensions` (class)

### Zamin.Extensions.Serializers.EPPlus.Services

- `EPPlusExcelSerializer` (class)

### Zamin.Extensions.Serializers.Microsoft.Services

- `MicrosoftSerializer` (class)

### Zamin.Extensions.Serializers.NewtonSoft.Services

- `NewtonSoftSerializer` (class)

### Zamin.Extensions.Translations.Parrot.Database

- `ParrotSqlRepository` (class)

### Zamin.Extensions.Translations.Parrot.DataModel

- `LocalizationRecord` (class)

### Zamin.Extensions.Translations.Parrot.Options

- `DefaultTranslationOption` (class)

### Zamin.Extensions.UsersManagement.Extensions

- `ClaimExtensions` (class)

### Zamin.Extensions.UsersManagement.Services

- `WebUserInfoService` (class)

### Zamin.Infra.Data.Sql.Commands

- `BaseCommandDbContext` (class)
- `BaseEntityFrameworkUnitOfWork<TDbContext>` (class)

### Zamin.Infra.Data.Sql.Commands.Extensions

- `AuditableShadowProperties` (class)
- `ChangeTrackerExtensions` (class)
- `DbCommandExtension` (class)
- `ModelBuilderExtensions` (class)
- `RowVersionShadowProperty` (class)

### Zamin.Infra.Data.Sql.Commands.Interceptors

- `AddChangeDataLogInterceptor` (class)

### Zamin.Infra.Data.Sql.Commands.ValueConversions

- `BusinessIdConversion` (class)
- `DescriptionConversion` (class)
- `LegalNationalIdConversion` (class)
- `NationalCodeConversion` (class)
- `TitleConversion` (class)

### Zamin.Infra.Data.Sql.Queries

- `QueryRepositoryExtensions` (class)

### Zamin.Utilities.Auth.ApiAuthentication.Extensions

- `ClaimsPrincipalExtentions` (class)

### Zamin.Utilities.Auth.ApiAuthentication.Models

- `ClaimCacheModel` (class)

### Zamin.Utilities.Auth.ApiAuthentication.Options

- `CacheExpirationType` (enum)
- `CacheKeyFormat` (enum)
- `EndpointsPathOption` (class)
- `JwtTokenConfigOption` (class)
- `RefrenceTokenConfigOption` (class)
- `RegisterUserInfoClaimsOption` (class)
- `UserClaimAddonOption` (class)
- `UserClaimRuleOption` (class)

### Zamin.Utilities.DateTimes

- `DateTimeOffsetPart` (enum)
- `DateTimeUtils` (class)
- `FriendlyPersianDateUtils` (class)
- `PersianCulture` (class)
- `PersianDateTimeUtils` (class)
- `PersianDay` (class)
- `PersianMonth` (class)
- `PersianNumbersUtils` (class)
- `PersianYear` (class)
- `RegexUtils` (class)
- `TimeConstants` (class)
- `UnicodeConstants` (class)

### Zamin.Utilities.Extensions

- `DateTimeExtensions` (class)
- `EnumExtensions` (class)
- `GuidExtensions` (class)
- `LinqExtensions` (class)
- `ObjectExtensions` (class)
- `StringExtensions` (class)
- `StringValidatorExtensions` (class)
- `TypeExtentsions` (class)

### Zamin.Utilities.Guards

- `Guard` (class) — False positive: only comment text "Guard:" in AuthController

### Zamin.Utilities.Guards.GuardClauses

- `EmptyGuardClause` (class)
- `EqualGuardClause` (class)
- `ExclusiveBetweenGuardClause` (class)
- `GreaterThanGuardClause` (class)
- `GreaterThanOrEqualGuardClause` (class)
- `InclusiveBetweenGuardClause` (class)
- `LengthGuardClause` (class)
- `LessThanGuardClause` (class)
- `LessThanOrEqualGuardClause` (class)
- `MatchGuardClause` (class)
- `MaximumLengthGuardClause` (class)
- `MinimumLengthGuardClause` (class)
- `NotEmptyGuardClause` (class)
- `NotEqualGuardClause` (class)
- `NotNullGuardClause` (class)
- `NullGuardClause` (class)

### Zamin.Utilities.ScalarRegistration.Options

- `ScalarOption` (class)

### Zamin.Utilities.SerilogRegistration.Enrichers

- `ZaminApplicaitonEnricher` (class)
- `ZaminUserInfoEnricher` (class)

### Zamin.Utilities.SerilogRegistration.Options

- `SerilogApplicationEnricherOptions` (class)

### Zamin.Utilities.Sinks.Elasticsearch

- `LoggerConfigurationZaminElasticsearchExtensions` (class)

### Zamin.Utilities.SoftwarePartDetector

- `ControllersAndActionDetector` (class)

### Zamin.Utilities.SoftwarePartDetector.Attributes

- `SoftwarePartControllerOptionAttribute` (class)

### Zamin.Utilities.SoftwarePartDetector.Authentications

- `ISoftwarePartAuthentication` (interface)
- `SoftwarePartAuthentication` (class)

### Zamin.Utilities.SoftwarePartDetector.DataModel

- `SoftwarePartAction` (class)

### Zamin.Utilities.SoftwarePartDetector.Options

- `OAuthOption` (class)
- `SoftwarePartDetectorOptions` (class)

### Zamin.Utilities.SoftwarePartDetector.Publishers

- `ISoftwarePartPublisher` (interface)
- `SoftwarePartWebPublisher` (class)

## Entirely unused namespaces (no type hit and no dedicated registration doc)

- `Zamin.Core.ApplicationServices.Events`
- `Zamin.Core.Contracts.ApplicationServices.Events`
- `Zamin.Core.Domain.Events`
- `Zamin.Core.RequestResponse.Endpoints`
- `Zamin.EndPoints.Web.Filters`
- `Zamin.EndPoints.Web.Middlewares.ApiExceptionHandler`
- `Zamin.EndPoints.Web.ModelBinding`
- `Zamin.Extensions.Caching.Distributed.Redis.Services`
- `Zamin.Extensions.Caching.Distributed.Sql.Services`
- `Zamin.Extensions.Caching.InMemory.Services`
- `Zamin.Extensions.ChangeDataLog.Abstractions`
- `Zamin.Extensions.ChangeDataLog.Sql`
- `Zamin.Extensions.ChangeDataLog.Sql.Options`
- `Zamin.Extensions.DependencyInjection.Extensions.DependencyInjection`
- `Zamin.Extensions.DependencyInjection.Options`
- `Zamin.Extensions.Events.Abstractions`
- `Zamin.Extensions.Events.Outbox.Dal.EF.Configs`
- `Zamin.Extensions.Events.Outbox.Dal.EF.Interceptors`
- `Zamin.Extensions.Events.PollingPublisher`
- `Zamin.Extensions.Events.PollingPublisher.Dal.Dapper.DataAccess`
- `Zamin.Extensions.Events.PollingPublisher.Dal.Dapper.Options`
- `Zamin.Extensions.Events.PollingPublisher.Options`
- `Zamin.Extensions.Logger.Abstractions`
- `Zamin.Extensions.MessageBus.Abstractions`
- `Zamin.Extensions.MessageBus.Abstractions.Fakes`
- `Zamin.Extensions.MessageBus.MessageInbox`
- `Zamin.Extensions.MessageBus.MessageInbox.Dal.Dapper.Options`
- `Zamin.Extensions.MessageBus.MessageInbox.Options`
- `Zamin.Extensions.MessageBus.RabbitMQ`
- `Zamin.Extensions.MessageBus.RabbitMQ.Options`
- `Zamin.Extensions.ObjectMappers.Abstractions`
- `Zamin.Extensions.ObjectMappers.AutoMapper.Options`
- `Zamin.Extensions.ObjectMappers.AutoMapper.Services`
- `Zamin.Extensions.ObjectMappers.Mapster.Services`
- `Zamin.Extensions.Serializers.EPPlus.Extensions`
- `Zamin.Extensions.Serializers.EPPlus.Services`
- `Zamin.Extensions.Serializers.Microsoft.Services`
- `Zamin.Extensions.Serializers.NewtonSoft.Services`
- `Zamin.Extensions.Translations.Parrot.Database`
- `Zamin.Extensions.Translations.Parrot.DataModel`
- `Zamin.Extensions.UsersManagement.Extensions`
- `Zamin.Extensions.UsersManagement.Services`
- `Zamin.Infra.Data.Sql.Commands.Extensions`
- `Zamin.Infra.Data.Sql.Commands.ValueConversions`
- `Zamin.Utilities.Auth.ApiAuthentication.Extensions`
- `Zamin.Utilities.Auth.ApiAuthentication.Models`
- `Zamin.Utilities.DateTimes`
- `Zamin.Utilities.Extensions`
- `Zamin.Utilities.Guards.GuardClauses`
- `Zamin.Utilities.ScalarRegistration.Options`
- `Zamin.Utilities.SerilogRegistration.Enrichers`
- `Zamin.Utilities.SerilogRegistration.Options`
- `Zamin.Utilities.Sinks.Elasticsearch`
- `Zamin.Utilities.SoftwarePartDetector.Attributes`
- `Zamin.Utilities.SoftwarePartDetector.Authentications`
- `Zamin.Utilities.SoftwarePartDetector.Options`
- `Zamin.Utilities.SoftwarePartDetector.Publishers`
