# Zamin.Core.ApplicationServices.Commands (Part 3/3)

مرجع API برای namespace `Zamin.Core.ApplicationServices.Commands`.

- **Type count (this file):** 1
- **Parts:** [Part 1](./Zamin.Core.ApplicationServices.Commands.Part1.md) · [Part 2](./Zamin.Core.ApplicationServices.Commands.Part2.md) · **Part 3**

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Core.ApplicationServices.Commands.CommandHandler<TCommand>`

- **Kind:** `class`
- **Base / interfaces:** `ICommandHandler<TCommand>`
- **Constraints:** `where TCommand : ICommand`
- **Source:** `Onion/src/2.Core/Zamin.Core.ApplicationServices/Commands/CommandHandler.cs`

کلاس «CommandHandler<TCommand>» در namespace Zamin.Core.ApplicationServices.Commands. پیاده‌سازی use-case یا واکنش به رویداد. ارث‌بری/پیاده‌سازی: ICommandHandler<TCommand>. قیود جنریک: where TCommand : ICommand. وابستگی‌های سازنده (DI): ZaminServices zaminServices. مرتبط: ICommandHandler<TCommand> | DI: ZaminServices zaminServices.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/common-recipes.md#recipe-command-handler)

#### Members

##### `_zaminServices` (field)

```csharp
protected readonly ZaminServices _zaminServices;
```

فیلد «_zaminServices» در CommandHandler<TCommand> با امضای `protected readonly ZaminServices _zaminServices;`. برای نگهداری وضعیت داخلی/قابل‌دسترس نوع استفاده می‌شود.

##### `result` (field)

```csharp
protected readonly CommandResult result = new();
```

فیلد «result» در CommandHandler<TCommand> با امضای `protected readonly CommandResult result = new();`. برای نگهداری وضعیت داخلی/قابل‌دسترس نوع استفاده می‌شود.

##### `.ctor` (constructor)

```csharp
public CommandHandler(ZaminServices zaminServices)
```

سازنده CommandHandler<TCommand>. پارامترها از طریق تزریق وابستگی تأمین می‌شوند. پارامترها:
- zaminServices (ZaminServices): بسته‌ی سرویس‌های مشترک زمین (ترجمه، کاربر، و ...).
پیش‌شرط: وابستگی‌ها/مقادیر ورودی باید معتبر باشند تا فیلدهای داخلی به‌درستی مقداردهی شوند.

##### `Handle` (method)

```csharp
public abstract Task<CommandResult> Handle(TCommand command)
```

متد «Handle» در CommandHandler<TCommand>. منطق اصلی پردازش درخواست/رویداد را اجرا می‌کند.
پارامترها:
- command (TCommand): فرمان ورودی برای اجرا.

مقدار بازگشتی: `Task<CommandResult>` — نتیجه ناهمگام عملیات.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: ICommandHandler<TCommand> | DI: ZaminServices zaminServices

##### `OkAsync` (method)

```csharp
protected virtual Task<CommandResult> OkAsync()
```

متد «OkAsync» در CommandHandler<TCommand>. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
بدون پارامتر ورودی.
مقدار بازگشتی: `Task<CommandResult>` — نتیجه ناهمگام عملیات.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: ICommandHandler<TCommand> | DI: ZaminServices zaminServices

##### `Ok` (method)

```csharp
protected virtual CommandResult Ok()
```

متد «Ok» در CommandHandler<TCommand>. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
بدون پارامتر ورودی.
مقدار بازگشتی: `CommandResult`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: ICommandHandler<TCommand> | DI: ZaminServices zaminServices

##### `ResultAsync` (method)

```csharp
protected virtual Task<CommandResult> ResultAsync(ApplicationServiceStatus status)
```

متد «ResultAsync» در CommandHandler<TCommand>. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- status (ApplicationServiceStatus): ورودی از نوع ApplicationServiceStatus.

مقدار بازگشتی: `Task<CommandResult>` — نتیجه ناهمگام عملیات.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: ICommandHandler<TCommand> | DI: ZaminServices zaminServices

##### `Result` (method)

```csharp
protected virtual CommandResult Result(ApplicationServiceStatus status)
```

متد «Result» در CommandHandler<TCommand>. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- status (ApplicationServiceStatus): ورودی از نوع ApplicationServiceStatus.

مقدار بازگشتی: `CommandResult`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: ICommandHandler<TCommand> | DI: ZaminServices zaminServices

##### `AddMessage` (method)

```csharp
protected void AddMessage(string message)
```

متد «AddMessage» در CommandHandler<TCommand>. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- message (string): پیام متنی خطا یا توضیح نقض شرط.

مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: ICommandHandler<TCommand> | DI: ZaminServices zaminServices

##### `AddMessage` (method)

```csharp
protected void AddMessage(string message, params string[] arguments)
```

متد «AddMessage» در CommandHandler<TCommand>. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- message (string): پیام متنی خطا یا توضیح نقض شرط.

مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: ICommandHandler<TCommand> | DI: ZaminServices zaminServices
