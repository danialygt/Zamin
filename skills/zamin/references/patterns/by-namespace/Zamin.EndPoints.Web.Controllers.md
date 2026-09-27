# Zamin.EndPoints.Web.Controllers

**Types in this pattern:** `BaseController`.

## Pattern

Almost all API controllers inherit `BaseController` and use helpers:
- `Create` / `Create<TCommand,TData>`
- `Edit`
- `Delete`
- `Query<TQuery,TData>`

No direct `new BaseController`.

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
