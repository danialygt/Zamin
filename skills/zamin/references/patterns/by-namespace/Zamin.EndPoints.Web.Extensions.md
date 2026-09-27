# Zamin.EndPoints.Web.Extensions

**Types in this pattern:** `HttpContextExtensions` (extension methods).

## Usage

Used for HTTP helpers such as client IP in rate limiting setup in API `HostingExtensions` (`httpContext.GetClientIpAddress()` pattern alongside the application rate limiter). Confirm exact extension method name at call-site when changing rate-limit code.
