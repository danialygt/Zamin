# Zamin.Core.ApplicationServices.Commands (Part 2/3)

مرجع API برای namespace `Zamin.Core.ApplicationServices.Commands`.

- **Type count (this file):** 2
- **Parts:** [Part 1](./Zamin.Core.ApplicationServices.Commands.Part1.md) · **Part 2** · [Part 3](./Zamin.Core.ApplicationServices.Commands.Part3.md)

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Core.ApplicationServices.Commands.CommandDispatcherValidationDecorator`

- **Kind:** `class`
- **Base / interfaces:** `CommandDispatcherDecorator`
- **Source:** `Onion/src/2.Core/Zamin.Core.ApplicationServices/Commands/CommandDispatcherValidationDecorator.cs`

کلاس «CommandDispatcherValidationDecorator» در namespace Zamin.Core.ApplicationServices.Commands. مسئول یافتن و فراخوانی handler مناسب برای فرمان/کوئری/رویداد. ارث‌بری/پیاده‌سازی: CommandDispatcherDecorator. وابستگی‌های سازنده (DI): IServiceProvider serviceProvider, ILogger<CommandDispatcherValidationDecorator> logger. مرتبط: CommandDispatcherDecorator (same namespace) | DI: IServiceProvider serviceProvider, ILogger<CommandDispatcherValidationDecorator> logger.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/common-recipes.md#recipe-command-handler)

#### Members

##### `.ctor` (constructor)

```csharp
public CommandDispatcherValidationDecorator(IServiceProvider serviceProvider,
                                                ILogger<CommandDispatcherValidationDecorator> logger)
