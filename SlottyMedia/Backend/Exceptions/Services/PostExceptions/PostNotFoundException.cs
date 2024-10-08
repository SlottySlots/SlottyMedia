using SlottyMedia.LoggingProvider;

namespace SlottyMedia.Backend.Exceptions.Services.PostExceptions;

/// <summary>
///     Represents an exception that is thrown when a requested post is not found.
/// </summary>
public class PostNotFoundException : BaseException<PostNotFoundException>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="PostNotFoundException" /> class with a specified error message.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public PostNotFoundException(string message) : base(message)
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="PostNotFoundException" /> class with a specified error message and a
    ///     reference to the inner exception that is the cause of this exception.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="innerException">The exception that is the cause of the current exception.</param>
    public PostNotFoundException(string message, Exception innerException) : base(message, innerException)
    {
    }
}