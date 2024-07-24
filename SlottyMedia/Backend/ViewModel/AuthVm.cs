using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Backend.ViewModel.Interfaces;
using Supabase.Gotrue;

namespace SlottyMedia.Backend.ViewModel;

public class AuthVM : IAuthVm
{
    private readonly IAuthService _authService;

    public string username { get; set; }
    public string password { get; set; }

    public AuthVM(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<User> SignIn(string username, string password)
    {
        var user = await _authService.SignIn(username, password);
        return user;
    }
    
    public async Task<User> SignUp(string username, string password)
    {
        var user = await _authService.SignUp(username, password);
        return user;
    }

    public async Task<User> SignOut()
    {
        await _authService.SignOut();
        return null;
    }
}