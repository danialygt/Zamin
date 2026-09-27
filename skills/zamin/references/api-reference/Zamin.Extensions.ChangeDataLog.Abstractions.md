# Zamin.Extensions.ChangeDataLog.Abstractions

مرجع API برای namespace `Zamin.Extensions.ChangeDataLog.Abstractions`.

- **Type count (this file):** 4

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Extensions.ChangeDataLog.Abstractions.DatabaseChangeType`

- **Kind:** `enum`
- **Source:** `Extentsions/Zamin.Extensions.Abstractions/Zamin.Extensions.ChangeDataLog.Abstractions/DatabaseChangeType.cs`

شمارشی (enum) «DatabaseChangeType» در namespace Zamin.Extensions.ChangeDataLog.Abstractions. تعریف enum عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین.

#### Members

##### `Insert` (enum_member)

```csharp
Insert = 1
```

مقدار شمارشی «Insert» در enum DatabaseChangeType.

##### `Update` (enum_member)

```csharp
Update = 2
```

مقدار شمارشی «Update» در enum DatabaseChangeType.

##### `Delete` (enum_member)

```csharp
Delete = 3
```

مقدار شمارشی «Delete» در enum DatabaseChangeType.

### `Zamin.Extensions.ChangeDataLog.Abstractions.EntityChageInterceptorItem`

- **Kind:** `class`
- **Source:** `Extentsions/Zamin.Extensions.Abstractions/Zamin.Extensions.ChangeDataLog.Abstractions/EntityChageInterceptorItem.cs`

کلاس «EntityChageInterceptorItem» در namespace Zamin.Extensions.ChangeDataLog.Abstractions. موجودیت دامنه با هویت و قابلیت auditable.

#### Members

##### `Id` (property)

```csharp
public Guid Id { get; set; }
```

پراپرتی «Id» از نوع `Guid` در EntityChageInterceptorItem. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `ContextName` (property)

```csharp
public string ContextName { get; set; }
```

پراپرتی «ContextName» از نوع `string` در EntityChageInterceptorItem. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `EntityType` (property)

```csharp
public string EntityType { get; set; }
```

پراپرتی «EntityType» از نوع `string` در EntityChageInterceptorItem. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `EntityId` (property)

```csharp
public string EntityId { get; set; }
```

پراپرتی «EntityId» از نوع `string` در EntityChageInterceptorItem. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `UserId` (property)

```csharp
public string UserId { get; set; }
```

پراپرتی «UserId» از نوع `string` در EntityChageInterceptorItem. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `Ip` (property)

```csharp
public string Ip { get; set; }
```

پراپرتی «Ip» از نوع `string` در EntityChageInterceptorItem. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `TransactionId` (property)

```csharp
public string TransactionId { get; set; }
```

پراپرتی «TransactionId» از نوع `string` در EntityChageInterceptorItem. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `DateOfOccurrence` (property)

```csharp
public DateTime DateOfOccurrence { get; set; }
```

پراپرتی «DateOfOccurrence» از نوع `DateTime` در EntityChageInterceptorItem. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `ChangeType` (property)

```csharp
public string ChangeType { get; set; }
```

پراپرتی «ChangeType» از نوع `string` در EntityChageInterceptorItem. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `PropertyChangeLogItems` (property)

```csharp
public List<PropertyChangeLogItem> PropertyChangeLogItems { get; set; }
```

پراپرتی «PropertyChangeLogItems» از نوع `List<PropertyChangeLogItem>` در EntityChageInterceptorItem. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `AddPropertyChangeItem` (method)

```csharp
public void AddPropertyChangeItem(string propertyName, string value)
```

متد «AddPropertyChangeItem» در EntityChageInterceptorItem. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- propertyName (string): ورودی از نوع string.
- value (string): مقدار مورد بررسی/ورود.

مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

### `Zamin.Extensions.ChangeDataLog.Abstractions.IEntityChageInterceptorItemRepository`

- **Kind:** `interface`
- **Source:** `Extentsions/Zamin.Extensions.Abstractions/Zamin.Extensions.ChangeDataLog.Abstractions/IEntityChageInterceptorItemRepository.cs`

قرارداد (اینترفیس) «IEntityChageInterceptorItemRepository» در namespace Zamin.Extensions.ChangeDataLog.Abstractions. قرارداد دسترسی به داده برای ذخیره و بازیابی aggregate/entity.

#### Members

##### `Save` (method)

```csharp
public void Save(List<EntityChageInterceptorItem> entityChageInterceptorItems, IDbTransaction transaction)
```

متد «Save» در IEntityChageInterceptorItemRepository. وضعیت را به‌روز یا ذخیره می‌کند.
پارامترها:
- entityChageInterceptorItems (List<EntityChageInterceptorItem>): ورودی از نوع List<EntityChageInterceptorItem>.
- transaction (IDbTransaction): ورودی از نوع IDbTransaction.

مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `SaveAsync` (method)

```csharp
public Task SaveAsync(List<EntityChageInterceptorItem> entityChageInterceptorItems, IDbTransaction transaction)
```

متد «SaveAsync» در IEntityChageInterceptorItemRepository. وضعیت را به‌روز یا ذخیره می‌کند.
پارامترها:
- entityChageInterceptorItems (List<EntityChageInterceptorItem>): ورودی از نوع List<EntityChageInterceptorItem>.
- transaction (IDbTransaction): ورودی از نوع IDbTransaction.

مقدار بازگشتی: `Task` — عملیات ناهمگام بدون نتیجه داده‌ای.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

### `Zamin.Extensions.ChangeDataLog.Abstractions.PropertyChangeLogItem`

- **Kind:** `class`
- **Source:** `Extentsions/Zamin.Extensions.Abstractions/Zamin.Extensions.ChangeDataLog.Abstractions/PropertyChangeLogItem.cs`

کلاس «PropertyChangeLogItem» در namespace Zamin.Extensions.ChangeDataLog.Abstractions. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین.

#### Members

##### `Id` (property)

```csharp
public Guid Id { get; set; }
```

پراپرتی «Id» از نوع `Guid` در PropertyChangeLogItem. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `ChageInterceptorItemId` (property)

```csharp
public Guid ChageInterceptorItemId { get; set; }
```

پراپرتی «ChageInterceptorItemId» از نوع `Guid` در PropertyChangeLogItem. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `PropertyName` (property)

```csharp
public string PropertyName { get; set; }
```

پراپرتی «PropertyName» از نوع `string` در PropertyChangeLogItem. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `Value` (property)

```csharp
public string Value { get; set; }
```

پراپرتی «Value» از نوع `string` در PropertyChangeLogItem. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.
