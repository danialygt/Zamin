# Zamin.EndPoints.Web.ModelBinding

مرجع API برای namespace `Zamin.EndPoints.Web.ModelBinding`.

- **Type count (this file):** 1

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.EndPoints.Web.ModelBinding.NonValidatingValidator`

- **Kind:** `class`
- **Base / interfaces:** `IObjectModelValidator`
- **Source:** `Onion/src/4.EndPoints/Zamin.EndPoints.Web/ModelBinding/NonValidatingValidator.cs`

کلاس «NonValidatingValidator» در namespace Zamin.EndPoints.Web.ModelBinding. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین. ارث‌بری/پیاده‌سازی: IObjectModelValidator. مرتبط: IObjectModelValidator.

#### Members

##### `Validate` (method)

```csharp
public void Validate(ActionContext actionContext, ValidationStateDictionary validationState, string prefix, object model)
```

متد «Validate» در NonValidatingValidator. ورودی را اعتبارسنجی می‌کند.
پارامترها:
- actionContext (ActionContext): ورودی از نوع ActionContext.
- validationState (ValidationStateDictionary): ورودی از نوع ValidationStateDictionary.
- prefix (string): ورودی از نوع string.
- model (object): ورودی از نوع object.

مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
انواع مرتبط: IObjectModelValidator
