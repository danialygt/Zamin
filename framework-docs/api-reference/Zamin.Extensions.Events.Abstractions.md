# Zamin.Extensions.Events.Abstractions

مرجع API برای namespace `Zamin.Extensions.Events.Abstractions`.

- **Type count (this file):** 2

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Extensions.Events.Abstractions.IOutBoxEventItemRepository`

- **Kind:** `interface`
- **Source:** `Extentsions/Zamin.Extensions.Abstractions/Zamin.Extensions.Events.Abstractions/IOutBoxEventItemRepository.cs`

قرارداد (اینترفیس) «IOutBoxEventItemRepository» در namespace Zamin.Extensions.Events.Abstractions. قرارداد دسترسی به داده برای ذخیره و بازیابی aggregate/entity.

#### Members

##### `GetOutBoxEventItemsForPublishe` (method)

```csharp
public List<OutBoxEventItem> GetOutBoxEventItemsForPublishe(int maxCount = 100)
```

متد «GetOutBoxEventItemsForPublishe» در IOutBoxEventItemRepository. داده یا وضعیت مرتبط را بازیابی می‌کند.
پارامترها:
- maxCount (int): ورودی اختیاری از نوع int (دارای مقدار پیش‌فرض).

مقدار بازگشتی: `List<OutBoxEventItem>`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `MarkAsRead` (method)

```csharp
void MarkAsRead(List<OutBoxEventItem> outBoxEventItems)
```

متد «MarkAsRead» در IOutBoxEventItemRepository. وضعیت آیتم را در ذخیره‌گاه علامت‌گذاری می‌کند.
پارامترها:
- outBoxEventItems (List<OutBoxEventItem>): رویداد دامنه/پیام برای پردازش.

مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

### `Zamin.Extensions.Events.Abstractions.OutBoxEventItem`

- **Kind:** `class`
- **Source:** `Extentsions/Zamin.Extensions.Abstractions/Zamin.Extensions.Events.Abstractions/OutBoxEventItem.cs`

کلاس «OutBoxEventItem» در namespace Zamin.Extensions.Events.Abstractions. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین.

#### Members

##### `OutBoxEventItemId` (property)

```csharp
public long OutBoxEventItemId { get; set; }
```

پراپرتی «OutBoxEventItemId» از نوع `long` در OutBoxEventItem. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `EventId` (property)

```csharp
public Guid EventId { get; set; }
```

پراپرتی «EventId» از نوع `Guid` در OutBoxEventItem. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `AccuredByUserId` (property)

```csharp
public string AccuredByUserId { get; set; }
```

پراپرتی «AccuredByUserId» از نوع `string` در OutBoxEventItem. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `AccuredOn` (property)

```csharp
public DateTime AccuredOn { get; set; }
```

پراپرتی «AccuredOn» از نوع `DateTime` در OutBoxEventItem. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `AggregateName` (property)

```csharp
public string AggregateName { get; set; }
```

پراپرتی «AggregateName» از نوع `string` در OutBoxEventItem. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `AggregateTypeName` (property)

```csharp
public string AggregateTypeName { get; set; }
```

پراپرتی «AggregateTypeName» از نوع `string` در OutBoxEventItem. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `AggregateId` (property)

```csharp
public string AggregateId { get; set; }
```

پراپرتی «AggregateId» از نوع `string` در OutBoxEventItem. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `EventName` (property)

```csharp
public string EventName { get; set; }
```

پراپرتی «EventName» از نوع `string` در OutBoxEventItem. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `EventTypeName` (property)

```csharp
public string EventTypeName { get; set; }
```

پراپرتی «EventTypeName» از نوع `string` در OutBoxEventItem. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `EventPayload` (property)

```csharp
public string EventPayload { get; set; }
```

پراپرتی «EventPayload» از نوع `string` در OutBoxEventItem. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `TraceId` (property)

```csharp
public string? TraceId { get; set; }
```

پراپرتی «TraceId» از نوع `string?` در OutBoxEventItem. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `SpanId` (property)

```csharp
public string? SpanId { get; set; }
```

پراپرتی «SpanId» از نوع `string?` در OutBoxEventItem. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `IsProcessed` (property)

```csharp
public bool IsProcessed { get; set; }
```

پراپرتی «IsProcessed» از نوع `bool` در OutBoxEventItem. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.
