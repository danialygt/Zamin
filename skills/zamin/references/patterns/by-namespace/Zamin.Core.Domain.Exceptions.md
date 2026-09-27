# Zamin.Core.Domain.Exceptions

**Types in this pattern:** `InvalidEntityStateException`, `InvalidValueObjectStateException`.

## Throw sites

- Aggregates / entities for invariant violations.
- Value objects on invalid construction.

## Catch sites (observed)

```csharp
// src/1.Core/ApplicationService/Common/Extensions/UserInfoServiceExtentions.cs
public static Guid GetUserSubOrDefault(this IUserInfoService userInfoService)
{
    try
    {
        return userInfoService.GetUserSub();
    }
    catch (InvalidEntityStateException)
    {
        return Guid.Empty;
    }
}
```

```csharp
// src/1.Core/Application/Services/SampleExpressionAnalyzer.cs
try
{
    using var document = ParseExpression(expression);
    return CollectConditions(document.RootElement).Any(...);
}
catch (InvalidValueObjectStateException)
{
    return ExpressionContainsAttributeFallback(expression, attributeName);
}
```

`DomainStateException` is **not** referenced under `src/`.
