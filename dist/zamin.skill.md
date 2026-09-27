---
name: zamin
description: >-
  این اسکیل باید هر زمان که کاربر یا ایجنت قصد نوشتن، ویرایش یا بررسی کدی دارد که از فریمورک زمین (Zamin)
  استفاده می‌کند یا می‌خواهد استفاده کند، فعال شود. شامل مرجع API فشرده، الگوهای صحیح استفاده (CQRS،
  Domain، Repository، BaseController، DI/bootstrap) و فهرست تایپ‌های بدون نمونه‌ی عملی است.
  Use whenever writing, reviewing, or wiring Zamin.* code—do not invent Zamin APIs from memory.
---

# Zamin — اسکیل تک‌فایلی

## نحوه استفاده

این فایل **خودکفا** است؛ به هیچ فایل جانبی نیاز ندارد. قبل از نوشتن یا تغییر هر کدی که با زمین سروکار دارد:

1. در صورت نیاز، بخش **Overview** را برای معماری و مفاهیم پایه بخوانید.
2. بخش **API Reference** مربوط به namespace/تایپ مورد نظر را پیدا کنید (جستجو روی `### Namespace:` یا نام تایپ).
3. اگر در بخش **Patterns** برای همان موضوع Recipe وجود دارد، آن را بخوانید و **ترتیب فراخوانی و ترکیب** را از Recipe بگیرید؛ امضا را از API Reference.
4. اگر تایپ در بخش **تایپ‌های بدون نمونه‌ی عملی استفاده** آمده است، فقط بر اساس API Reference عمل کنید و الگوی فراخوانی اختراع نکنید.

### قوانین کوتاه

- Handlerها را `new` نکنید؛ با `AddZaminApiCore` کشف می‌شوند.
- `CommandHandler` / `QueryHandler` معمولاً `ZaminServices` می‌گیرند.
- کنترلر نازک: ارث از `BaseController` و helperهای `Create` / `Edit` / `Delete` / `Query`.
- اگر داده کافی نبود، حدس نزنید؛ صریحاً کمبود مستند را اعلام کنید.

---

## Overview

زمین (Zamin) یک فریمورک .NET مبتنی بر معماری لایه‌ای/پیازی است که قراردادها و پیاده‌سازی‌های آماده برای Command/Query، دامنه (Aggregate/Entity/ValueObject)، زیرساخت SQL، EndPointهای وب، و مجموعه‌ای از Extensionها (کش، پیام، ترجمه، DI، و …) را فراهم می‌کند. این مجموعه مستندات از استخراج سورس زمین به‌همراه الگوهای صحیح استفاده‌ی مستندشده تولید شده است.

استخراج سورس زمین شامل **249** فایل سورس، **97** namespace و **258** تایپ است. توضیحات تایپ/اعضا از enrichment (XML نویسنده یا generated_doc) آمده‌اند.


هر جا داده کافی برای ادعا وجود نداشته باشد، در این مستندات صریحاً با عبارت «مستندات کافی موجود نیست» مشخص شده و چیزی حدس زده نشده است.

### معماری کلی (بر اساس namespaceهای استخراج‌شده)

ماژول‌های زمین در گروه‌های **Core**، **EndPoints**، **Infra**، **Extensions** و **Utilities** سازمان یافته‌اند. جریان رایج: HTTP → `BaseController` → Dispatcher/Handler → Domain → Sql Command/Query (+ Extensionهای Outbox/Cache/…).

فهرست کامل namespaceها و تایپ‌ها در بخش **API Reference** همین فایل آمده است.

### مفاهیم پایه‌ای برای درک فریمورک

این مفاهیم از الگوهای مشاهده‌شده در اپلیکیشن و تایپ‌های Core استخراج شده‌اند:

1. **CQRS سبک:** فرمان‌ها (`ICommand` / `CommandHandler` / `ICommandDispatcher`) و کوئری‌ها (`IQuery` / `QueryHandler` / `IQueryDispatcher`) مسیرهای جدا دارند.
2. **دامنه غنی:** `AggregateRoot`/`Entity` + ValueObjectها؛ نقضInvariant با `InvalidEntityStateException` / `InvalidValueObjectStateException`.
3. **نتیجه اپلیکیشن:** `CommandResult` / `QueryResult` و `ApplicationServiceStatus`.
4. **ثبت وابستگی:** `AddZaminApiCore` برای کشف handlerها و lifetime markerها؛ decoratorهای dispatcher قابل جایگزینی‌اند.
5. **`ZaminServices`:** کانتینر سرویس‌های مشترک تزریق‌شونده به handlerها (مثلاً دسترسی به `UserInfoService`).
6. **جداسازی خواندن/نوشتن داده:** `BaseOutboxCommandDbContext` / `BaseCommandRepository` در برابر `BaseQueryDbContext` / `BaseQueryRepository`.
7. **EndPoint نازک:** کنترلر از `BaseController` ارث می‌برد و فقط به helperهای Create/Edit/Delete/Query متکی است.

### نقطه‌ی شروع پیشنهادی برای ایجنت

اگر می‌خواهید با زمین در پروژه‌ای شبیه اپلیکیشن کد بزنید، این ترتیب را دنبال کنید:

1. همین فایل (`overview.md`) و سپس `_toc.md` برای نقشه کامل.
2. `patterns/dependency-injection.md` — نحوه bootstrap و ثبت سرویس.
3. `patterns/common-recipes.md` — برش عمودی command/query، Aggregate، Repository، BaseController.
4. api-reference برای تایپ‌هایی که لمس می‌کنید، حداقل:
   - `Zamin.Core.ApplicationServices.Commands` / `Queries`
   - `Zamin.Core.RequestResponse.Commands` / `Queries`
   - `Zamin.Core.Domain.Entities` / `ValueObjects` / `Exceptions`
   - `Zamin.Infra.Data.Sql.Commands` / `Queries`
   - `Zamin.EndPoints.Web.Controllers`
   - `Zamin.Utilities` (`ZaminServices`)
5. قبل از استفاده از تایپ‌های ناآشنا، `patterns/unused-types.md` را چک کنید؛ اگر در اپلیکیشن استفاده نشده‌اند، نمونه واقعی در این ریپو ندارید و فقط به XML/enriched تکیه کنید.

### آمار استخراج

- Namespaceها: **97** · تایپ‌ها: **258** · فایل‌های سورس اسکن‌شده: **249**

---

## API Reference

مرجع فشرده برای **97** namespace و **258** تایپ. برای یافتن یک ماژول، تیتر `### Namespace:` یا نام کامل تایپ را جستجو کنید.

### Namespace: `Zamin.Core.ApplicationServices.Commands`

#### `Zamin.Core.ApplicationServices.Commands.CommandDispatcher` (class)

کلاس «CommandDispatcher» در namespace Zamin.Core.ApplicationServices.Commands. مسئول یافتن و فراخوانی handler مناسب برای فرمان/کوئری/رویداد. ارث‌بری/پیاده‌سازی: ICommandDispatcher. وابستگی‌های سازنده (DI): IServiceProvider serviceProvider, ILogger<CommandDispatcher> logger. مرتب…

- **Base:** `ICommandDispatcher`

**اعضا (3):**

- `.ctor` (constructor): `public CommandDispatcher(IServiceProvider serviceProvider, ILogger<CommandDispatcher> logger)`
- `Send` (method): `public async Task<CommandResult> Send<TCommand>(TCommand command) where TCommand : class, ICommand`
- `Send` (method): `public async Task<CommandResult<TData>> Send<TCommand, TData>(TCommand command) where TCommand : class, ICommand<TData>`

#### `Zamin.Core.ApplicationServices.Commands.CommandDispatcherDecorator` (class)

کلاس «CommandDispatcherDecorator» در namespace Zamin.Core.ApplicationServices.Commands. مسئول یافتن و فراخوانی handler مناسب برای فرمان/کوئری/رویداد. ارث‌بری/پیاده‌سازی: ICommandDispatcher. مرتبط: ICommandDispatcher.

- **Base:** `ICommandDispatcher`

**اعضا (6):**

- `_commandDispatcher` (field): `protected ICommandDispatcher _commandDispatcher;`
- `Order` (property): `public abstract int Order { get; }`
- `.ctor` (constructor): `public CommandDispatcherDecorator()`
- `SetCommandDispatcher` (method): `public void SetCommandDispatcher(ICommandDispatcher commandDispatcher)`
- `Send` (method): `public abstract Task<CommandResult> Send<TCommand>(TCommand command) where TCommand : class, ICommand`
- `Send` (method): `public abstract Task<CommandResult<TData>> Send<TCommand, TData>(TCommand command) where TCommand : class, ICommand<TData>`

#### `Zamin.Core.ApplicationServices.Commands.CommandDispatcherDomainExceptionHandlerDecorator` (class)

کلاس «CommandDispatcherDomainExceptionHandlerDecorator» در namespace Zamin.Core.ApplicationServices.Commands. مسئول یافتن و فراخوانی handler مناسب برای فرمان/کوئری/رویداد. ارث‌بری/پیاده‌سازی: CommandDispatcherDecorator. وابستگی‌های سازنده (DI): IServiceProvider serviceProvider,…

- **Base:** `CommandDispatcherDecorator`

**اعضا (4):**

- `.ctor` (constructor): `public CommandDispatcherDomainExceptionHandlerDecorator(IServiceProvider serviceProvider, ILogger<CommandDispatcherDomainExceptionHandlerDecorator> logger)`
- `Order` (property): `public override int Order => ...`
- `Send` (method): `public override async Task<CommandResult> Send<TCommand>(TCommand command)`
- `Send` (method): `public override async Task<CommandResult<TData>> Send<TCommand, TData>(TCommand command)`

#### `Zamin.Core.ApplicationServices.Commands.CommandDispatcherValidationDecorator` (class)

کلاس «CommandDispatcherValidationDecorator» در namespace Zamin.Core.ApplicationServices.Commands. مسئول یافتن و فراخوانی handler مناسب برای فرمان/کوئری/رویداد. ارث‌بری/پیاده‌سازی: CommandDispatcherDecorator. وابستگی‌های سازنده (DI): IServiceProvider serviceProvider, ILogger<Comm…

- **Base:** `CommandDispatcherDecorator`

**اعضا (4):**

- `.ctor` (constructor): `public CommandDispatcherValidationDecorator(IServiceProvider serviceProvider, ILogger<CommandDispatcherValidationDecorator> logger)`
- `Order` (property): `public override int Order => ...`
- `Send` (method): `public override async Task<CommandResult> Send<TCommand>(TCommand command)`
- `Send` (method): `public override async Task<CommandResult<TData>> Send<TCommand, TData>(TCommand command)`

#### `Zamin.Core.ApplicationServices.Commands.CommandHandler<TCommand, TData>` (class)

کلاس «CommandHandler<TCommand, TData>» در namespace Zamin.Core.ApplicationServices.Commands. پیاده‌سازی use-case یا واکنش به رویداد. ارث‌بری/پیاده‌سازی: ICommandHandler<TCommand, TData>. قیود جنریک: where TCommand : ICommand<TData>. وابستگی‌های سازنده (DI): ZaminServices zaminSe…

- **Base:** `ICommandHandler<TCommand, TData>`

**اعضا (10):**

- `_zaminServices` (field): `protected readonly ZaminServices _zaminServices;`
- `result` (field): `protected readonly CommandResult<TData> result = new();`
- `.ctor` (constructor): `public CommandHandler(ZaminServices zaminServices)`
- `Handle` (method): `public abstract Task<CommandResult<TData>> Handle(TCommand command)`
- `OkAsync` (method): `protected virtual Task<CommandResult<TData>> OkAsync(TData data)`
- `Ok` (method): `protected virtual CommandResult<TData> Ok(TData data)`
- `ResultAsync` (method): `protected virtual Task<CommandResult<TData>> ResultAsync(TData data, ApplicationServiceStatus status)`
- `Result` (method): `protected virtual CommandResult<TData> Result(TData data, ApplicationServiceStatus status)`
- `AddMessage` (method): `protected void AddMessage(string message)`
- `AddMessage` (method): `protected void AddMessage(string message, params string[] arguments)`

#### `Zamin.Core.ApplicationServices.Commands.CommandHandler<TCommand>` (class)

کلاس «CommandHandler<TCommand>» در namespace Zamin.Core.ApplicationServices.Commands. پیاده‌سازی use-case یا واکنش به رویداد. ارث‌بری/پیاده‌سازی: ICommandHandler<TCommand>. قیود جنریک: where TCommand : ICommand. وابستگی‌های سازنده (DI): ZaminServices zaminServices. مرتبط: IComma…

- **Base:** `ICommandHandler<TCommand>`

**اعضا (10):**

- `_zaminServices` (field): `protected readonly ZaminServices _zaminServices;`
- `result` (field): `protected readonly CommandResult result = new();`
- `.ctor` (constructor): `public CommandHandler(ZaminServices zaminServices)`
- `Handle` (method): `public abstract Task<CommandResult> Handle(TCommand command)`
- `OkAsync` (method): `protected virtual Task<CommandResult> OkAsync()`
- `Ok` (method): `protected virtual CommandResult Ok()`
- `ResultAsync` (method): `protected virtual Task<CommandResult> ResultAsync(ApplicationServiceStatus status)`
- `Result` (method): `protected virtual CommandResult Result(ApplicationServiceStatus status)`
- `AddMessage` (method): `protected void AddMessage(string message)`
- `AddMessage` (method): `protected void AddMessage(string message, params string[] arguments)`

### Namespace: `Zamin.Core.ApplicationServices.Events`

#### `Zamin.Core.ApplicationServices.Events.EventDispatcher` (class)

کلاس «EventDispatcher» در namespace Zamin.Core.ApplicationServices.Events. مسئول یافتن و فراخوانی handler مناسب برای فرمان/کوئری/رویداد. ارث‌بری/پیاده‌سازی: IEventDispatcher. وابستگی‌های سازنده (DI): IServiceProvider serviceProvider, ILogger<EventDispatcher> logger. مرتبط: IEven…

- **Base:** `IEventDispatcher`

**اعضا (2):**

- `.ctor` (constructor): `public EventDispatcher(IServiceProvider serviceProvider, ILogger<EventDispatcher> logger)`
- `PublishDomainEventAsync` (method): `public async Task PublishDomainEventAsync<TDomainEvent>(TDomainEvent @event) where TDomainEvent : class, IDomainEvent`

#### `Zamin.Core.ApplicationServices.Events.EventDispatcherDecorator` (class)

کلاس «EventDispatcherDecorator» در namespace Zamin.Core.ApplicationServices.Events. مسئول یافتن و فراخوانی handler مناسب برای فرمان/کوئری/رویداد. ارث‌بری/پیاده‌سازی: IEventDispatcher. مرتبط: IEventDispatcher.

- **Base:** `IEventDispatcher`

**اعضا (5):**

- `_eventDispatcher` (field): `protected IEventDispatcher _eventDispatcher;`
- `Order` (property): `public abstract int Order { get; }`
- `.ctor` (constructor): `public EventDispatcherDecorator()`
- `PublishDomainEventAsync` (method): `public abstract Task PublishDomainEventAsync<TDomainEvent>(TDomainEvent @event) where TDomainEvent : class, IDomainEvent`
- `SetEventDispatcher` (method): `public void SetEventDispatcher(IEventDispatcher eventDispatcher)`

#### `Zamin.Core.ApplicationServices.Events.EventDispatcherDomainExceptionHandlerDecorator` (class)

کلاس «EventDispatcherDomainExceptionHandlerDecorator» در namespace Zamin.Core.ApplicationServices.Events. مسئول یافتن و فراخوانی handler مناسب برای فرمان/کوئری/رویداد. ارث‌بری/پیاده‌سازی: EventDispatcherDecorator. وابستگی‌های سازنده (DI): ILogger<EventDispatcherDomainExceptionHa…

- **Base:** `EventDispatcherDecorator`

**اعضا (3):**

- `Order` (property): `public override int Order => ...`
- `.ctor` (constructor): `public EventDispatcherDomainExceptionHandlerDecorator(ILogger<EventDispatcherDomainExceptionHandlerDecorator> logger)`
- `PublishDomainEventAsync` (method): `public override async Task PublishDomainEventAsync<TDomainEvent>(TDomainEvent @event)`

#### `Zamin.Core.ApplicationServices.Events.EventDispatcherValidationDecorator` (class)

کلاس «EventDispatcherValidationDecorator» در namespace Zamin.Core.ApplicationServices.Events. مسئول یافتن و فراخوانی handler مناسب برای فرمان/کوئری/رویداد. ارث‌بری/پیاده‌سازی: EventDispatcherDecorator. وابستگی‌های سازنده (DI): IServiceProvider serviceProvider, ILogger<EventDispa…

- **Base:** `EventDispatcherDecorator`

**اعضا (3):**

- `Order` (property): `public override int Order => ...`
- `.ctor` (constructor): `public EventDispatcherValidationDecorator(IServiceProvider serviceProvider, ILogger<EventDispatcherValidationDecorator> logger)`
- `PublishDomainEventAsync` (method): `public override async Task PublishDomainEventAsync<TDomainEvent>(TDomainEvent @event)`

### Namespace: `Zamin.Core.ApplicationServices.Queries`

#### `Zamin.Core.ApplicationServices.Queries.QueryDispatcher` (class)

کلاس «QueryDispatcher» در namespace Zamin.Core.ApplicationServices.Queries. مسئول یافتن و فراخوانی handler مناسب برای فرمان/کوئری/رویداد. ارث‌بری/پیاده‌سازی: IQueryDispatcher. وابستگی‌های سازنده (DI): IServiceProvider serviceProvider, ILogger<QueryDispatcher> logger. مرتبط: IQue…

- **Base:** `IQueryDispatcher`

**اعضا (2):**

- `.ctor` (constructor): `public QueryDispatcher(IServiceProvider serviceProvider, ILogger<QueryDispatcher> logger)`
- `Execute` (method): `public Task<QueryResult<TData>> Execute<TQuery, TData>(TQuery query) where TQuery : class, IQuery<TData>`

#### `Zamin.Core.ApplicationServices.Queries.QueryDispatcherDecorator` (class)

کلاس «QueryDispatcherDecorator» در namespace Zamin.Core.ApplicationServices.Queries. مسئول یافتن و فراخوانی handler مناسب برای فرمان/کوئری/رویداد. ارث‌بری/پیاده‌سازی: IQueryDispatcher. مرتبط: IQueryDispatcher.

- **Base:** `IQueryDispatcher`

**اعضا (5):**

- `_queryDispatcher` (field): `protected IQueryDispatcher _queryDispatcher;`
- `Order` (property): `public abstract int Order { get; }`
- `.ctor` (constructor): `public QueryDispatcherDecorator()`
- `Execute` (method): `public abstract Task<QueryResult<TData>> Execute<TQuery, TData>(TQuery query) where TQuery : class, IQuery<TData>`
- `SetQueryDispatcher` (method): `public void SetQueryDispatcher(IQueryDispatcher queryDispatcher)`

#### `Zamin.Core.ApplicationServices.Queries.QueryDispatcherDomainExceptionHandlerDecorator` (class)

کلاس «QueryDispatcherDomainExceptionHandlerDecorator» در namespace Zamin.Core.ApplicationServices.Queries. مسئول یافتن و فراخوانی handler مناسب برای فرمان/کوئری/رویداد. ارث‌بری/پیاده‌سازی: QueryDispatcherDecorator. وابستگی‌های سازنده (DI): IServiceProvider serviceProvider, ILogg…

- **Base:** `QueryDispatcherDecorator`

**اعضا (3):**

- `Order` (property): `public override int Order => ...`
- `.ctor` (constructor): `public QueryDispatcherDomainExceptionHandlerDecorator(IServiceProvider serviceProvider, ILogger<QueryDispatcherDomainExceptionHandlerDecorator> logger)`
- `Execute` (method): `public override async Task<QueryResult<TData>> Execute<TQuery, TData>(TQuery query)`

#### `Zamin.Core.ApplicationServices.Queries.QueryDispatcherValidationDecorator` (class)

کلاس «QueryDispatcherValidationDecorator» در namespace Zamin.Core.ApplicationServices.Queries. مسئول یافتن و فراخوانی handler مناسب برای فرمان/کوئری/رویداد. ارث‌بری/پیاده‌سازی: QueryDispatcherDecorator. وابستگی‌های سازنده (DI): IServiceProvider serviceProvider, ILogger<QueryDisp…

- **Base:** `QueryDispatcherDecorator`

**اعضا (3):**

- `Order` (property): `public override int Order => ...`
- `.ctor` (constructor): `public QueryDispatcherValidationDecorator(IServiceProvider serviceProvider, ILogger<QueryDispatcherValidationDecorator> logger)`
- `Execute` (method): `public override async Task<QueryResult<TData>> Execute<TQuery, TData>(TQuery query)`

#### `Zamin.Core.ApplicationServices.Queries.QueryHandler<TQuery, TData>` (class)

کلاس «QueryHandler<TQuery, TData>» در namespace Zamin.Core.ApplicationServices.Queries. پیاده‌سازی use-case یا واکنش به رویداد. ارث‌بری/پیاده‌سازی: IQueryHandler<TQuery, TData>. قیود جنریک: where TQuery : class, IQuery<TData>. وابستگی‌های سازنده (DI): ZaminServices zaminServices…

- **Base:** `IQueryHandler<TQuery, TData>`

**اعضا (10):**

- `_zaminServices` (field): `protected readonly ZaminServices _zaminServices;`
- `result` (field): `protected readonly QueryResult<TData> result = new();`
- `ResultAsync` (method): `protected virtual Task<QueryResult<TData>> ResultAsync(TData data, ApplicationServiceStatus status)`
- `Result` (method): `protected virtual QueryResult<TData> Result(TData data, ApplicationServiceStatus status)`
- `ResultAsync` (method): `protected virtual Task<QueryResult<TData>> ResultAsync(TData data)`
- `Result` (method): `protected virtual QueryResult<TData> Result(TData data)`
- `.ctor` (constructor): `public QueryHandler(ZaminServices zaminServices)`
- `AddMessage` (method): `protected void AddMessage(string message)`
- `AddMessage` (method): `protected void AddMessage(string message, params string[] arguments)`
- `Handle` (method): `public abstract Task<QueryResult<TData>> Handle(TQuery query)`

### Namespace: `Zamin.Core.Contracts.ApplicationServices.Commands`

#### `Zamin.Core.Contracts.ApplicationServices.Commands.ICommandDispatcher` (interface)

تعریف ساختار برای مدیریت دستورات. پیاده سازی الگوی Mediator از این الگو جهت کاهش پیچیدگی صدا زدن دستورات استفاده می‌شود

**اعضا (2):**

- `Send` (method): `Task<CommandResult> Send<TCommand>(TCommand command) where TCommand : class, ICommand`
- `Send` (method): `Task<CommandResult<TData>> Send<TCommand, TData>(TCommand command) where TCommand : class, ICommand<TData>`

#### `Zamin.Core.Contracts.ApplicationServices.Commands.ICommandHandler<TCommand, TData>` (interface)

قرارداد (اینترفیس) «ICommandHandler<TCommand, TData>» در namespace Zamin.Core.Contracts.ApplicationServices.Commands. قرارداد پردازش یک درخواست/رویداد در لایه اپلیکیشن. قیود جنریک: where TCommand : ICommand<TData>.

**اعضا (1):**

- `Handle` (method): `Task<CommandResult<TData>> Handle(TCommand request)`

#### `Zamin.Core.Contracts.ApplicationServices.Commands.ICommandHandler<TCommand>` (interface)

قرارداد (اینترفیس) «ICommandHandler<TCommand>» در namespace Zamin.Core.Contracts.ApplicationServices.Commands. قرارداد پردازش یک درخواست/رویداد در لایه اپلیکیشن. قیود جنریک: where TCommand : ICommand.

**اعضا (1):**

- `Handle` (method): `Task<CommandResult> Handle(TCommand request)`

### Namespace: `Zamin.Core.Contracts.ApplicationServices.Events`

#### `Zamin.Core.Contracts.ApplicationServices.Events.IDomainEventHandler<TDomainEvent>` (interface)

قرارداد (اینترفیس) «IDomainEventHandler<TDomainEvent>» در namespace Zamin.Core.Contracts.ApplicationServices.Events. قرارداد پردازش یک درخواست/رویداد در لایه اپلیکیشن. قیود جنریک: where TDomainEvent : IDomainEvent.

**اعضا (1):**

- `Handle` (method): `Task Handle(TDomainEvent Event)`

#### `Zamin.Core.Contracts.ApplicationServices.Events.IEventDispatcher` (interface)

قرارداد (اینترفیس) «IEventDispatcher» در namespace Zamin.Core.Contracts.ApplicationServices.Events. قرارداد مسیریابی و ارسال فرمان/کوئری/رویداد به handler مناسب.

**اعضا (1):**

- `PublishDomainEventAsync` (method): `Task PublishDomainEventAsync<TDomainEvent>(TDomainEvent @event) where TDomainEvent : class, IDomainEvent`

### Namespace: `Zamin.Core.Contracts.ApplicationServices.Queries`

#### `Zamin.Core.Contracts.ApplicationServices.Queries.IQueryDispatcher` (interface)

تعریف ساختار الگوی Mediator جهت اتصال ساده کوئری‌ها به هندلر‌ها

**اعضا (1):**

- `Execute` (method): `Task<QueryResult<TData>> Execute<TQuery, TData>(TQuery query) where TQuery : class, IQuery<TData>`

#### `Zamin.Core.Contracts.ApplicationServices.Queries.IQueryHandler<TQuery, TData>` (interface)

تعریف ساختار مورد نیاز جهت پردازش یک کورئری

**اعضا (1):**

- `Handle` (method): `Task<QueryResult<TData>> Handle(TQuery request)`

### Namespace: `Zamin.Core.Contracts.Data.Commands`

#### `Zamin.Core.Contracts.Data.Commands.ICommandRepository<TEntity,TId>` (interface)

در صورتی که داده‌ها به صورت عادی ذخیره سازی شوند از این Interface جهت تعیین اعمال اصلی موجود در بخش ذخیره سازی داده‌ها استفاده می‌شود.

- **Base:** `IUnitOfWork`

**اعضا (15):**

- `Delete` (method): `void Delete(TId id)`
- `DeleteGraph` (method): `void DeleteGraph(TId id)`
- `Delete` (method): `void Delete(TEntity entity)`
- `Insert` (method): `void Insert(TEntity entity)`
- `InsertAsync` (method): `Task InsertAsync(TEntity entity)`
- `Get` (method): `TEntity Get(TId id)`
- `GetAsync` (method): `Task<TEntity> GetAsync(TId id)`
- `Get` (method): `TEntity Get(BusinessId businessId)`
- `GetAsync` (method): `Task<TEntity> GetAsync(BusinessId businessId)`
- `GetGraph` (method): `TEntity GetGraph(TId id)`
- `GetGraphAsync` (method): `Task<TEntity> GetGraphAsync(TId id)`
- `GetGraph` (method): `TEntity GetGraph(BusinessId businessId)`
- `GetGraphAsync` (method): `Task<TEntity> GetGraphAsync(BusinessId businessId)`
- `Exists` (method): `bool Exists(Expression<Func<TEntity, bool>> expression)`
- `ExistsAsync` (method): `Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression)`

#### `Zamin.Core.Contracts.Data.Commands.IDomainEventStore` (interface)

در صورت نیاز به ذخیره و بازیابی eventها از این اینترفیس استفاده می‌شود.

**اعضا (2):**

- `Save` (method): `void Save<TEvent>(string aggregateName, string aggregateId, IEnumerable<TEvent> events) where TEvent : IDomainEvent`
- `SaveAsync` (method): `Task SaveAsync<TEvent>(string aggregateName, string aggregateId, IEnumerable<TEvent> events) where TEvent : IDomainEvent`

#### `Zamin.Core.Contracts.Data.Commands.IUnitOfWork` (interface)

تعریف Interface برای الگوی UnitOfWork جهت مدیریت تراکنش‌ها با دیتابیس در این قسمت انجام شده است تعریف کامل این الگو در کتاب P of EAA وجود دارد و تعریف اولیه را در آدرس زیر می‌توان مشاهده کرد https://martinfowler.com/eaaCatalog/unitOfWork.html

**اعضا (5):**

- `BeginTransaction` (method): `void BeginTransaction()`
- `CommitTransaction` (method): `void CommitTransaction()`
- `RollbackTransaction` (method): `void RollbackTransaction()`
- `Commit` (method): `int Commit()`
- `CommitAsync` (method): `Task<int> CommitAsync()`

### Namespace: `Zamin.Core.Contracts.Data.Queries`

#### `Zamin.Core.Contracts.Data.Queries.IQueryRepository` (interface)

تعریف کوئری‌های پایه مورد نیاز در سامانه در این Interface قرار می‌گیرد.

_اعضای عمومی استخراج‌شده ندارد._

### Namespace: `Zamin.Core.Domain.Entities`

#### `Zamin.Core.Domain.Entities.AggregateRoot` (class)

کلاس «AggregateRoot» در namespace Zamin.Core.Domain.Entities. ریشه aggregate دامنه؛ مسئول ثبات درونی و ثبت domain eventها. ارث‌بری/پیاده‌سازی: AggregateRoot<long>. مرتبط: AggregateRoot<long> (same namespace).

- **Base:** `AggregateRoot<long>`

_اعضای عمومی استخراج‌شده ندارد._

#### `Zamin.Core.Domain.Entities.AggregateRoot<TId>` (class)

پیاده سازی الگوی AggregateRoot توضیحات کامل در مورد این الگو را در آدرس زیر می‌توانید مشاهده نمایید https://martinfowler.com/bliki/DDD_Aggregate.html

- **Base:** `Entity<TId>`, `IAggregateRoot`

**اعضا (6):**

- `.ctor` (constructor): `protected AggregateRoot()`
- `.ctor` (constructor): `public AggregateRoot(IEnumerable<IDomainEvent> events)`
- `Apply` (method): `protected void Apply(IDomainEvent @event)`
- `AddEvent` (method): `protected void AddEvent(IDomainEvent @event)`
- `GetEvents` (method): `public IEnumerable<IDomainEvent> GetEvents()`
- `ClearEvents` (method): `public void ClearEvents()`

#### `Zamin.Core.Domain.Entities.Entity` (class)

کلاس «Entity» در namespace Zamin.Core.Domain.Entities. موجودیت دامنه با هویت و قابلیت auditable. ارث‌بری/پیاده‌سازی: Entity<long>. مرتبط: Entity<long> (same namespace).

- **Base:** `Entity<long>`

_اعضای عمومی استخراج‌شده ندارد._

#### `Zamin.Core.Domain.Entities.Entity<TId>` (class)

کلاس پایه برای تمامی Entityها موجود در سامانه

- **Base:** `IAuditableEntity`

**اعضا (8):**

- `Id` (property): `public TId Id { get; protected set; }`
- `BusinessId` (property): `public BusinessId BusinessId { get; protected set; }`
- `.ctor` (constructor): `protected Entity()`
- `Equals` (method): `public bool Equals(Entity<TId>? other)`
- `Equals` (method): `public override bool Equals(object? obj)`
- `GetHashCode` (method): `public override int GetHashCode()`
- `==` (operator): `public static bool operator ==(Entity<TId> left, Entity<TId> right)`
- `!=` (operator): `public static bool operator !=(Entity<TId> left, Entity<TId> right)`

#### `Zamin.Core.Domain.Entities.IAggregateRoot` (interface)

قرارداد (اینترفیس) «IAggregateRoot» در namespace Zamin.Core.Domain.Entities. قرارداد رفتار برای مصرف‌کنندگان و پیاده‌سازی‌های جایگزین.

**اعضا (2):**

- `ClearEvents` (method): `void ClearEvents()`
- `GetEvents` (method): `IEnumerable<IDomainEvent> GetEvents()`

#### `Zamin.Core.Domain.Entities.IAuditableEntity` (interface)

قرارداد (اینترفیس) «IAuditableEntity» در namespace Zamin.Core.Domain.Entities. قرارداد رفتار برای مصرف‌کنندگان و پیاده‌سازی‌های جایگزین.

_اعضای عمومی استخراج‌شده ندارد._

### Namespace: `Zamin.Core.Domain.Events`

#### `Zamin.Core.Domain.Events.IDomainEvent` (interface)

در این مجموعه از eventها برای تغییر وضعیت و نگهداری تغییرات استفاده می‌شود به منظور انجام اتوماتیک امور مختلف از این اینترفیس به عنوان marker استفاده می شود

_اعضای عمومی استخراج‌شده ندارد._

### Namespace: `Zamin.Core.Domain.Exceptions`

#### `Zamin.Core.Domain.Exceptions.DomainStateException` (class)

خطاهای لایه Domain مربوط به Entityها و ValueObjectها به کمک Extention برای لایه‌های بالاتر ارسال می‌شود با توجه به اینکه هم Entity و هم ValueObject به یک شکل خطا را ارسال می‌کنند یک کلاس Exception طراحی و پیاده سازی شده است. برای اینکه در لایه‌های بالاتر بتوان تفاوت خطای و محل ر…

- **Base:** `Exception`

**اعضا (3):**

- `Parameters` (property): `public string[] Parameters { get; set; }`
- `.ctor` (constructor): `public DomainStateException(string message, params string[] parameters)`
- `ToString` (method): `public override string ToString()`

#### `Zamin.Core.Domain.Exceptions.InvalidEntityStateException` (class)

کلاس «InvalidEntityStateException» در namespace Zamin.Core.Domain.Exceptions. موجودیت دامنه با هویت و قابلیت auditable. ارث‌بری/پیاده‌سازی: DomainStateException. وابستگی‌های سازنده (DI): string message, string[] parameters. مرتبط: DomainStateException (same namespace) | DI: stri…

- **Base:** `DomainStateException`

**اعضا (1):**

- `.ctor` (constructor): `public InvalidEntityStateException(string message, params string[] parameters)`

#### `Zamin.Core.Domain.Exceptions.InvalidValueObjectStateException` (class)

