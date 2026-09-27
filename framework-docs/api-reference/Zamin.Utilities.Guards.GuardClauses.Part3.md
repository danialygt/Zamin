# Zamin.Utilities.Guards.GuardClauses (Part 3/4)

مرجع API برای namespace `Zamin.Utilities.Guards.GuardClauses`.

- **Type count (this file):** 5
- **Parts:** [Part 1](./Zamin.Utilities.Guards.GuardClauses.Part1.md) · [Part 2](./Zamin.Utilities.Guards.GuardClauses.Part2.md) · **Part 3** · [Part 4](./Zamin.Utilities.Guards.GuardClauses.Part4.md)

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Utilities.Guards.GuardClauses.LessThanOrEqualGuardClause`

- **Kind:** `class`
- **Source:** `Onion/src/1.Utilities/Zamin.Utilities/Guards/GuardClauses/LessThanOrEqualGuardClause.cs`

کلاس «LessThanOrEqualGuardClause» در namespace Zamin.Utilities.Guards.GuardClauses. کمک‌کننده اعتبارسنجی ورودی و پیش‌شرط‌ها.

#### Members

##### `LessThanOrEqual` (method)

```csharp
public static void LessThanOrEqual<T>(this Guard guard, T value, T minimumValue, IComparer<T> comparer, string message)
```

متد «LessThanOrEqual» در LessThanOrEqualGuardClause. در صورت نقض شرط، استثنا پرتاب می‌کند تا از ادامه با ورودی نامعتبر جلوگیری شود.
پارامترها:
- guard (Guard): نمونه‌ی Guard برای فراخوانی زنجیره‌ای extension method.
- value (T): مقدار مورد بررسی/ورود.
- minimumValue (T): ورودی از نوع T.
- comparer (IComparer<T>): ورودی از نوع IComparer<T>.
- message (string): پیام متنی خطا یا توضیح نقض شرط.

مقدار بازگشتی: ندارد (void).
استثناها (قابل تشخیص از کد):
- ArgumentNullException (throw new)
- InvalidOperationException (throw new)
- ArgumentNullException
- InvalidOperationException
پیش‌شرط/وابستگی: برای جلوگیری از ادامه با داده نامعتبر، معمولاً در ابتدای متدهای عمومی فراخوانی می‌شود

##### `LessThanOrEqual` (method)

```csharp
public static void LessThanOrEqual<T>(this Guard guard, T value, T minimumValue, string message) where T : IComparable<T>, IComparable
```

متد «LessThanOrEqual» در LessThanOrEqualGuardClause. در صورت نقض شرط، استثنا پرتاب می‌کند تا از ادامه با ورودی نامعتبر جلوگیری شود.
پارامترها:
- guard (Guard): نمونه‌ی Guard برای فراخوانی زنجیره‌ای extension method.
- value (T): مقدار مورد بررسی/ورود.
- minimumValue (T): ورودی از نوع T.
- message (string): پیام متنی خطا یا توضیح نقض شرط.

مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: برای جلوگیری از ادامه با داده نامعتبر، معمولاً در ابتدای متدهای عمومی فراخوانی می‌شود

### `Zamin.Utilities.Guards.GuardClauses.MatchGuardClause`

- **Kind:** `class`
- **Source:** `Onion/src/1.Utilities/Zamin.Utilities/Guards/GuardClauses/MatchGuardClause.cs`

کلاس «MatchGuardClause» در namespace Zamin.Utilities.Guards.GuardClauses. کمک‌کننده اعتبارسنجی ورودی و پیش‌شرط‌ها.

#### Members

##### `Match` (method)

```csharp
public static void Match(this Guard guard, string value, string pattern, string message)
```

متد «Match» در MatchGuardClause. در صورت نقض شرط، استثنا پرتاب می‌کند تا از ادامه با ورودی نامعتبر جلوگیری شود.
پارامترها:
- guard (Guard): نمونه‌ی Guard برای فراخوانی زنجیره‌ای extension method.
- value (string): مقدار مورد بررسی/ورود.
- pattern (string): ورودی از نوع string.
- message (string): پیام متنی خطا یا توضیح نقض شرط.

مقدار بازگشتی: ندارد (void).
استثناها (قابل تشخیص از کد):
- ArgumentNullException (throw new)
- InvalidOperationException (throw new)
- ArgumentNullException
- InvalidOperationException
پیش‌شرط/وابستگی: برای جلوگیری از ادامه با داده نامعتبر، معمولاً در ابتدای متدهای عمومی فراخوانی می‌شود

### `Zamin.Utilities.Guards.GuardClauses.MaximumLengthGuardClause`

- **Kind:** `class`
- **Source:** `Onion/src/1.Utilities/Zamin.Utilities/Guards/GuardClauses/MaximumLengthGuardClause.cs`

کلاس «MaximumLengthGuardClause» در namespace Zamin.Utilities.Guards.GuardClauses. کمک‌کننده اعتبارسنجی ورودی و پیش‌شرط‌ها.

#### Members

##### `MaximumLength` (method)

```csharp
public static void MaximumLength(this Guard guard, string value, int maximumLength, string message)
```

متد «MaximumLength» در MaximumLengthGuardClause. در صورت نقض شرط، استثنا پرتاب می‌کند تا از ادامه با ورودی نامعتبر جلوگیری شود.
پارامترها:
- guard (Guard): نمونه‌ی Guard برای فراخوانی زنجیره‌ای extension method.
- value (string): مقدار مورد بررسی/ورود.
- maximumLength (int): ورودی از نوع int.
- message (string): پیام متنی خطا یا توضیح نقض شرط.

مقدار بازگشتی: ندارد (void).
استثناها (قابل تشخیص از کد):
- ArgumentNullException (throw new)
- InvalidOperationException (throw new)
- ArgumentNullException
- InvalidOperationException
پیش‌شرط/وابستگی: برای جلوگیری از ادامه با داده نامعتبر، معمولاً در ابتدای متدهای عمومی فراخوانی می‌شود

##### `MaximumLength` (method)

```csharp
public static void MaximumLength(this Guard guard, ICollection value, int maximumLength, string message)
```

متد «MaximumLength» در MaximumLengthGuardClause. در صورت نقض شرط، استثنا پرتاب می‌کند تا از ادامه با ورودی نامعتبر جلوگیری شود.
پارامترها:
- guard (Guard): نمونه‌ی Guard برای فراخوانی زنجیره‌ای extension method.
- value (ICollection): مقدار مورد بررسی/ورود.
- maximumLength (int): ورودی از نوع int.
- message (string): پیام متنی خطا یا توضیح نقض شرط.

مقدار بازگشتی: ندارد (void).
استثناها (قابل تشخیص از کد):
- ArgumentNullException (throw new)
- InvalidOperationException (throw new)
- ArgumentNullException
- InvalidOperationException
پیش‌شرط/وابستگی: برای جلوگیری از ادامه با داده نامعتبر، معمولاً در ابتدای متدهای عمومی فراخوانی می‌شود

### `Zamin.Utilities.Guards.GuardClauses.MinimumLengthGuardClause`

- **Kind:** `class`
- **Source:** `Onion/src/1.Utilities/Zamin.Utilities/Guards/GuardClauses/MinimumLengthGuardClause.cs`

کلاس «MinimumLengthGuardClause» در namespace Zamin.Utilities.Guards.GuardClauses. کمک‌کننده اعتبارسنجی ورودی و پیش‌شرط‌ها.

#### Members

##### `MinimumLength` (method)

```csharp
public static void MinimumLength(this Guard guard, string value, int minimumLength, string message)
```

متد «MinimumLength» در MinimumLengthGuardClause. در صورت نقض شرط، استثنا پرتاب می‌کند تا از ادامه با ورودی نامعتبر جلوگیری شود.
پارامترها:
- guard (Guard): نمونه‌ی Guard برای فراخوانی زنجیره‌ای extension method.
- value (string): مقدار مورد بررسی/ورود.
- minimumLength (int): ورودی از نوع int.
- message (string): پیام متنی خطا یا توضیح نقض شرط.

مقدار بازگشتی: ندارد (void).
استثناها (قابل تشخیص از کد):
- ArgumentNullException (throw new)
- InvalidOperationException (throw new)
- ArgumentNullException
- InvalidOperationException
پیش‌شرط/وابستگی: برای جلوگیری از ادامه با داده نامعتبر، معمولاً در ابتدای متدهای عمومی فراخوانی می‌شود

##### `MinimumLength` (method)

```csharp
public static void MinimumLength<T>(this Guard guard, ICollection value, int minimumLength, string message)
```

متد «MinimumLength» در MinimumLengthGuardClause. در صورت نقض شرط، استثنا پرتاب می‌کند تا از ادامه با ورودی نامعتبر جلوگیری شود.
پارامترها:
- guard (Guard): نمونه‌ی Guard برای فراخوانی زنجیره‌ای extension method.
- value (ICollection): مقدار مورد بررسی/ورود.
- minimumLength (int): ورودی از نوع int.
- message (string): پیام متنی خطا یا توضیح نقض شرط.

مقدار بازگشتی: ندارد (void).
استثناها (قابل تشخیص از کد):
- ArgumentNullException (throw new)
- InvalidOperationException (throw new)
- ArgumentNullException
- InvalidOperationException
پیش‌شرط/وابستگی: برای جلوگیری از ادامه با داده نامعتبر، معمولاً در ابتدای متدهای عمومی فراخوانی می‌شود

### `Zamin.Utilities.Guards.GuardClauses.NotEmptyGuardClause`

- **Kind:** `class`
- **Source:** `Onion/src/1.Utilities/Zamin.Utilities/Guards/GuardClauses/NotEmptyGuardClause.cs`

کلاس «NotEmptyGuardClause» در namespace Zamin.Utilities.Guards.GuardClauses. کمک‌کننده اعتبارسنجی ورودی و پیش‌شرط‌ها.

#### Members

##### `NotEmpty` (method)

```csharp
public static void NotEmpty<T>(this Guard guard, T value, string message)
```

متد «NotEmpty» در NotEmptyGuardClause. در صورت نقض شرط، استثنا پرتاب می‌کند تا از ادامه با ورودی نامعتبر جلوگیری شود.
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

##### `NotEmpty` (method)

```csharp
public static void NotEmpty<T>(this Guard guard, T value, IEqualityComparer<T> equalityComparer, string message)
```

متد «NotEmpty» در NotEmptyGuardClause. در صورت نقض شرط، استثنا پرتاب می‌کند تا از ادامه با ورودی نامعتبر جلوگیری شود.
پارامترها:
- guard (Guard): نمونه‌ی Guard برای فراخوانی زنجیره‌ای extension method.
- value (T): مقدار مورد بررسی/ورود.
- equalityComparer (IEqualityComparer<T>): ورودی از نوع IEqualityComparer<T>.
- message (string): پیام متنی خطا یا توضیح نقض شرط.

مقدار بازگشتی: ندارد (void).
استثناها (قابل تشخیص از کد):
- ArgumentNullException (throw new)
- InvalidOperationException (throw new)
- ArgumentNullException
- InvalidOperationException
پیش‌شرط/وابستگی: برای جلوگیری از ادامه با داده نامعتبر، معمولاً در ابتدای متدهای عمومی فراخوانی می‌شود
