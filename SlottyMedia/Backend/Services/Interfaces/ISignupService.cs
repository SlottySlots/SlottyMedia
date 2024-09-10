using SlottyMedia.Backend.Exceptions.signup;
using Supabase.Gotrue;

namespace SlottyMedia.Backend.Services.Interfaces;

/// <summary>
///     This service is used for signup operations for new users.
/// </summary>
public interface ISignupService
{
    /// <summary>
    ///     Attempts to perform a signup operation.
    /// </summary>
    /// <param name="username">The user's username</param>
    /// <param name="email">The user's email</param>
    /// <param name="password">The user's password</param>
    /// <exception cref="UsernameAlreadyExistsException">If a user with the provided username already exists</exception>
    /// <exception cref="EmailAlreadyExistsException">If a user with the provided email already exists</exception>
    /// <exception cref="IllegalCharsInUsernameException">If the provided username contains illegal characters</exception>
    /// <exception cref="IllegalUsernameLengthException">If the provided username is of illegal length</exception>
    /// <exception cref="PasswordTooShortException">If the provided password was too short</exception>
    Task<Session> SignUp(string username, string email, string password);
}