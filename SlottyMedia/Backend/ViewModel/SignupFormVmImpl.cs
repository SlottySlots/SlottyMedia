using Microsoft.IdentityModel.Tokens;
using SlottyMedia.Backend.Exceptions.signup;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Backend.ViewModel.Interfaces;

namespace SlottyMedia.Backend.ViewModel;

public class SignupFormVmImpl : ISignupFormVm
{
    private readonly ISignupService _signupService;

    public SignupFormVmImpl(ISignupService signupService)
    {
        _signupService = signupService;
    }

    public string? Username { get; set; }
    public string? UsernameErrorMessage { get; set; }

    public string? Email { get; set; }
    public string? EmailErrorMessage { get; set; }

    public string? Password { get; set; }
    public string? PasswordErrorMessage { get; set; }

    public string? ServerErrorMessage { get; set; }


    public async Task SubmitSignupForm()
    {
        // reset all existing errors first
        _resetErrors();

        // handle errors when fields were empty
        if (Username.IsNullOrEmpty())
        {
            UsernameErrorMessage = "Username is required";
            throw new ArgumentException("Username is required but was null or empty");
        }

        if (Email.IsNullOrEmpty())
        {
            EmailErrorMessage = "Email is required";
            throw new ArgumentException("Email is required but was null or empty");
        }

        if (Password.IsNullOrEmpty())
        {
            PasswordErrorMessage = "Password is required";
            throw new ArgumentException("Password is required but was null or empty");
        }

        // if all fields were provided, try signing up
        try
        {
            await _signupService.SignUp(Username!, Email!, Password!);
        }
        catch (UsernameAlreadyExistsException)
        {
            UsernameErrorMessage = "Username already taken";
            throw;
        }
        catch (EmailAlreadyExistsException)
        {
            EmailErrorMessage = "Email already in use";
            throw;
        }
        catch
        {
            ServerErrorMessage = "An unknown error has occured. Please try again later.";
            throw;
        }
    }

    private void _resetErrors()
    {
        UsernameErrorMessage = null;
        EmailErrorMessage = null;
        PasswordErrorMessage = null;
        ServerErrorMessage = null;
    }
}