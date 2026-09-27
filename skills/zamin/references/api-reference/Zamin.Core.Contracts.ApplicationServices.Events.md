# Zamin.Core.Contracts.ApplicationServices.Events

مرجع API برای namespace `Zamin.Core.Contracts.ApplicationServices.Events`.

- **Type count (this file):** 2

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Core.Contracts.ApplicationServices.Events.IDomainEventHandler<TDomainEvent>`

- **Kind:** `interface`
- **Constraints:** `where TDomainEvent : IDomainEvent`
- **Source:** `Onion/src/2.Core/Zamin.Core.Contracts/ApplicationServices/Events/IDomainEventHandler.cs`

قرارداد (اینترفیس) «IDomainEventHandler<TDomainEvent>» در namespace Zamin.Core.Contracts.ApplicationServices.Events. قرارداد پردازش یک درخواست/رویداد در لایه اپلیکیشن. قیود جنریک: where TDomainEvent : IDomainEvent.

#### Members

##### `Handle` (method)

```csharp
Task Handle(TDomainEvent Event)
```

متد «Handle» در IDomainEventHandler<TDomainEvent>. منطق اصلی پردازش درخواست/رویداد را اجرا می‌کند.
پارامترها:
- Event (TDomainEvent): رویداد دامنه/پیام برای پردازش.

مقدار بازگشتی: `Task` — عملیات ناهمگام بدون نتیجه داده‌ای.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

### `Zamin.Core.Contracts.ApplicationServices.Events.IEventDispatcher`

- **Kind:** `interface`
- **Source:** `Onion/src/2.Core/Zamin.Core.Contracts/ApplicationServices/Events/IEventDispatcher.cs`

قرارداد (اینترفیس) «IEventDispatcher» در namespace Zamin.Core.Contracts.ApplicationServices.Events. قرارداد مسیریابی و ارسال فرمان/کوئری/رویداد به handler مناسب.

#### Members

##### `PublishDomainEventAsync` (method)

```csharp
Task PublishDomainEventAsync<TDomainEvent>(TDomainEvent @event) where TDomainEvent : class, IDomainEvent
```

متد «PublishDomainEventAsync» در IEventDispatcher. رویداد/پیام را منتشر می‌کند.
پارامترها:
- event (TDomainEvent): رویداد دامنه/پیام برای پردازش.

مقدار بازگشتی: `Task` — عملیات ناهمگام بدون نتیجه داده‌ای.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
