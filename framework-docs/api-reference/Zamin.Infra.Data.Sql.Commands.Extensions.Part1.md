# Zamin.Infra.Data.Sql.Commands.Extensions (Part 1/2)

مرجع API برای namespace `Zamin.Infra.Data.Sql.Commands.Extensions`.

- **Type count (this file):** 4
- **Parts:** **Part 1** · [Part 2](./Zamin.Infra.Data.Sql.Commands.Extensions.Part2.md)

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Infra.Data.Sql.Commands.Extensions.AuditableShadowProperties`

- **Kind:** `class`
- **Source:** `Onion/src/3.Infra/Data/Zamin.Infra.Data.Sql.Commands/Extensions/AuditableShadowProperties.cs`

کلاس «AuditableShadowProperties» در namespace Zamin.Infra.Data.Sql.Commands.Extensions. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین.

#### Members

##### `EFPropertyCreatedByUserId` (field)

```csharp
public static readonly Func<object, string> EFPropertyCreatedByUserId =
                                    entity => EF.Property<string>(entity, CreatedByUserId);
```

فیلد «EFPropertyCreatedByUserId» در AuditableShadowProperties با امضای `public static readonly Func<object, string> EFPropertyCreatedByUserId =
                                    entity => EF.Property<string>(entity, CreatedByUserId);`. برای نگهداری وضعیت داخلی/قابل‌دسترس نوع استفاده می‌شود.

##### `CreatedByUserId` (field)

```csharp
public static readonly string CreatedByUserId = nameof(CreatedByUserId);
```

فیلد «CreatedByUserId» در AuditableShadowProperties با امضای `public static readonly string CreatedByUserId = nameof(CreatedByUserId);`. برای نگهداری وضعیت داخلی/قابل‌دسترس نوع استفاده می‌شود.

##### `EFPropertyModifiedByUserId` (field)

```csharp
public static readonly Func<object, string> EFPropertyModifiedByUserId =
                                    entity => EF.Property<string>(entity, ModifiedByUserId);
```

فیلد «EFPropertyModifiedByUserId» در AuditableShadowProperties با امضای `public static readonly Func<object, string> EFPropertyModifiedByUserId =
                                    entity => EF.Property<string>(entity, ModifiedByUserId);`. برای نگهداری وضعیت داخلی/قابل‌دسترس نوع استفاده می‌شود.

##### `ModifiedByUserId` (field)

```csharp
public static readonly string ModifiedByUserId = nameof(ModifiedByUserId);
```

فیلد «ModifiedByUserId» در AuditableShadowProperties با امضای `public static readonly string ModifiedByUserId = nameof(ModifiedByUserId);`. برای نگهداری وضعیت داخلی/قابل‌دسترس نوع استفاده می‌شود.

##### `EFPropertyCreatedDateTime` (field)

```csharp
public static readonly Func<object, DateTime?> EFPropertyCreatedDateTime =
                                    entity => EF.Property<DateTime?>(entity, CreatedDateTime);
```

فیلد «EFPropertyCreatedDateTime» در AuditableShadowProperties با امضای `public static readonly Func<object, DateTime?> EFPropertyCreatedDateTime =
                                    entity => EF.Property<DateTime?>(entity, CreatedDateTime);`. برای نگهداری وضعیت داخلی/قابل‌دسترس نوع استفاده می‌شود.

##### `CreatedDateTime` (field)

```csharp
public static readonly string CreatedDateTime = nameof(CreatedDateTime);
```

فیلد «CreatedDateTime» در AuditableShadowProperties با امضای `public static readonly string CreatedDateTime = nameof(CreatedDateTime);`. برای نگهداری وضعیت داخلی/قابل‌دسترس نوع استفاده می‌شود.

##### `EFPropertyModifiedDateTime` (field)

```csharp
public static readonly Func<object, DateTime?> EFPropertyModifiedDateTime =
                                    entity => EF.Property<DateTime?>(entity, ModifiedDateTime);
```

فیلد «EFPropertyModifiedDateTime» در AuditableShadowProperties با امضای `public static readonly Func<object, DateTime?> EFPropertyModifiedDateTime =
                                    entity => EF.Property<DateTime?>(entity, ModifiedDateTime);`. برای نگهداری وضعیت داخلی/قابل‌دسترس نوع استفاده می‌شود.

##### `ModifiedDateTime` (field)

```csharp
public static readonly string ModifiedDateTime = nameof(ModifiedDateTime);
```

فیلد «ModifiedDateTime» در AuditableShadowProperties با امضای `public static readonly string ModifiedDateTime = nameof(ModifiedDateTime);`. برای نگهداری وضعیت داخلی/قابل‌دسترس نوع استفاده می‌شود.

##### `AddAuditableShadowProperties` (method)

```csharp
public static void AddAuditableShadowProperties(this ModelBuilder modelBuilder)
```

متد «AddAuditableShadowProperties» در AuditableShadowProperties. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- modelBuilder (ModelBuilder): ورودی از نوع ModelBuilder.

مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `SetAuditableEntityPropertyValues` (method)

```csharp
public static void SetAuditableEntityPropertyValues(
        this ChangeTracker changeTracker,
        IUserInfoService userInfoService)
