# Zamin.Extensions.MessageBus.MessageInbox.Dal.Dapper

## Registration (WorkerService only, active)

```csharp
builder.Services.AddZaminMessageInboxDalSql(builder.Configuration, "MessageInboxSqlStore");
// builder.Services.AddZaminMessageInbox(builder.Configuration, "MessageInbox"); // commented
```
