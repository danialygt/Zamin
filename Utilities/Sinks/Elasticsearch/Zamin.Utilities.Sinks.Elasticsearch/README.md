# Zamin.Utilities.Sinks.Elasticsearch

## 📋 معرفی پکیج

این پکیج یک Extension Method پیشرفته و بهینه‌شده برای ارسال لاگ‌ها به Elasticsearch در پروژه‌های ASP.NET Core ارائه می‌دهد. این پکیج بر اساس Serilog.Sinks.Elasticsearch ساخته شده و قابلیت‌های اضافی و تنظیمات پیشرفته‌ای برای مدیریت بهتر لاگ‌ها در Elasticsearch فراهم می‌کند.

**زمان استفاده:** زمانی که نیاز به ارسال لاگ‌ها به Elasticsearch با تنظیمات پیشرفته، پشتیبانی از چندین Node، مدیریت Template ها و قابلیت‌های Enterprise دارید.

**تکنولوژی:** این پکیج برای پروژه‌های ASP.NET Core 8.0 و بالاتر طراحی شده است.

## 📦 نسخه

**نسخه فعلی:** 8.0.0

## 🚀 نصب و راه‌اندازی

### نصب پکیج

با استفاده از NuGet Package Manager:

```bash
dotnet add package Zamin.Utilities.Sinks.Elasticsearch
```

یا از طریق Package Manager Console در Visual Studio:

```powershell
Install-Package Zamin.Utilities.Sinks.Elasticsearch
```

### رجیستر کردن در پروژه

در فایل `Program.cs` خود، سرویس را به DI Container اضافه کنید:

```csharp
using Zamin.Utilities.Sinks.Elasticsearch;

var builder = WebApplication.CreateBuilder(args);

// تنظیمات Serilog با Elasticsearch
builder.Host.UseSerilog((context, services, configuration) =>
{
    configuration
        .ReadFrom.Configuration(context.Configuration)
        .WriteTo.ZaminElasticsearch(
            nodeUris: "http://localhost:9200",
            indexFormat: "logs-{0:yyyy.MM.dd}",
            autoRegisterTemplate: true
        );
});

var app = builder.Build();
app.Run();
```

### تنظیمات (Configuration)

#### تنظیمات در `appsettings.json`

```json
{
  "Serilog": {
    "Using": ["Serilog.Sinks.Console", "Zamin.Utilities.Sinks.Elasticsearch"],
    "MinimumLevel": {
      "Default": "Information",
      "Override": {
        "Microsoft": "Warning",
        "System": "Warning"
      }
    },
    "WriteTo": [
      {
        "Name": "Console"
      },
      {
        "Name": "ZaminElasticsearch",
        "Args": {
          "nodeUris": "http://localhost:9200",
          "indexFormat": "logs-{0:yyyy.MM.dd}",
          "templateName": "serilog-logs-template",
          "autoRegisterTemplate": true,
          "numberOfShards": 1,
          "numberOfReplicas": 0,
          "batchPostingLimit": 50,
          "period": 2,
          "connectionTimeout": 5,
          "queueSizeLimit": 100000
        }
      }
    ]
  }
}
```

#### تنظیمات دستی (بدون appsettings.json)

```csharp
builder.Host.UseSerilog((context, services, configuration) =>
{
    configuration
        .WriteTo.Console()
        .WriteTo.ZaminElasticsearch(
            nodeUris: "http://localhost:9200,http://localhost:9201",
            indexFormat: "myapp-logs-{0:yyyy.MM.dd}",
            templateName: "myapp-template",
            autoRegisterTemplate: true,
            numberOfShards: 2,
            numberOfReplicas: 1,
            batchPostingLimit: 100,
            period: 5,
            connectionTimeout: 10,
            queueSizeLimit: 50000,
            emitEventFailure: EmitEventFailureHandling.WriteToSelfLog,
            bufferBaseFilename: "logs/elasticsearch-buffer",
            bufferFileSizeLimitBytes: 104857600,
            bufferLogShippingInterval: 2000,
            connectionGlobalHeaders: "Authorization=Bearer your-token,Content-Type=application/json",
            disableServerCertificateValidation: false
        );
});
```

