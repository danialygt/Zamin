# Zamin.Extensions.MessageBus.Abstractions

مرجع API برای namespace `Zamin.Extensions.MessageBus.Abstractions`.

- **Type count (this file):** 5

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Extensions.MessageBus.Abstractions.IMessageConsumer`

- **Kind:** `interface`
- **Source:** `Extentsions/Zamin.Extensions.Abstractions/Zamin.Extensions.MessageBus.Abstractions/IMessageConsumer.cs`

قرارداد (اینترفیس) «IMessageConsumer» در namespace Zamin.Extensions.MessageBus.Abstractions. قرارداد رفتار برای مصرف‌کنندگان و پیاده‌سازی‌های جایگزین.

#### Members

##### `ConsumeEvent` (method)

```csharp
Task<bool> ConsumeEvent(string sender, Parcel parcel)
```

متد «ConsumeEvent» در IMessageConsumer. پیام دریافتی را مصرف و به handler مناسب تحویل می‌دهد.
پارامترها:
- sender (string): ورودی از نوع string.
- parcel (Parcel): ورودی از نوع Parcel.

مقدار بازگشتی: `Task<bool>` — نتیجه ناهمگام عملیات.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `ConsumeCommand` (method)

```csharp
Task<bool> ConsumeCommand(string sender, Parcel parcel)
```

متد «ConsumeCommand» در IMessageConsumer. پیام دریافتی را مصرف و به handler مناسب تحویل می‌دهد.
پارامترها:
- sender (string): ورودی از نوع string.
- parcel (Parcel): ورودی از نوع Parcel.

مقدار بازگشتی: `Task<bool>` — نتیجه ناهمگام عملیات.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

### `Zamin.Extensions.MessageBus.Abstractions.IMessageInboxItemRepository`

- **Kind:** `interface`
- **Source:** `Extentsions/Zamin.Extensions.Abstractions/Zamin.Extensions.MessageBus.Abstractions/IMessageInboxItemRepository.cs`

قرارداد (اینترفیس) «IMessageInboxItemRepository» در namespace Zamin.Extensions.MessageBus.Abstractions. قرارداد دسترسی به داده برای ذخیره و بازیابی aggregate/entity.

#### Members

##### `AllowReceive` (method)

```csharp
bool AllowReceive(string messageId, string fromService)
```

متد «AllowReceive» در IMessageInboxItemRepository. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- messageId (string): ورودی از نوع string.
- fromService (string): ورودی از نوع string.

مقدار بازگشتی: `bool`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `Receive` (method)

```csharp
void Receive(string messageId, string fromService,string payload)
```

متد «Receive» در IMessageInboxItemRepository. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- messageId (string): ورودی از نوع string.
- fromService (string): ورودی از نوع string.
- payload (string): ورودی از نوع string.

مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

### `Zamin.Extensions.MessageBus.Abstractions.IReceiveMessageBus`

- **Kind:** `interface`
- **Source:** `Extentsions/Zamin.Extensions.Abstractions/Zamin.Extensions.MessageBus.Abstractions/IReceiveMessageBus.cs`

قرارداد (اینترفیس) «IReceiveMessageBus» در namespace Zamin.Extensions.MessageBus.Abstractions. قرارداد رفتار برای مصرف‌کنندگان و پیاده‌سازی‌های جایگزین.

#### Members

##### `Subscribe` (method)

```csharp
void Subscribe(string serviceId, string eventName)
```

متد «Subscribe» در IReceiveMessageBus. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- serviceId (string): ورودی از نوع string.
- eventName (string): رویداد دامنه/پیام برای پردازش.

مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `Receive` (method)

```csharp
void Receive(string commandName)
```

متد «Receive» در IReceiveMessageBus. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- commandName (string): ورودی از نوع string.

مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

### `Zamin.Extensions.MessageBus.Abstractions.ISendMessageBus`

- **Kind:** `interface`
- **Source:** `Extentsions/Zamin.Extensions.Abstractions/Zamin.Extensions.MessageBus.Abstractions/ISendMessageBus.cs`

جهت ارسال پیام از این زیر ساخت اتستفاده می‌شود پیام ها می‌توانند در قالب دستوری باشند که به سرویسی خاص ارسال می‌شوند یا پیامی عمومی که برای همه ارسال می‌شود

#### Members

##### `Publish` (method)

```csharp
void Publish<TInput>(TInput input)
```

متد «Publish» در ISendMessageBus. رویداد/پیام را منتشر می‌کند.
پارامترها:
- input (TInput): مقدار مورد بررسی/ورود.

مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `SendCommandTo` (method)

```csharp
void SendCommandTo<TCommandData>(string destinationService, string commandName, TCommandData commandData)
```

متد «SendCommandTo» در ISendMessageBus. درخواست را به handler مناسب مسیریابی و اجرا می‌کند.
پارامترها:
- destinationService (string): ورودی از نوع string.
- commandName (string): ورودی از نوع string.
- commandData (TCommandData): ورودی از نوع TCommandData.

مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `SendCommandTo` (method)

```csharp
void SendCommandTo<TCommandData>(string destinationService, string commandName, string correlationId, TCommandData commandData)
```

متد «SendCommandTo» در ISendMessageBus. درخواست را به handler مناسب مسیریابی و اجرا می‌کند.
پارامترها:
- destinationService (string): ورودی از نوع string.
- commandName (string): ورودی از نوع string.
- correlationId (string): ورودی از نوع string.
- commandData (TCommandData): ورودی از نوع TCommandData.

مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `Send` (method)

```csharp
void Send(Parcel parcel)
```

متد «Send» در ISendMessageBus. درخواست را به handler مناسب مسیریابی و اجرا می‌کند.
پارامترها:
- parcel (Parcel): ورودی از نوع Parcel.

مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

### `Zamin.Extensions.MessageBus.Abstractions.Parcel`

- **Kind:** `class`
- **Source:** `Extentsions/Zamin.Extensions.Abstractions/Zamin.Extensions.MessageBus.Abstractions/Parcel.cs`

این کلاس در نرم‌افزار داده‌هایی که باید از طریق زیر ساخت پیام رسانی منتقل شود را نگهداری می‌کند

#### Members

##### `MessageId` (property)

```csharp
public string MessageId { get; set; }
```

پراپرتی «MessageId» از نوع `string` در Parcel. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `CorrelationId` (property)

```csharp
public string CorrelationId { get; set; }
```

پراپرتی «CorrelationId» از نوع `string` در Parcel. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `MessageName` (property)

```csharp
public string MessageName { get; set; }
```

پراپرتی «MessageName» از نوع `string` در Parcel. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `Headers` (property)

```csharp
public Dictionary<string, object> Headers { get; set; }
```

پراپرتی «Headers» از نوع `Dictionary<string, object>` در Parcel. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `MessageBody` (property)

```csharp
public string MessageBody { get; set; }
```

پراپرتی «MessageBody» از نوع `string` در Parcel. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `Route` (property)

```csharp
public string Route { get; set; }
```

پراپرتی «Route» از نوع `string` در Parcel. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.
