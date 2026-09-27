# Zamin.Utilities.DateTimes (Part 1/9)

مرجع API برای namespace `Zamin.Utilities.DateTimes`.

- **Type count (this file):** 1
- **Parts:** **Part 1** · [Part 2](./Zamin.Utilities.DateTimes.Part2.md) · [Part 3](./Zamin.Utilities.DateTimes.Part3.md) · [Part 4](./Zamin.Utilities.DateTimes.Part4.md) · [Part 5](./Zamin.Utilities.DateTimes.Part5.md) · [Part 6](./Zamin.Utilities.DateTimes.Part6.md) · [Part 7](./Zamin.Utilities.DateTimes.Part7.md) · [Part 8](./Zamin.Utilities.DateTimes.Part8.md) · [Part 9](./Zamin.Utilities.DateTimes.Part9.md)

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Utilities.DateTimes.DateTimeOffsetPart`

- **Kind:** `enum`
- **Source:** `Onion/src/1.Utilities/Zamin.Utilities/DateTimes/DateTimeOffsetPart.cs`

DateTimeOffset Part سورس این بخش در ابتدا از مجموعه کارهای آقای وحید نصیری برداشته شده است. پس از تکمیل و اصلاحات نهایی آدرس دهی و ... اصلاح می‌شود

#### Members

##### `DateTime` (enum_member)

```csharp
DateTime
```

قسمت زمان مقدار را بدون توجه به آفست باز می‌گرداند و به زمان محلی سرور تبدیل نخواهد شد

##### `LocalDateTime` (enum_member)

```csharp
LocalDateTime
```

قسمت زمان را با توجه به منطقه زمانی سروری که برنامه بر روی آن اجرا می‌شود، بر می‌گرداند

##### `UtcDateTime` (enum_member)

```csharp
UtcDateTime
```

The Coordinated Universal Time (UTC) date and time of the current System.DateTimeOffset

##### `IranLocalDateTime` (enum_member)

```csharp
IranLocalDateTime
```

این وهله را به منطقه‌ی زمانی ایران تبدیل و مقدار را بر می‌گرداند