خطا‌های مربوط به وضعیت ناصحیح در ValueObject ها توسط این کلاس ارسال می‌شود پارامترها: - message: پیام یا الگوی پیام خطا - parameters: پارامتر‌ها که در صورت وجود در الگوی پیام جایگذاری می‌شوند

- **Base:** `DomainStateException`

**اعضا (1):**

- `.ctor` (constructor): `public InvalidValueObjectStateException(string message, params string[] parameters)`

### Namespace: `Zamin.Core.Domain.Toolkits.ValueObjects`

#### `Zamin.Core.Domain.Toolkits.ValueObjects.Description` (class)

کلاس «Description» در namespace Zamin.Core.Domain.Toolkits.ValueObjects. شیء مقدار دامنه با برابری مبتنی بر مقدار. ارث‌بری/پیاده‌سازی: BaseValueObject<Description>. مرتبط: BaseValueObject<Description>.

- **Base:** `BaseValueObject<Description>`

**اعضا (5):**

- `Value` (property): `public string Value { get; private set; }`
- `FromString` (method): `public static Description FromString(string value)`
- `GetEqualityComponents` (method): `protected override IEnumerable<object> GetEqualityComponents()`
- `string` (conversion_operator): `public static explicit operator string(Description description)`
- `Description` (conversion_operator): `public static implicit operator Description(string value)`

#### `Zamin.Core.Domain.Toolkits.ValueObjects.LegalNationalId` (class)

کلاس «LegalNationalId» در namespace Zamin.Core.Domain.Toolkits.ValueObjects. شیء مقدار دامنه با برابری مبتنی بر مقدار. ارث‌بری/پیاده‌سازی: BaseValueObject<LegalNationalId>. مرتبط: BaseValueObject<LegalNationalId>.

- **Base:** `BaseValueObject<LegalNationalId>`

**اعضا (6):**

- `Value` (property): `public string Value { get; private set; }`
- `FromString` (method): `public static LegalNationalId FromString(string value)`
- `GetEqualityComponents` (method): `protected override IEnumerable<object> GetEqualityComponents()`
- `string` (conversion_operator): `public static explicit operator string(LegalNationalId title)`
- `LegalNationalId` (conversion_operator): `public static implicit operator LegalNationalId(string value)`
- `ToString` (method): `public override string ToString()`

#### `Zamin.Core.Domain.Toolkits.ValueObjects.NationalCode` (class)

کلاس «NationalCode» در namespace Zamin.Core.Domain.Toolkits.ValueObjects. شیء مقدار دامنه با برابری مبتنی بر مقدار. ارث‌بری/پیاده‌سازی: BaseValueObject<NationalCode>. وابستگی‌های سازنده (DI): string value. مرتبط: BaseValueObject<NationalCode> | DI: string value.

- **Base:** `BaseValueObject<NationalCode>`

**اعضا (7):**

- `Value` (property): `public string Value { get; private set; }`
- `FromString` (method): `public static NationalCode FromString(string value)`
- `.ctor` (constructor): `public NationalCode(string value)`
- `GetEqualityComponents` (method): `protected override IEnumerable<object> GetEqualityComponents()`
- `string` (conversion_operator): `public static explicit operator string(NationalCode title)`
- `NationalCode` (conversion_operator): `public static implicit operator NationalCode(string value)`
- `ToString` (method): `public override string ToString()`

#### `Zamin.Core.Domain.Toolkits.ValueObjects.Priority` (class)

کلاس «Priority» در namespace Zamin.Core.Domain.Toolkits.ValueObjects. شیء مقدار دامنه با برابری مبتنی بر مقدار. ارث‌بری/پیاده‌سازی: BaseValueObject<Priority>. وابستگی‌های سازنده (DI): int value. مرتبط: BaseValueObject<Priority> | DI: int value.

- **Base:** `BaseValueObject<Priority>`

**اعضا (14):**

- `Value` (property): `public int Value { get; private set; }`
- `FromInt` (method): `public static Priority FromInt(int value)`
- `.ctor` (constructor): `public Priority(int value)`
- `GetEqualityComponents` (method): `protected override IEnumerable<object> GetEqualityComponents()`
- `+` (operator): `public static Priority operator +(Priority priority, int addNum)`
- `-` (operator): `public static Priority operator -(Priority priority, int addNum)`
- `<` (operator): `public static bool operator <(Priority priority01, Priority priority02)`
- `>` (operator): `public static bool operator >(Priority priority01, Priority priority02)`
- `<=` (operator): `public static bool operator <=(Priority priority01, Priority priority02)`
- `>=` (operator): `public static bool operator >=(Priority priority01, Priority priority02)`
- `int` (conversion_operator): `public static explicit operator int(Priority priority)`
- `Priority` (conversion_operator): `public static implicit operator Priority(int value)`
- `Increase` (method): `public Priority Increase(int increasedValue)`
- `Decrease` (method): `public Priority Decrease(int increasedValue)`

#### `Zamin.Core.Domain.Toolkits.ValueObjects.Title` (class)

کلاس «Title» در namespace Zamin.Core.Domain.Toolkits.ValueObjects. شیء مقدار دامنه با برابری مبتنی بر مقدار. ارث‌بری/پیاده‌سازی: BaseValueObject<Title>. مرتبط: BaseValueObject<Title>.

- **Base:** `BaseValueObject<Title>`

**اعضا (6):**

- `Value` (property): `public string Value { get; private set; }`
- `FromString` (method): `public static Title FromString(string value)`
- `GetEqualityComponents` (method): `protected override IEnumerable<object> GetEqualityComponents()`
- `string` (conversion_operator): `public static explicit operator string(Title title)`
- `Title` (conversion_operator): `public static implicit operator Title(string value)`
- `ToString` (method): `public override string ToString()`

### Namespace: `Zamin.Core.Domain.ValueObjects`

#### `Zamin.Core.Domain.ValueObjects.BaseValueObject<TValueObject>` (class)

کلاس پایه برای همه ValueObjectها توضحیات کاملی در مورد دلایل وجود ValueObjectها را در لینک زیر مشاهده می‌کند https://martinfowler.com/bliki/ValueObject.html

- **Base:** `IEquatable<TValueObject>`

**اعضا (6):**

- `Equals` (method): `public bool Equals(TValueObject other)`
- `Equals` (method): `public override bool Equals(object obj)`
- `GetHashCode` (method): `public override int GetHashCode()`
- `GetEqualityComponents` (method): `protected abstract IEnumerable<object> GetEqualityComponents()`
- `==` (operator): `public static bool operator ==(BaseValueObject<TValueObject> right, BaseValueObject<TValueObject> left)`
- `!=` (operator): `public static bool operator !=(BaseValueObject<TValueObject> right, BaseValueObject<TValueObject> left)`

#### `Zamin.Core.Domain.ValueObjects.BusinessId` (class)

کلاس «BusinessId» در namespace Zamin.Core.Domain.ValueObjects. شیء مقدار دامنه با برابری مبتنی بر مقدار. ارث‌بری/پیاده‌سازی: BaseValueObject<BusinessId>. وابستگی‌های سازنده (DI): string value. مرتبط: BaseValueObject<BusinessId> (same namespace) | DI: string value.

- **Base:** `BaseValueObject<BusinessId>`

**اعضا (10):**

- `FromString` (method): `public static BusinessId FromString(string value)`
- `FromGuid` (method): `public static BusinessId FromGuid(Guid value)`
- `.ctor` (constructor): `public BusinessId(string value)`
- `Value` (property): `public Guid Value { get; private set; }`
- `ToString` (method): `public override string ToString()`
- `GetEqualityComponents` (method): `protected override IEnumerable<object> GetEqualityComponents()`
- `string` (conversion_operator): `public static explicit operator string(BusinessId title)`
- `BusinessId` (conversion_operator): `public static implicit operator BusinessId(string value)`
- `Guid` (conversion_operator): `public static explicit operator Guid(BusinessId title)`
- `BusinessId` (conversion_operator): `public static implicit operator BusinessId(Guid value)`

### Namespace: `Zamin.Core.RequestResponse.Commands`

#### `Zamin.Core.RequestResponse.Commands.CommandResult` (class)

نتیجه انجام هر عملیات به کمک این کلاس بازگشت داده می‌شود. دلایل استفاده از این الگو و پیاده سازی کاملی از این الگو را در لینک زیر می‌توانید مشاهده کنید https://github.com/vkhorikov/CqrsInPractice

- **Base:** `ApplicationServiceResult`

_اعضای عمومی استخراج‌شده ندارد._

#### `Zamin.Core.RequestResponse.Commands.CommandResult<TData>` (class)

نتیجه انجام هر عملیات به کمک این کلاس بازگشت داده می‌شود. دلایل استفاده از این الگو و پیاده سازی کاملی از این الگو را در لینک زیر می‌توانید مشاهده کنید این ساختار در صورتی استفاده میشود که برای عملیات مقدار خروجی نیاز باشد https://github.com/vkhorikov/CqrsInPractice

- **Base:** `CommandResult`

**اعضا (2):**

- `_data` (field): `public TData? _data;`
- `Data` (property): `public TData? Data => ...`

#### `Zamin.Core.RequestResponse.Commands.ICommand` (interface)

جهت علامت گذاری کلاسی که پارامتر‌های ورودی درستور را دارد از این اینترفیس اسفتاده می‌شود

_اعضای عمومی استخراج‌شده ندارد._

#### `Zamin.Core.RequestResponse.Commands.ICommand<TData>` (interface)

جهت علامت گذاری کلاسی که پارامتر‌های ورودی درستور را دارد از این اینترفیس اسفتاده می‌شود اگر به ازای دستور ارسال شده مقدار خروجی باید بازگشت داده شود از این اینترفیس استفاده می‌شود

_اعضای عمومی استخراج‌شده ندارد._

### Namespace: `Zamin.Core.RequestResponse.Common`

#### `Zamin.Core.RequestResponse.Common.ApplicationServiceResult` (class)

کلاس «ApplicationServiceResult» در namespace Zamin.Core.RequestResponse.Common. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین. ارث‌بری/پیاده‌سازی: IApplicationServiceResult. مرتبط: IApplicationServiceResult (same namespace).

- **Base:** `IApplicationServiceResult`

**اعضا (6):**

- `_messages` (field): `protected readonly List<string> _messages = new();`
- `Messages` (property): `public IEnumerable<string> Messages => ...`
- `Status` (property): `public ApplicationServiceStatus Status { get; set; }`
- `AddMessage` (method): `public void AddMessage(string error)`
- `AddMessages` (method): `public void AddMessages(IEnumerable<string> errors)`
- `ClearMessages` (method): `public void ClearMessages()`

#### `Zamin.Core.RequestResponse.Common.ApplicationServiceStatus` (enum)

شمارشی (enum) «ApplicationServiceStatus» در namespace Zamin.Core.RequestResponse.Common. تعریف enum عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین.

**اعضا (5):**

- `Ok` (enum_member): `Ok = 1`
- `NotFound` (enum_member): `NotFound = 2`
- `ValidationError` (enum_member): `ValidationError = 3`
- `InvalidDomainState` (enum_member): `InvalidDomainState = 4`
- `Exception` (enum_member): `Exception = 5`

#### `Zamin.Core.RequestResponse.Common.IApplicationServiceResult` (interface)

قرارداد (اینترفیس) «IApplicationServiceResult» در namespace Zamin.Core.RequestResponse.Common. قرارداد رفتار برای مصرف‌کنندگان و پیاده‌سازی‌های جایگزین.

**اعضا (2):**

- `Messages` (property): `IEnumerable<string> Messages { get; }`
- `Status` (property): `ApplicationServiceStatus Status { get; set; }`

### Namespace: `Zamin.Core.RequestResponse.Endpoints`

#### `Zamin.Core.RequestResponse.Endpoints.IWebRequest` (interface)

قرارداد (اینترفیس) «IWebRequest» در namespace Zamin.Core.RequestResponse.Endpoints. قرارداد رفتار برای مصرف‌کنندگان و پیاده‌سازی‌های جایگزین.

**اعضا (1):**

- `Path` (property): `string Path { get; }`

### Namespace: `Zamin.Core.RequestResponse.Queries`

#### `Zamin.Core.RequestResponse.Queries.IPageQuery<TData>` (interface)

اینترفیسی جهت استفاده به عنوان مارکر برای کلاس‌هایی که پارامتر‌های ورودی را برای جستجو تعیین می‌کنند! در صورتی که جستجو نیاز به صفحه بندی داشته باشد از این اینترفیس استفاده می‌شود

- **Base:** `IQuery<TData>`

**اعضا (6):**

- `PageNumber` (property): `public int PageNumber { get; set; }`
- `PageSize` (property): `public int PageSize { get; set; }`
- `SkipCount` (property): `public int SkipCount => ...`
- `NeedTotalCount` (property): `public bool NeedTotalCount { get; set; }`
- `SortBy` (property): `public string SortBy { get; set; }`
- `SortAscending` (property): `public bool SortAscending { get; set; }`

#### `Zamin.Core.RequestResponse.Queries.IQuery<TData>` (interface)

اینترفیسی جهت استفاده به عنوان مارکر برای کلاس‌هایی که پارامتر‌های ورودی را برای جستجو تعیین می‌کنند!

_اعضای عمومی استخراج‌شده ندارد._

#### `Zamin.Core.RequestResponse.Queries.PageQuery<TData>` (class)

کلاس پایه جهت استفاده به عنوان مارکر برای کلاس‌هایی که پارامتر‌های ورودی را برای جستجو تعیین می‌کنند! در صورتی که جستجو نیاز به صفحه بندی داشته باشد از این اینترفیس استفاده می‌شود

- **Base:** `IPageQuery<TData>`

**اعضا (6):**

- `PageNumber` (property): `public int PageNumber { get; set; }`
- `PageSize` (property): `public int PageSize { get; set; }`
- `SkipCount` (property): `public int SkipCount => ...`
- `NeedTotalCount` (property): `public bool NeedTotalCount { get; set; }`
- `SortBy` (property): `public string SortBy { get; set; }`
- `SortAscending` (property): `public bool SortAscending { get; set; }`

#### `Zamin.Core.RequestResponse.Queries.PageQueryRecord<TData>` (record)

رکورد پایه جهت استفاده به عنوان مارکر برای رکورد‌هایی که پارامتر‌های ورودی را برای جستجو تعیین می‌کنند! در صورتی که جستجو نیاز به صفحه بندی داشته باشد از این اینترفیس استفاده می‌شود

- **Base:** `IPageQuery<TData>`

**اعضا (6):**

- `PageNumber` (property): `public int PageNumber { get; set; }`
- `PageSize` (property): `public int PageSize { get; set; }`
- `SkipCount` (property): `public int SkipCount => ...`
- `NeedTotalCount` (property): `public bool NeedTotalCount { get; set; }`
- `SortBy` (property): `public string SortBy { get; set; }`
- `SortAscending` (property): `public bool SortAscending { get; set; }`

#### `Zamin.Core.RequestResponse.Queries.PagedData<T>` (class)

ساختار پایه جهت بازگشت داده‌ها هنگام کوئری گرفتن وقتی که Paging دارد

**اعضا (4):**

- `QueryResult` (property): `public List<T> QueryResult { get; set; }`
- `PageNumber` (property): `public int PageNumber { get; set; }`
- `PageSize` (property): `public int PageSize { get; set; }`
- `TotalCount` (property): `public int TotalCount { get; set; }`

#### `Zamin.Core.RequestResponse.Queries.QueryResult<TData>` (class)

نتیجه یک کوئری را بازگشت می‌دهد

- **Base:** `ApplicationServiceResult`

**اعضا (2):**

- `_data` (field): `public TData? _data;`
- `Data` (property): `public TData? Data { get; }`

### Namespace: `Zamin.EndPoints.Web.Controllers`

#### `Zamin.EndPoints.Web.Controllers.BaseController` (class)

کلاس «BaseController» در namespace Zamin.EndPoints.Web.Controllers. کنترلر endpoint برای دریافت درخواست HTTP و ارجاع به لایه اپلیکیشن. ارث‌بری/پیاده‌سازی: Controller. مرتبط: Controller.

- **Base:** `Controller`

**اعضا (13):**

- `CommandDispatcher` (property): `protected ICommandDispatcher CommandDispatcher => ...`
- `QueryDispatcher` (property): `protected IQueryDispatcher QueryDispatcher => ...`
- `EventDispatcher` (property): `protected IEventDispatcher EventDispatcher => ...`
- `ZaminApplicationContext` (property): `protected ZaminServices ZaminApplicationContext => ...`
- `Excel` (method): `public IActionResult Excel<T>(List<T> list)`
- `Excel` (method): `public IActionResult Excel<T>(List<T> list, string fileName)`
- `Create` (method): `protected async Task<IActionResult> Create<TCommand, TCommandResult>(TCommand command) where TCommand : class, ICommand<TCommandResult>`
- `Create` (method): `protected async Task<IActionResult> Create<TCommand>(TCommand command) where TCommand : class, ICommand`
- `Edit` (method): `protected async Task<IActionResult> Edit<TCommand, TCommandResult>(TCommand command) where TCommand : class, ICommand<TCommandResult>`
- `Edit` (method): `protected async Task<IActionResult> Edit<TCommand>(TCommand command) where TCommand : class, ICommand`
- `Delete` (method): `protected async Task<IActionResult> Delete<TCommand, TCommandResult>(TCommand command) where TCommand : class, ICommand<TCommandResult>`
- `Delete` (method): `protected async Task<IActionResult> Delete<TCommand>(TCommand command) where TCommand : class, ICommand`
- `Query` (method): `protected async Task<IActionResult> Query<TQuery, TQueryResult>(TQuery query) where TQuery : class, IQuery<TQueryResult>`

### Namespace: `Zamin.EndPoints.Web.Extensions`

#### `Zamin.EndPoints.Web.Extensions.ClaimExtensions` (class)

کلاس «ClaimExtensions» در namespace Zamin.EndPoints.Web.Extensions. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

**اعضا (1):**

- `GetClaim` (method): `public static string GetClaim(this ClaimsPrincipal userClaimsPrincipal, string claimType)`

#### `Zamin.EndPoints.Web.Extensions.HttpContextExtensions` (class)

کلاس «HttpContextExtensions» در namespace Zamin.EndPoints.Web.Extensions. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

**اعضا (4):**

- `CommandDispatcher` (method): `public static ICommandDispatcher CommandDispatcher(this HttpContext httpContext)`
- `QueryDispatcher` (method): `public static IQueryDispatcher QueryDispatcher(this HttpContext httpContext)`
- `EventDispatcher` (method): `public static IEventDispatcher EventDispatcher(this HttpContext httpContext)`
- `ZaminApplicationContext` (method): `public static ZaminServices ZaminApplicationContext(this HttpContext httpContext)`

### Namespace: `Zamin.EndPoints.Web.Extensions.ModelBinding`

#### `Zamin.EndPoints.Web.Extensions.ModelBinding.NonValidatingValidatorExtensions` (class)

کلاس «NonValidatingValidatorExtensions» در namespace Zamin.EndPoints.Web.Extensions.ModelBinding. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

**اعضا (1):**

- `AddNonValidatingValidator` (method): `public static IServiceCollection AddNonValidatingValidator(this IServiceCollection services)`

### Namespace: `Zamin.EndPoints.Web.Filters`

#### `Zamin.EndPoints.Web.Filters.CamelCaseJsonAttribute` (class)

کلاس «CamelCaseJsonAttribute» در namespace Zamin.EndPoints.Web.Filters. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین. ارث‌بری/پیاده‌سازی: Attribute. اتریبیوت‌ها: AttributeUsage(AttributeTargets.Method). مرتبط: Attribute.

- **Base:** `Attribute`

_اعضای عمومی استخراج‌شده ندارد._

#### `Zamin.EndPoints.Web.Filters.CamelCaseJsonFilter` (class)

کلاس «CamelCaseJsonFilter» در namespace Zamin.EndPoints.Web.Filters. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین. ارث‌بری/پیاده‌سازی: IAsyncResultFilter. مرتبط: IAsyncResultFilter.

- **Base:** `IAsyncResultFilter`

**اعضا (1):**

- `OnResultExecutionAsync` (method): `public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)`

#### `Zamin.EndPoints.Web.Filters.PascalCaseJsonAttribute` (class)

کلاس «PascalCaseJsonAttribute» در namespace Zamin.EndPoints.Web.Filters. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین. ارث‌بری/پیاده‌سازی: Attribute. اتریبیوت‌ها: AttributeUsage(AttributeTargets.Method). مرتبط: Attribute.

- **Base:** `Attribute`

_اعضای عمومی استخراج‌شده ندارد._

#### `Zamin.EndPoints.Web.Filters.PascalCaseJsonFilter` (class)

کلاس «PascalCaseJsonFilter» در namespace Zamin.EndPoints.Web.Filters. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین. ارث‌بری/پیاده‌سازی: IAsyncResultFilter. مرتبط: IAsyncResultFilter.

- **Base:** `IAsyncResultFilter`

**اعضا (1):**

- `OnResultExecutionAsync` (method): `public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)`

#### `Zamin.EndPoints.Web.Filters.ValidateModelStateAttribute` (class)

کلاس «ValidateModelStateAttribute» در namespace Zamin.EndPoints.Web.Filters. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین. ارث‌بری/پیاده‌سازی: ActionFilterAttribute. مرتبط: ActionFilterAttribute.

- **Base:** `ActionFilterAttribute`

**اعضا (1):**

- `OnActionExecuting` (method): `public override void OnActionExecuting(ActionExecutingContext context)`

### Namespace: `Zamin.EndPoints.Web.Middlewares.ApiExceptionHandler`

#### `Zamin.EndPoints.Web.Middlewares.ApiExceptionHandler.ApiError` (class)

کلاس «ApiError» در namespace Zamin.EndPoints.Web.Middlewares.ApiExceptionHandler. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین.

**اعضا (6):**

- `Id` (property): `public string Id { get; set; }`
- `Status` (property): `public short Status { get; set; }`
- `Code` (property): `public string Code { get; set; }`
- `Links` (property): `public string Links { get; set; }`
- `Title` (property): `public string Title { get; set; }`
- `Detail` (property): `public string Detail { get; set; }`

#### `Zamin.EndPoints.Web.Middlewares.ApiExceptionHandler.ApiExceptionMiddleware` (class)

کلاس «ApiExceptionMiddleware» در namespace Zamin.EndPoints.Web.Middlewares.ApiExceptionHandler. استثنای دامنه/چارچوب برای اعلام نقض قاعده یا خطای قابل‌کنترل. وابستگی‌های سازنده (DI): ApiExceptionOptions options, RequestDelegate next, ILogger<ApiExceptionMiddleware> logger, IJson…

**اعضا (2):**

- `.ctor` (constructor): `public ApiExceptionMiddleware(ApiExceptionOptions options, RequestDelegate next, ILogger<ApiExceptionMiddleware> logger, IJsonSerializer serializer,ITranslator translator )`
- `Invoke` (method): `public async Task Invoke(HttpContext context)`

#### `Zamin.EndPoints.Web.Middlewares.ApiExceptionHandler.ApiExceptionMiddlewareExtensions` (class)

کلاس «ApiExceptionMiddlewareExtensions» در namespace Zamin.EndPoints.Web.Middlewares.ApiExceptionHandler. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

**اعضا (2):**

- `UseApiExceptionHandler` (method): `public static IApplicationBuilder UseApiExceptionHandler(this IApplicationBuilder builder)`
- `UseApiExceptionHandler` (method): `public static IApplicationBuilder UseApiExceptionHandler(this IApplicationBuilder builder, Action<ApiExceptionOptions> configureOptions)`

#### `Zamin.EndPoints.Web.Middlewares.ApiExceptionHandler.ApiExceptionOptions` (class)

کلاس «ApiExceptionOptions» در namespace Zamin.EndPoints.Web.Middlewares.ApiExceptionHandler. مدل تنظیمات قابل بایند شدن از configuration.

**اعضا (2):**

- `AddResponseDetails` (property): `public Action<HttpContext, Exception, ApiError> AddResponseDetails { get; set; }`
- `DetermineLogLevel` (property): `public Func<Exception, LogLevel> DetermineLogLevel { get; set; }`

### Namespace: `Zamin.EndPoints.Web.ModelBinding`

#### `Zamin.EndPoints.Web.ModelBinding.NonValidatingValidator` (class)

کلاس «NonValidatingValidator» در namespace Zamin.EndPoints.Web.ModelBinding. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین. ارث‌بری/پیاده‌سازی: IObjectModelValidator. مرتبط: IObjectModelValidator.

- **Base:** `IObjectModelValidator`

**اعضا (1):**

- `Validate` (method): `public void Validate(ActionContext actionContext, ValidationStateDictionary validationState, string prefix, object model)`

### Namespace: `Zamin.Extensions.Caching.Abstractions`

#### `Zamin.Extensions.Caching.Abstractions.FakeCacheAdapter` (class)

کلاس «FakeCacheAdapter» در namespace Zamin.Extensions.Caching.Abstractions. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین. ارث‌بری/پیاده‌سازی: ICacheAdapter. مرتبط: ICacheAdapter (same namespace).

- **Base:** `ICacheAdapter`

**اعضا (3):**

- `Add` (method): `public void Add<TInput>(string key, TInput obj, DateTime? AbsoluteExpiration, TimeSpan? SlidingExpiration)`
- `Get` (method): `public TOutput Get<TOutput>(string key)`
- `RemoveCache` (method): `public void RemoveCache(string key)`

#### `Zamin.Extensions.Caching.Abstractions.ICacheAdapter` (interface)

قرارداد (اینترفیس) «ICacheAdapter» در namespace Zamin.Extensions.Caching.Abstractions. قرارداد رفتار برای مصرف‌کنندگان و پیاده‌سازی‌های جایگزین.

**اعضا (3):**

- `Add` (method): `void Add<TInput>(string key, TInput obj, DateTime? AbsoluteExpiration, TimeSpan? SlidingExpiration)`
- `Get` (method): `TOutput Get<TOutput>(string key)`
- `RemoveCache` (method): `void RemoveCache(string key)`

### Namespace: `Zamin.Extensions.Caching.Distributed.Redis.Options`

#### `Zamin.Extensions.Caching.Distributed.Redis.Options.DistributedRedisCacheOptions` (class)

کلاس «DistributedRedisCacheOptions» در namespace Zamin.Extensions.Caching.Distributed.Redis.Options. مدل تنظیمات قابل بایند شدن از configuration.

**اعضا (2):**

- `Configuration` (property): `public string Configuration { get; set; }`
- `InstanceName` (property): `public string InstanceName { get; set; }`

### Namespace: `Zamin.Extensions.Caching.Distributed.Redis.Services`

#### `Zamin.Extensions.Caching.Distributed.Redis.Services.DistributedRedisCacheAdapter` (class)

کلاس «DistributedRedisCacheAdapter» در namespace Zamin.Extensions.Caching.Distributed.Redis.Services. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین. ارث‌بری/پیاده‌سازی: ICacheAdapter. وابستگی‌های سازنده (DI): IDistributedCache cache, IJsonSerializer serializer, ILogg…

- **Base:** `ICacheAdapter`

**اعضا (4):**

- `.ctor` (constructor): `public DistributedRedisCacheAdapter(IDistributedCache cache, IJsonSerializer serializer, ILogger<DistributedRedisCacheAdapter> logger)`
- `Add` (method): `public void Add<TInput>(string key, TInput obj, DateTime? absoluteExpiration, TimeSpan? slidingExpiration)`
- `Get` (method): `public TOutput Get<TOutput>(string key)`
- `RemoveCache` (method): `public void RemoveCache(string key)`

### Namespace: `Zamin.Extensions.Caching.Distributed.Sql.Options`

#### `Zamin.Extensions.Caching.Distributed.Sql.Options.DistributedSqlCacheOptions` (class)

کلاس «DistributedSqlCacheOptions» در namespace Zamin.Extensions.Caching.Distributed.Sql.Options. مدل تنظیمات قابل بایند شدن از configuration.

**اعضا (4):**

- `AutoCreateTable` (property): `public bool AutoCreateTable { get; set; }`
- `ConnectionString` (property): `public string ConnectionString { get; set; }`
- `SchemaName` (property): `public string SchemaName { get; set; }`
- `TableName` (property): `public string TableName { get; set; }`

### Namespace: `Zamin.Extensions.Caching.Distributed.Sql.Services`

#### `Zamin.Extensions.Caching.Distributed.Sql.Services.DistributedSqlCacheAdapter` (class)

کلاس «DistributedSqlCacheAdapter» در namespace Zamin.Extensions.Caching.Distributed.Sql.Services. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین. ارث‌بری/پیاده‌سازی: ICacheAdapter. وابستگی‌های سازنده (DI): IDistributedCache cache, IJsonSerializer serializer, ILogger<D…

- **Base:** `ICacheAdapter`

**اعضا (4):**

- `.ctor` (constructor): `public DistributedSqlCacheAdapter(IDistributedCache cache, IJsonSerializer serializer, ILogger<DistributedSqlCacheAdapter> logger)`
- `Add` (method): `public void Add<TInput>(string key, TInput obj, DateTime? absoluteExpiration, TimeSpan? slidingExpiration)`
- `Get` (method): `public TOutput Get<TOutput>(string key)`
- `RemoveCache` (method): `public void RemoveCache(string key)`

### Namespace: `Zamin.Extensions.Caching.InMemory.Services`

#### `Zamin.Extensions.Caching.InMemory.Services.InMemoryCacheAdapter` (class)

کلاس «InMemoryCacheAdapter» در namespace Zamin.Extensions.Caching.InMemory.Services. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین. ارث‌بری/پیاده‌سازی: ICacheAdapter. وابستگی‌های سازنده (DI): IMemoryCache memoryCache, IJsonSerializer jsonSerializer, ILogger<InMemoryC…

- **Base:** `ICacheAdapter`

**اعضا (4):**

- `.ctor` (constructor): `public InMemoryCacheAdapter(IMemoryCache memoryCache, IJsonSerializer jsonSerializer, ILogger<InMemoryCacheAdapter> logger)`
- `Add` (method): `public void Add<TInput>(string key, TInput obj, DateTime? absoluteExpiration, TimeSpan? slidingExpiration)`
- `Get` (method): `public TOutput Get<TOutput>(string key)`
- `RemoveCache` (method): `public void RemoveCache(string key)`

### Namespace: `Zamin.Extensions.ChangeDataLog.Abstractions`

#### `Zamin.Extensions.ChangeDataLog.Abstractions.DatabaseChangeType` (enum)

شمارشی (enum) «DatabaseChangeType» در namespace Zamin.Extensions.ChangeDataLog.Abstractions. تعریف enum عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین.

**اعضا (3):**

- `Insert` (enum_member): `Insert = 1`
- `Update` (enum_member): `Update = 2`
- `Delete` (enum_member): `Delete = 3`

#### `Zamin.Extensions.ChangeDataLog.Abstractions.EntityChageInterceptorItem` (class)

کلاس «EntityChageInterceptorItem» در namespace Zamin.Extensions.ChangeDataLog.Abstractions. موجودیت دامنه با هویت و قابلیت auditable.

**اعضا (11):**

- `Id` (property): `public Guid Id { get; set; }`
- `ContextName` (property): `public string ContextName { get; set; }`
- `EntityType` (property): `public string EntityType { get; set; }`
- `EntityId` (property): `public string EntityId { get; set; }`
- `UserId` (property): `public string UserId { get; set; }`
- `Ip` (property): `public string Ip { get; set; }`
- `TransactionId` (property): `public string TransactionId { get; set; }`
- `DateOfOccurrence` (property): `public DateTime DateOfOccurrence { get; set; }`
- `ChangeType` (property): `public string ChangeType { get; set; }`
- `PropertyChangeLogItems` (property): `public List<PropertyChangeLogItem> PropertyChangeLogItems { get; set; }`
- `AddPropertyChangeItem` (method): `public void AddPropertyChangeItem(string propertyName, string value)`

#### `Zamin.Extensions.ChangeDataLog.Abstractions.IEntityChageInterceptorItemRepository` (interface)

قرارداد (اینترفیس) «IEntityChageInterceptorItemRepository» در namespace Zamin.Extensions.ChangeDataLog.Abstractions. قرارداد دسترسی به داده برای ذخیره و بازیابی aggregate/entity.

**اعضا (2):**

- `Save` (method): `public void Save(List<EntityChageInterceptorItem> entityChageInterceptorItems, IDbTransaction transaction)`
- `SaveAsync` (method): `public Task SaveAsync(List<EntityChageInterceptorItem> entityChageInterceptorItems, IDbTransaction transaction)`

#### `Zamin.Extensions.ChangeDataLog.Abstractions.PropertyChangeLogItem` (class)

کلاس «PropertyChangeLogItem» در namespace Zamin.Extensions.ChangeDataLog.Abstractions. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین.

**اعضا (4):**

- `Id` (property): `public Guid Id { get; set; }`
- `ChageInterceptorItemId` (property): `public Guid ChageInterceptorItemId { get; set; }`
- `PropertyName` (property): `public string PropertyName { get; set; }`
- `Value` (property): `public string Value { get; set; }`

### Namespace: `Zamin.Extensions.ChangeDataLog.Sql`

#### `Zamin.Extensions.ChangeDataLog.Sql.DapperEntityChangeInterceptorItemRepository` (class)

کلاس «DapperEntityChangeInterceptorItemRepository» در namespace Zamin.Extensions.ChangeDataLog.Sql. موجودیت دامنه با هویت و قابلیت auditable. ارث‌بری/پیاده‌سازی: IEntityChageInterceptorItemRepository. وابستگی‌های سازنده (DI): IOptions<ChangeDataLogSqlOptions> options, ILogger<Da…

- **Base:** `IEntityChageInterceptorItemRepository`

**اعضا (3):**

- `.ctor` (constructor): `public DapperEntityChangeInterceptorItemRepository(IOptions<ChangeDataLogSqlOptions> options, ILogger<DapperEntityChangeInterceptorItemRepository> logger)`
- `Save` (method): `public void Save(List<EntityChageInterceptorItem> entityChangeInterceptorItems, IDbTransaction transaction = null)`
- `SaveAsync` (method): `public async Task SaveAsync(List<EntityChageInterceptorItem> entityChangeInterceptorItems, IDbTransaction transaction = null)`

