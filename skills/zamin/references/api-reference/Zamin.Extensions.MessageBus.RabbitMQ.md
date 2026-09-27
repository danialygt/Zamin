# Zamin.Extensions.MessageBus.RabbitMQ

مرجع API برای namespace `Zamin.Extensions.MessageBus.RabbitMQ`.

- **Type count (this file):** 3

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Extensions.MessageBus.RabbitMQ.RabbitMqReceiveMessageBus`

- **Kind:** `class`
- **Base / interfaces:** `IReceiveMessageBus`, `IDisposable`
- **Source:** `Extentsions/MessageBus/Zamin.Extensions.MessageBus.RabbitMQ/Zamin.Extensions.MessageBus.RabbitMQ/RabbitMqReceiveMessageBus.cs`

کلاس «RabbitMqReceiveMessageBus» در namespace Zamin.Extensions.MessageBus.RabbitMQ. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین. ارث‌بری/پیاده‌سازی: IReceiveMessageBus, IDisposable. وابستگی‌های سازنده (DI): IConnection connection, ILogger<RabbitMqReceiveMessageBus> logger, IOptions<RabbitMqOptions> rabbitMqOptions, IServiceScopeFactory serviceScopeFactory. مرتبط: IReceiveMessageBus | IDisposable | DI: IConnection connection, ILogger<RabbitMqReceiveMessageBus> logger, IOptions<RabbitMqOptions> rabbitMqOptions, IServiceScopeFactory serviceScopeFactory.

#### Members

##### `.ctor` (constructor)

```csharp
public RabbitMqReceiveMessageBus(IConnection connection,
                                     ILogger<RabbitMqReceiveMessageBus> logger,
                                     IOptions<RabbitMqOptions> rabbitMqOptions,
                                     IServiceScopeFactory serviceScopeFactory)
