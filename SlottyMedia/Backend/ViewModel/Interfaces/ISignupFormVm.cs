using SlottyMedia.Backend.Exceptions.signup;

namespace SlottyMedia.Backend.ViewModel.Interfaces;

/// <summary>
///     This ViewModel is used for the app's signup page. It represents the
///     form's internal state and provides functionalities for submitting the
///     form as well.
/// </summary>
public interface ISignupFormVm
{
    /// <summary>The form's username</summary>
    string? Username { get; set; }

    /// <summary>An optional error message that is caused by the username</summary>
    string? UsernameErrorMessage { get; set; }

    /// <summary>The form's email address</summary>
    string? Email { get; set; }

    /// <summary>An optional error message that is caused by the email address</summary>
    string? EmailErrorMessage { get; set; }

    /// <summary>The form's password</summary>
    string? Password { get; set; }

    /// <summary>An optional error message that is caused by the password</summary>
    string? PasswordErrorMessage { get; set; }

    /// <summary>An optional error message that is caused by some internal server error</summary>
    string? ServerErrorMessage { get; set; }

    /// <summary>
    ///     Attempts to submit the form. If this is successful, then the user was signed up
    ///     successfully and cookies have been set. Otherwise, an exception is thrown.
    /// </summary>
    /// <exception cref="ArgumentException">If an input field was left empty but was required</exception>
    /// <exception cref="UsernameAlreadyExistsException">If the username is already in use</exception>
    /// <exception cref="EmailAlreadyExistsException">If the email address is already in use</exception>
    Task SubmitSignupForm();
}