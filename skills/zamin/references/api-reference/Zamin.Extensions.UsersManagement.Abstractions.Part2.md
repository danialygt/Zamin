# Zamin.Extensions.UsersManagement.Abstractions (Part 2/2)

مرجع API برای namespace `Zamin.Extensions.UsersManagement.Abstractions`.

- **Type count (this file):** 1
- **Parts:** [Part 1](./Zamin.Extensions.UsersManagement.Abstractions.Part1.md) · **Part 2**

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Extensions.UsersManagement.Abstractions.IUserInfoService`

- **Kind:** `interface`
- **Source:** `Extentsions/Zamin.Extensions.Abstractions/Zamin.Extensions.UsersManagement.Abstractions/IUserInfoService.cs`

قرارداد (اینترفیس) «IUserInfoService» در namespace Zamin.Extensions.UsersManagement.Abstractions. قرارداد رفتار برای مصرف‌کنندگان و پیاده‌سازی‌های جایگزین.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/common-recipes.md#recipe-user-info)

#### Members

##### `GetUserAgent` (method)

```csharp
string GetUserAgent()
```

متد «GetUserAgent» در IUserInfoService. داده یا وضعیت مرتبط را بازیابی می‌کند.
بدون پارامتر ورودی.
مقدار بازگشتی: `string`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `GetUserIp` (method)

```csharp
string GetUserIp()
```

متد «GetUserIp» در IUserInfoService. داده یا وضعیت مرتبط را بازیابی می‌کند.
بدون پارامتر ورودی.
مقدار بازگشتی: `string`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `UserId` (method)

```csharp
string UserId()
```

متد «UserId» در IUserInfoService. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
بدون پارامتر ورودی.
مقدار بازگشتی: `string`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `GetFirstName` (method)

```csharp
string GetFirstName()
```

متد «GetFirstName» در IUserInfoService. داده یا وضعیت مرتبط را بازیابی می‌کند.
بدون پارامتر ورودی.
مقدار بازگشتی: `string`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `GetLastName` (method)

```csharp
string GetLastName()
```

متد «GetLastName» در IUserInfoService. داده یا وضعیت مرتبط را بازیابی می‌کند.
بدون پارامتر ورودی.
مقدار بازگشتی: `string`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `GetUsername` (method)

```csharp
string GetUsername()
```

متد «GetUsername» در IUserInfoService. داده یا وضعیت مرتبط را بازیابی می‌کند.
بدون پارامتر ورودی.
مقدار بازگشتی: `string`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `GetClaim` (method)

```csharp
string? GetClaim(string claimType)
```

متد «GetClaim» در IUserInfoService. داده یا وضعیت مرتبط را بازیابی می‌کند.
پارامترها:
- claimType (string): ورودی از نوع string.

مقدار بازگشتی: `string?`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `IsCurrentUser` (method)

```csharp
bool IsCurrentUser(string userId)
```

متد «IsCurrentUser» در IUserInfoService. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- userId (string): ورودی از نوع string.

مقدار بازگشتی: `bool`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `UserIdOrDefault` (method)

```csharp
string UserIdOrDefault()
```

متد «UserIdOrDefault» در IUserInfoService. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
بدون پارامتر ورودی.
مقدار بازگشتی: `string`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).

##### `UserIdOrDefault` (method)

```csharp
string UserIdOrDefault(string defaultValue)
```

متد «UserIdOrDefault» در IUserInfoService. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- defaultValue (string): ورودی از نوع string.

مقدار بازگشتی: `string`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