### Namespace: `Zamin.Extensions.ChangeDataLog.Sql.Options`

#### `Zamin.Extensions.ChangeDataLog.Sql.Options.ChangeDataLogHamsterOptions` (record)

رکورد «ChangeDataLogHamsterOptions» در namespace Zamin.Extensions.ChangeDataLog.Sql.Options. مدل تنظیمات قابل بایند شدن از configuration.

**اعضا (2):**

- `PropertyForReject` (property): `public List<string> PropertyForReject { get; set; }`
- `BusinessIdFieldName` (property): `public string BusinessIdFieldName { get; set; }`

#### `Zamin.Extensions.ChangeDataLog.Sql.Options.ChangeDataLogSqlOptions` (record)

رکورد «ChangeDataLogSqlOptions» در namespace Zamin.Extensions.ChangeDataLog.Sql.Options. مدل تنظیمات قابل بایند شدن از configuration.

**اعضا (5):**

- `ConnectionString` (property): `public string ConnectionString { get; set; }`
- `AutoCreateSqlTable` (property): `public bool AutoCreateSqlTable { get; set; }`
- `EntityTableName` (property): `public string EntityTableName { get; set; }`
- `PropertyTableName` (property): `public string PropertyTableName { get; set; }`
- `SchemaName` (property): `public string SchemaName { get; set; }`

### Namespace: `Zamin.Extensions.DependencyInjection.Abstractions`

#### `Zamin.Extensions.DependencyInjection.Abstractions.IScopeLifetime` (interface)

قرارداد (اینترفیس) «IScopeLifetime» در namespace Zamin.Extensions.DependencyInjection.Abstractions. قرارداد رفتار برای مصرف‌کنندگان و پیاده‌سازی‌های جایگزین.

_اعضای عمومی استخراج‌شده ندارد._

#### `Zamin.Extensions.DependencyInjection.Abstractions.ISingletoneLifetime` (interface)

قرارداد (اینترفیس) «ISingletoneLifetime» در namespace Zamin.Extensions.DependencyInjection.Abstractions. قرارداد رفتار برای مصرف‌کنندگان و پیاده‌سازی‌های جایگزین.

_اعضای عمومی استخراج‌شده ندارد._

#### `Zamin.Extensions.DependencyInjection.Abstractions.ITransientLifetime` (interface)

قرارداد (اینترفیس) «ITransientLifetime» در namespace Zamin.Extensions.DependencyInjection.Abstractions. قرارداد رفتار برای مصرف‌کنندگان و پیاده‌سازی‌های جایگزین.

_اعضای عمومی استخراج‌شده ندارد._

### Namespace: `Zamin.Extensions.DependencyInjection.Extensions.DependencyInjection`

#### `Zamin.Extensions.DependencyInjection.Extensions.DependencyInjection.DependencyInjectionServiceCollectionExtensions` (class)

کلاس «DependencyInjectionServiceCollectionExtensions» در namespace Zamin.Extensions.DependencyInjection.Extensions.DependencyInjection. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

**اعضا (3):**

- `AddCustomeDepenecies` (method): `public static IServiceCollection AddCustomeDepenecies(this IServiceCollection services, IConfiguration configuration)`
- `AddCustomeDepenecies` (method): `public static IServiceCollection AddCustomeDepenecies(this IServiceCollection services, IConfiguration configuration, string sectionName)`
- `AddCustomeDepenecies` (method): `public static IServiceCollection AddCustomeDepenecies(this IServiceCollection services, Action<DependencyInjectionOption> setupAction)`

### Namespace: `Zamin.Extensions.DependencyInjection`

#### `Zamin.Extensions.DependencyInjection.AddApiConfigurationExtensions` (class)

کلاس «AddApiConfigurationExtensions» در namespace Zamin.Extensions.DependencyInjection. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

**اعضا (2):**

- `AddZaminApiCore` (method): `public static IServiceCollection AddZaminApiCore(this IServiceCollection services, params string[] assemblyNamesForLoad)`
- `UseZaminApiExceptionHandler` (method): `public static void UseZaminApiExceptionHandler(this IApplicationBuilder app)`

#### `Zamin.Extensions.DependencyInjection.AddApplicationServicesExtensions` (class)

کلاس «AddApplicationServicesExtensions» در namespace Zamin.Extensions.DependencyInjection. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

**اعضا (1):**

- `AddZaminApplicationServices` (method): `public static IServiceCollection AddZaminApplicationServices(this IServiceCollection services, IEnumerable<Assembly> assembliesForSearch)`

#### `Zamin.Extensions.DependencyInjection.AddDataAccessExtentsions` (class)

توابع کمکی جهت ثبت نیازمندی‌های لایه داده

**اعضا (3):**

- `AddZaminDataAccess` (method): `public static IServiceCollection AddZaminDataAccess( this IServiceCollection services, IEnumerable<Assembly> assembliesForSearch)`
- `AddRepositories` (method): `public static IServiceCollection AddRepositories(this IServiceCollection services, IEnumerable<Assembly> assembliesForSearch)`
- `AddUnitOfWorks` (method): `public static IServiceCollection AddUnitOfWorks(this IServiceCollection services, IEnumerable<Assembly> assembliesForSearch)`

#### `Zamin.Extensions.DependencyInjection.AddZaminServicesExtensions` (class)

کلاس «AddZaminServicesExtensions» در namespace Zamin.Extensions.DependencyInjection. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

**اعضا (1):**

- `AddZaminUntilityServices` (method): `public static IServiceCollection AddZaminUntilityServices( this IServiceCollection services)`

#### `Zamin.Extensions.DependencyInjection.ApiAuthenticationServiceCollectionExtensions` (class)

کلاس «ApiAuthenticationServiceCollectionExtensions» در namespace Zamin.Extensions.DependencyInjection. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

**اعضا (3):**

- `AddZaminApiAuthentication` (method): `public static IServiceCollection AddZaminApiAuthentication(this IServiceCollection services, IConfiguration configuration, string sectionName)`
- `AddZaminApiAuthentication` (method): `public static IServiceCollection AddZaminApiAuthentication(this IServiceCollection services, IConfiguration configuration)`
- `AddZaminApiAuthentication` (method): `public static IServiceCollection AddZaminApiAuthentication(this IServiceCollection services, Action<ApiAuthenticationOption> action)`

#### `Zamin.Extensions.DependencyInjection.AutoMapperServiceCollectionExtensions` (class)

کلاس «AutoMapperServiceCollectionExtensions» در namespace Zamin.Extensions.DependencyInjection. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

**اعضا (3):**

- `AddZaminAutoMapperProfiles` (method): `public static IServiceCollection AddZaminAutoMapperProfiles(this IServiceCollection services, IConfiguration configuration, string sectionName)`
- `AddZaminAutoMapperProfiles` (method): `public static IServiceCollection AddZaminAutoMapperProfiles(this IServiceCollection services, IConfiguration configuration)`
- `AddZaminAutoMapperProfiles` (method): `public static IServiceCollection AddZaminAutoMapperProfiles(this IServiceCollection services, Action<AutoMapperOption> setupAction)`

#### `Zamin.Extensions.DependencyInjection.ChageDatalogServiceCollectionExtensions` (class)

کلاس «ChageDatalogServiceCollectionExtensions» در namespace Zamin.Extensions.DependencyInjection. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

**اعضا (6):**

- `AddZaminHamsterChageDatalog` (method): `public static IServiceCollection AddZaminHamsterChageDatalog(this IServiceCollection services, IConfiguration configuration)`
- `AddZaminHamsterChageDatalog` (method): `public static IServiceCollection AddZaminHamsterChageDatalog(this IServiceCollection services, IConfiguration configuration, string sectionName)`
- `AddZaminHamsterChageDatalog` (method): `public static IServiceCollection AddZaminHamsterChageDatalog(this IServiceCollection services, Action<ChangeDataLogHamsterOptions> setupAction)`
- `AddZaminChageDatalogDalSql` (method): `public static IServiceCollection AddZaminChageDatalogDalSql(this IServiceCollection services, IConfiguration configuration)`
- `AddZaminChageDatalogDalSql` (method): `public static IServiceCollection AddZaminChageDatalogDalSql(this IServiceCollection services, IConfiguration configuration, string sectionName)`
- `AddZaminChageDatalogDalSql` (method): `public static IServiceCollection AddZaminChageDatalogDalSql(this IServiceCollection services, Action<ChangeDataLogSqlOptions> setupAction)`

#### `Zamin.Extensions.DependencyInjection.DistributedRedisCacheServiceCollectionExtensions` (class)

کلاس «DistributedRedisCacheServiceCollectionExtensions» در namespace Zamin.Extensions.DependencyInjection. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

**اعضا (3):**

- `AddZaminRedisDistributedCache` (method): `public static IServiceCollection AddZaminRedisDistributedCache(this IServiceCollection services, IConfiguration configuration, string sectionName)`
- `AddZaminRedisDistributedCache` (method): `public static IServiceCollection AddZaminRedisDistributedCache(this IServiceCollection services, IConfiguration configuration)`
- `AddZaminRedisDistributedCache` (method): `public static IServiceCollection AddZaminRedisDistributedCache(this IServiceCollection services, Action<DistributedRedisCacheOptions> setupAction)`

#### `Zamin.Extensions.DependencyInjection.DistributedSqlCacheServiceCollectionExtensions` (class)

کلاس «DistributedSqlCacheServiceCollectionExtensions» در namespace Zamin.Extensions.DependencyInjection. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

**اعضا (3):**

- `AddZaminSqlDistributedCache` (method): `public static IServiceCollection AddZaminSqlDistributedCache(this IServiceCollection services, IConfiguration configuration, string sectionName)`
- `AddZaminSqlDistributedCache` (method): `public static IServiceCollection AddZaminSqlDistributedCache(this IServiceCollection services, IConfiguration configuration)`
- `AddZaminSqlDistributedCache` (method): `public static IServiceCollection AddZaminSqlDistributedCache(this IServiceCollection services, Action<DistributedSqlCacheOptions> setupAction)`

#### `Zamin.Extensions.DependencyInjection.EPPlusExcelSerializerServiceCollectionExtensions` (class)

کلاس «EPPlusExcelSerializerServiceCollectionExtensions» در namespace Zamin.Extensions.DependencyInjection. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

**اعضا (1):**

- `AddEPPlusExcelSerializer` (method): `public static IServiceCollection AddEPPlusExcelSerializer(this IServiceCollection services)`

#### `Zamin.Extensions.DependencyInjection.Extensions` (class)

کلاس «Extensions» در namespace Zamin.Extensions.DependencyInjection. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

**اعضا (5):**

- `AddZaminDependencies` (method): `public static IServiceCollection AddZaminDependencies(this IServiceCollection services, params string[] assemblyNamesForSearch)`
- `AddCustomeDepenecies` (method): `public static IServiceCollection AddCustomeDepenecies(this IServiceCollection services, IEnumerable<Assembly> assemblies)`
- `AddWithTransientLifetime` (method): `public static IServiceCollection AddWithTransientLifetime(this IServiceCollection services, IEnumerable<Assembly> assembliesForSearch, params Type[] assignableTo)`
- `AddWithScopedLifetime` (method): `public static IServiceCollection AddWithScopedLifetime(this IServiceCollection services, IEnumerable<Assembly> assembliesForSearch, params Type[] assignableTo)`
- `AddWithSingletonLifetime` (method): `public static IServiceCollection AddWithSingletonLifetime(this IServiceCollection services, IEnumerable<Assembly> assembliesForSearch, params Type[] assignableTo)`

#### `Zamin.Extensions.DependencyInjection.InMemoryCachingServiceCollectionExtensions` (class)

کلاس «InMemoryCachingServiceCollectionExtensions» در namespace Zamin.Extensions.DependencyInjection. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

**اعضا (1):**

- `AddZaminInMemoryCaching` (method): `public static IServiceCollection AddZaminInMemoryCaching(this IServiceCollection services)`

#### `Zamin.Extensions.DependencyInjection.JwtTokenExtensions` (class)

کلاس «JwtTokenExtensions» در namespace Zamin.Extensions.DependencyInjection. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

**اعضا (1):**

- `AddJwtTokenSupoort` (method): `public static AuthenticationBuilder AddJwtTokenSupoort(this AuthenticationBuilder authenticationBuilder, IServiceCollection services, ProviderOption provider)`

#### `Zamin.Extensions.DependencyInjection.MessageInboxServiceCollectionExtensions` (class)

کلاس «MessageInboxServiceCollectionExtensions» در namespace Zamin.Extensions.DependencyInjection. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

**اعضا (6):**

- `AddZaminMessageInboxDalSql` (method): `public static IServiceCollection AddZaminMessageInboxDalSql(this IServiceCollection services, IConfiguration configuration)`
- `AddZaminMessageInboxDalSql` (method): `public static IServiceCollection AddZaminMessageInboxDalSql(this IServiceCollection services, IConfiguration configuration, string sectionName)`
- `AddZaminMessageInboxDalSql` (method): `public static IServiceCollection AddZaminMessageInboxDalSql(this IServiceCollection services, Action<MessageInboxDalDapperOptions> setupAction)`
- `AddZaminMessageInbox` (method): `public static IServiceCollection AddZaminMessageInbox(this IServiceCollection services, IConfiguration configuration)`
- `AddZaminMessageInbox` (method): `public static IServiceCollection AddZaminMessageInbox(this IServiceCollection services, IConfiguration configuration, string sectionName)`
- `AddZaminMessageInbox` (method): `public static IServiceCollection AddZaminMessageInbox(this IServiceCollection services, Action<MessageInboxOptions> setupAction)`

#### `Zamin.Extensions.DependencyInjection.MicrosoftSerializerServiceCollectionExtensions` (class)

کلاس «MicrosoftSerializerServiceCollectionExtensions» در namespace Zamin.Extensions.DependencyInjection. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

**اعضا (1):**

- `AddZaminMicrosoftSerializer` (method): `public static IServiceCollection AddZaminMicrosoftSerializer(this IServiceCollection services)`

#### `Zamin.Extensions.DependencyInjection.NewtonSoftSerializerServiceCollectionExtensions` (class)

کلاس «NewtonSoftSerializerServiceCollectionExtensions» در namespace Zamin.Extensions.DependencyInjection. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

**اعضا (1):**

- `AddZaminNewtonSoftSerializer` (method): `public static IServiceCollection AddZaminNewtonSoftSerializer(this IServiceCollection services)`

#### `Zamin.Extensions.DependencyInjection.ParrotTranslatorServiceCollectionExtensions` (class)

کلاس «ParrotTranslatorServiceCollectionExtensions» در namespace Zamin.Extensions.DependencyInjection. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

**اعضا (3):**

- `AddZaminParrotTranslator` (method): `public static IServiceCollection AddZaminParrotTranslator(this IServiceCollection services, IConfiguration configuration)`
- `AddZaminParrotTranslator` (method): `public static IServiceCollection AddZaminParrotTranslator(this IServiceCollection services, IConfiguration configuration, string sectionName)`
- `AddZaminParrotTranslator` (method): `public static IServiceCollection AddZaminParrotTranslator(this IServiceCollection services, Action<ParrotTranslatorOptions> setupAction)`

#### `Zamin.Extensions.DependencyInjection.PollingPublisherServiceCollectionExtensions` (class)

کلاس «PollingPublisherServiceCollectionExtensions» در namespace Zamin.Extensions.DependencyInjection. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

**اعضا (6):**

- `AddZaminPollingPublisherDalSql` (method): `public static IServiceCollection AddZaminPollingPublisherDalSql(this IServiceCollection services, IConfiguration configuration)`
- `AddZaminPollingPublisherDalSql` (method): `public static IServiceCollection AddZaminPollingPublisherDalSql(this IServiceCollection services, IConfiguration configuration, string sectionName)`
- `AddZaminPollingPublisherDalSql` (method): `public static IServiceCollection AddZaminPollingPublisherDalSql(this IServiceCollection services, Action<PollingPublisherDalRedisOptions> setupAction)`
- `AddZaminPollingPublisher` (method): `public static IServiceCollection AddZaminPollingPublisher(this IServiceCollection services, IConfiguration configuration)`
- `AddZaminPollingPublisher` (method): `public static IServiceCollection AddZaminPollingPublisher(this IServiceCollection services, IConfiguration configuration, string sectionName)`
- `AddZaminPollingPublisher` (method): `public static IServiceCollection AddZaminPollingPublisher(this IServiceCollection services, Action<PollingPublisherOptions> setupAction)`

#### `Zamin.Extensions.DependencyInjection.ProviderExtensions` (class)

کلاس «ProviderExtensions» در namespace Zamin.Extensions.DependencyInjection. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

**اعضا (4):**

- `AddProviderHttpClient` (method): `public static string AddProviderHttpClient(this ProviderOption provider, IServiceCollection services)`
- `GetUserInfoClaims` (method): `public static async Task<List<Claim>> GetUserInfoClaims(this ProviderOption provider, HttpContext httpContext, string httpClientName)`
- `UserInfoEndpointCaller` (method): `public static async Task<List<Claim>> UserInfoEndpointCaller(this ProviderOption provider, HttpContext httpContext, HttpClient client, string token)`
- `CallUserInfoEndpoint` (method): `public static async Task<List<Claim>> CallUserInfoEndpoint(this ProviderOption provider, HttpClient client, string token)`

#### `Zamin.Extensions.DependencyInjection.RabbitMqMessageBusServiceCollectionExtensions` (class)

کلاس «RabbitMqMessageBusServiceCollectionExtensions» در namespace Zamin.Extensions.DependencyInjection. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

**اعضا (5):**

- `AddZaminRabbitMqMessageBus` (method): `public static IServiceCollection AddZaminRabbitMqMessageBus(this IServiceCollection services, IConfiguration configuration, List<Type>? commands = null, Dictionary<string, List<Type>>? events = null)`
- `AddZaminRabbitMqMessageBus` (method): `public static IServiceCollection AddZaminRabbitMqMessageBus(this IServiceCollection services, IConfiguration configuration, string sectionName, List<Type>? commands = null, Dictionary<string, List<Type>>? events = null)`
- `AddZaminRabbitMqMessageBus` (method): `public static IServiceCollection AddZaminRabbitMqMessageBus(this IServiceCollection services, Action<RabbitMqOptions> setupAction, List<Type>? commands = null, Dictionary<string, List<Type>>? events = null)`
- `ReceiveCommandFromRabbitMqMessageBus` (method): `public static void ReceiveCommandFromRabbitMqMessageBus(this IServiceProvider serviceProvider, params string[] commands)`
- `ReceiveEventFromRabbitMqMessageBus` (method): `public static void ReceiveEventFromRabbitMqMessageBus(this IServiceProvider serviceProvider, params KeyValuePair<string, string>[] events)`

#### `Zamin.Extensions.DependencyInjection.ReferenceTokenExtensions` (class)

کلاس «ReferenceTokenExtensions» در namespace Zamin.Extensions.DependencyInjection. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

**اعضا (1):**

- `AddReferenceTokenSupoort` (method): `public static AuthenticationBuilder AddReferenceTokenSupoort(this AuthenticationBuilder authenticationBuilder, IServiceCollection services, ProviderOption provider)`

#### `Zamin.Extensions.DependencyInjection.ScalarServiceCollectionExtensions` (class)

کلاس «ScalarServiceCollectionExtensions» در namespace Zamin.Extensions.DependencyInjection. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

**اعضا (4):**

- `AddZaminScalar` (method): `public static IServiceCollection AddZaminScalar(this IServiceCollection services, IConfiguration configuration, string sectionName)`
- `AddZaminScalar` (method): `public static IServiceCollection AddZaminScalar(this IServiceCollection services, IConfiguration configuration)`
- `AddZaminScalar` (method): `public static IServiceCollection AddZaminScalar(this IServiceCollection services, Action<ScalarOption> action)`
- `UseZaminScalar` (method): `public static void UseZaminScalar(this WebApplication app)`

#### `Zamin.Extensions.DependencyInjection.SerilogServiceCollectionExtensions` (class)

کلاس «SerilogServiceCollectionExtensions» در namespace Zamin.Extensions.DependencyInjection. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

**اعضا (3):**

- `AddZaminSerilog` (method): `public static WebApplicationBuilder AddZaminSerilog(this WebApplicationBuilder builder, IConfiguration configuration, params Type[] enrichersType)`
- `AddZaminSerilog` (method): `public static WebApplicationBuilder AddZaminSerilog(this WebApplicationBuilder builder, IConfiguration configuration, string sectionName, params Type[] enrichersType)`
- `AddZaminSerilog` (method): `public static WebApplicationBuilder AddZaminSerilog(this WebApplicationBuilder builder, Action<SerilogApplicationEnricherOptions> setupAction, params Type[] enrichersType)`

#### `Zamin.Extensions.DependencyInjection.ServiceCollectionExtensions` (class)

کلاس «ServiceCollectionExtensions» در namespace Zamin.Extensions.DependencyInjection. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

**اعضا (1):**

- `AddMapsterMappings` (method): `public static IServiceCollection AddMapsterMappings(this IServiceCollection services, params Assembly[] assembliesToScan)`

#### `Zamin.Extensions.DependencyInjection.SoftwarePartDetectorServiceCollectionExtensions` (class)

کلاس «SoftwarePartDetectorServiceCollectionExtensions» در namespace Zamin.Extensions.DependencyInjection. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

**اعضا (3):**

- `AddSoftwarePartDetector` (method): `public static IServiceCollection AddSoftwarePartDetector(this IServiceCollection services, IConfiguration configuration, string sectionName)`
- `AddSoftwarePartDetector` (method): `public static IServiceCollection AddSoftwarePartDetector(this IServiceCollection services, IConfiguration configuration)`
- `AddSoftwarePartDetector` (method): `public static IServiceCollection AddSoftwarePartDetector(this IServiceCollection services, Action<SoftwarePartDetectorOptions> setupAction)`

#### `Zamin.Extensions.DependencyInjection.UserInfoServiceCollectionExtensions` (class)

کلاس «UserInfoServiceCollectionExtensions» در namespace Zamin.Extensions.DependencyInjection. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

**اعضا (3):**

- `AddZaminWebUserInfoService` (method): `public static IServiceCollection AddZaminWebUserInfoService(this IServiceCollection services, IConfiguration configuration, bool useFake = false)`
- `AddZaminWebUserInfoService` (method): `public static IServiceCollection AddZaminWebUserInfoService(this IServiceCollection services, IConfiguration configuration, string sectionName, bool useFake = false)`
- `AddZaminWebUserInfoService` (method): `public static IServiceCollection AddZaminWebUserInfoService(this IServiceCollection services, Action<UserManagementOptions> setupAction, bool useFake = false)`

### Namespace: `Zamin.Extensions.DependencyInjection.Options`

#### `Zamin.Extensions.DependencyInjection.Options.DependencyInjectionOption` (class)

کلاس «DependencyInjectionOption» در namespace Zamin.Extensions.DependencyInjection.Options. مدل تنظیمات قابل بایند شدن از configuration.

**اعضا (1):**

- `AssmblyNamesForLoad` (property): `public string AssmblyNamesForLoad { get; set; }`

### Namespace: `Zamin.Extensions.Events.Abstractions`

#### `Zamin.Extensions.Events.Abstractions.IOutBoxEventItemRepository` (interface)

قرارداد (اینترفیس) «IOutBoxEventItemRepository» در namespace Zamin.Extensions.Events.Abstractions. قرارداد دسترسی به داده برای ذخیره و بازیابی aggregate/entity.

**اعضا (2):**

- `GetOutBoxEventItemsForPublishe` (method): `public List<OutBoxEventItem> GetOutBoxEventItemsForPublishe(int maxCount = 100)`
- `MarkAsRead` (method): `void MarkAsRead(List<OutBoxEventItem> outBoxEventItems)`

#### `Zamin.Extensions.Events.Abstractions.OutBoxEventItem` (class)

کلاس «OutBoxEventItem» در namespace Zamin.Extensions.Events.Abstractions. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین.

**اعضا (13):**

- `OutBoxEventItemId` (property): `public long OutBoxEventItemId { get; set; }`
- `EventId` (property): `public Guid EventId { get; set; }`
- `AccuredByUserId` (property): `public string AccuredByUserId { get; set; }`
- `AccuredOn` (property): `public DateTime AccuredOn { get; set; }`
- `AggregateName` (property): `public string AggregateName { get; set; }`
- `AggregateTypeName` (property): `public string AggregateTypeName { get; set; }`
- `AggregateId` (property): `public string AggregateId { get; set; }`
- `EventName` (property): `public string EventName { get; set; }`
- `EventTypeName` (property): `public string EventTypeName { get; set; }`
- `EventPayload` (property): `public string EventPayload { get; set; }`
- `TraceId` (property): `public string? TraceId { get; set; }`
- `SpanId` (property): `public string? SpanId { get; set; }`
- `IsProcessed` (property): `public bool IsProcessed { get; set; }`

### Namespace: `Zamin.Extensions.Events.Outbox.Dal.EF.Configs`

#### `Zamin.Extensions.Events.Outbox.Dal.EF.Configs.OutBoxEventItemConfig` (class)

کلاس «OutBoxEventItemConfig» در namespace Zamin.Extensions.Events.Outbox.Dal.EF.Configs. موجودیت دامنه با هویت و قابلیت auditable. ارث‌بری/پیاده‌سازی: IEntityTypeConfiguration<OutBoxEventItem>. مرتبط: IEntityTypeConfiguration<OutBoxEventItem>.

- **Base:** `IEntityTypeConfiguration<OutBoxEventItem>`

**اعضا (1):**

- `Configure` (method): `public void Configure(EntityTypeBuilder<OutBoxEventItem> builder)`

### Namespace: `Zamin.Extensions.Events.Outbox.Dal.EF.Interceptors`

#### `Zamin.Extensions.Events.Outbox.Dal.EF.Interceptors.AddOutBoxEventItemInterceptor` (class)

کلاس «AddOutBoxEventItemInterceptor» در namespace Zamin.Extensions.Events.Outbox.Dal.EF.Interceptors. رهگیر EF/زیرساخت برای اعمال منطق هنگام ذخیره یا تغییر داده. ارث‌بری/پیاده‌سازی: SaveChangesInterceptor. مرتبط: SaveChangesInterceptor.

- **Base:** `SaveChangesInterceptor`

**اعضا (2):**

- `SavingChanges` (method): `public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)`
- `SavingChangesAsync` (method): `public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)`

### Namespace: `Zamin.Extensions.Events.Outbox.Dal.EF`

#### `Zamin.Extensions.Events.Outbox.Dal.EF.BaseOutboxCommandDbContext` (class)

کلاس «BaseOutboxCommandDbContext» در namespace Zamin.Extensions.Events.Outbox.Dal.EF. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین. ارث‌بری/پیاده‌سازی: BaseCommandDbContext. وابستگی‌های سازنده (DI): DbContextOptions options. مرتبط: BaseCommandDbContext | DI: DbConte…

- **Base:** `BaseCommandDbContext`

**اعضا (5):**

- `OutBoxEventItems` (property): `public DbSet<OutBoxEventItem> OutBoxEventItems { get; set; }`
- `.ctor` (constructor): `public BaseOutboxCommandDbContext(DbContextOptions options)`
- `.ctor` (constructor): `protected BaseOutboxCommandDbContext()`
- `OnConfiguring` (method): `protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)`
- `OnModelCreating` (method): `protected override void OnModelCreating(ModelBuilder builder)`

### Namespace: `Zamin.Extensions.Events.PollingPublisher.Dal.Dapper.DataAccess`

#### `Zamin.Extensions.Events.PollingPublisher.Dal.Dapper.DataAccess.SqlOutBoxEventItemRepository` (class)

کلاس «SqlOutBoxEventItemRepository» در namespace Zamin.Extensions.Events.PollingPublisher.Dal.Dapper.DataAccess. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین. ارث‌بری/پیاده‌سازی: IOutBoxEventItemRepository. وابستگی‌های سازنده (DI): IOptions<PollingPublisherDalRedisO…

- **Base:** `IOutBoxEventItemRepository`

**اعضا (3):**

- `.ctor` (constructor): `public SqlOutBoxEventItemRepository(IOptions<PollingPublisherDalRedisOptions> options, ILogger<SqlOutBoxEventItemRepository> logger)`
- `GetOutBoxEventItemsForPublishe` (method): `public List<OutBoxEventItem> GetOutBoxEventItemsForPublishe(int maxCount = 100)`
- `MarkAsRead` (method): `public void MarkAsRead(List<OutBoxEventItem> outBoxEventItems)`

### Namespace: `Zamin.Extensions.Events.PollingPublisher.Dal.Dapper.Options`

#### `Zamin.Extensions.Events.PollingPublisher.Dal.Dapper.Options.PollingPublisherDalRedisOptions` (class)

کلاس «PollingPublisherDalRedisOptions» در namespace Zamin.Extensions.Events.PollingPublisher.Dal.Dapper.Options. مدل تنظیمات قابل بایند شدن از configuration.

**اعضا (4):**

- `ApplicationName` (property): `public string ApplicationName { get; set; }`
- `ConnectionString` (property): `public string ConnectionString { get; set; }`
- `SelectCommand` (property): `public string SelectCommand { get; set; }`
- `UpdateCommand` (property): `public string UpdateCommand { get; set; }`

### Namespace: `Zamin.Extensions.Events.PollingPublisher`

#### `Zamin.Extensions.Events.PollingPublisher.PoolingPublisherBackgroundService` (class)

کلاس «PoolingPublisherBackgroundService» در namespace Zamin.Extensions.Events.PollingPublisher. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین. ارث‌بری/پیاده‌سازی: BackgroundService. وابستگی‌های سازنده (DI): IOutBoxEventItemRepository outBoxEventItemRepository, IOptio…

- **Base:** `BackgroundService`

**اعضا (2):**

- `.ctor` (constructor): `public PoolingPublisherBackgroundService( IOutBoxEventItemRepository outBoxEventItemRepository, IOptions<PollingPublisherOptions> options, ILogger<PoolingPublisherBackgroundService> logger,IServiceProvider serviceProvider)`
- `ExecuteAsync` (method): `protected override async Task ExecuteAsync(CancellationToken stoppingToken)`

### Namespace: `Zamin.Extensions.Events.PollingPublisher.Options`

#### `Zamin.Extensions.Events.PollingPublisher.Options.PollingPublisherOptions` (class)

کلاس «PollingPublisherOptions» در namespace Zamin.Extensions.Events.PollingPublisher.Options. مدل تنظیمات قابل بایند شدن از configuration.

**اعضا (4):**

- `SendInterval` (property): `public int SendInterval { get; set; }`
- `ExceptionInterval` (property): `public int ExceptionInterval { get; set; }`
- `SendCount` (property): `public int SendCount { get; set; }`
- `ApplicationName` (property): `public string ApplicationName { get; set; }`

### Namespace: `Zamin.Extensions.Logger.Abstractions`

#### `Zamin.Extensions.Logger.Abstractions.ZaminEventId` (class)

کلاس «ZaminEventId» در namespace Zamin.Extensions.Logger.Abstractions. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین. اتریبیوت‌ها: Obsolete("این بخش در نسخه 10 deprecated شده و ممکن است در Zamin 11 حذف یا بازطراحی شود.").

**اعضا (5):**

- `PerformanceMeasurement` (field): `public const int PerformanceMeasurement = 1001;`
- `DomainValidationException` (field): `public const int DomainValidationException = 1010;`
- `CommandValidation` (field): `public const int CommandValidation = 1011;`
- `QueryValidation` (field): `public const int QueryValidation = 1012;`
- `EventValidation` (field): `public const int EventValidation = 1013;`

### Namespace: `Zamin.Extensions.MessageBus.Abstractions.Fakes`

#### `Zamin.Extensions.MessageBus.Abstractions.Fakes.FakeMessageConsumer` (class)

کلاس «FakeMessageConsumer» در namespace Zamin.Extensions.MessageBus.Abstractions.Fakes. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین. ارث‌بری/پیاده‌سازی: IMessageConsumer. مرتبط: IMessageConsumer.

- **Base:** `IMessageConsumer`

**اعضا (2):**

- `ConsumeCommand` (method): `public async Task<bool> ConsumeCommand(string sender, Parcel parcel)`
- `ConsumeEvent` (method): `public async Task<bool> ConsumeEvent(string sender, Parcel parcel)`

#### `Zamin.Extensions.MessageBus.Abstractions.Fakes.FakeReceiveMessageBus` (class)

کلاس «FakeReceiveMessageBus» در namespace Zamin.Extensions.MessageBus.Abstractions.Fakes. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین. ارث‌بری/پیاده‌سازی: IReceiveMessageBus. وابستگی‌های سازنده (DI): ILogger<FakeSendMessageBus> logger. مرتبط: IReceiveMessageBus | D…

- **Base:** `IReceiveMessageBus`

**اعضا (3):**

- `.ctor` (constructor): `public FakeReceiveMessageBus(ILogger<FakeSendMessageBus> logger)`
- `Receive` (method): `public void Receive(string commandName)`
- `Subscribe` (method): `public void Subscribe(string serviceId, string eventName)`

#### `Zamin.Extensions.MessageBus.Abstractions.Fakes.FakeSendMessageBus` (class)

کلاس «FakeSendMessageBus» در namespace Zamin.Extensions.MessageBus.Abstractions.Fakes. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین. ارث‌بری/پیاده‌سازی: ISendMessageBus. وابستگی‌های سازنده (DI): ILogger<FakeSendMessageBus> logger. مرتبط: ISendMessageBus | DI: ILogge…

- **Base:** `ISendMessageBus`

**اعضا (5):**

- `.ctor` (constructor): `public FakeSendMessageBus(ILogger<FakeSendMessageBus> logger)`
- `Publish` (method): `public void Publish<TInput>(TInput input)`
- `Send` (method): `public void Send(Parcel parcel)`
- `SendCommandTo` (method): `public void SendCommandTo<TCommandData>(string destinationService, string commandName, TCommandData commandData)`
- `SendCommandTo` (method): `public void SendCommandTo<TCommandData>(string destinationService, string commandName, string correlationId, TCommandData commandData)`

