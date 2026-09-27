# Zamin.EndPoints.Web.Controllers

مرجع API برای namespace `Zamin.EndPoints.Web.Controllers`.

- **Type count (this file):** 1

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.EndPoints.Web.Controllers.BaseController`

- **Kind:** `class`
- **Base / interfaces:** `Controller`
- **Source:** `Onion/src/4.EndPoints/Zamin.EndPoints.Web/Controllers/BaseController.cs`

کلاس «BaseController» در namespace Zamin.EndPoints.Web.Controllers. کنترلر endpoint برای دریافت درخواست HTTP و ارجاع به لایه اپلیکیشن. ارث‌بری/پیاده‌سازی: Controller. مرتبط: Controller.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/common-recipes.md#recipe-base-controller)

#### Members

##### `CommandDispatcher` (property)

```csharp
protected ICommandDispatcher CommandDispatcher => ...
```

پراپرتی «CommandDispatcher» از نوع `ICommandDispatcher` در BaseController. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. منطق دسترسی از روی بدنه accessor قابل مشاهده است.

##### `QueryDispatcher` (property)

```csharp
protected IQueryDispatcher QueryDispatcher => ...
```

پراپرتی «QueryDispatcher» از نوع `IQueryDispatcher` در BaseController. کوئری/عملیات را به handler مناسب مسیریابی و اجرا می‌کند. منطق دسترسی از روی بدنه accessor قابل مشاهده است.

##### `EventDispatcher` (property)

```csharp
protected IEventDispatcher EventDispatcher => ...
```

پراپرتی «EventDispatcher» از نوع `IEventDispatcher` در BaseController. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. منطق دسترسی از روی بدنه accessor قابل مشاهده است.

##### `ZaminApplicationContext` (property)

```csharp
protected ZaminServices ZaminApplicationContext => ...
```

پراپرتی «ZaminApplicationContext» از نوع `ZaminServices` در BaseController. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. منطق دسترسی از روی بدنه accessor قابل مشاهده است.

##### `Excel` (method)

```csharp
public IActionResult Excel<T>(List<T> list)
```

متد «Excel» در BaseController. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد. handler/سرویس را از DI با GetRequiredService برمی‌دارد.
پارامترها:
- list (List<T>): ورودی از نوع List<T>.

مقدار بازگشتی: `IActionResult`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: سرویس/handler مربوطه باید در DI ثبت شده باشد وگرنه InvalidOperationException رخ می‌دهد
انواع مرتبط: Controller

##### `Excel` (method)

```csharp
public IActionResult Excel<T>(List<T> list, string fileName)
```

متد «Excel» در BaseController. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد. handler/سرویس را از DI با GetRequiredService برمی‌دارد.
پارامترها:
- list (List<T>): ورودی از نوع List<T>.
- fileName (string): ورودی از نوع string.

مقدار بازگشتی: `IActionResult`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: سرویس/handler مربوطه باید در DI ثبت شده باشد وگرنه InvalidOperationException رخ می‌دهد
انواع مرتبط: Controller

##### `Create` (method)

```csharp
protected async Task<IActionResult> Create<TCommand, TCommandResult>(TCommand command) where TCommand : class, ICommand<TCommandResult>
```

متد «Create» در BaseController. نمونه یا نتیجه جدیدی می‌سازد. به‌صورت ناهمگام اجرا می‌شود.
پارامترها:
- command (TCommand): فرمان ورودی برای اجرا.

مقدار بازگشتی: `Task<IActionResult>` — نتیجه ناهمگام عملیات.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
انواع مرتبط: Controller

##### `Create` (method)

```csharp
protected async Task<IActionResult> Create<TCommand>(TCommand command) where TCommand : class, ICommand
```

متد «Create» در BaseController. نمونه یا نتیجه جدیدی می‌سازد. به‌صورت ناهمگام اجرا می‌شود.
پارامترها:
- command (TCommand): فرمان ورودی برای اجرا.

مقدار بازگشتی: `Task<IActionResult>` — نتیجه ناهمگام عملیات.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
انواع مرتبط: Controller

##### `Edit` (method)

```csharp
protected async Task<IActionResult> Edit<TCommand, TCommandResult>(TCommand command) where TCommand : class, ICommand<TCommandResult>
```

متد «Edit» در BaseController. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد. به‌صورت ناهمگام اجرا می‌شود.
پارامترها:
- command (TCommand): فرمان ورودی برای اجرا.

مقدار بازگشتی: `Task<IActionResult>` — نتیجه ناهمگام عملیات.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
انواع مرتبط: Controller

##### `Edit` (method)

```csharp
protected async Task<IActionResult> Edit<TCommand>(TCommand command) where TCommand : class, ICommand
```

متد «Edit» در BaseController. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد. به‌صورت ناهمگام اجرا می‌شود.
پارامترها:
- command (TCommand): فرمان ورودی برای اجرا.

مقدار بازگشتی: `Task<IActionResult>` — نتیجه ناهمگام عملیات.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
انواع مرتبط: Controller

##### `Delete` (method)

```csharp
protected async Task<IActionResult> Delete<TCommand, TCommandResult>(TCommand command) where TCommand : class, ICommand<TCommandResult>
```

متد «Delete» در BaseController. مورد یا وضعیت را حذف/پاک می‌کند. به‌صورت ناهمگام اجرا می‌شود.
پارامترها:
- command (TCommand): فرمان ورودی برای اجرا.

مقدار بازگشتی: `Task<IActionResult>` — نتیجه ناهمگام عملیات.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
انواع مرتبط: Controller

##### `Delete` (method)

```csharp
protected async Task<IActionResult> Delete<TCommand>(TCommand command) where TCommand : class, ICommand
```

متد «Delete» در BaseController. مورد یا وضعیت را حذف/پاک می‌کند. به‌صورت ناهمگام اجرا می‌شود.
پارامترها:
- command (TCommand): فرمان ورودی برای اجرا.

مقدار بازگشتی: `Task<IActionResult>` — نتیجه ناهمگام عملیات.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
انواع مرتبط: Controller

##### `Query` (method)

```csharp
protected async Task<IActionResult> Query<TQuery, TQueryResult>(TQuery query) where TQuery : class, IQuery<TQueryResult>
```

متد «Query» در BaseController. کوئری/عملیات را به handler مناسب مسیریابی و اجرا می‌کند. به‌صورت ناهمگام اجرا می‌شود.
پارامترها:
- query (TQuery): کوئری ورودی برای اجرا.

مقدار بازگشتی: `Task<IActionResult>` — نتیجه ناهمگام عملیات.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
انواع مرتبط: Controller
