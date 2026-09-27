# Zamin.Extensions.UsersManagement.Abstractions

**Types in this pattern:** `IUserInfoService`, `FakeUserInfoService`.

## Registration

API: `AddAppUserInfoService(..., "UserInfo")` (application wrapper over Zamin user-info). Worker: `AddAppWorkerUserInfoService`.

## Usage

Via `ZaminServices.UserInfoService` in handlers/decorators, or ctor injection (e.g. `UserController(IUserInfoService userInfoService)`).

```csharp
// src/1.Core/ApplicationService/Common/Extensions/UserInfoServiceExtentions.cs
public static Guid GetUserSub(this IUserInfoService userInfoService)
{
    string? sub = userInfoService.UserId();
    if (string.IsNullOrWhiteSpace(sub))
        throw new InvalidEntityStateException("User data not found", "UserId");
    return Guid.Parse(sub);
}
```
