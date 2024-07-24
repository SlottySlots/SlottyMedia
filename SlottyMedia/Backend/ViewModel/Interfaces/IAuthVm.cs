using Supabase.Gotrue;

namespace SlottyMedia.Backend.ViewModel.Interfaces;

public interface IAuthVm
{
    public Task<User> SignUp(string username, string password);
    public Task<User> SignIn(string username, string password);
    public Task<User> SignOut();
}