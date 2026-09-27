# Zamin.Utilities.SoftwarePartDetector.Publishers

مرجع API برای namespace `Zamin.Utilities.SoftwarePartDetector.Publishers`.

- **Type count (this file):** 2

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Utilities.SoftwarePartDetector.Publishers.ISoftwarePartPublisher`

- **Kind:** `interface`
- **Source:** `Utilities/SoftwarePartDetector/Zamin.Utilities.SoftwarepartDetector/Publishers/ISoftwarePartWebPublisher.cs`

قرارداد (اینترفیس) «ISoftwarePartPublisher» در namespace Zamin.Utilities.SoftwarePartDetector.Publishers. قرارداد رفتار برای مصرف‌کنندگان و پیاده‌سازی‌های جایگزین.

#### Members

##### `PublishAsync` (method)

```csharp
Task PublishAsync(SoftwarePart softwarePart)
```

متد «PublishAsync» در ISoftwarePartPublisher. رویداد/پیام را منتشر می‌کند.
پارامترها:
- softwarePart (SoftwarePart): ورودی از نوع SoftwarePart.

مقدار بازگشتی: `Task` — عملیات ناهمگام بدون نتیجه داده‌ای.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

### `Zamin.Utilities.SoftwarePartDetector.Publishers.SoftwarePartWebPublisher`

- **Kind:** `class`
- **Base / interfaces:** `ISoftwarePartPublisher`
- **Source:** `Utilities/SoftwarePartDetector/Zamin.Utilities.SoftwarepartDetector/Publishers/SoftwarePartWebPublisher.cs`

کلاس «SoftwarePartWebPublisher» در namespace Zamin.Utilities.SoftwarePartDetector.Publishers. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین. ارث‌بری/پیاده‌سازی: ISoftwarePartPublisher. وابستگی‌های سازنده (DI): HttpClient httpClient, IOptions<SoftwarePartDetectorOptions> softwarePartDetectorOption, ISoftwarePartAuthentication softwarePartLogin, IJsonSerializer jsonSerializer. مرتبط: ISoftwarePartPublisher (same namespace) | DI: HttpClient httpClient, IOptions<SoftwarePartDetectorOptions> softwarePartDetectorOption, ISoftwarePartAuthentication softwarePartLogin, IJsonSerializer jsonSerializer.

#### Members

##### `.ctor` (constructor)

```csharp
public SoftwarePartWebPublisher(HttpClient httpClient,
                                    IOptions<SoftwarePartDetectorOptions> softwarePartDetectorOption,
                                    ISoftwarePartAuthentication softwarePartLogin,
                                    IJsonSerializer jsonSerializer)
```

سازنده SoftwarePartWebPublisher. پارامترها از طریق تزریق وابستگی تأمین می‌شوند. پارامترها:
- httpClient (HttpClient): ورودی از نوع HttpClient.
- softwarePartDetectorOption (IOptions<SoftwarePartDetectorOptions>): گزینه‌های typed تنظیمات.
- softwarePartLogin (ISoftwarePartAuthentication): ورودی از نوع ISoftwarePartAuthentication.
- jsonSerializer (IJsonSerializer): ورودی از نوع IJsonSerializer.
پیش‌شرط: وابستگی‌ها/مقادیر ورودی باید معتبر باشند تا فیلدهای داخلی به‌درستی مقداردهی شوند.

##### `PublishAsync` (method)

```csharp
public async Task PublishAsync(SoftwarePart softwarePart)
```

متد «PublishAsync» در SoftwarePartWebPublisher. رویداد/پیام را منتشر می‌کند. به‌صورت ناهمگام اجرا می‌شود.
پارامترها:
- softwarePart (SoftwarePart): ورودی از نوع SoftwarePart.

مقدار بازگشتی: `Task` — عملیات ناهمگام بدون نتیجه داده‌ای.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: ISoftwarePartPublisher (same namespace) | DI: HttpClient httpClient, IOptions<SoftwarePartDetectorOptions> softwarePartDetectorOption, ISoftwarePartAuthentication softwarePartLogin, IJsonSerializer jsonSerializer
