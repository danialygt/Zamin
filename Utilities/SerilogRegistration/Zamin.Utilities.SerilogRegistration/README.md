# Zamin.Utilities.SerilogRegistration

## 📋 معرفی پکیج

این پکیج یک سیستم لاگ‌گیری پیشرفته و کامل برای پروژه‌های ASP.NET Core ارائه می‌دهد که بر اساس Serilog ساخته شده است. این پکیج شامل Enricher های سفارشی، پشتیبانی از چندین Sink مختلف و قابلیت‌های پیشرفته برای مدیریت لاگ‌ها است.

**زمان استفاده:** زمانی که نیاز به سیستم لاگ‌گیری پیشرفته با Enricher های سفارشی، پشتیبانی از چندین مقصد (File, Database, Elasticsearch, Seq) و مدیریت اطلاعات کاربر در لاگ‌ها دارید.

**تکنولوژی:** این پکیج برای پروژه‌های ASP.NET Core 9.0 و بالاتر طراحی شده است.

## 📦 نسخه

**نسخه فعلی:** 9.0.0

## 🚀 نصب و راه‌اندازی

### نصب پکیج

با استفاده از NuGet Package Manager:

```bash
dotnet add package Zamin.Utilities.SerilogRegistration
```

یا از طریق Package Manager Console در Visual Studio:

```powershell
Install-Package Zamin.Utilities.SerilogRegistration
```

### رجیستر کردن در پروژه

در فایل `Program.cs` خود، سرویس را به DI Container اضافه کنید:

```csharp
using Zamin.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// رجیستر کردن Serilog
builder.AddZaminSerilog(builder.Configuration);

var app = builder.Build();

app.Run();
```

### تنظیمات (Configuration)

#### تنظیمات در `appsettings.json`

```json
{
  "SerilogApplicationEnricherOptions": {
    "ApplicationName": "MyApplication",
    "ServiceName": "UserService",
    "ServiceVersion": "1.0.0",
    "ServiceId": "user-service-001"
  },
  "Serilog": {
    "Using": ["Serilog.Sinks.Console", "Serilog.Sinks.File", "Serilog.Sinks.Seq"],
    "MinimumLevel": {
      "Default": "Information",
      "Override": {
        "Microsoft": "Warning",
        "System": "Warning"
      }
    },
    "WriteTo": [
      {
        "Name": "Console",
        "Args": {
          "outputTemplate": "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj} {Properties:j}{NewLine}{Exception}"
        }
      },
      {
        "Name": "File",
        "Args": {
          "path": "logs/log-.txt",
          "rollingInterval": "Day",
          "retainedFileCountLimit": 7,
          "outputTemplate": "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} {Level:u3}] {Message:lj} {Properties:j}{NewLine}{Exception}"
        }
      },
      {
        "Name": "Seq",
        "Args": {
          "serverUrl": "http://localhost:5341"
        }
      },
      {
        "Name": "MSSqlServer",
        "Args": {
          "connectionString": "Server=localhost;Database=Logs;Trusted_Connection=true;",
          "tableName": "Logs",
          "autoCreateSqlTable": true
        }
      },
      {
        "Name": "Elasticsearch",
        "Args": {
          "nodeUris": "http://localhost:9200",
          "indexFormat": "logs-{0:yyyy.MM.dd}"
        }
      }
    ],
    "Enrich": ["FromLogContext", "WithExceptionDetails", "WithSpan"]
  }
}
```

#### تنظیمات دستی (بدون appsettings.json)

```csharp
builder.AddZaminSerilog(options =>
{
    options.ApplicationName = "MyApplication";
    options.ServiceName = "UserService";
    options.ServiceVersion = "1.0.0";
    options.ServiceId = "user-service-001";
});
```

## ⚙️ گزینه‌های کانفیگ

### SerilogApplicationEnricherOptions

#### 1. `ApplicationName`
- **توضیح:** نام اپلیکیشن که در لاگ‌ها ثبت می‌شود
- **مقدار پیش‌فرض:** `string.Empty`
- **زمان تغییر:** همیشه باید تنظیم شود
- **مثال:** `"MyApplication"`

#### 2. `ServiceName`
- **توضیح:** نام سرویس که در لاگ‌ها ثبت می‌شود
- **مقدار پیش‌فرض:** `string.Empty`
- **زمان تغییر:** همیشه باید تنظیم شود
- **مثال:** `"UserService"`

#### 3. `ServiceVersion`
- **توضیح:** نسخه سرویس که در لاگ‌ها ثبت می‌شود
- **مقدار پیش‌فرض:** `string.Empty`
- **زمان تغییر:** همیشه باید تنظیم شود
- **مثال:** `"1.0.0"`

#### 4. `ServiceId`
- **توضیح:** شناسه یکتا سرویس که در لاگ‌ها ثبت می‌شود
- **مقدار پیش‌فرض:** `string.Empty`
- **زمان تغییر:** همیشه باید تنظیم شود
- **مثال:** `"user-service-001"`

