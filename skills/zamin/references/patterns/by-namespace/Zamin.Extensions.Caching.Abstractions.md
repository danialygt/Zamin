# Zamin.Extensions.Caching.Abstractions

**Types in this pattern:** `ICacheAdapter`.

## Registration

Not registered by type name; provided by `AddZaminRedisDistributedCache` / `AddZaminSqlDistributedCache` based on `DistributedCacheActive`.

## Call patterns

`Get<T>`, `Add(key, value, absoluteExpiration, ...)` — e.g. ABAC catalog cache.

```csharp
// src/1.Core/Application/Services/SampleCachedService.cs
public sealed class SampleCachedService(
    IAttributeDefinitionQueryRepository attributeDefinitionQueryRepository,
    IPolicyQueryRepository policyQueryRepository,
    ICacheAdapter cacheAdapter,
    IOptions<AbacEvaluationCacheOptions> cacheOptions)
    : ISampleAppService
{
    public async Task<IReadOnlyList<AttributeDefinitionCatalogItem>> GetCatalogAsync(
        Guid softwareBusinessId,
        CancellationToken cancellationToken = default)
    {
        var key = CatalogCacheKey(softwareBusinessId);
        var cached = _cacheAdapter.Get<List<AttributeDefinitionCatalogItem>>(key);
        if (cached is not null)
            return cached;

        var loaded = await _attributeDefinitionQueryRepository.GetCatalogBySoftwareBusinessIdAsync(softwareBusinessId);
        var items = loaded.ToList();
        _cacheAdapter.Add(key, items, GetAbsoluteExpiration(), null);
        return items;
    }
}
```
