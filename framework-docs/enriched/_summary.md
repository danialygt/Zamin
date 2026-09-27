# Zamin API Doc Enrichment Summary

Generated at (UTC): 2026-09-27T08:24:40.0435153Z

## Counts

- Namespaces processed: **97**
- Items with original author XML kept as primary (`source: existing`): **197** (= 131 unmodified + 66 completed)
  - Unmodified meaning preserved: **131**
  - Completed/supplemented where XML was incomplete (missing params/returns): **66**
- Items fully generated (`source: generated`): **1137**
- Human-review candidates: **22**

## Notes

- Raw files under `framework-docs/raw-extraction/` were left untouched.
- Enriched output is under `framework-docs/enriched/{Namespace}.json`.
- Each type/member includes `generated_doc.fa`, `generated_doc.en`, and `source` (`existing` | `generated`).
- Exception/precondition notes are only claimed when detectable from signature/body patterns.
- CommandDispatcher `Send` overloads and their validation/domain-exception decorators were hand-curated from source for higher accuracy.
- Regenerator tool: `tools/Zamin.DocEnricher` (`dotnet run --project tools/Zamin.DocEnricher -- <repo> <raw> <enriched>`).

## Human review list

Items below still deserve a human pass because of long/branchy bodies, `dynamic`, or non-obvious logic. Generated docs exist but should be verified.

