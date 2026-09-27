# Zamin.Utilities.Auth.ApiAuthentication.Options (Part 1/3)

مرجع API برای namespace `Zamin.Utilities.Auth.ApiAuthentication.Options`.

- **Type count (this file):** 5
- **Parts:** **Part 1** · [Part 2](./Zamin.Utilities.Auth.ApiAuthentication.Options.Part2.md) · [Part 3](./Zamin.Utilities.Auth.ApiAuthentication.Options.Part3.md)

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Utilities.Auth.ApiAuthentication.Options.ApiAuthenticationOption`

- **Kind:** `class`
- **Source:** `Utilities/Auth/ApiAuthentication/Zamin.Utilities.Auth.ApiAuthentication/Options/ApiAuthenticationOption.cs`

کلاس «ApiAuthenticationOption» در namespace Zamin.Utilities.Auth.ApiAuthentication.Options. مدل تنظیمات قابل بایند شدن از configuration.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/dependency-injection.md#recipe-api-authentication)

#### Members

##### `Enabled` (property)

```csharp
public bool Enabled { get; set; }
```

پراپرتی «Enabled» از نوع `bool` در ApiAuthenticationOption. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `Providers` (property)

```csharp
public List<ProviderOption> Providers { get; set; }
```

پراپرتی «Providers» از نوع `List<ProviderOption>` در ApiAuthenticationOption. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `EnabledProviders` (property)

```csharp
public IReadOnlyList<ProviderOption> EnabledProviders => ...
```

پراپرتی «EnabledProviders» از نوع `IReadOnlyList<ProviderOption>` در ApiAuthenticationOption. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. منطق دسترسی از روی بدنه accessor قابل مشاهده است.

##### `DefualtProvider` (property)

```csharp
public ProviderOption? DefualtProvider => ...
```

پراپرتی «DefualtProvider» از نوع `ProviderOption?` در ApiAuthenticationOption. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. منطق دسترسی از روی بدنه accessor قابل مشاهده است.

##### `Active` (property)

```csharp
public bool Active => ...
```

پراپرتی «Active» از نوع `bool` در ApiAuthenticationOption. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. منطق دسترسی از روی بدنه accessor قابل مشاهده است.

### `Zamin.Utilities.Auth.ApiAuthentication.Options.CacheExpirationType`

- **Kind:** `enum`
- **Source:** `Utilities/Auth/ApiAuthentication/Zamin.Utilities.Auth.ApiAuthentication/Options/CacheExpirationType.cs`

شمارشی (enum) «CacheExpirationType» در namespace Zamin.Utilities.Auth.ApiAuthentication.Options. مدل تنظیمات قابل بایند شدن از configuration.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/dependency-injection.md#recipe-api-authentication)

#### Members

##### `Absolute` (enum_member)

```csharp
Absolute = 1
```

مقدار شمارشی «Absolute» در enum CacheExpirationType.

##### `Sliding` (enum_member)

```csharp
Sliding = 2
```

مقدار شمارشی «Sliding» در enum CacheExpirationType.

### `Zamin.Utilities.Auth.ApiAuthentication.Options.CacheKeyFormat`

- **Kind:** `enum`
- **Source:** `Utilities/Auth/ApiAuthentication/Zamin.Utilities.Auth.ApiAuthentication/Options/CacheKeyFormat.cs`

شمارشی (enum) «CacheKeyFormat» در namespace Zamin.Utilities.Auth.ApiAuthentication.Options. مدل تنظیمات قابل بایند شدن از configuration.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/dependency-injection.md#recipe-api-authentication)

#### Members

##### `Base64` (enum_member)

```csharp
Base64 = 1
```

مقدار شمارشی «Base64» در enum CacheKeyFormat.

##### `PlainText` (enum_member)

```csharp
PlainText = 2
```

مقدار شمارشی «PlainText» در enum CacheKeyFormat.

### `Zamin.Utilities.Auth.ApiAuthentication.Options.EndpointsPathOption`

- **Kind:** `class`
- **Source:** `Utilities/Auth/ApiAuthentication/Zamin.Utilities.Auth.ApiAuthentication/Options/EndpointsPathOption.cs`

کلاس «EndpointsPathOption» در namespace Zamin.Utilities.Auth.ApiAuthentication.Options. مدل تنظیمات قابل بایند شدن از configuration.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/dependency-injection.md#recipe-api-authentication)

#### Members

##### `AuthorizeEndpoint` (property)

```csharp
public string AuthorizeEndpoint { get; set; }
```

پراپرتی «AuthorizeEndpoint» از نوع `string` در EndpointsPathOption. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `TokenEndpoint` (property)

```csharp
public string TokenEndpoint { get; set; }
```

پراپرتی «TokenEndpoint» از نوع `string` در EndpointsPathOption. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `UserInfoEndpoint` (property)

```csharp
public string UserInfoEndpoint { get; set; }
```

پراپرتی «UserInfoEndpoint» از نوع `string` در EndpointsPathOption. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `IntrospectionEndpoint` (property)

```csharp
public string IntrospectionEndpoint { get; set; }
```

پراپرتی «IntrospectionEndpoint» از نوع `string` در EndpointsPathOption. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

### `Zamin.Utilities.Auth.ApiAuthentication.Options.JwtTokenConfigOption`

- **Kind:** `class`
- **Source:** `Utilities/Auth/ApiAuthentication/Zamin.Utilities.Auth.ApiAuthentication/Options/JwtTokenConfigOption.cs`

کلاس «JwtTokenConfigOption» در namespace Zamin.Utilities.Auth.ApiAuthentication.Options. مدل تنظیمات قابل بایند شدن از configuration.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/dependency-injection.md#recipe-api-authentication)

#### Members

##### `Audience` (property)

```csharp
public string? Audience { get; set; }
```

پراپرتی «Audience» از نوع `string?` در JwtTokenConfigOption. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `RequireHttpsMetadata` (property)

```csharp
public bool RequireHttpsMetadata { get; set; }
```

پراپرتی «RequireHttpsMetadata» از نوع `bool` در JwtTokenConfigOption. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `ValidateAudience` (property)

```csharp
public bool ValidateAudience { get; set; }
```

پراپرتی «ValidateAudience» از نوع `bool` در JwtTokenConfigOption. ورودی را اعتبارسنجی می‌کند. قابل خواندن و نوشتن است.

##### `ValidateIssuer` (property)

```csharp
public bool ValidateIssuer { get; set; }
```

پراپرتی «ValidateIssuer» از نوع `bool` در JwtTokenConfigOption. ورودی را اعتبارسنجی می‌کند. قابل خواندن و نوشتن است.

##### `ValidateIssuerSigningKey` (property)

```csharp
public bool ValidateIssuerSigningKey { get; set; }
```

پراپرتی «ValidateIssuerSigningKey» از نوع `bool` در JwtTokenConfigOption. ورودی را اعتبارسنجی می‌کند. قابل خواندن و نوشتن است.
