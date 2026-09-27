# Zamin.Utilities.Sinks.Elasticsearch

مرجع API برای namespace `Zamin.Utilities.Sinks.Elasticsearch`.

- **Type count (this file):** 1

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Utilities.Sinks.Elasticsearch.LoggerConfigurationZaminElasticsearchExtensions`

- **Kind:** `class`
- **Source:** `Utilities/Sinks/Elasticsearch/Zamin.Utilities.Sinks.Elasticsearch/LoggerConfigurationZaminElasticsearchExtensions.cs`

کلاس «LoggerConfigurationZaminElasticsearchExtensions» در namespace Zamin.Utilities.Sinks.Elasticsearch. متدهای الحاقی برای ثبت سرویس‌ها یا تسهیل استفاده از API.

#### Members

##### `ZaminElasticsearch` (method)

```csharp
public static LoggerConfiguration ZaminElasticsearch(this LoggerSinkConfiguration loggerSinkConfiguration, ElasticsearchSinkOptions options = null)
```

متد «ZaminElasticsearch» در LoggerConfigurationZaminElasticsearchExtensions. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- loggerSinkConfiguration (LoggerSinkConfiguration): ورودی از نوع LoggerSinkConfiguration.
- options (ElasticsearchSinkOptions): ورودی اختیاری از نوع ElasticsearchSinkOptions (دارای مقدار پیش‌فرض).

مقدار بازگشتی: `LoggerConfiguration`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `ZaminElasticsearch` (method)

```csharp
public static LoggerConfiguration ZaminElasticsearch(this LoggerSinkConfiguration loggerSinkConfiguration,
    // … (بدنه/initializer کامل در enriched JSON)
```

متد «ZaminElasticsearch» در LoggerConfigurationZaminElasticsearchExtensions. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- loggerSinkConfiguration (LoggerSinkConfiguration): ورودی از نوع LoggerSinkConfiguration.
- nodeUris (string): ورودی از نوع string.
- indexFormat (string): ورودی اختیاری از نوع string (دارای مقدار پیش‌فرض).
- templateName (string): ورودی اختیاری از نوع string (دارای مقدار پیش‌فرض).
- typeName (string): ورودی اختیاری از نوع string (دارای مقدار پیش‌فرض).
- batchPostingLimit (int): ورودی اختیاری از نوع int (دارای مقدار پیش‌فرض).
- period (int): ورودی اختیاری از نوع int (دارای مقدار پیش‌فرض).
- inlineFields (bool): ورودی اختیاری از نوع bool (دارای مقدار پیش‌فرض).
- restrictedToMinimumLevel (LogEventLevel): رویداد دامنه/پیام برای پردازش.
- bufferBaseFilename (string): ورودی اختیاری از نوع string (دارای مقدار پیش‌فرض).
- bufferFileSizeLimitBytes (long?): ورودی اختیاری از نوع long? (دارای مقدار پیش‌فرض).
- bufferLogShippingInterval (long): ورودی اختیاری از نوع long (دارای مقدار پیش‌فرض).
- connectionGlobalHeaders (string): ورودی اختیاری از نوع string (دارای مقدار پیش‌فرض).
- levelSwitch (LoggingLevelSwitch): ورودی اختیاری از نوع LoggingLevelSwitch (دارای مقدار پیش‌فرض).
- connectionTimeout (int): ورودی اختیاری از نوع int (دارای مقدار پیش‌فرض).
- emitEventFailure (EmitEventFailureHandling): رویداد دامنه/پیام برای پردازش.
- queueSizeLimit (int): ورودی اختیاری از نوع int (دارای مقدار پیش‌فرض).
- pipelineName (string): ورودی اختیاری از نوع string (دارای مقدار پیش‌فرض).
- autoRegisterTemplate (bool): ورودی اختیاری از نوع bool (دارای مقدار پیش‌فرض).
- autoRegisterTemplateVersion (AutoRegisterTemplateVersion?): ورودی اختیاری از نوع AutoRegisterTemplateVersion? (دارای مقدار پیش‌فرض).
- overwriteTemplate (bool): ورودی اختیاری از نوع bool (دارای مقدار پیش‌فرض).
- registerTemplateFailure (RegisterTemplateRecovery): ورودی اختیاری از نوع RegisterTemplateRecovery (دارای مقدار پیش‌فرض).
- deadLetterIndexName (string): ورودی اختیاری از نوع string (دارای مقدار پیش‌فرض).
- numberOfShards (int?): ورودی اختیاری از نوع int? (دارای مقدار پیش‌فرض).
- numberOfReplicas (int?): ورودی اختیاری از نوع int? (دارای مقدار پیش‌فرض).
- formatProvider (IFormatProvider): ورودی اختیاری از نوع IFormatProvider (دارای مقدار پیش‌فرض).
- connection (IConnection): ورودی اختیاری از نوع IConnection (دارای مقدار پیش‌فرض).
- serializer (IElasticsearchSerializer): ورودی اختیاری از نوع IElasticsearchSerializer (دارای مقدار پیش‌فرض).
- connectionPool (IConnectionPool): ورودی اختیاری از نوع IConnectionPool (دارای مقدار پیش‌فرض).
- customFormatter (ITextFormatter): ورودی اختیاری از نوع ITextFormatter (دارای مقدار پیش‌فرض).
- customDurableFormatter (ITextFormatter): ورودی اختیاری از نوع ITextFormatter (دارای مقدار پیش‌فرض).
- failureSink (ILogEventSink): رویداد دامنه/پیام برای پردازش.
- singleEventSizePostingLimit (long?): رویداد دامنه/پیام برای پردازش.
- bufferFileCountLimit (int?): ورودی اختیاری از نوع int? (دارای مقدار پیش‌فرض).
- templateCustomSettings (Dictionary<string, string>): ورودی اختیاری از نوع Dictionary<string, string> (دارای مقدار پیش‌فرض).
- batchAction (ElasticOpType): ورودی اختیاری از نوع ElasticOpType (دارای مقدار پیش‌فرض).
- detectElasticsearchVersion (bool): ورودی اختیاری از نوع bool (دارای مقدار پیش‌فرض).
- disableServerCertificateValidation (bool): ورودی اختیاری از نوع bool (دارای مقدار پیش‌فرض).

مقدار بازگشتی: `LoggerConfiguration`.
استثناها (قابل تشخیص از کد):
- ArgumentNullException (throw new)
- ArgumentNullException
