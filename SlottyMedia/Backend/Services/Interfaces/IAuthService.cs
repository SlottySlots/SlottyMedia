using Supabase.Gotrue;

namespace SlottyMedia.Backend.Services.Interfaces;

/// <summary>
///     Interface providing a contract to authenticate a user via supabase
/// </summary>
public interface IAuthService
{
    /// <summary>
    ///     This method is used to sign up the user.
    /// </summary>
    /// <param name="email"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    [Obsolete("This method is deprecated, use ISignupService instead.")]
    Task<Session?> SignUp(string email, string password);

    /// <summary>
    ///     This method is used to sign in the user.
    /// </summary>
    /// <param name="email"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    Task<Session?> SignIn(string email, string password);

    /// <summary>
    ///     This method is used to sign out the user.
    /// </summary>
    /// <returns></returns>
    Task SignOut();

    /// <summary>
    ///     Should restore a session by reading in accessToken, refreshToken Cookie
    /// </summary>
    /// <returns>
    ///     Returns a supabase session
    /// </returns>
    public Task<Session?> RestoreSessionAsync();

    /// <summary>
    ///     Saves the accessToken, refreshToken in form of a cookie in the clients browser
    /// </summary>
    /// <param name="session">
    ///     Session on which the tokens are extracted
    /// </param>
    /// <returns>
    ///     Returns the sessions again
    /// </returns>
    public Task SaveSessionAsync(Session session);

    /// <summary>
    ///     Checks if a session exists
    /// </summary>
    bool IsAuthenticated();

    /// <summary>
    ///     Sets a session in form of a cookie on the client side by using wwwroot/js/cookies.js
    /// </summary>
    /// <param name="accessToken">
    ///     AccessToken about to be set as cookie
    /// </param>
    /// <param name="refreshToken">
    ///     RefreshToken about to be set as cookie
    /// </param>
    /// <returns>
    ///     Returns the session which was set
    /// </returns>
    Task<Session?> SetSession(string accessToken, string refreshToken);

    /// <summary>
    ///     Restores a session on server- and client-side and refreshes a accessToken if necessary
    /// </summary>
    /// <param name="accessToken">
    ///     AccessToken for restoration
    /// </param>
    /// <param name="refreshToken">
    ///     RefreshToken for restoration
    /// </param>
    /// <returns>
    ///     Returns the new session
    /// </returns>
    Task<Session?> RefreshSession(string accessToken, string refreshToken);


    /// <summary>
    ///     Gets the current session set by the client
    /// </summary>
    /// <returns>
    ///     Returns the session
    /// </returns>
    Session? GetCurrentSession();
}