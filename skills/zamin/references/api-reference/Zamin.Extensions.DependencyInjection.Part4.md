# Zamin.Extensions.DependencyInjection (Part 4/7)

مرجع API برای namespace `Zamin.Extensions.DependencyInjection`.

- **Type count (this file):** 4
- **Parts:** [Part 1](./Zamin.Extensions.DependencyInjection.Part1.md) · [Part 2](./Zamin.Extensions.DependencyInjection.Part2.md) · [Part 3](./Zamin.Extensions.DependencyInjection.Part3.md) · **Part 4** · [Part 5](./Zamin.Extensions.DependencyInjection.Part5.md) · [Part 6](./Zamin.Extensions.DependencyInjection.Part6.md) · [Part 7](./Zamin.Extensions.DependencyInjection.Part7.md)

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Extensions.DependencyInjection.MessageInboxServiceCollectionExtensions`

- **Kind:** `class`
- **Source:** `Extentsions/MessageBus/Zamin.Extensions.MessageBus.MessageInbox/Zamin.Extensions.MessageBus.MessageInbox.Dal.Dapper/Extensions/DependencyInjection/MessageInboxServiceCollectionExtensions.cs;Extentsions/MessageBus/Zamin.Extensions.MessageBus.MessageInbox/Zamin.Extensions.MessageBus.MessageInbox/Extensions/DependencyInjection/MessageInboxServiceCollectionExtensions.cs`

کلاس «MessageInboxServiceCollectionExtensions» در namespace Zamin.Extensions.DependencyInjection. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/dependency-injection.md#recipe-add-zamin-api-core)

#### Members

##### `AddZaminMessageInboxDalSql` (method)

```csharp
public static IServiceCollection AddZaminMessageInboxDalSql(this IServiceCollection services, IConfiguration configuration)
```

متد «AddZaminMessageInboxDalSql» در MessageInboxServiceCollectionExtensions. سرویس‌ها/قابلیت مرتبط را به IServiceCollection ثبت می‌کند. گزینه‌های تنظیمات را Configure می‌کند.
پارامترها:
- services (IServiceCollection): مجموعه سرویس‌های DI که باید گسترش یابد.
- configuration (IConfiguration): پیکربندی برنامه برای خواندن تنظیمات.

مقدار بازگشتی: `IServiceCollection`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `AddZaminMessageInboxDalSql` (method)

```csharp
public static IServiceCollection AddZaminMessageInboxDalSql(this IServiceCollection services, IConfiguration configuration, string sectionName)
```

متد «AddZaminMessageInboxDalSql» در MessageInboxServiceCollectionExtensions. سرویس‌ها/قابلیت مرتبط را به IServiceCollection ثبت می‌کند.
پارامترها:
- services (IServiceCollection): مجموعه سرویس‌های DI که باید گسترش یابد.
- configuration (IConfiguration): پیکربندی برنامه برای خواندن تنظیمات.
- sectionName (string): ورودی از نوع string.

مقدار بازگشتی: `IServiceCollection`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `AddZaminMessageInboxDalSql` (method)

```csharp
public static IServiceCollection AddZaminMessageInboxDalSql(this IServiceCollection services, Action<MessageInboxDalDapperOptions> setupAction)
```

متد «AddZaminMessageInboxDalSql» در MessageInboxServiceCollectionExtensions. سرویس‌ها/قابلیت مرتبط را به IServiceCollection ثبت می‌کند. گزینه‌های تنظیمات را Configure می‌کند.
پارامترها:
- services (IServiceCollection): مجموعه سرویس‌های DI که باید گسترش یابد.
- setupAction (Action<MessageInboxDalDapperOptions>): ورودی از نوع Action<MessageInboxDalDapperOptions>.

مقدار بازگشتی: `IServiceCollection`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `AddZaminMessageInbox` (method)

```csharp
public static IServiceCollection AddZaminMessageInbox(this IServiceCollection services, IConfiguration configuration)
```

متد «AddZaminMessageInbox» در MessageInboxServiceCollectionExtensions. سرویس‌ها/قابلیت مرتبط را به IServiceCollection ثبت می‌کند. گزینه‌های تنظیمات را Configure می‌کند.
پارامترها:
- services (IServiceCollection): مجموعه سرویس‌های DI که باید گسترش یابد.
- configuration (IConfiguration): پیکربندی برنامه برای خواندن تنظیمات.

مقدار بازگشتی: `IServiceCollection`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `AddZaminMessageInbox` (method)

```csharp
public static IServiceCollection AddZaminMessageInbox(this IServiceCollection services, IConfiguration configuration, string sectionName)
```

متد «AddZaminMessageInbox» در MessageInboxServiceCollectionExtensions. سرویس‌ها/قابلیت مرتبط را به IServiceCollection ثبت می‌کند.
پارامترها:
- services (IServiceCollection): مجموعه سرویس‌های DI که باید گسترش یابد.
- configuration (IConfiguration): پیکربندی برنامه برای خواندن تنظیمات.
- sectionName (string): ورودی از نوع string.

مقدار بازگشتی: `IServiceCollection`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `AddZaminMessageInbox` (method)

```csharp
public static IServiceCollection AddZaminMessageInbox(this IServiceCollection services, Action<MessageInboxOptions> setupAction)
```

متد «AddZaminMessageInbox» در MessageInboxServiceCollectionExtensions. سرویس‌ها/قابلیت مرتبط را به IServiceCollection ثبت می‌کند. گزینه‌های تنظیمات را Configure می‌کند.
پارامترها:
- services (IServiceCollection): مجموعه سرویس‌های DI که باید گسترش یابد.
- setupAction (Action<MessageInboxOptions>): ورودی از نوع Action<MessageInboxOptions>.

مقدار بازگشتی: `IServiceCollection`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

### `Zamin.Extensions.DependencyInjection.MicrosoftSerializerServiceCollectionExtensions`

- **Kind:** `class`
- **Source:** `Extentsions/Serializers/Zamin.Extensions.Serializers.Microsoft/Zamin.Extensions.Serializers.Microsoft/Extensions/DependencyInjection/MicrosoftSerializerServiceCollectionExtensions.cs`

کلاس «MicrosoftSerializerServiceCollectionExtensions» در namespace Zamin.Extensions.DependencyInjection. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/dependency-injection.md#recipe-add-zamin-api-core)

#### Members

##### `AddZaminMicrosoftSerializer` (method)

```csharp
public static IServiceCollection AddZaminMicrosoftSerializer(this IServiceCollection services)
```

متد «AddZaminMicrosoftSerializer» در MicrosoftSerializerServiceCollectionExtensions. سرویس‌ها/قابلیت مرتبط را به IServiceCollection ثبت می‌کند. سرویس‌ها را با lifetime مشخص در DI ثبت می‌کند.
پارامترها:
- services (IServiceCollection): مجموعه سرویس‌های DI که باید گسترش یابد.

مقدار بازگشتی: `IServiceCollection`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

### `Zamin.Extensions.DependencyInjection.NewtonSoftSerializerServiceCollectionExtensions`

- **Kind:** `class`
- **Source:** `Extentsions/Serializers/Zamin.Extensions.Serializers.NewtonSoft/Zamin.Extensions.Serializers.NewtonSoft/Extensions/DependencyInjection/NewtonSoftSerializerServiceCollectionExtensions.cs`

کلاس «NewtonSoftSerializerServiceCollectionExtensions» در namespace Zamin.Extensions.DependencyInjection. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/dependency-injection.md#recipe-add-zamin-api-core)

#### Members

##### `AddZaminNewtonSoftSerializer` (method)

```csharp
public static IServiceCollection AddZaminNewtonSoftSerializer(this IServiceCollection services)
```

متد «AddZaminNewtonSoftSerializer» در NewtonSoftSerializerServiceCollectionExtensions. سرویس‌ها/قابلیت مرتبط را به IServiceCollection ثبت می‌کند. سرویس‌ها را با lifetime مشخص در DI ثبت می‌کند.
پارامترها:
- services (IServiceCollection): مجموعه سرویس‌های DI که باید گسترش یابد.

مقدار بازگشتی: `IServiceCollection`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

### `Zamin.Extensions.DependencyInjection.ParrotTranslatorServiceCollectionExtensions`

- **Kind:** `class`
- **Source:** `Extentsions/Translations/Zamin.Extensions.Translations.Parrot/Zamin.Extensions.Translations.Parrot/Extensions/DependencyInjection/ParrotTranslatorServiceCollectionExtensions.cs`

کلاس «ParrotTranslatorServiceCollectionExtensions» در namespace Zamin.Extensions.DependencyInjection. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/dependency-injection.md#recipe-add-zamin-api-core)

#### Members

##### `AddZaminParrotTranslator` (method)

```csharp
public static IServiceCollection AddZaminParrotTranslator(this IServiceCollection services, IConfiguration configuration)
```

متد «AddZaminParrotTranslator» در ParrotTranslatorServiceCollectionExtensions. سرویس‌ها/قابلیت مرتبط را به IServiceCollection ثبت می‌کند. گزینه‌های تنظیمات را Configure می‌کند. سرویس‌ها را با lifetime مشخص در DI ثبت می‌کند.
پارامترها:
- services (IServiceCollection): مجموعه سرویس‌های DI که باید گسترش یابد.
- configuration (IConfiguration): پیکربندی برنامه برای خواندن تنظیمات.

مقدار بازگشتی: `IServiceCollection`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `AddZaminParrotTranslator` (method)

```csharp
public static IServiceCollection AddZaminParrotTranslator(this IServiceCollection services, IConfiguration configuration, string sectionName)
```

متد «AddZaminParrotTranslator» در ParrotTranslatorServiceCollectionExtensions. سرویس‌ها/قابلیت مرتبط را به IServiceCollection ثبت می‌کند.
پارامترها:
- services (IServiceCollection): مجموعه سرویس‌های DI که باید گسترش یابد.
- configuration (IConfiguration): پیکربندی برنامه برای خواندن تنظیمات.
- sectionName (string): ورودی از نوع string.

مقدار بازگشتی: `IServiceCollection`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `AddZaminParrotTranslator` (method)

```csharp
public static IServiceCollection AddZaminParrotTranslator(this IServiceCollection services, Action<ParrotTranslatorOptions> setupAction)
```

متد «AddZaminParrotTranslator» در ParrotTranslatorServiceCollectionExtensions. سرویس‌ها/قابلیت مرتبط را به IServiceCollection ثبت می‌کند. گزینه‌های تنظیمات را Configure می‌کند. سرویس‌ها را با lifetime مشخص در DI ثبت می‌کند.
پارامترها:
- services (IServiceCollection): مجموعه سرویس‌های DI که باید گسترش یابد.
- setupAction (Action<ParrotTranslatorOptions>): ورودی از نوع Action<ParrotTranslatorOptions>.

مقدار بازگشتی: `IServiceCollection`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
