# Zamin.Infra.Data.Sql.Commands.Interceptors

**Types in this pattern:** `SetPersianYeKeInterceptor`, `AddAuditDataInterceptor`.

## Registration

Instantiated in `AddDbContext` `AddInterceptors(...)` for command DbContext (API / Worker hosts).

```csharp
.AddInterceptors(
    new SetPersianYeKeInterceptor(),
    new AddAuditDataInterceptor(),
    sp.GetRequiredService<ClientCacheInvalidationInterceptor>());
```
