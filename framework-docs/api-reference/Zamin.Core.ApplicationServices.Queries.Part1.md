# Zamin.Core.ApplicationServices.Queries (Part 1/2)

مرجع API برای namespace `Zamin.Core.ApplicationServices.Queries`.

- **Type count (this file):** 4
- **Parts:** **Part 1** · [Part 2](./Zamin.Core.ApplicationServices.Queries.Part2.md)

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Core.ApplicationServices.Queries.QueryDispatcher`

- **Kind:** `class`
- **Base / interfaces:** `IQueryDispatcher`
- **Source:** `Onion/src/2.Core/Zamin.Core.ApplicationServices/Queries/QueryDispatcher.cs`

کلاس «QueryDispatcher» در namespace Zamin.Core.ApplicationServices.Queries. مسئول یافتن و فراخوانی handler مناسب برای فرمان/کوئری/رویداد. ارث‌بری/پیاده‌سازی: IQueryDispatcher. وابستگی‌های سازنده (DI): IServiceProvider serviceProvider, ILogger<QueryDispatcher> logger. مرتبط: IQueryDispatcher | DI: IServiceProvider serviceProvider, ILogger<QueryDispatcher> logger.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/common-recipes.md#recipe-query-handler)

#### Members

##### `.ctor` (constructor)

```csharp
public QueryDispatcher(IServiceProvider serviceProvider, ILogger<QueryDispatcher> logger)
```

سازنده QueryDispatcher. پارامترها از طریق تزریق وابستگی تأمین می‌شوند. پارامترها:
- serviceProvider (IServiceProvider): ارائه‌دهنده سرویس برای resolve کردن وابستگی‌ها.
- logger (ILogger<QueryDispatcher>): لاگر برای ثبت رویدادها و خطاها.
پیش‌شرط: وابستگی‌ها/مقادیر ورودی باید معتبر باشند تا فیلدهای داخلی به‌درستی مقداردهی شوند.

##### `Execute` (method)

```csharp
public Task<QueryResult<TData>> Execute<TQuery, TData>(TQuery query) where TQuery : class, IQuery<TData>
```

متد «Execute» در QueryDispatcher. کوئری/عملیات را به handler مناسب مسیریابی و اجرا می‌کند. handler/سرویس را از DI با GetRequiredService برمی‌دارد. زمان اجرا را اندازه‌گیری و لاگ می‌کند. جزئیات اجرا را لاگ می‌کند. خطاها را در بلوک try/catch مدیریت می‌کند.
پارامترها:
- query (TQuery): کوئری ورودی برای اجرا.

مقدار بازگشتی: `Task<QueryResult<TData>>` — نتیجه ناهمگام عملیات.
استثناها (قابل تشخیص از کد):
- InvalidOperationException
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند؛ سرویس/handler مربوطه باید در DI ثبت شده باشد وگرنه InvalidOperationException رخ می‌دهد
انواع مرتبط: IQueryDispatcher | DI: IServiceProvider serviceProvider, ILogger<QueryDispatcher> logger

### `Zamin.Core.ApplicationServices.Queries.QueryDispatcherDecorator`

- **Kind:** `class`
- **Base / interfaces:** `IQueryDispatcher`
- **Source:** `Onion/src/2.Core/Zamin.Core.ApplicationServices/Queries/QueryDispatcherDecorator.cs`

کلاس «QueryDispatcherDecorator» در namespace Zamin.Core.ApplicationServices.Queries. مسئول یافتن و فراخوانی handler مناسب برای فرمان/کوئری/رویداد. ارث‌بری/پیاده‌سازی: IQueryDispatcher. مرتبط: IQueryDispatcher.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/common-recipes.md#recipe-query-handler)

#### Members

##### `_queryDispatcher` (field)

```csharp
protected IQueryDispatcher _queryDispatcher;
```

فیلد «_queryDispatcher» در QueryDispatcherDecorator با امضای `protected IQueryDispatcher _queryDispatcher;`. برای نگهداری وضعیت داخلی/قابل‌دسترس نوع استفاده می‌شود.

##### `Order` (property)

```csharp
public abstract int Order { get; }
```

پراپرتی «Order» از نوع `int` در QueryDispatcherDecorator. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. فقط‌خواندنی است.

##### `.ctor` (constructor)

```csharp
public QueryDispatcherDecorator()
```

سازنده QueryDispatcherDecorator. بدون پارامتر؛ معمولاً برای ORM، serialization یا مقداردهی اولیه محافظت‌شده استفاده می‌شود.

##### `Execute` (method)

```csharp
public abstract Task<QueryResult<TData>> Execute<TQuery, TData>(TQuery query) where TQuery : class, IQuery<TData>
```

متد «Execute» در QueryDispatcherDecorator. کوئری/عملیات را به handler مناسب مسیریابی و اجرا می‌کند.
پارامترها:
- query (TQuery): کوئری ورودی برای اجرا.

مقدار بازگشتی: `Task<QueryResult<TData>>` — نتیجه ناهمگام عملیات.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
انواع مرتبط: IQueryDispatcher

##### `SetQueryDispatcher` (method)

```csharp
public void SetQueryDispatcher(IQueryDispatcher queryDispatcher)
```

متد «SetQueryDispatcher» در QueryDispatcherDecorator. وضعیت را به‌روز یا ذخیره می‌کند.
پارامترها:
- queryDispatcher (IQueryDispatcher): کوئری ورودی برای اجرا.

مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: قبل از Execute باید SetQueryDispatcher فراخوانی شده باشد
انواع مرتبط: IQueryDispatcher

### `Zamin.Core.ApplicationServices.Queries.QueryDispatcherDomainExceptionHandlerDecorator`

- **Kind:** `class`
- **Base / interfaces:** `QueryDispatcherDecorator`
- **Source:** `Onion/src/2.Core/Zamin.Core.ApplicationServices/Queries/QueryDispatcherDomainExceptionHandlerDecorator.cs`

کلاس «QueryDispatcherDomainExceptionHandlerDecorator» در namespace Zamin.Core.ApplicationServices.Queries. مسئول یافتن و فراخوانی handler مناسب برای فرمان/کوئری/رویداد. ارث‌بری/پیاده‌سازی: QueryDispatcherDecorator. وابستگی‌های سازنده (DI): IServiceProvider serviceProvider, ILogger<QueryDispatcherDomainExceptionHandlerDecorator> logger. مرتبط: QueryDispatcherDecorator (same namespace) | DI: IServiceProvider serviceProvider, ILogger<QueryDispatcherDomainExceptionHandlerDecorator> logger.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/common-recipes.md#recipe-query-handler)

#### Members

##### `Order` (property)

```csharp
public override int Order => ...
```

پراپرتی «Order» از نوع `int` در QueryDispatcherDomainExceptionHandlerDecorator. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. منطق دسترسی از روی بدنه accessor قابل مشاهده است.

##### `.ctor` (constructor)

```csharp
public QueryDispatcherDomainExceptionHandlerDecorator(IServiceProvider serviceProvider,
                                                          ILogger<QueryDispatcherDomainExceptionHandlerDecorator> logger)
