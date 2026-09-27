# Zamin.Extensions.Translations.Parrot.Options

مرجع API برای namespace `Zamin.Extensions.Translations.Parrot.Options`.

- **Type count (this file):** 2

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Extensions.Translations.Parrot.Options.DefaultTranslationOption`

- **Kind:** `class`
- **Source:** `Extentsions/Translations/Zamin.Extensions.Translations.Parrot/Zamin.Extensions.Translations.Parrot/Options/ParrotTranslatorOptions.cs`

کلاس «DefaultTranslationOption» در namespace Zamin.Extensions.Translations.Parrot.Options. مدل تنظیمات قابل بایند شدن از configuration.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/dependency-injection.md#recipe-parrot-translator)

#### Members

##### `Key` (property)

```csharp
public string Key { get; set; }
```

پراپرتی «Key» از نوع `string` در DefaultTranslationOption. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `Value` (property)

```csharp
public string Value { get; set; }
```

پراپرتی «Value» از نوع `string` در DefaultTranslationOption. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `Culture` (property)

```csharp
public string Culture { get; set; }
```

پراپرتی «Culture» از نوع `string` در DefaultTranslationOption. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

### `Zamin.Extensions.Translations.Parrot.Options.ParrotTranslatorOptions`

- **Kind:** `class`
- **Source:** `Extentsions/Translations/Zamin.Extensions.Translations.Parrot/Zamin.Extensions.Translations.Parrot/Options/ParrotTranslatorOptions.cs`

کلاس «ParrotTranslatorOptions» در namespace Zamin.Extensions.Translations.Parrot.Options. مدل تنظیمات قابل بایند شدن از configuration.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/dependency-injection.md#recipe-parrot-translator)

#### Members

##### `ConnectionString` (property)

```csharp
public string ConnectionString { get; set; }
```

پراپرتی «ConnectionString» از نوع `string` در ParrotTranslatorOptions. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `AutoCreateSqlTable` (property)

```csharp
public bool AutoCreateSqlTable { get; set; }
```

پراپرتی «AutoCreateSqlTable» از نوع `bool` در ParrotTranslatorOptions. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `TableName` (property)

```csharp
public string TableName { get; set; }
```

پراپرتی «TableName» از نوع `string` در ParrotTranslatorOptions. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `SchemaName` (property)

```csharp
public string SchemaName { get; set; }
```

پراپرتی «SchemaName» از نوع `string` در ParrotTranslatorOptions. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `ReloadDataIntervalInMinuts` (property)

```csharp
public int ReloadDataIntervalInMinuts { get; set; }
```

پراپرتی «ReloadDataIntervalInMinuts» از نوع `int` در ParrotTranslatorOptions. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.

##### `DefaultTranslations` (property)

```csharp
public DefaultTranslationOption[] DefaultTranslations { get; set; }
```

پراپرتی «DefaultTranslations» از نوع `DefaultTranslationOption[]` در ParrotTranslatorOptions. وضعیت یا تنظیم مرتبط با این عضو را در اختیار می‌گذارد. قابل خواندن و نوشتن است.
