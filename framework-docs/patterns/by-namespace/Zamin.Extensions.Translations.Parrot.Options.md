# Zamin.Extensions.Translations.Parrot.Options

**Types in this pattern:** `ParrotTranslatorOptions`.

## Usage

Resolved after pipeline build to initialize DB table:

```csharp
var options = app.Services.GetService<IOptions<ParrotTranslatorOptions>>()?.Value
    ?? throw new NullReferenceException();
ParrotTranslatorInitializer.Initialize(options.ConnectionString, options.SchemaName, options.TableName);
```
