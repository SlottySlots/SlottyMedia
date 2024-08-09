using Microsoft.JSInterop;
using SlottyMedia.Backend.Services.Interfaces;

namespace SlottyMedia.Backend.Services;

/// <summary>
///     This class is used to perform JSInterops to perform Read, Write, Exec operations on cookies. It uses the stored
///     cookie.js file on client side (found in wwwroot/js)
/// </summary>
public class CookieService : ICookieService
{
    /// <summary>
    ///     Runtime to perform js operations on client side
    /// </summary>
    private readonly IJSRuntime _jsRuntime;

    /// <summary>
    ///     Sets a singleton by using ctor injection
    /// </summary>
    /// <param name="jsRuntime"></param>
    public CookieService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    /// <summary>
    ///     Sets a cookie by taking a name, value and a expiration offset
    /// </summary>
    /// <param name="name">
    ///     Name of the cookie (key)
    /// </param>
    /// <param name="value">
    ///     Value of the cookie as string.
    /// </param>
    /// <param name="days">
    ///     Expiration offset in days.
    ///     Standard value: 7 Days
    /// </param>
    /// <returns>
    ///     Returns a value task
    /// </returns>
    public ValueTask SetCookie(string name, string value, int days = 7)
    {
        return _jsRuntime.InvokeVoidAsync("setCookie", name, value, days);
    }

    /// <summary>
    ///     Gets a cookie by name
    /// </summary>
    /// <param name="name">
    ///     Name of the cookie f.e. "supabase.auth.token"
    /// </param>
    /// <returns>
    ///     Returns a value task of type string => output is the cookie value
    /// </returns>
    public ValueTask<string> GetCookie(string name)
    {
        return _jsRuntime.InvokeAsync<string>("getCookie", name);
    }

    /// <summary>
    ///     Removes a cookie by name
    /// </summary>
    /// <param name="name">
    ///     Name of the cookie to identify it
    /// </param>
    /// <returns>
    ///     ValueTask of type string => output is the cookie value
    /// </returns>
    public ValueTask<string> RemoveCookie(string name)
    {
        return _jsRuntime.InvokeAsync<string>("RemoveCookie", name);
    }
}