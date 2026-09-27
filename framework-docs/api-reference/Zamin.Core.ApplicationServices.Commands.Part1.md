# Zamin.Core.ApplicationServices.Commands (Part 1/3)

مرجع API برای namespace `Zamin.Core.ApplicationServices.Commands`.

- **Type count (this file):** 3
- **Parts:** **Part 1** · [Part 2](./Zamin.Core.ApplicationServices.Commands.Part2.md) · [Part 3](./Zamin.Core.ApplicationServices.Commands.Part3.md)

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Core.ApplicationServices.Commands.CommandDispatcher`

- **Kind:** `class`
- **Base / interfaces:** `ICommandDispatcher`
- **Source:** `Onion/src/2.Core/Zamin.Core.ApplicationServices/Commands/CommandDispatcher.cs`

کلاس «CommandDispatcher» در namespace Zamin.Core.ApplicationServices.Commands. مسئول یافتن و فراخوانی handler مناسب برای فرمان/کوئری/رویداد. ارث‌بری/پیاده‌سازی: ICommandDispatcher. وابستگی‌های سازنده (DI): IServiceProvider serviceProvider, ILogger<CommandDispatcher> logger. مرتبط: ICommandDispatcher | DI: IServiceProvider serviceProvider, ILogger<CommandDispatcher> logger.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/common-recipes.md#recipe-command-handler)

#### Members

##### `.ctor` (constructor)

```csharp
public CommandDispatcher(IServiceProvider serviceProvider, ILogger<CommandDispatcher> logger)
```

سازنده CommandDispatcher. پارامترها از طریق تزریق وابستگی تأمین می‌شوند. پارامترها:
- serviceProvider (IServiceProvider): ارائه‌دهنده سرویس برای resolve کردن وابستگی‌ها.
- logger (ILogger<CommandDispatcher>): لاگر برای ثبت رویدادها و خطاها.
پیش‌شرط: وابستگی‌ها/مقادیر ورودی باید معتبر باشند تا فیلدهای داخلی به‌درستی مقداردهی شوند.

##### `Send` (method)

```csharp
public async Task<CommandResult> Send<TCommand>(TCommand command) where TCommand : class, ICommand
```

متد Send فرمان بدون دادهٔ بازگشتی را به ICommandHandler<TCommand> مسیریابی می‌کند.
پارامترها:
- command (TCommand): فرمان ورودی که باید class و ICommand باشد.
مقدار بازگشتی: Task<CommandResult> نتیجه اجرای handler.
استثناها (قابل تشخیص از کد):
- InvalidOperationException: وقتی handler متناظر در DI ثبت نشده باشد (GetRequiredService)؛ پس از لاگ خطا دوباره throw می‌شود.
سایر استثناهای handler نیز به بالا منتشر می‌شوند.
پیش‌شرط/وابستگی: ICommandHandler<TCommand> باید در DI ثبت شده باشد؛ نمونه CommandDispatcher باید از DI ساخته شود (IServiceProvider، ILogger).
در finally مدت اجرا با Stopwatch اندازه‌گیری و لاگ performance ثبت می‌شود.

##### `Send` (method)

```csharp
public async Task<CommandResult<TData>> Send<TCommand, TData>(TCommand command) where TCommand : class, ICommand<TData>
```

متد Send فرمان دارای دادهٔ بازگشتی را به ICommandHandler<TCommand, TData> مسیریابی می‌کند.
پارامترها:
- command (TCommand): فرمان ورودی که ICommand<TData> را پیاده می‌کند.
مقدار بازگشتی: Task<CommandResult<TData>> شامل وضعیت و دادهٔ نتیجه.
استثناها (قابل تشخیص از کد):
- هر Exception از resolve/اجرای handler لاگ و سپس دوباره throw می‌شود (برخلاف overload بدون TData که فقط InvalidOperationException را catch می‌کند).
پیش‌شرط/وابستگی: ثبت ICommandHandler<TCommand, TData> در DI؛ ساخت Dispatcher از DI.

### `Zamin.Core.ApplicationServices.Commands.CommandDispatcherDecorator`

- **Kind:** `class`
- **Base / interfaces:** `ICommandDispatcher`
- **Source:** `Onion/src/2.Core/Zamin.Core.ApplicationServices/Commands/CommandDispatcherDecorator.cs`

کلاس «CommandDispatcherDecorator» در namespace Zamin.Core.ApplicationServices.Commands. مسئول یافتن و فراخوانی handler مناسب برای فرمان/کوئری/رویداد. ارث‌بری/پیاده‌سازی: ICommandDispatcher. مرتبط: ICommandDispatcher.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/common-recipes.md#recipe-command-handler)

#### Members

##### `_commandDispatcher` (field)

```csharp
protected ICommandDispatcher _commandDispatcher;
```

فیلد «_commandDispatcher» در CommandDispatcherDecorator با امضای `protected ICommandDispatcher _commandDispatcher;`. برای نگهداری وضعیت داخلی/قابل‌دسترس نوع استفاده می‌شود.

##### `Order` (property)

```csharp
public abstract int Order { get; }
```

پراپرتی «Order» از نوع `int` در CommandDispatcherDecorator. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. فقط‌خواندنی است.

##### `.ctor` (constructor)

```csharp
public CommandDispatcherDecorator()
```

سازنده CommandDispatcherDecorator. بدون پارامتر؛ معمولاً برای ORM، serialization یا مقداردهی اولیه محافظت‌شده استفاده می‌شود.

##### `SetCommandDispatcher` (method)

```csharp
public void SetCommandDispatcher(ICommandDispatcher commandDispatcher)
```

متد «SetCommandDispatcher» در CommandDispatcherDecorator. وضعیت را به‌روز یا ذخیره می‌کند.
پارامترها:
- commandDispatcher (ICommandDispatcher): فرمان ورودی برای اجرا.

مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: قبل از Send باید SetCommandDispatcher فراخوانی شده باشد
انواع مرتبط: ICommandDispatcher

##### `Send` (method)

```csharp
public abstract Task<CommandResult> Send<TCommand>(TCommand command) where TCommand : class, ICommand
```

متد «Send» در CommandDispatcherDecorator. درخواست را به handler مناسب مسیریابی و اجرا می‌کند.
پارامترها:
- command (TCommand): فرمان ورودی برای اجرا.

مقدار بازگشتی: `Task<CommandResult>` — نتیجه ناهمگام عملیات.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
انواع مرتبط: ICommandDispatcher

##### `Send` (method)

```csharp
public abstract Task<CommandResult<TData>> Send<TCommand, TData>(TCommand command) where TCommand : class, ICommand<TData>
```

متد «Send» در CommandDispatcherDecorator. درخواست را به handler مناسب مسیریابی و اجرا می‌کند.
پارامترها:
- command (TCommand): فرمان ورودی برای اجرا.

مقدار بازگشتی: `Task<CommandResult<TData>>` — نتیجه ناهمگام عملیات.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
انواع مرتبط: ICommandDispatcher

### `Zamin.Core.ApplicationServices.Commands.CommandDispatcherDomainExceptionHandlerDecorator`

- **Kind:** `class`
- **Base / interfaces:** `CommandDispatcherDecorator`
- **Source:** `Onion/src/2.Core/Zamin.Core.ApplicationServices/Commands/CommandDispatcherDomainExceptionHandlerDecorator.cs`

کلاس «CommandDispatcherDomainExceptionHandlerDecorator» در namespace Zamin.Core.ApplicationServices.Commands. مسئول یافتن و فراخوانی handler مناسب برای فرمان/کوئری/رویداد. ارث‌بری/پیاده‌سازی: CommandDispatcherDecorator. وابستگی‌های سازنده (DI): IServiceProvider serviceProvider, ILogger<CommandDispatcherDomainExceptionHandlerDecorator> logger. مرتبط: CommandDispatcherDecorator (same namespace) | DI: IServiceProvider serviceProvider, ILogger<CommandDispatcherDomainExceptionHandlerDecorator> logger.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/common-recipes.md#recipe-command-handler)

#### Members

##### `.ctor` (constructor)

```csharp
public CommandDispatcherDomainExceptionHandlerDecorator(IServiceProvider serviceProvider,
                                                            ILogger<CommandDispatcherDomainExceptionHandlerDecorator> logger)
