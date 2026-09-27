# Zamin.Infra.Data.Sql.Commands.Interceptors

مرجع API برای namespace `Zamin.Infra.Data.Sql.Commands.Interceptors`.

- **Type count (this file):** 3

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Infra.Data.Sql.Commands.Interceptors.AddAuditDataInterceptor`

- **Kind:** `class`
- **Base / interfaces:** `SaveChangesInterceptor`
- **Source:** `Onion/src/3.Infra/Data/Zamin.Infra.Data.Sql.Commands/Interceptors/AddAuditDataInterceptor.cs`

کلاس «AddAuditDataInterceptor» در namespace Zamin.Infra.Data.Sql.Commands.Interceptors. رهگیر EF/زیرساخت برای اعمال منطق هنگام ذخیره یا تغییر داده. ارث‌بری/پیاده‌سازی: SaveChangesInterceptor. مرتبط: SaveChangesInterceptor.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/common-recipes.md#recipe-ef-interceptors)

#### Members

##### `SavingChanges` (method)

```csharp
public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
```

متد «SavingChanges» در AddAuditDataInterceptor. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- eventData (DbContextEventData): رویداد دامنه/پیام برای پردازش.
- result (InterceptionResult<int>): ورودی از نوع InterceptionResult<int>.

مقدار بازگشتی: `InterceptionResult<int>`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
انواع مرتبط: SaveChangesInterceptor

##### `SavingChangesAsync` (method)

```csharp
public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
```

متد «SavingChangesAsync» در AddAuditDataInterceptor. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- eventData (DbContextEventData): رویداد دامنه/پیام برای پردازش.
- result (InterceptionResult<int>): ورودی از نوع InterceptionResult<int>.
- cancellationToken (CancellationToken): توکن لغو عملیات ناهمگام.

مقدار بازگشتی: `ValueTask<InterceptionResult<int>>` — نتیجه ناهمگام عملیات.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
انواع مرتبط: SaveChangesInterceptor

### `Zamin.Infra.Data.Sql.Commands.Interceptors.AddChangeDataLogInterceptor`

- **Kind:** `class`
- **Base / interfaces:** `SaveChangesInterceptor`
- **Source:** `Extentsions/Databases/Zamin.Extensions.ChangeDataLog/Zamin.Extensions.ChangeDataLog.Hamster/Interceptors/AddChangeDataLogInterceptor.cs`

کلاس «AddChangeDataLogInterceptor» در namespace Zamin.Infra.Data.Sql.Commands.Interceptors. رهگیر EF/زیرساخت برای اعمال منطق هنگام ذخیره یا تغییر داده. ارث‌بری/پیاده‌سازی: SaveChangesInterceptor. مرتبط: SaveChangesInterceptor.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/common-recipes.md#recipe-ef-interceptors)

#### Members

##### `SavingChanges` (method)

```csharp
public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
```

متد «SavingChanges» در AddChangeDataLogInterceptor. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- eventData (DbContextEventData): رویداد دامنه/پیام برای پردازش.
- result (InterceptionResult<int>): ورودی از نوع InterceptionResult<int>.

مقدار بازگشتی: `InterceptionResult<int>`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
انواع مرتبط: SaveChangesInterceptor

##### `SavingChangesAsync` (method)

```csharp
public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
```

متد «SavingChangesAsync» در AddChangeDataLogInterceptor. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- eventData (DbContextEventData): رویداد دامنه/پیام برای پردازش.
- result (InterceptionResult<int>): ورودی از نوع InterceptionResult<int>.
- cancellationToken (CancellationToken): توکن لغو عملیات ناهمگام.

مقدار بازگشتی: `ValueTask<InterceptionResult<int>>` — نتیجه ناهمگام عملیات.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
انواع مرتبط: SaveChangesInterceptor

### `Zamin.Infra.Data.Sql.Commands.Interceptors.SetPersianYeKeInterceptor`

- **Kind:** `class`
- **Base / interfaces:** `DbCommandInterceptor`
- **Source:** `Onion/src/3.Infra/Data/Zamin.Infra.Data.Sql.Commands/Interceptors/SetPersianYeKeInterceptor.cs`

کلاس «SetPersianYeKeInterceptor» در namespace Zamin.Infra.Data.Sql.Commands.Interceptors. رهگیر EF/زیرساخت برای اعمال منطق هنگام ذخیره یا تغییر داده. ارث‌بری/پیاده‌سازی: DbCommandInterceptor. مرتبط: DbCommandInterceptor.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/common-recipes.md#recipe-ef-interceptors)

#### Members

##### `NonQueryExecuting` (method)

```csharp
public override InterceptionResult<int> NonQueryExecuting(DbCommand command, CommandEventData eventData, InterceptionResult<int> result)
```

متد «NonQueryExecuting» در SetPersianYeKeInterceptor. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- command (DbCommand): فرمان ورودی برای اجرا.
- eventData (CommandEventData): رویداد دامنه/پیام برای پردازش.
- result (InterceptionResult<int>): ورودی از نوع InterceptionResult<int>.

مقدار بازگشتی: `InterceptionResult<int>`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
انواع مرتبط: DbCommandInterceptor

##### `NonQueryExecutingAsync` (method)

```csharp
public override ValueTask<InterceptionResult<int>> NonQueryExecutingAsync(DbCommand command, CommandEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
```

متد «NonQueryExecutingAsync» در SetPersianYeKeInterceptor. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- command (DbCommand): فرمان ورودی برای اجرا.
- eventData (CommandEventData): رویداد دامنه/پیام برای پردازش.
- result (InterceptionResult<int>): ورودی از نوع InterceptionResult<int>.
- cancellationToken (CancellationToken): توکن لغو عملیات ناهمگام.

مقدار بازگشتی: `ValueTask<InterceptionResult<int>>` — نتیجه ناهمگام عملیات.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
انواع مرتبط: DbCommandInterceptor

##### `ReaderExecuting` (method)

```csharp
public override InterceptionResult<DbDataReader> ReaderExecuting(DbCommand command, CommandEventData eventData, InterceptionResult<DbDataReader> result)
```

متد «ReaderExecuting» در SetPersianYeKeInterceptor. داده یا وضعیت مرتبط را بازیابی می‌کند.
پارامترها:
- command (DbCommand): فرمان ورودی برای اجرا.
- eventData (CommandEventData): رویداد دامنه/پیام برای پردازش.
- result (InterceptionResult<DbDataReader>): ورودی از نوع InterceptionResult<DbDataReader>.

مقدار بازگشتی: `InterceptionResult<DbDataReader>`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
انواع مرتبط: DbCommandInterceptor

##### `ReaderExecutingAsync` (method)

```csharp
public override ValueTask<InterceptionResult<DbDataReader>> ReaderExecutingAsync(DbCommand command, CommandEventData eventData, InterceptionResult<DbDataReader> result, CancellationToken cancellationToken = default)
```

متد «ReaderExecutingAsync» در SetPersianYeKeInterceptor. داده یا وضعیت مرتبط را بازیابی می‌کند.
پارامترها:
- command (DbCommand): فرمان ورودی برای اجرا.
- eventData (CommandEventData): رویداد دامنه/پیام برای پردازش.
- result (InterceptionResult<DbDataReader>): ورودی از نوع InterceptionResult<DbDataReader>.
- cancellationToken (CancellationToken): توکن لغو عملیات ناهمگام.

مقدار بازگشتی: `ValueTask<InterceptionResult<DbDataReader>>` — نتیجه ناهمگام عملیات.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
انواع مرتبط: DbCommandInterceptor

##### `ScalarExecuting` (method)

```csharp
public override InterceptionResult<object> ScalarExecuting(DbCommand command, CommandEventData eventData, InterceptionResult<object> result)
```

متد «ScalarExecuting» در SetPersianYeKeInterceptor. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- command (DbCommand): فرمان ورودی برای اجرا.
- eventData (CommandEventData): رویداد دامنه/پیام برای پردازش.
- result (InterceptionResult<object>): ورودی از نوع InterceptionResult<object>.

مقدار بازگشتی: `InterceptionResult<object>`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
انواع مرتبط: DbCommandInterceptor

##### `ScalarExecutingAsync` (method)

```csharp
public override ValueTask<InterceptionResult<object>> ScalarExecutingAsync(DbCommand command, CommandEventData eventData, InterceptionResult<object> result, CancellationToken cancellationToken = default)
```

متد «ScalarExecutingAsync» در SetPersianYeKeInterceptor. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- command (DbCommand): فرمان ورودی برای اجرا.
- eventData (CommandEventData): رویداد دامنه/پیام برای پردازش.
- result (InterceptionResult<object>): ورودی از نوع InterceptionResult<object>.
- cancellationToken (CancellationToken): توکن لغو عملیات ناهمگام.

مقدار بازگشتی: `ValueTask<InterceptionResult<object>>` — نتیجه ناهمگام عملیات.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
انواع مرتبط: DbCommandInterceptor
