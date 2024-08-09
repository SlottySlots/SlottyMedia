namespace SlottyMedia.Backend.Exceptions.signup;

/// <summary>
///     This exception is thrown after an illegal attempt to sign up a user with an already existing email.
/// </summary>
public class EmailAlreadyExistsException : Exception
{
    /// <summary>
    ///     Build an exception with the given email.
    /// </summary>
    /// <param name="email">The illegally used email</param>
    public EmailAlreadyExistsException(string email) : base($"Email '{email}' is already in use")
    {
    }
}