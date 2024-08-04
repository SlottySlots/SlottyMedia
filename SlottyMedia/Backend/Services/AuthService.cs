using SlottyMedia.Backend.Services.Interfaces;
using Supabase.Gotrue;
using Client = Supabase.Client;
/// <summary>
/// This class is used to implement the IAuthService.
/// </summary>
/// <param name="supabaseClient"></param>
public class AuthService(Client supabaseClient) : IAuthService
{
    /// <summary>
    /// This property is used to store the Supabase client.
    /// </summary>
    /// <returns></returns>
    public async Task<string?> GetAccessToken()
    {
        var accessToken = supabaseClient.Auth.CurrentSession?.AccessToken;
        return accessToken;
    }
    
    /// <summary>
    /// This method is used to sign up the user.
    /// </summary>
    /// <param name="email"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public async Task<Session?> SignUp(string email, string password)
    {
        var authResponse = await supabaseClient.Auth.SignUp(email, password);
        return authResponse;
    }
    
    /// <summary>
    /// This method is used to sign in the user.
    /// </summary>
    /// <param name="email"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public async Task<Session?> SignIn(string? email, string? password)
    {
        var authResponse = await supabaseClient.Auth.SignIn(email, password);
        return authResponse;
    }

    public async Task<Session?> SetSession(string sessionToken, string refreshToken)
    {
        var session = await supabaseClient.Auth.SetSession(sessionToken, refreshToken);
        return session;
    }

    public async Task SignOut()
    {
        await supabaseClient.Auth.SignOut();
    }

    public async Task<Session?> RefreshSession(string accessToken, string refreshToken)
    {
        var session = await supabaseClient.Auth.SetSession(accessToken, refreshToken, true);
        return session;
    }

    /// <summary>
    /// This method is used to check if the user is authenticated.
    /// </summary>
    /// <returns></returns>
    public bool IsAuthenticated()
    {
        return supabaseClient.Auth.CurrentSession != null;
    }
}