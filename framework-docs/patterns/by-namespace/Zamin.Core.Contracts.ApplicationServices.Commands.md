# Zamin.Core.Contracts.ApplicationServices.Commands

**Types in this pattern:** `ICommandDispatcher`.

## Usage

Not constructed directly. Resolved inside Zamin `BaseController` / dispatcher pipeline after `AddZaminApiCore`. MyApp never calls `ICommandDispatcher` explicitly in feature code; it goes through `BaseController` helpers.

## Snippet (indirect via controller)

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
