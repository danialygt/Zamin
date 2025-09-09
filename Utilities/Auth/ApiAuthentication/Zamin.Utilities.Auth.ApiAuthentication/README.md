# Zamin.Utilities.Auth.ApiAuthentication

## 📋 معرفی پکیج

این پکیج یک سیستم احراز هویت پیشرفته و انعطاف‌پذیر برای پروژه‌های ASP.NET Core ارائه می‌دهد که از چندین Provider احراز هویت پشتیبانی می‌کند. این پکیج امکان استفاده از JWT Token و Reference Token را فراهم می‌کند و قابلیت‌های پیشرفته‌ای مانند Claim Mapping، User Info Registration و Caching را ارائه می‌دهد.

**زمان استفاده:** زمانی که نیاز به سیستم احراز هویت پیچیده با پشتیبانی از چندین Provider، Claim Mapping و مدیریت پیشرفته کاربران دارید.

**تکنولوژی:** این پکیج برای پروژه‌های ASP.NET Core 9.0 و بالاتر طراحی شده است.

## 📦 نسخه

**نسخه فعلی:** 9.0.0

## 🚀 نصب و راه‌اندازی

### نصب پکیج

با استفاده از NuGet Package Manager:

```bash
dotnet add package Zamin.Utilities.Auth.ApiAuthentication
```

یا از طریق Package Manager Console در Visual Studio:

```powershell
Install-Package Zamin.Utilities.Auth.ApiAuthentication
```

### رجیستر کردن در پروژه

در فایل `Program.cs` یا `Startup.cs` خود، سرویس را به DI Container اضافه کنید:

```csharp
using Zamin.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// رجیستر کردن سرویس احراز هویت
builder.Services.AddZaminApiAuthentication(builder.Configuration);

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.Run();
```

### تنظیمات (Configuration)

#### تنظیمات در `appsettings.json`

```json
{
  "ApiAuthenticationOption": {
    "Enabled": true,
    "Providers": [
      {
        "Enabled": true,
        "Scheme": "Bearer",
        "Authority": "https://auth.example.com",
        "TokenTypeSupport": "Jwt",
        "Priority": 1,
        "IgnoreSSL": false,
        "UserIdentifierClaimType": "sub",
        "JwtTokenConfig": {
          "Audience": "api.example.com",
          "RequireHttpsMetadata": true,
          "ValidateAudience": true,
          "ValidateIssuer": true,
          "ValidateIssuerSigningKey": true
        },
        "RegisterUserInfoClaims": {
          "Enabled": true,
          "CachingData": true,
          "CacheKeyPrefix": "UserInfoClaims_",
          "CacheKeyFormat": "Base64",
          "CacheExpirationType": "Absolute",
          "CacheExpirationInSeconds": 300
        },
        "UserClaimRules": [
          {
            "Source": "sub",
            "Destination": "user_id",
            "RemoveSource": false
          }
        ],
        "UserClaimAddons": [
          {
            "Type": "role",
            "Value": "user",
            "ValueType": "string"
          }
        ]
      }
    ]
  }
}
```

#### تنظیمات دستی (بدون appsettings.json)

```csharp
builder.Services.AddZaminApiAuthentication(options =>
{
    options.Enabled = true;
    options.Providers = new List<ProviderOption>
    {
        new ProviderOption
        {
            Enabled = true,
            Scheme = "Bearer",
            Authority = "https://auth.example.com",
            TokenTypeSupport = TokenType.Jwt,
            Priority = 1,
            UserIdentifierClaimType = "sub",
            JwtTokenConfig = new JwtTokenConfigOption
            {
                Audience = "api.example.com",
                RequireHttpsMetadata = true,
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateIssuerSigningKey = true
            },
            RegisterUserInfoClaims = new RegisterUserInfoClaimsOption
            {
                Enabled = true,
                CachingData = true,
                CacheKeyPrefix = "UserInfoClaims_",
                CacheKeyFormat = CacheKeyFormat.Base64,
                CacheExpirationType = CacheExpirationType.Absolute,
                CacheExpirationInSeconds = 300
            }
        }
    };
});
```

## ⚙️ گزینه‌های کانفیگ

### ApiAuthenticationOption

