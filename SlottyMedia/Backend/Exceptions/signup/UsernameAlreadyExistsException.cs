namespace SlottyMedia.Backend.Exceptions.signup;

/// <summary>
///     This exception is thrown after an illegal attempt to sign up a user with an already
///     existing username.
/// </summary>
public class UsernameAlreadyExistsException : Exception
{
    /// <summary>
    ///     Build an exception with the given username.
    /// </summary>
    /// <param name="username">The illegally used username</param>
    public UsernameAlreadyExistsException(string username) : base($"Username '{username}' is already in use")
    {
    }
}