```

سازنده QueryDispatcherDomainExceptionHandlerDecorator. پارامترها از طریق تزریق وابستگی تأمین می‌شوند. پارامترها:
- serviceProvider (IServiceProvider): ارائه‌دهنده سرویس برای resolve کردن وابستگی‌ها.
- logger (ILogger<QueryDispatcherDomainExceptionHandlerDecorator>): لاگر برای ثبت رویدادها و خطاها.
پیش‌شرط: وابستگی‌ها/مقادیر ورودی باید معتبر باشند تا فیلدهای داخلی به‌درستی مقداردهی شوند.

##### `Execute` (method)

```csharp
public override async Task<QueryResult<TData>> Execute<TQuery, TData>(TQuery query)
```

متد «Execute» در QueryDispatcherDomainExceptionHandlerDecorator. کوئری/عملیات را به handler مناسب مسیریابی و اجرا می‌کند. جزئیات اجرا را لاگ می‌کند. خطاها را در بلوک try/catch مدیریت می‌کند. به‌صورت ناهمگام اجرا می‌شود.
پارامترها:
- query (TQuery): کوئری ورودی برای اجرا.

مقدار بازگشتی: `Task<QueryResult<TData>>` — نتیجه ناهمگام عملیات.
استثناها (قابل تشخیص از کد):
- ex (rethrow/throw)
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند؛ قبل از Execute باید SetQueryDispatcher فراخوانی شده باشد
انواع مرتبط: QueryDispatcherDecorator (same namespace) | DI: IServiceProvider serviceProvider, ILogger<QueryDispatcherDomainExceptionHandlerDecorator> logger

### `Zamin.Core.ApplicationServices.Queries.QueryDispatcherValidationDecorator`

- **Kind:** `class`
- **Base / interfaces:** `QueryDispatcherDecorator`
- **Source:** `Onion/src/2.Core/Zamin.Core.ApplicationServices/Queries/QueryDispatcherValidationDecorator.cs`

کلاس «QueryDispatcherValidationDecorator» در namespace Zamin.Core.ApplicationServices.Queries. مسئول یافتن و فراخوانی handler مناسب برای فرمان/کوئری/رویداد. ارث‌بری/پیاده‌سازی: QueryDispatcherDecorator. وابستگی‌های سازنده (DI): IServiceProvider serviceProvider, ILogger<QueryDispatcherValidationDecorator> logger. مرتبط: QueryDispatcherDecorator (same namespace) | DI: IServiceProvider serviceProvider, ILogger<QueryDispatcherValidationDecorator> logger.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/common-recipes.md#recipe-query-handler)

#### Members

##### `Order` (property)

```csharp
public override int Order => ...
```

پراپرتی «Order» از نوع `int` در QueryDispatcherValidationDecorator. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. منطق دسترسی از روی بدنه accessor قابل مشاهده است.

##### `.ctor` (constructor)

```csharp
public QueryDispatcherValidationDecorator(IServiceProvider serviceProvider,
                                              ILogger<QueryDispatcherValidationDecorator> logger)
