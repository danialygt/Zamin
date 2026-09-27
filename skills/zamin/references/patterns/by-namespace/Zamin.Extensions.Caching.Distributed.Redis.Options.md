# Zamin.Extensions.Caching.Distributed.Redis.Options

**Types in this pattern:** `DistributedRedisCacheOptions`.

## Registration pattern

```csharp
if (builder.Configuration["DistributedCacheActive"] == nameof(DistributedRedisCacheOptions))
    builder.Services.AddZaminRedisDistributedCache(builder.Configuration, nameof(DistributedRedisCacheOptions));
```

Appears in API and Worker hosts `HostingExtensions`.
