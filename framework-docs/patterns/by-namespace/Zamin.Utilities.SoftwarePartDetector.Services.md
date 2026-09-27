# Zamin.Utilities.SoftwarePartDetector.Services

**Types in this pattern:** `SoftwarePartDetectorService`.

## Registration / run

```csharp
builder.Services.AddSoftwarePartDetector(builder.Configuration, "SoftwarePart");
// pipeline end:
app.Services.GetService<SoftwarePartDetectorService>()?.Run();
```

(API `HostingExtensions`.)
