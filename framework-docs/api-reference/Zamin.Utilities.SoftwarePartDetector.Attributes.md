# Zamin.Utilities.SoftwarePartDetector.Attributes

مرجع API برای namespace `Zamin.Utilities.SoftwarePartDetector.Attributes`.

- **Type count (this file):** 1

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Utilities.SoftwarePartDetector.Attributes.SoftwarePartControllerOptionAttribute`

- **Kind:** `class`
- **Base / interfaces:** `Attribute`
- **Source:** `Utilities/SoftwarePartDetector/Zamin.Utilities.SoftwarepartDetector/Attributes/SoftwarePartControllerOptionAttribute.cs`

کلاس «SoftwarePartControllerOptionAttribute» در namespace Zamin.Utilities.SoftwarePartDetector.Attributes. کنترلر endpoint برای دریافت درخواست HTTP و ارجاع به لایه اپلیکیشن. ارث‌بری/پیاده‌سازی: Attribute. وابستگی‌های سازنده (DI): string? service, string? module. مرتبط: Attribute | DI: string? service, string? module.

#### Members

##### `.ctor` (constructor)

```csharp
public SoftwarePartControllerOptionAttribute(string? service , string? module = null)
```

سازنده SoftwarePartControllerOptionAttribute. برای ایجاد نمونه با مقادیر اولیه‌ی مشخص. پارامترها:
- service (string?): ورودی از نوع string?.
- module (string?): ورودی اختیاری از نوع string? (دارای مقدار پیش‌فرض).
استثناها (از روی بدنه):
- ArgumentNullException (throw new)
پیش‌شرط: وابستگی‌ها/مقادیر ورودی باید معتبر باشند تا فیلدهای داخلی به‌درستی مقداردهی شوند.

##### `Module` (property)

```csharp
public string? Module => ...
```

پراپرتی «Module» از نوع `string?` در SoftwarePartControllerOptionAttribute. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. منطق دسترسی از روی بدنه accessor قابل مشاهده است.

##### `Service` (property)

```csharp
public string? Service => ...
```

پراپرتی «Service» از نوع `string?` در SoftwarePartControllerOptionAttribute. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. منطق دسترسی از روی بدنه accessor قابل مشاهده است.
