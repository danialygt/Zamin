# Zamin.Utilities.SoftwarePartDetector

## 📋 معرفی پکیج

این پکیج یک سیستم پیشرفته برای تشخیص و تحلیل ساختار نرم‌افزاری پروژه‌های ASP.NET Core ارائه می‌دهد. این پکیج قابلیت شناسایی خودکار کنترلرها، اکشن‌ها، سرویس‌ها و ماژول‌ها را دارد و ساختار سلسله‌مراتبی نرم‌افزار را به صورت خودکار ایجاد می‌کند.

**زمان استفاده:** زمانی که نیاز به تحلیل ساختار نرم‌افزاری، مستندسازی خودکار API ها، مدیریت مجوزها بر اساس ساختار نرم‌افزار یا ارسال اطلاعات ساختاری به سیستم‌های خارجی دارید.

**تکنولوژی:** این پکیج برای پروژه‌های ASP.NET Core 9.0 و بالاتر طراحی شده است.

## 📦 نسخه

**نسخه فعلی:** 9.0.0

## 🚀 نصب و راه‌اندازی

### نصب پکیج

با استفاده از NuGet Package Manager:

```bash
dotnet add package Zamin.Utilities.SoftwarePartDetector
```

یا از طریق Package Manager Console در Visual Studio:

```powershell
Install-Package Zamin.Utilities.SoftwarePartDetector
```

### رجیستر کردن در پروژه

در فایل `Program.cs` خود، سرویس را به DI Container اضافه کنید:

```csharp
using Zamin.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// رجیستر کردن SoftwarePartDetector
builder.Services.AddSoftwarePartDetector(builder.Configuration, "SoftwarePartDetectorOptions");

var app = builder.Build();

app.Run();
```

### تنظیمات (Configuration)

#### تنظیمات در `appsettings.json`

```json
{
  "SoftwarePartDetectorOptions": {
    "ApplicationName": "MyApplication",
    "ModuleName": "UserManagement",
    "ServiceName": "UserService",
    "DestinationServiceBaseAddress": "https://api.example.com",
    "DestinationServicePath": "/api/softwareparts",
    "FakeSSL": false,
    "OAuth": {
      "Enabled": true,
      "ClientId": "your-client-id",
      "ClientSecret": "your-client-secret",
      "Authority": "https://auth.example.com",
      "Scopes": ["softwarepart.write", "softwarepart.read"]
    }
  }
}
```

#### تنظیمات دستی (بدون appsettings.json)

```csharp
builder.Services.AddSoftwarePartDetector(options =>
{
    options.ApplicationName = "MyApplication";
    options.ModuleName = "UserManagement";
    options.ServiceName = "UserService";
    options.DestinationServiceBaseAddress = "https://api.example.com";
    options.DestinationServicePath = "/api/softwareparts";
    options.FakeSSL = false;
    options.OAuth = new OAuthOption
    {
        Enabled = true,
        ClientId = "your-client-id",
        ClientSecret = "your-client-secret",
        Authority = "https://auth.example.com",
        Scopes = new[] { "softwarepart.write", "softwarepart.read" }
    };
});
```

## ⚙️ گزینه‌های کانفیگ

### SoftwarePartDetectorOptions

#### 1. `ApplicationName`
- **توضیح:** نام اپلیکیشن که در ساختار نرم‌افزاری ثبت می‌شود
- **مقدار پیش‌فرض:** `string.Empty`
- **زمان تغییر:** همیشه باید تنظیم شود
- **مثال:** `"MyApplication"`

#### 2. `ModuleName`
- **توضیح:** نام ماژول که در ساختار نرم‌افزاری ثبت می‌شود
- **مقدار پیش‌فرض:** `string.Empty`
- **زمان تغییر:** زمانی که می‌خواهید کنترلرها را در یک ماژول خاص گروه‌بندی کنید
- **مثال:** `"UserManagement"`

#### 3. `ServiceName`
- **توضیح:** نام سرویس که در ساختار نرم‌افزاری ثبت می‌شود
- **مقدار پیش‌فرض:** `string.Empty`
- **زمان تغییر:** زمانی که می‌خواهید کنترلرها را در یک سرویس خاص گروه‌بندی کنید
- **مثال:** `"UserService"`

