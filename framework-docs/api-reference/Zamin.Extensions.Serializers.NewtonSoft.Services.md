# Zamin.Extensions.Serializers.NewtonSoft.Services

مرجع API برای namespace `Zamin.Extensions.Serializers.NewtonSoft.Services`.

- **Type count (this file):** 1

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Extensions.Serializers.NewtonSoft.Services.NewtonSoftSerializer`

- **Kind:** `class`
- **Base / interfaces:** `IJsonSerializer`, `IDisposable`
- **Source:** `Extentsions/Serializers/Zamin.Extensions.Serializers.NewtonSoft/Zamin.Extensions.Serializers.NewtonSoft/Services/NewtonSoftSerializer.cs`

کلاس «NewtonSoftSerializer» در namespace Zamin.Extensions.Serializers.NewtonSoft.Services. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین. ارث‌بری/پیاده‌سازی: IJsonSerializer, IDisposable. وابستگی‌های سازنده (DI): ILogger<NewtonSoftSerializer> logger. مرتبط: IJsonSerializer | IDisposable | DI: ILogger<NewtonSoftSerializer> logger.

#### Members

##### `.ctor` (constructor)

```csharp
public NewtonSoftSerializer(ILogger<NewtonSoftSerializer> logger)
```

سازنده NewtonSoftSerializer. پارامترها از طریق تزریق وابستگی تأمین می‌شوند. پارامترها:
- logger (ILogger<NewtonSoftSerializer>): لاگر برای ثبت رویدادها و خطاها.
پیش‌شرط: وابستگی‌ها/مقادیر ورودی باید معتبر باشند تا فیلدهای داخلی به‌درستی مقداردهی شوند.

##### `Deserialize` (method)

```csharp
public TOutput Deserialize<TOutput>(string input)
```

متد «Deserialize» در NewtonSoftSerializer. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- input (string): مقدار مورد بررسی/ورود.

مقدار بازگشتی: `TOutput`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: IJsonSerializer | IDisposable | DI: ILogger<NewtonSoftSerializer> logger

##### `Deserialize` (method)

```csharp
public object Deserialize(string input, Type type)
```

متد «Deserialize» در NewtonSoftSerializer. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- input (string): مقدار مورد بررسی/ورود.
- type (Type): ورودی از نوع Type.

مقدار بازگشتی: `object`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: IJsonSerializer | IDisposable | DI: ILogger<NewtonSoftSerializer> logger

##### `Serialize` (method)

```csharp
public string Serialize<TInput>(TInput input)
```

متد «Serialize» در NewtonSoftSerializer. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- input (TInput): مقدار مورد بررسی/ورود.

مقدار بازگشتی: `string`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: IJsonSerializer | IDisposable | DI: ILogger<NewtonSoftSerializer> logger

##### `Dispose` (method)

```csharp
public void Dispose()
```

متد «Dispose» در NewtonSoftSerializer. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد. جزئیات اجرا را لاگ می‌کند.
بدون پارامتر ورودی.
مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: IJsonSerializer | IDisposable | DI: ILogger<NewtonSoftSerializer> logger
