# Zamin.Core.Contracts.Data.Queries

**Types in this pattern:** `IQueryRepository`.

Application query contracts inherit `IQueryRepository`; implementations use `BaseQueryRepository<AppQueryDbContext>` and expose `ExecuteAsync` overloads per query type.

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
