# Zamin.Core.Contracts.ApplicationServices.Commands

مرجع API برای namespace `Zamin.Core.Contracts.ApplicationServices.Commands`.

- **Type count (this file):** 3

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Core.Contracts.ApplicationServices.Commands.ICommandDispatcher`

- **Kind:** `interface`
- **Source:** `Onion/src/2.Core/Zamin.Core.Contracts/ApplicationServices/Commands/ICommandDispatcher.cs`

تعریف ساختار برای مدیریت دستورات. پیاده سازی الگوی Mediator از این الگو جهت کاهش پیچیدگی صدا زدن دستورات استفاده می‌شود

- **Recipe:** [الگوی استفاده مرتبط](../patterns/common-recipes.md#recipe-command-dispatcher)

#### Members

##### `Send` (method)

```csharp
Task<CommandResult> Send<TCommand>(TCommand command) where TCommand : class, ICommand
```

یک دستور از نوع ICommand را دریافت کرده و پیاده سازی مناسب جهت مدیریت این دستور را یافته و کار را برای ادامه پردازش به آن پیاده سازی تحویل می‌شود.
پارامترها:
- command: نام دستور

مقدار بازگشتی: `Task<CommandResult>` — نتیجه ناهمگام عملیات.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `Send` (method)

```csharp
Task<CommandResult<TData>> Send<TCommand, TData>(TCommand command) where TCommand : class, ICommand<TData>
```

یک دستور از نوع ICommand را دریافت کرده و پیاده سازی مناسب جهت مدیریت این دستور را یافته و کار را برای ادامه پردازش به آن پیاده سازی تحویل می‌شود.
پارامترها:
- command: نام دستور

مقدار بازگشتی: `Task<CommandResult<TData>>` — نتیجه ناهمگام عملیات.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

### `Zamin.Core.Contracts.ApplicationServices.Commands.ICommandHandler<TCommand, TData>`

- **Kind:** `interface`
- **Constraints:** `where TCommand : ICommand<TData>`
- **Source:** `Onion/src/2.Core/Zamin.Core.Contracts/ApplicationServices/Commands/ICommandHandler.cs`

قرارداد (اینترفیس) «ICommandHandler<TCommand, TData>» در namespace Zamin.Core.Contracts.ApplicationServices.Commands. قرارداد پردازش یک درخواست/رویداد در لایه اپلیکیشن. قیود جنریک: where TCommand : ICommand<TData>.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/common-recipes.md#recipe-command-dispatcher)

#### Members

##### `Handle` (method)

```csharp
Task<CommandResult<TData>> Handle(TCommand request)
```

متد «Handle» در ICommandHandler<TCommand, TData>. منطق اصلی پردازش درخواست/رویداد را اجرا می‌کند.
پارامترها:
- request (TCommand): ورودی از نوع TCommand.

مقدار بازگشتی: `Task<CommandResult<TData>>` — نتیجه ناهمگام عملیات.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

### `Zamin.Core.Contracts.ApplicationServices.Commands.ICommandHandler<TCommand>`

- **Kind:** `interface`
- **Constraints:** `where TCommand : ICommand`
- **Source:** `Onion/src/2.Core/Zamin.Core.Contracts/ApplicationServices/Commands/ICommandHandler.cs`

قرارداد (اینترفیس) «ICommandHandler<TCommand>» در namespace Zamin.Core.Contracts.ApplicationServices.Commands. قرارداد پردازش یک درخواست/رویداد در لایه اپلیکیشن. قیود جنریک: where TCommand : ICommand.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/common-recipes.md#recipe-command-dispatcher)

#### Members

##### `Handle` (method)

```csharp
Task<CommandResult> Handle(TCommand request)
```

متد «Handle» در ICommandHandler<TCommand>. منطق اصلی پردازش درخواست/رویداد را اجرا می‌کند.
پارامترها:
- request (TCommand): ورودی از نوع TCommand.

مقدار بازگشتی: `Task<CommandResult>` — نتیجه ناهمگام عملیات.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