## ⚙️ پارامترهای کانفیگ

### پارامترهای اصلی

#### 1. `nodeUris`
- **توضیح:** آدرس‌های Node های Elasticsearch (جدا شده با کاما یا نقطه‌ویرگول)
- **مقدار پیش‌فرض:** ندارد (اجباری)
- **زمان تغییر:** همیشه باید تنظیم شود
- **مثال:** `"http://localhost:9200,http://localhost:9201"`

#### 2. `indexFormat`
- **توضیح:** فرمت نام Index در Elasticsearch
- **مقدار پیش‌فرض:** `"logstash-{0:yyyy.MM.dd}"`
- **زمان تغییر:** برای تغییر نام Index
- **مثال:** `"myapp-logs-{0:yyyy.MM.dd}"`

#### 3. `templateName`
- **توضیح:** نام Template برای Index
- **مقدار پیش‌فرض:** `null`
- **زمان تغییر:** زمانی که می‌خواهید Template سفارشی تعریف کنید
- **مثال:** `"myapp-logs-template"`

#### 4. `batchPostingLimit`
- **توضیح:** حداکثر تعداد لاگ در هر Batch
- **مقدار پیش‌فرض:** `50`
- **زمان تغییر:** برای بهینه‌سازی عملکرد
- **مثال:** `100`

#### 5. `period`
- **توضیح:** فاصله زمانی ارسال Batch ها (ثانیه)
- **مقدار پیش‌فرض:** `2`
- **زمان تغییر:** برای تنظیم فرکانس ارسال
- **مثال:** `5`

### پارامترهای پیشرفته

#### 6. `inlineFields`
- **توضیح:** آیا فیلدها به صورت Inline در Index ذخیره شوند
- **مقدار پیش‌فرض:** `false`
- **زمان تغییر:** برای بهینه‌سازی جستجو
- **مثال:** `true`

#### 7. `restrictedToMinimumLevel`
- **توضیح:** حداقل سطح لاگ برای ارسال
- **مقدار پیش‌فرض:** `LogEventLevel.Verbose`
- **زمان تغییر:** برای فیلتر کردن لاگ‌ها
- **مثال:** `LogEventLevel.Information`

#### 8. `bufferBaseFilename`
- **توضیح:** مسیر فایل Buffer برای ذخیره موقت لاگ‌ها
- **مقدار پیش‌فرض:** `null`
- **زمان تغییر:** برای بهبود قابلیت اطمینان
- **مثال:** `"logs/elasticsearch-buffer"`

#### 9. `bufferFileSizeLimitBytes`
- **توضیح:** حداکثر اندازه فایل Buffer (بایت)
- **مقدار پیش‌فرض:** `null`
- **زمان تغییر:** برای مدیریت حافظه
- **مثال:** `104857600` (100MB)

#### 10. `bufferLogShippingInterval`
- **توضیح:** فاصله زمانی ارسال لاگ‌ها از Buffer (میلی‌ثانیه)
- **مقدار پیش‌فرض:** `5000`
- **زمان تغییر:** برای تنظیم فرکانس ارسال
- **مثال:** `2000`

#### 11. `connectionGlobalHeaders`
- **توضیح:** Header های اضافی برای اتصال (جدا شده با کاما)
- **مقدار پیش‌فرض:** `null`
- **زمان تغییر:** برای احراز هویت یا تنظیمات خاص
- **مثال:** `"Authorization=Bearer token,Content-Type=application/json"`

#### 12. `connectionTimeout`
- **توضیح:** زمان انتظار برای اتصال (ثانیه)
- **مقدار پیش‌فرض:** `5`
- **زمان تغییر:** برای تنظیم Timeout
- **مثال:** `10`

#### 13. `emitEventFailure`
- **توضیح:** نحوه مدیریت خطاهای ارسال
- **مقدار پیش‌فرض:** `EmitEventFailureHandling.WriteToSelfLog`
- **زمان تغییر:** برای تغییر استراتژی مدیریت خطا
- **مثال:** `EmitEventFailureHandling.RaiseCallback`

