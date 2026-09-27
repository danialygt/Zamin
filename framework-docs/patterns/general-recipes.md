# General recipes — Zamin usage patterns

Source of truth: real call-sites under `application source` (samples excluded unless noted).
No invented APIs — only documented usage patterns.

## 1. Host bootstrap (Program + Serilog)

Application hosts wrap startup in Zamin Serilog helper, then chain configuration → Zamin Serilog options → service registration → pipeline.

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

Same shape appears in secondary API host and WorkerService `Program.cs`.

## 2. Core DI registration order (API HostingExtensions)

Observed order in `src/Endpoints/API/DependencyInjection/HostingExtensions.cs`:

1. Register application logging decorators for Zamin dispatchers (`CommandDispatcherDecorator`, `QueryDispatcherDecorator`).
2. `AddZaminApiCore("Zamin", "MyApp")` — assembly scan for handlers / lifetime markers.
3. User-info / translator / software-part / serializer / AutoMapper / cache.
4. EF `AppCommandDbContext` / `AppQueryDbContext` with Zamin interceptors.
5. Auth + Swagger (`AddZaminApiAuthentication`, `AddZaminSwagger`).
6. Pipeline: `UseZaminApiExceptionHandler()` early, then auth, then `MapControllers`.
7. Post-build: `SoftwarePartDetectorService.Run()` and Parrot table initializer.

```csharp
// excerpt — ConfigureServices (API)
builder.Services.AddTransient<CommandDispatcherDecorator, LoggingCommandDispatcherDecorator>();
builder.Services.AddTransient<QueryDispatcherDecorator, LoggingQueryDispatcherDecorator>();

builder.Services.AddZaminApiCore("Zamin", "MyApp");
builder.Services.AddAppUserInfoService(builder.Configuration, "UserInfo");
builder.Services.AddZaminParrotTranslator(builder.Configuration, "ParrotTranslator");
builder.Services.AddSoftwarePartDetector(builder.Configuration, "SoftwarePart");
builder.Services.AddNonValidatingValidator();
builder.Services.AddZaminMicrosoftSerializer();
builder.Services.AddZaminAutoMapperProfiles(builder.Configuration, "AutoMapper");

if (builder.Configuration["DistributedCacheActive"] == nameof(DistributedRedisCacheOptions))
    builder.Services.AddZaminRedisDistributedCache(builder.Configuration, nameof(DistributedRedisCacheOptions));
else if (builder.Configuration["DistributedCacheActive"] == nameof(DistributedSqlCacheOptions))
    builder.Services.AddZaminSqlDistributedCache(builder.Configuration, nameof(DistributedSqlCacheOptions));
else
    throw new ArgumentException("There is no valid DistributedCacheActive on appsettings.");

builder.Services.AddDbContext<AppCommandDbContext>((sp, c) =>
    c.UseSqlServer(builder.Configuration.GetConnectionString("CommandDb_ConnectionString"))
     .AddInterceptors(
         new SetPersianYeKeInterceptor(),
         new AddAuditDataInterceptor(),
         sp.GetRequiredService<ClientCacheInvalidationInterceptor>()));

builder.Services.AddZaminSwagger(builder.Configuration, "Swagger");
builder.Services.AddZaminApiAuthentication(builder.Configuration, "ApiAuthentication");
```

```csharp
// excerpt — ConfigurePipeline (API)
app.UseZaminApiExceptionHandler();
app.UseSerilogRequestLogging();
// ... application middlewares, auth ...
app.MapControllers().RequireAuthorization();

app.Services.GetService<SoftwarePartDetectorService>()?.Run();

var options = app.Services.GetService<IOptions<ParrotTranslatorOptions>>()?.Value
    ?? throw new NullReferenceException();
ParrotTranslatorInitializer.Initialize(options.ConnectionString, options.SchemaName, options.TableName);
```

### WorkerService differences (observed)

- Still calls `AddZaminApiCore`, Parrot, serializer, AutoMapper, cache, EF + same interceptors.
- Actively registers `AddZaminPollingPublisherDalSql` and `AddZaminMessageInboxDalSql`.
- RabbitMQ / PollingPublisher / MessageInbox **application** registrations and ChangeDataLog are present but **commented out**.
- Pipeline does **not** call `UseZaminApiExceptionHandler`.

## 3. Vertical slice recipe (command)

Typical command flow seen repeatedly:

1. Request DTO: `record XCommand : ICommand` or `ICommand<TData>`.
2. Handler: `CommandHandler<TCommand>` / `CommandHandler<TCommand,TData>(ZaminServices)` + injected repositories/domain services.
3. Domain: `AggregateRoot` factory → mutate → repository `InsertAsync`/`GetAsync` → `CommitAsync`.
4. Return: `Ok()` / `OkAsync(data)` / `Result(...)` from base handler (`CommandResult`).
5. API: controller inheriting `BaseController` calls `Create` / `Edit` / `Delete` helpers which dispatch via Zamin.

