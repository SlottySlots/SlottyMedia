using SlottyMedia.Backend.Services.Interfaces;
using Supabase.Gotrue;
using Client = Supabase.Client;

namespace SlottyMedia.Backend.Services
{
    public class AuthService(Client supabaseClient) : IAuthService
    {
        public async Task<User> SignUp(string email, string password)
        {
            var authResponse = await supabaseClient.Auth.SignUp(email, password);
            return authResponse.User;
        }
        
        public async Task<User> SignIn(string email, string password)
        {
            var authResponse = await supabaseClient.Auth.SignIn(email, password);
            return authResponse.User;
        }
        
        public async Task SignOut()
        {
            await supabaseClient.Auth.SignOut();
        }

        public bool IsAuthenticated()
        {
            return supabaseClient.Auth.CurrentSession != null;
        }
    }
}