#### 1. `Enabled`
- **توضیح:** فعال یا غیرفعال کردن سیستم احراز هویت
- **مقدار پیش‌فرض:** `true`
- **زمان تغییر:** برای غیرفعال کردن موقت سیستم

#### 2. `Providers`
- **توضیح:** لیست Provider های احراز هویت
- **مقدار پیش‌فرض:** `[]`
- **زمان تغییر:** برای اضافه کردن Provider های جدید

### ProviderOption

#### 1. `Enabled`
- **توضیح:** فعال یا غیرفعال کردن Provider
- **مقدار پیش‌فرض:** `true`
- **زمان تغییر:** برای غیرفعال کردن Provider خاص

#### 2. `Scheme`
- **توضیح:** نام Scheme احراز هویت
- **مقدار پیش‌فرض:** `string.Empty`
- **زمان تغییر:** همیشه باید تنظیم شود
- **مثال:** `"Bearer"`, `"JWT"`, `"OAuth"`

#### 3. `Authority`
- **توضیح:** آدرس سرور احراز هویت
- **مقدار پیش‌فرض:** `string.Empty`
- **زمان تغییر:** همیشه باید تنظیم شود
- **مثال:** `"https://auth.example.com"`

#### 4. `TokenTypeSupport`
- **توضیح:** نوع توکن پشتیبانی شده
- **مقدار پیش‌فرض:** `TokenType.Jwt`
- **زمان تغییر:** بر اساس نوع توکن استفاده شده
- **مقادیر:** `Jwt`, `Reference`

#### 5. `Priority`
- **توضیح:** اولویت Provider (کمتر = اولویت بالاتر)
- **مقدار پیش‌فرض:** `1`
- **زمان تغییر:** برای تنظیم اولویت Provider ها

#### 6. `IgnoreSSL`
- **توضیح:** نادیده گرفتن خطاهای SSL
- **مقدار پیش‌فرض:** `false`
- **زمان تغییر:** در محیط Development یا با گواهی‌های خودامضا

#### 7. `UserIdentifierClaimType`
- **توضیح:** نوع Claim شناسایی کاربر
- **مقدار پیش‌فرض:** `ClaimTypes.NameIdentifier`
- **زمان تغییر:** زمانی که نوع Claim متفاوت است

### JwtTokenConfigOption

#### 1. `Audience`
- **توضیح:** Audience مورد انتظار در توکن
- **مقدار پیش‌فرض:** `null`
- **زمان تغییر:** زمانی که Audience مشخص است

#### 2. `RequireHttpsMetadata`
- **توضیح:** الزام استفاده از HTTPS برای Metadata
- **مقدار پیش‌فرض:** `false`
- **زمان تغییر:** در محیط Production باید `true` باشد

#### 3. `ValidateAudience`
- **توضیح:** اعتبارسنجی Audience
- **مقدار پیش‌فرض:** `false`
- **زمان تغییر:** زمانی که نیاز به اعتبارسنجی Audience دارید

#### 4. `ValidateIssuer`
- **توضیح:** اعتبارسنجی Issuer
- **مقدار پیش‌فرض:** `false`
- **زمان تغییر:** زمانی که نیاز به اعتبارسنجی Issuer دارید

#### 5. `ValidateIssuerSigningKey`
- **توضیح:** اعتبارسنجی کلید امضا
- **مقدار پیش‌فرض:** `false`
- **زمان تغییر:** زمانی که نیاز به اعتبارسنجی کلید دارید

### RefrenceTokenConfigOption

#### 1. `ClientId`
- **توضیح:** شناسه کلاینت برای Reference Token
- **مقدار پیش‌فرض:** `string.Empty`
- **زمان تغییر:** همیشه باید تنظیم شود

#### 2. `ClientSecret`
- **توضیح:** رمز کلاینت برای Reference Token
- **مقدار پیش‌فرض:** `string.Empty`
- **زمان تغییر:** همیشه باید تنظیم شود

### RegisterUserInfoClaimsOption

#### 1. `Enabled`
- **توضیح:** فعال یا غیرفعال کردن ثبت اطلاعات کاربر
- **مقدار پیش‌فرض:** `true`
- **زمان تغییر:** زمانی که نیازی به اطلاعات کاربر ندارید