#### 4. `DestinationServiceBaseAddress`
- **توضیح:** آدرس پایه سرویس مقصد برای ارسال اطلاعات ساختاری
- **مقدار پیش‌فرض:** `string.Empty`
- **زمان تغییر:** زمانی که می‌خواهید اطلاعات را به سرویس خارجی ارسال کنید
- **مثال:** `"https://api.example.com"`

#### 5. `DestinationServicePath`
- **توضیح:** مسیر API برای ارسال اطلاعات ساختاری
- **مقدار پیش‌فرض:** `string.Empty`
- **زمان تغییر:** زمانی که می‌خواهید اطلاعات را به سرویس خارجی ارسال کنید
- **مثال:** `"/api/softwareparts"`

#### 6. `FakeSSL`
- **توضیح:** آیا اعتبارسنجی گواهی SSL غیرفعال شود
- **مقدار پیش‌فرض:** `false`
- **زمان تغییر:** برای محیط‌های Development یا تست
- **مثال:** `true`

### OAuthOption

#### 7. `Enabled`
- **توضیح:** آیا احراز هویت OAuth فعال باشد
- **مقدار پیش‌فرض:** `true`
- **زمان تغییر:** برای غیرفعال کردن احراز هویت
- **مثال:** `false`

#### 8. `ClientId`
- **توضیح:** شناسه کلاینت OAuth
- **مقدار پیش‌فرض:** `string.Empty`
- **زمان تغییر:** زمانی که احراز هویت OAuth فعال است
- **مثال:** `"your-client-id"`

#### 9. `ClientSecret`
- **توضیح:** رمز کلاینت OAuth
- **مقدار پیش‌فرض:** `string.Empty`
- **زمان تغییر:** زمانی که احراز هویت OAuth فعال است
- **مثال:** `"your-client-secret"`

#### 10. `Authority`
- **توضیح:** آدرس سرور احراز هویت OAuth
- **مقدار پیش‌فرض:** `string.Empty`
- **زمان تغییر:** زمانی که احراز هویت OAuth فعال است
- **مثال:** `"https://auth.example.com"`

#### 11. `Scopes`
- **توضیح:** Scope های مورد نیاز برای دسترسی
- **مقدار پیش‌فرض:** `Array.Empty<string>()`
- **زمان تغییر:** زمانی که احراز هویت OAuth فعال است
- **مثال:** `["softwarepart.write", "softwarepart.read"]`

## 🔧 ویژگی‌های اصلی

### 1. تشخیص خودکار ساختار نرم‌افزاری

#### SoftwarePartDetector
**توضیح:** کلاس اصلی برای تشخیص و ایجاد ساختار سلسله‌مراتبی نرم‌افزار.

**متدهای اصلی:**
- `Detect(string softwareName)` - تشخیص ساختار با نام نرم‌افزار
- `Detect(string softwareName, string moduleName)` - تشخیص ساختار با نام نرم‌افزار و ماژول
- `Detect(string softwareName, string moduleName, string serviceName)` - تشخیص ساختار کامل

**مثال استفاده:**
```csharp
public class MyService
{
    private readonly SoftwarePartDetector _detector;

    public MyService(SoftwarePartDetector detector)
    {
        _detector = detector;
    }

    public async Task<SoftwarePart> GetSoftwareStructure()
    {
        return await _detector.Detect("MyApp", "UserModule", "UserService");
    }
}
```

#### ControllersAndActionDetector
**توضیح:** کلاس برای تشخیص کنترلرها و اکشن‌های موجود در پروژه.

**متد اصلی:**
- `Detect()` - تشخیص تمام کنترلرها و اکشن‌ها

**مثال استفاده:**
```csharp
public class ControllerAnalyzer
{
    private readonly ControllersAndActionDetector _detector;

    public ControllerAnalyzer(ControllersAndActionDetector detector)
    {
        _detector = detector;
    }

    public async Task<List<SoftwarePartController>> GetControllers()
    {
        return await _detector.Detect();
    }
}
```

### 2. مدیریت ساختار سلسله‌مراتبی

#### SoftwarePart
**توضیح:** مدل اصلی برای نمایش بخش‌های نرم‌افزاری.

**ویژگی‌ها:**
- `Name` - نام بخش نرم‌افزاری
- `SoftwarePartType` - نوع بخش (Software, Module, Service, Controller, Action)
- `Children` - بخش‌های زیرمجموعه

