# Zamin.Utilities.Auth.ApiAuthentication.Options

**Types in this pattern:** `ApiAuthenticationOption`, `ProviderOption`, `TokenType`.

## Registration

`builder.Services.AddZaminApiAuthentication(builder.Configuration, "ApiAuthentication");` in API host registration. Options bound from that configuration section; feature code rarely references option types by name.
