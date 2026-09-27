# Zamin.Core.Contracts.ApplicationServices.Queries

مرجع API برای namespace `Zamin.Core.Contracts.ApplicationServices.Queries`.

- **Type count (this file):** 2

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Core.Contracts.ApplicationServices.Queries.IQueryDispatcher`

- **Kind:** `interface`
- **Source:** `Onion/src/2.Core/Zamin.Core.Contracts/ApplicationServices/Queries/IQueryDispatcher.cs`

تعریف ساختار الگوی Mediator جهت اتصال ساده کوئری‌ها به هندلر‌ها

- **Recipe:** [الگوی استفاده مرتبط](../patterns/common-recipes.md#recipe-query-dispatcher)

#### Members

##### `Execute` (method)

```csharp
Task<QueryResult<TData>> Execute<TQuery, TData>(TQuery query) where TQuery : class, IQuery<TData>
```

متد «Execute» در IQueryDispatcher. کوئری/عملیات را به handler مناسب مسیریابی و اجرا می‌کند.
پارامترها:
- query (TQuery): کوئری ورودی برای اجرا.

مقدار بازگشتی: `Task<QueryResult<TData>>` — نتیجه ناهمگام عملیات.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

### `Zamin.Core.Contracts.ApplicationServices.Queries.IQueryHandler<TQuery, TData>`

- **Kind:** `interface`
- **Constraints:** `where TQuery : class, IQuery<TData>`
- **Source:** `Onion/src/2.Core/Zamin.Core.Contracts/ApplicationServices/Queries/IQueryHandler.cs`

تعریف ساختار مورد نیاز جهت پردازش یک کورئری

- **Recipe:** [الگوی استفاده مرتبط](../patterns/common-recipes.md#recipe-query-dispatcher)

#### Members

##### `Handle` (method)

```csharp
Task<QueryResult<TData>> Handle(TQuery request)
```

متد «Handle» در IQueryHandler<TQuery, TData>. منطق اصلی پردازش درخواست/رویداد را اجرا می‌کند.
پارامترها:
- request (TQuery): ورودی از نوع TQuery.

مقدار بازگشتی: `Task<QueryResult<TData>>` — نتیجه ناهمگام عملیات.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
