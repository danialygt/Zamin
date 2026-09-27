# Zamin.Extensions.DependencyInjection.Extensions.DependencyInjection

مرجع API برای namespace `Zamin.Extensions.DependencyInjection.Extensions.DependencyInjection`.

- **Type count (this file):** 1

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Extensions.DependencyInjection.Extensions.DependencyInjection.DependencyInjectionServiceCollectionExtensions`

- **Kind:** `class`
- **Source:** `Extentsions/DependencyInjection/Zamin.Extensions.DependencyInjection/Zamin.Extensions.DependencyInjection/Extensions/DependencyInjection/DependencyInjectionServiceCollectionExtensions.cs`

کلاس «DependencyInjectionServiceCollectionExtensions» در namespace Zamin.Extensions.DependencyInjection.Extensions.DependencyInjection. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

#### Members

##### `AddCustomeDepenecies` (method)

```csharp
public static IServiceCollection AddCustomeDepenecies(this IServiceCollection services, IConfiguration configuration)
```

متد «AddCustomeDepenecies» در DependencyInjectionServiceCollectionExtensions. سرویس‌ها/قابلیت مرتبط را به IServiceCollection ثبت می‌کند. گزینه‌های تنظیمات را Configure می‌کند.
پارامترها:
- services (IServiceCollection): مجموعه سرویس‌های DI که باید گسترش یابد.
- configuration (IConfiguration): پیکربندی برنامه برای خواندن تنظیمات.

مقدار بازگشتی: `IServiceCollection`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `AddCustomeDepenecies` (method)

```csharp
public static IServiceCollection AddCustomeDepenecies(this IServiceCollection services, IConfiguration configuration, string sectionName)
```

متد «AddCustomeDepenecies» در DependencyInjectionServiceCollectionExtensions. سرویس‌ها/قابلیت مرتبط را به IServiceCollection ثبت می‌کند.
پارامترها:
- services (IServiceCollection): مجموعه سرویس‌های DI که باید گسترش یابد.
- configuration (IConfiguration): پیکربندی برنامه برای خواندن تنظیمات.
- sectionName (string): ورودی از نوع string.

مقدار بازگشتی: `IServiceCollection`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `AddCustomeDepenecies` (method)

```csharp
public static IServiceCollection AddCustomeDepenecies(this IServiceCollection services, Action<DependencyInjectionOption> setupAction)
```

متد «AddCustomeDepenecies» در DependencyInjectionServiceCollectionExtensions. سرویس‌ها/قابلیت مرتبط را به IServiceCollection ثبت می‌کند. گزینه‌های تنظیمات را Configure می‌کند.
پارامترها:
- services (IServiceCollection): مجموعه سرویس‌های DI که باید گسترش یابد.
- setupAction (Action<DependencyInjectionOption>): ورودی از نوع Action<DependencyInjectionOption>.

مقدار بازگشتی: `IServiceCollection`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
