# Zamin.Utilities.Auth.ApiAuthentication.Options (Part 2/3)

مرجع API برای namespace `Zamin.Utilities.Auth.ApiAuthentication.Options`.

- **Type count (this file):** 4
- **Parts:** [Part 1](./Zamin.Utilities.Auth.ApiAuthentication.Options.Part1.md) · **Part 2** · [Part 3](./Zamin.Utilities.Auth.ApiAuthentication.Options.Part3.md)

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Utilities.Auth.ApiAuthentication.Options.ProviderOption`

- **Kind:** `class`
- **Source:** `Utilities/Auth/ApiAuthentication/Zamin.Utilities.Auth.ApiAuthentication/Options/ProviderOption.cs`

کلاس «ProviderOption» در namespace Zamin.Utilities.Auth.ApiAuthentication.Options. مدل تنظیمات قابل بایند شدن از configuration.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/dependency-injection.md#recipe-api-authentication)

#### Members

##### `Enabled` (property)

```csharp
public bool Enabled { get; set; }
```

پراپرتی «Enabled» از نوع `bool` در ProviderOption. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `IgnoreSSL` (property)

```csharp
public bool IgnoreSSL { get; set; }
```

پراپرتی «IgnoreSSL» از نوع `bool` در ProviderOption. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `Scheme` (property)

```csharp
public string Scheme { get; set; }
```

پراپرتی «Scheme» از نوع `string` در ProviderOption. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `Authority` (property)

```csharp
public string Authority { get; set; }
```

پراپرتی «Authority» از نوع `string` در ProviderOption. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `HttpClientFactoryName` (property)

```csharp
public string? HttpClientFactoryName { get; set; }
```

پراپرتی «HttpClientFactoryName» از نوع `string?` در ProviderOption. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `TokenTypeSupport` (property)

```csharp
public TokenType TokenTypeSupport { get; set; }
```

پراپرتی «TokenTypeSupport» از نوع `TokenType` در ProviderOption. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `JwtTokenConfig` (property)

```csharp
public JwtTokenConfigOption JwtTokenConfig { get; set; }
```

پراپرتی «JwtTokenConfig» از نوع `JwtTokenConfigOption` در ProviderOption. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `RefrenceTokenConfig` (property)

```csharp
public RefrenceTokenConfigOption RefrenceTokenConfig { get; set; }
```

پراپرتی «RefrenceTokenConfig» از نوع `RefrenceTokenConfigOption` در ProviderOption. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `UserIdentifierClaimType` (property)

```csharp
public string UserIdentifierClaimType { get; set; }
```

پراپرتی «UserIdentifierClaimType» از نوع `string` در ProviderOption. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `RegisterUserInfoClaims` (property)

```csharp
public RegisterUserInfoClaimsOption RegisterUserInfoClaims { get; set; }
```

پراپرتی «RegisterUserInfoClaims» از نوع `RegisterUserInfoClaimsOption` در ProviderOption. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `UserClaimRules` (property)

```csharp
public List<UserClaimRuleOption> UserClaimRules { get; set; }
```

پراپرتی «UserClaimRules» از نوع `List<UserClaimRuleOption>` در ProviderOption. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `UserClaimAddons` (property)

```csharp
public List<UserClaimAddonOption> UserClaimAddons { get; set; }
```

پراپرتی «UserClaimAddons» از نوع `List<UserClaimAddonOption>` در ProviderOption. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `EndpointsPath` (property)

```csharp
public EndpointsPathOption? EndpointsPath { get; set; }
```

پراپرتی «EndpointsPath» از نوع `EndpointsPathOption?` در ProviderOption. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `Priority` (property)

```csharp
public int Priority { get; set; }
```

پراپرتی «Priority» از نوع `int` در ProviderOption. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

### `Zamin.Utilities.Auth.ApiAuthentication.Options.RefrenceTokenConfigOption`

- **Kind:** `class`
- **Source:** `Utilities/Auth/ApiAuthentication/Zamin.Utilities.Auth.ApiAuthentication/Options/RefrenceTokenConfigOption.cs`

کلاس «RefrenceTokenConfigOption» در namespace Zamin.Utilities.Auth.ApiAuthentication.Options. مدل تنظیمات قابل بایند شدن از configuration.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/dependency-injection.md#recipe-api-authentication)

#### Members

##### `ClientId` (property)

```csharp
public string ClientId { get; set; }
```

پراپرتی «ClientId» از نوع `string` در RefrenceTokenConfigOption. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `ClientSecret` (property)

```csharp
public string ClientSecret { get; set; }
```

پراپرتی «ClientSecret» از نوع `string` در RefrenceTokenConfigOption. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

### `Zamin.Utilities.Auth.ApiAuthentication.Options.RegisterUserInfoClaimsOption`

- **Kind:** `class`
- **Source:** `Utilities/Auth/ApiAuthentication/Zamin.Utilities.Auth.ApiAuthentication/Options/RegisterUserInfoClaimsOption.cs`

کلاس «RegisterUserInfoClaimsOption» در namespace Zamin.Utilities.Auth.ApiAuthentication.Options. مدل تنظیمات قابل بایند شدن از configuration.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/dependency-injection.md#recipe-api-authentication)

#### Members

##### `Enabled` (property)

```csharp
public bool Enabled { get; set; }
```

پراپرتی «Enabled» از نوع `bool` در RegisterUserInfoClaimsOption. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `CachingData` (property)

```csharp
public bool CachingData { get; set; }
```

پراپرتی «CachingData» از نوع `bool` در RegisterUserInfoClaimsOption. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `CacheKeyPrefix` (property)

```csharp
public string CacheKeyPrefix { get; set; }
```

پراپرتی «CacheKeyPrefix» از نوع `string` در RegisterUserInfoClaimsOption. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `CacheKeyFormat` (property)

```csharp
public CacheKeyFormat CacheKeyFormat { get; set; }
```

پراپرتی «CacheKeyFormat» از نوع `CacheKeyFormat` در RegisterUserInfoClaimsOption. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `CacheExpirationType` (property)

```csharp
public CacheExpirationType CacheExpirationType { get; set; }
```

پراپرتی «CacheExpirationType» از نوع `CacheExpirationType` در RegisterUserInfoClaimsOption. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `CacheExpirationInSeconds` (property)

```csharp
public int CacheExpirationInSeconds { get; set; }
```

پراپرتی «CacheExpirationInSeconds» از نوع `int` در RegisterUserInfoClaimsOption. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

### `Zamin.Utilities.Auth.ApiAuthentication.Options.TokenType`

- **Kind:** `enum`
- **Source:** `Utilities/Auth/ApiAuthentication/Zamin.Utilities.Auth.ApiAuthentication/Options/TokenType.cs`

شمارشی (enum) «TokenType» در namespace Zamin.Utilities.Auth.ApiAuthentication.Options. مدل تنظیمات قابل بایند شدن از configuration.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/dependency-injection.md#recipe-api-authentication)

#### Members

##### `Jwt` (enum_member)

```csharp
Jwt = 1
```

مقدار شمارشی «Jwt» در enum TokenType.

##### `Reference` (enum_member)

```csharp
Reference = 2
```

مقدار شمارشی «Reference» در enum TokenType.
