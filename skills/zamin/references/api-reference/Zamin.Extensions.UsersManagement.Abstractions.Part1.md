# Zamin.Extensions.UsersManagement.Abstractions (Part 1/2)

مرجع API برای namespace `Zamin.Extensions.UsersManagement.Abstractions`.

- **Type count (this file):** 1
- **Parts:** **Part 1** · [Part 2](./Zamin.Extensions.UsersManagement.Abstractions.Part2.md)

منبع توضیحات: `framework-docs/enriched/` (فیلد `generated_doc.fa` یا XML اصلی).

## Types

### `Zamin.Extensions.UsersManagement.Abstractions.FakeUserInfoService`

- **Kind:** `class`
- **Base / interfaces:** `IUserInfoService`
- **Source:** `Extentsions/Zamin.Extensions.Abstractions/Zamin.Extensions.UsersManagement.Abstractions/FakeUserInfoService.cs`

کلاس «FakeUserInfoService» در namespace Zamin.Extensions.UsersManagement.Abstractions. تعریف class عمومی/محافظت‌شده در لایه مربوطه فریم‌ورک زمین. ارث‌بری/پیاده‌سازی: IUserInfoService. وابستگی‌های سازنده (DI): string defaultUserId. مرتبط: IUserInfoService (same namespace) | DI: string defaultUserId.

- **Recipe:** [الگوی استفاده مرتبط](../patterns/common-recipes.md#recipe-user-info)

#### Members

##### `.ctor` (constructor)

```csharp
public FakeUserInfoService()
```

سازنده FakeUserInfoService. بدون پارامتر؛ معمولاً برای ORM، serialization یا مقداردهی اولیه محافظت‌شده استفاده می‌شود.

##### `.ctor` (constructor)

```csharp
public FakeUserInfoService(string defaultUserId)
```

سازنده FakeUserInfoService. برای ایجاد نمونه با مقادیر اولیه‌ی مشخص. پارامترها:
- defaultUserId (string): ورودی از نوع string.
پیش‌شرط: وابستگی‌ها/مقادیر ورودی باید معتبر باشند تا فیلدهای داخلی به‌درستی مقداردهی شوند.

##### `GetClaim` (method)

```csharp
public string? GetClaim(string claimType)
```

متد «GetClaim» در FakeUserInfoService. داده یا وضعیت مرتبط را بازیابی می‌کند.
پارامترها:
- claimType (string): ورودی از نوع string.

مقدار بازگشتی: `string?`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: IUserInfoService (same namespace) | DI: string defaultUserId

##### `GetFirstName` (method)

```csharp
public string GetFirstName()
```

متد «GetFirstName» در FakeUserInfoService. داده یا وضعیت مرتبط را بازیابی می‌کند.
بدون پارامتر ورودی.
مقدار بازگشتی: `string`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: IUserInfoService (same namespace) | DI: string defaultUserId

##### `GetLastName` (method)

```csharp
public string GetLastName()
```

متد «GetLastName» در FakeUserInfoService. داده یا وضعیت مرتبط را بازیابی می‌کند.
بدون پارامتر ورودی.
مقدار بازگشتی: `string`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: IUserInfoService (same namespace) | DI: string defaultUserId

##### `GetUserAgent` (method)

```csharp
public string GetUserAgent()
```

متد «GetUserAgent» در FakeUserInfoService. داده یا وضعیت مرتبط را بازیابی می‌کند.
بدون پارامتر ورودی.
مقدار بازگشتی: `string`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: IUserInfoService (same namespace) | DI: string defaultUserId

##### `GetUserIp` (method)

```csharp
public string GetUserIp()
```

متد «GetUserIp» در FakeUserInfoService. داده یا وضعیت مرتبط را بازیابی می‌کند.
بدون پارامتر ورودی.
مقدار بازگشتی: `string`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: IUserInfoService (same namespace) | DI: string defaultUserId

##### `GetUsername` (method)

```csharp
public string GetUsername()
```

متد «GetUsername» در FakeUserInfoService. داده یا وضعیت مرتبط را بازیابی می‌کند.
بدون پارامتر ورودی.
مقدار بازگشتی: `string`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: IUserInfoService (same namespace) | DI: string defaultUserId

##### `HasAccess` (method)

```csharp
public bool HasAccess(string access)
```

متد «HasAccess» در FakeUserInfoService. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- access (string): ورودی از نوع string.

مقدار بازگشتی: `bool`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: IUserInfoService (same namespace) | DI: string defaultUserId

##### `IsCurrentUser` (method)

```csharp
public bool IsCurrentUser(string userId)
```

متد «IsCurrentUser» در FakeUserInfoService. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- userId (string): ورودی از نوع string.

مقدار بازگشتی: `bool`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: IUserInfoService (same namespace) | DI: string defaultUserId

##### `UserId` (method)

```csharp
public string UserId()
```

متد «UserId» در FakeUserInfoService. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
بدون پارامتر ورودی.
مقدار بازگشتی: `string`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: IUserInfoService (same namespace) | DI: string defaultUserId

##### `UserIdOrDefault` (method)

```csharp
public string UserIdOrDefault()
```

متد «UserIdOrDefault» در FakeUserInfoService. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
بدون پارامتر ورودی.
مقدار بازگشتی: `string`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: IUserInfoService (same namespace) | DI: string defaultUserId

##### `UserIdOrDefault` (method)

```csharp
public string UserIdOrDefault(string defaultValue)
```

متد «UserIdOrDefault» در FakeUserInfoService. عملیات تعریف‌شده در امضا را روی این نوع انجام می‌دهد.
پارامترها:
- defaultValue (string): ورودی از نوع string.

مقدار بازگشتی: `string`.
استثنای صریحی در بدنه دیده نشد (ممکن است از وابستگی‌های داخلی پرتاب شود).
پیش‌شرط/وابستگی: نمونه باید از DI ساخته شده باشد تا وابستگی‌های سازنده در دسترس باشند
انواع مرتبط: IUserInfoService (same namespace) | DI: string defaultUserId
