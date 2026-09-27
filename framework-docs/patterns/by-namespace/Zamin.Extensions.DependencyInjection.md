# Zamin.Extensions.DependencyInjection

**Types / entry points observed:** extension methods on `IServiceCollection` / `WebApplicationBuilder` such as `AddZaminApiCore`, `AddZaminSerilog` (via related packages), `AddNonValidatingValidator`, serializer/mapper/cache helpers imported from this umbrella namespace in hosts.

## Snippet

```csharp
// src/Endpoints/API/DependencyInjection/HostingExtensions.cs
builder.Services.AddTransient<CommandDispatcherDecorator, LoggingCommandDispatcherDecorator>();
builder.Services.AddTransient<QueryDispatcherDecorator, LoggingQueryDispatcherDecorator>();
builder.Services.AddZaminApiCore("Zamin", "MyApp");
```
