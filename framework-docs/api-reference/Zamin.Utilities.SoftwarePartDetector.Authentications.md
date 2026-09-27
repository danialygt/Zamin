# Zamin.Utilities.SoftwarePartDetector.Authentications

مرجع API برای namespace `Zamin.Utilities.SoftwarePartDetector.Authentications`.

- **Type count (this file):** 2

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Utilities.SoftwarePartDetector.Authentications.ISoftwarePartAuthentication`

- **Kind:** `interface`
- **Source:** `Utilities/SoftwarePartDetector/Zamin.Utilities.SoftwarepartDetector/Authentications/ISoftwarePartAuthentication.cs`

قرارداد (اینترفیس) «ISoftwarePartAuthentication» در namespace Zamin.Utilities.SoftwarePartDetector.Authentications. قرارداد رفتار برای مصرف‌کنندگان و پیاده‌سازی‌های جایگزین.

#### Members

##### `LoginAsync` (method)

```csharp
Task<TokenResponse> LoginAsync()
```

متد «LoginAsync» در ISoftwarePartAuthentication. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
بدون پارامتر ورودی.
مقدار بازگشتی: `Task<TokenResponse>` — نتیجه ناهمگام عملیات.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

### `Zamin.Utilities.SoftwarePartDetector.Authentications.SoftwarePartAuthentication`

- **Kind:** `class`
- **Base / interfaces:** `ISoftwarePartAuthentication`
- **Source:** `Utilities/SoftwarePartDetector/Zamin.Utilities.SoftwarepartDetector/Authentications/SoftwarePartAuthentication.cs`

کلاس «SoftwarePartAuthentication» در namespace Zamin.Utilities.SoftwarePartDetector.Authentications. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین. ارث‌بری/پیاده‌سازی: ISoftwarePartAuthentication. وابستگی‌های سازنده (DI): HttpClient httpClient, IOptions<SoftwarePartDetectorOptions> softwarePartDetectorOption. مرتبط: ISoftwarePartAuthentication (same namespace) | DI: HttpClient httpClient, IOptions<SoftwarePartDetectorOptions> softwarePartDetectorOption.

#### Members

##### `.ctor` (constructor)

```csharp
public SoftwarePartAuthentication(HttpClient httpClient, IOptions<SoftwarePartDetectorOptions> softwarePartDetectorOption)
```

سازنده SoftwarePartAuthentication. پارامترها از طریق تزریق وابستگی تأمین می‌شوند. پارامترها:
- httpClient (HttpClient): ورودی از نوع HttpClient.
- softwarePartDetectorOption (IOptions<SoftwarePartDetectorOptions>): گزینه‌های typed تنظیمات.
پیش‌شرط: وابستگی‌ها/مقادیر ورودی باید معتبر باشند تا فیلدهای داخلی به‌درستی مقداردهی شوند.

##### `LoginAsync` (method)

```csharp
public async Task<TokenResponse> LoginAsync()
```

متد «LoginAsync» در SoftwarePartAuthentication. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد. به‌صورت ناهمگام اجرا می‌شود.
بدون پارامتر ورودی.
مقدار بازگشتی: `Task<TokenResponse>` — نتیجه ناهمگام عملیات.
استثناها (قابل تشخیص از کد):
- Exception (throw new)
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: ISoftwarePartAuthentication (same namespace) | DI: HttpClient httpClient, IOptions<SoftwarePartDetectorOptions> softwarePartDetectorOption
