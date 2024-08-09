namespace SlottyMedia.Backend.Services.Interfaces;

/// <summary>
///     Provides a contract for setting cookies on the clients server
/// </summary>
public interface ICookieService
{
    /// <summary>
    ///     Should set a cookie on the clients browser
    /// </summary>
    /// <param name="name">
    ///     Name of the cookies
    /// </param>
    /// <param name="value">
    ///     Value of the cookie
    /// </param>
    /// <param name="days">
    ///     Expiration offset in days
    /// </param>
    /// <returns>
    ///     Returns a valuetask
    /// </returns>
    ValueTask SetCookie(string name, string value, int days);

    /// <summary>
    ///     Gets a cookie
    /// </summary>
    /// <param name="name">
    ///     Name to identify cookie
    /// </param>
    /// <returns>
    ///     Returns a ValueTask of type string
    /// </returns>
    ValueTask<string> GetCookie(string name);

    /// <summary>
    ///     Removes a cookie on the client side by setting its duration below zero
    /// </summary>
    /// <param name="name">
    ///     Name to identify cookie
    /// </param>
    /// <returns>
    ///     Returns the cookie which was deleted
    /// </returns>
    ValueTask<string> RemoveCookie(string name);
}