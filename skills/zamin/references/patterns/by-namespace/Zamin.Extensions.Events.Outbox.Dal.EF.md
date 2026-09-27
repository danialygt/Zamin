# Zamin.Extensions.Events.Outbox.Dal.EF

**Types in this pattern:** `BaseOutboxCommandDbContext`.

## Pattern

```csharp
// src/Infra/Sql.Commands/Common/AppCommandDbContext.cs
public class AppCommandDbContext(DbContextOptions<AppCommandDbContext> options)
    : BaseOutboxCommandDbContext(options), IDataProtectionKeyContext
{
    public DbSet<Sample> Samples { get; set; } = default!;
    // ...
}
```

Registered with `AddDbContext<AppCommandDbContext>(...)` in all hosts.
