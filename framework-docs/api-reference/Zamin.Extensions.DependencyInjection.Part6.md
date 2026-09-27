# Zamin.Extensions.DependencyInjection (Part 6/7)

مرجع API برای namespace `Zamin.Extensions.DependencyInjection`.

- **Type count (this file):** 3
- **Parts:** [Part 1](./Zamin.Extensions.DependencyInjection.Part1.md) · [Part 2](./Zamin.Extensions.DependencyInjection.Part2.md) · [Part 3](./Zamin.Extensions.DependencyInjection.Part3.md) · [Part 4](./Zamin.Extensions.DependencyInjection.Part4.md) · [Part 5](./Zamin.Extensions.DependencyInjection.Part5.md) · **Part 6** · [Part 7](./Zamin.Extensions.DependencyInjection.Part7.md)

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Extensions.DependencyInjection.RabbitMqMessageBusServiceCollectionExtensions`

- **Kind:** `class`
- **Source:** `Extentsions/MessageBus/Zamin.Extensions.MessageBus.RabbitMQ/Zamin.Extensions.MessageBus.RabbitMQ/Extensions/DependencyInjection/RabbitMqMessageBusServiceCollectionExtensions.cs`

کلاس «RabbitMqMessageBusServiceCollectionExtensions» در namespace Zamin.Extensions.DependencyInjection. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/dependency-injection.md#recipe-add-zamin-api-core)

#### Members

##### `AddZaminRabbitMqMessageBus` (method)

```csharp
public static IServiceCollection AddZaminRabbitMqMessageBus(this IServiceCollection services, IConfiguration configuration, List<Type>? commands = null, Dictionary<string, List<Type>>? events = null)
```

متد «AddZaminRabbitMqMessageBus» در RabbitMqMessageBusServiceCollectionExtensions. سرویس‌ها/قابلیت مرتبط را به IServiceCollection ثبت می‌کند. گزینه‌های تنظیمات را Configure می‌کند.
پارامترها:
- services (IServiceCollection): مجموعه سرویس‌های DI که باید گسترش یابد.
- configuration (IConfiguration): پیکربندی برنامه برای خواندن تنظیمات.
- commands (List<Type>?): ورودی اختیاری از نوع List<Type>? (دارای مقدار پیش‌فرض).
- events (Dictionary<string, List<Type>>?): رویداد دامنه/پیام برای پردازش.

مقدار بازگشتی: `IServiceCollection`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `AddZaminRabbitMqMessageBus` (method)

```csharp
public static IServiceCollection AddZaminRabbitMqMessageBus(this IServiceCollection services, IConfiguration configuration, string sectionName, List<Type>? commands = null, Dictionary<string, List<Type>>? events = null)
```

متد «AddZaminRabbitMqMessageBus» در RabbitMqMessageBusServiceCollectionExtensions. سرویس‌ها/قابلیت مرتبط را به IServiceCollection ثبت می‌کند.
پارامترها:
- services (IServiceCollection): مجموعه سرویس‌های DI که باید گسترش یابد.
- configuration (IConfiguration): پیکربندی برنامه برای خواندن تنظیمات.
- sectionName (string): ورودی از نوع string.
- commands (List<Type>?): ورودی اختیاری از نوع List<Type>? (دارای مقدار پیش‌فرض).
- events (Dictionary<string, List<Type>>?): رویداد دامنه/پیام برای پردازش.

مقدار بازگشتی: `IServiceCollection`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `AddZaminRabbitMqMessageBus` (method)

```csharp
public static IServiceCollection AddZaminRabbitMqMessageBus(this IServiceCollection services, Action<RabbitMqOptions> setupAction, List<Type>? commands = null, Dictionary<string, List<Type>>? events = null)
```

متد «AddZaminRabbitMqMessageBus» در RabbitMqMessageBusServiceCollectionExtensions. سرویس‌ها/قابلیت مرتبط را به IServiceCollection ثبت می‌کند. گزینه‌های تنظیمات را Configure می‌کند.
پارامترها:
- services (IServiceCollection): مجموعه سرویس‌های DI که باید گسترش یابد.
- setupAction (Action<RabbitMqOptions>): ورودی از نوع Action<RabbitMqOptions>.
- commands (List<Type>?): ورودی اختیاری از نوع List<Type>? (دارای مقدار پیش‌فرض).
- events (Dictionary<string, List<Type>>?): رویداد دامنه/پیام برای پردازش.

مقدار بازگشتی: `IServiceCollection`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `ReceiveCommandFromRabbitMqMessageBus` (method)

```csharp
public static void ReceiveCommandFromRabbitMqMessageBus(this IServiceProvider serviceProvider, params string[] commands)
```

متد «ReceiveCommandFromRabbitMqMessageBus» در RabbitMqMessageBusServiceCollectionExtensions. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد. handler/سرویس را از DI با GetRequiredService برمی‌دارد.
پارامترها:
- serviceProvider (IServiceProvider): ارائه‌دهنده سرویس برای resolve کردن وابستگی‌ها.

مقدار بازگشتی: ندارد (void).
استثناها (قابل تشخیص از کد):
- ArgumentNullException (throw new)
- ArgumentNullException
پیش‌شرط/وابستگی: سرویس/handler مربوطه باید در DI ثبت شده باشد وگرنه InvalidOperationException رخ می‌دهد

##### `ReceiveEventFromRabbitMqMessageBus` (method)

```csharp
public static void ReceiveEventFromRabbitMqMessageBus(this IServiceProvider serviceProvider, params KeyValuePair<string, string>[] events)
```

متد «ReceiveEventFromRabbitMqMessageBus» در RabbitMqMessageBusServiceCollectionExtensions. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد. handler/سرویس را از DI با GetRequiredService برمی‌دارد.
پارامترها:
- serviceProvider (IServiceProvider): ارائه‌دهنده سرویس برای resolve کردن وابستگی‌ها.
- string>events (KeyValuePair<string,): رویداد دامنه/پیام برای پردازش.

مقدار بازگشتی: ندارد (void).
استثناها (قابل تشخیص از کد):
- ArgumentNullException (throw new)
- ArgumentNullException
پیش‌شرط/وابستگی: سرویس/handler مربوطه باید در DI ثبت شده باشد وگرنه InvalidOperationException رخ می‌دهد

### `Zamin.Extensions.DependencyInjection.ReferenceTokenExtensions`

- **Kind:** `class`
- **Source:** `Utilities/Auth/ApiAuthentication/Zamin.Utilities.Auth.ApiAuthentication/Extensions/ReferenceTokenExtensions.cs`

کلاس «ReferenceTokenExtensions» در namespace Zamin.Extensions.DependencyInjection. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/dependency-injection.md#recipe-add-zamin-api-core)

#### Members

##### `AddReferenceTokenSupoort` (method)

```csharp
public static AuthenticationBuilder AddReferenceTokenSupoort(this AuthenticationBuilder authenticationBuilder,
                                                                 IServiceCollection services,
                                                                 ProviderOption provider)
