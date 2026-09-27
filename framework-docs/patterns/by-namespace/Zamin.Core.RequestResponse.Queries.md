# Zamin.Core.RequestResponse.Queries

**Types in this pattern:** `IQuery<TData>`, `QueryResult<TData>`, `PagedData<T>`, `PageQuery<TData>`.

## Pattern

Query records implement `IQuery<T>`. Handlers return `QueryResult<T>` via `Result(...)`. Paging uses `PagedData<T>` extensively in user/list endpoints.

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
