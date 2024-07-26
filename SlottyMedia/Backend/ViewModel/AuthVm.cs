using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Backend.ViewModel.Interfaces;
using Supabase.Gotrue;

namespace SlottyMedia.Backend.ViewModel;

/// <summary>
/// This class is used to implement the IAuthVm.
/// </summary>
public class AuthVm : IAuthVm
{
    private readonly IAuthService _authService;
    
    /// <summary>
    /// This property is used to store the username.
    /// </summary>
    public string Username { get; set; }
    
    /// <summary>
    /// This property is used to store the password.
    /// </summary>
    public string Password { get; set; }

    /// <summary>
    /// This constructor is used to inject the IAuthService.
    /// </summary>
    /// <param name="authService"></param>
    public AuthVm(IAuthService authService)
    {
        _authService = authService;
    }

    /// <summary>
    /// This method is used to sign in the user.
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public async Task<User> SignIn(string? username, string? password)
    {
        var user = await _authService.SignIn(username, password);
        return user;
    }
    
    /// <summary>
    /// This method is used to sign up the user.
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public async Task<User?> SignUp(string username, string password)
    {
        var user = await _authService.SignUp(username, password);
        return user;
    }

    /// <summary>
    /// This method is used to sign out the user.
    /// </summary>
    /// <returns></returns>
    public async Task<bool> SignOut()
    {
        try
        {
            await _authService.SignOut();
            return true; // Sign out successful
        }
        catch (Exception ex)
        {
            return false; // Sign out failed
        }
    }

    /// <summary>
    /// This method is used to get the access token after sign in.
    /// </summary>
    /// <returns></returns>
    public async Task<string?> GetAccessTokenAfterSignIn(string username, string password)
    {
        return await _authService.GetAccessToken();
    }
}