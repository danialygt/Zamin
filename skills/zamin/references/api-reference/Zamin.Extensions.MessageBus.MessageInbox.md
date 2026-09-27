# Zamin.Extensions.MessageBus.MessageInbox

مرجع API برای namespace `Zamin.Extensions.MessageBus.MessageInbox`.

- **Type count (this file):** 1

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Extensions.MessageBus.MessageInbox.InboxMessageConsumer`

- **Kind:** `class`
- **Base / interfaces:** `IMessageConsumer`
- **Source:** `Extentsions/MessageBus/Zamin.Extensions.MessageBus.MessageInbox/Zamin.Extensions.MessageBus.MessageInbox/InboxMessageConsumer.cs`

کلاس «InboxMessageConsumer» در namespace Zamin.Extensions.MessageBus.MessageInbox. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین. ارث‌بری/پیاده‌سازی: IMessageConsumer. وابستگی‌های سازنده (DI): IOptions<MessageInboxOptions> messageInboxOptions, IJsonSerializer jsonSerializer, IMessageInboxItemRepository messageInboxItemRepository, ICommandDispatcher commandDispatcher, IEventDispatcher eventDispatcher. مرتبط: IMessageConsumer | DI: IOptions<MessageInboxOptions> messageInboxOptions, IJsonSerializer jsonSerializer, IMessageInboxItemRepository messageInboxItemRepository, ICommandDispatcher commandDispatcher, IEventDispatcher eventDispatcher.

#### Members

##### `.ctor` (constructor)

```csharp
public InboxMessageConsumer(IOptions<MessageInboxOptions> messageInboxOptions,
                                IJsonSerializer jsonSerializer,
                                IMessageInboxItemRepository messageInboxItemRepository,
                                ICommandDispatcher commandDispatcher,
                                IEventDispatcher eventDispatcher)
```

سازنده InboxMessageConsumer. پارامترها از طریق تزریق وابستگی تأمین می‌شوند. پارامترها:
- messageInboxOptions (IOptions<MessageInboxOptions>): گزینه‌های typed تنظیمات.
- jsonSerializer (IJsonSerializer): ورودی از نوع IJsonSerializer.
- messageInboxItemRepository (IMessageInboxItemRepository): ورودی از نوع IMessageInboxItemRepository.
- commandDispatcher (ICommandDispatcher): فرمان ورودی برای اجرا.
- eventDispatcher (IEventDispatcher): رویداد دامنه/پیام برای پردازش.
پیش‌شرط: وابستگی‌ها/مقادیر ورودی باید معتبر باشند تا فیلدهای داخلی به‌درستی مقداردهی شوند.

##### `ConsumeCommand` (method)

```csharp
public Task<bool> ConsumeCommand(string sender, Parcel parcel)
```

متد «ConsumeCommand» در InboxMessageConsumer. پیام دریافتی را مصرف و به handler مناسب تحویل می‌دهد.
پارامترها:
- sender (string): ورودی از نوع string.
- parcel (Parcel): ورودی از نوع Parcel.

مقدار بازگشتی: `Task<bool>` — نتیجه ناهمگام عملیات.
استثناها (قابل تشخیص از کد):
- NotImplementedException (throw new)
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند؛ قبل از Send باید SetCommandDispatcher فراخوانی شده باشد
انواع مرتبط: IMessageConsumer | DI: IOptions<MessageInboxOptions> messageInboxOptions, IJsonSerializer jsonSerializer, IMessageInboxItemRepository messageInboxItemRepository, ICommandDispatcher commandDispatcher, IEventDispatcher eventDispatcher

##### `ConsumeEvent` (method)

```csharp
public async Task<bool> ConsumeEvent(string sender, Parcel parcel)
```

متد «ConsumeEvent» در InboxMessageConsumer. پیام دریافتی را مصرف و به handler مناسب تحویل می‌دهد. به‌صورت ناهمگام اجرا می‌شود.
پارامترها:
- sender (string): ورودی از نوع string.
- parcel (Parcel): ورودی از نوع Parcel.

مقدار بازگشتی: `Task<bool>` — نتیجه ناهمگام عملیات.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند؛ قبل از Publish باید SetEventDispatcher فراخوانی شده باشد
انواع مرتبط: IMessageConsumer | DI: IOptions<MessageInboxOptions> messageInboxOptions, IJsonSerializer jsonSerializer, IMessageInboxItemRepository messageInboxItemRepository, ICommandDispatcher commandDispatcher, IEventDispatcher eventDispatcher
