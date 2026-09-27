# Zamin.Extensions.Translations.Parrot.Services

مرجع API برای namespace `Zamin.Extensions.Translations.Parrot.Services`.

- **Type count (this file):** 1

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Extensions.Translations.Parrot.Services.ParrotTranslator`

- **Kind:** `class`
- **Base / interfaces:** `ITranslator`, `IDisposable`
- **Source:** `Extentsions/Translations/Zamin.Extensions.Translations.Parrot/Zamin.Extensions.Translations.Parrot/Services/ParrotTranslator.cs`

کلاس «ParrotTranslator» در namespace Zamin.Extensions.Translations.Parrot.Services. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین. ارث‌بری/پیاده‌سازی: ITranslator, IDisposable. وابستگی‌های سازنده (DI): IOptions<ParrotTranslatorOptions> configuration, ILogger<ParrotTranslator> logger. مرتبط: ITranslator | IDisposable | DI: IOptions<ParrotTranslatorOptions> configuration, ILogger<ParrotTranslator> logger.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/dependency-injection.md#recipe-parrot-translator)

#### Members

##### `.ctor` (constructor)

```csharp
public ParrotTranslator(IOptions<ParrotTranslatorOptions> configuration, ILogger<ParrotTranslator> logger)
```

سازنده ParrotTranslator. پارامترها از طریق تزریق وابستگی تأمین می‌شوند. پارامترها:
- configuration (IOptions<ParrotTranslatorOptions>): گزینه‌های typed تنظیمات.
- logger (ILogger<ParrotTranslator>): لاگر برای ثبت رویدادها و خطاها.
پیش‌شرط: وابستگی‌ها/مقادیر ورودی باید معتبر باشند تا فیلدهای داخلی به‌درستی مقداردهی شوند.

##### `this` (indexer)

```csharp
public string this[string name] { get; set; }
```

ایندکسر «this» در ParrotTranslator. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
بدون پارامتر ورودی.
مقدار بازگشتی: ندارد (void).
استثناها (قابل تشخیص از کد):
- NotImplementedException (throw new)
انواع مرتبط: ITranslator | IDisposable | DI: IOptions<ParrotTranslatorOptions> configuration, ILogger<ParrotTranslator> logger

##### `this` (indexer)

```csharp
public string this[CultureInfo culture, string name ] { get; set; }
```

ایندکسر «this» در ParrotTranslator. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
بدون پارامتر ورودی.
مقدار بازگشتی: ندارد (void).
استثناها (قابل تشخیص از کد):
- NotImplementedException (throw new)
انواع مرتبط: ITranslator | IDisposable | DI: IOptions<ParrotTranslatorOptions> configuration, ILogger<ParrotTranslator> logger

##### `this` (indexer)

```csharp
public string this[string name, params string[] arguments] { get; set; }
```

ایندکسر «this» در ParrotTranslator. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
بدون پارامتر ورودی.
مقدار بازگشتی: ندارد (void).
استثناها (قابل تشخیص از کد):
- NotImplementedException (throw new)
انواع مرتبط: ITranslator | IDisposable | DI: IOptions<ParrotTranslatorOptions> configuration, ILogger<ParrotTranslator> logger

##### `this` (indexer)

```csharp
public string this[CultureInfo culture, string name, params string[] arguments] { get; set; }
```

ایندکسر «this» در ParrotTranslator. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
بدون پارامتر ورودی.
مقدار بازگشتی: ندارد (void).
استثناها (قابل تشخیص از کد):
- NotImplementedException (throw new)
انواع مرتبط: ITranslator | IDisposable | DI: IOptions<ParrotTranslatorOptions> configuration, ILogger<ParrotTranslator> logger

##### `this` (indexer)

```csharp
public string this[char separator, params string[] names] { get; set; }
```

ایندکسر «this» در ParrotTranslator. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
بدون پارامتر ورودی.
مقدار بازگشتی: ندارد (void).
استثناها (قابل تشخیص از کد):
- NotImplementedException (throw new)
انواع مرتبط: ITranslator | IDisposable | DI: IOptions<ParrotTranslatorOptions> configuration, ILogger<ParrotTranslator> logger

##### `this` (indexer)

```csharp
public string this[CultureInfo culture, char separator, params string[] names] { get; set; }
```

ایندکسر «this» در ParrotTranslator. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
بدون پارامتر ورودی.
مقدار بازگشتی: ندارد (void).
استثناها (قابل تشخیص از کد):
- NotImplementedException (throw new)
انواع مرتبط: ITranslator | IDisposable | DI: IOptions<ParrotTranslatorOptions> configuration, ILogger<ParrotTranslator> logger

##### `GetString` (method)

```csharp
public string GetString(string name)
```

متد «GetString» در ParrotTranslator. داده یا وضعیت مرتبط را بازیابی می‌کند.
پارامترها:
- name (string): ورودی از نوع string.

مقدار بازگشتی: `string`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: ITranslator | IDisposable | DI: IOptions<ParrotTranslatorOptions> configuration, ILogger<ParrotTranslator> logger

##### `GetString` (method)

```csharp
public string GetString(CultureInfo culture, string name)
```

متد «GetString» در ParrotTranslator. داده یا وضعیت مرتبط را بازیابی می‌کند.
پارامترها:
- culture (CultureInfo): ورودی از نوع CultureInfo.
- name (string): ورودی از نوع string.

مقدار بازگشتی: `string`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: ITranslator | IDisposable | DI: IOptions<ParrotTranslatorOptions> configuration, ILogger<ParrotTranslator> logger

##### `GetString` (method)

```csharp
public string GetString(string pattern, params string[] arguments)
```

متد «GetString» در ParrotTranslator. داده یا وضعیت مرتبط را بازیابی می‌کند.
پارامترها:
- pattern (string): ورودی از نوع string.

مقدار بازگشتی: `string`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: ITranslator | IDisposable | DI: IOptions<ParrotTranslatorOptions> configuration, ILogger<ParrotTranslator> logger

##### `GetString` (method)

```csharp
public string GetString(CultureInfo culture, string pattern, params string[] arguments)
```

متد «GetString» در ParrotTranslator. داده یا وضعیت مرتبط را بازیابی می‌کند.
پارامترها:
- culture (CultureInfo): ورودی از نوع CultureInfo.
- pattern (string): ورودی از نوع string.

مقدار بازگشتی: `string`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: ITranslator | IDisposable | DI: IOptions<ParrotTranslatorOptions> configuration, ILogger<ParrotTranslator> logger

##### `GetConcateString` (method)

```csharp
public string GetConcateString(char separator = ' ', params string[] names)
```

متد «GetConcateString» در ParrotTranslator. داده یا وضعیت مرتبط را بازیابی می‌کند.
پارامترها:
- separator (char): ورودی اختیاری از نوع char (دارای مقدار پیش‌فرض).

مقدار بازگشتی: `string`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: ITranslator | IDisposable | DI: IOptions<ParrotTranslatorOptions> configuration, ILogger<ParrotTranslator> logger

##### `GetConcateString` (method)

```csharp
public string GetConcateString(CultureInfo culture, char separator = ' ',  params string[] names)
```

متد «GetConcateString» در ParrotTranslator. داده یا وضعیت مرتبط را بازیابی می‌کند.
پارامترها:
- culture (CultureInfo): ورودی از نوع CultureInfo.
- separator (char): ورودی اختیاری از نوع char (دارای مقدار پیش‌فرض).

مقدار بازگشتی: `string`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: ITranslator | IDisposable | DI: IOptions<ParrotTranslatorOptions> configuration, ILogger<ParrotTranslator> logger

##### `Dispose` (method)

```csharp
public void Dispose()
```

متد «Dispose» در ParrotTranslator. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد. جزئیات اجرا را لاگ می‌کند.
بدون پارامتر ورودی.
مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: ITranslator | IDisposable | DI: IOptions<ParrotTranslatorOptions> configuration, ILogger<ParrotTranslator> logger
