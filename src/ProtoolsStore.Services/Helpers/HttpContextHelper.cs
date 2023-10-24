using Microsoft.AspNetCore.Http;
using ProtoolsStore.Domain.Enums;

namespace ProtoolsStore.Services;
#pragma  warning disable

/// <summary>
/// Helper class providing convenient access to HttpContext properties and values.
/// </summary>
public static class HttpContextHelper
{
    /// <summary>
    /// Gets or sets the IHttpContextAccessor instance, allowing access to the current HttpContext.
    /// </summary>
    public static IHttpContextAccessor Accessor { get; set; }

    /// <summary>
    /// Gets the current HttpContext, if available.
    /// </summary>
    public static HttpContext HttpContext => Accessor?.HttpContext;

    /// <summary>
    /// Gets the response headers of the current HttpContext, if available.
    /// </summary>
    public static IHeaderDictionary ResponseHeaders => HttpContext?.Response?.Headers;

    /// <summary>
    /// Gets the user ID from the current HttpContext claims, if available.
    /// </summary>
    public static int? UserId => GetUserId();

    /// <summary>
    /// Gets the user role from the current HttpContext claims, if available.
    /// </summary>
    public static string UserRole => HttpContext?.User.FindFirst("Role")?.Value;

    /// <summary>
    /// Retrieves the user ID from the claims of the current HttpContext, if available and valid.
    /// </summary>
    /// <returns>The user ID if available and valid; otherwise, null.</returns>
    private static int? GetUserId()
    {
        string value = HttpContext?.User?.Claims.FirstOrDefault(p => p.Type == "Id")?.Value;

        bool canParse = int.TryParse(value, out int id);
        return canParse ? id : null;
    }

    public static Localization Localization =>
        Enum.TryParse(Accessor.HttpContext.Response.Headers["Accept-Language"], true, out Localization result)
            ? result
            : Localization.Uz;
}
