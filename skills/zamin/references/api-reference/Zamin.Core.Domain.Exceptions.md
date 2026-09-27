# Zamin.Core.Domain.Exceptions

مرجع API برای namespace `Zamin.Core.Domain.Exceptions`.

- **Type count (this file):** 3

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Core.Domain.Exceptions.DomainStateException`

- **Kind:** `class`
- **Base / interfaces:** `Exception`
- **Source:** `Onion/src/2.Core/Zamin.Core.Domain/Exceptions/DomainStateException.cs`

خطاهای لایه Domain مربوط به Entityها و ValueObjectها به کمک Extention برای لایه‌های بالاتر ارسال می‌شود با توجه به اینکه هم Entity و هم ValueObject به یک شکل خطا را ارسال می‌کنند یک کلاس Exception طراحی و پیاده سازی شده است. برای اینکه در لایه‌های بالاتر بتوان تفاوت خطای و محل رخداد آن را تشخیص داد از الگوی MicroType استفاده شده.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/common-recipes.md#recipe-domain-exceptions)

#### Members

##### `Parameters` (property)

```csharp
public string[] Parameters { get; set; }
```

لیست پارامتر‌های خطا در صورتی که پارامتری وجود داشته باشد message را به صورت الگو ارسال کرده و مقادیر پارامتر‌ها در محل مخصوص در الگو قرار می‌گیرند.

##### `.ctor` (constructor)

```csharp
public DomainStateException(string message, params string[] parameters)
```

سازنده DomainStateException. برای ایجاد نمونه با مقادیر اولیه‌ی مشخص. پارامترها:
- message (string): پیام متنی خطا یا توضیح نقض شرط.

##### `ToString` (method)

```csharp
public override string ToString()
```

متد «ToString» در DomainStateException. بخشی از قرارداد برابری/نمایش شیء را پیاده می‌کند.
بدون پارامتر ورودی.
مقدار بازگشتی: `string`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: Exception | DI: string message, string[] parameters

### `Zamin.Core.Domain.Exceptions.InvalidEntityStateException`

- **Kind:** `class`
- **Base / interfaces:** `DomainStateException`
- **Source:** `Onion/src/2.Core/Zamin.Core.Domain/Exceptions/InvalidEntityStateException.cs`

کلاس «InvalidEntityStateException» در namespace Zamin.Core.Domain.Exceptions. موجودیت دامنه با هویت و قابلیت auditable. ارث‌بری/پیاده‌سازی: DomainStateException. وابستگی‌های سازنده (DI): string message, string[] parameters. مرتبط: DomainStateException (same namespace) | DI: string message, string[] parameters.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/common-recipes.md#recipe-domain-exceptions)

#### Members

##### `.ctor` (constructor)

```csharp
public InvalidEntityStateException(string message, params string[] parameters)
```

خطا‌های مربوط به وضعیت ناصحیح در Entity ها توسط این کلاس ارسال می‌شود
پارامترها:
- message: پیام یا الگوی پیام خطا
- parameters: پارامتر‌ها که در صورت وجود در الگوی پیام جایگذاری می‌شوند

### `Zamin.Core.Domain.Exceptions.InvalidValueObjectStateException`

- **Kind:** `class`
- **Base / interfaces:** `DomainStateException`
- **Source:** `Onion/src/2.Core/Zamin.Core.Domain/Exceptions/InvalidValueObjectStateException.cs`

خطا‌های مربوط به وضعیت ناصحیح در ValueObject ها توسط این کلاس ارسال می‌شود
پارامترها:
- message: پیام یا الگوی پیام خطا
- parameters: پارامتر‌ها که در صورت وجود در الگوی پیام جایگذاری می‌شوند

- **Recipe:** [الگوی استفاده مرتبط](../patterns/common-recipes.md#recipe-domain-exceptions)

#### Members

##### `.ctor` (constructor)

```csharp
public InvalidValueObjectStateException(string message, params string[] parameters)
```

سازنده InvalidValueObjectStateException. برای ایجاد نمونه با مقادیر اولیه‌ی مشخص. پارامترها:
- message (string): پیام متنی خطا یا توضیح نقض شرط.