### Namespace: `Zamin.Extensions.MessageBus.Abstractions`

#### `Zamin.Extensions.MessageBus.Abstractions.IMessageConsumer` (interface)

قرارداد (اینترفیس) «IMessageConsumer» در namespace Zamin.Extensions.MessageBus.Abstractions. قرارداد رفتار برای مصرف‌کنندگان و پیاده‌سازی‌های جایگزین.

**اعضا (2):**

- `ConsumeEvent` (method): `Task<bool> ConsumeEvent(string sender, Parcel parcel)`
- `ConsumeCommand` (method): `Task<bool> ConsumeCommand(string sender, Parcel parcel)`

#### `Zamin.Extensions.MessageBus.Abstractions.IMessageInboxItemRepository` (interface)

قرارداد (اینترفیس) «IMessageInboxItemRepository» در namespace Zamin.Extensions.MessageBus.Abstractions. قرارداد دسترسی به داده برای ذخیره و بازیابی aggregate/entity.

**اعضا (2):**

- `AllowReceive` (method): `bool AllowReceive(string messageId, string fromService)`
- `Receive` (method): `void Receive(string messageId, string fromService,string payload)`

#### `Zamin.Extensions.MessageBus.Abstractions.IReceiveMessageBus` (interface)

قرارداد (اینترفیس) «IReceiveMessageBus» در namespace Zamin.Extensions.MessageBus.Abstractions. قرارداد رفتار برای مصرف‌کنندگان و پیاده‌سازی‌های جایگزین.

**اعضا (2):**

- `Subscribe` (method): `void Subscribe(string serviceId, string eventName)`
- `Receive` (method): `void Receive(string commandName)`

#### `Zamin.Extensions.MessageBus.Abstractions.ISendMessageBus` (interface)

جهت ارسال پیام از این زیر ساخت اتستفاده می‌شود پیام ها می‌توانند در قالب دستوری باشند که به سرویسی خاص ارسال می‌شوند یا پیامی عمومی که برای همه ارسال می‌شود

**اعضا (4):**

- `Publish` (method): `void Publish<TInput>(TInput input)`
- `SendCommandTo` (method): `void SendCommandTo<TCommandData>(string destinationService, string commandName, TCommandData commandData)`
- `SendCommandTo` (method): `void SendCommandTo<TCommandData>(string destinationService, string commandName, string correlationId, TCommandData commandData)`
- `Send` (method): `void Send(Parcel parcel)`

#### `Zamin.Extensions.MessageBus.Abstractions.Parcel` (class)

این کلاس در نرم‌افزار داده‌هایی که باید از طریق زیر ساخت پیام رسانی منتقل شود را نگهداری می‌کند

**اعضا (6):**

- `MessageId` (property): `public string MessageId { get; set; }`
- `CorrelationId` (property): `public string CorrelationId { get; set; }`
- `MessageName` (property): `public string MessageName { get; set; }`
- `Headers` (property): `public Dictionary<string, object> Headers { get; set; }`
- `MessageBody` (property): `public string MessageBody { get; set; }`
- `Route` (property): `public string Route { get; set; }`

### Namespace: `Zamin.Extensions.MessageBus.MessageInbox.Dal.Dapper`

#### `Zamin.Extensions.MessageBus.MessageInbox.Dal.Dapper.SqlMessageInboxItemRepository` (class)

کلاس «SqlMessageInboxItemRepository» در namespace Zamin.Extensions.MessageBus.MessageInbox.Dal.Dapper. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین. ارث‌بری/پیاده‌سازی: IMessageInboxItemRepository. وابستگی‌های سازنده (DI): IOptions<MessageInboxDalDapperOptions> opti…

- **Base:** `IMessageInboxItemRepository`

**اعضا (3):**

- `.ctor` (constructor): `public SqlMessageInboxItemRepository(IOptions<MessageInboxDalDapperOptions> options, ILogger<SqlMessageInboxItemRepository> logger)`
- `AllowReceive` (method): `public bool AllowReceive(string messageId, string fromService)`
- `Receive` (method): `public void Receive(string messageId, string fromService, string payload)`

### Namespace: `Zamin.Extensions.MessageBus.MessageInbox.Dal.Dapper.Options`

#### `Zamin.Extensions.MessageBus.MessageInbox.Dal.Dapper.Options.MessageInboxDalDapperOptions` (class)

کلاس «MessageInboxDalDapperOptions» در namespace Zamin.Extensions.MessageBus.MessageInbox.Dal.Dapper.Options. مدل تنظیمات قابل بایند شدن از configuration.

**اعضا (4):**

- `ConnectionString` (property): `public string ConnectionString { get; set; }`
- `AutoCreateSqlTable` (property): `public bool AutoCreateSqlTable { get; set; }`
- `TableName` (property): `public string TableName { get; set; }`
- `SchemaName` (property): `public string SchemaName { get; set; }`

### Namespace: `Zamin.Extensions.MessageBus.MessageInbox`

#### `Zamin.Extensions.MessageBus.MessageInbox.InboxMessageConsumer` (class)

کلاس «InboxMessageConsumer» در namespace Zamin.Extensions.MessageBus.MessageInbox. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین. ارث‌بری/پیاده‌سازی: IMessageConsumer. وابستگی‌های سازنده (DI): IOptions<MessageInboxOptions> messageInboxOptions, IJsonSerializer jsonSer…

- **Base:** `IMessageConsumer`

**اعضا (3):**

- `.ctor` (constructor): `public InboxMessageConsumer(IOptions<MessageInboxOptions> messageInboxOptions, // …`
- `ConsumeCommand` (method): `public Task<bool> ConsumeCommand(string sender, Parcel parcel)`
- `ConsumeEvent` (method): `public async Task<bool> ConsumeEvent(string sender, Parcel parcel)`

### Namespace: `Zamin.Extensions.MessageBus.MessageInbox.Options`

#### `Zamin.Extensions.MessageBus.MessageInbox.Options.MessageInboxOptions` (class)

کلاس «MessageInboxOptions» در namespace Zamin.Extensions.MessageBus.MessageInbox.Options. مدل تنظیمات قابل بایند شدن از configuration.

**اعضا (1):**

- `ApplicationName` (property): `public string ApplicationName { get; set; }`

### Namespace: `Zamin.Extensions.MessageBus.RabbitMQ`

#### `Zamin.Extensions.MessageBus.RabbitMQ.RabbitMqReceiveMessageBus` (class)

کلاس «RabbitMqReceiveMessageBus» در namespace Zamin.Extensions.MessageBus.RabbitMQ. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین. ارث‌بری/پیاده‌سازی: IReceiveMessageBus, IDisposable. وابستگی‌های سازنده (DI): IConnection connection, ILogger<RabbitMqReceiveMessageBus>…

- **Base:** `IReceiveMessageBus`, `IDisposable`

**اعضا (4):**

- `.ctor` (constructor): `public RabbitMqReceiveMessageBus(IConnection connection, // …`
- `Subscribe` (method): `public void Subscribe(string serviceId, string eventName)`
- `Receive` (method): `public void Receive(string commandName)`
- `Dispose` (method): `public void Dispose()`

#### `Zamin.Extensions.MessageBus.RabbitMQ.RabbitMqSendMessageBus` (class)

کلاس «RabbitMqSendMessageBus» در namespace Zamin.Extensions.MessageBus.RabbitMQ. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین. ارث‌بری/پیاده‌سازی: IDisposable, ISendMessageBus. وابستگی‌های سازنده (DI): IConnection connection, IJsonSerializer jsonSerializer, IOptions…

- **Base:** `IDisposable`, `ISendMessageBus`

**اعضا (6):**

- `.ctor` (constructor): `public RabbitMqSendMessageBus(IConnection connection, IJsonSerializer jsonSerializer, IOptions<RabbitMqOptions> rabbitMqOptions,ILogger<RabbitMqSendMessageBus> logger)`
- `Publish` (method): `public void Publish<TInput>(TInput input)`
- `SendCommandTo` (method): `public void SendCommandTo<TCommandData>(string destinationService, string commandName, TCommandData commandData)`
- `SendCommandTo` (method): `public void SendCommandTo<TCommandData>(string destinationService, string commandName, string correlationId, TCommandData commandData)`
- `Send` (method): `public void Send(Parcel parcel)`
- `Dispose` (method): `public void Dispose()`

#### `Zamin.Extensions.MessageBus.RabbitMQ.RabbitMqSendMessageBusConstants` (class)

کلاس «RabbitMqSendMessageBusConstants» در namespace Zamin.Extensions.MessageBus.RabbitMQ. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین.

**اعضا (2):**

- `@event` (field): `public const string @event = "event";`
- `command` (field): `public const string command = "command";`

### Namespace: `Zamin.Extensions.MessageBus.RabbitMQ.Options`

#### `Zamin.Extensions.MessageBus.RabbitMQ.Options.RabbitMqOptions` (class)

کلاس «RabbitMqOptions» در namespace Zamin.Extensions.MessageBus.RabbitMQ.Options. مدل تنظیمات قابل بایند شدن از configuration.

**اعضا (5):**

- `Url` (property): `public string Url { get; set; }`
- `PerssistMessage` (property): `public bool PerssistMessage { get; set; }`
- `ExchangeName` (property): `public string ExchangeName { get; set; }`
- `ServiceName` (property): `public string ServiceName { get; set; }`
- `IsMessageMandatory` (property): `public bool IsMessageMandatory { get; set; }`

### Namespace: `Zamin.Extensions.ObjectMappers.Abstractions`

#### `Zamin.Extensions.ObjectMappers.Abstractions.IMapperAdapter` (interface)

قرارداد (اینترفیس) «IMapperAdapter» در namespace Zamin.Extensions.ObjectMappers.Abstractions. قرارداد رفتار برای مصرف‌کنندگان و پیاده‌سازی‌های جایگزین.

**اعضا (1):**

- `Map` (method): `TDestination Map<TSource, TDestination>(TSource source)`

### Namespace: `Zamin.Extensions.ObjectMappers.AutoMapper.Options`

#### `Zamin.Extensions.ObjectMappers.AutoMapper.Options.AutoMapperOption` (class)

کلاس «AutoMapperOption» در namespace Zamin.Extensions.ObjectMappers.AutoMapper.Options. مدل تنظیمات قابل بایند شدن از configuration.

**اعضا (1):**

- `AssmblyNamesForLoadProfiles` (property): `public string AssmblyNamesForLoadProfiles { get; set; }`

### Namespace: `Zamin.Extensions.ObjectMappers.AutoMapper.Services`

#### `Zamin.Extensions.ObjectMappers.AutoMapper.Services.AutoMapperAdapter` (class)

کلاس «AutoMapperAdapter» در namespace Zamin.Extensions.ObjectMappers.AutoMapper.Services. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین. ارث‌بری/پیاده‌سازی: IMapperAdapter. وابستگی‌های سازنده (DI): IMapper mapper, ILogger<AutoMapperAdapter> logger. مرتبط: IMapperAdap…

- **Base:** `IMapperAdapter`

**اعضا (2):**

- `.ctor` (constructor): `public AutoMapperAdapter(IMapper mapper, ILogger<AutoMapperAdapter> logger)`
- `Map` (method): `public TDestination Map<TSource, TDestination>(TSource source)`

### Namespace: `Zamin.Extensions.ObjectMappers.Mapster.Services`

#### `Zamin.Extensions.ObjectMappers.Mapster.Services.IObjectMapper` (interface)

قرارداد (اینترفیس) «IObjectMapper» در namespace Zamin.Extensions.ObjectMappers.Mapster.Services. قرارداد رفتار برای مصرف‌کنندگان و پیاده‌سازی‌های جایگزین.

**اعضا (4):**

- `Map` (method): `TDestination Map<TSource, TDestination>(TSource source)`
- `Map` (method): `TDestination Map<TDestination>(object source)`
- `MapCollection` (method): `IEnumerable<TDestination> MapCollection<TSource, TDestination>(IEnumerable<TSource> source)`
- `RegisterMap` (method): `void RegisterMap<TSource, TDestination>(Action<TypeAdapterSetter<TSource, TDestination>> configAction)`

#### `Zamin.Extensions.ObjectMappers.Mapster.Services.Mapster` (class)

کلاس «Mapster» در namespace Zamin.Extensions.ObjectMappers.Mapster.Services. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین. ارث‌بری/پیاده‌سازی: Abstractions.IMapperAdapter, IObjectMapper. وابستگی‌های سازنده (DI): ILogger<Mapster> logger. مرتبط: Abstractions.IMapperAd…

- **Base:** `Abstractions.IMapperAdapter`, `IObjectMapper`

**اعضا (5):**

- `.ctor` (constructor): `public Mapster(ILogger<Mapster> logger)`
- `Map` (method): `public TDestination Map<TDestination>(object source)`
- `Map` (method): `public TDestination Map<TSource, TDestination>(TSource source)`
- `MapCollection` (method): `public IEnumerable<TDestination> MapCollection<TSource, TDestination>(IEnumerable<TSource> source)`
- `RegisterMap` (method): `public void RegisterMap<TSource, TDestination>(Action<TypeAdapterSetter<TSource, TDestination>> configAction)`

### Namespace: `Zamin.Extensions.Serializers.Abstractions`

#### `Zamin.Extensions.Serializers.Abstractions.IExcelSerializer` (interface)

قرارداد (اینترفیس) «IExcelSerializer» در namespace Zamin.Extensions.Serializers.Abstractions. قرارداد رفتار برای مصرف‌کنندگان و پیاده‌سازی‌های جایگزین.

**اعضا (3):**

- `ListToExcelByteArray` (method): `byte[] ListToExcelByteArray<T>(List<T> list, string sheetName = "Result")`
- `ExcelToDataTable` (method): `DataTable ExcelToDataTable(byte[] bytes)`
- `ExcelToList` (method): `List<T> ExcelToList<T>(byte[] bytes)`

#### `Zamin.Extensions.Serializers.Abstractions.IJsonSerializer` (interface)

قرارداد (اینترفیس) «IJsonSerializer» در namespace Zamin.Extensions.Serializers.Abstractions. قرارداد رفتار برای مصرف‌کنندگان و پیاده‌سازی‌های جایگزین.

**اعضا (3):**

- `Serialize` (method): `string Serialize<TInput>(TInput input)`
- `Deserialize` (method): `TOutput Deserialize<TOutput>(string input)`
- `Deserialize` (method): `object Deserialize(string input, Type type)`

### Namespace: `Zamin.Extensions.Serializers.EPPlus.Extensions`

#### `Zamin.Extensions.Serializers.EPPlus.Extensions.ExcelExtensions` (class)

کلاس «ExcelExtensions» در namespace Zamin.Extensions.Serializers.EPPlus.Extensions. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

**اعضا (2):**

- `ToExcelByteArray` (method): `public static byte[] ToExcelByteArray<T>(this List<T> list, ITranslator translator, string sheetName = "Result")`
- `ToDataTableFromExcel` (method): `public static DataTable ToDataTableFromExcel(this byte[] bytes)`

#### `Zamin.Extensions.Serializers.EPPlus.Extensions.LinqExtensions` (class)

کلاس «LinqExtensions» در namespace Zamin.Extensions.Serializers.EPPlus.Extensions. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

**اعضا (1):**

- `ToList` (method): `public static List<T> ToList<T>(this DataTable dataTable, ITranslator translator)`

### Namespace: `Zamin.Extensions.Serializers.EPPlus.Services`

#### `Zamin.Extensions.Serializers.EPPlus.Services.EPPlusExcelSerializer` (class)

کلاس «EPPlusExcelSerializer» در namespace Zamin.Extensions.Serializers.EPPlus.Services. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین. ارث‌بری/پیاده‌سازی: IExcelSerializer. وابستگی‌های سازنده (DI): ITranslator translator. مرتبط: IExcelSerializer | DI: ITranslator tra…

- **Base:** `IExcelSerializer`

**اعضا (4):**

- `.ctor` (constructor): `public EPPlusExcelSerializer(ITranslator translator)`
- `ListToExcelByteArray` (method): `public byte[] ListToExcelByteArray<T>(List<T> list, string sheetName = "Result")`
- `ExcelToDataTable` (method): `public DataTable ExcelToDataTable(byte[] bytes)`
- `ExcelToList` (method): `public List<T> ExcelToList<T>(byte[] bytes)`

### Namespace: `Zamin.Extensions.Serializers.Microsoft.Services`

#### `Zamin.Extensions.Serializers.Microsoft.Services.MicrosoftSerializer` (class)

کلاس «MicrosoftSerializer» در namespace Zamin.Extensions.Serializers.Microsoft.Services. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین. ارث‌بری/پیاده‌سازی: IJsonSerializer, IDisposable. وابستگی‌های سازنده (DI): ILogger<MicrosoftSerializer> logger. مرتبط: IJsonSeriali…

- **Base:** `IJsonSerializer`, `IDisposable`

**اعضا (5):**

- `.ctor` (constructor): `public MicrosoftSerializer(ILogger<MicrosoftSerializer> logger)`
- `Deserialize` (method): `public TOutput Deserialize<TOutput>(string input)`
- `Deserialize` (method): `public object Deserialize(string input, Type type)`
- `Serialize` (method): `public string Serialize<TInput>(TInput input)`
- `Dispose` (method): `public void Dispose()`

### Namespace: `Zamin.Extensions.Serializers.NewtonSoft.Services`

#### `Zamin.Extensions.Serializers.NewtonSoft.Services.NewtonSoftSerializer` (class)

کلاس «NewtonSoftSerializer» در namespace Zamin.Extensions.Serializers.NewtonSoft.Services. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین. ارث‌بری/پیاده‌سازی: IJsonSerializer, IDisposable. وابستگی‌های سازنده (DI): ILogger<NewtonSoftSerializer> logger. مرتبط: IJsonSeri…

- **Base:** `IJsonSerializer`, `IDisposable`

**اعضا (5):**

- `.ctor` (constructor): `public NewtonSoftSerializer(ILogger<NewtonSoftSerializer> logger)`
- `Deserialize` (method): `public TOutput Deserialize<TOutput>(string input)`
- `Deserialize` (method): `public object Deserialize(string input, Type type)`
- `Serialize` (method): `public string Serialize<TInput>(TInput input)`
- `Dispose` (method): `public void Dispose()`

### Namespace: `Zamin.Extensions.Translations.Abstractions`

#### `Zamin.Extensions.Translations.Abstractions.ITranslator` (interface)

قرارداد (اینترفیس) «ITranslator» در namespace Zamin.Extensions.Translations.Abstractions. قرارداد رفتار برای مصرف‌کنندگان و پیاده‌سازی‌های جایگزین.

**اعضا (12):**

- `this` (indexer): `string this[string name] { get; set; }`
- `this` (indexer): `string this[CultureInfo culture, string name] { get; set; }`
- `this` (indexer): `string this[string name, params string[] arguments] { get; set; }`
- `this` (indexer): `string this[CultureInfo culture, string name, params string[] arguments] { get; set; }`
- `this` (indexer): `string this[char separator, params string[] names] { get; set; }`
- `this` (indexer): `string this[CultureInfo culture, char separator, params string[] names] { get; set; }`
- `GetString` (method): `string GetString(string name)`
- `GetString` (method): `string GetString(CultureInfo culture,string name)`
- `GetString` (method): `string GetString(string pattern, params string[] arguments)`
- `GetString` (method): `string GetString(CultureInfo culture, string pattern, params string[] arguments)`
- `GetConcateString` (method): `string GetConcateString(char separator = ' ', params string[] names)`
- `GetConcateString` (method): `string GetConcateString(CultureInfo culture, char separator = ' ', params string[] names)`

### Namespace: `Zamin.Extensions.Translations.Parrot.Database`

#### `Zamin.Extensions.Translations.Parrot.Database.ParrotSqlRepository` (class)

کلاس «ParrotSqlRepository» در namespace Zamin.Extensions.Translations.Parrot.Database. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین. وابستگی‌های سازنده (DI): ParrotTranslatorOptions configuration, ILogger logger. مرتبط: DI: ParrotTranslatorOptions configuration, ILo…

**اعضا (2):**

- `.ctor` (constructor): `public ParrotSqlRepository(ParrotTranslatorOptions configuration, ILogger logger)`
- `Get` (method): `public string Get(string key, string culture)`

### Namespace: `Zamin.Extensions.Translations.Parrot.DataModel`

#### `Zamin.Extensions.Translations.Parrot.DataModel.LocalizationRecord` (class)

کلاس «LocalizationRecord» در namespace Zamin.Extensions.Translations.Parrot.DataModel. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین.

**اعضا (7):**

- `Id` (property): `public long Id { get; set; }`
- `BusinessId` (property): `public Guid BusinessId { get; set; }`
- `Key` (property): `public string Key { get; set; }`
- `Value` (property): `public string Value { get; set; }`
- `Culture` (property): `public string Culture { get; set; }`
- `CorrespondingValueNotFound` (property): `public bool CorrespondingValueNotFound => ...`
- `ToString` (method): `public override string ToString()`

### Namespace: `Zamin.Extensions.Translations.Parrot.Options`

#### `Zamin.Extensions.Translations.Parrot.Options.DefaultTranslationOption` (class)

کلاس «DefaultTranslationOption» در namespace Zamin.Extensions.Translations.Parrot.Options. مدل تنظیمات قابل بایند شدن از configuration.

**اعضا (3):**

- `Key` (property): `public string Key { get; set; }`
- `Value` (property): `public string Value { get; set; }`
- `Culture` (property): `public string Culture { get; set; }`

#### `Zamin.Extensions.Translations.Parrot.Options.ParrotTranslatorOptions` (class)

کلاس «ParrotTranslatorOptions» در namespace Zamin.Extensions.Translations.Parrot.Options. مدل تنظیمات قابل بایند شدن از configuration.

**اعضا (6):**

- `ConnectionString` (property): `public string ConnectionString { get; set; }`
- `AutoCreateSqlTable` (property): `public bool AutoCreateSqlTable { get; set; }`
- `TableName` (property): `public string TableName { get; set; }`
- `SchemaName` (property): `public string SchemaName { get; set; }`
- `ReloadDataIntervalInMinuts` (property): `public int ReloadDataIntervalInMinuts { get; set; }`
- `DefaultTranslations` (property): `public DefaultTranslationOption[] DefaultTranslations { get; set; }`

### Namespace: `Zamin.Extensions.Translations.Parrot.Services`

#### `Zamin.Extensions.Translations.Parrot.Services.ParrotTranslator` (class)

کلاس «ParrotTranslator» در namespace Zamin.Extensions.Translations.Parrot.Services. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین. ارث‌بری/پیاده‌سازی: ITranslator, IDisposable. وابستگی‌های سازنده (DI): IOptions<ParrotTranslatorOptions> configuration, ILogger<ParrotTr…

- **Base:** `ITranslator`, `IDisposable`

**اعضا (14):**

- `.ctor` (constructor): `public ParrotTranslator(IOptions<ParrotTranslatorOptions> configuration, ILogger<ParrotTranslator> logger)`
- `this` (indexer): `public string this[string name] { get; set; }`
- `this` (indexer): `public string this[CultureInfo culture, string name ] { get; set; }`
- `this` (indexer): `public string this[string name, params string[] arguments] { get; set; }`
- `this` (indexer): `public string this[CultureInfo culture, string name, params string[] arguments] { get; set; }`
- `this` (indexer): `public string this[char separator, params string[] names] { get; set; }`
- `this` (indexer): `public string this[CultureInfo culture, char separator, params string[] names] { get; set; }`
- `GetString` (method): `public string GetString(string name)`
- `GetString` (method): `public string GetString(CultureInfo culture, string name)`
- `GetString` (method): `public string GetString(string pattern, params string[] arguments)`
- `GetString` (method): `public string GetString(CultureInfo culture, string pattern, params string[] arguments)`
- `GetConcateString` (method): `public string GetConcateString(char separator = ' ', params string[] names)`
- `GetConcateString` (method): `public string GetConcateString(CultureInfo culture, char separator = ' ',  params string[] names)`
- `Dispose` (method): `public void Dispose()`

### Namespace: `Zamin.Extensions.UsersManagement.Abstractions`

#### `Zamin.Extensions.UsersManagement.Abstractions.FakeUserInfoService` (class)

کلاس «FakeUserInfoService» در namespace Zamin.Extensions.UsersManagement.Abstractions. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین. ارث‌بری/پیاده‌سازی: IUserInfoService. وابستگی‌های سازنده (DI): string defaultUserId. مرتبط: IUserInfoService (same namespace) | DI: s…

- **Base:** `IUserInfoService`

**اعضا (13):**

- `.ctor` (constructor): `public FakeUserInfoService()`
- `.ctor` (constructor): `public FakeUserInfoService(string defaultUserId)`
- `GetClaim` (method): `public string? GetClaim(string claimType)`
- `GetFirstName` (method): `public string GetFirstName()`
- `GetLastName` (method): `public string GetLastName()`
- `GetUserAgent` (method): `public string GetUserAgent()`
- `GetUserIp` (method): `public string GetUserIp()`
- `GetUsername` (method): `public string GetUsername()`
- `HasAccess` (method): `public bool HasAccess(string access)`
- `IsCurrentUser` (method): `public bool IsCurrentUser(string userId)`
- `UserId` (method): `public string UserId()`
- `UserIdOrDefault` (method): `public string UserIdOrDefault()`
- `UserIdOrDefault` (method): `public string UserIdOrDefault(string defaultValue)`

#### `Zamin.Extensions.UsersManagement.Abstractions.IUserInfoService` (interface)

قرارداد (اینترفیس) «IUserInfoService» در namespace Zamin.Extensions.UsersManagement.Abstractions. قرارداد رفتار برای مصرف‌کنندگان و پیاده‌سازی‌های جایگزین.

**اعضا (10):**

- `GetUserAgent` (method): `string GetUserAgent()`
- `GetUserIp` (method): `string GetUserIp()`
- `UserId` (method): `string UserId()`
- `GetFirstName` (method): `string GetFirstName()`
- `GetLastName` (method): `string GetLastName()`
- `GetUsername` (method): `string GetUsername()`
- `GetClaim` (method): `string? GetClaim(string claimType)`
- `IsCurrentUser` (method): `bool IsCurrentUser(string userId)`
- `UserIdOrDefault` (method): `string UserIdOrDefault()`
- `UserIdOrDefault` (method): `string UserIdOrDefault(string defaultValue)`

### Namespace: `Zamin.Extensions.UsersManagement.Extensions`

#### `Zamin.Extensions.UsersManagement.Extensions.ClaimExtensions` (class)

کلاس «ClaimExtensions» در namespace Zamin.Extensions.UsersManagement.Extensions. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

**اعضا (1):**

- `GetClaim` (method): `public static string GetClaim(this ClaimsPrincipal userClaimsPrincipal, string claimType)`

### Namespace: `Zamin.Extensions.UsersManagement.Options`

#### `Zamin.Extensions.UsersManagement.Options.UserManagementOptions` (class)

کلاس «UserManagementOptions» در namespace Zamin.Extensions.UsersManagement.Options. مدل تنظیمات قابل بایند شدن از configuration.

**اعضا (6):**

- `DefaultUserId` (property): `public string DefaultUserId { get; set; }`
- `DefaultUserAgent` (property): `public string DefaultUserAgent { get; set; }`
- `DefaultUserIp` (property): `public string DefaultUserIp { get; set; }`
- `DefaultUsername` (property): `public string DefaultUsername { get; set; }`
- `DefaultFirstName` (property): `public string DefaultFirstName { get; set; }`
- `DefaultLastName` (property): `public string DefaultLastName { get; set; }`

### Namespace: `Zamin.Extensions.UsersManagement.Services`

#### `Zamin.Extensions.UsersManagement.Services.WebUserInfoService` (class)

کلاس «WebUserInfoService» در namespace Zamin.Extensions.UsersManagement.Services. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین. ارث‌بری/پیاده‌سازی: IUserInfoService. مرتبط: IUserInfoService.

- **Base:** `IUserInfoService`

**اعضا (10):**

- `GetUserAgent` (method): `public string GetUserAgent()`
- `GetUserIp` (method): `public string GetUserIp()`
- `UserId` (method): `public string UserId()`
- `GetUsername` (method): `public string GetUsername()`
- `GetFirstName` (method): `public string GetFirstName()`
- `GetLastName` (method): `public string GetLastName()`
- `IsCurrentUser` (method): `public bool IsCurrentUser(string userId)`
- `GetClaim` (method): `public string? GetClaim(string claimType)`
- `UserIdOrDefault` (method): `public string UserIdOrDefault()`
- `UserIdOrDefault` (method): `public string UserIdOrDefault(string defaultValue)`

### Namespace: `Zamin.Infra.Data.Sql.Commands.Extensions`

#### `Zamin.Infra.Data.Sql.Commands.Extensions.AuditableShadowProperties` (class)

کلاس «AuditableShadowProperties» در namespace Zamin.Infra.Data.Sql.Commands.Extensions. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین.

**اعضا (10):**

- `EFPropertyCreatedByUserId` (field): `public static readonly Func<object, string> EFPropertyCreatedByUserId = entity => EF.Property<string>(entity, CreatedByUserId);`
- `CreatedByUserId` (field): `public static readonly string CreatedByUserId = nameof(CreatedByUserId);`
- `EFPropertyModifiedByUserId` (field): `public static readonly Func<object, string> EFPropertyModifiedByUserId = entity => EF.Property<string>(entity, ModifiedByUserId);`
- `ModifiedByUserId` (field): `public static readonly string ModifiedByUserId = nameof(ModifiedByUserId);`
- `EFPropertyCreatedDateTime` (field): `public static readonly Func<object, DateTime?> EFPropertyCreatedDateTime = entity => EF.Property<DateTime?>(entity, CreatedDateTime);`
- `CreatedDateTime` (field): `public static readonly string CreatedDateTime = nameof(CreatedDateTime);`
- `EFPropertyModifiedDateTime` (field): `public static readonly Func<object, DateTime?> EFPropertyModifiedDateTime = entity => EF.Property<DateTime?>(entity, ModifiedDateTime);`
- `ModifiedDateTime` (field): `public static readonly string ModifiedDateTime = nameof(ModifiedDateTime);`
- `AddAuditableShadowProperties` (method): `public static void AddAuditableShadowProperties(this ModelBuilder modelBuilder)`
- `SetAuditableEntityPropertyValues` (method): `public static void SetAuditableEntityPropertyValues( this ChangeTracker changeTracker, IUserInfoService userInfoService)`

#### `Zamin.Infra.Data.Sql.Commands.Extensions.ChangeTrackerExtensions` (class)

کلاس «ChangeTrackerExtensions» در namespace Zamin.Infra.Data.Sql.Commands.Extensions. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

**اعضا (3):**

- `GetChangedAggregates` (method): `public static List<AggregateRoot> GetChangedAggregates(this ChangeTracker changeTracker)`
- `GetAggregatesWithEvent` (method): `public static List<AggregateRoot> GetAggregatesWithEvent(this ChangeTracker changeTracker)`
- `Aggreates` (method): `public static IEnumerable<EntityEntry<AggregateRoot>> Aggreates(this ChangeTracker changeTracker)`

#### `Zamin.Infra.Data.Sql.Commands.Extensions.DbCommandExtension` (class)

کلاس «DbCommandExtension» در namespace Zamin.Infra.Data.Sql.Commands.Extensions. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

**اعضا (1):**

- `ApplyCorrectYeKe` (method): `public static void ApplyCorrectYeKe(this DbCommand command)`

#### `Zamin.Infra.Data.Sql.Commands.Extensions.ModelBuilderExtensions` (class)

کلاس «ModelBuilderExtensions» در namespace Zamin.Infra.Data.Sql.Commands.Extensions. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

**اعضا (3):**

- `AddBusinessId` (method): `public static void AddBusinessId(this ModelBuilder modelBuilder)`
- `UseValueConverterForType` (method): `public static ModelBuilder UseValueConverterForType<T>(this ModelBuilder modelBuilder, ValueConverter converter, int maxLenght = 0)`
- `UseValueConverterForType` (method): `public static ModelBuilder UseValueConverterForType(this ModelBuilder modelBuilder, Type type, ValueConverter converter, int maxLength = 0)`

#### `Zamin.Infra.Data.Sql.Commands.Extensions.RowVersionShadowProperty` (class)

کلاس «RowVersionShadowProperty» در namespace Zamin.Infra.Data.Sql.Commands.Extensions. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین.

**اعضا (2):**

- `RowVersion` (field): `public static readonly string RowVersion = nameof(RowVersion);`
- `AddRowVersionShadowProperty` (method): `public static void AddRowVersionShadowProperty<TEntity>(this EntityTypeBuilder<TEntity> builder) where TEntity : class`

### Namespace: `Zamin.Infra.Data.Sql.Commands.Interceptors`

#### `Zamin.Infra.Data.Sql.Commands.Interceptors.AddAuditDataInterceptor` (class)

کلاس «AddAuditDataInterceptor» در namespace Zamin.Infra.Data.Sql.Commands.Interceptors. رهگیر EF/زیرساخت برای اعمال منطق هنگام ذخیره یا تغییر داده. ارث‌بری/پیاده‌سازی: SaveChangesInterceptor. مرتبط: SaveChangesInterceptor.

- **Base:** `SaveChangesInterceptor`

**اعضا (2):**

- `SavingChanges` (method): `public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)`
- `SavingChangesAsync` (method): `public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)`

#### `Zamin.Infra.Data.Sql.Commands.Interceptors.AddChangeDataLogInterceptor` (class)

کلاس «AddChangeDataLogInterceptor» در namespace Zamin.Infra.Data.Sql.Commands.Interceptors. رهگیر EF/زیرساخت برای اعمال منطق هنگام ذخیره یا تغییر داده. ارث‌بری/پیاده‌سازی: SaveChangesInterceptor. مرتبط: SaveChangesInterceptor.

- **Base:** `SaveChangesInterceptor`

**اعضا (2):**

- `SavingChanges` (method): `public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)`
- `SavingChangesAsync` (method): `public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)`

#### `Zamin.Infra.Data.Sql.Commands.Interceptors.SetPersianYeKeInterceptor` (class)

