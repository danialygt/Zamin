# Zamin.Extensions.Events.PollingPublisher.Dal.Dapper

## Registration (WorkerService only, active)

```csharp
// src/3.Endpoints/WorkerService/Extentions/DependencyInjection/HostingExtensions.cs
builder.Services.AddZaminPollingPublisherDalSql(builder.Configuration, "PollingPublisherSqlStore");
// companion app registration is commented:
// builder.Services.AddZaminPollingPublisher(builder.Configuration, "PollingPublisher");
```