```

سازنده CommandDispatcherDomainExceptionHandlerDecorator. پارامترها از طریق تزریق وابستگی تأمین می‌شوند. پارامترها:
- serviceProvider (IServiceProvider): ارائه‌دهنده سرویس برای resolve کردن وابستگی‌ها.
- logger (ILogger<CommandDispatcherDomainExceptionHandlerDecorator>): لاگر برای ثبت رویدادها و خطاها.
پیش‌شرط: وابستگی‌ها/مقادیر ورودی باید معتبر باشند تا فیلدهای داخلی به‌درستی مقداردهی شوند.

##### `Order` (property)

```csharp
public override int Order => ...
```

پراپرتی «Order» از نوع `int` در CommandDispatcherDomainExceptionHandlerDecorator. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. منطق دسترسی از روی بدنه accessor قابل مشاهده است.

##### `Send` (method)

```csharp
public override async Task<CommandResult> Send<TCommand>(TCommand command)
```

دکوریتور مدیریت DomainStateException: Send داخلی را فراخوانی می‌کند؛ اگر DomainStateException (یا AggregateException با Inner از همان نوع) رخ دهد، آن را به CommandResult با Status=InvalidDomainState و پیام ترجمه‌شده (ITranslator در صورت وجود) تبدیل می‌کند به‌جای پرتاب استثنا. سایر AggregateExceptionها دوباره throw می‌شوند.
پارامترها:
- command (TCommand): فرمان در حال اجرا.
مقدار بازگشتی: Task<CommandResult> موفق یا معادل خطای دامنه.
استثناها: DomainStateException بلعیده و به نتیجه تبدیل می‌شود؛ سایر استثناها propagate می‌شوند.
پیش‌شرط: SetCommandDispatcher؛ Order = 2. وابستگی اختیاری ITranslator برای متن پیام.

##### `Send` (method)

```csharp
public override async Task<CommandResult<TData>> Send<TCommand, TData>(TCommand command)
```

نسخهٔ دارای TData از دکوریتور DomainStateException؛ خطاهای دامنه به CommandResult<TData> با InvalidDomainState نگاشت می‌شوند.
پارامترها:
- command (TCommand): فرمان ICommand<TData>.
مقدار بازگشتی: Task<CommandResult<TData>>.
پیش‌شرط: SetCommandDispatcher؛ Order = 2.