کلاس «SetPersianYeKeInterceptor» در namespace Zamin.Infra.Data.Sql.Commands.Interceptors. رهگیر EF/زیرساخت برای اعمال منطق هنگام ذخیره یا تغییر داده. ارث‌بری/پیاده‌سازی: DbCommandInterceptor. مرتبط: DbCommandInterceptor.

- **Base:** `DbCommandInterceptor`

**اعضا (6):**

- `NonQueryExecuting` (method): `public override InterceptionResult<int> NonQueryExecuting(DbCommand command, CommandEventData eventData, InterceptionResult<int> result)`
- `NonQueryExecutingAsync` (method): `public override ValueTask<InterceptionResult<int>> NonQueryExecutingAsync(DbCommand command, CommandEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)`
- `ReaderExecuting` (method): `public override InterceptionResult<DbDataReader> ReaderExecuting(DbCommand command, CommandEventData eventData, InterceptionResult<DbDataReader> result)`
- `ReaderExecutingAsync` (method): `public override ValueTask<InterceptionResult<DbDataReader>> ReaderExecutingAsync(DbCommand command, CommandEventData eventData, InterceptionResult<DbDataReader> result, CancellationToken cancellationToken = default)`
- `ScalarExecuting` (method): `public override InterceptionResult<object> ScalarExecuting(DbCommand command, CommandEventData eventData, InterceptionResult<object> result)`
- `ScalarExecutingAsync` (method): `public override ValueTask<InterceptionResult<object>> ScalarExecutingAsync(DbCommand command, CommandEventData eventData, InterceptionResult<object> result, CancellationToken cancellationToken = default)`

### Namespace: `Zamin.Infra.Data.Sql.Commands`

#### `Zamin.Infra.Data.Sql.Commands.BaseCommandDbContext` (class)

کلاس «BaseCommandDbContext» در namespace Zamin.Infra.Data.Sql.Commands. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین. ارث‌بری/پیاده‌سازی: DbContext. وابستگی‌های سازنده (DI): DbContextOptions options. مرتبط: DbContext | DI: DbContextOptions options.

- **Base:** `DbContext`

**اعضا (11):**

- `_transaction` (field): `protected IDbContextTransaction _transaction;`
- `.ctor` (constructor): `public BaseCommandDbContext(DbContextOptions options)`
- `.ctor` (constructor): `protected BaseCommandDbContext()`
- `BeginTransaction` (method): `public void BeginTransaction()`
- `RollbackTransaction` (method): `public void RollbackTransaction()`
- `CommitTransaction` (method): `public void CommitTransaction()`
- `GetShadowPropertyValue` (method): `public T GetShadowPropertyValue<T>(object entity, string propertyName) where T : IConvertible`
- `GetShadowPropertyValue` (method): `public object GetShadowPropertyValue(object entity, string propertyName)`
- `OnModelCreating` (method): `protected override void OnModelCreating(ModelBuilder builder)`
- `ConfigureConventions` (method): `protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)`
- `GetIncludePaths` (method): `public IEnumerable<string> GetIncludePaths(Type clrEntityType)`

#### `Zamin.Infra.Data.Sql.Commands.BaseCommandRepository<TEntity, TDbContext, TId>` (class)

کلاس «BaseCommandRepository<TEntity, TDbContext, TId>» در namespace Zamin.Infra.Data.Sql.Commands. موجودیت دامنه با هویت و قابلیت auditable. ارث‌بری/پیاده‌سازی: ICommandRepository<TEntity, TId>, IUnitOfWork. قیود جنریک: where TEntity : AggregateRoot<TId> where TDbContext : BaseC…

- **Base:** `ICommandRepository<TEntity, TId>`, `IUnitOfWork`

**اعضا (22):**

- `_dbContext` (field): `protected readonly TDbContext _dbContext;`
- `.ctor` (constructor): `public BaseCommandRepository(TDbContext dbContext)`
- `Delete` (method): `public void Delete(TId id)`
- `Delete` (method): `public void Delete(TEntity entity)`
- `DeleteGraph` (method): `public void DeleteGraph(TId id)`
- `Insert` (method): `public void Insert(TEntity entity)`
- `InsertAsync` (method): `public async Task InsertAsync(TEntity entity)`
- `Get` (method): `public TEntity Get(TId id)`
- `Get` (method): `public TEntity Get(BusinessId businessId)`
- `GetAsync` (method): `public async Task<TEntity> GetAsync(TId id)`
- `GetAsync` (method): `public async Task<TEntity> GetAsync(BusinessId businessId)`
- `GetGraph` (method): `public TEntity GetGraph(TId id)`
- `GetGraph` (method): `public TEntity GetGraph(BusinessId businessId)`
- `GetGraphAsync` (method): `public async Task<TEntity> GetGraphAsync(TId id)`
- `GetGraphAsync` (method): `public async Task<TEntity> GetGraphAsync(BusinessId businessId)`
- `Exists` (method): `public bool Exists(Expression<Func<TEntity, bool>> expression)`
- `ExistsAsync` (method): `public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression)`
- `Commit` (method): `public int Commit()`
- `CommitAsync` (method): `public Task<int> CommitAsync()`
- `BeginTransaction` (method): `public void BeginTransaction()`
- `CommitTransaction` (method): `public void CommitTransaction()`
- `RollbackTransaction` (method): `public void RollbackTransaction()`

#### `Zamin.Infra.Data.Sql.Commands.BaseCommandRepository<TEntity, TDbContext>` (class)

کلاس «BaseCommandRepository<TEntity, TDbContext>» در namespace Zamin.Infra.Data.Sql.Commands. موجودیت دامنه با هویت و قابلیت auditable. ارث‌بری/پیاده‌سازی: BaseCommandRepository<TEntity, TDbContext, long>. قیود جنریک: where TEntity : AggregateRoot where TDbContext : BaseCommandD…

- **Base:** `BaseCommandRepository<TEntity, TDbContext, long>`

**اعضا (1):**

- `.ctor` (constructor): `public BaseCommandRepository(TDbContext dbContext)`

#### `Zamin.Infra.Data.Sql.Commands.BaseEntityFrameworkUnitOfWork<TDbContext>` (class)

کلاس «BaseEntityFrameworkUnitOfWork<TDbContext>» در namespace Zamin.Infra.Data.Sql.Commands. موجودیت دامنه با هویت و قابلیت auditable. ارث‌بری/پیاده‌سازی: IUnitOfWork. قیود جنریک: where TDbContext : BaseCommandDbContext. وابستگی‌های سازنده (DI): TDbContext dbContext. مرتبط: IUni…

- **Base:** `IUnitOfWork`

**اعضا (7):**

- `_dbContext` (field): `protected readonly TDbContext _dbContext;`
- `.ctor` (constructor): `public BaseEntityFrameworkUnitOfWork(TDbContext dbContext)`
- `BeginTransaction` (method): `public void BeginTransaction()`
- `Commit` (method): `public int Commit()`
- `CommitAsync` (method): `public async Task<int> CommitAsync()`
- `CommitTransaction` (method): `public void CommitTransaction()`
- `RollbackTransaction` (method): `public void RollbackTransaction()`

### Namespace: `Zamin.Infra.Data.Sql.Commands.ValueConversions`

#### `Zamin.Infra.Data.Sql.Commands.ValueConversions.BusinessIdConversion` (class)

کلاس «BusinessIdConversion» در namespace Zamin.Infra.Data.Sql.Commands.ValueConversions. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین. ارث‌بری/پیاده‌سازی: ValueConverter<BusinessId, Guid>. مرتبط: ValueConverter<BusinessId, Guid>.

- **Base:** `ValueConverter<BusinessId, Guid>`

**اعضا (1):**

- `.ctor` (constructor): `public BusinessIdConversion()`

#### `Zamin.Infra.Data.Sql.Commands.ValueConversions.DescriptionConversion` (class)

کلاس «DescriptionConversion» در namespace Zamin.Infra.Data.Sql.Commands.ValueConversions. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین. ارث‌بری/پیاده‌سازی: ValueConverter<Description, string>. مرتبط: ValueConverter<Description, string>.

- **Base:** `ValueConverter<Description, string>`

**اعضا (1):**

- `.ctor` (constructor): `public DescriptionConversion()`

#### `Zamin.Infra.Data.Sql.Commands.ValueConversions.LegalNationalIdConversion` (class)

کلاس «LegalNationalIdConversion» در namespace Zamin.Infra.Data.Sql.Commands.ValueConversions. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین. ارث‌بری/پیاده‌سازی: ValueConverter<LegalNationalId, string>. مرتبط: ValueConverter<LegalNationalId, string>.

- **Base:** `ValueConverter<LegalNationalId, string>`

**اعضا (1):**

- `.ctor` (constructor): `public LegalNationalIdConversion()`

#### `Zamin.Infra.Data.Sql.Commands.ValueConversions.NationalCodeConversion` (class)

کلاس «NationalCodeConversion» در namespace Zamin.Infra.Data.Sql.Commands.ValueConversions. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین. ارث‌بری/پیاده‌سازی: ValueConverter<NationalCode, string>. مرتبط: ValueConverter<NationalCode, string>.

- **Base:** `ValueConverter<NationalCode, string>`

**اعضا (1):**

- `.ctor` (constructor): `public NationalCodeConversion()`

#### `Zamin.Infra.Data.Sql.Commands.ValueConversions.TitleConversion` (class)

کلاس «TitleConversion» در namespace Zamin.Infra.Data.Sql.Commands.ValueConversions. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین. ارث‌بری/پیاده‌سازی: ValueConverter<Title, string>. مرتبط: ValueConverter<Title, string>.

- **Base:** `ValueConverter<Title, string>`

**اعضا (1):**

- `.ctor` (constructor): `public TitleConversion()`

### Namespace: `Zamin.Infra.Data.Sql.Queries`

#### `Zamin.Infra.Data.Sql.Queries.BaseQueryDbContext` (class)

کلاس «BaseQueryDbContext» در namespace Zamin.Infra.Data.Sql.Queries. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین. ارث‌بری/پیاده‌سازی: DbContext. وابستگی‌های سازنده (DI): DbContextOptions options. مرتبط: DbContext | DI: DbContextOptions options.

- **Base:** `DbContext`

**اعضا (7):**

- `.ctor` (constructor): `public BaseQueryDbContext(DbContextOptions options)`
- `OnConfiguring` (method): `protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)`
- `OnModelCreating` (method): `protected override void OnModelCreating(ModelBuilder modelBuilder)`
- `SaveChanges` (method): `public override int SaveChanges()`
- `SaveChanges` (method): `public override int SaveChanges(bool acceptAllChangesOnSuccess)`
- `SaveChangesAsync` (method): `public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)`
- `SaveChangesAsync` (method): `public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)`

#### `Zamin.Infra.Data.Sql.Queries.BaseQueryRepository<TDbContext>` (class)

کلاس «BaseQueryRepository<TDbContext>» در namespace Zamin.Infra.Data.Sql.Queries. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین. ارث‌بری/پیاده‌سازی: IQueryRepository. قیود جنریک: where TDbContext : BaseQueryDbContext. وابستگی‌های سازنده (DI): TDbContext dbContext. مر…

- **Base:** `IQueryRepository`

**اعضا (2):**

- `_dbContext` (field): `protected readonly TDbContext _dbContext;`
- `.ctor` (constructor): `public BaseQueryRepository(TDbContext dbContext)`

#### `Zamin.Infra.Data.Sql.Queries.QueryRepositoryExtensions` (class)

کلاس «QueryRepositoryExtensions» در namespace Zamin.Infra.Data.Sql.Queries. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

**اعضا (1):**

- `ToPagedData` (method): `public static async Task<PagedData<TResult>> ToPagedData<TEntity, TQuery, TResult>(this IQueryable<TEntity> entities, PageQuery<PagedData<TQuery>> query, Func<TEntity, TResult> selectFunc)`

### Namespace: `Zamin.Utilities.Auth.ApiAuthentication.Extensions`

#### `Zamin.Utilities.Auth.ApiAuthentication.Extensions.ClaimsPrincipalExtentions` (class)

کلاس «ClaimsPrincipalExtentions» در namespace Zamin.Utilities.Auth.ApiAuthentication.Extensions. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین.

**اعضا (3):**

- `HasSubClaim` (method): `public static bool HasSubClaim(this ClaimsPrincipal? principal, string userIdentifierClaimType)`
- `CreateClaimsIdentity` (method): `public static ClaimsIdentity CreateClaimsIdentity(this ClaimsPrincipal? principal, List<Claim> claims)`
- `ClonePrincipalWithConvertedClaims` (method): `public static ClaimsPrincipal? ClonePrincipalWithConvertedClaims(this ClaimsPrincipal? principal, ProviderOption provider)`

### Namespace: `Zamin.Utilities.Auth.ApiAuthentication.Models`

#### `Zamin.Utilities.Auth.ApiAuthentication.Models.ClaimCacheModel` (class)

کلاس «ClaimCacheModel» در namespace Zamin.Utilities.Auth.ApiAuthentication.Models. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین. وابستگی‌های سازنده (DI): string type, string value, string? valueType, string? issuer, string? originalIssuer, ClaimsIdentity? subject. ا…

**اعضا (10):**

- `Type` (property): `public string Type { get; set; }`
- `Value` (property): `public string Value { get; set; }`
- `ValueType` (property): `public string? ValueType { get; set; }`
- `Issuer` (property): `public string? Issuer { get; set; }`
- `OriginalIssuer` (property): `public string? OriginalIssuer { get; set; }`
- `Subject` (property): `public ClaimsIdentity? Subject { get; set; }`
- `.ctor` (constructor): `public ClaimCacheModel()`
- `.ctor` (constructor): `public ClaimCacheModel(string type, string value, string? valueType, string? issuer, string? originalIssuer, ClaimsIdentity? subject)`
- `FromClaim` (method): `public static ClaimCacheModel FromClaim(Claim claim)`
- `ToClaim` (method): `public Claim ToClaim()`

### Namespace: `Zamin.Utilities.Auth.ApiAuthentication.Options`

#### `Zamin.Utilities.Auth.ApiAuthentication.Options.ApiAuthenticationOption` (class)

کلاس «ApiAuthenticationOption» در namespace Zamin.Utilities.Auth.ApiAuthentication.Options. مدل تنظیمات قابل بایند شدن از configuration.

**اعضا (5):**

- `Enabled` (property): `public bool Enabled { get; set; }`
- `Providers` (property): `public List<ProviderOption> Providers { get; set; }`
- `EnabledProviders` (property): `public IReadOnlyList<ProviderOption> EnabledProviders => ...`
- `DefualtProvider` (property): `public ProviderOption? DefualtProvider => ...`
- `Active` (property): `public bool Active => ...`

#### `Zamin.Utilities.Auth.ApiAuthentication.Options.CacheExpirationType` (enum)

شمارشی (enum) «CacheExpirationType» در namespace Zamin.Utilities.Auth.ApiAuthentication.Options. مدل تنظیمات قابل بایند شدن از configuration.

**اعضا (2):**

- `Absolute` (enum_member): `Absolute = 1`
- `Sliding` (enum_member): `Sliding = 2`

#### `Zamin.Utilities.Auth.ApiAuthentication.Options.CacheKeyFormat` (enum)

شمارشی (enum) «CacheKeyFormat» در namespace Zamin.Utilities.Auth.ApiAuthentication.Options. مدل تنظیمات قابل بایند شدن از configuration.

**اعضا (2):**

- `Base64` (enum_member): `Base64 = 1`
- `PlainText` (enum_member): `PlainText = 2`

#### `Zamin.Utilities.Auth.ApiAuthentication.Options.EndpointsPathOption` (class)

کلاس «EndpointsPathOption» در namespace Zamin.Utilities.Auth.ApiAuthentication.Options. مدل تنظیمات قابل بایند شدن از configuration.

**اعضا (4):**

- `AuthorizeEndpoint` (property): `public string AuthorizeEndpoint { get; set; }`
- `TokenEndpoint` (property): `public string TokenEndpoint { get; set; }`
- `UserInfoEndpoint` (property): `public string UserInfoEndpoint { get; set; }`
- `IntrospectionEndpoint` (property): `public string IntrospectionEndpoint { get; set; }`

#### `Zamin.Utilities.Auth.ApiAuthentication.Options.JwtTokenConfigOption` (class)

کلاس «JwtTokenConfigOption» در namespace Zamin.Utilities.Auth.ApiAuthentication.Options. مدل تنظیمات قابل بایند شدن از configuration.

**اعضا (5):**

- `Audience` (property): `public string? Audience { get; set; }`
- `RequireHttpsMetadata` (property): `public bool RequireHttpsMetadata { get; set; }`
- `ValidateAudience` (property): `public bool ValidateAudience { get; set; }`
- `ValidateIssuer` (property): `public bool ValidateIssuer { get; set; }`
- `ValidateIssuerSigningKey` (property): `public bool ValidateIssuerSigningKey { get; set; }`

#### `Zamin.Utilities.Auth.ApiAuthentication.Options.ProviderOption` (class)

کلاس «ProviderOption» در namespace Zamin.Utilities.Auth.ApiAuthentication.Options. مدل تنظیمات قابل بایند شدن از configuration.

**اعضا (14):**

- `Enabled` (property): `public bool Enabled { get; set; }`
- `IgnoreSSL` (property): `public bool IgnoreSSL { get; set; }`
- `Scheme` (property): `public string Scheme { get; set; }`
- `Authority` (property): `public string Authority { get; set; }`
- `HttpClientFactoryName` (property): `public string? HttpClientFactoryName { get; set; }`
- `TokenTypeSupport` (property): `public TokenType TokenTypeSupport { get; set; }`
- `JwtTokenConfig` (property): `public JwtTokenConfigOption JwtTokenConfig { get; set; }`
- `RefrenceTokenConfig` (property): `public RefrenceTokenConfigOption RefrenceTokenConfig { get; set; }`
- `UserIdentifierClaimType` (property): `public string UserIdentifierClaimType { get; set; }`
- `RegisterUserInfoClaims` (property): `public RegisterUserInfoClaimsOption RegisterUserInfoClaims { get; set; }`
- `UserClaimRules` (property): `public List<UserClaimRuleOption> UserClaimRules { get; set; }`
- `UserClaimAddons` (property): `public List<UserClaimAddonOption> UserClaimAddons { get; set; }`
- `EndpointsPath` (property): `public EndpointsPathOption? EndpointsPath { get; set; }`
- `Priority` (property): `public int Priority { get; set; }`

#### `Zamin.Utilities.Auth.ApiAuthentication.Options.RefrenceTokenConfigOption` (class)

کلاس «RefrenceTokenConfigOption» در namespace Zamin.Utilities.Auth.ApiAuthentication.Options. مدل تنظیمات قابل بایند شدن از configuration.

**اعضا (2):**

- `ClientId` (property): `public string ClientId { get; set; }`
- `ClientSecret` (property): `public string ClientSecret { get; set; }`

#### `Zamin.Utilities.Auth.ApiAuthentication.Options.RegisterUserInfoClaimsOption` (class)

کلاس «RegisterUserInfoClaimsOption» در namespace Zamin.Utilities.Auth.ApiAuthentication.Options. مدل تنظیمات قابل بایند شدن از configuration.

**اعضا (6):**

- `Enabled` (property): `public bool Enabled { get; set; }`
- `CachingData` (property): `public bool CachingData { get; set; }`
- `CacheKeyPrefix` (property): `public string CacheKeyPrefix { get; set; }`
- `CacheKeyFormat` (property): `public CacheKeyFormat CacheKeyFormat { get; set; }`
- `CacheExpirationType` (property): `public CacheExpirationType CacheExpirationType { get; set; }`
- `CacheExpirationInSeconds` (property): `public int CacheExpirationInSeconds { get; set; }`

#### `Zamin.Utilities.Auth.ApiAuthentication.Options.TokenType` (enum)

شمارشی (enum) «TokenType» در namespace Zamin.Utilities.Auth.ApiAuthentication.Options. مدل تنظیمات قابل بایند شدن از configuration.

**اعضا (2):**

- `Jwt` (enum_member): `Jwt = 1`
- `Reference` (enum_member): `Reference = 2`

#### `Zamin.Utilities.Auth.ApiAuthentication.Options.UserClaimAddonOption` (class)

کلاس «UserClaimAddonOption» در namespace Zamin.Utilities.Auth.ApiAuthentication.Options. مدل تنظیمات قابل بایند شدن از configuration.

**اعضا (5):**

- `Type` (property): `public string Type { get; set; }`
- `Value` (property): `public string Value { get; set; }`
- `ValueType` (property): `public string? ValueType { get; set; }`
- `Issuer` (property): `public string? Issuer { get; set; }`
- `OriginalIssuer` (property): `public string? OriginalIssuer { get; set; }`

#### `Zamin.Utilities.Auth.ApiAuthentication.Options.UserClaimRuleOption` (class)

کلاس «UserClaimRuleOption» در namespace Zamin.Utilities.Auth.ApiAuthentication.Options. مدل تنظیمات قابل بایند شدن از configuration.

**اعضا (3):**

- `Source` (property): `public string Source { get; set; }`
- `Destination` (property): `public string Destination { get; set; }`
- `RemoveSource` (property): `public bool RemoveSource { get; set; }`

### Namespace: `Zamin.Utilities.DateTimes`

#### `Zamin.Utilities.DateTimes.DateTimeOffsetPart` (enum)

DateTimeOffset Part سورس این بخش در ابتدا از مجموعه کارهای آقای وحید نصیری برداشته شده است. پس از تکمیل و اصلاحات نهایی آدرس دهی و ... اصلاح می‌شود

**اعضا (4):**

- `DateTime` (enum_member): `DateTime`
- `LocalDateTime` (enum_member): `LocalDateTime`
- `UtcDateTime` (enum_member): `UtcDateTime`
- `IranLocalDateTime` (enum_member): `IranLocalDateTime`

#### `Zamin.Utilities.DateTimes.DateTimeUtils` (class)

متدهای کمکی جهت کار با تاریخ میلادی

**اعضا (18):**

- `IranStandardTime` (field): `public static readonly TimeZoneInfo IranStandardTime;`
- `Epoch` (field): `public static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);`
- `GetAge` (method): `public static int GetAge(this DateTimeOffset birthday, DateTime comparisonBase, DateTimeOffsetPart dateTimeOffsetPart = DateTimeOffsetPart.IranLocalDateTime)`
- `GetAge` (method): `public static int GetAge(this DateTimeOffset birthday)`
- `GetAge` (method): `public static int GetAge(this DateTime birthday, DateTime comparisonBase)`
- `GetAge` (method): `public static int GetAge(this DateTime birthday)`
- `GetDateTimeOffsetPart` (method): `public static DateTime GetDateTimeOffsetPart( this DateTimeOffset dateTimeOffset, DateTimeOffsetPart dataDateTimeOffsetPart)`
- `GetNow` (method): `public static DateTime GetNow(this DateTimeKind dataDateTimeKind)`
- `ToIranTimeZoneDateTimeOffset` (method): `public static DateTimeOffset ToIranTimeZoneDateTimeOffset(this DateTimeOffset dateTimeOffset)`
- `ToIranTimeZoneDateTime` (method): `public static DateTime ToIranTimeZoneDateTime(this DateTime dateTime)`
- `ToEpochMilliseconds` (method): `public static long ToEpochMilliseconds(this DateTime dateTime)`
- `ToEpochSeconds` (method): `public static long ToEpochSeconds(this DateTime dateTime)`
- `IsBetween` (method): `public static bool IsBetween(this DateTime date, DateTime startDate, DateTime endDate, bool compareTime = false)`
- `IsLastDayOfTheMonth` (method): `public static bool IsLastDayOfTheMonth(this DateTime dateTime)`
- `IsWeekend` (method): `public static bool IsWeekend(this DateTime value)`
- `IsLeapYear` (method): `public static bool IsLeapYear(this DateTime value)`
- `ToDateTimeOffset` (method): `public static DateTimeOffset ToDateTimeOffset(this DateTime dt, TimeSpan offset)`
- `ToDateTimeOffset` (method): `public static DateTimeOffset ToDateTimeOffset(this DateTime dt, double offsetInHours = 0)`

#### `Zamin.Utilities.DateTimes.FriendlyPersianDateUtils` (class)

نمایش دوستانه‌ی یک تاریخ و ساعت انگلیسی به شمسی

**اعضا (13):**

- `ToPersianDateTextify` (method): `public static string ToPersianDateTextify(int persianYear, int persianMonth, int persianDay)`
- `ToPersianDateTextify` (method): `public static string ToPersianDateTextify(this DateTime dt)`
- `ToPersianDateTextify` (method): `public static string ToPersianDateTextify(this DateTime? dt)`
- `ToPersianDateTextify` (method): `public static string ToPersianDateTextify(this DateTimeOffset dt, DateTimeOffsetPart dateTimeOffsetPart = DateTimeOffsetPart.IranLocalDateTime)`
- `ToPersianDateTextify` (method): `public static string ToPersianDateTextify(this DateTimeOffset? dt, DateTimeOffsetPart dateTimeOffsetPart = DateTimeOffsetPart.IranLocalDateTime)`
- `ToFriendlyPersianDateTextify` (method): `public static string ToFriendlyPersianDateTextify(this DateTime dt, DateTime comparisonBase, bool appendHhMm = true)`
- `ToFriendlyPersianDateTextify` (method): `public static string ToFriendlyPersianDateTextify(this DateTime dt, bool appendHhMm = true)`
- `ToFriendlyPersianDateTextify` (method): `public static string ToFriendlyPersianDateTextify(this DateTimeOffset dt, DateTime comparisonBase, DateTimeOffsetPart dateTimeOffsetPart = DateTimeOffsetPart.IranLocalDateTime, bool appendHhMm = true)`
- `ToFriendlyPersianDateTextify` (method): `public static string ToFriendlyPersianDateTextify(this DateTimeOffset dt, bool appendHhMm = true)`
- `ToFriendlyPersianDateTextify` (method): `public static string ToFriendlyPersianDateTextify(this DateTime? dt, DateTime comparisonBase)`
- `ToFriendlyPersianDateTextify` (method): `public static string ToFriendlyPersianDateTextify(this DateTime? dt)`
- `ToFriendlyPersianDateTextify` (method): `public static string ToFriendlyPersianDateTextify(this DateTimeOffset? dt, DateTime comparisonBase, DateTimeOffsetPart dateTimeOffsetPart = DateTimeOffsetPart.IranLocalDateTime)`
- `ToFriendlyPersianDateTextify` (method): `public static string ToFriendlyPersianDateTextify(this DateTimeOffset? dt)`

#### `Zamin.Utilities.DateTimes.PersianCulture` (class)

فرهنگ فارسی سفارشی سازی شده

**اعضا (22):**

- `PersianDayWeekNames` (field): `public static readonly IDictionary<DayOfWeek, string> PersianDayWeekNames = new Dictionary<DayOfWeek, string> // …`
- `PersianMonthDayNumberNames` (field): `public static readonly IDictionary<int, string> PersianMonthDayNumberNames = new Dictionary<int, string> // …`
- `PersianMonthNames` (field): `public static readonly IDictionary<int, string> PersianMonthNames = new Dictionary<int, string> // …`
- `Instance` (property): `public static CultureInfo Instance { get; }`
- `GetPersianDayOfMonth` (method): `public static int GetPersianDayOfMonth(this DateTime dateTime)`
- `GetPersianMonth` (method): `public static int GetPersianMonth(this DateTime dateTime)`
- `GetPersianMonthDayNumberName` (method): `public static string GetPersianMonthDayNumberName(this int dayNumber)`
- `GetPersianMonthName` (method): `public static string GetPersianMonthName(this int monthNumber)`
- `GetPersianWeekDayName` (method): `public static string GetPersianWeekDayName(this DayOfWeek dayOfWeek)`
- `GetPersianWeekDayName` (method): `public static string GetPersianWeekDayName(int persianYear, int persianMonth, int persianDay)`
- `GetPersianWeekDayName` (method): `public static string GetPersianWeekDayName(this DateTime dt)`
- `GetPersianWeekDayName` (method): `public static string GetPersianWeekDayName(this DateTime? dt)`
- `GetPersianWeekDayName` (method): `public static string GetPersianWeekDayName(this DateTimeOffset? dt, DateTimeOffsetPart dateTimeOffsetPart = DateTimeOffsetPart.IranLocalDateTime)`
- `GetPersianWeekDayName` (method): `public static string GetPersianWeekDayName(this DateTimeOffset dt, DateTimeOffsetPart dateTimeOffsetPart = DateTimeOffsetPart.IranLocalDateTime)`
- `GetPersianYear` (method): `public static int GetPersianYear(this DateTime dateTime)`
- `GetPersianYearStartAndEndDates` (method): `public static PersianYear GetPersianYearStartAndEndDates(this int persianYear)`
- `GetPersianYearStartAndEndDates` (method): `public static PersianYear GetPersianYearStartAndEndDates(this DateTime dateTime)`
- `GetPersianYearStartAndEndDates` (method): `public static PersianYear GetPersianYearStartAndEndDates(this DateTimeOffset dateTimeOffset, DateTimeOffsetPart dateTimeOffsetPart = DateTimeOffsetPart.IranLocalDateTime)`
- `GetPersianMonthStartAndEndDates` (method): `public static PersianMonth GetPersianMonthStartAndEndDates(this int persianYear, int persianMonth)`
- `GetPersianMonthStartAndEndDates` (method): `public static PersianMonth GetPersianMonthStartAndEndDates(this DateTime dateTime)`
- `GetPersianMonthStartAndEndDates` (method): `public static PersianMonth GetPersianMonthStartAndEndDates(this DateTimeOffset dateTimeOffset, DateTimeOffsetPart dateTimeOffsetPart = DateTimeOffsetPart.IranLocalDateTime)`
- `GetPersianMonthLastDay` (method): `public static int GetPersianMonthLastDay(this int persianYear, int persianMonth)`

#### `Zamin.Utilities.DateTimes.PersianDateTimeUtils` (class)

Represents PersianDateTime utils.

**اعضا (26):**

- `IsValidPersianDate` (method): `public static bool IsValidPersianDate(int persianYear, int persianMonth, int persianDay)`
- `IsValidPersianDateTime` (method): `public static bool IsValidPersianDateTime(this string persianDateTime)`
- `ToGregorianDateTime` (method): `public static DateTime? ToGregorianDateTime(this string persianDateTime)`
- `ToGregorianDateTimeOffset` (method): `public static DateTimeOffset? ToGregorianDateTimeOffset(this string persianDateTime)`
- `ToLongPersianDateString` (method): `public static string ToLongPersianDateString(this DateTime dt)`
- `ToLongPersianDateString` (method): `public static string ToLongPersianDateString(this DateTime? dt)`
- `ToLongPersianDateString` (method): `public static string ToLongPersianDateString(this DateTimeOffset? dt, DateTimeOffsetPart dateTimeOffsetPart = DateTimeOffsetPart.IranLocalDateTime)`
- `ToLongPersianDateString` (method): `public static string ToLongPersianDateString(this DateTimeOffset dt, DateTimeOffsetPart dateTimeOffsetPart = DateTimeOffsetPart.IranLocalDateTime)`
- `ToLongPersianDateTimeString` (method): `public static string ToLongPersianDateTimeString(this DateTime dt)`
- `ToLongPersianDateTimeString` (method): `public static string ToLongPersianDateTimeString(this DateTime? dt)`
- `ToLongPersianDateTimeString` (method): `public static string ToLongPersianDateTimeString(this DateTimeOffset? dt, DateTimeOffsetPart dateTimeOffsetPart = DateTimeOffsetPart.IranLocalDateTime)`
- `ToLongPersianDateTimeString` (method): `public static string ToLongPersianDateTimeString(this DateTimeOffset dt, DateTimeOffsetPart dateTimeOffsetPart = DateTimeOffsetPart.IranLocalDateTime)`
- `ToPersianDateTimeString` (method): `public static string ToPersianDateTimeString(this DateTime dateTime, string format)`
- `ToPersianYearMonthDay` (method): `public static PersianDay ToPersianYearMonthDay(this DateTimeOffset? gregorianDate, DateTimeOffsetPart dateTimeOffsetPart = DateTimeOffsetPart.IranLocalDateTime)`
- `ToPersianYearMonthDay` (method): `public static PersianDay ToPersianYearMonthDay(this DateTime? gregorianDate)`
- `ToPersianYearMonthDay` (method): `public static PersianDay ToPersianYearMonthDay(this DateTimeOffset gregorianDate, DateTimeOffsetPart dateTimeOffsetPart = DateTimeOffsetPart.IranLocalDateTime)`
- `ToPersianYearMonthDay` (method): `public static PersianDay ToPersianYearMonthDay(this DateTime gregorianDate)`
- `ToShortPersianDateString` (method): `public static string ToShortPersianDateString(this DateTimeOffset? dt, DateTimeOffsetPart dateTimeOffsetPart = DateTimeOffsetPart.IranLocalDateTime)`
- `ToShortPersianDateString` (method): `public static string ToShortPersianDateString(this DateTimeOffset dt, DateTimeOffsetPart dateTimeOffsetPart = DateTimeOffsetPart.IranLocalDateTime)`
- `ToShortPersianDateString` (method): `public static string ToShortPersianDateString(this DateTime dt)`
- `ToShortPersianDateString` (method): `public static string ToShortPersianDateString(this DateTime? dt)`
- `ToShortPersianDateTimeString` (method): `public static string ToShortPersianDateTimeString(this DateTime dt)`
- `ToShortPersianDateTimeString` (method): `public static string ToShortPersianDateTimeString(this DateTime? dt)`
- `ToShortPersianDateTimeString` (method): `public static string ToShortPersianDateTimeString(this DateTimeOffset? dt, DateTimeOffsetPart dateTimeOffsetPart = DateTimeOffsetPart.IranLocalDateTime)`
- `ToShortPersianDateTimeString` (method): `public static string ToShortPersianDateTimeString(this DateTimeOffset dt, DateTimeOffsetPart dateTimeOffsetPart = DateTimeOffsetPart.IranLocalDateTime)`
- `CorrectReverseDate` (method): `public static string CorrectReverseDate(string reverseDate)`

#### `Zamin.Utilities.DateTimes.PersianDay` (class)

