# Zamin.Core.Domain.Entities

**Types in this pattern:** `AggregateRoot`, `AggregateRoot<TId>`, `Entity`, `Entity<TId>`.

## Pattern

- Aggregates: `public sealed class Sample : AggregateRoot<int>`
- Child/query-side entities often `Entity<long>`
- Private parameterless ctor for ORM; public factory `Create`.

## Exceptions / invariants

Methods like `EnsureModifiable` throw `InvalidEntityStateException` (see Exceptions namespace doc).

## Snippet

```csharp
// src/Domain/Samples/Entities/Sample.cs
public sealed class Sample : AggregateRoot<int>
{
    private Sample() { }

    private Sample(SampleCreateParameter parameter) : this()
    {
        Name = parameter.Name;
        DisplayName = parameter.DisplayName;
        Description = parameter.Description;
        Protected = false;
        Primary = parameter.Primary;
    }

    public static Sample Create(SampleCreateParameter parameter) => new(parameter);

    public void ChangeProtectedStatus(bool status)
    {
        if (Primary.Equals(true))
        {
            throw new InvalidEntityStateException("Cannot modify primary sample", Name.Value);
        }
        Protected = status;
    }
}
```
