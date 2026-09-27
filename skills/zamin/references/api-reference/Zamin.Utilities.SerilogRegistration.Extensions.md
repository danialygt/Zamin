# Zamin.Utilities.SerilogRegistration.Extensions

مرجع API برای namespace `Zamin.Utilities.SerilogRegistration.Extensions`.

- **Type count (this file):** 1

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Utilities.SerilogRegistration.Extensions.SerilogExtensions`

- **Kind:** `class`
- **Source:** `Utilities/SerilogRegistration/Zamin.Utilities.SerilogRegistration/Extensions/SerilogExtensions.cs`

کلاس «SerilogExtensions» در namespace Zamin.Utilities.SerilogRegistration.Extensions. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/dependency-injection.md#recipe-host-bootstrap)

#### Members

##### `RunWithSerilogExceptionHandling` (method)

```csharp
public static void RunWithSerilogExceptionHandling(Action action, string startUpMessage = "Starting up", string exceptionMessage = "Unhandled exception", string shutdownMessage = "Shutdown complete")
```

متد «RunWithSerilogExceptionHandling» در SerilogExtensions. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد. خطاها را در بلوک try/catch مدیریت می‌کند.
پارامترها:
- action (Action): ورودی از نوع Action.
- startUpMessage (string): ورودی اختیاری از نوع string (دارای مقدار پیش‌فرض).
- exceptionMessage (string): ورودی اختیاری از نوع string (دارای مقدار پیش‌فرض).
- shutdownMessage (string): ورودی اختیاری از نوع string (دارای مقدار پیش‌فرض).

مقدار بازگشتی: ندارد (void).
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