#### 14. `queueSizeLimit`
- **توضیح:** حداکثر اندازه Queue برای لاگ‌ها
- **مقدار پیش‌فرض:** `100000`
- **زمان تغییر:** برای مدیریت حافظه
- **مثال:** `50000`

#### 15. `pipelineName`
- **توضیح:** نام Pipeline برای پردازش لاگ‌ها
- **مقدار پیش‌فرض:** `null`
- **زمان تغییر:** برای استفاده از Pipeline های Elasticsearch
- **مثال:** `"log-processing-pipeline"`

#### 16. `autoRegisterTemplate`
- **توضیح:** آیا Template به صورت خودکار ثبت شود
- **مقدار پیش‌فرض:** `false`
- **زمان تغییر:** برای تنظیم خودکار Index
- **مثال:** `true`

#### 17. `autoRegisterTemplateVersion`
- **توضیح:** نسخه Template برای ثبت
- **مقدار پیش‌فرض:** `null`
- **زمان تغییر:** برای استفاده از نسخه خاص
- **مثال:** `AutoRegisterTemplateVersion.ESv7`

#### 18. `overwriteTemplate`
- **توضیح:** آیا Template موجود بازنویسی شود
- **مقدار پیش‌فرض:** `false`
- **زمان تغییر:** برای به‌روزرسانی Template
- **مثال:** `true`

#### 19. `registerTemplateFailure`
- **توضیح:** نحوه مدیریت خطاهای ثبت Template
- **مقدار پیش‌فرض:** `RegisterTemplateRecovery.IndexAnyway`
- **زمان تغییر:** برای تغییر استراتژی مدیریت خطا
- **مثال:** `RegisterTemplateRecovery.IndexAnyway`

#### 20. `deadLetterIndexName`
- **توضیح:** نام Index برای لاگ‌های ناموفق
- **مقدار پیش‌فرض:** `null`
- **زمان تغییر:** برای ذخیره لاگ‌های ناموفق
- **مثال:** `"dead-letter-logs"`

#### 21. `numberOfShards`
- **توضیح:** تعداد Shard های Index
- **مقدار پیش‌فرض:** `null`
- **زمان تغییر:** برای تنظیم تعداد Shard
- **مثال:** `2`

#### 22. `numberOfReplicas`
- **توضیح:** تعداد Replica های Index
- **مقدار پیش‌فرض:** `null`
- **زمان تغییر:** برای تنظیم تعداد Replica
- **مثال:** `1`

#### 23. `singleEventSizePostingLimit`
- **توضیح:** حداکثر اندازه یک لاگ برای ارسال (بایت)
- **مقدار پیش‌فرض:** `null`
- **زمان تغییر:** برای محدود کردن اندازه لاگ‌ها
- **مثال:** `1048576` (1MB)

#### 24. `bufferFileCountLimit`
- **توضیح:** حداکثر تعداد فایل‌های Buffer
- **مقدار پیش‌فرض:** `null`
- **زمان تغییر:** برای مدیریت فایل‌های Buffer
- **مثال:** `10`

#### 25. `templateCustomSettings`
- **توضیح:** تنظیمات سفارشی برای Template
- **مقدار پیش‌فرض:** `null`
- **زمان تغییر:** برای تنظیمات پیشرفته Template
- **مثال:** `new Dictionary<string, string> { {"index.refresh_interval", "30s"} }`

#### 26. `batchAction`
- **توضیح:** نوع عملیات Batch
- **مقدار پیش‌فرض:** `ElasticOpType.Index`
- **زمان تغییر:** برای تغییر نوع عملیات
- **مثال:** `ElasticOpType.Create`

#### 27. `detectElasticsearchVersion`
- **توضیح:** آیا نسخه Elasticsearch به صورت خودکار تشخیص داده شود
- **مقدار پیش‌فرض:** `true`
- **زمان تغییر:** برای غیرفعال کردن تشخیص خودکار
- **مثال:** `false`

