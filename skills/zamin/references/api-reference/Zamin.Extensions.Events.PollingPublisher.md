# Zamin.Extensions.Events.PollingPublisher

مرجع API برای namespace `Zamin.Extensions.Events.PollingPublisher`.

- **Type count (this file):** 1

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Extensions.Events.PollingPublisher.PoolingPublisherBackgroundService`

- **Kind:** `class`
- **Base / interfaces:** `BackgroundService`
- **Source:** `Extentsions/Events/Zamin.Extensions.Events.PollingPublisher/Zamin.Extensions.Events.PollingPublisher/PoolingPublisherBackgroundService.cs`

کلاس «PoolingPublisherBackgroundService» در namespace Zamin.Extensions.Events.PollingPublisher. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین. ارث‌بری/پیاده‌سازی: BackgroundService. وابستگی‌های سازنده (DI): IOutBoxEventItemRepository outBoxEventItemRepository, IOptions<PollingPublisherOptions> options, ILogger<PoolingPublisherBackgroundService> logger, IServiceProvider serviceProvider. مرتبط: BackgroundService | DI: IOutBoxEventItemRepository outBoxEventItemRepository, IOptions<PollingPublisherOptions> options, ILogger<PoolingPublisherBackgroundService> logger, IServiceProvider serviceProvider.

#### Members

##### `.ctor` (constructor)

```csharp
public PoolingPublisherBackgroundService( IOutBoxEventItemRepository outBoxEventItemRepository, IOptions<PollingPublisherOptions> options, ILogger<PoolingPublisherBackgroundService> logger,IServiceProvider serviceProvider)
```

سازنده PoolingPublisherBackgroundService. پارامترها از طریق تزریق وابستگی تأمین می‌شوند. پارامترها:
- outBoxEventItemRepository (IOutBoxEventItemRepository): رویداد دامنه/پیام برای پردازش.
- options (IOptions<PollingPublisherOptions>): گزینه‌های typed تنظیمات.
- logger (ILogger<PoolingPublisherBackgroundService>): لاگر برای ثبت رویدادها و خطاها.
- serviceProvider (IServiceProvider): ارائه‌دهنده سرویس برای resolve کردن وابستگی‌ها.
پیش‌شرط: وابستگی‌ها/مقادیر ورودی باید معتبر باشند تا فیلدهای داخلی به‌درستی مقداردهی شوند.

##### `ExecuteAsync` (method)

```csharp
protected override async Task ExecuteAsync(CancellationToken stoppingToken)
```

متد «ExecuteAsync» در PoolingPublisherBackgroundService. کوئری/عملیات را به handler مناسب مسیریابی و اجرا می‌کند. جزئیات اجرا را لاگ می‌کند. خطاها را در بلوک try/catch مدیریت می‌کند. به‌صورت ناهمگام اجرا می‌شود.
پارامترها:
- stoppingToken (CancellationToken): توکن لغو عملیات ناهمگام.

مقدار بازگشتی: `Task` — عملیات ناهمگام بدون نتیجه داده‌ای.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: BackgroundService | DI: IOutBoxEventItemRepository outBoxEventItemRepository, IOptions<PollingPublisherOptions> options, ILogger<PoolingPublisherBackgroundService> logger, IServiceProvider serviceProvider
