# Zamin.Extensions.Translations.Abstractions

**Types in this pattern:** `ITranslator`.

## Registration

`AddZaminParrotTranslator(configuration, "ParrotTranslator")`.

## Usage patterns

- FluentValidation validators: ctor `(ITranslator translator)`.
- Controllers: `[FromServices] ITranslator translator` then `translator[errorKey]`.

```csharp
// src/3.Endpoints/API/Features/Users/UserController.cs
public async Task<IActionResult> CreateByPassword([FromForm] UserCreateCommand command, [FromServices] ITranslator translator)
{
    if (command.Picture is not null)
    {
        var isValid = FileValidationService.ValidateImageFile(command.Picture, out string? errorKey);
        if (!isValid)
            return BadRequest(translator[errorKey!]);
    }
    return await Create<UserCreateCommand, Guid>(command);
}
```
