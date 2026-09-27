# Zamin.Utilities.SoftwarePartDetector.DataModel

مرجع API برای namespace `Zamin.Utilities.SoftwarePartDetector.DataModel`.

- **Type count (this file):** 4

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Utilities.SoftwarePartDetector.DataModel.SoftwarePart`

- **Kind:** `class`
- **Source:** `Utilities/SoftwarePartDetector/Zamin.Utilities.SoftwarepartDetector/DataModel/SoftwarePart.cs`

کلاس «SoftwarePart» در namespace Zamin.Utilities.SoftwarePartDetector.DataModel. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/dependency-injection.md#recipe-software-part-detector)

#### Members

##### `Name` (property)

```csharp
public string Name { get; set; }
```

پراپرتی «Name» از نوع `string` در SoftwarePart. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `SoftwarePartType` (property)

```csharp
public SoftwarePartType SoftwarePartType { get; set; }
```

پراپرتی «SoftwarePartType» از نوع `SoftwarePartType` در SoftwarePart. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `Children` (property)

```csharp
public List<SoftwarePart> Children { get; set; }
```

پراپرتی «Children» از نوع `List<SoftwarePart>` در SoftwarePart. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

### `Zamin.Utilities.SoftwarePartDetector.DataModel.SoftwarePartAction`

- **Kind:** `class`
- **Source:** `Utilities/SoftwarePartDetector/Zamin.Utilities.SoftwarepartDetector/DataModel/SoftwarePartController.cs`

کلاس «SoftwarePartAction» در namespace Zamin.Utilities.SoftwarePartDetector.DataModel. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/dependency-injection.md#recipe-software-part-detector)

#### Members

##### `Name` (property)

```csharp
public string Name { get; set; }
```

پراپرتی «Name» از نوع `string` در SoftwarePartAction. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `ApplicationPartType` (property)

```csharp
public SoftwarePartType ApplicationPartType { get; set; }
```

پراپرتی «ApplicationPartType» از نوع `SoftwarePartType` در SoftwarePartAction. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

### `Zamin.Utilities.SoftwarePartDetector.DataModel.SoftwarePartController`

- **Kind:** `class`
- **Source:** `Utilities/SoftwarePartDetector/Zamin.Utilities.SoftwarepartDetector/DataModel/SoftwarePartController.cs`

کلاس «SoftwarePartController» در namespace Zamin.Utilities.SoftwarePartDetector.DataModel. کنترلر endpoint برای دریافت درخواست HTTP و ارجاع به لایه اپلیکیشن.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/dependency-injection.md#recipe-software-part-detector)

#### Members

##### `Module` (property)

```csharp
public string? Module { get; set; }
```

پراپرتی «Module» از نوع `string?` در SoftwarePartController. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `Service` (property)

```csharp
public string? Service { get; set; }
```

پراپرتی «Service» از نوع `string?` در SoftwarePartController. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `Name` (property)

```csharp
public string Name { get; set; }
```

پراپرتی «Name» از نوع `string` در SoftwarePartController. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `ApplicationPartType` (property)

```csharp
public SoftwarePartType ApplicationPartType { get; set; }
```

پراپرتی «ApplicationPartType» از نوع `SoftwarePartType` در SoftwarePartController. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `Actions` (property)

```csharp
public List<SoftwarePartAction> Actions { get; set; }
```

پراپرتی «Actions» از نوع `List<SoftwarePartAction>` در SoftwarePartController. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

### `Zamin.Utilities.SoftwarePartDetector.DataModel.SoftwarePartType`

- **Kind:** `enum`
- **Source:** `Utilities/SoftwarePartDetector/Zamin.Utilities.SoftwarepartDetector/DataModel/SoftwarePartType.cs`

شمارشی (enum) «SoftwarePartType» در namespace Zamin.Utilities.SoftwarePartDetector.DataModel. تعریف enum عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/dependency-injection.md#recipe-software-part-detector)

#### Members

##### `Other` (enum_member)

```csharp
Other = 0
```

مقدار شمارشی «Other» در enum SoftwarePartType.

##### `Sample` (enum_member)

```csharp
Sample = 1
```

مقدار شمارشی «Sample» در enum SoftwarePartType.

##### `Module` (enum_member)

```csharp
Module = 2
```

مقدار شمارشی «Module» در enum SoftwarePartType.

##### `Service` (enum_member)

```csharp
Service = 3
```

مقدار شمارشی «Service» در enum SoftwarePartType.

##### `Controller` (enum_member)

```csharp
Controller = 4
```

مقدار شمارشی «Controller» در enum SoftwarePartType.

##### `Action` (enum_member)

```csharp
Action = 5
```

مقدار شمارشی «Action» در enum SoftwarePartType.
