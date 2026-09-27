# Zamin.Utilities.Guards.GuardClauses (Part 4/4)

مرجع API برای namespace `Zamin.Utilities.Guards.GuardClauses`.

- **Type count (this file):** 3
- **Parts:** [Part 1](./Zamin.Utilities.Guards.GuardClauses.Part1.md) · [Part 2](./Zamin.Utilities.Guards.GuardClauses.Part2.md) · [Part 3](./Zamin.Utilities.Guards.GuardClauses.Part3.md) · **Part 4**

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Utilities.Guards.GuardClauses.NotEqualGuardClause`

- **Kind:** `class`
- **Source:** `Onion/src/1.Utilities/Zamin.Utilities/Guards/GuardClauses/NotEqualGuardClause.cs`

کلاس «NotEqualGuardClause» در namespace Zamin.Utilities.Guards.GuardClauses. کمک‌کننده اعتبارسنجی ورودی و پیش‌شرط‌ها.

#### Members

##### `NotEqual` (method)

```csharp
public static void NotEqual<T>(this Guard guard, T value, T targetValue, string message)
```

متد «NotEqual» در NotEqualGuardClause. در صورت نقض شرط، استثنا پرتاب می‌کند تا از ادامه با ورودی نامعتبر جلوگیری شود.
پارامترها:
- guard (Guard): نمونه‌ی Guard برای فراخوانی زنجیره‌ای extension method.
- value (T): مقدار مورد بررسی/ورود.
- targetValue (T): مقدار مبنا برای مقایسه.
- message (string): پیام متنی خطا یا توضیح نقض شرط.

مقدار بازگشتی: ندارد (void).
استثناها (قابل تشخیص از کد):
- ArgumentNullException (throw new)
- InvalidOperationException (throw new)
- ArgumentNullException
- InvalidOperationException
پیش‌شرط/وابستگی: برای جلوگیری از ادامه با داده نامعتبر، معمولاً در ابتدای متدهای عمومی فراخوانی می‌شود

### `Zamin.Utilities.Guards.GuardClauses.NotNullGuardClause`

- **Kind:** `class`
- **Source:** `Onion/src/1.Utilities/Zamin.Utilities/Guards/GuardClauses/NotNullGuardClause.cs`

کلاس «NotNullGuardClause» در namespace Zamin.Utilities.Guards.GuardClauses. کمک‌کننده اعتبارسنجی ورودی و پیش‌شرط‌ها.

#### Members

##### `Null` (method)

```csharp
public static void Null<T>(this Guard guard, T value, string message)
```

متد «Null» در NotNullGuardClause. در صورت نقض شرط، استثنا پرتاب می‌کند تا از ادامه با ورودی نامعتبر جلوگیری شود.
پارامترها:
- guard (Guard): نمونه‌ی Guard برای فراخوانی زنجیره‌ای extension method.
- value (T): مقدار مورد بررسی/ورود.
- message (string): پیام متنی خطا یا توضیح نقض شرط.

مقدار بازگشتی: ندارد (void).
استثناها (قابل تشخیص از کد):
- ArgumentNullException (throw new)
- InvalidOperationException (throw new)
- ArgumentNullException
- InvalidOperationException
پیش‌شرط/وابستگی: برای جلوگیری از ادامه با داده نامعتبر، معمولاً در ابتدای متدهای عمومی فراخوانی می‌شود

### `Zamin.Utilities.Guards.GuardClauses.NullGuardClause`

- **Kind:** `class`
- **Source:** `Onion/src/1.Utilities/Zamin.Utilities/Guards/GuardClauses/NullGuardClause.cs`

کلاس «NullGuardClause» در namespace Zamin.Utilities.Guards.GuardClauses. کمک‌کننده اعتبارسنجی ورودی و پیش‌شرط‌ها.

#### Members

##### `Null` (method)

```csharp
public static void Null<T>(this Guard guard, T value, string message)
```

متد «Null» در NullGuardClause. در صورت نقض شرط، استثنا پرتاب می‌کند تا از ادامه با ورودی نامعتبر جلوگیری شود.
پارامترها:
- guard (Guard): نمونه‌ی Guard برای فراخوانی زنجیره‌ای extension method.
- value (T): مقدار مورد بررسی/ورود.
- message (string): پیام متنی خطا یا توضیح نقض شرط.

مقدار بازگشتی: ندارد (void).
استثناها (قابل تشخیص از کد):
- ArgumentNullException (throw new)
- InvalidOperationException (throw new)
- ArgumentNullException
- InvalidOperationException
پیش‌شرط/وابستگی: برای جلوگیری از ادامه با داده نامعتبر، معمولاً در ابتدای متدهای عمومی فراخوانی می‌شود
