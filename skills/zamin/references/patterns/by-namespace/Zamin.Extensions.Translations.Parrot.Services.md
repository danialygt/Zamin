# Zamin.Extensions.Translations.Parrot.Services

**Types in this pattern:** `ParrotTranslator` (implementation behind `ITranslator` after `AddZaminParrotTranslator`).

Application code typically depends on `ITranslator`, not the concrete type, except through DI registration/options initialization.