```csharp
// Handler — src/Application/Samples/Commands/Create/SampleCreateHandler.cs
public class SampleCreateHandler(
    ZaminServices zaminServices,
    ISampleCommandRepository sampleCommandRepository,
    ISampleValidationService sampleValidationService)
    : CommandHandler<SampleCreateCommand, Guid>(zaminServices)
{
    public override async Task<CommandResult<Guid>> Handle(SampleCreateCommand command)
    {
        await sampleValidationService.EnsureUniqueNameAsync((SampleName)command.Name);

        Sample entity = Sample.Create(command.ToParameter());

        await sampleCommandRepository.InsertAsync(entity);

        await sampleCommandRepository.CommitAsync();

        return await OkAsync(entity.BusinessId.Value);
    }
}
```

```csharp
// Controller — src/Endpoints/API/Features/Samples/SampleController.cs
public sealed class SampleController : BaseController
{
    [HttpPost]
    [ProducesResponseType(typeof(Guid), 201)]
    public async Task<IActionResult> Create([FromBody] SampleCreateCommand command)
        => await Create<SampleCreateCommand, Guid>(command);

    [HttpPost]
    public async Task<IActionResult> Update([FromBody] SampleUpdateCommand command)
        => await Edit(command);

    [HttpPost]
    public async Task<IActionResult> Delete([FromBody] SampleDeleteCommand command)
        => await base.Delete(command);
}
```

## 4. Vertical slice recipe (query)

1. `record XQuery : IQuery<T>` (often with paged result types / `PageQuery`).
2. `QueryHandler<TQuery,TData>(ZaminServices)` → query repository `ExecuteAsync` → `Result(...)`.
3. Controller: `Query<TQuery,TData>(query)`.

```csharp
// SampleGetPagedFilterQueryHandler.cs
public sealed class SampleGetPagedFilterQueryHandler(
    ZaminServices zaminServices,
    ISampleQueryRepository queryRepository)
    : QueryHandler<SampleGetPagedFilterQuery, PagedData<SampleListItemDto>>(zaminServices)
{
    public override async Task<QueryResult<PagedData<SampleListItemDto>>> Handle(SampleGetPagedFilterQuery query)
    {
        var queryResult = await queryRepository.ExecuteAsync(query);
        return Result(queryResult);
    }
}
```

## 5. Domain + persistence composition

- Domain aggregates inherit `AggregateRoot` / `AggregateRoot<TId>`; child entities inherit `Entity` / `Entity<TId>`.
- Value objects inherit `BaseValueObject<T>` and throw `InvalidValueObjectStateException` on invalid input.
- Aggregate invariants throw `InvalidEntityStateException`.
- Command DbContext inherits `BaseOutboxCommandDbContext`; Query DbContext inherits `BaseQueryDbContext`.
- Repositories: `BaseCommandRepository<TEntity, AppCommandDbContext, TId>` and `BaseQueryRepository<AppQueryDbContext>`.
- Contracts: `ICommandRepository<TEntity,TId>` / `IQueryRepository`.
- App-service lifetime: marker interfaces `ITransientLifetime` (and siblings) on contracts; discovered via `AddZaminApiCore`.

## 6. Cross-cutting services used with Zamin

| Concern | How to wire it |
|---------|------------------|
| Translation | `AddZaminParrotTranslator` + `ITranslator` in validators/controllers |
| User context | `IUserInfoService` via `ZaminServices.UserInfoService` and ctor injection |
| Cache | Config switch Redis vs SQL → `ICacheAdapter` |
| JSON | `AddZaminMicrosoftSerializer` → `IJsonSerializer` (e.g. Duende stores) |
| Dispatcher logging | Custom `*DispatcherDecorator` registered as `CommandDispatcherDecorator` / `QueryDispatcherDecorator` |
| Exceptions to HTTP | `UseZaminApiExceptionHandler()` (API host) |

## 7. Exception handling observed

- Domain/value-object exceptions are **thrown** in domain (`InvalidEntityStateException`, `InvalidValueObjectStateException`).
- Application layer sometimes **catches** them locally:
  - `UserInfoServiceExtentions.GetUserSubOrDefault` catches `InvalidEntityStateException` → `Guid.Empty`.
  - `SampleExpressionAnalyzer` catches `InvalidValueObjectStateException` and falls back to string search.
- Dispatcher decorators catch generic `Exception`, log, then rethrow.
- **No** `catch (DomainStateException)` found under `src/`.

## 8. Call order summary (command path)

`HTTP` → `BaseController.Create/Edit/Delete` → (Zamin) `ICommandDispatcher` (+ app `LoggingCommandDispatcherDecorator`) → `CommandHandler.Handle` → domain + `ICommandRepository` → `CommitAsync` → `CommandResult` → controller `IActionResult`.

Query path mirrors with `Query` / `IQueryDispatcher` / `QueryHandler` / `IQueryRepository` (no `CommitAsync`).
