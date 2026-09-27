# Zamin.Core.ApplicationServices.Events

مرجع API برای namespace `Zamin.Core.ApplicationServices.Events`.

- **Type count (this file):** 4

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Core.ApplicationServices.Events.EventDispatcher`

- **Kind:** `class`
- **Base / interfaces:** `IEventDispatcher`
- **Source:** `Onion/src/2.Core/Zamin.Core.ApplicationServices/Events/EventDispatcher.cs`

کلاس «EventDispatcher» در namespace Zamin.Core.ApplicationServices.Events. مسئول یافتن و فراخوانی handler مناسب برای فرمان/کوئری/رویداد. ارث‌بری/پیاده‌سازی: IEventDispatcher. وابستگی‌های سازنده (DI): IServiceProvider serviceProvider, ILogger<EventDispatcher> logger. مرتبط: IEventDispatcher | DI: IServiceProvider serviceProvider, ILogger<EventDispatcher> logger.

#### Members

##### `.ctor` (constructor)

```csharp
public EventDispatcher(IServiceProvider serviceProvider, ILogger<EventDispatcher> logger)
```

سازنده EventDispatcher. پارامترها از طریق تزریق وابستگی تأمین می‌شوند. پارامترها:
- serviceProvider (IServiceProvider): ارائه‌دهنده سرویس برای resolve کردن وابستگی‌ها.
- logger (ILogger<EventDispatcher>): لاگر برای ثبت رویدادها و خطاها.
پیش‌شرط: وابستگی‌ها/مقادیر ورودی باید معتبر باشند تا فیلدهای داخلی به‌درستی مقداردهی شوند.

##### `PublishDomainEventAsync` (method)

```csharp
public async Task PublishDomainEventAsync<TDomainEvent>(TDomainEvent @event) where TDomainEvent : class, IDomainEvent
```

متد «PublishDomainEventAsync» در EventDispatcher. رویداد/پیام را منتشر می‌کند. زمان اجرا را اندازه‌گیری و لاگ می‌کند. جزئیات اجرا را لاگ می‌کند. خطاها را در بلوک try/catch مدیریت می‌کند. به‌صورت ناهمگام اجرا می‌شود.
پارامترها:
- event (TDomainEvent): رویداد دامنه/پیام برای پردازش.

مقدار بازگشتی: `Task` — عملیات ناهمگام بدون نتیجه داده‌ای.
استثناها (قابل تشخیص از کد):
- InvalidOperationException
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: IEventDispatcher | DI: IServiceProvider serviceProvider, ILogger<EventDispatcher> logger

### `Zamin.Core.ApplicationServices.Events.EventDispatcherDecorator`

- **Kind:** `class`
- **Base / interfaces:** `IEventDispatcher`
- **Source:** `Onion/src/2.Core/Zamin.Core.ApplicationServices/Events/EventDispatcherDecorator.cs`

کلاس «EventDispatcherDecorator» در namespace Zamin.Core.ApplicationServices.Events. مسئول یافتن و فراخوانی handler مناسب برای فرمان/کوئری/رویداد. ارث‌بری/پیاده‌سازی: IEventDispatcher. مرتبط: IEventDispatcher.

#### Members

##### `_eventDispatcher` (field)

```csharp
protected IEventDispatcher _eventDispatcher;
```

فیلد «_eventDispatcher» در EventDispatcherDecorator با امضای `protected IEventDispatcher _eventDispatcher;`. برای نگهداری وضعیت داخلی/قابل‌دسترس نوع استفاده می‌شود.

##### `Order` (property)

```csharp
public abstract int Order { get; }
```

پراپرتی «Order» از نوع `int` در EventDispatcherDecorator. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. فقط‌خواندنی است.

##### `.ctor` (constructor)

```csharp
public EventDispatcherDecorator()
```

سازنده EventDispatcherDecorator. بدون پارامتر؛ معمولاً برای ORM، serialization یا مقداردهی اولیه محافظت‌شده استفاده می‌شود.

##### `PublishDomainEventAsync` (method)

```csharp
public abstract Task PublishDomainEventAsync<TDomainEvent>(TDomainEvent @event) where TDomainEvent : class, IDomainEvent
```

متد «PublishDomainEventAsync» در EventDispatcherDecorator. رویداد/پیام را منتشر می‌کند.
پارامترها:
- event (TDomainEvent): رویداد دامنه/پیام برای پردازش.

مقدار بازگشتی: `Task` — عملیات ناهمگام بدون نتیجه داده‌ای.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
انواع مرتبط: IEventDispatcher

##### `SetEventDispatcher` (method)

```csharp
public void SetEventDispatcher(IEventDispatcher eventDispatcher)
```

متد «SetEventDispatcher» در EventDispatcherDecorator. وضعیت را به‌روز یا ذخیره می‌کند.
پارامترها:
- eventDispatcher (IEventDispatcher): رویداد دامنه/پیام برای پردازش.

مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: قبل از Publish باید SetEventDispatcher فراخوانی شده باشد
انواع مرتبط: IEventDispatcher

### `Zamin.Core.ApplicationServices.Events.EventDispatcherDomainExceptionHandlerDecorator`

- **Kind:** `class`
- **Base / interfaces:** `EventDispatcherDecorator`
- **Source:** `Onion/src/2.Core/Zamin.Core.ApplicationServices/Events/EventDispatcherDomainExceptionHandlerDecorator.cs`

کلاس «EventDispatcherDomainExceptionHandlerDecorator» در namespace Zamin.Core.ApplicationServices.Events. مسئول یافتن و فراخوانی handler مناسب برای فرمان/کوئری/رویداد. ارث‌بری/پیاده‌سازی: EventDispatcherDecorator. وابستگی‌های سازنده (DI): ILogger<EventDispatcherDomainExceptionHandlerDecorator> logger. مرتبط: EventDispatcherDecorator (same namespace) | DI: ILogger<EventDispatcherDomainExceptionHandlerDecorator> logger.

#### Members

##### `Order` (property)

```csharp
public override int Order => ...
```

پراپرتی «Order» از نوع `int` در EventDispatcherDomainExceptionHandlerDecorator. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. منطق دسترسی از روی بدنه accessor قابل مشاهده است.

##### `.ctor` (constructor)

```csharp
public EventDispatcherDomainExceptionHandlerDecorator(ILogger<EventDispatcherDomainExceptionHandlerDecorator> logger)
```

سازنده EventDispatcherDomainExceptionHandlerDecorator. پارامترها از طریق تزریق وابستگی تأمین می‌شوند. پارامترها:
- logger (ILogger<EventDispatcherDomainExceptionHandlerDecorator>): لاگر برای ثبت رویدادها و خطاها.
پیش‌شرط: وابستگی‌ها/مقادیر ورودی باید معتبر باشند تا فیلدهای داخلی به‌درستی مقداردهی شوند.

##### `PublishDomainEventAsync` (method)

```csharp
public override async Task PublishDomainEventAsync<TDomainEvent>(TDomainEvent @event)
```

متد «PublishDomainEventAsync» در EventDispatcherDomainExceptionHandlerDecorator. رویداد/پیام را منتشر می‌کند. جزئیات اجرا را لاگ می‌کند. خطاها را در بلوک try/catch مدیریت می‌کند. به‌صورت ناهمگام اجرا می‌شود.
پارامترها:
- event (TDomainEvent): رویداد دامنه/پیام برای پردازش.

مقدار بازگشتی: `Task` — عملیات ناهمگام بدون نتیجه داده‌ای.
استثناها (قابل تشخیص از کد):
- ex (rethrow/throw)
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند؛ قبل از Publish باید SetEventDispatcher فراخوانی شده باشد
انواع مرتبط: EventDispatcherDecorator (same namespace) | DI: ILogger<EventDispatcherDomainExceptionHandlerDecorator> logger

### `Zamin.Core.ApplicationServices.Events.EventDispatcherValidationDecorator`

- **Kind:** `class`
- **Base / interfaces:** `EventDispatcherDecorator`
- **Source:** `Onion/src/2.Core/Zamin.Core.ApplicationServices/Events/EventDispatcherValidationDecorator.cs`

کلاس «EventDispatcherValidationDecorator» در namespace Zamin.Core.ApplicationServices.Events. مسئول یافتن و فراخوانی handler مناسب برای فرمان/کوئری/رویداد. ارث‌بری/پیاده‌سازی: EventDispatcherDecorator. وابستگی‌های سازنده (DI): IServiceProvider serviceProvider, ILogger<EventDispatcherValidationDecorator> logger. مرتبط: EventDispatcherDecorator (same namespace) | DI: IServiceProvider serviceProvider, ILogger<EventDispatcherValidationDecorator> logger.

#### Members

##### `Order` (property)

```csharp
public override int Order => ...
```

پراپرتی «Order» از نوع `int` در EventDispatcherValidationDecorator. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. منطق دسترسی از روی بدنه accessor قابل مشاهده است.

##### `.ctor` (constructor)

```csharp
public EventDispatcherValidationDecorator(IServiceProvider serviceProvider,
                                              ILogger<EventDispatcherValidationDecorator> logger)