#### 2. `CachingData`
- **توضیح:** فعال یا غیرفعال کردن کش اطلاعات کاربر
- **مقدار پیش‌فرض:** `false`
- **زمان تغییر:** برای بهبود عملکرد

#### 3. `CacheKeyPrefix`
- **توضیح:** پیشوند کلید کش
- **مقدار پیش‌فرض:** `"UserInfoClaims_"`
- **زمان تغییر:** برای جلوگیری از تداخل کلیدها

#### 4. `CacheKeyFormat`
- **توضیح:** فرمت کلید کش
- **مقدار پیش‌فرض:** `CacheKeyFormat.Base64`
- **زمان تغییر:** بر اساس نیاز

#### 5. `CacheExpirationType`
- **توضیح:** نوع انقضای کش
- **مقدار پیش‌فرض:** `CacheExpirationType.Absolute`
- **زمان تغییر:** بر اساس نیاز

#### 6. `CacheExpirationInSeconds`
- **توضیح:** مدت انقضای کش (به ثانیه)
- **مقدار پیش‌فرض:** `60`
- **زمان تغییر:** بر اساس نیاز

## 🔧 ویژگی‌های اصلی

### 1. پشتیبانی از چندین Provider

**توضیح:** امکان استفاده از چندین Provider احراز هویت به صورت همزمان با اولویت‌بندی.

```csharp
var providers = new List<ProviderOption>
{
    new ProviderOption
    {
        Scheme = "JWT",
        Authority = "https://jwt-auth.example.com",
        TokenTypeSupport = TokenType.Jwt,
        Priority = 1
    },
    new ProviderOption
    {
        Scheme = "OAuth",
        Authority = "https://oauth.example.com",
        TokenTypeSupport = TokenType.Reference,
        Priority = 2
    }
};
```

### 2. Claim Mapping

**توضیح:** امکان تبدیل و نگاشت Claim های مختلف بین Provider ها.

```csharp
UserClaimRules = new List<UserClaimRuleOption>
{
    new UserClaimRuleOption
    {
        Source = "sub",
        Destination = "user_id",
        RemoveSource = false
    },
    new UserClaimRuleOption
    {
        Source = "email",
        Destination = "user_email",
        RemoveSource = true
    }
}
```

### 3. Claim Addons

**توضیح:** امکان اضافه کردن Claim های سفارشی به کاربران.

```csharp
UserClaimAddons = new List<UserClaimAddonOption>
{
    new UserClaimAddonOption
    {
        Type = "role",
        Value = "user",
        ValueType = "string"
    },
    new UserClaimAddonOption
    {
        Type = "permission",
        Value = "read",
        ValueType = "string"
    }
}
```

### 4. User Info Registration

**توضیح:** امکان دریافت و ثبت اطلاعات کاربر از UserInfo endpoint.

```csharp
RegisterUserInfoClaims = new RegisterUserInfoClaimsOption
{
    Enabled = true,
    CachingData = true,
    CacheKeyPrefix = "UserInfoClaims_",
    CacheExpirationInSeconds = 300
}
```

### 5. Caching Support

**توضیح:** پشتیبانی از کش برای بهبود عملکرد و کاهش درخواست‌های غیرضروری.

## 📝 مثال کامل

### 1. تنظیمات در Program.cs

```csharp
using Zamin.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// رجیستر کردن سرویس احراز هویت
builder.Services.AddZaminApiAuthentication(builder.Configuration);

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
```

### 2. استفاده در کنترلر

```csharp
[ApiController]
[Route("api/[controller]")]
[Authorize] // نیاز به احراز هویت
public class UserController : ControllerBase
{
    [HttpGet]
    public IActionResult GetUser()
    {
        var userId = User.FindFirst("user_id")?.Value;
        var email = User.FindFirst("user_email")?.Value;
        var role = User.FindFirst("role")?.Value;
        
        return Ok(new { UserId = userId, Email = email, Role = role });
    }

    [HttpGet("profile")]
    public IActionResult GetProfile()
    {
        // استفاده از ClaimsPrincipal extensions
        var hasSubClaim = User.HasSubClaim("sub");
        
        return Ok(new { HasSubClaim = hasSubClaim });
    }
}
```

### 3. تنظیمات پیشرفته