```

متد «AddReferenceTokenSupoort» در ReferenceTokenExtensions. سرویس‌ها/قابلیت مرتبط را به IServiceCollection ثبت می‌کند. به‌صورت ناهمگام اجرا می‌شود.
پارامترها:
- authenticationBuilder (AuthenticationBuilder): ورودی از نوع AuthenticationBuilder.
- services (IServiceCollection): مجموعه سرویس‌های DI که باید گسترش یابد.
- provider (ProviderOption): ورودی از نوع ProviderOption.

مقدار بازگشتی: `AuthenticationBuilder`.
استثناها (قابل تشخیص از کد):
- ArgumentNullException (throw new)
- ArgumentNullException

### `Zamin.Extensions.DependencyInjection.ScalarServiceCollectionExtensions`

- **Kind:** `class`
- **Source:** `Utilities/ScalarRegistration/Zamin.Utilities.ScalarRegistration/Extensions/DependencyInjection/ScalarServiceCollectionExtensions.cs`

کلاس «ScalarServiceCollectionExtensions» در namespace Zamin.Extensions.DependencyInjection. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/dependency-injection.md#recipe-add-zamin-api-core)

#### Members

##### `AddZaminScalar` (method)

```csharp
public static IServiceCollection AddZaminScalar(this IServiceCollection services, IConfiguration configuration, string sectionName)
```

متد «AddZaminScalar» در ScalarServiceCollectionExtensions. سرویس‌ها/قابلیت مرتبط را به IServiceCollection ثبت می‌کند.
پارامترها:
- services (IServiceCollection): مجموعه سرویس‌های DI که باید گسترش یابد.
- configuration (IConfiguration): پیکربندی برنامه برای خواندن تنظیمات.
- sectionName (string): ورودی از نوع string.

مقدار بازگشتی: `IServiceCollection`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `AddZaminScalar` (method)

```csharp
public static IServiceCollection AddZaminScalar(this IServiceCollection services, IConfiguration configuration)
```

متد «AddZaminScalar» در ScalarServiceCollectionExtensions. سرویس‌ها/قابلیت مرتبط را به IServiceCollection ثبت می‌کند. گزینه‌های تنظیمات را Configure می‌کند.
پارامترها:
- services (IServiceCollection): مجموعه سرویس‌های DI که باید گسترش یابد.
- configuration (IConfiguration): پیکربندی برنامه برای خواندن تنظیمات.

مقدار بازگشتی: `IServiceCollection`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `AddZaminScalar` (method)

```csharp
public static IServiceCollection AddZaminScalar(this IServiceCollection services, Action<ScalarOption> action)
```

متد «AddZaminScalar» در ScalarServiceCollectionExtensions. سرویس‌ها/قابلیت مرتبط را به IServiceCollection ثبت می‌کند. گزینه‌های تنظیمات را Configure می‌کند.
پارامترها:
- services (IServiceCollection): مجموعه سرویس‌های DI که باید گسترش یابد.
- action (Action<ScalarOption>): ورودی از نوع Action<ScalarOption>.

مقدار بازگشتی: `IServiceCollection`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `UseZaminScalar` (method)

```csharp
public static void UseZaminScalar(this WebApplication app)
```

متد «UseZaminScalar» در ScalarServiceCollectionExtensions. میان‌افزار یا پیکربندی pipeline را به اپلیکیشن اضافه می‌کند. handler/سرویس را از DI با GetRequiredService برمی‌دارد.
پارامترها:
- app (WebApplication): ورودی از نوع WebApplication.

مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: سرویس/handler مربوطه باید در DI ثبت شده باشد وگرنه InvalidOperationException رخ می‌دهد
