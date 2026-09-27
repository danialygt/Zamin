# Zamin.Utilities

**Types in this pattern:** `ZaminServices`.

## Pattern

Injected into every `CommandHandler` / `QueryHandler` and some decorators. Exposes shared services (e.g. `UserInfoService`).

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
