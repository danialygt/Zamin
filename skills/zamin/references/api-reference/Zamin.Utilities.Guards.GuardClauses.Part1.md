# Zamin.Utilities.Guards.GuardClauses (Part 1/4)

مرجع API برای namespace `Zamin.Utilities.Guards.GuardClauses`.

- **Type count (this file):** 4
- **Parts:** **Part 1** · [Part 2](./Zamin.Utilities.Guards.GuardClauses.Part2.md) · [Part 3](./Zamin.Utilities.Guards.GuardClauses.Part3.md) · [Part 4](./Zamin.Utilities.Guards.GuardClauses.Part4.md)

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Utilities.Guards.GuardClauses.EmptyGuardClause`

- **Kind:** `class`
- **Source:** `Onion/src/1.Utilities/Zamin.Utilities/Guards/GuardClauses/EmptyGuardClause.cs`

کلاس «EmptyGuardClause» در namespace Zamin.Utilities.Guards.GuardClauses. کمک‌کننده اعتبارسنجی ورودی و پیش‌شرط‌ها.

#### Members

##### `Empty` (method)

```csharp
public static void Empty<T>(this Guard guard, T value, string message)
```

متد «Empty» در EmptyGuardClause. در صورت نقض شرط، استثنا پرتاب می‌کند تا از ادامه با ورودی نامعتبر جلوگیری شود.
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

##### `Empty` (method)

```csharp
public static void Empty<T>(this Guard guard, T value, IEqualityComparer<T> equalityComparer, string message)
```

متد «Empty» در EmptyGuardClause. در صورت نقض شرط، استثنا پرتاب می‌کند تا از ادامه با ورودی نامعتبر جلوگیری شود.
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

### `Zamin.Utilities.Guards.GuardClauses.EqualGuardClause`

- **Kind:** `class`
- **Source:** `Onion/src/1.Utilities/Zamin.Utilities/Guards/GuardClauses/EqualGuardClause.cs`

کلاس «EqualGuardClause» در namespace Zamin.Utilities.Guards.GuardClauses. کمک‌کننده اعتبارسنجی ورودی و پیش‌شرط‌ها.

#### Members

##### `Equal` (method)

```csharp
public static void Equal<T>(this Guard guard, T value, T targetValue, string message)
```

متد «Equal» در EqualGuardClause. در صورت نقض شرط، استثنا پرتاب می‌کند تا از ادامه با ورودی نامعتبر جلوگیری شود.
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

##### `Equal` (method)

```csharp
public static void Equal<T>(this Guard guard, T value, T targetValue, IEqualityComparer<T> equalityComparer, string message)
```

متد «Equal» در EqualGuardClause. در صورت نقض شرط، استثنا پرتاب می‌کند تا از ادامه با ورودی نامعتبر جلوگیری شود.
پارامترها:
- guard (Guard): نمونه‌ی Guard برای فراخوانی زنجیره‌ای extension method.
- value (T): مقدار مورد بررسی/ورود.
- targetValue (T): مقدار مبنا برای مقایسه.
- equalityComparer (IEqualityComparer<T>): ورودی از نوع IEqualityComparer<T>.
- message (string): پیام متنی خطا یا توضیح نقض شرط.

مقدار بازگشتی: ندارد (void).
استثناها (قابل تشخیص از کد):
- ArgumentNullException (throw new)
- InvalidOperationException (throw new)
- ArgumentNullException
- InvalidOperationException
پیش‌شرط/وابستگی: برای جلوگیری از ادامه با داده نامعتبر، معمولاً در ابتدای متدهای عمومی فراخوانی می‌شود

### `Zamin.Utilities.Guards.GuardClauses.ExclusiveBetweenGuardClause`

- **Kind:** `class`
- **Source:** `Onion/src/1.Utilities/Zamin.Utilities/Guards/GuardClauses/ExclusiveBetweenGuardClause.cs`

کلاس «ExclusiveBetweenGuardClause» در namespace Zamin.Utilities.Guards.GuardClauses. کمک‌کننده اعتبارسنجی ورودی و پیش‌شرط‌ها.

#### Members

##### `ExclusiveBetween` (method)

```csharp
public static void ExclusiveBetween<T>(this Guard guard, T value, T minimumValue, T maximumValue, IComparer<T> comparer, string message)
```

متد «ExclusiveBetween» در ExclusiveBetweenGuardClause. در صورت نقض شرط، استثنا پرتاب می‌کند تا از ادامه با ورودی نامعتبر جلوگیری شود.
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

##### `ExclusiveBetween` (method)

```csharp
public static void ExclusiveBetween<T>(this Guard guard, T value, T minimumValue, T maximumValue, string message) where T : IComparable<T>, IComparable
```

متد «ExclusiveBetween» در ExclusiveBetweenGuardClause. در صورت نقض شرط، استثنا پرتاب می‌کند تا از ادامه با ورودی نامعتبر جلوگیری شود.
پارامترها:
- guard (Guard): نمونه‌ی Guard برای فراخوانی زنجیره‌ای extension method.
- value (T): مقدار مورد بررسی/ورود.
- minimumValue (T): ورودی از نوع T.
- maximumValue (T): ورودی از نوع T.
- message (string): پیام متنی خطا یا توضیح نقض شرط.

مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: برای جلوگیری از ادامه با داده نامعتبر، معمولاً در ابتدای متدهای عمومی فراخوانی می‌شود

### `Zamin.Utilities.Guards.GuardClauses.GreaterThanGuardClause`

- **Kind:** `class`
- **Source:** `Onion/src/1.Utilities/Zamin.Utilities/Guards/GuardClauses/GreaterThanGuardClause.cs`

کلاس «GreaterThanGuardClause» در namespace Zamin.Utilities.Guards.GuardClauses. کمک‌کننده اعتبارسنجی ورودی و پیش‌شرط‌ها.

#### Members

##### `GreaterThan` (method)

```csharp
public static void GreaterThan<T>(this Guard guard, T value, T minimumValue, IComparer<T> comparer, string message)
```

متد «GreaterThan» در GreaterThanGuardClause. در صورت نقض شرط، استثنا پرتاب می‌کند تا از ادامه با ورودی نامعتبر جلوگیری شود.
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

##### `GreaterThan` (method)

```csharp
public static void GreaterThan<T>(this Guard guard, T value, T minimumValue, string message) where T : IComparable<T>, IComparable
```

متد «GreaterThan» در GreaterThanGuardClause. در صورت نقض شرط، استثنا پرتاب می‌کند تا از ادامه با ورودی نامعتبر جلوگیری شود.
پارامترها:
- guard (Guard): نمونه‌ی Guard برای فراخوانی زنجیره‌ای extension method.
- value (T): مقدار مورد بررسی/ورود.
- minimumValue (T): ورودی از نوع T.
- message (string): پیام متنی خطا یا توضیح نقض شرط.

مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: برای جلوگیری از ادامه با داده نامعتبر، معمولاً در ابتدای متدهای عمومی فراخوانی می‌شود