اجزای روز شمسی

**اعضا (8):**

- `Year` (property): `public int Year { set; get; }`
- `Month` (property): `public int Month { set; get; }`
- `Day` (property): `public int Day { set; get; }`
- `.ctor` (constructor): `public PersianDay()`
- `.ctor` (constructor): `public PersianDay(int year, int month, int day)`
- `ToString` (method): `public override string ToString()`
- `Equals` (method): `public override bool Equals(object obj)`
- `GetHashCode` (method): `public override int GetHashCode()`

#### `Zamin.Utilities.DateTimes.PersianMonth` (class)

اجزای ماه شمسی

**اعضا (2):**

- `StartDate` (property): `public DateTime StartDate { set; get; }`
- `EndDate` (property): `public DateTime EndDate { set; get; }`

#### `Zamin.Utilities.DateTimes.PersianNumbersUtils` (class)

Converts English digits of a given number to their equivalent Persian digits.

**اعضا (6):**

- `ToPersianNumbers` (method): `public static string ToPersianNumbers(this int number, string format = "")`
- `ToPersianNumbers` (method): `public static string ToPersianNumbers(this long number, string format = "")`
- `ToPersianNumbers` (method): `public static string ToPersianNumbers(this int? number, string format = "")`
- `ToPersianNumbers` (method): `public static string ToPersianNumbers(this long? number, string format = "")`
- `ToPersianNumbers` (method): `public static string ToPersianNumbers(this string data)`
- `ToEnglishNumbers` (method): `public static string ToEnglishNumbers(this string data)`

#### `Zamin.Utilities.DateTimes.PersianYear` (class)

اجزای سال شمسی

**اعضا (2):**

- `StartDate` (property): `public DateTime StartDate { set; get; }`
- `EndDate` (property): `public DateTime EndDate { set; get; }`

#### `Zamin.Utilities.DateTimes.RegexUtils` (class)

متدهای کمکی مبتنی بر عبارات باقاعده

**اعضا (6):**

- `MatchTimeout` (field): `public static readonly TimeSpan MatchTimeout = TimeSpan.FromSeconds(3);`
- `ContainsFarsi` (method): `public static bool ContainsFarsi(this string txt)`
- `ContainsOnlyFarsiLetters` (method): `public static bool ContainsOnlyFarsiLetters(this string txt)`
- `StripHtmlTags` (method): `public static string StripHtmlTags(this string text)`
- `WrapInDirectionalDiv` (method): `public static string WrapInDirectionalDiv(this string body, string fontFamily = "tahoma", string fontSize = "9pt")`
- `ContainsOnlyPersianNumbers` (method): `public static bool ContainsOnlyPersianNumbers(this string text)`

#### `Zamin.Utilities.DateTimes.TimeConstants` (class)

Time Constants

**اعضا (5):**

- `Day` (field): `public const int Day = 24 * Hour;`
- `Hour` (field): `public const int Hour = 60 * Minute;`
- `Minute` (field): `public const int Minute = 60 * Second;`
- `Month` (field): `public const int Month = 30 * Day;`
- `Second` (field): `public const int Second = 1;`

#### `Zamin.Utilities.DateTimes.UnicodeConstants` (class)

Unicode Constants

**اعضا (2):**

- `RleChar` (field): `public const char RleChar = (char)0x202B;`
- `ApplyRle` (method): `public static string ApplyRle(this string text)`

### Namespace: `Zamin.Utilities.Extensions`

#### `Zamin.Utilities.Extensions.DateTimeExtensions` (class)

کلاس «DateTimeExtensions» در namespace Zamin.Utilities.Extensions. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

**اعضا (12):**

- `ToUnixTimeMillisecond` (method): `public static long ToUnixTimeMillisecond(this DateTime dateTime, TimeZoneInfo timeZoneInfo)`
- `ToUnixTimeMillisecond` (method): `public static long? ToUnixTimeMillisecond(this DateTime? dateTime, TimeZoneInfo timeZoneInfo)`
- `ToDateTime` (method): `public static DateTime ToDateTime(this long unixTimeMilliseconds, TimeZoneInfo timeZoneInfo)`
- `ToDateTime` (method): `public static DateTime? ToDateTime(this long? unixTimeMilliseconds, TimeZoneInfo timeZoneInfo)`
- `ToLocalUnixTimeMillisecond` (method): `public static long ToLocalUnixTimeMillisecond(this DateTime dateTime)`
- `ToLocalUnixTimeMillisecond` (method): `public static long? ToLocalUnixTimeMillisecond(this DateTime? dateTime)`
- `ToLocalDateTime` (method): `public static DateTime ToLocalDateTime(this long unixTimeMilliseconds)`
- `ToLocalDateTime` (method): `public static DateTime? ToLocalDateTime(this long? unixTimeMilliseconds)`
- `ToUtcUnixTimeMillisecond` (method): `public static long ToUtcUnixTimeMillisecond(this DateTime dateTime)`
- `ToUtcUnixTimeMillisecond` (method): `public static long? ToUtcUnixTimeMillisecond(this DateTime? dateTime)`
- `ToUtcDateTime` (method): `public static DateTime ToUtcDateTime(this long unixTimeMilliseconds)`
- `ToUtcDateTime` (method): `public static DateTime? ToUtcDateTime(this long? unixTimeMilliseconds)`

#### `Zamin.Utilities.Extensions.EnumExtensions` (class)

کلاس «EnumExtensions» در namespace Zamin.Utilities.Extensions. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

**اعضا (1):**

- `GetEnumDescription` (method): `public static string GetEnumDescription(this Enum enumValue)`

#### `Zamin.Utilities.Extensions.GuidExtensions` (class)

کلاس «GuidExtensions» در namespace Zamin.Utilities.Extensions. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

**اعضا (2):**

- `IsNullOrEmpty` (method): `public static bool IsNullOrEmpty(this Guid? guid)`
- `IsEmpty` (method): `public static bool IsEmpty(this Guid guid)`

#### `Zamin.Utilities.Extensions.LinqExtensions` (class)

کلاس «LinqExtensions» در namespace Zamin.Utilities.Extensions. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

**اعضا (5):**

- `OrderByField` (method): `public static IQueryable<T> OrderByField<T>(this IQueryable<T> q, string SortField, bool Ascending)`
- `ToDataTable` (method): `public static DataTable ToDataTable<T>(this List<T> list)`
- `ToList` (method): `public static List<T> ToList<T>(this DataTable dt)`
- `WhereIf` (method): `public static IQueryable<T> WhereIf<T>(this IQueryable<T> query, bool condition, Expression<Func<T, bool>> predicate)`
- `WhereIf` (method): `public static IQueryable<T> WhereIf<T>(this IQueryable<T> query, bool condition, Expression<Func<T, int, bool>> predicate)`

#### `Zamin.Utilities.Extensions.ObjectExtensions` (class)

کلاس «ObjectExtensions» در namespace Zamin.Utilities.Extensions. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

**اعضا (1):**

- `ToQueryString` (method): `public static string ToQueryString(this object obj)`

#### `Zamin.Utilities.Extensions.StringExtensions` (class)

کلاس «StringExtensions» در namespace Zamin.Utilities.Extensions. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

**اعضا (18):**

- `ArabicYeChar` (field): `public const char ArabicYeChar = (char)1610;`
- `PersianYeChar` (field): `public const char PersianYeChar = (char)1740;`
- `ArabicKeChar` (field): `public const char ArabicKeChar = (char)1603;`
- `PersianKeChar` (field): `public const char PersianKeChar = (char)1705;`
- `ApplyCorrectYeKe` (method): `public static string ApplyCorrectYeKe(this object data)`
- `ApplyCorrectYeKe` (method): `public static string ApplyCorrectYeKe(this string data)`
- `ToSafeLong` (method): `public static long ToSafeLong(this string input, long replacement = long.MinValue)`
- `ToSafeNullableLong` (method): `public static long? ToSafeNullableLong(this string input)`
- `ToSafeInt` (method): `public static int ToSafeInt(this string input, int replacement = int.MinValue)`
- `ToSafeNullableInt` (method): `public static int? ToSafeNullableInt(this string input)`
- `ToStringOrEmpty` (method): `public static string ToStringOrEmpty(this string? input)`
- `ToUnderscoreCase` (method): `public static string ToUnderscoreCase(this string input)`
- `ToByteArray` (method): `public static byte[] ToByteArray(this string input)`
- `FromByteArray` (method): `public static string FromByteArray(this byte[] input)`
- `ToNumeric` (method): `public static string ToNumeric(this int value)`
- `ToCurrency` (method): `public static string ToCurrency(this int value)`
- `En2Fa` (method): `public static string En2Fa(this string str)`
- `Fa2En` (method): `public static string Fa2En(this string str)`

#### `Zamin.Utilities.Extensions.StringValidatorExtensions` (class)

کلاس «StringValidatorExtensions» در namespace Zamin.Utilities.Extensions. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

**اعضا (9):**

- `IsNationalCode` (method): `public static bool IsNationalCode(this string nationalCode)`
- `IsLegalNationalIdValid` (method): `public static bool IsLegalNationalIdValid(this string nationalId)`
- `IsNumeric` (method): `public static bool IsNumeric(this string nationalCode)`
- `IsLengthBetween` (method): `public static bool IsLengthBetween(this string input, int minLength, int maxLenght)`
- `IsLengthLessThan` (method): `public static bool IsLengthLessThan(this string input, int lenght)`
- `IsLengthLessThanOrEqual` (method): `public static bool IsLengthLessThanOrEqual(this string input, int lenght)`
- `IsLengthGreaterThan` (method): `public static bool IsLengthGreaterThan(this string input, int lenght)`
- `IsLengthGreaterThanOrEqual` (method): `public static bool IsLengthGreaterThanOrEqual(this string input, int lenght)`
- `IsLengthEqual` (method): `public static bool IsLengthEqual(this string input, int lenght)`

#### `Zamin.Utilities.Extensions.TypeExtentsions` (class)

کلاس «TypeExtentsions» در namespace Zamin.Utilities.Extensions. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین.

**اعضا (1):**

- `IsSubclassOfRawGeneric` (method): `public static bool IsSubclassOfRawGeneric(this Type toCheck, Type generic)`

### Namespace: `Zamin.Utilities.Guards.GuardClauses`

#### `Zamin.Utilities.Guards.GuardClauses.EmptyGuardClause` (class)

کلاس «EmptyGuardClause» در namespace Zamin.Utilities.Guards.GuardClauses. کمک‌کننده اعتبارسنجی ورودی و پیش‌شرط‌ها.

**اعضا (2):**

- `Empty` (method): `public static void Empty<T>(this Guard guard, T value, string message)`
- `Empty` (method): `public static void Empty<T>(this Guard guard, T value, IEqualityComparer<T> equalityComparer, string message)`

#### `Zamin.Utilities.Guards.GuardClauses.EqualGuardClause` (class)

کلاس «EqualGuardClause» در namespace Zamin.Utilities.Guards.GuardClauses. کمک‌کننده اعتبارسنجی ورودی و پیش‌شرط‌ها.

**اعضا (2):**

- `Equal` (method): `public static void Equal<T>(this Guard guard, T value, T targetValue, string message)`
- `Equal` (method): `public static void Equal<T>(this Guard guard, T value, T targetValue, IEqualityComparer<T> equalityComparer, string message)`

#### `Zamin.Utilities.Guards.GuardClauses.ExclusiveBetweenGuardClause` (class)

کلاس «ExclusiveBetweenGuardClause» در namespace Zamin.Utilities.Guards.GuardClauses. کمک‌کننده اعتبارسنجی ورودی و پیش‌شرط‌ها.

**اعضا (2):**

- `ExclusiveBetween` (method): `public static void ExclusiveBetween<T>(this Guard guard, T value, T minimumValue, T maximumValue, IComparer<T> comparer, string message)`
- `ExclusiveBetween` (method): `public static void ExclusiveBetween<T>(this Guard guard, T value, T minimumValue, T maximumValue, string message) where T : IComparable<T>, IComparable`

#### `Zamin.Utilities.Guards.GuardClauses.GreaterThanGuardClause` (class)

کلاس «GreaterThanGuardClause» در namespace Zamin.Utilities.Guards.GuardClauses. کمک‌کننده اعتبارسنجی ورودی و پیش‌شرط‌ها.

**اعضا (2):**

- `GreaterThan` (method): `public static void GreaterThan<T>(this Guard guard, T value, T minimumValue, IComparer<T> comparer, string message)`
- `GreaterThan` (method): `public static void GreaterThan<T>(this Guard guard, T value, T minimumValue, string message) where T : IComparable<T>, IComparable`

#### `Zamin.Utilities.Guards.GuardClauses.GreaterThanOrEqualGuardClause` (class)

کلاس «GreaterThanOrEqualGuardClause» در namespace Zamin.Utilities.Guards.GuardClauses. کمک‌کننده اعتبارسنجی ورودی و پیش‌شرط‌ها.

**اعضا (2):**

- `GreaterThanOrEqual` (method): `public static void GreaterThanOrEqual<T>(this Guard guard, T value, T minimumValue, IComparer<T> comparer, string message)`
- `GreaterThanOrEqual` (method): `public static void GreaterThanOrEqual<T>(this Guard guard, T value, T minimumValue, string message) where T : IComparable<T>, IComparable`

#### `Zamin.Utilities.Guards.GuardClauses.InclusiveBetweenGuardClause` (class)

کلاس «InclusiveBetweenGuardClause» در namespace Zamin.Utilities.Guards.GuardClauses. کمک‌کننده اعتبارسنجی ورودی و پیش‌شرط‌ها.

**اعضا (2):**

- `InclusiveBetween` (method): `public static void InclusiveBetween<T>(this Guard guard, T value, T minimumValue, T maximumValue, IComparer<T> comparer, string message)`
- `InclusiveBetween` (method): `public static void InclusiveBetween<T>(this Guard guard, T value, T minimumValue, T maximumValue, string message) where T : IComparable<T>, IComparable`

#### `Zamin.Utilities.Guards.GuardClauses.LengthGuardClause` (class)

کلاس «LengthGuardClause» در namespace Zamin.Utilities.Guards.GuardClauses. کمک‌کننده اعتبارسنجی ورودی و پیش‌شرط‌ها.

**اعضا (2):**

- `Length` (method): `public static void Length(this Guard guard, string value, int length, string message)`
- `Length` (method): `public static void Length(this Guard guard, ICollection value, int length, string message)`

#### `Zamin.Utilities.Guards.GuardClauses.LessThanGuardClause` (class)

کلاس «LessThanGuardClause» در namespace Zamin.Utilities.Guards.GuardClauses. کمک‌کننده اعتبارسنجی ورودی و پیش‌شرط‌ها.

**اعضا (2):**

- `LessThan` (method): `public static void LessThan<T>(this Guard guard, T value, T maximumValue, IComparer<T> comparer, string message)`
- `LessThan` (method): `public static void LessThan<T>(this Guard guard, T value, T maximumValue, string message) where T : IComparable<T>, IComparable`

#### `Zamin.Utilities.Guards.GuardClauses.LessThanOrEqualGuardClause` (class)

کلاس «LessThanOrEqualGuardClause» در namespace Zamin.Utilities.Guards.GuardClauses. کمک‌کننده اعتبارسنجی ورودی و پیش‌شرط‌ها.

**اعضا (2):**

- `LessThanOrEqual` (method): `public static void LessThanOrEqual<T>(this Guard guard, T value, T minimumValue, IComparer<T> comparer, string message)`
- `LessThanOrEqual` (method): `public static void LessThanOrEqual<T>(this Guard guard, T value, T minimumValue, string message) where T : IComparable<T>, IComparable`

#### `Zamin.Utilities.Guards.GuardClauses.MatchGuardClause` (class)

کلاس «MatchGuardClause» در namespace Zamin.Utilities.Guards.GuardClauses. کمک‌کننده اعتبارسنجی ورودی و پیش‌شرط‌ها.

**اعضا (1):**

- `Match` (method): `public static void Match(this Guard guard, string value, string pattern, string message)`

#### `Zamin.Utilities.Guards.GuardClauses.MaximumLengthGuardClause` (class)

کلاس «MaximumLengthGuardClause» در namespace Zamin.Utilities.Guards.GuardClauses. کمک‌کننده اعتبارسنجی ورودی و پیش‌شرط‌ها.

**اعضا (2):**

- `MaximumLength` (method): `public static void MaximumLength(this Guard guard, string value, int maximumLength, string message)`
- `MaximumLength` (method): `public static void MaximumLength(this Guard guard, ICollection value, int maximumLength, string message)`

#### `Zamin.Utilities.Guards.GuardClauses.MinimumLengthGuardClause` (class)

کلاس «MinimumLengthGuardClause» در namespace Zamin.Utilities.Guards.GuardClauses. کمک‌کننده اعتبارسنجی ورودی و پیش‌شرط‌ها.

**اعضا (2):**

- `MinimumLength` (method): `public static void MinimumLength(this Guard guard, string value, int minimumLength, string message)`
- `MinimumLength` (method): `public static void MinimumLength<T>(this Guard guard, ICollection value, int minimumLength, string message)`

#### `Zamin.Utilities.Guards.GuardClauses.NotEmptyGuardClause` (class)

کلاس «NotEmptyGuardClause» در namespace Zamin.Utilities.Guards.GuardClauses. کمک‌کننده اعتبارسنجی ورودی و پیش‌شرط‌ها.

**اعضا (2):**

- `NotEmpty` (method): `public static void NotEmpty<T>(this Guard guard, T value, string message)`
- `NotEmpty` (method): `public static void NotEmpty<T>(this Guard guard, T value, IEqualityComparer<T> equalityComparer, string message)`

#### `Zamin.Utilities.Guards.GuardClauses.NotEqualGuardClause` (class)

کلاس «NotEqualGuardClause» در namespace Zamin.Utilities.Guards.GuardClauses. کمک‌کننده اعتبارسنجی ورودی و پیش‌شرط‌ها.

**اعضا (1):**

- `NotEqual` (method): `public static void NotEqual<T>(this Guard guard, T value, T targetValue, string message)`

#### `Zamin.Utilities.Guards.GuardClauses.NotNullGuardClause` (class)

کلاس «NotNullGuardClause» در namespace Zamin.Utilities.Guards.GuardClauses. کمک‌کننده اعتبارسنجی ورودی و پیش‌شرط‌ها.

**اعضا (1):**

- `Null` (method): `public static void Null<T>(this Guard guard, T value, string message)`

#### `Zamin.Utilities.Guards.GuardClauses.NullGuardClause` (class)

کلاس «NullGuardClause» در namespace Zamin.Utilities.Guards.GuardClauses. کمک‌کننده اعتبارسنجی ورودی و پیش‌شرط‌ها.

**اعضا (1):**

- `Null` (method): `public static void Null<T>(this Guard guard, T value, string message)`

### Namespace: `Zamin.Utilities.Guards`

#### `Zamin.Utilities.Guards.Guard` (class)

کلاس «Guard» در namespace Zamin.Utilities.Guards. کمک‌کننده اعتبارسنجی ورودی و پیش‌شرط‌ها.

**اعضا (1):**

- `ThrowIf` (field): `public static Guard ThrowIf = new Guard();`

### Namespace: `Zamin.Utilities`

#### `Zamin.Utilities.ZaminServices` (class)

کلاس «ZaminServices» در namespace Zamin.Utilities. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین. وابستگی‌های سازنده (DI): ITranslator translator, ILoggerFactory loggerFactory, IJsonSerializer serializer, IUserInfoService userInfoService, ICacheAdapter cacheAdapter,…

**اعضا (7):**

- `Translator` (field): `public readonly ITranslator Translator;`
- `CacheAdapter` (field): `public readonly ICacheAdapter CacheAdapter;`
- `MapperFacade` (field): `public readonly IMapperAdapter MapperFacade;`
- `LoggerFactory` (field): `public readonly ILoggerFactory LoggerFactory;`
- `Serializer` (field): `public readonly IJsonSerializer Serializer;`
- `UserInfoService` (field): `public readonly IUserInfoService UserInfoService;`
- `.ctor` (constructor): `public ZaminServices(ITranslator translator, // …`

### Namespace: `Zamin.Utilities.Resources.Translators`

#### `Zamin.Utilities.Resources.Translators.TranslatorKeys` (class)

کلاس «TranslatorKeys» در namespace Zamin.Utilities.Resources.Translators. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین.

**اعضا (34):**

- `VALIDATION_ERROR_NOT_EMPTY` (field): `public const string VALIDATION_ERROR_NOT_EMPTY = nameof(VALIDATION_ERROR_NOT_EMPTY);`
- `VALIDATION_ERROR_NOT_NULL` (field): `public const string VALIDATION_ERROR_NOT_NULL = nameof(VALIDATION_ERROR_NOT_NULL);`
- `VALIDATION_ERROR_IS_REQUIRED` (field): `public const string VALIDATION_ERROR_IS_REQUIRED = nameof(VALIDATION_ERROR_IS_REQUIRED);`
- `VALIDATION_ERROR_IS_DUPLICATED` (field): `public const string VALIDATION_ERROR_IS_DUPLICATED = nameof(VALIDATION_ERROR_IS_DUPLICATED);`
- `VALIDATION_ERROR_NOT_FOUND` (field): `public const string VALIDATION_ERROR_NOT_FOUND = nameof(VALIDATION_ERROR_NOT_FOUND);`
- `VALIDATION_ERROR_MUST_BE_UNIQUE` (field): `public const string VALIDATION_ERROR_MUST_BE_UNIQUE = nameof(VALIDATION_ERROR_MUST_BE_UNIQUE);`
- `VALIDATION_ERROR_NOT_EXIST` (field): `public const string VALIDATION_ERROR_NOT_EXIST = nameof(VALIDATION_ERROR_NOT_EXIST);`
- `VALIDATION_ERROR_STRING_MAX_LENGTH` (field): `public const string VALIDATION_ERROR_STRING_MAX_LENGTH = nameof(VALIDATION_ERROR_STRING_MAX_LENGTH);`
- `VALIDATION_ERROR_STRING_MIN_LENGTH` (field): `public const string VALIDATION_ERROR_STRING_MIN_LENGTH = nameof(VALIDATION_ERROR_STRING_MIN_LENGTH);`
- `VALIDATION_ERROR_STRING_LENGTH_BETWEEN` (field): `public const string VALIDATION_ERROR_STRING_LENGTH_BETWEEN = nameof(VALIDATION_ERROR_STRING_LENGTH_BETWEEN);`
- `VALIDATION_ERROR_MAX_VALUE` (field): `public const string VALIDATION_ERROR_MAX_VALUE = nameof(VALIDATION_ERROR_MAX_VALUE);`
- `VALIDATION_ERROR_MIN_VALUE` (field): `public const string VALIDATION_ERROR_MIN_VALUE = nameof(VALIDATION_ERROR_MIN_VALUE);`
- `VALIDATION_ERROR_VALUE_BETWEEN` (field): `public const string VALIDATION_ERROR_VALUE_BETWEEN = nameof(VALIDATION_ERROR_VALUE_BETWEEN);`
- `VALIDATION_ERROR_NOT_EQUAL` (field): `public const string VALIDATION_ERROR_NOT_EQUAL = nameof(VALIDATION_ERROR_NOT_EQUAL);`
- `VALIDATION_ERROR_EQUAL` (field): `public const string VALIDATION_ERROR_EQUAL = nameof(VALIDATION_ERROR_EQUAL);`
- `VALIDATION_ERROR_GREATER_THAN` (field): `public const string VALIDATION_ERROR_GREATER_THAN = nameof(VALIDATION_ERROR_GREATER_THAN);`
- `VALIDATION_ERROR_LESS_THAN` (field): `public const string VALIDATION_ERROR_LESS_THAN = nameof(VALIDATION_ERROR_LESS_THAN);`
- `VALIDATION_ERROR_NOT_ACCESS` (field): `public const string VALIDATION_ERROR_NOT_ACCESS = nameof(VALIDATION_ERROR_NOT_ACCESS);`
- `VALIDATION_ERROR_NOT_AUTHENTICATED` (field): `public const string VALIDATION_ERROR_NOT_AUTHENTICATED = nameof(VALIDATION_ERROR_NOT_AUTHENTICATED);`
- `VALIDATION_ERROR_NOT_AUTHORIZED` (field): `public const string VALIDATION_ERROR_NOT_AUTHORIZED = nameof(VALIDATION_ERROR_NOT_AUTHORIZED);`
- `VALIDATION_ERROR_NOT_VALID` (field): `public const string VALIDATION_ERROR_NOT_VALID = nameof(VALIDATION_ERROR_NOT_VALID);`
- `VALIDATION_ERROR_MUST_BE` (field): `public const string VALIDATION_ERROR_MUST_BE = nameof(VALIDATION_ERROR_MUST_BE);`
- `VALIDATION_ERROR_MUST_NOT_BE` (field): `public const string VALIDATION_ERROR_MUST_NOT_BE = nameof(VALIDATION_ERROR_MUST_NOT_BE);`
- `VALIDATION_ERROR_MUST_HAVE` (field): `public const string VALIDATION_ERROR_MUST_HAVE = nameof(VALIDATION_ERROR_MUST_HAVE);`
- `VALIDATION_ERROR_MUST_HAVE_NOT` (field): `public const string VALIDATION_ERROR_MUST_HAVE_NOT = nameof(VALIDATION_ERROR_MUST_HAVE_NOT);`
- `VALIDATION_ERROR_FORMAT_INCORRECT` (field): `public const string VALIDATION_ERROR_FORMAT_INCORRECT = nameof(VALIDATION_ERROR_FORMAT_INCORRECT);`
- `NAME` (field): `public const string NAME = nameof(NAME);`
- `DISPLAY_NAME` (field): `public const string DISPLAY_NAME = nameof(DISPLAY_NAME);`
- `TITLE` (field): `public const string TITLE = nameof(TITLE);`
- `PRIMARY_KEY` (field): `public const string PRIMARY_KEY = nameof(PRIMARY_KEY);`
- `MESSAGE` (field): `public const string MESSAGE = nameof(MESSAGE);`
- `CHILD` (field): `public const string CHILD = nameof(CHILD);`
- `PARENT` (field): `public const string PARENT = nameof(PARENT);`
- `VALUE` (field): `public const string VALUE = nameof(VALUE);`

#### `Zamin.Utilities.Resources.Translators.TranslatorValues` (class)

کلاس «TranslatorValues» در namespace Zamin.Utilities.Resources.Translators. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین.

**اعضا (34):**

- `VALIDATION_ERROR_NOT_EMPTY` (field): `public const string VALIDATION_ERROR_NOT_EMPTY = "{0} باید مقدار داشته باشد.";`
- `VALIDATION_ERROR_NOT_NULL` (field): `public const string VALIDATION_ERROR_NOT_NULL = "{0} نباید نال باشد.";`
- `VALIDATION_ERROR_IS_REQUIRED` (field): `public const string VALIDATION_ERROR_IS_REQUIRED = "{0} اجباری است.";`
- `VALIDATION_ERROR_IS_DUPLICATED` (field): `public const string VALIDATION_ERROR_IS_DUPLICATED = "{0} تکراری است.";`
- `VALIDATION_ERROR_NOT_FOUND` (field): `public const string VALIDATION_ERROR_NOT_FOUND = "{0} یافت نشد.";`
- `VALIDATION_ERROR_MUST_BE_UNIQUE` (field): `public const string VALIDATION_ERROR_MUST_BE_UNIQUE = "{0} باید یکتا باشد";`
- `VALIDATION_ERROR_NOT_EXIST` (field): `public const string VALIDATION_ERROR_NOT_EXIST = "{0} وجود ندارد.";`
- `VALIDATION_ERROR_STRING_MAX_LENGTH` (field): `public const string VALIDATION_ERROR_STRING_MAX_LENGTH = "{0} باید حداکثر {1} کاراکتر باشد";`
- `VALIDATION_ERROR_MIN_STRING_LENGTH` (field): `public const string VALIDATION_ERROR_MIN_STRING_LENGTH = "{0} باید حداقل {1} کاراکتر باشد";`
- `VALIDATION_ERROR_STRING_LENGTH_BETWEEN` (field): `public const string VALIDATION_ERROR_STRING_LENGTH_BETWEEN = "{0} باید بین {2} و {1} کاراکتر باشد";`
- `VALIDATION_ERROR_MAX_VALUE` (field): `public const string VALIDATION_ERROR_MAX_VALUE = "مقدار {0} باید کوچکتر {1} باشد";`
- `VALIDATION_ERROR_MIN_VALUE` (field): `public const string VALIDATION_ERROR_MIN_VALUE = "مقدار {0} باید بزرگتر {1} باشد";`
- `VALIDATION_ERROR_NOT_EQUAL` (field): `public const string VALIDATION_ERROR_NOT_EQUAL = "{0} برابر  {1} نیست ";`
- `VALIDATION_ERROR_EQUAL` (field): `public const string VALIDATION_ERROR_EQUAL = "{0}باید برابر {1} باشد";`
- `VALIDATION_ERROR_GREATER_THAN` (field): `public const string VALIDATION_ERROR_GREATER_THAN = "{0}باید برابر {1} باشد";`
- `VALIDATION_ERROR_LESS_THAN` (field): `public const string VALIDATION_ERROR_LESS_THAN = "{0}باید برابر {1} باشد";`
- `VALIDATION_ERROR_VALUE_BETWEEN` (field): `public const string VALIDATION_ERROR_VALUE_BETWEEN = "{0} باید بین {2} و {1} باشد";`
- `VALIDATION_ERROR_NOT_ACCESS` (field): `public const string VALIDATION_ERROR_NOT_ACCESS = "شما به {0} دسترسی ندارید";`
- `VALIDATION_ERROR_NOT_AUTHENTICATED` (field): `public const string VALIDATION_ERROR_NOT_AUTHENTICATED = "شما احراظ هویت نشده اید.";`
- `VALIDATION_ERROR_NOT_AUTHORIZED` (field): `public const string VALIDATION_ERROR_NOT_AUTHORIZED = "دسترسی شما احراظ نشده است";`
- `VALIDATION_ERROR_NOT_VALID` (field): `public const string VALIDATION_ERROR_NOT_VALID = "مقدار {0} نامعتبر است.";`
- `VALIDATION_ERROR_MUST_BE` (field): `public const string VALIDATION_ERROR_MUST_BE = "{0} باید {1} باشد.";`
- `VALIDATION_ERROR_MUST_NOT_BE` (field): `public const string VALIDATION_ERROR_MUST_NOT_BE = "{0} نباید {1} باشد.";`
- `VALIDATION_ERROR_MUST_HAVE` (field): `public const string VALIDATION_ERROR_MUST_HAVE = "{0} باید {1} داشته باشد.";`
- `VALIDATION_ERROR_MUST_HAVE_NOT` (field): `public const string VALIDATION_ERROR_MUST_HAVE_NOT = "{0} نباید {1} داشته باشد.";`
- `VALIDATION_ERROR_FORMAT_INCORRECT` (field): `public const string VALIDATION_ERROR_FORMAT_INCORRECT = "فرمت {0} نا معتبر است.";`
- `NAME` (field): `public const string NAME = "نام";`
- `DISPLAY_NAME` (field): `public const string DISPLAY_NAME = "نام نمایشی";`
- `TITLE` (field): `public const string TITLE = "عنوان";`
- `PRIMARY_KEY` (field): `public const string PRIMARY_KEY = "کلید اصلی";`
- `MESSAGE` (field): `public const string MESSAGE = "متن پیام";`
- `CHILD` (field): `public const string CHILD = "فرزند";`
- `PARENT` (field): `public const string PARENT = "والد";`
- `VALUE` (field): `public const string VALUE = "مقداز";`

### Namespace: `Zamin.Utilities.ScalarRegistration.Options`

#### `Zamin.Utilities.ScalarRegistration.Options.ScalarOption` (class)

کلاس «ScalarOption» در namespace Zamin.Utilities.ScalarRegistration.Options. مدل تنظیمات قابل بایند شدن از configuration.

**اعضا (5):**

- `Enabled` (property): `public bool Enabled { get; set; }`
- `Name` (property): `public string Name { get; set; }`
- `Title` (property): `public string Title { get; set; }`
- `Version` (property): `public string Version { get; set; }`
- `Description` (property): `public string Description { get; set; }`

### Namespace: `Zamin.Utilities.SerilogRegistration.Enrichers`

#### `Zamin.Utilities.SerilogRegistration.Enrichers.ZaminApplicaitonEnricher` (class)

کلاس «ZaminApplicaitonEnricher» در namespace Zamin.Utilities.SerilogRegistration.Enrichers. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین. ارث‌بری/پیاده‌سازی: ILogEventEnricher. وابستگی‌های سازنده (DI): IOptions<SerilogApplicationEnricherOptions> options. مرتبط: ILog…

- **Base:** `ILogEventEnricher`

**اعضا (2):**

- `.ctor` (constructor): `public ZaminApplicaitonEnricher(IOptions<SerilogApplicationEnricherOptions> options)`
- `Enrich` (method): `public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)`

#### `Zamin.Utilities.SerilogRegistration.Enrichers.ZaminUserInfoEnricher` (class)

کلاس «ZaminUserInfoEnricher» در namespace Zamin.Utilities.SerilogRegistration.Enrichers. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین. ارث‌بری/پیاده‌سازی: ILogEventEnricher. وابستگی‌های سازنده (DI): IUserInfoService userInfoService. مرتبط: ILogEventEnricher | DI: IU…

- **Base:** `ILogEventEnricher`

**اعضا (2):**

- `.ctor` (constructor): `public ZaminUserInfoEnricher(IUserInfoService userInfoService)`
- `Enrich` (method): `public void Enrich(LogEvent logEvent, ILogEventPropertyFactory factory)`

### Namespace: `Zamin.Utilities.SerilogRegistration.Extensions`

#### `Zamin.Utilities.SerilogRegistration.Extensions.SerilogExtensions` (class)

کلاس «SerilogExtensions» در namespace Zamin.Utilities.SerilogRegistration.Extensions. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

**اعضا (1):**

