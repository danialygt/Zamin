# Zamin.Extensions.Translations.Abstractions

مرجع API برای namespace `Zamin.Extensions.Translations.Abstractions`.

- **Type count (this file):** 1

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Extensions.Translations.Abstractions.ITranslator`

- **Kind:** `interface`
- **Source:** `Extentsions/Zamin.Extensions.Abstractions/Zamin.Extensions.Translations.Abstractions/ITranslator.cs`

قرارداد (اینترفیس) «ITranslator» در namespace Zamin.Extensions.Translations.Abstractions. قرارداد رفتار برای مصرف‌کنندگان و پیاده‌سازی‌های جایگزین.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/common-recipes.md#recipe-translator)

#### Members

##### `this` (indexer)

```csharp
string this[string name] { get; set; }
```

ایندکسر «this» در ITranslator. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
بدون پارامتر ورودی.
مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `this` (indexer)

```csharp
string this[CultureInfo culture, string name] { get; set; }
```

ایندکسر «this» در ITranslator. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
بدون پارامتر ورودی.
مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `this` (indexer)

```csharp
string this[string name, params string[] arguments] { get; set; }
```

ایندکسر «this» در ITranslator. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
بدون پارامتر ورودی.
مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `this` (indexer)

```csharp
string this[CultureInfo culture, string name, params string[] arguments] { get; set; }
```

ایندکسر «this» در ITranslator. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
بدون پارامتر ورودی.
مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `this` (indexer)

```csharp
string this[char separator, params string[] names] { get; set; }
```

ایندکسر «this» در ITranslator. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
بدون پارامتر ورودی.
مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `this` (indexer)

```csharp
string this[CultureInfo culture, char separator, params string[] names] { get; set; }
```

ایندکسر «this» در ITranslator. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
بدون پارامتر ورودی.
مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `GetString` (method)

```csharp
string GetString(string name)
```

متد «GetString» در ITranslator. داده یا وضعیت مرتبط را بازیابی می‌کند.
پارامترها:
- name (string): ورودی از نوع string.

مقدار بازگشتی: `string`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `GetString` (method)

```csharp
string GetString(CultureInfo culture,string name)
```

متد «GetString» در ITranslator. داده یا وضعیت مرتبط را بازیابی می‌کند.
پارامترها:
- culture (CultureInfo): ورودی از نوع CultureInfo.
- name (string): ورودی از نوع string.

مقدار بازگشتی: `string`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `GetString` (method)

```csharp
string GetString(string pattern, params string[] arguments)
```

متد «GetString» در ITranslator. داده یا وضعیت مرتبط را بازیابی می‌کند.
پارامترها:
- pattern (string): ورودی از نوع string.

مقدار بازگشتی: `string`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `GetString` (method)

```csharp
string GetString(CultureInfo culture, string pattern, params string[] arguments)
```

متد «GetString» در ITranslator. داده یا وضعیت مرتبط را بازیابی می‌کند.
پارامترها:
- culture (CultureInfo): ورودی از نوع CultureInfo.
- pattern (string): ورودی از نوع string.

مقدار بازگشتی: `string`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `GetConcateString` (method)

```csharp
string GetConcateString(char separator = ' ', params string[] names)
```

متد «GetConcateString» در ITranslator. داده یا وضعیت مرتبط را بازیابی می‌کند.
پارامترها:
- separator (char): ورودی اختیاری از نوع char (دارای مقدار پیش‌فرض).

مقدار بازگشتی: `string`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `GetConcateString` (method)

```csharp
string GetConcateString(CultureInfo culture, char separator = ' ', params string[] names)
```

متد «GetConcateString» در ITranslator. داده یا وضعیت مرتبط را بازیابی می‌کند.
پارامترها:
- culture (CultureInfo): ورودی از نوع CultureInfo.
- separator (char): ورودی اختیاری از نوع char (دارای مقدار پیش‌فرض).

مقدار بازگشتی: `string`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