```

سازنده RabbitMqReceiveMessageBus. پارامترها از طریق تزریق وابستگی تأمین می‌شوند. پارامترها:
- connection (IConnection): ورودی از نوع IConnection.
- logger (ILogger<RabbitMqReceiveMessageBus>): لاگر برای ثبت رویدادها و خطاها.
- rabbitMqOptions (IOptions<RabbitMqOptions>): گزینه‌های typed تنظیمات.
- serviceScopeFactory (IServiceScopeFactory): ورودی از نوع IServiceScopeFactory.
پیش‌شرط: وابستگی‌ها/مقادیر ورودی باید معتبر باشند تا فیلدهای داخلی به‌درستی مقداردهی شوند.

##### `Subscribe` (method)

```csharp
public void Subscribe(string serviceId, string eventName)
```

متد «Subscribe» در RabbitMqReceiveMessageBus. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد. جزئیات اجرا را لاگ می‌کند.
پارامترها:
- serviceId (string): ورودی از نوع string.
- eventName (string): رویداد دامنه/پیام برای پردازش.

مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: IReceiveMessageBus | IDisposable | DI: IConnection connection, ILogger<RabbitMqReceiveMessageBus> logger, IOptions<RabbitMqOptions> rabbitMqOptions, IServiceScopeFactory serviceScopeFactory

##### `Receive` (method)

```csharp
public void Receive(string commandName)
```

متد «Receive» در RabbitMqReceiveMessageBus. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد. جزئیات اجرا را لاگ می‌کند.
پارامترها:
- commandName (string): ورودی از نوع string.

مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: IReceiveMessageBus | IDisposable | DI: IConnection connection, ILogger<RabbitMqReceiveMessageBus> logger, IOptions<RabbitMqOptions> rabbitMqOptions, IServiceScopeFactory serviceScopeFactory

##### `Dispose` (method)

```csharp
public void Dispose()
```

متد «Dispose» در RabbitMqReceiveMessageBus. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
بدون پارامتر ورودی.
مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: IReceiveMessageBus | IDisposable | DI: IConnection connection, ILogger<RabbitMqReceiveMessageBus> logger, IOptions<RabbitMqOptions> rabbitMqOptions, IServiceScopeFactory serviceScopeFactory

### `Zamin.Extensions.MessageBus.RabbitMQ.RabbitMqSendMessageBus`

- **Kind:** `class`
- **Base / interfaces:** `IDisposable`, `ISendMessageBus`
- **Source:** `Extentsions/MessageBus/Zamin.Extensions.MessageBus.RabbitMQ/Zamin.Extensions.MessageBus.RabbitMQ/RabbitMqSendMessageBus.cs`

کلاس «RabbitMqSendMessageBus» در namespace Zamin.Extensions.MessageBus.RabbitMQ. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین. ارث‌بری/پیاده‌سازی: IDisposable, ISendMessageBus. وابستگی‌های سازنده (DI): IConnection connection, IJsonSerializer jsonSerializer, IOptions<RabbitMqOptions> rabbitMqOptions, ILogger<RabbitMqSendMessageBus> logger. مرتبط: IDisposable | ISendMessageBus | DI: IConnection connection, IJsonSerializer jsonSerializer, IOptions<RabbitMqOptions> rabbitMqOptions, ILogger<RabbitMqSendMessageBus> logger.

#### Members

##### `.ctor` (constructor)

```csharp
public RabbitMqSendMessageBus(IConnection connection, IJsonSerializer jsonSerializer, IOptions<RabbitMqOptions> rabbitMqOptions,ILogger<RabbitMqSendMessageBus> logger)
```

سازنده RabbitMqSendMessageBus. پارامترها از طریق تزریق وابستگی تأمین می‌شوند. پارامترها:
- connection (IConnection): ورودی از نوع IConnection.
- jsonSerializer (IJsonSerializer): ورودی از نوع IJsonSerializer.
- rabbitMqOptions (IOptions<RabbitMqOptions>): گزینه‌های typed تنظیمات.
- logger (ILogger<RabbitMqSendMessageBus>): لاگر برای ثبت رویدادها و خطاها.
پیش‌شرط: وابستگی‌ها/مقادیر ورودی باید معتبر باشند تا فیلدهای داخلی به‌درستی مقداردهی شوند.

##### `Publish` (method)

```csharp
public void Publish<TInput>(TInput input)
```

متد «Publish» در RabbitMqSendMessageBus. رویداد/پیام را منتشر می‌کند.
پارامترها:
- input (TInput): مقدار مورد بررسی/ورود.

مقدار بازگشتی: ندارد (void).
استثناها (قابل تشخیص از کد):
- ArgumentNullException (throw new)
- ArgumentNullException
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: IDisposable | ISendMessageBus | DI: IConnection connection, IJsonSerializer jsonSerializer, IOptions<RabbitMqOptions> rabbitMqOptions, ILogger<RabbitMqSendMessageBus> logger

##### `SendCommandTo` (method)

```csharp
public void SendCommandTo<TCommandData>(string destinationService, string commandName, TCommandData commandData)
```

متد «SendCommandTo» در RabbitMqSendMessageBus. درخواست را به handler مناسب مسیریابی و اجرا می‌کند.
پارامترها:
- destinationService (string): ورودی از نوع string.
- commandName (string): ورودی از نوع string.
- commandData (TCommandData): ورودی از نوع TCommandData.

مقدار بازگشتی: ندارد (void).
استثناها (قابل تشخیص از کد):
- ArgumentNullException (throw new)
- ArgumentNullException
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: IDisposable | ISendMessageBus | DI: IConnection connection, IJsonSerializer jsonSerializer, IOptions<RabbitMqOptions> rabbitMqOptions, ILogger<RabbitMqSendMessageBus> logger

##### `SendCommandTo` (method)

```csharp
public void SendCommandTo<TCommandData>(string destinationService, string commandName, string correlationId, TCommandData commandData)
```

متد «SendCommandTo» در RabbitMqSendMessageBus. درخواست را به handler مناسب مسیریابی و اجرا می‌کند.
پارامترها:
- destinationService (string): ورودی از نوع string.
- commandName (string): ورودی از نوع string.
- correlationId (string): ورودی از نوع string.
- commandData (TCommandData): ورودی از نوع TCommandData.

مقدار بازگشتی: ندارد (void).
استثناها (قابل تشخیص از کد):
- ArgumentNullException (throw new)
- ArgumentNullException
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: IDisposable | ISendMessageBus | DI: IConnection connection, IJsonSerializer jsonSerializer, IOptions<RabbitMqOptions> rabbitMqOptions, ILogger<RabbitMqSendMessageBus> logger

##### `Send` (method)

```csharp
public void Send(Parcel parcel)
```

متد «Send» در RabbitMqSendMessageBus. درخواست را به handler مناسب مسیریابی و اجرا می‌کند. جزئیات اجرا را لاگ می‌کند.
پارامترها:
- parcel (Parcel): ورودی از نوع Parcel.

مقدار بازگشتی: ندارد (void).
استثناها (قابل تشخیص از کد):
- ArgumentNullException
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: IDisposable | ISendMessageBus | DI: IConnection connection, IJsonSerializer jsonSerializer, IOptions<RabbitMqOptions> rabbitMqOptions, ILogger<RabbitMqSendMessageBus> logger

##### `Dispose` (method)

```csharp
public void Dispose()
```

متد «Dispose» در RabbitMqSendMessageBus. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
بدون پارامتر ورودی.
مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: IDisposable | ISendMessageBus | DI: IConnection connection, IJsonSerializer jsonSerializer, IOptions<RabbitMqOptions> rabbitMqOptions, ILogger<RabbitMqSendMessageBus> logger

### `Zamin.Extensions.MessageBus.RabbitMQ.RabbitMqSendMessageBusConstants`

- **Kind:** `class`
- **Source:** `Extentsions/MessageBus/Zamin.Extensions.MessageBus.RabbitMQ/Zamin.Extensions.MessageBus.RabbitMQ/RabbitMqSendMessageBusConstants.cs`

کلاس «RabbitMqSendMessageBusConstants» در namespace Zamin.Extensions.MessageBus.RabbitMQ. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین.

#### Members

##### `@event` (field)

```csharp
public const string @event = "event";
```

فیلد «@event» در RabbitMqSendMessageBusConstants با امضای `public const string @event = "event";`. برای نگهداری وضعیت داخلی/قابل‌دسترس نوع استفاده می‌شود.

##### `command` (field)

```csharp
public const string command = "command";
```

فیلد «command» در RabbitMqSendMessageBusConstants با امضای `public const string command = "command";`. برای نگهداری وضعیت داخلی/قابل‌دسترس نوع استفاده می‌شود.
