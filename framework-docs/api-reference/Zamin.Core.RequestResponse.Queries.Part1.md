# Zamin.Core.RequestResponse.Queries (Part 1/2)

مرجع API برای namespace `Zamin.Core.RequestResponse.Queries`.

- **Type count (this file):** 5
- **Parts:** **Part 1** · [Part 2](./Zamin.Core.RequestResponse.Queries.Part2.md)

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Core.RequestResponse.Queries.IPageQuery<TData>`

- **Kind:** `interface`
- **Base / interfaces:** `IQuery<TData>`
- **Source:** `Onion/src/2.Core/Zamin.Core.RequestResponse/Queries/IPageQuery.cs`

اینترفیسی جهت استفاده به عنوان مارکر برای کلاس‌هایی که پارامتر‌های ورودی را برای جستجو تعیین می‌کنند! در صورتی که جستجو نیاز به صفحه بندی داشته باشد از این اینترفیس استفاده می‌شود

- **Recipe:** [الگوی استفاده مرتبط](../patterns/common-recipes.md#recipe-query-contracts)

#### Members

##### `PageNumber` (property)

```csharp
public int PageNumber { get; set; }
```

شماره صفحه ای که باید اطلاعات از آن بارگذاری شود

##### `PageSize` (property)

```csharp
public int PageSize { get; set; }
```

تعداد رکورد‌های هر صفحه

##### `SkipCount` (property)

```csharp
public int SkipCount => ...
```

تعداد رکورد‌هایی که باید از ابتدای نتیجه رد شود تا به رکوردهای مورد نظر برسیم

##### `NeedTotalCount` (property)

```csharp
public bool NeedTotalCount { get; set; }
```

تعیین اینکه آیا نیاز است تعداد کل رکورد‌های موجود در جستجو نیز بازگردانده شود یا خیر

##### `SortBy` (property)

```csharp
public string SortBy { get; set; }
```

تعیین ستونی که مرتب سازی بر اساس آن انجام می شود

##### `SortAscending` (property)

```csharp
public bool SortAscending { get; set; }
```

جهت مرتب سازی داده‌ها که به صورت صعودی انجام می‌شود یا نزولی

### `Zamin.Core.RequestResponse.Queries.IQuery<TData>`

- **Kind:** `interface`
- **Source:** `Onion/src/2.Core/Zamin.Core.RequestResponse/Queries/IQuery.cs`

اینترفیسی جهت استفاده به عنوان مارکر برای کلاس‌هایی که پارامتر‌های ورودی را برای جستجو تعیین می‌کنند!

- **Recipe:** [الگوی استفاده مرتبط](../patterns/common-recipes.md#recipe-query-contracts)

_اعضای عمومی مستندسازی‌شده در این خروجی وجود ندارد یا استخراج نشده است._

### `Zamin.Core.RequestResponse.Queries.PageQuery<TData>`

- **Kind:** `class`
- **Base / interfaces:** `IPageQuery<TData>`
- **Source:** `Onion/src/2.Core/Zamin.Core.RequestResponse/Queries/PageQuery.cs`

کلاس پایه جهت استفاده به عنوان مارکر برای کلاس‌هایی که پارامتر‌های ورودی را برای جستجو تعیین می‌کنند! در صورتی که جستجو نیاز به صفحه بندی داشته باشد از این اینترفیس استفاده می‌شود

- **Recipe:** [الگوی استفاده مرتبط](../patterns/common-recipes.md#recipe-query-contracts)

#### Members

##### `PageNumber` (property)

```csharp
public int PageNumber { get; set; }
```

شماره صفحه ای که باید اطلاعات از آن بارگذاری شود

##### `PageSize` (property)

```csharp
public int PageSize { get; set; }
```

تعداد رکورد‌های هر صفحه

##### `SkipCount` (property)

```csharp
public int SkipCount => ...
```

تعداد رکورد‌هایی که باید از ابتدای نتیجه رد شود تا به رکوردهای مورد نظر برسیم

##### `NeedTotalCount` (property)

```csharp
public bool NeedTotalCount { get; set; }
```

تعیین اینکه آیا نیاز است تعداد کل رکورد‌های موجود در جستجو نیز بازگردانده شود یا خیر

##### `SortBy` (property)

```csharp
public string SortBy { get; set; }
```

تعیین ستونی که مرتب سازی بر اساس آن انجام می شود

##### `SortAscending` (property)

```csharp
public bool SortAscending { get; set; }
```

جهت مرتب سازی داده‌ها که به صورت صعودی انجام می‌شود یا نزولی

### `Zamin.Core.RequestResponse.Queries.PageQueryRecord<TData>`

- **Kind:** `record`
- **Base / interfaces:** `IPageQuery<TData>`
- **Source:** `Onion/src/2.Core/Zamin.Core.RequestResponse/Queries/PageQuery.cs`

رکورد پایه جهت استفاده به عنوان مارکر برای رکورد‌هایی که پارامتر‌های ورودی را برای جستجو تعیین می‌کنند! در صورتی که جستجو نیاز به صفحه بندی داشته باشد از این اینترفیس استفاده می‌شود

- **Recipe:** [الگوی استفاده مرتبط](../patterns/common-recipes.md#recipe-query-contracts)

#### Members

##### `PageNumber` (property)

```csharp
public int PageNumber { get; set; }
```

شماره صفحه ای که باید اطلاعات از آن بارگذاری شود

##### `PageSize` (property)

```csharp
public int PageSize { get; set; }
```

تعداد رکورد‌های هر صفحه

##### `SkipCount` (property)

```csharp
public int SkipCount => ...
```

تعداد رکورد‌هایی که باید از ابتدای نتیجه رد شود تا به رکوردهای مورد نظر برسیم

##### `NeedTotalCount` (property)

```csharp
public bool NeedTotalCount { get; set; }
```

تعیین اینکه آیا نیاز است تعداد کل رکورد‌های موجود در جستجو نیز بازگردانده شود یا خیر

##### `SortBy` (property)

```csharp
public string SortBy { get; set; }
```

تعیین ستونی که مرتب سازی بر اساس آن انجام می شود

##### `SortAscending` (property)

```csharp
public bool SortAscending { get; set; }
```

جهت مرتب سازی داده‌ها که به صورت صعودی انجام می‌شود یا نزولی

### `Zamin.Core.RequestResponse.Queries.PagedData<T>`

- **Kind:** `class`
- **Source:** `Onion/src/2.Core/Zamin.Core.RequestResponse/Queries/PagedData.cs`

ساختار پایه جهت بازگشت داده‌ها هنگام کوئری گرفتن وقتی که Paging دارد

- **Recipe:** [الگوی استفاده مرتبط](../patterns/common-recipes.md#recipe-query-contracts)

#### Members

##### `QueryResult` (property)

```csharp
public List<T> QueryResult { get; set; }
```

پراپرتی «QueryResult» از نوع `List<T>` در PagedData<T>. کوئری/عملیات را به handler مناسب مسیریابی و اجرا می‌کند. قابل خواندن و نوشتن است.

##### `PageNumber` (property)

```csharp
public int PageNumber { get; set; }
```

پراپرتی «PageNumber» از نوع `int` در PagedData<T>. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `PageSize` (property)

```csharp
public int PageSize { get; set; }
```

پراپرتی «PageSize» از نوع `int` در PagedData<T>. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `TotalCount` (property)

```csharp
public int TotalCount { get; set; }
```

پراپرتی «TotalCount» از نوع `int` در PagedData<T>. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.
