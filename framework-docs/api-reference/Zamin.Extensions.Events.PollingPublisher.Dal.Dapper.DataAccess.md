# Zamin.Extensions.Events.PollingPublisher.Dal.Dapper.DataAccess

مرجع API برای namespace `Zamin.Extensions.Events.PollingPublisher.Dal.Dapper.DataAccess`.

- **Type count (this file):** 1

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Extensions.Events.PollingPublisher.Dal.Dapper.DataAccess.SqlOutBoxEventItemRepository`

- **Kind:** `class`
- **Base / interfaces:** `IOutBoxEventItemRepository`
- **Source:** `Extentsions/Events/Zamin.Extensions.Events.PollingPublisher/Zamin.Extensions.Events.PollingPublisher.Dal.Dapper/DataAccess/SqlOutBoxEventItemRepository.cs`

کلاس «SqlOutBoxEventItemRepository» در namespace Zamin.Extensions.Events.PollingPublisher.Dal.Dapper.DataAccess. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین. ارث‌بری/پیاده‌سازی: IOutBoxEventItemRepository. وابستگی‌های سازنده (DI): IOptions<PollingPublisherDalRedisOptions> options, ILogger<SqlOutBoxEventItemRepository> logger. مرتبط: IOutBoxEventItemRepository | DI: IOptions<PollingPublisherDalRedisOptions> options, ILogger<SqlOutBoxEventItemRepository> logger.

#### Members

##### `.ctor` (constructor)

```csharp
public SqlOutBoxEventItemRepository(IOptions<PollingPublisherDalRedisOptions> options, ILogger<SqlOutBoxEventItemRepository> logger)
```

سازنده SqlOutBoxEventItemRepository. پارامترها از طریق تزریق وابستگی تأمین می‌شوند. پارامترها:
- options (IOptions<PollingPublisherDalRedisOptions>): گزینه‌های typed تنظیمات.
- logger (ILogger<SqlOutBoxEventItemRepository>): لاگر برای ثبت رویدادها و خطاها.
پیش‌شرط: وابستگی‌ها/مقادیر ورودی باید معتبر باشند تا فیلدهای داخلی به‌درستی مقداردهی شوند.

##### `GetOutBoxEventItemsForPublishe` (method)

```csharp
public List<OutBoxEventItem> GetOutBoxEventItemsForPublishe(int maxCount = 100)
```

متد «GetOutBoxEventItemsForPublishe» در SqlOutBoxEventItemRepository. داده یا وضعیت مرتبط را بازیابی می‌کند. جزئیات اجرا را لاگ می‌کند. خطاها را در بلوک try/catch مدیریت می‌کند.
پارامترها:
- maxCount (int): ورودی اختیاری از نوع int (دارای مقدار پیش‌فرض).

مقدار بازگشتی: `List<OutBoxEventItem>`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: IOutBoxEventItemRepository | DI: IOptions<PollingPublisherDalRedisOptions> options, ILogger<SqlOutBoxEventItemRepository> logger

##### `MarkAsRead` (method)

```csharp
public void MarkAsRead(List<OutBoxEventItem> outBoxEventItems)
```

متد «MarkAsRead» در SqlOutBoxEventItemRepository. وضعیت آیتم را در ذخیره‌گاه علامت‌گذاری می‌کند. جزئیات اجرا را لاگ می‌کند. خطاها را در بلوک try/catch مدیریت می‌کند.
پارامترها:
- outBoxEventItems (List<OutBoxEventItem>): رویداد دامنه/پیام برای پردازش.

مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: IOutBoxEventItemRepository | DI: IOptions<PollingPublisherDalRedisOptions> options, ILogger<SqlOutBoxEventItemRepository> logger
