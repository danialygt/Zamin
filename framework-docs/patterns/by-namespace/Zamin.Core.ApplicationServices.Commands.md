# Zamin.Core.ApplicationServices.Commands

**Types documented in usage patterns:** `CommandHandler<TCommand>`, `CommandHandler<TCommand,TData>`, `CommandDispatcherDecorator`, `CommandDispatcher` (via decorator chain / DI).

## Registration / instantiate

- Handlers are **not** new'ed manually; discovered by `AddZaminApiCore("Zamin", "MyApp")`.
- The application registers a custom decorator: `AddTransient<CommandDispatcherDecorator, LoggingCommandDispatcherDecorator>()` before `AddZaminApiCore`.

```csharp
// src/Endpoints/API/DependencyInjection/HostingExtensions.cs
builder.Services.AddTransient<CommandDispatcherDecorator, LoggingCommandDispatcherDecorator>();
builder.Services.AddTransient<QueryDispatcherDecorator, LoggingQueryDispatcherDecorator>();
builder.Services.AddZaminApiCore("Zamin", "MyApp");
```

## Typical call order

1. `BaseController.Create/Edit/Delete` → dispatcher `Send`
2. `LoggingCommandDispatcherDecorator.Send` → inner `_commandDispatcher.Send`
3. `CommandHandler.Handle` → repository / domain → `Ok` / `OkAsync`

## Parameter / composition patterns

- Primary ctor always receives `ZaminServices` first (passed to base `CommandHandler`).
- Additional deps: command repositories, domain validation services, optional infra services.
- Return helpers from base: `Ok()`, `OkAsync(T)`, `Result(...)`.

## Exceptions

Decorator catches `Exception`, logs, rethrows. Domain exceptions typically bubble unless handled inside handler.

## Snippet

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
// src/1.Core/ApplicationService/Common/Decorator/LoggingCommandHandlerDecorator.cs
public class LoggingCommandDispatcherDecorator(
    ILogger<LoggingCommandDispatcherDecorator> logger,
    ZaminServices zaminServices,
    IConfiguration configuration
    ) : CommandDispatcherDecorator
{
    public override int Order => 1;

    public override async Task<CommandResult> Send<TCommand>(TCommand command)
    {
        // ... logging / telemetry ...
        var result = await _commandDispatcher.Send(command);
        return result;
    }
}
```
