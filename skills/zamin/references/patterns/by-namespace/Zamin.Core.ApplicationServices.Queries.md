# Zamin.Core.ApplicationServices.Queries

**Types in this pattern:** `QueryHandler<TQuery,TData>`, `QueryDispatcherDecorator`, `QueryDispatcher` (via DI).

## Registration

`AddTransient<QueryDispatcherDecorator, LoggingQueryDispatcherDecorator>()` then `AddZaminApiCore`.

## Call order

`BaseController.Query<TQuery,TData>` → decorator `Execute` → `QueryHandler.Handle` → query repository → `Result(...)`.

## Snippet

```csharp
// SampleGetPagedFilterQueryHandler.cs
public sealed class SampleGetPagedFilterQueryHandler(
    ZaminServices zaminServices,
    ISampleQueryRepository queryRepository)
    : QueryHandler<SampleGetPagedFilterQuery, PagedData<SampleListItemDto>>(zaminServices)
{
    public override async Task<QueryResult<PagedData<SampleListItemDto>>> Handle(SampleGetPagedFilterQuery query)
    {
        var queryResult = await queryRepository.ExecuteAsync(query);
        return Result(queryResult);
    }
}
```