```

سازنده EventDispatcherValidationDecorator. پارامترها از طریق تزریق وابستگی تأمین می‌شوند. پارامترها:
- serviceProvider (IServiceProvider): ارائه‌دهنده سرویس برای resolve کردن وابستگی‌ها.
- logger (ILogger<EventDispatcherValidationDecorator>): لاگر برای ثبت رویدادها و خطاها.
پیش‌شرط: وابستگی‌ها/مقادیر ورودی باید معتبر باشند تا فیلدهای داخلی به‌درستی مقداردهی شوند.

##### `PublishDomainEventAsync` (method)

```csharp
public override async Task PublishDomainEventAsync<TDomainEvent>(TDomainEvent @event)
```

متد «PublishDomainEventAsync» در EventDispatcherValidationDecorator. رویداد/پیام را منتشر می‌کند. جزئیات اجرا را لاگ می‌کند. به‌صورت ناهمگام اجرا می‌شود.
پارامترها:
- event (TDomainEvent): رویداد دامنه/پیام برای پردازش.

مقدار بازگشتی: `Task` — عملیات ناهمگام بدون نتیجه داده‌ای.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند؛ قبل از Publish باید SetEventDispatcher فراخوانی شده باشد
انواع مرتبط: EventDispatcherDecorator (same namespace) | DI: IServiceProvider serviceProvider, ILogger<EventDispatcherValidationDecorator> logger
