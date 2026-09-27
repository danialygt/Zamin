# Zamin.EndPoints.Web.Extensions.ModelBinding

مرجع API برای namespace `Zamin.EndPoints.Web.Extensions.ModelBinding`.

- **Type count (this file):** 1

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.EndPoints.Web.Extensions.ModelBinding.NonValidatingValidatorExtensions`

- **Kind:** `class`
- **Source:** `Onion/src/4.EndPoints/Zamin.EndPoints.Web/Extentions/ModelBinding/AddNonValidateValidator.cs`

کلاس «NonValidatingValidatorExtensions» در namespace Zamin.EndPoints.Web.Extensions.ModelBinding. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/common-recipes.md#recipe-model-binding)

#### Members

##### `AddNonValidatingValidator` (method)

```csharp
public static IServiceCollection AddNonValidatingValidator(this IServiceCollection services)
```

متد «AddNonValidatingValidator» در NonValidatingValidatorExtensions. سرویس‌ها/قابلیت مرتبط را به IServiceCollection ثبت می‌کند.
پارامترها:
- services (IServiceCollection): مجموعه سرویس‌های DI که باید گسترش یابد.

مقدار بازگشتی: `IServiceCollection`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
