# Zamin.Core.Domain.Toolkits.ValueObjects

**Types observed (identifier hits):** `Description`, `NationalCode`, `Priority`, `Title`.

## Notes

Applications may also define its own VOs (e.g. `MyApp.Domain.ValueObjects.Priority`, claim/user national-code fields as strings). Toolkit types appear in domain/mapping code where Zamin toolkit VOs are imported. Prefer confirming each call-site's `using` when documenting a specific field.

## Related real VO pattern in application code

See `Zamin.Core.Domain.ValueObjects` (`Code : BaseValueObject<Code>`) for the dominant application style.
