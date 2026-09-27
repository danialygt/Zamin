# Zamin.Extensions.MessageBus.MessageInbox.Dal.Dapper

مرجع API برای namespace `Zamin.Extensions.MessageBus.MessageInbox.Dal.Dapper`.

- **Type count (this file):** 1

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Extensions.MessageBus.MessageInbox.Dal.Dapper.SqlMessageInboxItemRepository`

- **Kind:** `class`
- **Base / interfaces:** `IMessageInboxItemRepository`
- **Source:** `Extentsions/MessageBus/Zamin.Extensions.MessageBus.MessageInbox/Zamin.Extensions.MessageBus.MessageInbox.Dal.Dapper/SqlMessageInboxItemRepository.cs`

کلاس «SqlMessageInboxItemRepository» در namespace Zamin.Extensions.MessageBus.MessageInbox.Dal.Dapper. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین. ارث‌بری/پیاده‌سازی: IMessageInboxItemRepository. وابستگی‌های سازنده (DI): IOptions<MessageInboxDalDapperOptions> options, ILogger<SqlMessageInboxItemRepository> logger. مرتبط: IMessageInboxItemRepository | DI: IOptions<MessageInboxDalDapperOptions> options, ILogger<SqlMessageInboxItemRepository> logger.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/dependency-injection.md#recipe-worker-messaging-dal)

#### Members

##### `.ctor` (constructor)

```csharp
public SqlMessageInboxItemRepository(IOptions<MessageInboxDalDapperOptions> options, ILogger<SqlMessageInboxItemRepository> logger)
```

سازنده SqlMessageInboxItemRepository. پارامترها از طریق تزریق وابستگی تأمین می‌شوند. پارامترها:
- options (IOptions<MessageInboxDalDapperOptions>): گزینه‌های typed تنظیمات.
- logger (ILogger<SqlMessageInboxItemRepository>): لاگر برای ثبت رویدادها و خطاها.
پیش‌شرط: وابستگی‌ها/مقادیر ورودی باید معتبر باشند تا فیلدهای داخلی به‌درستی مقداردهی شوند.

##### `AllowReceive` (method)

```csharp
public bool AllowReceive(string messageId, string fromService)
```

متد «AllowReceive» در SqlMessageInboxItemRepository. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- messageId (string): ورودی از نوع string.
- fromService (string): ورودی از نوع string.

مقدار بازگشتی: `bool`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: IMessageInboxItemRepository | DI: IOptions<MessageInboxDalDapperOptions> options, ILogger<SqlMessageInboxItemRepository> logger

##### `Receive` (method)

```csharp
public void Receive(string messageId, string fromService, string payload)
```

متد «Receive» در SqlMessageInboxItemRepository. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- messageId (string): ورودی از نوع string.
- fromService (string): ورودی از نوع string.
- payload (string): ورودی از نوع string.

مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: IMessageInboxItemRepository | DI: IOptions<MessageInboxDalDapperOptions> options, ILogger<SqlMessageInboxItemRepository> logger
