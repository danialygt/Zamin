# Zamin.Utilities.Guards.GuardClauses (Part 2/4)

مرجع API برای namespace `Zamin.Utilities.Guards.GuardClauses`.

- **Type count (this file):** 4
- **Parts:** [Part 1](./Zamin.Utilities.Guards.GuardClauses.Part1.md) · **Part 2** · [Part 3](./Zamin.Utilities.Guards.GuardClauses.Part3.md) · [Part 4](./Zamin.Utilities.Guards.GuardClauses.Part4.md)

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Utilities.Guards.GuardClauses.GreaterThanOrEqualGuardClause`

- **Kind:** `class`
- **Source:** `Onion/src/1.Utilities/Zamin.Utilities/Guards/GuardClauses/GreaterThanOrEqualGuardClause.cs`

کلاس «GreaterThanOrEqualGuardClause» در namespace Zamin.Utilities.Guards.GuardClauses. کمک‌کننده اعتبارسنجی ورودی و پیش‌شرط‌ها.

#### Members

##### `GreaterThanOrEqual` (method)

```csharp
public static void GreaterThanOrEqual<T>(this Guard guard, T value, T minimumValue, IComparer<T> comparer, string message)
```

متد «GreaterThanOrEqual» در GreaterThanOrEqualGuardClause. در صورت نقض شرط، استثنا پرتاب می‌کند تا از ادامه با ورودی نامعتبر جلوگیری شود.
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

##### `GreaterThanOrEqual` (method)

```csharp
public static void GreaterThanOrEqual<T>(this Guard guard, T value, T minimumValue, string message) where T : IComparable<T>, IComparable
```

متد «GreaterThanOrEqual» در GreaterThanOrEqualGuardClause. در صورت نقض شرط، استثنا پرتاب می‌کند تا از ادامه با ورودی نامعتبر جلوگیری شود.
پارامترها:
- guard (Guard): نمونه‌ی Guard برای فراخوانی زنجیره‌ای extension method.
- value (T): مقدار مورد بررسی/ورود.
- minimumValue (T): ورودی از نوع T.
- message (string): پیام متنی خطا یا توضیح نقض شرط.

مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: برای جلوگیری از ادامه با داده نامعتبر، معمولاً در ابتدای متدهای عمومی فراخوانی می‌شود

### `Zamin.Utilities.Guards.GuardClauses.InclusiveBetweenGuardClause`

- **Kind:** `class`
- **Source:** `Onion/src/1.Utilities/Zamin.Utilities/Guards/GuardClauses/InclusiveBetweenGuardClause.cs`

کلاس «InclusiveBetweenGuardClause» در namespace Zamin.Utilities.Guards.GuardClauses. کمک‌کننده اعتبارسنجی ورودی و پیش‌شرط‌ها.

#### Members

##### `InclusiveBetween` (method)

```csharp
public static void InclusiveBetween<T>(this Guard guard, T value, T minimumValue, T maximumValue, IComparer<T> comparer, string message)
```

متد «InclusiveBetween» در InclusiveBetweenGuardClause. در صورت نقض شرط، استثنا پرتاب می‌کند تا از ادامه با ورودی نامعتبر جلوگیری شود.
پارامترها:
- guard (Guard): نمونه‌ی Guard برای فراخوانی زنجیره‌ای extension method.
- value (T): مقدار مورد بررسی/ورود.
- minimumValue (T): ورودی از نوع T.
- maximumValue (T): ورودی از نوع T.
- comparer (IComparer<T>): ورودی از نوع IComparer<T>.
- message (string): پیام متنی خطا یا توضیح نقض شرط.

مقدار بازگشتی: ندارد (void).
استثناها (قابل تشخیص از کد):
- ArgumentNullException (throw new)
- InvalidOperationException (throw new)
- ArgumentNullException
- InvalidOperationException
پیش‌شرط/وابستگی: برای جلوگیری از ادامه با داده نامعتبر، معمولاً در ابتدای متدهای عمومی فراخوانی می‌شود

##### `InclusiveBetween` (method)

```csharp
public static void InclusiveBetween<T>(this Guard guard, T value, T minimumValue, T maximumValue, string message) where T : IComparable<T>, IComparable
```

متد «InclusiveBetween» در InclusiveBetweenGuardClause. در صورت نقض شرط، استثنا پرتاب می‌کند تا از ادامه با ورودی نامعتبر جلوگیری شود.
پارامترها:
- guard (Guard): نمونه‌ی Guard برای فراخوانی زنجیره‌ای extension method.
- value (T): مقدار مورد بررسی/ورود.
- minimumValue (T): ورودی از نوع T.
- maximumValue (T): ورودی از نوع T.
- message (string): پیام متنی خطا یا توضیح نقض شرط.

مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: برای جلوگیری از ادامه با داده نامعتبر، معمولاً در ابتدای متدهای عمومی فراخوانی می‌شود

### `Zamin.Utilities.Guards.GuardClauses.LengthGuardClause`

- **Kind:** `class`
- **Source:** `Onion/src/1.Utilities/Zamin.Utilities/Guards/GuardClauses/LengthGuardClause.cs`

کلاس «LengthGuardClause» در namespace Zamin.Utilities.Guards.GuardClauses. کمک‌کننده اعتبارسنجی ورودی و پیش‌شرط‌ها.

#### Members

##### `Length` (method)

```csharp
public static void Length(this Guard guard, string value, int length, string message)
```

متد «Length» در LengthGuardClause. در صورت نقض شرط، استثنا پرتاب می‌کند تا از ادامه با ورودی نامعتبر جلوگیری شود.
پارامترها:
- guard (Guard): نمونه‌ی Guard برای فراخوانی زنجیره‌ای extension method.
- value (string): مقدار مورد بررسی/ورود.
- length (int): ورودی از نوع int.
- message (string): پیام متنی خطا یا توضیح نقض شرط.

مقدار بازگشتی: ندارد (void).
استثناها (قابل تشخیص از کد):
- ArgumentNullException (throw new)
- InvalidOperationException (throw new)
- ArgumentNullException
- InvalidOperationException
پیش‌شرط/وابستگی: برای جلوگیری از ادامه با داده نامعتبر، معمولاً در ابتدای متدهای عمومی فراخوانی می‌شود

##### `Length` (method)

```csharp
public static void Length(this Guard guard, ICollection value, int length, string message)
```

متد «Length» در LengthGuardClause. در صورت نقض شرط، استثنا پرتاب می‌کند تا از ادامه با ورودی نامعتبر جلوگیری شود.
پارامترها:
- guard (Guard): نمونه‌ی Guard برای فراخوانی زنجیره‌ای extension method.
- value (ICollection): مقدار مورد بررسی/ورود.
- length (int): ورودی از نوع int.
- message (string): پیام متنی خطا یا توضیح نقض شرط.

مقدار بازگشتی: ندارد (void).
استثناها (قابل تشخیص از کد):
- ArgumentNullException (throw new)
- InvalidOperationException (throw new)
- ArgumentNullException
- InvalidOperationException
پیش‌شرط/وابستگی: برای جلوگیری از ادامه با داده نامعتبر، معمولاً در ابتدای متدهای عمومی فراخوانی می‌شود

### `Zamin.Utilities.Guards.GuardClauses.LessThanGuardClause`

- **Kind:** `class`
- **Source:** `Onion/src/1.Utilities/Zamin.Utilities/Guards/GuardClauses/LessThanGuardClause.cs`

کلاس «LessThanGuardClause» در namespace Zamin.Utilities.Guards.GuardClauses. کمک‌کننده اعتبارسنجی ورودی و پیش‌شرط‌ها.

#### Members

##### `LessThan` (method)

```csharp
public static void LessThan<T>(this Guard guard, T value, T maximumValue, IComparer<T> comparer, string message)
```

متد «LessThan» در LessThanGuardClause. در صورت نقض شرط، استثنا پرتاب می‌کند تا از ادامه با ورودی نامعتبر جلوگیری شود.
پارامترها:
- guard (Guard): نمونه‌ی Guard برای فراخوانی زنجیره‌ای extension method.
- value (T): مقدار مورد بررسی/ورود.
- maximumValue (T): ورودی از نوع T.
- comparer (IComparer<T>): ورودی از نوع IComparer<T>.
- message (string): پیام متنی خطا یا توضیح نقض شرط.

مقدار بازگشتی: ندارد (void).
استثناها (قابل تشخیص از کد):
- ArgumentNullException (throw new)
- InvalidOperationException (throw new)
- ArgumentNullException
- InvalidOperationException
پیش‌شرط/وابستگی: برای جلوگیری از ادامه با داده نامعتبر، معمولاً در ابتدای متدهای عمومی فراخوانی می‌شود

##### `LessThan` (method)

```csharp
public static void LessThan<T>(this Guard guard, T value, T maximumValue, string message) where T : IComparable<T>, IComparable
```

متد «LessThan» در LessThanGuardClause. در صورت نقض شرط، استثنا پرتاب می‌کند تا از ادامه با ورودی نامعتبر جلوگیری شود.
پارامترها:
- guard (Guard): نمونه‌ی Guard برای فراخوانی زنجیره‌ای extension method.
- value (T): مقدار مورد بررسی/ورود.
- maximumValue (T): ورودی از نوع T.
- message (string): پیام متنی خطا یا توضیح نقض شرط.

مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: برای جلوگیری از ادامه با داده نامعتبر، معمولاً در ابتدای متدهای عمومی فراخوانی می‌شود