## 🔧 ویژگی‌های اصلی

### 1. Enricher های سفارشی

#### ZaminApplicationEnricher
**توضیح:** این Enricher اطلاعات اپلیکیشن و سرویس را به تمام لاگ‌ها اضافه می‌کند.

**اطلاعات اضافه شده:**
- `ApplicationName` - نام اپلیکیشن
- `ServiceName` - نام سرویس
- `ServiceVersion` - نسخه سرویس
- `ServiceId` - شناسه سرویس
- `MachineName` - نام ماشین
- `EntryPoint` - نقطه ورود اپلیکیشن

#### ZaminUserInfoEnricher
**توضیح:** این Enricher اطلاعات کاربر فعلی را به لاگ‌ها اضافه می‌کند.

**اطلاعات اضافه شده:**
- `UserName` - نام کاربری
- `UserId` - شناسه کاربر
- `UserIp` - آدرس IP کاربر
- `ClientId` - شناسه کلاینت

### 2. پشتیبانی از چندین Sink

#### Console Sink
```json
{
  "Name": "Console",
  "Args": {
    "outputTemplate": "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj} {Properties:j}{NewLine}{Exception}"
  }
}
```

#### File Sink
```json
{
  "Name": "File",
  "Args": {
    "path": "logs/log-.txt",
    "rollingInterval": "Day",
    "retainedFileCountLimit": 7
  }
}
```

#### Seq Sink
```json
{
  "Name": "Seq",
  "Args": {
    "serverUrl": "http://localhost:5341"
  }
}
```

#### SQL Server Sink
```json
{
  "Name": "MSSqlServer",
  "Args": {
    "connectionString": "Server=localhost;Database=Logs;Trusted_Connection=true;",
    "tableName": "Logs",
    "autoCreateSqlTable": true
  }
}
```

#### Elasticsearch Sink
```json
{
  "Name": "Elasticsearch",
  "Args": {
    "nodeUris": "http://localhost:9200",
    "indexFormat": "logs-{0:yyyy.MM.dd}"
  }
}
```

### 3. Enricher های پیش‌فرض

- **FromLogContext** - اضافه کردن اطلاعات از LogContext
- **WithExceptionDetails** - جزئیات کامل Exception ها
- **WithSpan** - اطلاعات Span برای Distributed Tracing

## 📝 مثال کامل

### 1. تنظیمات در Program.cs

```csharp
using Zamin.Extensions.DependencyInjection;
using Zamin.Utilities.SerilogRegistration.Extensions;

var builder = WebApplication.CreateBuilder(args);

// رجیستر کردن Serilog
builder.AddZaminSerilog(builder.Configuration);

var app = builder.Build();

// استفاده از Exception Handling
SerilogExtensions.RunWithSerilogExceptionHandling(
    () => app.Run(),
    "Starting up MyApplication",
    "Unhandled exception occurred",
    "Shutdown complete"
);
```

### 2. استفاده در کنترلر

```csharp
[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;

    public UserController(ILogger<UserController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult GetUsers()
    {
        _logger.LogInformation("Getting all users");
        
        try
        {
            // منطق کسب کاربران
            var users = GetUsersFromDatabase();
            
            _logger.LogInformation("Successfully retrieved {UserCount} users", users.Count);
            return Ok(users);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while getting users");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpPost]
    public IActionResult CreateUser(CreateUserRequest request)
    {
        _logger.LogInformation("Creating new user with email {Email}", request.Email);
        
        try
        {
            // منطق ایجاد کاربر
            var user = CreateUserInDatabase(request);
            
            _logger.LogInformation("Successfully created user with ID {UserId}", user.Id);
            return Ok(user);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while creating user with email {Email}", request.Email);
            return StatusCode(500, "Internal server error");
        }
    }
}
```

### 3. استفاده در سرویس‌ها

```csharp
public class UserService
{
    private readonly ILogger<UserService> _logger;

    public UserService(ILogger<UserService> logger)
    {
        _logger = logger;
    }

    public async Task<User> GetUserByIdAsync(int userId)
    {
        using var activity = _logger.BeginScope("Getting user by ID {UserId}", userId);
        
        _logger.LogInformation("Starting to get user by ID {UserId}", userId);
        
        try
        {
            var user = await _userRepository.GetByIdAsync(userId);
            
            if (user == null)
            {
                _logger.LogWarning("User with ID {UserId} not found", userId);
                return null;
            }
            
            _logger.LogInformation("Successfully retrieved user {UserId}", userId);
            return user;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while getting user {UserId}", userId);
            throw;
        }
    }
}
```

### 4. تنظیمات پیشرفته

```csharp
// با Enricher های سفارشی
builder.AddZaminSerilog(
    builder.Configuration,
    typeof(CustomEnricher1),
    typeof(CustomEnricher2)
);

// با تنظیمات دستی
builder.AddZaminSerilog(options =>
{
    options.ApplicationName = "MyEnterpriseApp";
    options.ServiceName = "UserManagementService";
    options.ServiceVersion = "2.1.0";
    options.ServiceId = "user-mgmt-001";
}, typeof(CustomEnricher));
```

