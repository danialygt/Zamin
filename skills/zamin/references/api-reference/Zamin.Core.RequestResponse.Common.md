# Zamin.Core.RequestResponse.Common

مرجع API برای namespace `Zamin.Core.RequestResponse.Common`.

- **Type count (this file):** 3

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Core.RequestResponse.Common.ApplicationServiceResult`

- **Kind:** `class`
- **Base / interfaces:** `IApplicationServiceResult`
- **Source:** `Onion/src/2.Core/Zamin.Core.RequestResponse/Common/ApplicationServiceResult.cs`

کلاس «ApplicationServiceResult» در namespace Zamin.Core.RequestResponse.Common. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین. ارث‌بری/پیاده‌سازی: IApplicationServiceResult. مرتبط: IApplicationServiceResult (same namespace).

- **Recipe:** [الگوی استفاده مرتبط](../patterns/common-recipes.md#recipe-application-service-status)

#### Members

##### `_messages` (field)

```csharp
protected readonly List<string> _messages = new();
```

فیلد «_messages» در ApplicationServiceResult با امضای `protected readonly List<string> _messages = new();`. برای نگهداری وضعیت داخلی/قابل‌دسترس نوع استفاده می‌شود.

##### `Messages` (property)

```csharp
public IEnumerable<string> Messages => ...
```

پراپرتی «Messages» از نوع `IEnumerable<string>` در ApplicationServiceResult. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. منطق دسترسی از روی بدنه accessor قابل مشاهده است.

##### `Status` (property)

```csharp
public ApplicationServiceStatus Status { get; set; }
```

پراپرتی «Status» از نوع `ApplicationServiceStatus` در ApplicationServiceResult. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `AddMessage` (method)

```csharp
public void AddMessage(string error)
```

متد «AddMessage» در ApplicationServiceResult. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- error (string): ورودی از نوع string.

مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
انواع مرتبط: IApplicationServiceResult (same namespace)

##### `AddMessages` (method)

```csharp
public void AddMessages(IEnumerable<string> errors)
```

متد «AddMessages» در ApplicationServiceResult. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- errors (IEnumerable<string>): ورودی از نوع IEnumerable<string>.

مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
انواع مرتبط: IApplicationServiceResult (same namespace)

##### `ClearMessages` (method)

```csharp
public void ClearMessages()
```

متد «ClearMessages» در ApplicationServiceResult. مورد یا وضعیت را حذف/پاک می‌کند.
بدون پارامتر ورودی.
مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
انواع مرتبط: IApplicationServiceResult (same namespace)

### `Zamin.Core.RequestResponse.Common.ApplicationServiceStatus`

- **Kind:** `enum`
- **Source:** `Onion/src/2.Core/Zamin.Core.RequestResponse/Common/ApplicationServiceStatus.cs`

شمارشی (enum) «ApplicationServiceStatus» در namespace Zamin.Core.RequestResponse.Common. تعریف enum عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/common-recipes.md#recipe-application-service-status)

#### Members

##### `Ok` (enum_member)

```csharp
Ok = 1
```

مقدار شمارشی «Ok» در enum ApplicationServiceStatus.

##### `NotFound` (enum_member)

```csharp
NotFound = 2
```

مقدار شمارشی «NotFound» در enum ApplicationServiceStatus.

##### `ValidationError` (enum_member)

```csharp
ValidationError = 3
```

مقدار شمارشی «ValidationError» در enum ApplicationServiceStatus.

##### `InvalidDomainState` (enum_member)

```csharp
InvalidDomainState = 4
```

مقدار شمارشی «InvalidDomainState» در enum ApplicationServiceStatus.

##### `Exception` (enum_member)

```csharp
Exception = 5
```

مقدار شمارشی «Exception» در enum ApplicationServiceStatus.

### `Zamin.Core.RequestResponse.Common.IApplicationServiceResult`

- **Kind:** `interface`
- **Source:** `Onion/src/2.Core/Zamin.Core.RequestResponse/Common/IApplicationServiceResult.cs`

قرارداد (اینترفیس) «IApplicationServiceResult» در namespace Zamin.Core.RequestResponse.Common. قرارداد رفتار برای مصرف‌کنندگان و پیاده‌سازی‌های جایگزین.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/common-recipes.md#recipe-application-service-status)

#### Members

##### `Messages` (property)

```csharp
IEnumerable<string> Messages { get; }
```

پراپرتی «Messages» از نوع `IEnumerable<string>` در IApplicationServiceResult. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. فقط‌خواندنی است.

##### `Status` (property)

```csharp
ApplicationServiceStatus Status { get; set; }
```

پراپرتی «Status» از نوع `ApplicationServiceStatus` در IApplicationServiceResult. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.