#### 28. `disableServerCertificateValidation`
- **توضیح:** آیا اعتبارسنجی گواهی SSL غیرفعال شود
- **مقدار پیش‌فرض:** `false`
- **زمان تغییر:** برای محیط‌های Development
- **مثال:** `true`

## 🔧 ویژگی‌های اصلی

### 1. پشتیبانی از چندین Node

```csharp
.WriteTo.ZaminElasticsearch(
    nodeUris: "http://node1:9200,http://node2:9200,http://node3:9200"
)
```

### 2. مدیریت Template های سفارشی

```csharp
.WriteTo.ZaminElasticsearch(
    nodeUris: "http://localhost:9200",
    templateName: "myapp-logs-template",
    autoRegisterTemplate: true,
    templateCustomSettings: new Dictionary<string, string>
    {
        {"index.refresh_interval", "30s"},
        {"index.number_of_shards", "2"},
        {"index.number_of_replicas", "1"}
    }
)
```

### 3. تنظیمات پیشرفته Buffer

```csharp
.WriteTo.ZaminElasticsearch(
    nodeUris: "http://localhost:9200",
    bufferBaseFilename: "logs/elasticsearch-buffer",
    bufferFileSizeLimitBytes: 104857600, // 100MB
    bufferFileCountLimit: 10,
    bufferLogShippingInterval: 2000
)
```

### 4. احراز هویت و امنیت

```csharp
.WriteTo.ZaminElasticsearch(
    nodeUris: "https://elasticsearch.example.com:9200",
    connectionGlobalHeaders: "Authorization=Bearer your-token,Content-Type=application/json",
    disableServerCertificateValidation: false
)
```

### 5. مدیریت خطا و قابلیت اطمینان

```csharp
.WriteTo.ZaminElasticsearch(
    nodeUris: "http://localhost:9200",
    emitEventFailure: EmitEventFailureHandling.WriteToSelfLog,
    deadLetterIndexName: "failed-logs",
    registerTemplateFailure: RegisterTemplateRecovery.IndexAnyway
)
```

## 📝 مثال کامل

### 1. تنظیمات ساده

```csharp
using Zamin.Utilities.Sinks.Elasticsearch;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, services, configuration) =>
{
    configuration
        .ReadFrom.Configuration(context.Configuration)
        .WriteTo.Console()
        .WriteTo.ZaminElasticsearch(
            nodeUris: "http://localhost:9200",
            indexFormat: "myapp-logs-{0:yyyy.MM.dd}",
            autoRegisterTemplate: true
        );
});

var app = builder.Build();
app.Run();
```

### 2. تنظیمات پیشرفته

```csharp
using Zamin.Utilities.Sinks.Elasticsearch;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, services, configuration) =>
{
    configuration
        .ReadFrom.Configuration(context.Configuration)
        .WriteTo.Console()
        .WriteTo.ZaminElasticsearch(
            nodeUris: "http://node1:9200,http://node2:9200,http://node3:9200",
            indexFormat: "myapp-logs-{0:yyyy.MM.dd}",
            templateName: "myapp-logs-template",
            autoRegisterTemplate: true,
            autoRegisterTemplateVersion: AutoRegisterTemplateVersion.ESv8,
            numberOfShards: 3,
            numberOfReplicas: 1,
            batchPostingLimit: 100,
            period: 5,
            connectionTimeout: 10,
            queueSizeLimit: 50000,
            emitEventFailure: EmitEventFailureHandling.WriteToSelfLog,
            bufferBaseFilename: "logs/elasticsearch-buffer",
            bufferFileSizeLimitBytes: 104857600,
            bufferFileCountLimit: 10,
            bufferLogShippingInterval: 2000,
            connectionGlobalHeaders: "Authorization=Bearer your-token,Content-Type=application/json",
            disableServerCertificateValidation: false,
            deadLetterIndexName: "failed-logs",
            singleEventSizePostingLimit: 1048576,
            templateCustomSettings: new Dictionary<string, string>
            {
                {"index.refresh_interval", "30s"},
                {"index.max_result_window", "10000"}
            },
            batchAction: ElasticOpType.Index,
            detectElasticsearchVersion: true
        );
});

var app = builder.Build();
app.Run();
```

