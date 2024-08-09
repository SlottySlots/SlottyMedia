using SlottyMedia.Backend.Services.Interfaces;
using Supabase.Gotrue;
using Client = Supabase.Client;

namespace SlottyMedia.Backend.Services;

/// <summary>
///     This service is used to authenticate users
/// </summary>
public class AuthService : IAuthService
{
    private readonly ICookieService _cookieService;
    private readonly Client _supabaseClient;

    /// <summary>
    ///     Initialize scoped service by ctor injection
    /// </summary>
    /// <param name="supabaseClient">
    ///     Injected supabaseClient
    /// </param>
    /// <param name="cookieService">
    ///     Injected cookieService
    /// </param>
    public AuthService(Client supabaseClient, ICookieService cookieService)
    {
        _supabaseClient = supabaseClient;
        _cookieService = cookieService;
    }

    /// <summary>
    ///     This method is used to sign up the user. And save the session by using SaveSessionAsync. This will set cookies.
    /// </summary>
    /// <param name="email">
    ///     Email of the user
    /// </param>
    /// <param name="password">
    ///     Password of the user
    /// </param>
    /// <returns></returns>
    public async Task<Session?> SignUp(string email, string password)
    {
        var session = await _supabaseClient.Auth.SignUp(email, password);
        if (session != null) await SaveSessionAsync(session);
        return session;
    }

    /// <summary>
    ///     This method is used to sign in the user. And save the session by using SaveSessionAsync. This will set cookies.
    /// </summary>
    /// <param name="email">
    ///     Email of the user
    /// </param>
    /// <param name="password">
    ///     Password of the user
    /// </param>
    /// <returns></returns>
    public async Task<Session?> SignIn(string email, string password)
    {
        var session = await _supabaseClient.Auth.SignIn(email, password);
        if (session != null) await SaveSessionAsync(session);
        return session;
    }

    /// <summary>
    ///     Used to save cookies of a specific session
    /// </summary>
    /// <param name="session">
    ///     Provides the session information, f.e. accessToken / refreshToken
    /// </param>
    public async Task SaveSessionAsync(Session session)
    {
        if (session is { AccessToken: not null, RefreshToken: not null })
        {
            await _cookieService.SetCookie("supabase.auth.token", session.AccessToken, 7);
            await _cookieService.SetCookie("supabase.auth.refreshToken", session.RefreshToken, 7);
        }
    }

    /// <summary>
    ///     Restores a session by cookies, if they exist
    /// </summary>
    /// <returns>
    ///     A session (might be the same as previously called, but can change if accessToken cookie is expired)
    /// </returns>
    public async Task<Session?> RestoreSessionAsync()
    {
        var accessToken = await _cookieService.GetCookie("supabase.auth.token");
        var refreshToken = await _cookieService.GetCookie("supabase.auth.refreshToken");
        if (!string.IsNullOrEmpty(accessToken) && !string.IsNullOrEmpty(refreshToken))
            try
            {
                var session = await RefreshSession(accessToken, refreshToken);
                if (session != null)
                {
                    await SaveSessionAsync(session);
                    return session;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error refreshing session: {ex.Message}");
                await SignOut();
            }

        return null;
    }

    /// <summary>
    ///     Sets a session on the server-side via supabase client
    /// </summary>
    /// <param name="accessToken">
    ///     Provided AccessToken
    /// </param>
    /// <param name="refreshToken">
    ///     Provided RefreshToken
    /// </param>
    /// <returns>
    ///     Returns the Session set, by AccessToken and RefreshToken
    /// </returns>
    public async Task<Session?> SetSession(string accessToken, string refreshToken)
    {
        var session = await _supabaseClient.Auth.SetSession(accessToken, refreshToken);
        return session;
    }

    /// <summary>
    ///     This method is used to sign out the user. It also removes cookies
    /// </summary>
    public async Task SignOut()
    {
        await _supabaseClient.Auth.SignOut();
        await _cookieService.RemoveCookie("supabase.auth.token");
        await _cookieService.RemoveCookie("supabase.auth.refreshToken");
    }

    /// <summary>
    ///     Sets a session but forces to refresh a new accessToken, and thus a new session
    /// </summary>
    /// <param name="accessToken">
    ///     Provided AccessToken
    /// </param>
    /// <param name="refreshToken">
    ///     Provided RefreshToken
    /// </param>
    /// <returns>
    ///     Returns the session
    /// </returns>
    public async Task<Session?> RefreshSession(string accessToken, string refreshToken)
    {
        var session = await _supabaseClient.Auth.SetSession(accessToken, refreshToken, true);
        return session;
    }

    /// <summary>
    ///     This method is used to check if the user is authenticated.
    /// </summary>
    /// <returns></returns>
    public bool IsAuthenticated()
    {
        return _supabaseClient.Auth.CurrentSession != null;
    }

    /// <summary>
    ///     Gets current user set on server side
    /// </summary>
    /// <returns>
    ///     Returns the session set on server side
    /// </returns>
    public Session? GetCurrentSession()
    {
        var session = _supabaseClient.Auth.CurrentSession;
        return session;
    }
}