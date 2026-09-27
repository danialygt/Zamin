# Zamin.Utilities.Extensions (Part 4/4)

مرجع API برای namespace `Zamin.Utilities.Extensions`.

- **Type count (this file):** 2
- **Parts:** [Part 1](./Zamin.Utilities.Extensions.Part1.md) · [Part 2](./Zamin.Utilities.Extensions.Part2.md) · [Part 3](./Zamin.Utilities.Extensions.Part3.md) · **Part 4**

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Utilities.Extensions.StringValidatorExtensions`

- **Kind:** `class`
- **Source:** `Onion/src/1.Utilities/Zamin.Utilities/Extensions/StringValidatorExtensions.cs`

کلاس «StringValidatorExtensions» در namespace Zamin.Utilities.Extensions. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

#### Members

##### `IsNationalCode` (method)

```csharp
public static bool IsNationalCode(this string nationalCode)
```

صحت سنجی کد ملی
پارامترها:
- input: کد ملی
مقدار بازگشتی: درست یا غلط

##### `IsLegalNationalIdValid` (method)

```csharp
public static bool IsLegalNationalIdValid(this string nationalId)
```

صحت سنجی شناسه ملی شرکت‌ها
پارامترها:
- nationalId: (بدون توضیح)

مقدار بازگشتی: `bool`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `IsNumeric` (method)

```csharp
public static bool IsNumeric(this string nationalCode)
```

متد «IsNumeric» در StringValidatorExtensions. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- nationalCode (string): ورودی از نوع string.

مقدار بازگشتی: `bool`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `IsLengthBetween` (method)

```csharp
public static bool IsLengthBetween(this string input, int minLength, int maxLenght)
```

متد «IsLengthBetween» در StringValidatorExtensions. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- input (string): مقدار مورد بررسی/ورود.
- minLength (int): ورودی از نوع int.
- maxLenght (int): ورودی از نوع int.

مقدار بازگشتی: `bool`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `IsLengthLessThan` (method)

```csharp
public static bool IsLengthLessThan(this string input, int lenght)
```

متد «IsLengthLessThan» در StringValidatorExtensions. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- input (string): مقدار مورد بررسی/ورود.
- lenght (int): ورودی از نوع int.

مقدار بازگشتی: `bool`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `IsLengthLessThanOrEqual` (method)

```csharp
public static bool IsLengthLessThanOrEqual(this string input, int lenght)
```

متد «IsLengthLessThanOrEqual» در StringValidatorExtensions. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- input (string): مقدار مورد بررسی/ورود.
- lenght (int): ورودی از نوع int.

مقدار بازگشتی: `bool`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `IsLengthGreaterThan` (method)

```csharp
public static bool IsLengthGreaterThan(this string input, int lenght)
```

متد «IsLengthGreaterThan» در StringValidatorExtensions. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- input (string): مقدار مورد بررسی/ورود.
- lenght (int): ورودی از نوع int.

مقدار بازگشتی: `bool`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `IsLengthGreaterThanOrEqual` (method)

```csharp
public static bool IsLengthGreaterThanOrEqual(this string input, int lenght)
```

متد «IsLengthGreaterThanOrEqual» در StringValidatorExtensions. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- input (string): مقدار مورد بررسی/ورود.
- lenght (int): ورودی از نوع int.

مقدار بازگشتی: `bool`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `IsLengthEqual` (method)

```csharp
public static bool IsLengthEqual(this string input, int lenght)
```

متد «IsLengthEqual» در StringValidatorExtensions. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- input (string): مقدار مورد بررسی/ورود.
- lenght (int): ورودی از نوع int.

مقدار بازگشتی: `bool`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

### `Zamin.Utilities.Extensions.TypeExtentsions`

- **Kind:** `class`
- **Source:** `Onion/src/1.Utilities/Zamin.Utilities/Extensions/TypeExtentsions.cs`

کلاس «TypeExtentsions» در namespace Zamin.Utilities.Extensions. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین.

#### Members

##### `IsSubclassOfRawGeneric` (method)

```csharp
public static bool IsSubclassOfRawGeneric(this Type toCheck, Type generic)
```

متد «IsSubclassOfRawGeneric» در TypeExtentsions. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- toCheck (Type): ورودی از نوع Type.
- generic (Type): ورودی از نوع Type.

مقدار بازگشتی: `bool`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