| Namespace | Type | Member | Kind | Reason | Source file |
|---|---|---|---|---|---|
| Zamin.Core.ApplicationServices.Queries | QueryDispatcher | Execute | method | منطق مرکزی dispatcher/decorator | Onion/src/2.Core/Zamin.Core.ApplicationServices/Queries/QueryDispatcher.cs |
| Zamin.Core.ApplicationServices.Queries | QueryDispatcherDomainExceptionHandlerDecorator | Execute | method | منطق مرکزی dispatcher/decorator | Onion/src/2.Core/Zamin.Core.ApplicationServices/Queries/QueryDispatcherDomainExceptionHandlerDecorator.cs |
| Zamin.Core.ApplicationServices.Queries | QueryDispatcherValidationDecorator | Execute | method | منطق مرکزی dispatcher/decorator | Onion/src/2.Core/Zamin.Core.ApplicationServices/Queries/QueryDispatcherValidationDecorator.cs |
| Zamin.Extensions.ChangeDataLog.Sql | DapperEntityChangeInterceptorItemRepository | SaveAsync | method | بدنه بسیار طولانی/پیچیده | Extentsions/Databases/Zamin.Extensions.ChangeDataLog/Zamin.Extensions.ChangeDataLog.Sql/DapperEntityChangeInterceptorItemRepository.cs |
| Zamin.Extensions.ChangeDataLog.Sql | DapperEntityChangeInterceptorItemRepository | Save | method | بدنه بسیار طولانی/پیچیده | Extentsions/Databases/Zamin.Extensions.ChangeDataLog/Zamin.Extensions.ChangeDataLog.Sql/DapperEntityChangeInterceptorItemRepository.cs |
| Zamin.Extensions.ChangeDataLog.Sql | DapperEntityChangeInterceptorItemRepository | .ctor | constructor | بدنه بسیار طولانی/پیچیده | Extentsions/Databases/Zamin.Extensions.ChangeDataLog/Zamin.Extensions.ChangeDataLog.Sql/DapperEntityChangeInterceptorItemRepository.cs |
| Zamin.Extensions.DependencyInjection | JwtTokenExtensions | AddJwtTokenSupoort | method | بدنه بسیار طولانی/پیچیده | Utilities/Auth/ApiAuthentication/Zamin.Utilities.Auth.ApiAuthentication/Extensions/JwtTokenExtensions.cs |
| Zamin.Extensions.DependencyInjection | ProviderExtensions | UserInfoEndpointCaller | method | بدنه بسیار طولانی/پیچیده | Utilities/Auth/ApiAuthentication/Zamin.Utilities.Auth.ApiAuthentication/Extensions/ProviderExtensions.cs |
| Zamin.Extensions.DependencyInjection | ReferenceTokenExtensions | AddReferenceTokenSupoort | method | بدنه بسیار طولانی/پیچیده | Utilities/Auth/ApiAuthentication/Zamin.Utilities.Auth.ApiAuthentication/Extensions/ReferenceTokenExtensions.cs |
| Zamin.Extensions.Events.PollingPublisher | PoolingPublisherBackgroundService | ExecuteAsync | method | بدنه بسیار طولانی/پیچیده | Extentsions/Events/Zamin.Extensions.Events.PollingPublisher/Zamin.Extensions.Events.PollingPublisher/PoolingPublisherBackgroundService.cs |
| Zamin.Extensions.MessageBus.MessageInbox | InboxMessageConsumer | ConsumeEvent | method | استفاده از dynamic | Extentsions/MessageBus/Zamin.Extensions.MessageBus.MessageInbox/Zamin.Extensions.MessageBus.MessageInbox/InboxMessageConsumer.cs |
| Zamin.Extensions.MessageBus.MessageInbox | InboxMessageConsumer | ConsumeCommand | method | استفاده از dynamic | Extentsions/MessageBus/Zamin.Extensions.MessageBus.MessageInbox/Zamin.Extensions.MessageBus.MessageInbox/InboxMessageConsumer.cs |
| Zamin.Infra.Data.Sql.Commands | BaseCommandDbContext | GetIncludePaths | method | بدنه بسیار طولانی/پیچیده | Onion/src/3.Infra/Data/Zamin.Infra.Data.Sql.Commands/BaseCommandDbContext.cs |
| Zamin.Infra.Data.Sql.Commands.Extensions | AuditableShadowProperties | AddAuditableShadowProperties | method | توضیح تولیدشده عمومی روی منطق غیربدیهی | Onion/src/3.Infra/Data/Zamin.Infra.Data.Sql.Commands/Extensions/AuditableShadowProperties.cs |
| Zamin.Utilities.Extensions | ObjectExtensions | ToQueryString | method | بدنه بسیار طولانی/پیچیده | Onion/src/1.Utilities/Zamin.Utilities/Extensions/ObjectExtensions.cs |
| Zamin.Utilities.Sinks.Elasticsearch | LoggerConfigurationZaminElasticsearchExtensions | ZaminElasticsearch | method | بدنه بسیار طولانی/پیچیده؛ شاخه‌بندی زیاد | Utilities/Sinks/Elasticsearch/Zamin.Utilities.Sinks.Elasticsearch/LoggerConfigurationZaminElasticsearchExtensions.cs |
| Zamin.Utilities.SoftwarePartDetector | ControllersAndActionDetector | Detect | method | بدنه بسیار طولانی/پیچیده | Utilities/SoftwarePartDetector/Zamin.Utilities.SoftwarepartDetector/Detectors/ControllersAndActionDetector.cs |
| Zamin.Utilities.SoftwarePartDetector | SoftwarePartDetector | Detect | method | بدنه بسیار طولانی/پیچیده | Utilities/SoftwarePartDetector/Zamin.Utilities.SoftwarepartDetector/Detectors/SoftwarePartDetector.cs |
| Zamin.Utilities.SoftwarePartDetector.Authentications | SoftwarePartAuthentication | LoginAsync | method | توضیح تولیدشده عمومی روی منطق غیربدیهی | Utilities/SoftwarePartDetector/Zamin.Utilities.SoftwarepartDetector/Authentications/SoftwarePartAuthentication.cs |
| Zamin.Utilities.SoftwarePartDetector.Services | SoftwarePartDetectorService | Run | method | توضیح تولیدشده عمومی روی منطق غیربدیهی | Utilities/SoftwarePartDetector/Zamin.Utilities.SoftwarepartDetector/Services/SoftwarePartDetectorService.cs |
