# Zamin.Utilities.SerilogRegistration.Enrichers

مرجع API برای namespace `Zamin.Utilities.SerilogRegistration.Enrichers`.

- **Type count (this file):** 2

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Utilities.SerilogRegistration.Enrichers.ZaminApplicaitonEnricher`

- **Kind:** `class`
- **Base / interfaces:** `ILogEventEnricher`
- **Source:** `Utilities/SerilogRegistration/Zamin.Utilities.SerilogRegistration/Enrichers/ZaminApplicaitonEnricher.cs`

کلاس «ZaminApplicaitonEnricher» در namespace Zamin.Utilities.SerilogRegistration.Enrichers. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین. ارث‌بری/پیاده‌سازی: ILogEventEnricher. وابستگی‌های سازنده (DI): IOptions<SerilogApplicationEnricherOptions> options. مرتبط: ILogEventEnricher | DI: IOptions<SerilogApplicationEnricherOptions> options.

#### Members

##### `.ctor` (constructor)

```csharp
public ZaminApplicaitonEnricher(IOptions<SerilogApplicationEnricherOptions> options)
```

سازنده ZaminApplicaitonEnricher. پارامترها از طریق تزریق وابستگی تأمین می‌شوند. پارامترها:
- options (IOptions<SerilogApplicationEnricherOptions>): گزینه‌های typed تنظیمات.
پیش‌شرط: وابستگی‌ها/مقادیر ورودی باید معتبر باشند تا فیلدهای داخلی به‌درستی مقداردهی شوند.

##### `Enrich` (method)

```csharp
public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
```

متد «Enrich» در ZaminApplicaitonEnricher. اطلاعات کمکی را به رویداد لاگ اضافه می‌کند.
پارامترها:
- logEvent (LogEvent): رویداد دامنه/پیام برای پردازش.
- propertyFactory (ILogEventPropertyFactory): رویداد دامنه/پیام برای پردازش.

مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: ILogEventEnricher | DI: IOptions<SerilogApplicationEnricherOptions> options

### `Zamin.Utilities.SerilogRegistration.Enrichers.ZaminUserInfoEnricher`

- **Kind:** `class`
- **Base / interfaces:** `ILogEventEnricher`
- **Source:** `Utilities/SerilogRegistration/Zamin.Utilities.SerilogRegistration/Enrichers/ZaminUserInfoEnricher.cs`

کلاس «ZaminUserInfoEnricher» در namespace Zamin.Utilities.SerilogRegistration.Enrichers. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین. ارث‌بری/پیاده‌سازی: ILogEventEnricher. وابستگی‌های سازنده (DI): IUserInfoService userInfoService. مرتبط: ILogEventEnricher | DI: IUserInfoService userInfoService.

#### Members

##### `.ctor` (constructor)

```csharp
public ZaminUserInfoEnricher(IUserInfoService userInfoService)
```

سازنده ZaminUserInfoEnricher. پارامترها از طریق تزریق وابستگی تأمین می‌شوند. پارامترها:
- userInfoService (IUserInfoService): ورودی از نوع IUserInfoService.
پیش‌شرط: وابستگی‌ها/مقادیر ورودی باید معتبر باشند تا فیلدهای داخلی به‌درستی مقداردهی شوند.

##### `Enrich` (method)

```csharp
public void Enrich(LogEvent logEvent, ILogEventPropertyFactory factory)
```

متد «Enrich» در ZaminUserInfoEnricher. اطلاعات کمکی را به رویداد لاگ اضافه می‌کند.
پارامترها:
- logEvent (LogEvent): رویداد دامنه/پیام برای پردازش.
- factory (ILogEventPropertyFactory): رویداد دامنه/پیام برای پردازش.

مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: ILogEventEnricher | DI: IUserInfoService userInfoService
