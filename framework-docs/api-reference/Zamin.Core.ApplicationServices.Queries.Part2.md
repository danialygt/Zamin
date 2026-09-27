# Zamin.Core.ApplicationServices.Queries (Part 2/2)

مرجع API برای namespace `Zamin.Core.ApplicationServices.Queries`.

- **Type count (this file):** 1
- **Parts:** [Part 1](./Zamin.Core.ApplicationServices.Queries.Part1.md) · **Part 2**

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Core.ApplicationServices.Queries.QueryHandler<TQuery, TData>`

- **Kind:** `class`
- **Base / interfaces:** `IQueryHandler<TQuery, TData>`
- **Constraints:** `where TQuery : class, IQuery<TData>`
- **Source:** `Onion/src/2.Core/Zamin.Core.ApplicationServices/Queries/QueryHandler.cs`

کلاس «QueryHandler<TQuery, TData>» در namespace Zamin.Core.ApplicationServices.Queries. پیاده‌سازی use-case یا واکنش به رویداد. ارث‌بری/پیاده‌سازی: IQueryHandler<TQuery, TData>. قیود جنریک: where TQuery : class, IQuery<TData>. وابستگی‌های سازنده (DI): ZaminServices zaminServices. مرتبط: IQueryHandler<TQuery, TData> | DI: ZaminServices zaminServices.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/common-recipes.md#recipe-query-handler)

#### Members

##### `_zaminServices` (field)

```csharp
protected readonly ZaminServices _zaminServices;
```

فیلد «_zaminServices» در QueryHandler<TQuery, TData> با امضای `protected readonly ZaminServices _zaminServices;`. برای نگهداری وضعیت داخلی/قابل‌دسترس نوع استفاده می‌شود.

##### `result` (field)

```csharp
protected readonly QueryResult<TData> result = new();
```

فیلد «result» در QueryHandler<TQuery, TData> با امضای `protected readonly QueryResult<TData> result = new();`. برای نگهداری وضعیت داخلی/قابل‌دسترس نوع استفاده می‌شود.

##### `ResultAsync` (method)

```csharp
protected virtual Task<QueryResult<TData>> ResultAsync(TData data, ApplicationServiceStatus status)
```

متد «ResultAsync» در QueryHandler<TQuery, TData>. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- data (TData): ورودی از نوع TData.
- status (ApplicationServiceStatus): ورودی از نوع ApplicationServiceStatus.

مقدار بازگشتی: `Task<QueryResult<TData>>` — نتیجه ناهمگام عملیات.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: IQueryHandler<TQuery, TData> | DI: ZaminServices zaminServices

##### `Result` (method)

```csharp
protected virtual QueryResult<TData> Result(TData data, ApplicationServiceStatus status)
```

متد «Result» در QueryHandler<TQuery, TData>. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- data (TData): ورودی از نوع TData.
- status (ApplicationServiceStatus): ورودی از نوع ApplicationServiceStatus.

مقدار بازگشتی: `QueryResult<TData>`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: IQueryHandler<TQuery, TData> | DI: ZaminServices zaminServices

##### `ResultAsync` (method)

```csharp
protected virtual Task<QueryResult<TData>> ResultAsync(TData data)
```

متد «ResultAsync» در QueryHandler<TQuery, TData>. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- data (TData): ورودی از نوع TData.

مقدار بازگشتی: `Task<QueryResult<TData>>` — نتیجه ناهمگام عملیات.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: IQueryHandler<TQuery, TData> | DI: ZaminServices zaminServices

##### `Result` (method)

```csharp
protected virtual QueryResult<TData> Result(TData data)
```

متد «Result» در QueryHandler<TQuery, TData>. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- data (TData): ورودی از نوع TData.

مقدار بازگشتی: `QueryResult<TData>`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: IQueryHandler<TQuery, TData> | DI: ZaminServices zaminServices

##### `.ctor` (constructor)

```csharp
public QueryHandler(ZaminServices zaminServices)
```

سازنده QueryHandler<TQuery, TData>. پارامترها از طریق تزریق وابستگی تأمین می‌شوند. پارامترها:
- zaminServices (ZaminServices): بسته‌ی سرویس‌های مشترک زمین (ترجمه، کاربر، و ...).
پیش‌شرط: وابستگی‌ها/مقادیر ورودی باید معتبر باشند تا فیلدهای داخلی به‌درستی مقداردهی شوند.

##### `AddMessage` (method)

```csharp
protected void AddMessage(string message)
```

متد «AddMessage» در QueryHandler<TQuery, TData>. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- message (string): پیام متنی خطا یا توضیح نقض شرط.

مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: IQueryHandler<TQuery, TData> | DI: ZaminServices zaminServices

##### `AddMessage` (method)

```csharp
protected void AddMessage(string message, params string[] arguments)
```

متد «AddMessage» در QueryHandler<TQuery, TData>. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- message (string): پیام متنی خطا یا توضیح نقض شرط.

مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: IQueryHandler<TQuery, TData> | DI: ZaminServices zaminServices

##### `Handle` (method)

```csharp
public abstract Task<QueryResult<TData>> Handle(TQuery query)
```

متد «Handle» در QueryHandler<TQuery, TData>. منطق اصلی پردازش درخواست/رویداد را اجرا می‌کند.
پارامترها:
- query (TQuery): کوئری ورودی برای اجرا.

مقدار بازگشتی: `Task<QueryResult<TData>>` — نتیجه ناهمگام عملیات.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: IQueryHandler<TQuery, TData> | DI: ZaminServices zaminServices
