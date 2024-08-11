using SlottyMedia.Backend.Exceptions.signup;
using SlottyMedia.Backend.Services.Interfaces;
using Supabase.Gotrue;
using Client = Supabase.Client;

namespace SlottyMedia.Backend.Services;

/// <summary>
///     Service
/// </summary>
public class SignupServiceImpl : ISignupService
{
    private readonly ICookieService _cookieService;
    private readonly Client _supabaseClient;
    private readonly IUserService _userService;

    /// <summary>
    ///     Standard Constructor for dependency injection
    /// </summary>
    /// <param name="supabaseClient">
    ///     Supabase Client used for supabase interactions
    /// </param>
    /// <param name="userService">
    ///     User Service used to retrieve dtos
    /// </param>
    /// <param name="cookieService">
    ///     Cookie Service used to set cookies on client side
    /// </param>
    public SignupServiceImpl(Client supabaseClient, IUserService userService, ICookieService cookieService)
    {
        _supabaseClient = supabaseClient;
        _userService = userService;
        _cookieService = cookieService;
    }

    /// <summary>
    ///     Function used to sign up a user. This must function be virtual in order to being mocked in unit tests!
    /// </summary>
    /// <param name="username">
    ///     Username for the new user
    /// </param>
    /// <param name="email">
    ///     Email for the new user
    /// </param>
    /// <param name="password">
    ///     Password for the new user
    /// </param>
    /// <returns></returns>
    /// <exception cref="UsernameAlreadyExistsException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    public virtual async Task<Session> SignUp(string username, string email, string password)
    {
        // throw exception if username already exists
        var user = await _userService.GetUserByUsername(username);
        if (user != null)
            throw new UsernameAlreadyExistsException(username);

        // else: sign up user
        var options = new SignUpOptions
        {
            Data = new Dictionary<string, object>
            {
                { "userName", username }
            }
        };
        var session = await _supabaseClient.Auth.SignUp(email, password, options);

        // TODO Check if email already exists, it is unclear how supabase responds in that case!

        // throw exception if, for whichever reason, the session is null
        if (session == null)
            throw new InvalidOperationException(
                "An unknown error occured in the Supabase client while attempting to perform a signup.");

        // save cookies
        await _cookieService.SetCookie("supabase.auth.token", session.AccessToken, 7);
        await _cookieService.SetCookie("supabase.auth.refreshToken", session.RefreshToken, 7);

        return session;
    }
}