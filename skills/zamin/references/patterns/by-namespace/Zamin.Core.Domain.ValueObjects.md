# Zamin.Core.Domain.ValueObjects

**Types in this pattern:** `BaseValueObject<TValueObject>`, `BusinessId`.

## Pattern

Custom VOs inherit `BaseValueObject<T>`, implement `GetEqualityComponents`, factory `FromString` / explicit operators. `BusinessId` used as aggregate identity (e.g. `software.BusinessId.Value`, `BusinessId.FromGuid(...)` in mappers).

## Snippet

```csharp
// src/1.Core/Domain/Common/ValueObjects/Code.cs
public sealed class Code : BaseValueObject<Code>
{
    private Code(string value)
    {
        Validate(value);
        Value = value.Trim();
    }

    public static Code FromString(string value) => new(value);

    public static void Validate(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new InvalidValueObjectStateException("Value is not valid", CODE);
        // ...
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
```
