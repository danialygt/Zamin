# Zamin.Utilities.SoftwarePartDetector

مرجع API برای namespace `Zamin.Utilities.SoftwarePartDetector`.

- **Type count (this file):** 2

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Utilities.SoftwarePartDetector.ControllersAndActionDetector`

- **Kind:** `class`
- **Source:** `Utilities/SoftwarePartDetector/Zamin.Utilities.SoftwarepartDetector/Detectors/ControllersAndActionDetector.cs`

کلاس «ControllersAndActionDetector» در namespace Zamin.Utilities.SoftwarePartDetector. کنترلر endpoint برای دریافت درخواست HTTP و ارجاع به لایه اپلیکیشن. وابستگی‌های سازنده (DI): IActionDescriptorCollectionProvider actionDescriptorCollectionProvider. مرتبط: DI: IActionDescriptorCollectionProvider actionDescriptorCollectionProvider.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/dependency-injection.md#recipe-software-part-detector)

#### Members

##### `.ctor` (constructor)

```csharp
public ControllersAndActionDetector(IActionDescriptorCollectionProvider actionDescriptorCollectionProvider)
```

سازنده ControllersAndActionDetector. پارامترها از طریق تزریق وابستگی تأمین می‌شوند. پارامترها:
- actionDescriptorCollectionProvider (IActionDescriptorCollectionProvider): ورودی از نوع IActionDescriptorCollectionProvider.
پیش‌شرط: وابستگی‌ها/مقادیر ورودی باید معتبر باشند تا فیلدهای داخلی به‌درستی مقداردهی شوند.

##### `Detect` (method)

```csharp
public Task<List<SoftwarePartController>> Detect()
```

متد «Detect» در ControllersAndActionDetector. اجزای نرم‌افزاری (کنترلر/اکشن و ...) را کشف می‌کند.
بدون پارامتر ورودی.
مقدار بازگشتی: `Task<List<SoftwarePartController>>` — نتیجه ناهمگام عملیات.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: DI: IActionDescriptorCollectionProvider actionDescriptorCollectionProvider

### `Zamin.Utilities.SoftwarePartDetector.SoftwarePartDetector`

- **Kind:** `class`
- **Source:** `Utilities/SoftwarePartDetector/Zamin.Utilities.SoftwarepartDetector/Detectors/SoftwarePartDetector.cs`

کلاس «SoftwarePartDetector» در namespace Zamin.Utilities.SoftwarePartDetector. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین. وابستگی‌های سازنده (DI): ControllersAndActionDetector controllersAndActionDetector. مرتبط: DI: ControllersAndActionDetector controllersAndActionDetector.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/dependency-injection.md#recipe-software-part-detector)

#### Members

##### `.ctor` (constructor)

```csharp
public SoftwarePartDetector(ControllersAndActionDetector controllersAndActionDetector)
```

سازنده SoftwarePartDetector. برای ایجاد نمونه با مقادیر اولیه‌ی مشخص. پارامترها:
- controllersAndActionDetector (ControllersAndActionDetector): ورودی از نوع ControllersAndActionDetector.
پیش‌شرط: وابستگی‌ها/مقادیر ورودی باید معتبر باشند تا فیلدهای داخلی به‌درستی مقداردهی شوند.

##### `Detect` (method)

```csharp
public async Task<SoftwarePart> Detect(string softwareName)
```

متد «Detect» در SoftwarePartDetector. اجزای نرم‌افزاری (کنترلر/اکشن و ...) را کشف می‌کند. به‌صورت ناهمگام اجرا می‌شود.
پارامترها:
- softwareName (string): ورودی از نوع string.

مقدار بازگشتی: `Task<SoftwarePart>` — نتیجه ناهمگام عملیات.
استثناها (قابل تشخیص از کد):
- ArgumentNullException (throw new)
- ArgumentNullException
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: DI: ControllersAndActionDetector controllersAndActionDetector

##### `Detect` (method)

```csharp
public async Task<SoftwarePart> Detect(string softwareName, string moduleName)
```

متد «Detect» در SoftwarePartDetector. اجزای نرم‌افزاری (کنترلر/اکشن و ...) را کشف می‌کند. به‌صورت ناهمگام اجرا می‌شود.
پارامترها:
- softwareName (string): ورودی از نوع string.
- moduleName (string): ورودی از نوع string.

مقدار بازگشتی: `Task<SoftwarePart>` — نتیجه ناهمگام عملیات.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: DI: ControllersAndActionDetector controllersAndActionDetector

##### `Detect` (method)

```csharp
public async Task<SoftwarePart> Detect(string softwareName, string moduleName, string serviceName)
```

متد «Detect» در SoftwarePartDetector. اجزای نرم‌افزاری (کنترلر/اکشن و ...) را کشف می‌کند. به‌صورت ناهمگام اجرا می‌شود.
پارامترها:
- softwareName (string): ورودی از نوع string.
- moduleName (string): ورودی از نوع string.
- serviceName (string): ورودی از نوع string.

مقدار بازگشتی: `Task<SoftwarePart>` — نتیجه ناهمگام عملیات.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: DI: ControllersAndActionDetector controllersAndActionDetector