**مثال استفاده:**
```csharp
var softwarePart = new SoftwarePart
{
    Name = "MyApplication",
    SoftwarePartType = SoftwarePartType.Software,
    Children = new List<SoftwarePart>
    {
        new SoftwarePart
        {
            Name = "UserModule",
            SoftwarePartType = SoftwarePartType.Module,
            Children = new List<SoftwarePart>
            {
                new SoftwarePart
                {
                    Name = "UserController",
                    SoftwarePartType = SoftwarePartType.Controller,
                    Children = new List<SoftwarePart>
                    {
                        new SoftwarePart
                        {
                            Name = "GetUsers",
                            SoftwarePartType = SoftwarePartType.Action
                        }
                    }
                }
            }
        }
    }
};
```

### 3. Attribute های سفارشی

#### SoftwarePartControllerOptionAttribute
**توضیح:** Attribute برای تعریف ماژول و سرویس کنترلرها.

**پارامترها:**
- `service` - نام سرویس (اجباری)
- `module` - نام ماژول (اختیاری)

**مثال استفاده:**
```csharp
[SoftwarePartControllerOption("UserService", "UserManagement")]
[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    [HttpGet]
    public IActionResult GetUsers()
    {
        // منطق کسب کاربران
        return Ok();
    }
}
```

### 4. ارسال اطلاعات به سرویس خارجی

#### ISoftwarePartPublisher
**توضیح:** اینترفیس برای ارسال اطلاعات ساختاری به سرویس خارجی.

**متد اصلی:**
- `PublishAsync(SoftwarePart softwarePart)` - ارسال اطلاعات ساختاری

**مثال استفاده:**
```csharp
public class SoftwarePartService
{
    private readonly ISoftwarePartPublisher _publisher;

    public SoftwarePartService(ISoftwarePartPublisher publisher)
    {
        _publisher = publisher;
    }

    public async Task PublishStructure(SoftwarePart softwarePart)
    {
        await _publisher.PublishAsync(softwarePart);
    }
}
```

#### SoftwarePartWebPublisher
**توضیح:** پیاده‌سازی HTTP برای ارسال اطلاعات به سرویس خارجی.

**ویژگی‌ها:**
- پشتیبانی از OAuth Authentication
- ارسال JSON
- مدیریت HTTP Client

### 5. احراز هویت OAuth

#### ISoftwarePartAuthentication
**توضیح:** اینترفیس برای احراز هویت OAuth.

**متد اصلی:**
- `LoginAsync()` - دریافت Token OAuth

**مثال استفاده:**
```csharp
public class AuthService
{
    private readonly ISoftwarePartAuthentication _auth;

    public AuthService(ISoftwarePartAuthentication auth)
    {
        _auth = auth;
    }

    public async Task<string> GetAccessToken()
    {
        var tokenResponse = await _auth.LoginAsync();
        return tokenResponse.AccessToken;
    }
}
```

## 📝 مثال کامل

### 1. تنظیمات در Program.cs

```csharp
using Zamin.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// رجیستر کردن SoftwarePartDetector
builder.Services.AddSoftwarePartDetector(builder.Configuration, "SoftwarePartDetectorOptions");

var app = builder.Build();

// اجرای تشخیص ساختار
using (var scope = app.Services.CreateScope())
{
    var detectorService = scope.ServiceProvider.GetRequiredService<SoftwarePartDetectorService>();
    await detectorService.Run();
}

app.Run();
```

### 2. استفاده از Attribute در کنترلرها

```csharp
[SoftwarePartControllerOption("UserService", "UserManagement")]
[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    [HttpGet]
    public IActionResult GetUsers()
    {
        return Ok();
    }

    [HttpPost]
    public IActionResult CreateUser(CreateUserRequest request)
    {
        return Ok();
    }
}

[SoftwarePartControllerOption("OrderService", "OrderManagement")]
[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    [HttpGet]
    public IActionResult GetOrders()
    {
        return Ok();
    }
}
```

### 3. استفاده در سرویس‌ها

