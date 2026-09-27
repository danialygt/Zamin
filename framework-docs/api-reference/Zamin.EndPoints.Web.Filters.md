# Zamin.EndPoints.Web.Filters

مرجع API برای namespace `Zamin.EndPoints.Web.Filters`.

- **Type count (this file):** 5

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.EndPoints.Web.Filters.CamelCaseJsonAttribute`

- **Kind:** `class`
- **Base / interfaces:** `Attribute`
- **Source:** `Onion/src/4.EndPoints/Zamin.EndPoints.Web/Filters/CamelCaseJsonAttribute.cs`

کلاس «CamelCaseJsonAttribute» در namespace Zamin.EndPoints.Web.Filters. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین. ارث‌بری/پیاده‌سازی: Attribute. اتریبیوت‌ها: AttributeUsage(AttributeTargets.Method). مرتبط: Attribute.

_اعضای عمومی مستندسازی‌شده در این خروجی وجود ندارد یا استخراج نشده است._

### `Zamin.EndPoints.Web.Filters.CamelCaseJsonFilter`

- **Kind:** `class`
- **Base / interfaces:** `IAsyncResultFilter`
- **Source:** `Onion/src/4.EndPoints/Zamin.EndPoints.Web/Filters/CamelCaseJsonAttribute.cs`

کلاس «CamelCaseJsonFilter» در namespace Zamin.EndPoints.Web.Filters. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین. ارث‌بری/پیاده‌سازی: IAsyncResultFilter. مرتبط: IAsyncResultFilter.

#### Members

##### `OnResultExecutionAsync` (method)

```csharp
public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
```

متد «OnResultExecutionAsync» در CamelCaseJsonFilter. در چرخه فیلتر MVC/Minimal API اجرا می‌شود و خروجی/درخواست را تنظیم می‌کند. به‌صورت ناهمگام اجرا می‌شود.
پارامترها:
- context (ResultExecutingContext): ورودی از نوع ResultExecutingContext.
- next (ResultExecutionDelegate): ورودی از نوع ResultExecutionDelegate.

مقدار بازگشتی: `Task` — عملیات ناهمگام بدون نتیجه داده‌ای.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
انواع مرتبط: IAsyncResultFilter

### `Zamin.EndPoints.Web.Filters.PascalCaseJsonAttribute`

- **Kind:** `class`
- **Base / interfaces:** `Attribute`
- **Source:** `Onion/src/4.EndPoints/Zamin.EndPoints.Web/Filters/PascalCaseJsonAttribute.cs`

کلاس «PascalCaseJsonAttribute» در namespace Zamin.EndPoints.Web.Filters. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین. ارث‌بری/پیاده‌سازی: Attribute. اتریبیوت‌ها: AttributeUsage(AttributeTargets.Method). مرتبط: Attribute.

_اعضای عمومی مستندسازی‌شده در این خروجی وجود ندارد یا استخراج نشده است._

### `Zamin.EndPoints.Web.Filters.PascalCaseJsonFilter`

- **Kind:** `class`
- **Base / interfaces:** `IAsyncResultFilter`
- **Source:** `Onion/src/4.EndPoints/Zamin.EndPoints.Web/Filters/PascalCaseJsonAttribute.cs`

کلاس «PascalCaseJsonFilter» در namespace Zamin.EndPoints.Web.Filters. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین. ارث‌بری/پیاده‌سازی: IAsyncResultFilter. مرتبط: IAsyncResultFilter.

#### Members

##### `OnResultExecutionAsync` (method)

```csharp
public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
```

متد «OnResultExecutionAsync» در PascalCaseJsonFilter. در چرخه فیلتر MVC/Minimal API اجرا می‌شود و خروجی/درخواست را تنظیم می‌کند. به‌صورت ناهمگام اجرا می‌شود.
پارامترها:
- context (ResultExecutingContext): ورودی از نوع ResultExecutingContext.
- next (ResultExecutionDelegate): ورودی از نوع ResultExecutionDelegate.

مقدار بازگشتی: `Task` — عملیات ناهمگام بدون نتیجه داده‌ای.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
انواع مرتبط: IAsyncResultFilter

### `Zamin.EndPoints.Web.Filters.ValidateModelStateAttribute`

- **Kind:** `class`
- **Base / interfaces:** `ActionFilterAttribute`
- **Source:** `Onion/src/4.EndPoints/Zamin.EndPoints.Web/Filters/ValidateModelStateAttribute.cs`

کلاس «ValidateModelStateAttribute» در namespace Zamin.EndPoints.Web.Filters. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین. ارث‌بری/پیاده‌سازی: ActionFilterAttribute. مرتبط: ActionFilterAttribute.

#### Members

##### `OnActionExecuting` (method)

```csharp
public override void OnActionExecuting(ActionExecutingContext context)
```

متد «OnActionExecuting» در ValidateModelStateAttribute. در چرخه فیلتر MVC/Minimal API اجرا می‌شود و خروجی/درخواست را تنظیم می‌کند.
پارامترها:
- context (ActionExecutingContext): ورودی از نوع ActionExecutingContext.

مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
انواع مرتبط: ActionFilterAttribute
