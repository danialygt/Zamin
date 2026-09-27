# Zamin.Core.RequestResponse.Common

**Types in this pattern:** `ApplicationServiceStatus`.

## Usage

Dispatcher logging decorators branch on `result.Status` (`Ok`, `Exception`, validation statuses) for metrics/logging.

```csharp
// src/1.Core/ApplicationService/Common/Decorator/LoggingQueryDispatcherDecorator.cs
activity?.SetTag("app.status", result.Status.ToString());
AppBusinessMetrics.QueryExecuted(queryName, result.Status.ToString());
// ...
case ApplicationServiceStatus.Ok:
    logType = LogType.UserActivity;
    break;
case ApplicationServiceStatus.Exception:
    logType = LogType.ErrorManagement;
    break;
```