```

متد «SetAuditableEntityPropertyValues» در AuditableShadowProperties. وضعیت را به‌روز یا ذخیره می‌کند.
پارامترها:
- changeTracker (ChangeTracker): ورودی از نوع ChangeTracker.
- userInfoService (IUserInfoService): ورودی از نوع IUserInfoService.

مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

### `Zamin.Infra.Data.Sql.Commands.Extensions.ChangeTrackerExtensions`

- **Kind:** `class`
- **Source:** `Onion/src/3.Infra/Data/Zamin.Infra.Data.Sql.Commands/Extensions/ChangeTrackerExtensions.cs`

کلاس «ChangeTrackerExtensions» در namespace Zamin.Infra.Data.Sql.Commands.Extensions. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

#### Members

##### `GetChangedAggregates` (method)

```csharp
public static List<AggregateRoot> GetChangedAggregates(this ChangeTracker changeTracker)
```

متد «GetChangedAggregates» در ChangeTrackerExtensions. داده یا وضعیت مرتبط را بازیابی می‌کند.
پارامترها:
- changeTracker (ChangeTracker): ورودی از نوع ChangeTracker.

مقدار بازگشتی: `List<AggregateRoot>`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `GetAggregatesWithEvent` (method)

```csharp
public static List<AggregateRoot> GetAggregatesWithEvent(this ChangeTracker changeTracker)
```

متد «GetAggregatesWithEvent» در ChangeTrackerExtensions. داده یا وضعیت مرتبط را بازیابی می‌کند.
پارامترها:
- changeTracker (ChangeTracker): ورودی از نوع ChangeTracker.

مقدار بازگشتی: `List<AggregateRoot>`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `Aggreates` (method)

```csharp
public static IEnumerable<EntityEntry<AggregateRoot>> Aggreates(this ChangeTracker changeTracker)
```

متد «Aggreates» در ChangeTrackerExtensions. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- changeTracker (ChangeTracker): ورودی از نوع ChangeTracker.

مقدار بازگشتی: `IEnumerable<EntityEntry<AggregateRoot>>`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

### `Zamin.Infra.Data.Sql.Commands.Extensions.DbCommandExtension`

- **Kind:** `class`
- **Source:** `Onion/src/3.Infra/Data/Zamin.Infra.Data.Sql.Commands/Extensions/DbCommandExtension.cs`

کلاس «DbCommandExtension» در namespace Zamin.Infra.Data.Sql.Commands.Extensions. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

#### Members

##### `ApplyCorrectYeKe` (method)

```csharp
public static void ApplyCorrectYeKe(this DbCommand command)
```

متد «ApplyCorrectYeKe» در DbCommandExtension. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- command (DbCommand): فرمان ورودی برای اجرا.

مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

### `Zamin.Infra.Data.Sql.Commands.Extensions.ModelBuilderExtensions`

- **Kind:** `class`
- **Source:** `Onion/src/3.Infra/Data/Zamin.Infra.Data.Sql.Commands/Extensions/ModelBuilderExtensions.cs`

کلاس «ModelBuilderExtensions» در namespace Zamin.Infra.Data.Sql.Commands.Extensions. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

#### Members

##### `AddBusinessId` (method)

```csharp
public static void AddBusinessId(this ModelBuilder modelBuilder)
```

متد «AddBusinessId» در ModelBuilderExtensions. سرویس‌ها/قابلیت مرتبط را به IServiceCollection ثبت می‌کند.
پارامترها:
- modelBuilder (ModelBuilder): ورودی از نوع ModelBuilder.

مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `UseValueConverterForType` (method)

```csharp
public static ModelBuilder UseValueConverterForType<T>(this ModelBuilder modelBuilder, ValueConverter converter, int maxLenght = 0)
```

متد «UseValueConverterForType» در ModelBuilderExtensions. میان‌افزار یا پیکربندی pipeline را به اپلیکیشن اضافه می‌کند.
پارامترها:
- modelBuilder (ModelBuilder): ورودی از نوع ModelBuilder.
- converter (ValueConverter): ورودی از نوع ValueConverter.
- maxLenght (int): ورودی اختیاری از نوع int (دارای مقدار پیش‌فرض).

مقدار بازگشتی: `ModelBuilder`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `UseValueConverterForType` (method)

```csharp
public static ModelBuilder UseValueConverterForType(this ModelBuilder modelBuilder, Type type, ValueConverter converter, int maxLength = 0)
```

متد «UseValueConverterForType» در ModelBuilderExtensions. میان‌افزار یا پیکربندی pipeline را به اپلیکیشن اضافه می‌کند.
پارامترها:
- modelBuilder (ModelBuilder): ورودی از نوع ModelBuilder.
- type (Type): ورودی از نوع Type.
- converter (ValueConverter): ورودی از نوع ValueConverter.
- maxLength (int): ورودی اختیاری از نوع int (دارای مقدار پیش‌فرض).

مقدار بازگشتی: `ModelBuilder`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
