# Zamin.Extensions.MessageBus.Abstractions.Fakes

مرجع API برای namespace `Zamin.Extensions.MessageBus.Abstractions.Fakes`.

- **Type count (this file):** 3

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Extensions.MessageBus.Abstractions.Fakes.FakeMessageConsumer`

- **Kind:** `class`
- **Base / interfaces:** `IMessageConsumer`
- **Source:** `Extentsions/Zamin.Extensions.Abstractions/Zamin.Extensions.MessageBus.Abstractions/Fakes/FakeMessageConsumer.cs`

کلاس «FakeMessageConsumer» در namespace Zamin.Extensions.MessageBus.Abstractions.Fakes. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین. ارث‌بری/پیاده‌سازی: IMessageConsumer. مرتبط: IMessageConsumer.

#### Members

##### `ConsumeCommand` (method)

```csharp
public async Task<bool> ConsumeCommand(string sender, Parcel parcel)
```

متد «ConsumeCommand» در FakeMessageConsumer. پیام دریافتی را مصرف و به handler مناسب تحویل می‌دهد.
پارامترها:
- sender (string): ورودی از نوع string.
- parcel (Parcel): ورودی از نوع Parcel.

مقدار بازگشتی: `Task<bool>` — نتیجه ناهمگام عملیات.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
انواع مرتبط: IMessageConsumer

##### `ConsumeEvent` (method)

```csharp
public async Task<bool> ConsumeEvent(string sender, Parcel parcel)
```

متد «ConsumeEvent» در FakeMessageConsumer. پیام دریافتی را مصرف و به handler مناسب تحویل می‌دهد.
پارامترها:
- sender (string): ورودی از نوع string.
- parcel (Parcel): ورودی از نوع Parcel.

مقدار بازگشتی: `Task<bool>` — نتیجه ناهمگام عملیات.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
انواع مرتبط: IMessageConsumer

### `Zamin.Extensions.MessageBus.Abstractions.Fakes.FakeReceiveMessageBus`

- **Kind:** `class`
- **Base / interfaces:** `IReceiveMessageBus`
- **Source:** `Extentsions/Zamin.Extensions.Abstractions/Zamin.Extensions.MessageBus.Abstractions/Fakes/FakeReceiveMessageBus.cs`

کلاس «FakeReceiveMessageBus» در namespace Zamin.Extensions.MessageBus.Abstractions.Fakes. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین. ارث‌بری/پیاده‌سازی: IReceiveMessageBus. وابستگی‌های سازنده (DI): ILogger<FakeSendMessageBus> logger. مرتبط: IReceiveMessageBus | DI: ILogger<FakeSendMessageBus> logger.

#### Members

##### `.ctor` (constructor)

```csharp
public FakeReceiveMessageBus(ILogger<FakeSendMessageBus> logger)
```

سازنده FakeReceiveMessageBus. پارامترها از طریق تزریق وابستگی تأمین می‌شوند. پارامترها:
- logger (ILogger<FakeSendMessageBus>): لاگر برای ثبت رویدادها و خطاها.
پیش‌شرط: وابستگی‌ها/مقادیر ورودی باید معتبر باشند تا فیلدهای داخلی به‌درستی مقداردهی شوند.

##### `Receive` (method)

```csharp
public void Receive(string commandName)
```

متد «Receive» در FakeReceiveMessageBus. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد. جزئیات اجرا را لاگ می‌کند.
پارامترها:
- commandName (string): ورودی از نوع string.

مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: IReceiveMessageBus | DI: ILogger<FakeSendMessageBus> logger

##### `Subscribe` (method)

```csharp
public void Subscribe(string serviceId, string eventName)
```

متد «Subscribe» در FakeReceiveMessageBus. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد. جزئیات اجرا را لاگ می‌کند.
پارامترها:
- serviceId (string): ورودی از نوع string.
- eventName (string): رویداد دامنه/پیام برای پردازش.

مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: IReceiveMessageBus | DI: ILogger<FakeSendMessageBus> logger

### `Zamin.Extensions.MessageBus.Abstractions.Fakes.FakeSendMessageBus`

- **Kind:** `class`
- **Base / interfaces:** `ISendMessageBus`
- **Source:** `Extentsions/Zamin.Extensions.Abstractions/Zamin.Extensions.MessageBus.Abstractions/Fakes/FakeSendMessageBus.cs`

کلاس «FakeSendMessageBus» در namespace Zamin.Extensions.MessageBus.Abstractions.Fakes. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین. ارث‌بری/پیاده‌سازی: ISendMessageBus. وابستگی‌های سازنده (DI): ILogger<FakeSendMessageBus> logger. مرتبط: ISendMessageBus | DI: ILogger<FakeSendMessageBus> logger.

#### Members

##### `.ctor` (constructor)

```csharp
public FakeSendMessageBus(ILogger<FakeSendMessageBus> logger)
```

سازنده FakeSendMessageBus. پارامترها از طریق تزریق وابستگی تأمین می‌شوند. پارامترها:
- logger (ILogger<FakeSendMessageBus>): لاگر برای ثبت رویدادها و خطاها.
پیش‌شرط: وابستگی‌ها/مقادیر ورودی باید معتبر باشند تا فیلدهای داخلی به‌درستی مقداردهی شوند.

##### `Publish` (method)

```csharp
public void Publish<TInput>(TInput input)
```

متد «Publish» در FakeSendMessageBus. رویداد/پیام را منتشر می‌کند. جزئیات اجرا را لاگ می‌کند.
پارامترها:
- input (TInput): مقدار مورد بررسی/ورود.

مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: ISendMessageBus | DI: ILogger<FakeSendMessageBus> logger

##### `Send` (method)

```csharp
public void Send(Parcel parcel)
```

متد «Send» در FakeSendMessageBus. درخواست را به handler مناسب مسیریابی و اجرا می‌کند. جزئیات اجرا را لاگ می‌کند.
پارامترها:
- parcel (Parcel): ورودی از نوع Parcel.

مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: ISendMessageBus | DI: ILogger<FakeSendMessageBus> logger

##### `SendCommandTo` (method)

```csharp
public void SendCommandTo<TCommandData>(string destinationService, string commandName, TCommandData commandData)
```

متد «SendCommandTo» در FakeSendMessageBus. درخواست را به handler مناسب مسیریابی و اجرا می‌کند. جزئیات اجرا را لاگ می‌کند.
پارامترها:
- destinationService (string): ورودی از نوع string.
- commandName (string): ورودی از نوع string.
- commandData (TCommandData): ورودی از نوع TCommandData.

مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: ISendMessageBus | DI: ILogger<FakeSendMessageBus> logger

##### `SendCommandTo` (method)

```csharp
public void SendCommandTo<TCommandData>(string destinationService, string commandName, string correlationId, TCommandData commandData)
```

متد «SendCommandTo» در FakeSendMessageBus. درخواست را به handler مناسب مسیریابی و اجرا می‌کند. جزئیات اجرا را لاگ می‌کند.
پارامترها:
- destinationService (string): ورودی از نوع string.
- commandName (string): ورودی از نوع string.
- correlationId (string): ورودی از نوع string.
- commandData (TCommandData): ورودی از نوع TCommandData.

مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: ISendMessageBus | DI: ILogger<FakeSendMessageBus> logger