```csharp
public class SoftwarePartAnalyzer
{
    private readonly SoftwarePartDetector _detector;
    private readonly ISoftwarePartPublisher _publisher;

    public SoftwarePartAnalyzer(SoftwarePartDetector detector, ISoftwarePartPublisher publisher)
    {
        _detector = detector;
        _publisher = publisher;
    }

    public async Task AnalyzeAndPublish()
    {
        // تشخیص ساختار نرم‌افزاری
        var softwarePart = await _detector.Detect("MyApplication", "UserManagement", "UserService");
        
        // ارسال به سرویس خارجی
        await _publisher.PublishAsync(softwarePart);
    }
}
```

### 4. تنظیمات کامل appsettings.json

```json
{
  "SoftwarePartDetectorOptions": {
    "ApplicationName": "MyEnterpriseApp",
    "ModuleName": "UserManagement",
    "ServiceName": "UserService",
    "DestinationServiceBaseAddress": "https://api.enterprise.com",
    "DestinationServicePath": "/api/v1/softwareparts",
    "FakeSSL": false,
    "OAuth": {
      "Enabled": true,
      "ClientId": "softwarepart-detector-client",
      "ClientSecret": "your-secret-key",
      "Authority": "https://auth.enterprise.com",
      "Scopes": [
        "softwarepart.write",
        "softwarepart.read",
        "softwarepart.admin"
      ]
    }
  }
}
```

### 5. تنظیمات برای محیط‌های مختلف

#### Development
```csharp
builder.Services.AddSoftwarePartDetector(options =>
{
    options.ApplicationName = "MyApp-Dev";
    options.ModuleName = "UserModule";
    options.ServiceName = "UserService";
    options.DestinationServiceBaseAddress = "https://dev-api.example.com";
    options.DestinationServicePath = "/api/softwareparts";
    options.FakeSSL = true;
    options.OAuth = new OAuthOption
    {
        Enabled = false
    };
});
```

#### Production
```csharp
builder.Services.AddSoftwarePartDetector(options =>
{
    options.ApplicationName = "MyApp-Prod";
    options.ModuleName = "UserModule";
    options.ServiceName = "UserService";
    options.DestinationServiceBaseAddress = "https://api.example.com";
    options.DestinationServicePath = "/api/v1/softwareparts";
    options.FakeSSL = false;
    options.OAuth = new OAuthOption
    {
        Enabled = true,
        ClientId = "prod-client-id",
        ClientSecret = "prod-client-secret",
        Authority = "https://auth.example.com",
        Scopes = new[] { "softwarepart.write", "softwarepart.read" }
    };
});
```

### 6. استفاده در Background Service

```csharp
public class SoftwarePartDetectionBackgroundService : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;

    public SoftwarePartDetectionBackgroundService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var detectorService = scope.ServiceProvider.GetRequiredService<SoftwarePartDetectorService>();
                await detectorService.Run();
            }

            await Task.Delay(TimeSpan.FromHours(1), stoppingToken); // هر ساعت یکبار
        }
    }
}

// رجیستر کردن در Program.cs
builder.Services.AddHostedService<SoftwarePartDetectionBackgroundService>();
```

## 🔍 نکات مهم

### بهترین روش‌ها:
- از Attribute های مناسب برای کنترلرها استفاده کنید
- ساختار سلسله‌مراتبی را به درستی تعریف کنید
- از OAuth برای امنیت استفاده کنید
- در Production، FakeSSL را غیرفعال کنید

### عملکرد:
- تشخیص ساختار را در Background Service اجرا کنید
- از Caching برای بهبود عملکرد استفاده کنید
- اطلاعات را به صورت Batch ارسال کنید

### امنیت:
- از HTTPS برای اتصالات استفاده کنید
- Client Secret را در User Secrets نگهداری کنید
- Scope های مناسب تعریف کنید

## 📚 وابستگی‌ها

- **IdentityModel** (7.0.0) - برای OAuth Authentication
- **Microsoft.AspNetCore.Mvc.Core** (2.2.5) - برای ASP.NET Core MVC
- **Microsoft.Extensions.Http** (9.0.0) - برای HTTP Client
- **Microsoft.Extensions.Options.ConfigurationExtensions** (9.0.0) - برای Configuration
- **Zamin.Extensions.Serializers.Abstractions** (9.0.0) - برای JSON Serialization

## 🤝 مشارکت

برای گزارش باگ یا درخواست ویژگی جدید، لطفاً با تیم توسعه تماس بگیرید.

## 📄 مجوز

این پکیج تحت مجوز اختصاصی تیم Zamin منتشر شده است.
