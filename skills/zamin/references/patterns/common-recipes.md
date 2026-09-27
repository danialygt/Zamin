# Common recipes — الگوهای کاربردی زمین

این فایل بازنویسی مرتب‌شده‌ی `general-recipes.md` و `patterns/by-namespace/*.md` است. فقط الگوهای صحیح استفاده‌ی مستندشده آمده‌اند.

## فهرست Recipeها

- [CommandHandler و مسیر Command](#recipe-command-handler)
- [QueryHandler و مسیر Query](#recipe-query-handler)
- [ICommandDispatcher از طریق BaseController](#recipe-command-dispatcher)
- [IQueryDispatcher از طریق BaseController](#recipe-query-dispatcher)
- [قراردادهای ICommand / CommandResult](#recipe-command-contracts)
- [قراردادهای IQuery / PageQuery / PagedData](#recipe-query-contracts)
- [ApplicationServiceStatus](#recipe-application-service-status)
- [AggregateRoot و Entity](#recipe-aggregate-entity)
- [BaseValueObject و BusinessId](#recipe-value-objects)
- [Toolkit value objects (Title, …)](#recipe-toolkit-value-objects)
- [استثناهای دامنه](#recipe-domain-exceptions)
- [ICommandRepository و BaseCommandRepository](#recipe-command-repository)
- [IQueryRepository و BaseQueryRepository](#recipe-query-repository)
- [BaseOutboxCommandDbContext](#recipe-outbox-dbcontext)
- [Interceptorهای EF فرمان](#recipe-ef-interceptors)
- [BaseController](#recipe-base-controller)
- [HttpContextExtensions](#recipe-http-context-extensions)
- [Model binding extensions](#recipe-model-binding)
- [ZaminServices در Handlerها](#recipe-zamin-services)
- [IUserInfoService](#recipe-user-info)
- [ITranslator](#recipe-translator)
- [TranslatorKeys / TranslatorValues](#recipe-translator-keys)
- [ICacheAdapter](#recipe-cache-adapter)

## Recipe: برش عمودی Command (از HTTP تا Commit) {#recipe-vertical-command}

**توضیح:** جریان تکراری پیشنهادی: DTO با `ICommand`/`ICommand<TData>` → `CommandHandler` → Aggregate + `ICommandRepository` → `CommitAsync` → `CommandResult` از طریق `BaseController`.

**کد نمونه:**

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

**نکات مهم:**

- ترتیب call: `HTTP` → `BaseController` → `ICommandDispatcher` (+ decorator لاگ اپلیکیشن) → `Handle` → repository → `CommitAsync`.
- Exception دامنه معمولاً bubble می‌شود مگر handler خودش catch کند.

## Recipe: برش عمودی Query {#recipe-vertical-query}

**توضیح:** `IQuery<T>` → `QueryHandler` → `IQueryRepository.ExecuteAsync` → `QueryResult` → `BaseController.Query`.

**کد نمونه:**

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

**نکات مهم:**

- مسیر query معمولاً `CommitAsync` ندارد.

## Recipe: CommandHandler و مسیر Command {#recipe-command-handler}

**توضیح:** Handlerها از `CommandHandler<TCommand>` / `CommandHandler<TCommand,TData>` ارث می‌برند، `ZaminServices` را به base می‌دهند و از repository/domain استفاده می‌کنند.

**Types documented in usage patterns:** `CommandHandler<TCommand>`, `CommandHandler<TCommand,TData>`, `CommandDispatcherDecorator`, `CommandDispatcher` (via decorator chain / DI).

**کد نمونه:**

```csharp
// src/Endpoints/API/DependencyInjection/HostingExtensions.cs
builder.Services.AddTransient<CommandDispatcherDecorator, LoggingCommandDispatcherDecorator>();
builder.Services.AddTransient<QueryDispatcherDecorator, LoggingQueryDispatcherDecorator>();
builder.Services.AddZaminApiCore("Zamin", "MyApp");
```

```csharp
// src/Application/Samples/Commands/Create/SampleCreateHandler.cs
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

**نکات مهم:**

- Handlers are **not** new'ed manually; discovered by `AddZaminApiCore("Zamin", "MyApp")`.
- The application registers a custom decorator: `AddTransient<CommandDispatcherDecorator, LoggingCommandDispatcherDecorator>()` before `AddZaminApiCore`.
- Primary ctor always receives `ZaminServices` first (passed to base `CommandHandler`).
- Additional deps: command repositories, domain validation services, optional infra services.
- Return helpers from base: `Ok()`, `OkAsync(T)`, `Result(...)`.

- Namespace مرتبط: `Zamin.Core.ApplicationServices.Commands`

## Recipe: QueryHandler و مسیر Query {#recipe-query-handler}

**توضیح:** Handler کوئری از `QueryHandler<TQuery,TData>` ارث می‌برد و معمولاً با query repository کار می‌کند.

**Types in this pattern:** `QueryHandler<TQuery,TData>`, `QueryDispatcherDecorator`, `QueryDispatcher` (via DI).

**کد نمونه:**

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

**نکات مهم:**

- جزئیات بیشتر در api-reference برای `Zamin.Core.ApplicationServices.Queries`.

- Namespace مرتبط: `Zamin.Core.ApplicationServices.Queries`

## Recipe: ICommandDispatcher از طریق BaseController {#recipe-command-dispatcher}

**توضیح:** کنترلرها مستقیم dispatcher را صدا نمی‌زنند؛ از helperهای BaseController استفاده می‌شود که به ICommandDispatcher می‌رسد.

**Types in this pattern:** `ICommandDispatcher`.

**کد نمونه:**

```csharp
// src/Endpoints/API/Features/Samples/SampleController.cs
public sealed class SampleController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] SampleCreateCommand command)
        => await Create<SampleCreateCommand, Guid>(command);

    [HttpGet]
    public async Task<IActionResult> GetDetail([FromQuery] SampleGetDetailQuery query)
        => await Query<SampleGetDetailQuery, SampleDetailDto?>(query);
}
```

**نکات مهم:**

- جزئیات بیشتر در api-reference برای `Zamin.Core.Contracts.ApplicationServices.Commands`.

- Namespace مرتبط: `Zamin.Core.Contracts.ApplicationServices.Commands`

## Recipe: IQueryDispatcher از طریق BaseController {#recipe-query-dispatcher}

**توضیح:** مسیر query مشابه command است با helper `Query<TQuery,TData>`.

**Types in this pattern:** `IQueryDispatcher`.

**کد نمونه:**

```csharp
// src/3.Endpoints/API/Features/Users/UserController.cs
public async Task<IActionResult> GetPagedFilter([FromQuery] SampleGetPagedFilterQuery query)
    => await Query<SampleGetPagedFilterQuery, PagedData<SampleListItemDto>>(query);
```

**نکات مهم:**

- جزئیات بیشتر در api-reference برای `Zamin.Core.Contracts.ApplicationServices.Queries`.

- Namespace مرتبط: `Zamin.Core.Contracts.ApplicationServices.Queries`

## Recipe: قراردادهای ICommand / CommandResult {#recipe-command-contracts}

**توضیح:** DTO فرمان: `ICommand` یا `ICommand<TData>`؛ خروجی handler از نوع `CommandResult` / `CommandResult<TData>`.

**Types in this pattern:** `ICommand`, `ICommand<TData>`, `CommandResult`, `CommandResult<TData>`.

**کد نمونه:**

```csharp
// src/1.Core/RequestResponse/Samples/Commands/Create/SampleCreateCommand.cs
public sealed record SampleCreateCommand : ICommand<Guid>
{
    public string Name { get; set; } = default!;
    public string? DisplayName { get; set; }
    public string? Description { get; set; }
}
```

```csharp
// src/Application/Samples/Commands/Create/SampleCreateHandler.cs
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

**نکات مهم:**

- جزئیات بیشتر در api-reference برای `Zamin.Core.RequestResponse.Commands`.

- Namespace مرتبط: `Zamin.Core.RequestResponse.Commands`

## Recipe: قراردادهای IQuery / PageQuery / PagedData {#recipe-query-contracts}

**توضیح:** کوئری‌ها `IQuery<TData>` هستند؛ صفحه‌بندی با `PageQuery` و `PagedData` مشاهده شده است.

**Types in this pattern:** `IQuery<TData>`, `QueryResult<TData>`, `PagedData<T>`, `PageQuery<TData>`.

**کد نمونه:**

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

**نکات مهم:**

- جزئیات بیشتر در api-reference برای `Zamin.Core.RequestResponse.Queries`.

- Namespace مرتبط: `Zamin.Core.RequestResponse.Queries`

## Recipe: ApplicationServiceStatus {#recipe-application-service-status}

**توضیح:** وضعیت نتیجه سرویس اپلیکیشن در نتایج command/query.

**Types in this pattern:** `ApplicationServiceStatus`.

**کد نمونه:**

```csharp
// src/1.Core/ApplicationService/Common/Decorator/LoggingQueryDispatcherDecorator.cs
activity?.SetTag("app.status", result.Status.ToString());
AppBusinessMetrics.QueryExecuted(queryName, result.Status.ToString());
// ...
case ApplicationServiceStatus.Ok:
    logType = LogType.UserActivity;
    break;
case ApplicationServiceStatus.Exception:
    logType = LogType.ErrorManagement;
    break;
```

**نکات مهم:**

- جزئیات بیشتر در api-reference برای `Zamin.Core.RequestResponse.Common`.

- Namespace مرتبط: `Zamin.Core.RequestResponse.Common`

## Recipe: AggregateRoot و Entity {#recipe-aggregate-entity}

**توضیح:** Aggregateها از `AggregateRoot` / `AggregateRoot<TId>` و موجودیت‌های وابسته از `Entity` / `Entity<TId>` ارث می‌برند.

**Types in this pattern:** `AggregateRoot`, `AggregateRoot<TId>`, `Entity`, `Entity<TId>`.

**کد نمونه:**

```csharp
// src/Domain/Samples/Entities/Sample.cs
public sealed class Sample : AggregateRoot<int>
{
    private Sample() { }

    private Sample(SampleCreateParameter parameter) : this()
    {
        Name = parameter.Name;
        DisplayName = parameter.DisplayName;
        Description = parameter.Description;
        Protected = false;
        Primary = parameter.Primary;
    }

    public static Sample Create(SampleCreateParameter parameter) => new(parameter);

    public void ChangeProtectedStatus(bool status)
    {
        if (Primary.Equals(true))
        {
            throw new InvalidEntityStateException("Cannot modify primary sample", Name.Value);
        }
        Protected = status;
    }
}
```

**نکات مهم:**

- Aggregates: `public sealed class Sample : AggregateRoot<int>`
- Child/query-side entities often `Entity<long>`
- Private parameterless ctor for ORM; public factory `Create`.

- Namespace مرتبط: `Zamin.Core.Domain.Entities`

## Recipe: BaseValueObject و BusinessId {#recipe-value-objects}

**توضیح:** Value objectها از `BaseValueObject<T>` ارث می‌برند.

**Types in this pattern:** `BaseValueObject<TValueObject>`, `BusinessId`.

**کد نمونه:**

```csharp
// src/1.Core/Domain/Common/ValueObjects/Code.cs
public sealed class Code : BaseValueObject<Code>
{
    private Code(string value)
    {
        Validate(value);
        Value = value.Trim();
    }

    public static Code FromString(string value) => new(value);

    public static void Validate(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new InvalidValueObjectStateException("Value is not valid", CODE);
        // ...
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
```

**نکات مهم:**

- جزئیات بیشتر در api-reference برای `Zamin.Core.Domain.ValueObjects`.

- Namespace مرتبط: `Zamin.Core.Domain.ValueObjects`

## Recipe: Toolkit value objects (Title, …) {#recipe-toolkit-value-objects}

**توضیح:** VOهای آماده مثل Title / Description / NationalCode / Priority در دامنه‌ی اپلیکیشن استفاده شده‌اند.

**Types observed (identifier hits):** `Description`, `NationalCode`, `Priority`, `Title`.

**کد نمونه:**

مستندات کافی موجود نیست

**نکات مهم:**

- جزئیات بیشتر در api-reference برای `Zamin.Core.Domain.Toolkits.ValueObjects`.

- Namespace مرتبط: `Zamin.Core.Domain.Toolkits.ValueObjects`

## Recipe: استثناهای دامنه {#recipe-domain-exceptions}

**توضیح:** `InvalidEntityStateException` و `InvalidValueObjectStateException` در دامنه throw می‌شوند.

**Types in this pattern:** `InvalidEntityStateException`, `InvalidValueObjectStateException`.

**کد نمونه:**

```csharp
// src/1.Core/ApplicationService/Common/Extensions/UserInfoServiceExtentions.cs
public static Guid GetUserSubOrDefault(this IUserInfoService userInfoService)
{
    try
    {
        return userInfoService.GetUserSub();
    }
    catch (InvalidEntityStateException)
    {
        return Guid.Empty;
    }
}
```

```csharp
// src/1.Core/Application/Services/SampleExpressionAnalyzer.cs
try
{
    using var document = ParseExpression(expression);
    return CollectConditions(document.RootElement).Any(...);
}
catch (InvalidValueObjectStateException)
{
    return ExpressionContainsAttributeFallback(expression, attributeName);
}
```

**نکات مهم:**

- Aggregates / entities for invariant violations.
- Value objects on invalid construction.

- Namespace مرتبط: `Zamin.Core.Domain.Exceptions`

## Recipe: ICommandRepository و BaseCommandRepository {#recipe-command-repository}

**توضیح:** ریپازیتوری فرمان از `BaseCommandRepository<...>` ارث می‌برد و قرارداد `ICommandRepository` را پیاده می‌کند.

**Types in this pattern:** `BaseCommandRepository<TEntity,TDbContext,TId>` (and non-generic-id overload).

**کد نمونه:**

```csharp
// src/Infra/Sql.Commands/Sliders/SliderCommandRepository.cs
public sealed class SliderCommandRepository(AppCommandDbContext dbContext)
        : BaseCommandRepository<Sample, AppCommandDbContext, long>(dbContext), ISampleCommandRepository
{
    public async Task<List<Sample>> GetAllAsync()
    {
        return await _dbContext.Sliders.ToListAsync();
    }
}
```

**نکات مهم:**

- جزئیات بیشتر در api-reference برای `Zamin.Infra.Data.Sql.Commands`.

- Namespace مرتبط: `Zamin.Infra.Data.Sql.Commands`

## Recipe: IQueryRepository و BaseQueryRepository {#recipe-query-repository}

**توضیح:** ریپازیتوری کوئری از `BaseQueryRepository<TDbContext>` و `BaseQueryDbContext` استفاده می‌کند.

**Types in this pattern:** `BaseQueryDbContext`, `BaseQueryRepository<TDbContext>`.

**کد نمونه:**

```csharp
// src/Infra/Sql.Queries/Common/AppQueryDbContext.cs
public class AppQueryDbContext(DbContextOptions<AppQueryDbContext> options) : BaseQueryDbContext(options)
{
    public DbSet<User> Users { get; set; } = default!;
}
```

```csharp
// src/2.Infra/Data/Sql.Queries/Users/SampleQueryRepository.cs
public class SampleQueryRepository(AppQueryDbContext dbContext, IConfiguration configuration)
    : BaseQueryRepository<AppQueryDbContext>(dbContext), ISampleQueryRepository
{
    public async Task<UserProfileQr?> ExecuteAsync(UserGetProfileDbQuery query)
    {
        return await _dbContext.Users
            .Where(user => user.ExpireDateTime == null || user.ExpireDateTime > DateTime.Now)
            // ...
            .Select(user => new UserProfileQr() { BusinessId = user.BusinessId, /* ... */ })
            .FirstOrDefaultAsync();
    }
}
```

**نکات مهم:**

- جزئیات بیشتر در api-reference برای `Zamin.Infra.Data.Sql.Queries`.

- Namespace مرتبط: `Zamin.Infra.Data.Sql.Queries`

## Recipe: BaseOutboxCommandDbContext {#recipe-outbox-dbcontext}

**توضیح:** Command DbContext اپلیکیشن از `BaseOutboxCommandDbContext` ارث می‌برد.

**Types in this pattern:** `BaseOutboxCommandDbContext`.

**کد نمونه:**

```csharp
// src/Infra/Sql.Commands/Common/AppCommandDbContext.cs
public class AppCommandDbContext(DbContextOptions<AppCommandDbContext> options)
    : BaseOutboxCommandDbContext(options), IDataProtectionKeyContext
{
    public DbSet<Sample> Samples { get; set; } = default!;
    // ...
}
```

**نکات مهم:**

- جزئیات بیشتر در api-reference برای `Zamin.Extensions.Events.Outbox.Dal.EF`.

- Namespace مرتبط: `Zamin.Extensions.Events.Outbox.Dal.EF`

## Recipe: Interceptorهای EF فرمان {#recipe-ef-interceptors}

**توضیح:** `SetPersianYeKeInterceptor` و `AddAuditDataInterceptor` روی Command DbContext ثبت می‌شوند.

**Types in this pattern:** `SetPersianYeKeInterceptor`, `AddAuditDataInterceptor`.

**کد نمونه:**

```csharp
.AddInterceptors(
    new SetPersianYeKeInterceptor(),
    new AddAuditDataInterceptor(),
    sp.GetRequiredService<ClientCacheInvalidationInterceptor>());
```

**نکات مهم:**

- جزئیات بیشتر در api-reference برای `Zamin.Infra.Data.Sql.Commands.Interceptors`.

- Namespace مرتبط: `Zamin.Infra.Data.Sql.Commands.Interceptors`

## Recipe: BaseController {#recipe-base-controller}

**توضیح:** کنترلرهای API از `BaseController` و متدهای `Create` / `Edit` / `Delete` / `Query` استفاده می‌کنند.

**Types in this pattern:** `BaseController`.

**کد نمونه:**

```csharp
// src/Endpoints/API/Features/Samples/SampleController.cs
public sealed class SampleController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] SampleCreateCommand command)
        => await Create<SampleCreateCommand, Guid>(command);

    [HttpGet]
    public async Task<IActionResult> GetDetail([FromQuery] SampleGetDetailQuery query)
        => await Query<SampleGetDetailQuery, SampleDetailDto?>(query);
}
```

**نکات مهم:**

- `Create` / `Create<TCommand,TData>`
- `Edit`
- `Delete`
- `Query<TQuery,TData>`

- Namespace مرتبط: `Zamin.EndPoints.Web.Controllers`

## Recipe: HttpContextExtensions {#recipe-http-context-extensions}

**توضیح:** الگوی استفاده مشاهده‌شده در اپلیکیشن برای extensionهای HTTP.

**Types in this pattern:** `HttpContextExtensions` (extension methods).

**کد نمونه:**

مستندات کافی موجود نیست

**نکات مهم:**

- جزئیات بیشتر در api-reference برای `Zamin.EndPoints.Web.Extensions`.

- Namespace مرتبط: `Zamin.EndPoints.Web.Extensions`

## Recipe: Model binding extensions {#recipe-model-binding}

**توضیح:** الگوی model binding مرتبط با EndPoints.Web.

No public type name hits required for usage — the host calls:

**کد نمونه:**

```csharp
builder.Services.AddNonValidatingValidator();
```

**نکات مهم:**

- جزئیات بیشتر در api-reference برای `Zamin.EndPoints.Web.Extensions.ModelBinding`.

- Namespace مرتبط: `Zamin.EndPoints.Web.Extensions.ModelBinding`

## Recipe: ZaminServices در Handlerها {#recipe-zamin-services}

**توضیح:** `ZaminServices` به هر CommandHandler/QueryHandler تزریق می‌شود و سرویس‌های مشترک (مثل UserInfo) را در دسترس می‌گذارد.

**Types in this pattern:** `ZaminServices`.

**کد نمونه:**

```csharp
// src/Application/Samples/Commands/Create/SampleCreateHandler.cs
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
// decorator access
var userIp = zaminServices.UserInfoService.GetUserIp();
var userId = zaminServices.UserInfoService.GetUserSubOrDefault();
```

**نکات مهم:**

- جزئیات بیشتر در api-reference برای `Zamin.Utilities`.

- Namespace مرتبط: `Zamin.Utilities`

## Recipe: IUserInfoService {#recipe-user-info}

**توضیح:** دسترسی به کاربر جاری از طریق `IUserInfoService` یا `zaminServices.UserInfoService`.

**Types in this pattern:** `IUserInfoService`, `FakeUserInfoService`.

**کد نمونه:**

```csharp
// src/1.Core/ApplicationService/Common/Extensions/UserInfoServiceExtentions.cs
public static Guid GetUserSub(this IUserInfoService userInfoService)
{
    string? sub = userInfoService.UserId();
    if (string.IsNullOrWhiteSpace(sub))
        throw new InvalidEntityStateException("User data not found", "UserId");
    return Guid.Parse(sub);
}
```

**نکات مهم:**

- جزئیات بیشتر در api-reference برای `Zamin.Extensions.UsersManagement.Abstractions`.

- Namespace مرتبط: `Zamin.Extensions.UsersManagement.Abstractions`

## Recipe: ITranslator {#recipe-translator}

**توضیح:** ترجمه پیام‌ها از طریق `ITranslator` (پیاده‌سازی Parrot).

**Types in this pattern:** `ITranslator`.

**کد نمونه:**

```csharp
// src/3.Endpoints/API/Features/Users/UserController.cs
public async Task<IActionResult> CreateByPassword([FromForm] UserCreateCommand command, [FromServices] ITranslator translator)
{
    if (command.Picture is not null)
    {
        var isValid = FileValidationService.ValidateImageFile(command.Picture, out string? errorKey);
        if (!isValid)
            return BadRequest(translator[errorKey!]);
    }
    return await Create<UserCreateCommand, Guid>(command);
}
```

**نکات مهم:**

- FluentValidation validators: ctor `(ITranslator translator)`.
- Controllers: `[FromServices] ITranslator translator` then `translator[errorKey]`.

- Namespace مرتبط: `Zamin.Extensions.Translations.Abstractions`

## Recipe: TranslatorKeys / TranslatorValues {#recipe-translator-keys}

**توضیح:** کلید/مقدارهای ترجمه استفاده‌شده در کنار translator.

**Types in this pattern:** `TranslatorKeys`, `TranslatorValues`.

**کد نمونه:**

مستندات کافی موجود نیست

**نکات مهم:**

- جزئیات بیشتر در api-reference برای `Zamin.Utilities.Resources.Translators`.

- Namespace مرتبط: `Zamin.Utilities.Resources.Translators`

## Recipe: ICacheAdapter {#recipe-cache-adapter}

**توضیح:** مصرف کش توزیع‌شده از طریق `ICacheAdapter` پس از ثبت Redis/SQL.

**Types in this pattern:** `ICacheAdapter`.

**کد نمونه:**

```csharp
// src/1.Core/Application/Services/SampleCachedService.cs
public sealed class SampleCachedService(
    IAttributeDefinitionQueryRepository attributeDefinitionQueryRepository,
    IPolicyQueryRepository policyQueryRepository,
    ICacheAdapter cacheAdapter,
    IOptions<AbacEvaluationCacheOptions> cacheOptions)
    : ISampleAppService
{
    public async Task<IReadOnlyList<AttributeDefinitionCatalogItem>> GetCatalogAsync(
        Guid softwareBusinessId,
        CancellationToken cancellationToken = default)
    {
        var key = CatalogCacheKey(softwareBusinessId);
        var cached = _cacheAdapter.Get<List<AttributeDefinitionCatalogItem>>(key);
        if (cached is not null)
            return cached;

        var loaded = await _attributeDefinitionQueryRepository.GetCatalogBySoftwareBusinessIdAsync(softwareBusinessId);
        var items = loaded.ToList();
        _cacheAdapter.Add(key, items, GetAbsoluteExpiration(), null);
        return items;
    }
}
```

**نکات مهم:**

- جزئیات بیشتر در api-reference برای `Zamin.Extensions.Caching.Abstractions`.

- Namespace مرتبط: `Zamin.Extensions.Caching.Abstractions`

## ترکیب دامنه و persistence (خلاصه مشاهده‌شده)

- Aggregate: `AggregateRoot` / `AggregateRoot<TId>`؛ Entity: `Entity` / `Entity<TId>`.
- VO: `BaseValueObject<T>` + استثناهای Invalid*.
- Command DbContext: `BaseOutboxCommandDbContext`؛ Query: `BaseQueryDbContext`.
- Repository: `BaseCommandRepository` / `BaseQueryRepository` + قراردادهای Core.Contracts.Data.*
- Lifetime: markerهای `ITransientLifetime` و مشابه از طریق `AddZaminApiCore`.

## مدیریت استثناء (مشاهده‌شده در اپلیکیشن)

- دامنه: throw از `InvalidEntityStateException` / `InvalidValueObjectStateException`.
- بعضی نقاط اپلیکیشن catch محلی دارند (مثلاً GetUserSubOrDefault → Guid.Empty).
- Decoratorهای dispatcher: catch `Exception`، لاگ، سپس rethrow.
- زیر `src/` هیچ `catch (DomainStateException)` یافت نشده است.
