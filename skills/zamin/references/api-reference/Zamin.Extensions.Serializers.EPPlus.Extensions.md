# Zamin.Extensions.Serializers.EPPlus.Extensions

مرجع API برای namespace `Zamin.Extensions.Serializers.EPPlus.Extensions`.

- **Type count (this file):** 2

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Extensions.Serializers.EPPlus.Extensions.ExcelExtensions`

- **Kind:** `class`
- **Source:** `Extentsions/Serializers/Zamin.Extensions.Serializers.EPPlus/Zamin.Extensions.Serializers.EPPlus/Extensions/ExcelExtentions.cs`

کلاس «ExcelExtensions» در namespace Zamin.Extensions.Serializers.EPPlus.Extensions. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

#### Members

##### `ToExcelByteArray` (method)

```csharp
public static byte[] ToExcelByteArray<T>(this List<T> list, ITranslator translator, string sheetName = "Result")
```

متد «ToExcelByteArray» در ExcelExtensions. تبدیل/نرمال‌سازی داده را طبق نام متد انجام می‌دهد.
پارامترها:
- list (List<T>): ورودی از نوع List<T>.
- translator (ITranslator): ورودی از نوع ITranslator.
- sheetName (string): ورودی اختیاری از نوع string (دارای مقدار پیش‌فرض).

مقدار بازگشتی: `byte[]`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `ToDataTableFromExcel` (method)

```csharp
public static DataTable ToDataTableFromExcel(this byte[] bytes)
```

متد «ToDataTableFromExcel» در ExcelExtensions. تبدیل/نرمال‌سازی داده را طبق نام متد انجام می‌دهد.
بدون پارامتر ورودی.
مقدار بازگشتی: `DataTable`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

### `Zamin.Extensions.Serializers.EPPlus.Extensions.LinqExtensions`

- **Kind:** `class`
- **Source:** `Extentsions/Serializers/Zamin.Extensions.Serializers.EPPlus/Zamin.Extensions.Serializers.EPPlus/Extensions/LinqExtensions.cs`

کلاس «LinqExtensions» در namespace Zamin.Extensions.Serializers.EPPlus.Extensions. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

#### Members

##### `ToList` (method)

```csharp
public static List<T> ToList<T>(this DataTable dataTable, ITranslator translator)
```

متد «ToList» در LinqExtensions. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- dataTable (DataTable): ورودی از نوع DataTable.
- translator (ITranslator): ورودی از نوع ITranslator.

مقدار بازگشتی: `List<T>`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
