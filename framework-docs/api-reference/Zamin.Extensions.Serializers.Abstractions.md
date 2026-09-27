# Zamin.Extensions.Serializers.Abstractions

مرجع API برای namespace `Zamin.Extensions.Serializers.Abstractions`.

- **Type count (this file):** 2

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Extensions.Serializers.Abstractions.IExcelSerializer`

- **Kind:** `interface`
- **Source:** `Extentsions/Zamin.Extensions.Abstractions/Zamin.Extensions.Serializers.Abstractions/IExcelSerializer.cs`

قرارداد (اینترفیس) «IExcelSerializer» در namespace Zamin.Extensions.Serializers.Abstractions. قرارداد رفتار برای مصرف‌کنندگان و پیاده‌سازی‌های جایگزین.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/dependency-injection.md#recipe-serializer-mapper)

#### Members

##### `ListToExcelByteArray` (method)

```csharp
byte[] ListToExcelByteArray<T>(List<T> list, string sheetName = "Result")
```

متد «ListToExcelByteArray» در IExcelSerializer. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- list (List<T>): ورودی از نوع List<T>.
- sheetName (string): ورودی اختیاری از نوع string (دارای مقدار پیش‌فرض).

مقدار بازگشتی: `byte[]`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `ExcelToDataTable` (method)

```csharp
DataTable ExcelToDataTable(byte[] bytes)
```

متد «ExcelToDataTable» در IExcelSerializer. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
بدون پارامتر ورودی.
مقدار بازگشتی: `DataTable`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `ExcelToList` (method)

```csharp
List<T> ExcelToList<T>(byte[] bytes)
```

متد «ExcelToList» در IExcelSerializer. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
بدون پارامتر ورودی.
مقدار بازگشتی: `List<T>`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

### `Zamin.Extensions.Serializers.Abstractions.IJsonSerializer`

- **Kind:** `interface`
- **Source:** `Extentsions/Zamin.Extensions.Abstractions/Zamin.Extensions.Serializers.Abstractions/IJsonSerializer.cs`

قرارداد (اینترفیس) «IJsonSerializer» در namespace Zamin.Extensions.Serializers.Abstractions. قرارداد رفتار برای مصرف‌کنندگان و پیاده‌سازی‌های جایگزین.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/dependency-injection.md#recipe-serializer-mapper)

#### Members

##### `Serialize` (method)

```csharp
string Serialize<TInput>(TInput input)
```

متد «Serialize» در IJsonSerializer. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- input (TInput): مقدار مورد بررسی/ورود.

مقدار بازگشتی: `string`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `Deserialize` (method)

```csharp
TOutput Deserialize<TOutput>(string input)
```

متد «Deserialize» در IJsonSerializer. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- input (string): مقدار مورد بررسی/ورود.

مقدار بازگشتی: `TOutput`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `Deserialize` (method)

```csharp
object Deserialize(string input, Type type)
```

متد «Deserialize» در IJsonSerializer. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- input (string): مقدار مورد بررسی/ورود.
- type (Type): ورودی از نوع Type.

مقدار بازگشتی: `object`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
