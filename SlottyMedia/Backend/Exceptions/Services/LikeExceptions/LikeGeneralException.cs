using SlottyMedia.Backend.Exceptions.Services.ForumExceptions;
using SlottyMedia.LoggingProvider;

namespace SlottyMedia.Backend.Exceptions.Services.LikeExceptions;

/// <summary>
///     Represents a general exception that occurs in the Forum service.
/// </summary>
public class LikeGeneralException : BaseException<LikeGeneralException>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ForumGeneralException" /> class with a specified error message.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public LikeGeneralException(string message) : base(message)
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ForumGeneralException" /> class with a specified error message and a
    ///     reference to the inner exception that is the cause of this exception.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="innerException">The exception that is the cause of the current exception.</param>
    public LikeGeneralException(string message, Exception innerException) : base(message, innerException)
    {
    }
}