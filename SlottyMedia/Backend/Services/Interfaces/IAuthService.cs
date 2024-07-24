using Supabase.Gotrue;

namespace SlottyMedia.Backend.Services.Interfaces;

public interface IAuthService
{
    Task<User> SignUp(string email, string password);
    Task<User> SignIn(string email, string password);
    Task SignOut();
    bool IsAuthenticated();
}