```

سازنده CommandDispatcherValidationDecorator. پارامترها از طریق تزریق وابستگی تأمین می‌شوند. پارامترها:
- serviceProvider (IServiceProvider): ارائه‌دهنده سرویس برای resolve کردن وابستگی‌ها.
- logger (ILogger<CommandDispatcherValidationDecorator>): لاگر برای ثبت رویدادها و خطاها.
پیش‌شرط: وابستگی‌ها/مقادیر ورودی باید معتبر باشند تا فیلدهای داخلی به‌درستی مقداردهی شوند.

##### `Order` (property)

```csharp
public override int Order => ...
```

پراپرتی «Order» از نوع `int` در CommandDispatcherValidationDecorator. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. منطق دسترسی از روی بدنه accessor قابل مشاهده است.

##### `Send` (method)

```csharp
public override async Task<CommandResult> Send<TCommand>(TCommand command)
```

دکوریتور اعتبارسنجی قبل از ارسال فرمان: اگر IValidator<TCommand> در DI باشد، Validate اجرا می‌شود؛ در صورت نامعتبر بودن، CommandResult با Status=ValidationError و پیام‌های FluentValidation برمی‌گردد و Send داخلی فراخوانی نمی‌شود. اگر validator نباشد فقط لاگ می‌شود و فرمان ادامه می‌یابد.
پارامترها:
- command (TCommand): فرمان برای اعتبارسنجی و اجرا.
مقدار بازگشتی: Task<CommandResult> (خطای اعتبارسنجی یا نتیجه dispatcher داخلی).
استثناها: استثنای صریح در این متد نیست؛ خطاهای validator به‌صورت نتیجه برمی‌گردند. خطاهای لایه بعدی ممکن است throw شوند.
پیش‌شرط: SetCommandDispatcher باید قبلاً فراخوانی شده باشد؛ Order این دکوریتور = 1 (قبل از DomainException handler).

##### `Send` (method)

```csharp
public override async Task<CommandResult<TData>> Send<TCommand, TData>(TCommand command)
```

همان منطق اعتبارسنجی دکوریتور برای فرمان‌های دارای TData؛ در خطا CommandResult<TData> با ValidationError برمی‌گردد، در موفقیت به _commandDispatcher.Send<TCommand,TData> تفویض می‌شود.
پارامترها:
- command (TCommand): فرمان ICommand<TData>.
مقدار بازگشتی: Task<CommandResult<TData>>.
پیش‌شرط: SetCommandDispatcher؛ ثبت اختیاری IValidator<TCommand>.

### `Zamin.Core.ApplicationServices.Commands.CommandHandler<TCommand, TData>`

- **Kind:** `class`
- **Base / interfaces:** `ICommandHandler<TCommand, TData>`
- **Constraints:** `where TCommand : ICommand<TData>`
- **Source:** `Onion/src/2.Core/Zamin.Core.ApplicationServices/Commands/CommandHandler.cs`

کلاس «CommandHandler<TCommand, TData>» در namespace Zamin.Core.ApplicationServices.Commands. پیاده‌سازی use-case یا واکنش به رویداد. ارث‌بری/پیاده‌سازی: ICommandHandler<TCommand, TData>. قیود جنریک: where TCommand : ICommand<TData>. وابستگی‌های سازنده (DI): ZaminServices zaminServices. مرتبط: ICommandHandler<TCommand, TData> | DI: ZaminServices zaminServices.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/common-recipes.md#recipe-command-handler)

#### Members

##### `_zaminServices` (field)

```csharp
protected readonly ZaminServices _zaminServices;
```

فیلد «_zaminServices» در CommandHandler<TCommand, TData> با امضای `protected readonly ZaminServices _zaminServices;`. برای نگهداری وضعیت داخلی/قابل‌دسترس نوع استفاده می‌شود.

##### `result` (field)

```csharp
protected readonly CommandResult<TData> result = new();
```

فیلد «result» در CommandHandler<TCommand, TData> با امضای `protected readonly CommandResult<TData> result = new();`. برای نگهداری وضعیت داخلی/قابل‌دسترس نوع استفاده می‌شود.

##### `.ctor` (constructor)

```csharp
public CommandHandler(ZaminServices zaminServices)
```

سازنده CommandHandler<TCommand, TData>. پارامترها از طریق تزریق وابستگی تأمین می‌شوند. پارامترها:
- zaminServices (ZaminServices): بسته‌ی سرویس‌های مشترک زمین (ترجمه، کاربر، و ...).
پیش‌شرط: وابستگی‌ها/مقادیر ورودی باید معتبر باشند تا فیلدهای داخلی به‌درستی مقداردهی شوند.

##### `Handle` (method)

```csharp
public abstract Task<CommandResult<TData>> Handle(TCommand command)
```

متد «Handle» در CommandHandler<TCommand, TData>. منطق اصلی پردازش درخواست/رویداد را اجرا می‌کند.
پارامترها:
- command (TCommand): فرمان ورودی برای اجرا.

مقدار بازگشتی: `Task<CommandResult<TData>>` — نتیجه ناهمگام عملیات.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: ICommandHandler<TCommand, TData> | DI: ZaminServices zaminServices

##### `OkAsync` (method)

```csharp
protected virtual Task<CommandResult<TData>> OkAsync(TData data)
```

متد «OkAsync» در CommandHandler<TCommand, TData>. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- data (TData): ورودی از نوع TData.

مقدار بازگشتی: `Task<CommandResult<TData>>` — نتیجه ناهمگام عملیات.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: ICommandHandler<TCommand, TData> | DI: ZaminServices zaminServices

##### `Ok` (method)

```csharp
protected virtual CommandResult<TData> Ok(TData data)
```

متد «Ok» در CommandHandler<TCommand, TData>. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- data (TData): ورودی از نوع TData.

مقدار بازگشتی: `CommandResult<TData>`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: ICommandHandler<TCommand, TData> | DI: ZaminServices zaminServices

##### `ResultAsync` (method)

```csharp
protected virtual Task<CommandResult<TData>> ResultAsync(TData data, ApplicationServiceStatus status)
```

متد «ResultAsync» در CommandHandler<TCommand, TData>. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- data (TData): ورودی از نوع TData.
- status (ApplicationServiceStatus): ورودی از نوع ApplicationServiceStatus.

مقدار بازگشتی: `Task<CommandResult<TData>>` — نتیجه ناهمگام عملیات.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: ICommandHandler<TCommand, TData> | DI: ZaminServices zaminServices

##### `Result` (method)

```csharp
protected virtual CommandResult<TData> Result(TData data, ApplicationServiceStatus status)
```

متد «Result» در CommandHandler<TCommand, TData>. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- data (TData): ورودی از نوع TData.
- status (ApplicationServiceStatus): ورودی از نوع ApplicationServiceStatus.

مقدار بازگشتی: `CommandResult<TData>`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: ICommandHandler<TCommand, TData> | DI: ZaminServices zaminServices

##### `AddMessage` (method)

```csharp
protected void AddMessage(string message)
```

متد «AddMessage» در CommandHandler<TCommand, TData>. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- message (string): پیام متنی خطا یا توضیح نقض شرط.

مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: ICommandHandler<TCommand, TData> | DI: ZaminServices zaminServices

##### `AddMessage` (method)

```csharp
protected void AddMessage(string message, params string[] arguments)
```

متد «AddMessage» در CommandHandler<TCommand, TData>. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- message (string): پیام متنی خطا یا توضیح نقض شرط.

مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: ICommandHandler<TCommand, TData> | DI: ZaminServices zaminServices
