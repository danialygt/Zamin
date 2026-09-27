# Zamin.Infra.Data.Sql.Commands

**Types in this pattern:** `BaseCommandRepository<TEntity,TDbContext,TId>` (and non-generic-id overload).

## Pattern

```csharp
// src/Infra/Sql.Commands/Sliders/SliderCommandRepository.cs
public sealed class SliderCommandRepository(AppCommandDbContext dbContext)
        : BaseCommandRepository<Sample, AppCommandDbContext, long>(dbContext), ISampleCommandRepository
{
    public async Task<List<Sample>> GetAllAsync()
    {
        return await _dbContext.Sliders.ToListAsync();
    }
}
```

Handlers call inherited `InsertAsync` / `CommitAsync` / get methods.
