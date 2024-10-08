using SlottyMedia.LoggingProvider;

namespace SlottyMedia.Backend.Exceptions.Services.PostExceptions;

/// <summary>
///     Represents an exception that occurs during Insert, Update, or Delete operations in the Post service.
/// </summary>
public class PostIudException : BaseException<PostIudException>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="PostIudException" /> class with a specified error message.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public PostIudException(string message) : base(message)
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="PostIudException" /> class with a specified error message and a
    ///     reference to the inner exception that is the cause of this exception.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="innerException">The exception that is the cause of the current exception.</param>
    public PostIudException(string message, Exception innerException) : base(message, innerException)
    {
    }
}