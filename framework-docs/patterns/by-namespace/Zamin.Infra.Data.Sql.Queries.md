# Zamin.Infra.Data.Sql.Queries

**Types in this pattern:** `BaseQueryDbContext`, `BaseQueryRepository<TDbContext>`.

## Snippets

```csharp
// src/Infra/Sql.Queries/Common/AppQueryDbContext.cs
public class AppQueryDbContext(DbContextOptions<AppQueryDbContext> options) : BaseQueryDbContext(options)
{
    public DbSet<User> Users { get; set; } = default!;
}
```

```csharp
// src/2.Infra/Data/Sql.Queries/Users/SampleQueryRepository.cs
public class SampleQueryRepository(AppQueryDbContext dbContext, IConfiguration configuration)
    : BaseQueryRepository<AppQueryDbContext>(dbContext), ISampleQueryRepository
{
    public async Task<UserProfileQr?> ExecuteAsync(UserGetProfileDbQuery query)
    {
        return await _dbContext.Users
            .Where(user => user.ExpireDateTime == null || user.ExpireDateTime > DateTime.Now)
            // ...
            .Select(user => new UserProfileQr() { BusinessId = user.BusinessId, /* ... */ })
            .FirstOrDefaultAsync();
    }
}
```
