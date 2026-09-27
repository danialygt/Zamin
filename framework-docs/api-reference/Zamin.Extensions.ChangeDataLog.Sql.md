# Zamin.Extensions.ChangeDataLog.Sql

مرجع API برای namespace `Zamin.Extensions.ChangeDataLog.Sql`.

- **Type count (this file):** 1

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Extensions.ChangeDataLog.Sql.DapperEntityChangeInterceptorItemRepository`

- **Kind:** `class`
- **Base / interfaces:** `IEntityChageInterceptorItemRepository`
- **Source:** `Extentsions/Databases/Zamin.Extensions.ChangeDataLog/Zamin.Extensions.ChangeDataLog.Sql/DapperEntityChangeInterceptorItemRepository.cs`

کلاس «DapperEntityChangeInterceptorItemRepository» در namespace Zamin.Extensions.ChangeDataLog.Sql. موجودیت دامنه با هویت و قابلیت auditable. ارث‌بری/پیاده‌سازی: IEntityChageInterceptorItemRepository. وابستگی‌های سازنده (DI): IOptions<ChangeDataLogSqlOptions> options, ILogger<DapperEntityChangeInterceptorItemRepository> logger. مرتبط: IEntityChageInterceptorItemRepository | DI: IOptions<ChangeDataLogSqlOptions> options, ILogger<DapperEntityChangeInterceptorItemRepository> logger.

#### Members

##### `.ctor` (constructor)

```csharp
public DapperEntityChangeInterceptorItemRepository(IOptions<ChangeDataLogSqlOptions> options,
                                                       ILogger<DapperEntityChangeInterceptorItemRepository> logger)
```

سازنده DapperEntityChangeInterceptorItemRepository. پارامترها از طریق تزریق وابستگی تأمین می‌شوند. پارامترها:
- options (IOptions<ChangeDataLogSqlOptions>): گزینه‌های typed تنظیمات.
- logger (ILogger<DapperEntityChangeInterceptorItemRepository>): لاگر برای ثبت رویدادها و خطاها.
استثناها (از روی بدنه):
- ArgumentNullException (throw new)
- ArgumentException (throw new)
پیش‌شرط: وابستگی‌ها/مقادیر ورودی باید معتبر باشند تا فیلدهای داخلی به‌درستی مقداردهی شوند.

##### `Save` (method)

```csharp
public void Save(List<EntityChageInterceptorItem> entityChangeInterceptorItems, IDbTransaction transaction = null)
```

متد «Save» در DapperEntityChangeInterceptorItemRepository. وضعیت را به‌روز یا ذخیره می‌کند. جزئیات اجرا را لاگ می‌کند. خطاها را در بلوک try/catch مدیریت می‌کند.
پارامترها:
- entityChangeInterceptorItems (List<EntityChageInterceptorItem>): ورودی از نوع List<EntityChageInterceptorItem>.
- transaction (IDbTransaction): ورودی اختیاری از نوع IDbTransaction (دارای مقدار پیش‌فرض).

مقدار بازگشتی: ندارد (void).
استثناها (قابل تشخیص از کد):
- ArgumentNullException (throw new)
- ArgumentNullException
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: IEntityChageInterceptorItemRepository | DI: IOptions<ChangeDataLogSqlOptions> options, ILogger<DapperEntityChangeInterceptorItemRepository> logger

##### `SaveAsync` (method)

```csharp
public async Task SaveAsync(List<EntityChageInterceptorItem> entityChangeInterceptorItems, IDbTransaction transaction = null)
```

متد «SaveAsync» در DapperEntityChangeInterceptorItemRepository. وضعیت را به‌روز یا ذخیره می‌کند. جزئیات اجرا را لاگ می‌کند. خطاها را در بلوک try/catch مدیریت می‌کند. به‌صورت ناهمگام اجرا می‌شود.
پارامترها:
- entityChangeInterceptorItems (List<EntityChageInterceptorItem>): ورودی از نوع List<EntityChageInterceptorItem>.
- transaction (IDbTransaction): ورودی اختیاری از نوع IDbTransaction (دارای مقدار پیش‌فرض).

مقدار بازگشتی: `Task` — عملیات ناهمگام بدون نتیجه داده‌ای.
استثناها (قابل تشخیص از کد):
- ArgumentNullException (throw new)
- ArgumentNullException
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: IEntityChageInterceptorItemRepository | DI: IOptions<ChangeDataLogSqlOptions> options, ILogger<DapperEntityChangeInterceptorItemRepository> logger
