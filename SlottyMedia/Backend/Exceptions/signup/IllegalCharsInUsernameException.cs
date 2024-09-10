using SlottyMedia.LoggingProvider;

namespace SlottyMedia.Backend.Exceptions.signup;

/// <summary>
///     An exception that is thrown when a user attempts to sign up with a username that
///     contains illegal characters.
/// </summary>
public class IllegalCharsInUsernameException : BaseException<IllegalCharsInUsernameException>;