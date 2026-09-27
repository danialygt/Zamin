# Zamin.Extensions.Serializers.EPPlus.Services

مرجع API برای namespace `Zamin.Extensions.Serializers.EPPlus.Services`.

- **Type count (this file):** 1

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Extensions.Serializers.EPPlus.Services.EPPlusExcelSerializer`

- **Kind:** `class`
- **Base / interfaces:** `IExcelSerializer`
- **Source:** `Extentsions/Serializers/Zamin.Extensions.Serializers.EPPlus/Zamin.Extensions.Serializers.EPPlus/Services/EPPlusExcelSerializer.cs`

کلاس «EPPlusExcelSerializer» در namespace Zamin.Extensions.Serializers.EPPlus.Services. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین. ارث‌بری/پیاده‌سازی: IExcelSerializer. وابستگی‌های سازنده (DI): ITranslator translator. مرتبط: IExcelSerializer | DI: ITranslator translator.

#### Members

##### `.ctor` (constructor)

```csharp
public EPPlusExcelSerializer(ITranslator translator)
```

سازنده EPPlusExcelSerializer. پارامترها از طریق تزریق وابستگی تأمین می‌شوند. پارامترها:
- translator (ITranslator): ورودی از نوع ITranslator.
پیش‌شرط: وابستگی‌ها/مقادیر ورودی باید معتبر باشند تا فیلدهای داخلی به‌درستی مقداردهی شوند.

##### `ListToExcelByteArray` (method)

```csharp
public byte[] ListToExcelByteArray<T>(List<T> list, string sheetName = "Result")
```

متد «ListToExcelByteArray» در EPPlusExcelSerializer. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- list (List<T>): ورودی از نوع List<T>.
- sheetName (string): ورودی اختیاری از نوع string (دارای مقدار پیش‌فرض).

مقدار بازگشتی: `byte[]`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: IExcelSerializer | DI: ITranslator translator

##### `ExcelToDataTable` (method)

```csharp
public DataTable ExcelToDataTable(byte[] bytes)
```

متد «ExcelToDataTable» در EPPlusExcelSerializer. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
بدون پارامتر ورودی.
مقدار بازگشتی: `DataTable`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: IExcelSerializer | DI: ITranslator translator

##### `ExcelToList` (method)

```csharp
public List<T> ExcelToList<T>(byte[] bytes)
```

متد «ExcelToList» در EPPlusExcelSerializer. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
بدون پارامتر ورودی.
مقدار بازگشتی: `List<T>`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: IExcelSerializer | DI: ITranslator translator
