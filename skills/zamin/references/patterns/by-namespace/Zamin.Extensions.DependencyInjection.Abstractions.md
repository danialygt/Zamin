# Zamin.Extensions.DependencyInjection.Abstractions

**Types in this pattern:** `ITransientLifetime`, `IScopeLifetime`, `ISingletoneLifetime`.

## Pattern

Application contracts mark lifetime for `AddZaminApiCore` scanning:

```csharp
// src/Contracts/Services/ISampleAppService.cs
public interface ISampleAppService : ITransientLifetime
```

Many domain validation service interfaces also `: ITransientLifetime`.
