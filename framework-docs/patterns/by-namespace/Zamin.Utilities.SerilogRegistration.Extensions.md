# Zamin.Utilities.SerilogRegistration.Extensions

**Types in this pattern:** `SerilogExtensions`.

## Snippet

```csharp
// src/Endpoints/API/Program.cs
SerilogExtensions.RunWithSerilogExceptionHandling(() =>
{
    var builder = WebApplication.CreateBuilder(args);
    var app = builder
        .AddConfiguration()
        .AddZaminSerilog(o => { /* Global:* settings */ })
        .ConfigureServices()
        .ConfigurePipeline();
    app.Run();
});
```