```csharp
builder.Services.AddZaminApiAuthentication(options =>
{
    options.Enabled = true;
    options.Providers = new List<ProviderOption>
    {
        // JWT Provider
        new ProviderOption
        {
            Enabled = true,
            Scheme = "JWT",
            Authority = "https://jwt-auth.example.com",
            TokenTypeSupport = TokenType.Jwt,
            Priority = 1,
            UserIdentifierClaimType = "sub",
            JwtTokenConfig = new JwtTokenConfigOption
            {
                Audience = "api.example.com",
                RequireHttpsMetadata = true,
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateIssuerSigningKey = true
            },
            RegisterUserInfoClaims = new RegisterUserInfoClaimsOption
            {
                Enabled = true,
                CachingData = true,
                CacheKeyPrefix = "JWT_UserInfo_",
                CacheExpirationInSeconds = 600
            },
            UserClaimRules = new List<UserClaimRuleOption>
            {
                new UserClaimRuleOption
                {
                    Source = "sub",
                    Destination = "user_id",
                    RemoveSource = false
                }
            },
            UserClaimAddons = new List<UserClaimAddonOption>
            {
                new UserClaimAddonOption
                {
                    Type = "auth_provider",
                    Value = "jwt",
                    ValueType = "string"
                }
            }
        },
        // Reference Token Provider
        new ProviderOption
        {
            Enabled = true,
            Scheme = "OAuth",
            Authority = "https://oauth.example.com",
            TokenTypeSupport = TokenType.Reference,
            Priority = 2,
            UserIdentifierClaimType = "sub",
            RefrenceTokenConfig = new RefrenceTokenConfigOption
            {
                ClientId = "api_client",
                ClientSecret = "secret_key"
            },
            RegisterUserInfoClaims = new RegisterUserInfoClaimsOption
            {
                Enabled = true,
                CachingData = true,
                CacheKeyPrefix = "OAuth_UserInfo_",
                CacheExpirationInSeconds = 300
            }
        }
    };
});
```

### 4. استفاده از Extensions

```csharp
public class UserService
{
    public void ProcessUser(ClaimsPrincipal user)
    {
        // بررسی وجود Claim
        var hasSubClaim = user.HasSubClaim("sub");
        
        // ایجاد ClaimsIdentity جدید
        var newClaims = new List<Claim>
        {
            new Claim("custom_claim", "custom_value")
        };
        var newIdentity = user.CreateClaimsIdentity(newClaims);
        
        // کلون Principal با Claim های تبدیل شده
        var provider = new ProviderOption(); // تنظیمات Provider
        var clonedPrincipal = user.ClonePrincipalWithConvertedClaims(provider);
    }
}
```

## 🔍 نکات مهم

### بهترین روش‌ها:
- از Priority برای تنظیم اولویت Provider ها استفاده کنید
- در محیط Production، `RequireHttpsMetadata` را `true` کنید
- از Caching برای بهبود عملکرد استفاده کنید
- Claim Rules را با دقت تنظیم کنید

### امنیت:
- همیشه `ValidateIssuer` و `ValidateAudience` را در Production فعال کنید
- از `IgnoreSSL` فقط در Development استفاده کنید
- Client Secret ها را در جای امن نگهداری کنید

### عملکرد:
- از Caching برای User Info استفاده کنید
- Provider های غیرضروری را غیرفعال کنید
- Cache Expiration را بر اساس نیاز تنظیم کنید

## 📚 وابستگی‌ها

- **Microsoft.Extensions.DependencyModel** (9.0.0) - برای مدیریت وابستگی‌ها
- **Microsoft.AspNetCore.Authentication.JwtBearer** (9.0.0) - برای JWT Authentication
- **Zamin.Extensions.Caching.Abstractions** (9.0.0) - برای Caching
- **IdentityModel** (7.0.0) - برای OAuth2 و JWT
- **IdentityModel.AspNetCore.OAuth2Introspection** (6.2.0) - برای Reference Token

## 🤝 مشارکت

برای گزارش باگ یا درخواست ویژگی جدید، لطفاً با تیم توسعه تماس بگیرید.

## 📄 مجوز

این پکیج تحت مجوز اختصاصی تیم Zamin منتشر شده است.
