# Zamin.Extensions.Caching.Distributed.Sql.Options

**Types in this pattern:** `DistributedSqlCacheOptions`.

## Registration pattern

```csharp
else if (builder.Configuration["DistributedCacheActive"] == nameof(DistributedSqlCacheOptions))
    builder.Services.AddZaminSqlDistributedCache(builder.Configuration, nameof(DistributedSqlCacheOptions));
```