```

سازنده QueryDispatcherValidationDecorator. پارامترها از طریق تزریق وابستگی تأمین می‌شوند. پارامترها:
- serviceProvider (IServiceProvider): ارائه‌دهنده سرویس برای resolve کردن وابستگی‌ها.
- logger (ILogger<QueryDispatcherValidationDecorator>): لاگر برای ثبت رویدادها و خطاها.
پیش‌شرط: وابستگی‌ها/مقادیر ورودی باید معتبر باشند تا فیلدهای داخلی به‌درستی مقداردهی شوند.

##### `Execute` (method)

```csharp
public override async Task<QueryResult<TData>> Execute<TQuery, TData>(TQuery query)
```

متد «Execute» در QueryDispatcherValidationDecorator. کوئری/عملیات را به handler مناسب مسیریابی و اجرا می‌کند. جزئیات اجرا را لاگ می‌کند. به‌صورت ناهمگام اجرا می‌شود.
پارامترها:
- query (TQuery): کوئری ورودی برای اجرا.

مقدار بازگشتی: `Task<QueryResult<TData>>` — نتیجه ناهمگام عملیات.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند؛ قبل از Execute باید SetQueryDispatcher فراخوانی شده باشد
انواع مرتبط: QueryDispatcherDecorator (same namespace) | DI: IServiceProvider serviceProvider, ILogger<QueryDispatcherValidationDecorator> logger
