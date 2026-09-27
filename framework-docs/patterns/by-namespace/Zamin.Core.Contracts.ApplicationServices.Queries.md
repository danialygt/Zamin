# Zamin.Core.Contracts.ApplicationServices.Queries

**Types in this pattern:** `IQueryDispatcher`.

Same pattern as commands: used inside Zamin web stack / dispatcher, not new'ed in application code features. Controllers call `Query<...>` on `BaseController`.

## Snippet

```csharp
// src/3.Endpoints/API/Features/Users/UserController.cs
public async Task<IActionResult> GetPagedFilter([FromQuery] SampleGetPagedFilterQuery query)
    => await Query<SampleGetPagedFilterQuery, PagedData<SampleListItemDto>>(query);
```
