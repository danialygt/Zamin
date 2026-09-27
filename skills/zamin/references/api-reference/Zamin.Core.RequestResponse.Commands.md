# Zamin.Core.RequestResponse.Commands

مرجع API برای namespace `Zamin.Core.RequestResponse.Commands`.

- **Type count (this file):** 4

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Core.RequestResponse.Commands.CommandResult`

- **Kind:** `class`
- **Base / interfaces:** `ApplicationServiceResult`
- **Source:** `Onion/src/2.Core/Zamin.Core.RequestResponse/Commands/CommandResult.cs`

نتیجه انجام هر عملیات به کمک این کلاس بازگشت داده می‌شود. دلایل استفاده از این الگو و پیاده سازی کاملی از این الگو را در لینک زیر می‌توانید مشاهده کنید https://github.com/vkhorikov/CqrsInPractice

- **Recipe:** [الگوی استفاده مرتبط](../patterns/common-recipes.md#recipe-command-contracts)

_اعضای عمومی مستندسازی‌شده در این خروجی وجود ندارد یا استخراج نشده است._

### `Zamin.Core.RequestResponse.Commands.CommandResult<TData>`

- **Kind:** `class`
- **Base / interfaces:** `CommandResult`
- **Source:** `Onion/src/2.Core/Zamin.Core.RequestResponse/Commands/CommandResult.cs`

نتیجه انجام هر عملیات به کمک این کلاس بازگشت داده می‌شود. دلایل استفاده از این الگو و پیاده سازی کاملی از این الگو را در لینک زیر می‌توانید مشاهده کنید این ساختار در صورتی استفاده میشود که برای عملیات مقدار خروجی نیاز باشد https://github.com/vkhorikov/CqrsInPractice

- **Recipe:** [الگوی استفاده مرتبط](../patterns/common-recipes.md#recipe-command-contracts)

#### Members

##### `_data` (field)

```csharp
public TData? _data;
```

فیلد «_data» در CommandResult<TData> با امضای `public TData? _data;`. برای نگهداری وضعیت داخلی/قابل‌دسترس نوع استفاده می‌شود.

##### `Data` (property)

```csharp
public TData? Data => ...
```

پراپرتی «Data» از نوع `TData?` در CommandResult<TData>. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. منطق دسترسی از روی بدنه accessor قابل مشاهده است.

### `Zamin.Core.RequestResponse.Commands.ICommand`

- **Kind:** `interface`
- **Source:** `Onion/src/2.Core/Zamin.Core.RequestResponse/Commands/ICommand.cs`

جهت علامت گذاری کلاسی که پارامتر‌های ورودی درستور را دارد از این اینترفیس اسفتاده می‌شود

- **Recipe:** [الگوی استفاده مرتبط](../patterns/common-recipes.md#recipe-command-contracts)

_اعضای عمومی مستندسازی‌شده در این خروجی وجود ندارد یا استخراج نشده است._

### `Zamin.Core.RequestResponse.Commands.ICommand<TData>`

- **Kind:** `interface`
- **Source:** `Onion/src/2.Core/Zamin.Core.RequestResponse/Commands/ICommand.cs`

جهت علامت گذاری کلاسی که پارامتر‌های ورودی درستور را دارد از این اینترفیس اسفتاده می‌شود اگر به ازای دستور ارسال شده مقدار خروجی باید بازگشت داده شود از این اینترفیس استفاده می‌شود

- **Recipe:** [الگوی استفاده مرتبط](../patterns/common-recipes.md#recipe-command-contracts)

_اعضای عمومی مستندسازی‌شده در این خروجی وجود ندارد یا استخراج نشده است._
