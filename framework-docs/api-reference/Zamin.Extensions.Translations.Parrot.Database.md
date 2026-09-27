# Zamin.Extensions.Translations.Parrot.Database

مرجع API برای namespace `Zamin.Extensions.Translations.Parrot.Database`.

- **Type count (this file):** 1

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Extensions.Translations.Parrot.Database.ParrotSqlRepository`

- **Kind:** `class`
- **Source:** `Extentsions/Translations/Zamin.Extensions.Translations.Parrot/Zamin.Extensions.Translations.Parrot/Database/ParrotSqlRepository.cs`

کلاس «ParrotSqlRepository» در namespace Zamin.Extensions.Translations.Parrot.Database. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین. وابستگی‌های سازنده (DI): ParrotTranslatorOptions configuration, ILogger logger. مرتبط: DI: ParrotTranslatorOptions configuration, ILogger logger.

#### Members

##### `.ctor` (constructor)

```csharp
public ParrotSqlRepository(ParrotTranslatorOptions configuration,
                               ILogger logger)
```

سازنده ParrotSqlRepository. پارامترها از طریق تزریق وابستگی تأمین می‌شوند. پارامترها:
- configuration (ParrotTranslatorOptions): ورودی از نوع ParrotTranslatorOptions.
- logger (ILogger): لاگر برای ثبت رویدادها و خطاها.
پیش‌شرط: وابستگی‌ها/مقادیر ورودی باید معتبر باشند تا فیلدهای داخلی به‌درستی مقداردهی شوند.

##### `Get` (method)

```csharp
public string Get(string key, string culture)
```

متد «Get» در ParrotSqlRepository. داده یا وضعیت مرتبط را بازیابی می‌کند. جزئیات اجرا را لاگ می‌کند. خطاها را در بلوک try/catch مدیریت می‌کند.
پارامترها:
- key (string): ورودی از نوع string.
- culture (string): ورودی از نوع string.

مقدار بازگشتی: `string`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: DI: ParrotTranslatorOptions configuration, ILogger logger
