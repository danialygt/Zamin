# Zamin.Utilities.SoftwarePartDetector.Services

مرجع API برای namespace `Zamin.Utilities.SoftwarePartDetector.Services`.

- **Type count (this file):** 1

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Utilities.SoftwarePartDetector.Services.SoftwarePartDetectorService`

- **Kind:** `class`
- **Source:** `Utilities/SoftwarePartDetector/Zamin.Utilities.SoftwarepartDetector/Services/SoftwarePartDetectorService.cs`

کلاس «SoftwarePartDetectorService» در namespace Zamin.Utilities.SoftwarePartDetector.Services. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین. وابستگی‌های سازنده (DI): SoftwarePartDetector softwarePartDetector, ISoftwarePartPublisher partWebPublisher, IOptions<SoftwarePartDetectorOptions> softwarePartDetectorOption. مرتبط: DI: SoftwarePartDetector softwarePartDetector, ISoftwarePartPublisher partWebPublisher, IOptions<SoftwarePartDetectorOptions> softwarePartDetectorOption.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/dependency-injection.md#recipe-software-part-detector)

#### Members

##### `.ctor` (constructor)

```csharp
public SoftwarePartDetectorService(SoftwarePartDetector softwarePartDetector,
                                       ISoftwarePartPublisher partWebPublisher,
                                       IOptions<SoftwarePartDetectorOptions> softwarePartDetectorOption)
```

سازنده SoftwarePartDetectorService. پارامترها از طریق تزریق وابستگی تأمین می‌شوند. پارامترها:
- softwarePartDetector (SoftwarePartDetector): ورودی از نوع SoftwarePartDetector.
- partWebPublisher (ISoftwarePartPublisher): ورودی از نوع ISoftwarePartPublisher.
- softwarePartDetectorOption (IOptions<SoftwarePartDetectorOptions>): گزینه‌های typed تنظیمات.
پیش‌شرط: وابستگی‌ها/مقادیر ورودی باید معتبر باشند تا فیلدهای داخلی به‌درستی مقداردهی شوند.

##### `Run` (method)

```csharp
public async Task Run()
```

متد «Run» در SoftwarePartDetectorService. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد. به‌صورت ناهمگام اجرا می‌شود.
بدون پارامتر ورودی.
مقدار بازگشتی: `Task` — عملیات ناهمگام بدون نتیجه داده‌ای.
استثناها (قابل تشخیص از کد):
- ArgumentNullException (throw new)
- ArgumentNullException
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: DI: SoftwarePartDetector softwarePartDetector, ISoftwarePartPublisher partWebPublisher, IOptions<SoftwarePartDetectorOptions> softwarePartDetectorOption