- `RunWithSerilogExceptionHandling` (method): `public static void RunWithSerilogExceptionHandling(Action action, string startUpMessage = "Starting up", string exceptionMessage = "Unhandled exception", string shutdownMessage = "Shutdown complete")`

### Namespace: `Zamin.Utilities.SerilogRegistration.Options`

#### `Zamin.Utilities.SerilogRegistration.Options.SerilogApplicationEnricherOptions` (class)

کلاس «SerilogApplicationEnricherOptions» در namespace Zamin.Utilities.SerilogRegistration.Options. مدل تنظیمات قابل بایند شدن از configuration.

**اعضا (4):**

- `ApplicationName` (property): `public string ApplicationName { get; set; }`
- `ServiceName` (property): `public string ServiceName { get; set; }`
- `ServiceVersion` (property): `public string ServiceVersion { get; set; }`
- `ServiceId` (property): `public string ServiceId { get; set; }`

### Namespace: `Zamin.Utilities.Sinks.Elasticsearch`

#### `Zamin.Utilities.Sinks.Elasticsearch.LoggerConfigurationZaminElasticsearchExtensions` (class)

کلاس «LoggerConfigurationZaminElasticsearchExtensions» در namespace Zamin.Utilities.Sinks.Elasticsearch. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

**اعضا (2):**

- `ZaminElasticsearch` (method): `public static LoggerConfiguration ZaminElasticsearch(this LoggerSinkConfiguration loggerSinkConfiguration, ElasticsearchSinkOptions options = null)`
- `ZaminElasticsearch` (method): `public static LoggerConfiguration ZaminElasticsearch(this LoggerSinkConfiguration loggerSinkConfiguration, // …`

### Namespace: `Zamin.Utilities.SoftwarePartDetector.Attributes`

#### `Zamin.Utilities.SoftwarePartDetector.Attributes.SoftwarePartControllerOptionAttribute` (class)

کلاس «SoftwarePartControllerOptionAttribute» در namespace Zamin.Utilities.SoftwarePartDetector.Attributes. کنترلر endpoint برای دریافت درخواست HTTP و ارجاع به لایه اپلیکیشن. ارث‌بری/پیاده‌سازی: Attribute. وابستگی‌های سازنده (DI): string? service, string? module. مرتبط: Attribute…

- **Base:** `Attribute`

**اعضا (3):**

- `.ctor` (constructor): `public SoftwarePartControllerOptionAttribute(string? service , string? module = null)`
- `Module` (property): `public string? Module => ...`
- `Service` (property): `public string? Service => ...`

### Namespace: `Zamin.Utilities.SoftwarePartDetector.Authentications`

#### `Zamin.Utilities.SoftwarePartDetector.Authentications.ISoftwarePartAuthentication` (interface)

قرارداد (اینترفیس) «ISoftwarePartAuthentication» در namespace Zamin.Utilities.SoftwarePartDetector.Authentications. قرارداد رفتار برای مصرف‌کنندگان و پیاده‌سازی‌های جایگزین.

**اعضا (1):**

- `LoginAsync` (method): `Task<TokenResponse> LoginAsync()`

#### `Zamin.Utilities.SoftwarePartDetector.Authentications.SoftwarePartAuthentication` (class)

کلاس «SoftwarePartAuthentication» در namespace Zamin.Utilities.SoftwarePartDetector.Authentications. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین. ارث‌بری/پیاده‌سازی: ISoftwarePartAuthentication. وابستگی‌های سازنده (DI): HttpClient httpClient, IOptions<SoftwarePartD…

- **Base:** `ISoftwarePartAuthentication`

**اعضا (2):**

- `.ctor` (constructor): `public SoftwarePartAuthentication(HttpClient httpClient, IOptions<SoftwarePartDetectorOptions> softwarePartDetectorOption)`
- `LoginAsync` (method): `public async Task<TokenResponse> LoginAsync()`

### Namespace: `Zamin.Utilities.SoftwarePartDetector.DataModel`

#### `Zamin.Utilities.SoftwarePartDetector.DataModel.SoftwarePart` (class)

کلاس «SoftwarePart» در namespace Zamin.Utilities.SoftwarePartDetector.DataModel. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین.

**اعضا (3):**

- `Name` (property): `public string Name { get; set; }`
- `SoftwarePartType` (property): `public SoftwarePartType SoftwarePartType { get; set; }`
- `Children` (property): `public List<SoftwarePart> Children { get; set; }`

#### `Zamin.Utilities.SoftwarePartDetector.DataModel.SoftwarePartAction` (class)

کلاس «SoftwarePartAction» در namespace Zamin.Utilities.SoftwarePartDetector.DataModel. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین.

**اعضا (2):**

- `Name` (property): `public string Name { get; set; }`
- `ApplicationPartType` (property): `public SoftwarePartType ApplicationPartType { get; set; }`

#### `Zamin.Utilities.SoftwarePartDetector.DataModel.SoftwarePartController` (class)

کلاس «SoftwarePartController» در namespace Zamin.Utilities.SoftwarePartDetector.DataModel. کنترلر endpoint برای دریافت درخواست HTTP و ارجاع به لایه اپلیکیشن.

**اعضا (5):**

- `Module` (property): `public string? Module { get; set; }`
- `Service` (property): `public string? Service { get; set; }`
- `Name` (property): `public string Name { get; set; }`
- `ApplicationPartType` (property): `public SoftwarePartType ApplicationPartType { get; set; }`
- `Actions` (property): `public List<SoftwarePartAction> Actions { get; set; }`

#### `Zamin.Utilities.SoftwarePartDetector.DataModel.SoftwarePartType` (enum)

شمارشی (enum) «SoftwarePartType» در namespace Zamin.Utilities.SoftwarePartDetector.DataModel. تعریف enum عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین.

**اعضا (6):**

- `Other` (enum_member): `Other = 0`
- `Sample` (enum_member): `Sample = 1`
- `Module` (enum_member): `Module = 2`
- `Service` (enum_member): `Service = 3`
- `Controller` (enum_member): `Controller = 4`
- `Action` (enum_member): `Action = 5`

### Namespace: `Zamin.Utilities.SoftwarePartDetector`

#### `Zamin.Utilities.SoftwarePartDetector.ControllersAndActionDetector` (class)

کلاس «ControllersAndActionDetector» در namespace Zamin.Utilities.SoftwarePartDetector. کنترلر endpoint برای دریافت درخواست HTTP و ارجاع به لایه اپلیکیشن. وابستگی‌های سازنده (DI): IActionDescriptorCollectionProvider actionDescriptorCollectionProvider. مرتبط: DI: IActionDescriptor…

**اعضا (2):**

- `.ctor` (constructor): `public ControllersAndActionDetector(IActionDescriptorCollectionProvider actionDescriptorCollectionProvider)`
- `Detect` (method): `public Task<List<SoftwarePartController>> Detect()`

#### `Zamin.Utilities.SoftwarePartDetector.SoftwarePartDetector` (class)

کلاس «SoftwarePartDetector» در namespace Zamin.Utilities.SoftwarePartDetector. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین. وابستگی‌های سازنده (DI): ControllersAndActionDetector controllersAndActionDetector. مرتبط: DI: ControllersAndActionDetector controllersAndAct…

**اعضا (4):**

- `.ctor` (constructor): `public SoftwarePartDetector(ControllersAndActionDetector controllersAndActionDetector)`
- `Detect` (method): `public async Task<SoftwarePart> Detect(string softwareName)`
- `Detect` (method): `public async Task<SoftwarePart> Detect(string softwareName, string moduleName)`
- `Detect` (method): `public async Task<SoftwarePart> Detect(string softwareName, string moduleName, string serviceName)`

### Namespace: `Zamin.Utilities.SoftwarePartDetector.Options`

#### `Zamin.Utilities.SoftwarePartDetector.Options.OAuthOption` (class)

کلاس «OAuthOption» در namespace Zamin.Utilities.SoftwarePartDetector.Options. مدل تنظیمات قابل بایند شدن از configuration.

**اعضا (5):**

- `Enabled` (property): `public bool Enabled { get; set; }`
- `ClientId` (property): `public string ClientId { get; set; }`
- `ClientSecret` (property): `public string ClientSecret { get; set; }`
- `Authority` (property): `public string Authority { get; set; }`
- `Scopes` (property): `public string[] Scopes { get; set; }`

#### `Zamin.Utilities.SoftwarePartDetector.Options.SoftwarePartDetectorOptions` (class)

کلاس «SoftwarePartDetectorOptions» در namespace Zamin.Utilities.SoftwarePartDetector.Options. مدل تنظیمات قابل بایند شدن از configuration.

**اعضا (7):**

- `ApplicationName` (property): `public string ApplicationName { get; set; }`
- `ModuleName` (property): `public string ModuleName { get; set; }`
- `ServiceName` (property): `public string ServiceName { get; set; }`
- `DestinationServiceBaseAddress` (property): `public string DestinationServiceBaseAddress { get; set; }`
- `DestinationServicePath` (property): `public string DestinationServicePath { get; set; }`
- `FakeSSL` (property): `public bool FakeSSL { get; set; }`
- `OAuth` (property): `public OAuthOption OAuth { get; set; }`

### Namespace: `Zamin.Utilities.SoftwarePartDetector.Publishers`

#### `Zamin.Utilities.SoftwarePartDetector.Publishers.ISoftwarePartPublisher` (interface)

قرارداد (اینترفیس) «ISoftwarePartPublisher» در namespace Zamin.Utilities.SoftwarePartDetector.Publishers. قرارداد رفتار برای مصرف‌کنندگان و پیاده‌سازی‌های جایگزین.

**اعضا (1):**

- `PublishAsync` (method): `Task PublishAsync(SoftwarePart softwarePart)`

#### `Zamin.Utilities.SoftwarePartDetector.Publishers.SoftwarePartWebPublisher` (class)

کلاس «SoftwarePartWebPublisher» در namespace Zamin.Utilities.SoftwarePartDetector.Publishers. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین. ارث‌بری/پیاده‌سازی: ISoftwarePartPublisher. وابستگی‌های سازنده (DI): HttpClient httpClient, IOptions<SoftwarePartDetectorOptio…

- **Base:** `ISoftwarePartPublisher`

**اعضا (2):**

- `.ctor` (constructor): `public SoftwarePartWebPublisher(HttpClient httpClient, // …`
- `PublishAsync` (method): `public async Task PublishAsync(SoftwarePart softwarePart)`

### Namespace: `Zamin.Utilities.SoftwarePartDetector.Services`

#### `Zamin.Utilities.SoftwarePartDetector.Services.SoftwarePartDetectorService` (class)

کلاس «SoftwarePartDetectorService» در namespace Zamin.Utilities.SoftwarePartDetector.Services. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین. وابستگی‌های سازنده (DI): SoftwarePartDetector softwarePartDetector, ISoftwarePartPublisher partWebPublisher, IOptions<Softwar…

**اعضا (2):**

- `.ctor` (constructor): `public SoftwarePartDetectorService(SoftwarePartDetector softwarePartDetector, ISoftwarePartPublisher partWebPublisher, IOptions<SoftwarePartDetectorOptions> softwarePartDetectorOption)`
- `Run` (method): `public async Task Run()`

---

## Patterns — الگوهای صحیح استفاده

قبل از نوشتن کد مبتنی بر زمین، Recipe مرتبط را بخوانید. الگوی ترکیب (composition) بر حدس زدن از روی امضا اولویت دارد.

### Dependency Injection و bootstrap

منبع: نمونه‌های کاربردی مستندشده و فایل‌های بخش Patterns همین فایل. هیچ API اختراع‌شده‌ای اینجا نیست.

### Recipe: Host bootstrap با Serilog {#recipe-host-bootstrap}

**توضیح:** هاست‌های اپلیکیشن startup را داخل `SerilogExtensions.RunWithSerilogExceptionHandling` می‌پیچند، سپس configuration، `AddZaminSerilog`، ثبت سرویس‌ها و pipeline را زنجیره می‌کنند. همین شکل برای چند نوع هاست (API و Worker) قابل اعمال است.

**کد نمونه:**

```csharp
// src/Endpoints/API/Program.cs
using MyApp.Endpoints.DependencyInjection;
using Zamin.Extensions.DependencyInjection;
using Zamin.Utilities.SerilogRegistration.Extensions;

SerilogExtensions.RunWithSerilogExceptionHandling(() =>
{
    var builder = WebApplication.CreateBuilder(args);
    var app = builder
        .AddConfiguration()
        .AddZaminSerilog(o =>
        {
            o.ApplicationName = builder.Configuration.GetValue<string>("Global:ApplicationName");
            o.ServiceId = builder.Configuration.GetValue<string>("Global:ServiceId");
            o.ServiceName = builder.Configuration.GetValue<string>("Global:ServiceName");
            o.ServiceVersion = builder.Configuration.GetValue<string>("Global:ServiceVersion");
        })
        .ConfigureServices()
        .ConfigurePipeline();
    app.Run();
});
```

**نکات مهم:**

- نقطه ورود مشاهده‌شده: `SerilogExtensions.RunWithSerilogExceptionHandling`.
- بعد از build، سرویس‌های post-start مثل SoftwarePartDetector اجرا می‌شوند (بخش‌های بعدی).

### Recipe: AddZaminApiCore و decoratorهای dispatcher {#recipe-add-zamin-api-core}

**توضیح:** قبل از `AddZaminApiCore("Zamin", "MyApp")` اپلیکیشن decoratorهای لاگ‌گذاری خودش را برای `CommandDispatcherDecorator` / `QueryDispatcherDecorator` ثبت می‌کند. `AddZaminApiCore` اسکن اسمبلی برای handlerها و lifetime markerها را انجام می‌دهد.

**کد نمونه:**

```csharp
// HostingExtensions.ConfigureServices
builder.Services.AddTransient<CommandDispatcherDecorator, LoggingCommandDispatcherDecorator>();
builder.Services.AddTransient<QueryDispatcherDecorator, LoggingQueryDispatcherDecorator>();
builder.Services.AddZaminApiCore("Zamin", "MyApp");
```

**نکات مهم:**

- ترتیب مشاهده‌شده: ثبت decoratorها → سپس `AddZaminApiCore`.
- handlerها دستی `new` نمی‌شوند؛ از طریق اسکن DI ساخته می‌شوند.

### Recipe: Lifetime markers {#recipe-lifetime-markers}

**توضیح:** اینترفیس‌های `ITransientLifetime` / `IScopeLifetime` / `ISingletoneLifetime` روی قراردادهای اپلیکیشن برای کشف lifetime توسط `AddZaminApiCore` استفاده می‌شوند.

**Types in this pattern:** `ITransientLifetime`, `IScopeLifetime`, `ISingletoneLifetime`.

**کد نمونه:**

```csharp
// src/Contracts/Services/ISampleAppService.cs
public interface ISampleAppService : ITransientLifetime
```

**نکات مهم:**

- املای `ISingletoneLifetime` در API زمین همین‌گونه است (طبق استخراج).

### Recipe: Distributed cache (Redis / SQL) {#recipe-distributed-cache}

**توضیح:** اپلیکیشن با کلید `DistributedCacheActive` بین Redis و SQL سوییچ می‌کند و یکی از `AddZaminRedisDistributedCache` یا `AddZaminSqlDistributedCache` را صدا می‌زند.

**کد نمونه:**

```csharp
// excerpt — ConfigureServices (API)
if (builder.Configuration["DistributedCacheActive"] == nameof(DistributedRedisCacheOptions))
    builder.Services.AddZaminRedisDistributedCache(builder.Configuration, nameof(DistributedRedisCacheOptions));
else if (builder.Configuration["DistributedCacheActive"] == nameof(DistributedSqlCacheOptions))
    builder.Services.AddZaminSqlDistributedCache(builder.Configuration, nameof(DistributedSqlCacheOptions));
else
    throw new ArgumentException("There is no valid DistributedCacheActive on appsettings.");
```

**نکات مهم:**

- Options مربوطه: `DistributedRedisCacheOptions` / `DistributedSqlCacheOptions`.
- مصرف‌کننده رایج: `ICacheAdapter` (نگاه کنید به Recipeهای مشترک در همین فایل).

### Recipe: Serializer و AutoMapper {#recipe-serializer-mapper}

**توضیح:** در هاست API ثبت‌های `AddZaminMicrosoftSerializer` و `AddZaminAutoMapperProfiles(builder.Configuration, "AutoMapper")` مشاهده شده است.

**کد نمونه:**

```csharp
builder.Services.AddZaminMicrosoftSerializer();
builder.Services.AddZaminAutoMapperProfiles(builder.Configuration, "AutoMapper");
```

**نکات مهم:**

- اینترفیس مصرفی serializer: `IJsonSerializer` (Abstractions).

### Recipe: Parrot translator registration {#recipe-parrot-translator}

**توضیح:** `AddZaminParrotTranslator` در ConfigureServices؛ بعد از build، `ParrotTranslatorInitializer.Initialize` با options اجرا می‌شود.

**کد نمونه:**

```csharp
builder.Services.AddZaminParrotTranslator(builder.Configuration, "ParrotTranslator");
// pipeline / post-build:
var options = app.Services.GetService<IOptions<ParrotTranslatorOptions>>()?.Value
    ?? throw new NullReferenceException();
ParrotTranslatorInitializer.Initialize(options.ConnectionString, options.SchemaName, options.TableName);
```

**نکات مهم:**

- Options: `ParrotTranslatorOptions`؛ سرویس: `ParrotTranslator` / قرارداد `ITranslator`.

### Recipe: User info registration {#recipe-user-info-registration}

**توضیح:** اپلیکیشن `AddAppUserInfoService(builder.Configuration, "UserInfo")` را صدا می‌زند (extension سمت اپلیکیشن روی قراردادهای UsersManagement زمین).

**کد نمونه:**

```csharp
builder.Services.AddAppUserInfoService(builder.Configuration, "UserInfo");
```

**نکات مهم:**

- Options مرتبط زمین: `UserManagementOptions` (مشاهده در بخش Patterns همین فایل).
- مصرف: `IUserInfoService` و مسیر `ZaminServices.UserInfoService`.

### Recipe: API authentication + Swagger {#recipe-api-authentication}

**توضیح:** پس از DbContext و سرویس‌های هسته، `AddZaminSwagger` و `AddZaminApiAuthentication` با sectionهای تنظیمات ثبت می‌شوند.

**کد نمونه:**

```csharp
builder.Services.AddZaminSwagger(builder.Configuration, "Swagger");
builder.Services.AddZaminApiAuthentication(builder.Configuration, "ApiAuthentication");
```

**نکات مهم:**

- Options مشاهده‌شده: `ApiAuthenticationOption`, `ProviderOption`, `TokenType`.

### Recipe: SoftwarePartDetector {#recipe-software-part-detector}

**توضیح:** ثبت با `AddSoftwarePartDetector`؛ بعد از pipeline، `SoftwarePartDetectorService.Run()` فراخوانی می‌شود.

**کد نمونه:**

```csharp
builder.Services.AddSoftwarePartDetector(builder.Configuration, "SoftwarePart");
// after MapControllers:
app.Services.GetService<SoftwarePartDetectorService>()?.Run();
```

**نکات مهم:**

- در inventory، نام‌های DataModel ممکن است با تایپ‌های دامنه‌ای اپلیکیشن تداخل داشته باشند؛ جزئیات در بخش «تایپ‌های بدون نمونه‌ی عملی» همین فایل آمده است.

### Recipe: Worker messaging DAL {#recipe-worker-messaging-dal}

**توضیح:** WorkerService به‌صورت فعال `AddZaminPollingPublisherDalSql` و `AddZaminMessageInboxDalSql` را ثبت می‌کند. ثبت‌های application-level برای RabbitMQ / PollingPublisher / MessageInbox در کد مشاهده‌شده comment شده‌اند.

**کد نمونه:**

مستندات کافی موجود نیست — snippet کامل Worker در منابع الگو موجود نیست.

**نکات مهم:**

- Pipeline ورکر `UseZaminApiExceptionHandler` را صدا نمی‌زند (مشاهده‌شده).

### ترتیب کلی ثبت سرویس در API (مشاهده‌شده)

1. Decoratorهای dispatcher اپلیکیشن
2. `AddZaminApiCore`
3. User-info / translator / software-part / serializer / AutoMapper / cache
4. EF Command/Query DbContext + interceptorهای زمین
5. Auth + Swagger
6. Pipeline: `UseZaminApiExceptionHandler` → auth → `MapControllers`
7. Post-build: SoftwarePartDetector + Parrot initializer

### Common recipes (CQRS، دامنه، Repository، Controller)

این فایل بازنویسی مرتب‌شده‌ی `general-recipes.md` و `patterns/by-namespace/*.md` است. فقط الگوهای صحیح استفاده‌ی مستندشده آمده‌اند.

### فهرست Recipeها

