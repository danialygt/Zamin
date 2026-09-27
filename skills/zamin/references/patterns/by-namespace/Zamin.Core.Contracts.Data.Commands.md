# Zamin.Core.Contracts.Data.Commands

**Types in this pattern:** `ICommandRepository<TEntity,TId>`.

## Pattern

Application contracts inherit the Zamin interface; infra implements via `BaseCommandRepository`.

```csharp
// example contract pattern (Users)
public interface IUserCommandRepository : ICommandRepository<User, long>
```

## Call order in handlers

`GetAsync` / custom get → domain mutate → `InsertAsync` (create) → `CommitAsync`.

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
