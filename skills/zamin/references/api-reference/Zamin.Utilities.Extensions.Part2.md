# Zamin.Utilities.Extensions (Part 2/4)

مرجع API برای namespace `Zamin.Utilities.Extensions`.

- **Type count (this file):** 2
- **Parts:** [Part 1](./Zamin.Utilities.Extensions.Part1.md) · **Part 2** · [Part 3](./Zamin.Utilities.Extensions.Part3.md) · [Part 4](./Zamin.Utilities.Extensions.Part4.md)

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Utilities.Extensions.LinqExtensions`

- **Kind:** `class`
- **Source:** `Onion/src/1.Utilities/Zamin.Utilities/Extensions/LinqExtensions.cs`

کلاس «LinqExtensions» در namespace Zamin.Utilities.Extensions. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

#### Members

##### `OrderByField` (method)

```csharp
public static IQueryable<T> OrderByField<T>(this IQueryable<T> q, string SortField, bool Ascending)
```

متد «OrderByField» در LinqExtensions. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- q (IQueryable<T>): کوئری ورودی برای اجرا.
- SortField (string): ورودی از نوع string.
- Ascending (bool): ورودی از نوع bool.

مقدار بازگشتی: `IQueryable<T>`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `ToDataTable` (method)

```csharp
public static DataTable ToDataTable<T>(this List<T> list)
```

متد «ToDataTable» در LinqExtensions. تبدیل/نرمال‌سازی داده را طبق نام متد انجام می‌دهد.
پارامترها:
- list (List<T>): ورودی از نوع List<T>.

مقدار بازگشتی: `DataTable`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `ToList` (method)

```csharp
public static List<T> ToList<T>(this DataTable dt)
```

متد «ToList» در LinqExtensions. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- dt (DataTable): ورودی از نوع DataTable.

مقدار بازگشتی: `List<T>`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `WhereIf` (method)

```csharp
public static IQueryable<T> WhereIf<T>(this IQueryable<T> query, bool condition, Expression<Func<T, bool>> predicate)
```

Filters a IQueryable{T} by given predicate if given condition is true.
پارامترها:
- query: Queryable to apply filtering
- condition: A boolean value
- predicate: Predicate to filter the query
مقدار بازگشتی: Filtered or not filtered query based on <paramref name="condition

##### `WhereIf` (method)

```csharp
public static IQueryable<T> WhereIf<T>(this IQueryable<T> query, bool condition, Expression<Func<T, int, bool>> predicate)
```

Filters a IQueryable{T} by given predicate if given condition is true.
پارامترها:
- query: Queryable to apply filtering
- condition: A boolean value
- predicate: Predicate to filter the query
مقدار بازگشتی: Filtered or not filtered query based on <paramref name="condition

### `Zamin.Utilities.Extensions.ObjectExtensions`

- **Kind:** `class`
- **Source:** `Onion/src/1.Utilities/Zamin.Utilities/Extensions/ObjectExtensions.cs`

کلاس «ObjectExtensions» در namespace Zamin.Utilities.Extensions. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

#### Members

##### `ToQueryString` (method)

```csharp
public static string ToQueryString(this object obj)
```

متد «ToQueryString» در ObjectExtensions. تبدیل/نرمال‌سازی داده را طبق نام متد انجام می‌دهد.
پارامترها:
- obj (object): ورودی از نوع object.

مقدار بازگشتی: `string`.
استثناها (قابل تشخیص از کد):
- ArgumentNullException (throw new)
- ArgumentNullException