### 3. تنظیمات در appsettings.json

```json
{
  "Serilog": {
    "Using": ["Serilog.Sinks.Console", "Zamin.Utilities.Sinks.Elasticsearch"],
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
        "Name": "ZaminElasticsearch",
        "Args": {
          "nodeUris": "http://localhost:9200",
          "indexFormat": "myapp-logs-{0:yyyy.MM.dd}",
          "templateName": "myapp-logs-template",
          "autoRegisterTemplate": true,
          "autoRegisterTemplateVersion": "ESv8",
          "numberOfShards": 1,
          "numberOfReplicas": 0,
          "batchPostingLimit": 50,
          "period": 2,
          "connectionTimeout": 5,
          "queueSizeLimit": 100000,
          "emitEventFailure": "WriteToSelfLog",
          "bufferBaseFilename": "logs/elasticsearch-buffer",
          "bufferFileSizeLimitBytes": 104857600,
          "bufferFileCountLimit": 10,
          "bufferLogShippingInterval": 5000,
          "connectionGlobalHeaders": "Authorization=Bearer your-token,Content-Type=application/json",
          "disableServerCertificateValidation": false,
          "deadLetterIndexName": "failed-logs",
          "singleEventSizePostingLimit": 1048576,
          "templateCustomSettings": {
            "index.refresh_interval": "30s",
            "index.max_result_window": "10000"
          },
          "batchAction": "Index",
          "detectElasticsearchVersion": true
        }
      }
    ]
  }
}
```

### 4. استفاده در کنترلر

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
        _logger.LogInformation("Getting all users from Elasticsearch");
        
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

### 5. تنظیمات برای محیط‌های مختلف

#### Development
```csharp
.WriteTo.ZaminElasticsearch(
    nodeUris: "http://localhost:9200",
    indexFormat: "dev-logs-{0:yyyy.MM.dd}",
    autoRegisterTemplate: true,
    disableServerCertificateValidation: true
)
```

#### Production
```csharp
.WriteTo.ZaminElasticsearch(
    nodeUris: "https://elasticsearch.prod.com:9200",
    indexFormat: "prod-logs-{0:yyyy.MM.dd}",
    templateName: "prod-logs-template",
    autoRegisterTemplate: true,
    numberOfShards: 3,
    numberOfReplicas: 1,
    connectionGlobalHeaders: "Authorization=Bearer prod-token",
    disableServerCertificateValidation: false,
    bufferBaseFilename: "logs/elasticsearch-buffer",
    bufferFileSizeLimitBytes: 1048576000, // 1GB
    deadLetterIndexName: "prod-failed-logs"
)
```

## 🔍 نکات مهم

### بهترین روش‌ها:
- از چندین Node برای High Availability استفاده کنید
- Template های مناسب برای Index تعریف کنید
- Buffer را برای بهبود قابلیت اطمینان فعال کنید
- از Dead Letter Index برای لاگ‌های ناموفق استفاده کنید

### عملکرد:
- Batch Size را بر اساس حجم لاگ‌ها تنظیم کنید
- تعداد Shard و Replica را بر اساس نیاز تنظیم کنید
- از Connection Pooling استفاده کنید

### امنیت:
- از HTTPS برای اتصال استفاده کنید
- از Authentication مناسب استفاده کنید
- گواهی‌های SSL را در Production اعتبارسنجی کنید

## 📚 وابستگی‌ها

- **Serilog.AspNetCore** (8.0.3) - برای ASP.NET Core Integration
- **Serilog.Sinks.Elasticsearch** (10.0.0) - برای Elasticsearch Sink

## 🤝 مشارکت

برای گزارش باگ یا درخواست ویژگی جدید، لطفاً با تیم توسعه تماس بگیرید.

## 📄 مجوز

این پکیج تحت مجوز اختصاصی تیم Zamin منتشر شده است.