- [CommandHandler و مسیر Command](#recipe-command-handler)
- [QueryHandler و مسیر Query](#recipe-query-handler)
- [ICommandDispatcher از طریق BaseController](#recipe-command-dispatcher)
- [IQueryDispatcher از طریق BaseController](#recipe-query-dispatcher)
- [قراردادهای ICommand / CommandResult](#recipe-command-contracts)
- [قراردادهای IQuery / PageQuery / PagedData](#recipe-query-contracts)
- [ApplicationServiceStatus](#recipe-application-service-status)
- [AggregateRoot و Entity](#recipe-aggregate-entity)
- [BaseValueObject و BusinessId](#recipe-value-objects)
- [Toolkit value objects (Title, …)](#recipe-toolkit-value-objects)
- [استثناهای دامنه](#recipe-domain-exceptions)
- [ICommandRepository و BaseCommandRepository](#recipe-command-repository)
- [IQueryRepository و BaseQueryRepository](#recipe-query-repository)
- [BaseOutboxCommandDbContext](#recipe-outbox-dbcontext)
- [Interceptorهای EF فرمان](#recipe-ef-interceptors)
- [BaseController](#recipe-base-controller)
- [HttpContextExtensions](#recipe-http-context-extensions)
- [Model binding extensions](#recipe-model-binding)
- [ZaminServices در Handlerها](#recipe-zamin-services)
- [IUserInfoService](#recipe-user-info)
- [ITranslator](#recipe-translator)
- [TranslatorKeys / TranslatorValues](#recipe-translator-keys)
- [ICacheAdapter](#recipe-cache-adapter)

### Recipe: برش عمودی Command (از HTTP تا Commit) {#recipe-vertical-command}

**توضیح:** جریان تکراری پیشنهادی: DTO با `ICommand`/`ICommand<TData>` → `CommandHandler` → Aggregate + `ICommandRepository` → `CommitAsync` → `CommandResult` از طریق `BaseController`.

**کد نمونه:**

```csharp
// Handler — src/Application/Samples/Commands/Create/SampleCreateHandler.cs
public class SampleCreateHandler(
    ZaminServices zaminServices,
    ISampleCommandRepository sampleCommandRepository,
    ISampleValidationService sampleValidationService)
    : CommandHandler<SampleCreateCommand, Guid>(zaminServices)
{
    public override async Task<CommandResult<Guid>> Handle(SampleCreateCommand command)
    {
        await sampleValidationService.EnsureUniqueNameAsync((SampleName)command.Name);

        Sample entity = Sample.Create(command.ToParameter());

        await sampleCommandRepository.InsertAsync(entity);

        await sampleCommandRepository.CommitAsync();

        return await OkAsync(entity.BusinessId.Value);
    }
}
```

```csharp
// Controller — src/Endpoints/API/Features/Samples/SampleController.cs
public sealed class SampleController : BaseController
{
    [HttpPost]
    [ProducesResponseType(typeof(Guid), 201)]
    public async Task<IActionResult> Create([FromBody] SampleCreateCommand command)
        => await Create<SampleCreateCommand, Guid>(command);

    [HttpPost]
    public async Task<IActionResult> Update([FromBody] SampleUpdateCommand command)
        => await Edit(command);

    [HttpPost]
    public async Task<IActionResult> Delete([FromBody] SampleDeleteCommand command)
        => await base.Delete(command);
}
```

**نکات مهم:**

- ترتیب call: `HTTP` → `BaseController` → `ICommandDispatcher` (+ decorator لاگ اپلیکیشن) → `Handle` → repository → `CommitAsync`.
- Exception دامنه معمولاً bubble می‌شود مگر handler خودش catch کند.

### Recipe: برش عمودی Query {#recipe-vertical-query}

**توضیح:** `IQuery<T>` → `QueryHandler` → `IQueryRepository.ExecuteAsync` → `QueryResult` → `BaseController.Query`.

**کد نمونه:**

```csharp
// SampleGetPagedFilterQueryHandler.cs
public sealed class SampleGetPagedFilterQueryHandler(
    ZaminServices zaminServices,
    ISampleQueryRepository queryRepository)
    : QueryHandler<SampleGetPagedFilterQuery, PagedData<SampleListItemDto>>(zaminServices)
{
    public override async Task<QueryResult<PagedData<SampleListItemDto>>> Handle(SampleGetPagedFilterQuery query)
    {
        var queryResult = await queryRepository.ExecuteAsync(query);
        return Result(queryResult);
    }
}
```

**نکات مهم:**

- مسیر query معمولاً `CommitAsync` ندارد.

### Recipe: CommandHandler و مسیر Command {#recipe-command-handler}

**توضیح:** Handlerها از `CommandHandler<TCommand>` / `CommandHandler<TCommand,TData>` ارث می‌برند، `ZaminServices` را به base می‌دهند و از repository/domain استفاده می‌کنند.

**Types documented in usage patterns:** `CommandHandler<TCommand>`, `CommandHandler<TCommand,TData>`, `CommandDispatcherDecorator`, `CommandDispatcher` (via decorator chain / DI).

**کد نمونه:**

```csharp
// src/Endpoints/API/DependencyInjection/HostingExtensions.cs
builder.Services.AddTransient<CommandDispatcherDecorator, LoggingCommandDispatcherDecorator>();
builder.Services.AddTransient<QueryDispatcherDecorator, LoggingQueryDispatcherDecorator>();
builder.Services.AddZaminApiCore("Zamin", "MyApp");
```

```csharp
// src/Application/Samples/Commands/Create/SampleCreateHandler.cs
public class SampleCreateHandler(
    ZaminServices zaminServices,
    ISampleCommandRepository sampleCommandRepository,
    ISampleValidationService sampleValidationService)
    : CommandHandler<SampleCreateCommand, Guid>(zaminServices)
{
    public override async Task<CommandResult<Guid>> Handle(SampleCreateCommand command)
    {
        await sampleValidationService.EnsureUniqueNameAsync((SampleName)command.Name);
        Sample entity = Sample.Create(command.ToParameter());
        await sampleCommandRepository.InsertAsync(entity);
        await sampleCommandRepository.CommitAsync();
        return await OkAsync(entity.BusinessId.Value);
    }
}
```

**نکات مهم:**

- Handlers are **not** new'ed manually; discovered by `AddZaminApiCore("Zamin", "MyApp")`.
- The application registers a custom decorator: `AddTransient<CommandDispatcherDecorator, LoggingCommandDispatcherDecorator>()` before `AddZaminApiCore`.
- Primary ctor always receives `ZaminServices` first (passed to base `CommandHandler`).
- Additional deps: command repositories, domain validation services, optional infra services.
- Return helpers from base: `Ok()`, `OkAsync(T)`, `Result(...)`.

- Namespace مرتبط: `Zamin.Core.ApplicationServices.Commands`

### Recipe: QueryHandler و مسیر Query {#recipe-query-handler}

**توضیح:** Handler کوئری از `QueryHandler<TQuery,TData>` ارث می‌برد و معمولاً با query repository کار می‌کند.

**Types in this pattern:** `QueryHandler<TQuery,TData>`, `QueryDispatcherDecorator`, `QueryDispatcher` (via DI).

**کد نمونه:**

```csharp
// SampleGetPagedFilterQueryHandler.cs
public sealed class SampleGetPagedFilterQueryHandler(
    ZaminServices zaminServices,
    ISampleQueryRepository queryRepository)
    : QueryHandler<SampleGetPagedFilterQuery, PagedData<SampleListItemDto>>(zaminServices)
{
    public override async Task<QueryResult<PagedData<SampleListItemDto>>> Handle(SampleGetPagedFilterQuery query)
    {
        var queryResult = await queryRepository.ExecuteAsync(query);
        return Result(queryResult);
    }
}
```

**نکات مهم:**

- جزئیات در بخش API Reference برای `Zamin.Core.ApplicationServices.Queries`.

- Namespace مرتبط: `Zamin.Core.ApplicationServices.Queries`

### Recipe: ICommandDispatcher از طریق BaseController {#recipe-command-dispatcher}

**توضیح:** کنترلرها مستقیم dispatcher را صدا نمی‌زنند؛ از helperهای BaseController استفاده می‌شود که به ICommandDispatcher می‌رسد.

**Types in this pattern:** `ICommandDispatcher`.

**کد نمونه:**

```csharp
// src/Endpoints/API/Features/Samples/SampleController.cs
public sealed class SampleController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] SampleCreateCommand command)
        => await Create<SampleCreateCommand, Guid>(command);

    [HttpGet]
    public async Task<IActionResult> GetDetail([FromQuery] SampleGetDetailQuery query)
        => await Query<SampleGetDetailQuery, SampleDetailDto?>(query);
}
```

**نکات مهم:**

- جزئیات در بخش API Reference برای `Zamin.Core.Contracts.ApplicationServices.Commands`.

- Namespace مرتبط: `Zamin.Core.Contracts.ApplicationServices.Commands`

### Recipe: IQueryDispatcher از طریق BaseController {#recipe-query-dispatcher}

**توضیح:** مسیر query مشابه command است با helper `Query<TQuery,TData>`.

**Types in this pattern:** `IQueryDispatcher`.

**کد نمونه:**

```csharp
// src/3.Endpoints/API/Features/Users/UserController.cs
public async Task<IActionResult> GetPagedFilter([FromQuery] SampleGetPagedFilterQuery query)
    => await Query<SampleGetPagedFilterQuery, PagedData<SampleListItemDto>>(query);
```

**نکات مهم:**

- جزئیات در بخش API Reference برای `Zamin.Core.Contracts.ApplicationServices.Queries`.

- Namespace مرتبط: `Zamin.Core.Contracts.ApplicationServices.Queries`

### Recipe: قراردادهای ICommand / CommandResult {#recipe-command-contracts}

**توضیح:** DTO فرمان: `ICommand` یا `ICommand<TData>`؛ خروجی handler از نوع `CommandResult` / `CommandResult<TData>`.

**Types in this pattern:** `ICommand`, `ICommand<TData>`, `CommandResult`, `CommandResult<TData>`.

**کد نمونه:**

```csharp
// src/1.Core/RequestResponse/Samples/Commands/Create/SampleCreateCommand.cs
public sealed record SampleCreateCommand : ICommand<Guid>
{
    public string Name { get; set; } = default!;
    public string? DisplayName { get; set; }
    public string? Description { get; set; }
}
```

```csharp
// src/Application/Samples/Commands/Create/SampleCreateHandler.cs
public class SampleCreateHandler(
    ZaminServices zaminServices,
    ISampleCommandRepository sampleCommandRepository,
    ISampleValidationService sampleValidationService)
    : CommandHandler<SampleCreateCommand, Guid>(zaminServices)
{
    public override async Task<CommandResult<Guid>> Handle(SampleCreateCommand command)
    {
        await sampleValidationService.EnsureUniqueNameAsync((SampleName)command.Name);
        Sample entity = Sample.Create(command.ToParameter());
        await sampleCommandRepository.InsertAsync(entity);
        await sampleCommandRepository.CommitAsync();
        return await OkAsync(entity.BusinessId.Value);
    }
}
```

**نکات مهم:**

- جزئیات در بخش API Reference برای `Zamin.Core.RequestResponse.Commands`.

- Namespace مرتبط: `Zamin.Core.RequestResponse.Commands`

### Recipe: قراردادهای IQuery / PageQuery / PagedData {#recipe-query-contracts}

**توضیح:** کوئری‌ها `IQuery<TData>` هستند؛ صفحه‌بندی با `PageQuery` و `PagedData` مشاهده شده است.

**Types in this pattern:** `IQuery<TData>`, `QueryResult<TData>`, `PagedData<T>`, `PageQuery<TData>`.

**کد نمونه:**

```csharp
// SampleGetPagedFilterQueryHandler.cs
public sealed class SampleGetPagedFilterQueryHandler(
    ZaminServices zaminServices,
    ISampleQueryRepository queryRepository)
    : QueryHandler<SampleGetPagedFilterQuery, PagedData<SampleListItemDto>>(zaminServices)
{
    public override async Task<QueryResult<PagedData<SampleListItemDto>>> Handle(SampleGetPagedFilterQuery query)
    {
        var queryResult = await queryRepository.ExecuteAsync(query);
        return Result(queryResult);
    }
}
```

**نکات مهم:**

- جزئیات در بخش API Reference برای `Zamin.Core.RequestResponse.Queries`.

- Namespace مرتبط: `Zamin.Core.RequestResponse.Queries`

### Recipe: ApplicationServiceStatus {#recipe-application-service-status}

**توضیح:** وضعیت نتیجه سرویس اپلیکیشن در نتایج command/query.

**Types in this pattern:** `ApplicationServiceStatus`.

**کد نمونه:**

```csharp
// src/1.Core/ApplicationService/Common/Decorator/LoggingQueryDispatcherDecorator.cs
activity?.SetTag("app.status", result.Status.ToString());
AppBusinessMetrics.QueryExecuted(queryName, result.Status.ToString());
// ...
case ApplicationServiceStatus.Ok:
    logType = LogType.UserActivity;
    break;
case ApplicationServiceStatus.Exception:
    logType = LogType.ErrorManagement;
    break;
```

**نکات مهم:**

- جزئیات در بخش API Reference برای `Zamin.Core.RequestResponse.Common`.

- Namespace مرتبط: `Zamin.Core.RequestResponse.Common`

### Recipe: AggregateRoot و Entity {#recipe-aggregate-entity}

**توضیح:** Aggregateها از `AggregateRoot` / `AggregateRoot<TId>` و موجودیت‌های وابسته از `Entity` / `Entity<TId>` ارث می‌برند.

**Types in this pattern:** `AggregateRoot`, `AggregateRoot<TId>`, `Entity`, `Entity<TId>`.

**کد نمونه:**

```csharp
// src/Domain/Samples/Entities/Sample.cs
public sealed class Sample : AggregateRoot<int>
{
    private Sample() { }

    private Sample(SampleCreateParameter parameter) : this()
    {
        Name = parameter.Name;
        DisplayName = parameter.DisplayName;
        Description = parameter.Description;
        Protected = false;
        Primary = parameter.Primary;
    }

    public static Sample Create(SampleCreateParameter parameter) => new(parameter);

    public void ChangeProtectedStatus(bool status)
    {
        if (Primary.Equals(true))
        {
            throw new InvalidEntityStateException("Cannot modify primary sample", Name.Value);
        }
        Protected = status;
    }
}
```

**نکات مهم:**

- Aggregates: `public sealed class Sample : AggregateRoot<int>`
- Child/query-side entities often `Entity<long>`
- Private parameterless ctor for ORM; public factory `Create`.

- Namespace مرتبط: `Zamin.Core.Domain.Entities`

### Recipe: BaseValueObject و BusinessId {#recipe-value-objects}

**توضیح:** Value objectها از `BaseValueObject<T>` ارث می‌برند.

**Types in this pattern:** `BaseValueObject<TValueObject>`, `BusinessId`.

**کد نمونه:**

```csharp
// src/1.Core/Domain/Common/ValueObjects/Code.cs
public sealed class Code : BaseValueObject<Code>
{
    private Code(string value)
    {
        Validate(value);
        Value = value.Trim();
    }

    public static Code FromString(string value) => new(value);

    public static void Validate(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new InvalidValueObjectStateException("Value is not valid", CODE);
        // ...
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
```

**نکات مهم:**

- جزئیات در بخش API Reference برای `Zamin.Core.Domain.ValueObjects`.

- Namespace مرتبط: `Zamin.Core.Domain.ValueObjects`

### Recipe: Toolkit value objects (Title, …) {#recipe-toolkit-value-objects}

**توضیح:** VOهای آماده مثل Title / Description / NationalCode / Priority در دامنه‌ی اپلیکیشن استفاده شده‌اند.

**Types observed (identifier hits):** `Description`, `NationalCode`, `Priority`, `Title`.

**کد نمونه:**

مستندات کافی موجود نیست

**نکات مهم:**

- جزئیات در بخش API Reference برای `Zamin.Core.Domain.Toolkits.ValueObjects`.

- Namespace مرتبط: `Zamin.Core.Domain.Toolkits.ValueObjects`

### Recipe: استثناهای دامنه {#recipe-domain-exceptions}

**توضیح:** `InvalidEntityStateException` و `InvalidValueObjectStateException` در دامنه throw می‌شوند.

**Types in this pattern:** `InvalidEntityStateException`, `InvalidValueObjectStateException`.

**کد نمونه:**

```csharp
// src/1.Core/ApplicationService/Common/Extensions/UserInfoServiceExtentions.cs
public static Guid GetUserSubOrDefault(this IUserInfoService userInfoService)
{
    try
    {
        return userInfoService.GetUserSub();
    }
    catch (InvalidEntityStateException)
    {
        return Guid.Empty;
    }
}
```

```csharp
// src/1.Core/Application/Services/SampleExpressionAnalyzer.cs
try
{
    using var document = ParseExpression(expression);
    return CollectConditions(document.RootElement).Any(...);
}
catch (InvalidValueObjectStateException)
{
    return ExpressionContainsAttributeFallback(expression, attributeName);
}
```

**نکات مهم:**

- Aggregates / entities for invariant violations.
- Value objects on invalid construction.

- Namespace مرتبط: `Zamin.Core.Domain.Exceptions`

### Recipe: ICommandRepository و BaseCommandRepository {#recipe-command-repository}

**توضیح:** ریپازیتوری فرمان از `BaseCommandRepository<...>` ارث می‌برد و قرارداد `ICommandRepository` را پیاده می‌کند.

**Types in this pattern:** `BaseCommandRepository<TEntity,TDbContext,TId>` (and non-generic-id overload).

**کد نمونه:**

```csharp
// src/Infra/Sql.Commands/Sliders/SliderCommandRepository.cs
public sealed class SliderCommandRepository(AppCommandDbContext dbContext)
        : BaseCommandRepository<Sample, AppCommandDbContext, long>(dbContext), ISampleCommandRepository
{
    public async Task<List<Sample>> GetAllAsync()
    {
        return await _dbContext.Sliders.ToListAsync();
    }
}
```

**نکات مهم:**

- جزئیات در بخش API Reference برای `Zamin.Infra.Data.Sql.Commands`.

- Namespace مرتبط: `Zamin.Infra.Data.Sql.Commands`

### Recipe: IQueryRepository و BaseQueryRepository {#recipe-query-repository}

**توضیح:** ریپازیتوری کوئری از `BaseQueryRepository<TDbContext>` و `BaseQueryDbContext` استفاده می‌کند.

**Types in this pattern:** `BaseQueryDbContext`, `BaseQueryRepository<TDbContext>`.

**کد نمونه:**

```csharp
// src/Infra/Sql.Queries/Common/AppQueryDbContext.cs
public class AppQueryDbContext(DbContextOptions<AppQueryDbContext> options) : BaseQueryDbContext(options)
{
    public DbSet<User> Users { get; set; } = default!;
}
```

```csharp
// src/2.Infra/Data/Sql.Queries/Users/SampleQueryRepository.cs
public class SampleQueryRepository(AppQueryDbContext dbContext, IConfiguration configuration)
    : BaseQueryRepository<AppQueryDbContext>(dbContext), ISampleQueryRepository
{
    public async Task<UserProfileQr?> ExecuteAsync(UserGetProfileDbQuery query)
    {
        return await _dbContext.Users
            .Where(user => user.ExpireDateTime == null || user.ExpireDateTime > DateTime.Now)
            // ...
            .Select(user => new UserProfileQr() { BusinessId = user.BusinessId, /* ... */ })
            .FirstOrDefaultAsync();
    }
}
```

**نکات مهم:**

- جزئیات در بخش API Reference برای `Zamin.Infra.Data.Sql.Queries`.

- Namespace مرتبط: `Zamin.Infra.Data.Sql.Queries`

### Recipe: BaseOutboxCommandDbContext {#recipe-outbox-dbcontext}

**توضیح:** Command DbContext اپلیکیشن از `BaseOutboxCommandDbContext` ارث می‌برد.

**Types in this pattern:** `BaseOutboxCommandDbContext`.

**کد نمونه:**

```csharp
// src/Infra/Sql.Commands/Common/AppCommandDbContext.cs
public class AppCommandDbContext(DbContextOptions<AppCommandDbContext> options)
    : BaseOutboxCommandDbContext(options), IDataProtectionKeyContext
{
    public DbSet<Sample> Samples { get; set; } = default!;
    // ...
}
```

**نکات مهم:**

- جزئیات در بخش API Reference برای `Zamin.Extensions.Events.Outbox.Dal.EF`.

- Namespace مرتبط: `Zamin.Extensions.Events.Outbox.Dal.EF`

### Recipe: Interceptorهای EF فرمان {#recipe-ef-interceptors}

**توضیح:** `SetPersianYeKeInterceptor` و `AddAuditDataInterceptor` روی Command DbContext ثبت می‌شوند.

**Types in this pattern:** `SetPersianYeKeInterceptor`, `AddAuditDataInterceptor`.

**کد نمونه:**

```csharp
.AddInterceptors(
    new SetPersianYeKeInterceptor(),
    new AddAuditDataInterceptor(),
    sp.GetRequiredService<ClientCacheInvalidationInterceptor>());
```

**نکات مهم:**

- جزئیات در بخش API Reference برای `Zamin.Infra.Data.Sql.Commands.Interceptors`.

- Namespace مرتبط: `Zamin.Infra.Data.Sql.Commands.Interceptors`

### Recipe: BaseController {#recipe-base-controller}

**توضیح:** کنترلرهای API از `BaseController` و متدهای `Create` / `Edit` / `Delete` / `Query` استفاده می‌کنند.

**Types in this pattern:** `BaseController`.

**کد نمونه:**

```csharp
// src/Endpoints/API/Features/Samples/SampleController.cs
public sealed class SampleController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] SampleCreateCommand command)
        => await Create<SampleCreateCommand, Guid>(command);

    [HttpGet]
    public async Task<IActionResult> GetDetail([FromQuery] SampleGetDetailQuery query)
        => await Query<SampleGetDetailQuery, SampleDetailDto?>(query);
}
```

**نکات مهم:**

- `Create` / `Create<TCommand,TData>`
- `Edit`
- `Delete`
- `Query<TQuery,TData>`

- Namespace مرتبط: `Zamin.EndPoints.Web.Controllers`

### Recipe: HttpContextExtensions {#recipe-http-context-extensions}

**توضیح:** الگوی استفاده مشاهده‌شده در اپلیکیشن برای extensionهای HTTP.

**Types in this pattern:** `HttpContextExtensions` (extension methods).

**کد نمونه:**

مستندات کافی موجود نیست

**نکات مهم:**

- جزئیات در بخش API Reference برای `Zamin.EndPoints.Web.Extensions`.

- Namespace مرتبط: `Zamin.EndPoints.Web.Extensions`

### Recipe: Model binding extensions {#recipe-model-binding}

**توضیح:** الگوی model binding مرتبط با EndPoints.Web.

No public type name hits required for usage — the host calls:

**کد نمونه:**

```csharp
builder.Services.AddNonValidatingValidator();
```

**نکات مهم:**

- جزئیات در بخش API Reference برای `Zamin.EndPoints.Web.Extensions.ModelBinding`.

- Namespace مرتبط: `Zamin.EndPoints.Web.Extensions.ModelBinding`

### Recipe: ZaminServices در Handlerها {#recipe-zamin-services}

**توضیح:** `ZaminServices` به هر CommandHandler/QueryHandler تزریق می‌شود و سرویس‌های مشترک (مثل UserInfo) را در دسترس می‌گذارد.

**Types in this pattern:** `ZaminServices`.

**کد نمونه:**

```csharp
// src/Application/Samples/Commands/Create/SampleCreateHandler.cs
public class SampleCreateHandler(
    ZaminServices zaminServices,
    ISampleCommandRepository sampleCommandRepository,
    ISampleValidationService sampleValidationService)
    : CommandHandler<SampleCreateCommand, Guid>(zaminServices)
{
    public override async Task<CommandResult<Guid>> Handle(SampleCreateCommand command)
    {
        await sampleValidationService.EnsureUniqueNameAsync((SampleName)command.Name);
        Sample entity = Sample.Create(command.ToParameter());
        await sampleCommandRepository.InsertAsync(entity);
        await sampleCommandRepository.CommitAsync();
        return await OkAsync(entity.BusinessId.Value);
    }
}
```

```csharp
// decorator access
var userIp = zaminServices.UserInfoService.GetUserIp();
var userId = zaminServices.UserInfoService.GetUserSubOrDefault();
```

**نکات مهم:**

- جزئیات در بخش API Reference برای `Zamin.Utilities`.

- Namespace مرتبط: `Zamin.Utilities`

### Recipe: IUserInfoService {#recipe-user-info}

**توضیح:** دسترسی به کاربر جاری از طریق `IUserInfoService` یا `zaminServices.UserInfoService`.

**Types in this pattern:** `IUserInfoService`, `FakeUserInfoService`.

**کد نمونه:**

```csharp
// src/1.Core/ApplicationService/Common/Extensions/UserInfoServiceExtentions.cs
public static Guid GetUserSub(this IUserInfoService userInfoService)
{
    string? sub = userInfoService.UserId();
    if (string.IsNullOrWhiteSpace(sub))
        throw new InvalidEntityStateException("User data not found", "UserId");
    return Guid.Parse(sub);
}
```

**نکات مهم:**

- جزئیات در بخش API Reference برای `Zamin.Extensions.UsersManagement.Abstractions`.

- Namespace مرتبط: `Zamin.Extensions.UsersManagement.Abstractions`

### Recipe: ITranslator {#recipe-translator}

**توضیح:** ترجمه پیام‌ها از طریق `ITranslator` (پیاده‌سازی Parrot).

**Types in this pattern:** `ITranslator`.

**کد نمونه:**

```csharp
// src/3.Endpoints/API/Features/Users/UserController.cs
public async Task<IActionResult> CreateByPassword([FromForm] UserCreateCommand command, [FromServices] ITranslator translator)
{
    if (command.Picture is not null)
    {
        var isValid = FileValidationService.ValidateImageFile(command.Picture, out string? errorKey);
        if (!isValid)
            return BadRequest(translator[errorKey!]);
    }
    return await Create<UserCreateCommand, Guid>(command);
}
```

**نکات مهم:**

- FluentValidation validators: ctor `(ITranslator translator)`.
- Controllers: `[FromServices] ITranslator translator` then `translator[errorKey]`.

- Namespace مرتبط: `Zamin.Extensions.Translations.Abstractions`

### Recipe: TranslatorKeys / TranslatorValues {#recipe-translator-keys}

**توضیح:** کلید/مقدارهای ترجمه استفاده‌شده در کنار translator.

**Types in this pattern:** `TranslatorKeys`, `TranslatorValues`.

**کد نمونه:**

مستندات کافی موجود نیست

**نکات مهم:**

- جزئیات در بخش API Reference برای `Zamin.Utilities.Resources.Translators`.

- Namespace مرتبط: `Zamin.Utilities.Resources.Translators`

### Recipe: ICacheAdapter {#recipe-cache-adapter}

**توضیح:** مصرف کش توزیع‌شده از طریق `ICacheAdapter` پس از ثبت Redis/SQL.

**Types in this pattern:** `ICacheAdapter`.

**کد نمونه:**

```csharp
// src/1.Core/Application/Services/SampleCachedService.cs
public sealed class SampleCachedService(
    IAttributeDefinitionQueryRepository attributeDefinitionQueryRepository,
    IPolicyQueryRepository policyQueryRepository,
    ICacheAdapter cacheAdapter,
    IOptions<AbacEvaluationCacheOptions> cacheOptions)
    : ISampleAppService
{
    public async Task<IReadOnlyList<AttributeDefinitionCatalogItem>> GetCatalogAsync(
        Guid softwareBusinessId,
        CancellationToken cancellationToken = default)
    {
        var key = CatalogCacheKey(softwareBusinessId);
        var cached = _cacheAdapter.Get<List<AttributeDefinitionCatalogItem>>(key);
        if (cached is not null)
            return cached;

        var loaded = await _attributeDefinitionQueryRepository.GetCatalogBySoftwareBusinessIdAsync(softwareBusinessId);
        var items = loaded.ToList();
        _cacheAdapter.Add(key, items, GetAbsoluteExpiration(), null);
        return items;
    }
}
```

**نکات مهم:**

- جزئیات در بخش API Reference برای `Zamin.Extensions.Caching.Abstractions`.

- Namespace مرتبط: `Zamin.Extensions.Caching.Abstractions`

### ترکیب دامنه و persistence (خلاصه مشاهده‌شده)

- Aggregate: `AggregateRoot` / `AggregateRoot<TId>`؛ Entity: `Entity` / `Entity<TId>`.
- VO: `BaseValueObject<T>` + استثناهای Invalid*.
- Command DbContext: `BaseOutboxCommandDbContext`؛ Query: `BaseQueryDbContext`.
- Repository: `BaseCommandRepository` / `BaseQueryRepository` + قراردادهای Core.Contracts.Data.*
- Lifetime: markerهای `ITransientLifetime` و مشابه از طریق `AddZaminApiCore`.

### مدیریت استثناء (مشاهده‌شده در اپلیکیشن)

- دامنه: throw از `InvalidEntityStateException` / `InvalidValueObjectStateException`.
- بعضی نقاط اپلیکیشن catch محلی دارند (مثلاً GetUserSubOrDefault → Guid.Empty).
- Decoratorهای dispatcher: catch `Exception`، لاگ، سپس rethrow.
- زیر `src/` هیچ `catch (DomainStateException)` یافت نشده است.

### تایپ‌های بدون نمونه‌ی عملی استفاده

نمونه‌ی عملی استفاده در دسترس نیست؛ مستندات فقط بر پایه‌ی امضا و پیاده‌سازی خود زمین (بخش API Reference همین فایل) است. با احتیاط و بدون اختراع الگوی فراخوانی استفاده کنید.

### without_usage_sample by namespace

#### Zamin.Core.ApplicationServices.Commands

- `CommandDispatcherDomainExceptionHandlerDecorator` (class)
- `CommandDispatcherValidationDecorator` (class)

#### Zamin.Core.ApplicationServices.Events

- `EventDispatcher` (class)
- `EventDispatcherDecorator` (class)
- `EventDispatcherDomainExceptionHandlerDecorator` (class)
- `EventDispatcherValidationDecorator` (class)

#### Zamin.Core.ApplicationServices.Queries

- `QueryDispatcherDomainExceptionHandlerDecorator` (class)
- `QueryDispatcherValidationDecorator` (class)

#### Zamin.Core.Contracts.ApplicationServices.Commands

- `ICommandHandler<TCommand, TData>` (interface)
- `ICommandHandler<TCommand>` (interface)

#### Zamin.Core.Contracts.ApplicationServices.Events

- `IDomainEventHandler<TDomainEvent>` (interface)
- `IEventDispatcher` (interface)

#### Zamin.Core.Contracts.ApplicationServices.Queries

- `IQueryHandler<TQuery, TData>` (interface)

#### Zamin.Core.Contracts.Data.Commands

- `IDomainEventStore` (interface)
- `IUnitOfWork` (interface)

#### Zamin.Core.Domain.Entities

- `IAggregateRoot` (interface)
- `IAuditableEntity` (interface)

#### Zamin.Core.Domain.Events

- `IDomainEvent` (interface)

#### Zamin.Core.Domain.Exceptions

- `DomainStateException` (class)

#### Zamin.Core.Domain.Toolkits.ValueObjects

- `LegalNationalId` (class)

#### Zamin.Core.RequestResponse.Common

- `ApplicationServiceResult` (class)
- `IApplicationServiceResult` (interface)

#### Zamin.Core.RequestResponse.Endpoints

- `IWebRequest` (interface)

#### Zamin.Core.RequestResponse.Queries

- `IPageQuery<TData>` (interface)
- `PageQueryRecord<TData>` (record)

#### Zamin.EndPoints.Web.Extensions

- `ClaimExtensions` (class)

#### Zamin.EndPoints.Web.Extensions.ModelBinding

- `NonValidatingValidatorExtensions` (class)

#### Zamin.EndPoints.Web.Filters

- `CamelCaseJsonAttribute` (class)
- `CamelCaseJsonFilter` (class)
- `PascalCaseJsonAttribute` (class)
- `PascalCaseJsonFilter` (class)
- `ValidateModelStateAttribute` (class)

#### Zamin.EndPoints.Web.Middlewares.ApiExceptionHandler

- `ApiError` (class)
- `ApiExceptionMiddleware` (class)
- `ApiExceptionMiddlewareExtensions` (class)
- `ApiExceptionOptions` (class)

#### Zamin.EndPoints.Web.ModelBinding

- `NonValidatingValidator` (class)

#### Zamin.Extensions.Caching.Abstractions

- `FakeCacheAdapter` (class)

#### Zamin.Extensions.Caching.Distributed.Redis.Services

- `DistributedRedisCacheAdapter` (class)

#### Zamin.Extensions.Caching.Distributed.Sql.Services

- `DistributedSqlCacheAdapter` (class)

#### Zamin.Extensions.Caching.InMemory.Services

- `InMemoryCacheAdapter` (class)

#### Zamin.Extensions.ChangeDataLog.Abstractions

- `DatabaseChangeType` (enum)
- `EntityChageInterceptorItem` (class)
- `IEntityChageInterceptorItemRepository` (interface)
- `PropertyChangeLogItem` (class)

#### Zamin.Extensions.ChangeDataLog.Sql

- `DapperEntityChangeInterceptorItemRepository` (class)

#### Zamin.Extensions.ChangeDataLog.Sql.Options

- `ChangeDataLogHamsterOptions` (record)
- `ChangeDataLogSqlOptions` (record)

#### Zamin.Extensions.DependencyInjection

- `AddApiConfigurationExtensions` (class)
- `AddApplicationServicesExtensions` (class)
- `AddDataAccessExtentsions` (class)
- `AddZaminServicesExtensions` (class)
- `ApiAuthenticationServiceCollectionExtensions` (class)
- `AutoMapperServiceCollectionExtensions` (class)
- `ChageDatalogServiceCollectionExtensions` (class)
- `DistributedRedisCacheServiceCollectionExtensions` (class)
- `DistributedSqlCacheServiceCollectionExtensions` (class)
- `EPPlusExcelSerializerServiceCollectionExtensions` (class)
- `InMemoryCachingServiceCollectionExtensions` (class)
- `JwtTokenExtensions` (class)
- `MessageInboxServiceCollectionExtensions` (class)
- `MicrosoftSerializerServiceCollectionExtensions` (class)
- `NewtonSoftSerializerServiceCollectionExtensions` (class)
- `ParrotTranslatorServiceCollectionExtensions` (class)
- `PollingPublisherServiceCollectionExtensions` (class)
- `ProviderExtensions` (class)
- `RabbitMqMessageBusServiceCollectionExtensions` (class)
- `ReferenceTokenExtensions` (class)
- `ScalarServiceCollectionExtensions` (class)
- `SerilogServiceCollectionExtensions` (class)
- `SoftwarePartDetectorServiceCollectionExtensions` (class)

#### Zamin.Extensions.DependencyInjection.Extensions.DependencyInjection

- `DependencyInjectionServiceCollectionExtensions` (class)

#### Zamin.Extensions.DependencyInjection.Options

- `DependencyInjectionOption` (class)

#### Zamin.Extensions.Events.Abstractions

- `IOutBoxEventItemRepository` (interface)
- `OutBoxEventItem` (class)

#### Zamin.Extensions.Events.Outbox.Dal.EF.Configs

- `OutBoxEventItemConfig` (class)

#### Zamin.Extensions.Events.Outbox.Dal.EF.Interceptors

- `AddOutBoxEventItemInterceptor` (class)

#### Zamin.Extensions.Events.PollingPublisher

- `PoolingPublisherBackgroundService` (class)

#### Zamin.Extensions.Events.PollingPublisher.Dal.Dapper.DataAccess

- `SqlOutBoxEventItemRepository` (class)

#### Zamin.Extensions.Events.PollingPublisher.Dal.Dapper.Options

- `PollingPublisherDalRedisOptions` (class)

#### Zamin.Extensions.Events.PollingPublisher.Options

- `PollingPublisherOptions` (class)

#### Zamin.Extensions.Logger.Abstractions

- `ZaminEventId` (class)

#### Zamin.Extensions.MessageBus.Abstractions

- `IMessageConsumer` (interface)
- `IMessageInboxItemRepository` (interface)
- `IReceiveMessageBus` (interface)
- `ISendMessageBus` (interface)
- `Parcel` (class)

#### Zamin.Extensions.MessageBus.Abstractions.Fakes

- `FakeMessageConsumer` (class)
- `FakeReceiveMessageBus` (class)
- `FakeSendMessageBus` (class)

#### Zamin.Extensions.MessageBus.MessageInbox

- `InboxMessageConsumer` (class)

#### Zamin.Extensions.MessageBus.MessageInbox.Dal.Dapper

- `SqlMessageInboxItemRepository` (class)

#### Zamin.Extensions.MessageBus.MessageInbox.Dal.Dapper.Options

- `MessageInboxDalDapperOptions` (class)

#### Zamin.Extensions.MessageBus.MessageInbox.Options

- `MessageInboxOptions` (class)

#### Zamin.Extensions.MessageBus.RabbitMQ

- `RabbitMqReceiveMessageBus` (class)
- `RabbitMqSendMessageBus` (class)
- `RabbitMqSendMessageBusConstants` (class)

#### Zamin.Extensions.MessageBus.RabbitMQ.Options

- `RabbitMqOptions` (class)

#### Zamin.Extensions.ObjectMappers.Abstractions

- `IMapperAdapter` (interface)

#### Zamin.Extensions.ObjectMappers.AutoMapper.Options

- `AutoMapperOption` (class)

#### Zamin.Extensions.ObjectMappers.AutoMapper.Services

- `AutoMapperAdapter` (class)

#### Zamin.Extensions.ObjectMappers.Mapster.Services

- `IObjectMapper` (interface)
- `Mapster` (class)

#### Zamin.Extensions.Serializers.Abstractions

- `IExcelSerializer` (interface)

#### Zamin.Extensions.Serializers.EPPlus.Extensions

- `ExcelExtensions` (class)
- `LinqExtensions` (class)

#### Zamin.Extensions.Serializers.EPPlus.Services

- `EPPlusExcelSerializer` (class)

#### Zamin.Extensions.Serializers.Microsoft.Services

- `MicrosoftSerializer` (class)

#### Zamin.Extensions.Serializers.NewtonSoft.Services

- `NewtonSoftSerializer` (class)

#### Zamin.Extensions.Translations.Parrot.Database

- `ParrotSqlRepository` (class)

#### Zamin.Extensions.Translations.Parrot.DataModel

- `LocalizationRecord` (class)

#### Zamin.Extensions.Translations.Parrot.Options

- `DefaultTranslationOption` (class)

#### Zamin.Extensions.UsersManagement.Extensions

- `ClaimExtensions` (class)

#### Zamin.Extensions.UsersManagement.Services

- `WebUserInfoService` (class)

#### Zamin.Infra.Data.Sql.Commands

- `BaseCommandDbContext` (class)
- `BaseEntityFrameworkUnitOfWork<TDbContext>` (class)

#### Zamin.Infra.Data.Sql.Commands.Extensions

- `AuditableShadowProperties` (class)
- `ChangeTrackerExtensions` (class)
- `DbCommandExtension` (class)
- `ModelBuilderExtensions` (class)
- `RowVersionShadowProperty` (class)

#### Zamin.Infra.Data.Sql.Commands.Interceptors

- `AddChangeDataLogInterceptor` (class)

#### Zamin.Infra.Data.Sql.Commands.ValueConversions

- `BusinessIdConversion` (class)
- `DescriptionConversion` (class)
- `LegalNationalIdConversion` (class)
- `NationalCodeConversion` (class)
- `TitleConversion` (class)

#### Zamin.Infra.Data.Sql.Queries

- `QueryRepositoryExtensions` (class)

#### Zamin.Utilities.Auth.ApiAuthentication.Extensions

- `ClaimsPrincipalExtentions` (class)

#### Zamin.Utilities.Auth.ApiAuthentication.Models

- `ClaimCacheModel` (class)

#### Zamin.Utilities.Auth.ApiAuthentication.Options

- `CacheExpirationType` (enum)
- `CacheKeyFormat` (enum)
- `EndpointsPathOption` (class)
- `JwtTokenConfigOption` (class)
- `RefrenceTokenConfigOption` (class)
- `RegisterUserInfoClaimsOption` (class)
- `UserClaimAddonOption` (class)
- `UserClaimRuleOption` (class)

#### Zamin.Utilities.DateTimes

- `DateTimeOffsetPart` (enum)
- `DateTimeUtils` (class)
- `FriendlyPersianDateUtils` (class)
- `PersianCulture` (class)
- `PersianDateTimeUtils` (class)
- `PersianDay` (class)
- `PersianMonth` (class)
- `PersianNumbersUtils` (class)
- `PersianYear` (class)
- `RegexUtils` (class)
- `TimeConstants` (class)
- `UnicodeConstants` (class)

#### Zamin.Utilities.Extensions

- `DateTimeExtensions` (class)
- `EnumExtensions` (class)
- `GuidExtensions` (class)
- `LinqExtensions` (class)
- `ObjectExtensions` (class)
- `StringExtensions` (class)
- `StringValidatorExtensions` (class)
- `TypeExtentsions` (class)

#### Zamin.Utilities.Guards

- `Guard` (class) — False positive: only comment text "Guard:" in AuthController

#### Zamin.Utilities.Guards.GuardClauses

- `EmptyGuardClause` (class)
- `EqualGuardClause` (class)
- `ExclusiveBetweenGuardClause` (class)
- `GreaterThanGuardClause` (class)
- `GreaterThanOrEqualGuardClause` (class)
- `InclusiveBetweenGuardClause` (class)
- `LengthGuardClause` (class)
- `LessThanGuardClause` (class)
- `LessThanOrEqualGuardClause` (class)
- `MatchGuardClause` (class)
- `MaximumLengthGuardClause` (class)
- `MinimumLengthGuardClause` (class)
- `NotEmptyGuardClause` (class)
- `NotEqualGuardClause` (class)
- `NotNullGuardClause` (class)
- `NullGuardClause` (class)

#### Zamin.Utilities.ScalarRegistration.Options

- `ScalarOption` (class)

#### Zamin.Utilities.SerilogRegistration.Enrichers

- `ZaminApplicaitonEnricher` (class)
- `ZaminUserInfoEnricher` (class)

#### Zamin.Utilities.SerilogRegistration.Options

- `SerilogApplicationEnricherOptions` (class)

#### Zamin.Utilities.Sinks.Elasticsearch

- `LoggerConfigurationZaminElasticsearchExtensions` (class)

#### Zamin.Utilities.SoftwarePartDetector

- `ControllersAndActionDetector` (class)

#### Zamin.Utilities.SoftwarePartDetector.Attributes

- `SoftwarePartControllerOptionAttribute` (class)

#### Zamin.Utilities.SoftwarePartDetector.Authentications

- `ISoftwarePartAuthentication` (interface)
- `SoftwarePartAuthentication` (class)

#### Zamin.Utilities.SoftwarePartDetector.DataModel

- `SoftwarePartAction` (class)

#### Zamin.Utilities.SoftwarePartDetector.Options

- `OAuthOption` (class)
- `SoftwarePartDetectorOptions` (class)

#### Zamin.Utilities.SoftwarePartDetector.Publishers

- `ISoftwarePartPublisher` (interface)
- `SoftwarePartWebPublisher` (class)

### Entirely unused namespaces (no type hit and no dedicated registration doc)

- `Zamin.Core.ApplicationServices.Events`
- `Zamin.Core.Contracts.ApplicationServices.Events`
- `Zamin.Core.Domain.Events`
- `Zamin.Core.RequestResponse.Endpoints`
- `Zamin.EndPoints.Web.Filters`
- `Zamin.EndPoints.Web.Middlewares.ApiExceptionHandler`
- `Zamin.EndPoints.Web.ModelBinding`
- `Zamin.Extensions.Caching.Distributed.Redis.Services`
- `Zamin.Extensions.Caching.Distributed.Sql.Services`
- `Zamin.Extensions.Caching.InMemory.Services`
- `Zamin.Extensions.ChangeDataLog.Abstractions`
- `Zamin.Extensions.ChangeDataLog.Sql`
- `Zamin.Extensions.ChangeDataLog.Sql.Options`
- `Zamin.Extensions.DependencyInjection.Extensions.DependencyInjection`
- `Zamin.Extensions.DependencyInjection.Options`
- `Zamin.Extensions.Events.Abstractions`
- `Zamin.Extensions.Events.Outbox.Dal.EF.Configs`
- `Zamin.Extensions.Events.Outbox.Dal.EF.Interceptors`
- `Zamin.Extensions.Events.PollingPublisher`
- `Zamin.Extensions.Events.PollingPublisher.Dal.Dapper.DataAccess`
- `Zamin.Extensions.Events.PollingPublisher.Dal.Dapper.Options`
- `Zamin.Extensions.Events.PollingPublisher.Options`
- `Zamin.Extensions.Logger.Abstractions`
- `Zamin.Extensions.MessageBus.Abstractions`
- `Zamin.Extensions.MessageBus.Abstractions.Fakes`
- `Zamin.Extensions.MessageBus.MessageInbox`
- `Zamin.Extensions.MessageBus.MessageInbox.Dal.Dapper.Options`
- `Zamin.Extensions.MessageBus.MessageInbox.Options`
- `Zamin.Extensions.MessageBus.RabbitMQ`
- `Zamin.Extensions.MessageBus.RabbitMQ.Options`
- `Zamin.Extensions.ObjectMappers.Abstractions`
- `Zamin.Extensions.ObjectMappers.AutoMapper.Options`
- `Zamin.Extensions.ObjectMappers.AutoMapper.Services`
- `Zamin.Extensions.ObjectMappers.Mapster.Services`
- `Zamin.Extensions.Serializers.EPPlus.Extensions`
- `Zamin.Extensions.Serializers.EPPlus.Services`
- `Zamin.Extensions.Serializers.Microsoft.Services`
- `Zamin.Extensions.Serializers.NewtonSoft.Services`
- `Zamin.Extensions.Translations.Parrot.Database`
- `Zamin.Extensions.Translations.Parrot.DataModel`
- `Zamin.Extensions.UsersManagement.Extensions`
- `Zamin.Extensions.UsersManagement.Services`
- `Zamin.Infra.Data.Sql.Commands.Extensions`
- `Zamin.Infra.Data.Sql.Commands.ValueConversions`
- `Zamin.Utilities.Auth.ApiAuthentication.Extensions`
- `Zamin.Utilities.Auth.ApiAuthentication.Models`
- `Zamin.Utilities.DateTimes`
- `Zamin.Utilities.Extensions`
- `Zamin.Utilities.Guards.GuardClauses`
- `Zamin.Utilities.ScalarRegistration.Options`
- `Zamin.Utilities.SerilogRegistration.Enrichers`
- `Zamin.Utilities.SerilogRegistration.Options`
- `Zamin.Utilities.Sinks.Elasticsearch`
- `Zamin.Utilities.SoftwarePartDetector.Attributes`
- `Zamin.Utilities.SoftwarePartDetector.Authentications`
- `Zamin.Utilities.SoftwarePartDetector.Options`
- `Zamin.Utilities.SoftwarePartDetector.Publishers`

---

## پوشش مستندات (verification)

- تایپ‌های استخراج‌شده از سورس زمین: **258**
- تایپ‌های مستندشده در این فایل: **258**
- پوشش: **کامل** (تعداد تایپ‌ها با استخراج خام برابر است).
