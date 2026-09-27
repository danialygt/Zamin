# Zamin.Utilities.Auth.ApiAuthentication.Options (Part 3/3)

مرجع API برای namespace `Zamin.Utilities.Auth.ApiAuthentication.Options`.

- **Type count (this file):** 2
- **Parts:** [Part 1](./Zamin.Utilities.Auth.ApiAuthentication.Options.Part1.md) · [Part 2](./Zamin.Utilities.Auth.ApiAuthentication.Options.Part2.md) · **Part 3**

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Utilities.Auth.ApiAuthentication.Options.UserClaimAddonOption`

- **Kind:** `class`
- **Source:** `Utilities/Auth/ApiAuthentication/Zamin.Utilities.Auth.ApiAuthentication/Options/UserClaimAddonOption.cs`

کلاس «UserClaimAddonOption» در namespace Zamin.Utilities.Auth.ApiAuthentication.Options. مدل تنظیمات قابل بایند شدن از configuration.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/dependency-injection.md#recipe-api-authentication)

#### Members

##### `Type` (property)

```csharp
public string Type { get; set; }
```

پراپرتی «Type» از نوع `string` در UserClaimAddonOption. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `Value` (property)

```csharp
public string Value { get; set; }
```

پراپرتی «Value» از نوع `string` در UserClaimAddonOption. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `ValueType` (property)

```csharp
public string? ValueType { get; set; }
```

پراپرتی «ValueType» از نوع `string?` در UserClaimAddonOption. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `Issuer` (property)

```csharp
public string? Issuer { get; set; }
```

پراپرتی «Issuer» از نوع `string?` در UserClaimAddonOption. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `OriginalIssuer` (property)

```csharp
public string? OriginalIssuer { get; set; }
```

پراپرتی «OriginalIssuer» از نوع `string?` در UserClaimAddonOption. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

### `Zamin.Utilities.Auth.ApiAuthentication.Options.UserClaimRuleOption`

- **Kind:** `class`
- **Source:** `Utilities/Auth/ApiAuthentication/Zamin.Utilities.Auth.ApiAuthentication/Options/UserClaimRuleOption.cs`

کلاس «UserClaimRuleOption» در namespace Zamin.Utilities.Auth.ApiAuthentication.Options. مدل تنظیمات قابل بایند شدن از configuration.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/dependency-injection.md#recipe-api-authentication)

#### Members

##### `Source` (property)

```csharp
public string Source { get; set; }
```

پراپرتی «Source» از نوع `string` در UserClaimRuleOption. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `Destination` (property)

```csharp
public string Destination { get; set; }
```

پراپرتی «Destination» از نوع `string` در UserClaimRuleOption. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `RemoveSource` (property)

```csharp
public bool RemoveSource { get; set; }
```

پراپرتی «RemoveSource» از نوع `bool` در UserClaimRuleOption. مورد یا وضعیت را حذف/پاک می‌کند. قابل خواندن و نوشتن است.
