# Zamin.Core.RequestResponse.Commands

**Types in this pattern:** `ICommand`, `ICommand<TData>`, `CommandResult`, `CommandResult<TData>`.

## Pattern

```csharp
// src/1.Core/RequestResponse/Samples/Commands/Create/SampleCreateCommand.cs
public sealed record SampleCreateCommand : ICommand<Guid>
{
    public string Name { get; set; } = default!;
    public string? DisplayName { get; set; }
    public string? Description { get; set; }
}
```

Handlers return `CommandResult` / `CommandResult<TData>` via `Ok` / `OkAsync`.

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
