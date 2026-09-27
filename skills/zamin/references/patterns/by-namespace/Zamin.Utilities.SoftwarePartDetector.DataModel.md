# Zamin.Utilities.SoftwarePartDetector.DataModel

**Inventory note:** Identifier scan matched `SoftwarePart`, `SoftwarePartController`, `SoftwarePartType`.

**Caution:** Application domain/API may also define `SoftwarePart` entities and `SoftwarePartController` endpoints. Do **not** treat every `SoftwarePart` hit as Zamin DataModel usage. Confirmed Zamin detector integration is via `AddSoftwarePartDetector` + `SoftwarePartDetectorService.Run()` (see Services doc). No unambiguous exclusive DataModel call-site was relied upon for recipes.