### 5. ایجاد Enricher سفارشی

```csharp
public class CustomEnricher : ILogEventEnricher
{
    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
    {
        var customProperty = propertyFactory.CreateProperty("CustomField", "CustomValue");
        logEvent.AddPropertyIfAbsent(customProperty);
    }
}
```

### 6. تنظیمات کامل appsettings.json

```json
{
  "SerilogApplicationEnricherOptions": {
    "ApplicationName": "MyEnterpriseApp",
    "ServiceName": "UserManagementService",
    "ServiceVersion": "2.1.0",
    "ServiceId": "user-mgmt-001"
  },
  "Serilog": {
    "Using": [
      "Serilog.Sinks.Console",
      "Serilog.Sinks.File",
      "Serilog.Sinks.Seq",
      "Serilog.Sinks.MSSqlServer",
      "Serilog.Sinks.Elasticsearch"
    ],
    "MinimumLevel": {
      "Default": "Information",
      "Override": {
        "Microsoft": "Warning",
        "System": "Warning",
        "Microsoft.AspNetCore": "Warning"
      }
    },
    "WriteTo": [
      {
        "Name": "Console",
        "Args": {
          "outputTemplate": "[{Timestamp:HH:mm:ss} {Level:u3}] {SourceContext} {Message:lj} {Properties:j}{NewLine}{Exception}"
        }
      },
      {
        "Name": "File",
        "Args": {
          "path": "logs/app-.txt",
          "rollingInterval": "Day",
          "retainedFileCountLimit": 30,
          "outputTemplate": "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} {Level:u3}] {SourceContext} {Message:lj} {Properties:j}{NewLine}{Exception}"
        }
      },
      {
        "Name": "Seq",
        "Args": {
          "serverUrl": "http://localhost:5341",
          "apiKey": "your-api-key"
        }
      },
      {
        "Name": "MSSqlServer",
        "Args": {
          "connectionString": "Server=localhost;Database=Logs;Trusted_Connection=true;",
          "tableName": "ApplicationLogs",
          "autoCreateSqlTable": true,
          "columnOptionsSection": {
            "addStandardColumns": ["LogEvent"],
            "removeStandardColumns": ["MessageTemplate", "Properties"],
            "timeStamp": {
              "columnName": "Timestamp",
              "convertToUtc": true
            }
          }
        }
      },
      {
        "Name": "Elasticsearch",
        "Args": {
          "nodeUris": "http://localhost:9200",
          "indexFormat": "app-logs-{0:yyyy.MM.dd}",
          "autoRegisterTemplate": true,
          "numberOfShards": 1,
          "numberOfReplicas": 0
        }
      }
    ],
    "Enrich": ["FromLogContext", "WithExceptionDetails", "WithSpan"]
  }
}
```

## 🔍 نکات مهم

### بهترین روش‌ها:
- از Structured Logging استفاده کنید
- اطلاعات حساس را در لاگ‌ها ثبت نکنید
- از Log Levels مناسب استفاده کنید
- در Production، لاگ‌ها را به مقاصد مناسب ارسال کنید

### عملکرد:
- از Async Logging استفاده کنید
- Rolling Files را برای مدیریت حجم لاگ‌ها تنظیم کنید
- Cache مناسب برای Enricher ها تنظیم کنید

### امنیت:
- اطلاعات حساس را در لاگ‌ها ثبت نکنید
- از API Key های مناسب برای Seq استفاده کنید
- دسترسی به فایل‌های لاگ را محدود کنید

## 📚 وابستگی‌ها

- **Microsoft.Extensions.Logging.Abstractions** (9.0.0) - برای Logging Abstractions
- **Microsoft.Extensions.Options.ConfigurationExtensions** (9.0.0) - برای Configuration
- **Serilog** (4.2.0) - هسته Serilog
- **Serilog.AspNetCore** (9.0.0) - برای ASP.NET Core
- **Serilog.Enrichers.Span** (3.1.0) - برای Span Enrichment
- **Serilog.Exceptions** (8.4.0) - برای Exception Details
- **Serilog.Sinks.Elasticsearch** (10.0.0) - برای Elasticsearch
- **Serilog.Sinks.File** (6.0.0) - برای File Logging
- **Serilog.Sinks.MSSqlServer** (8.1.0) - برای SQL Server
- **Serilog.Sinks.Seq** (8.0.0) - برای Seq
- **Zamin.Extensions.UsersManagement.Abstractions** (9.0.0) - برای User Management

## 🤝 مشارکت

برای گزارش باگ یا درخواست ویژگی جدید، لطفاً با تیم توسعه تماس بگیرید.

## 📄 مجوز

این پکیج تحت مجوز اختصاصی تیم Zamin منتشر شده است.
