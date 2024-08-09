using SlottyMedia.Database.Daos;

namespace SlottyMedia.Backend.Dtos;

/// <summary>
///     The Forum Data Transfer Object
/// </summary>
public class ForumDto
{
    /// <summary>
    ///     The default constructor.
    /// </summary>
    public ForumDto()
    {
        ForumId = Guid.Empty;
        Topic = string.Empty;
    }

    /// <summary>
    ///     The Forum Id.
    /// </summary>
    public Guid ForumId { get; set; }

    /// <summary>
    ///     The Topic of the Forum.v
    /// </summary>
    public string Topic { get; set; }

    /// <summary>
    ///     This method maps the ForumDto to a ForumDao.
    /// </summary>
    /// <returns></returns>
    public ForumDao Mapper()
    {
        return new ForumDao
        {
            ForumId = ForumId,
            ForumTopic = Topic
        };
    }

    /// <summary>
    ///     THis method maps the ForumDao to a ForumDto.
    /// </summary>
    /// <param name="forumDao"></param>
    /// <returns></returns>
    public ForumDto Mapper(ForumDao forumDao)
    {
        return new ForumDto
        {
            ForumId = forumDao.ForumId ?? Guid.Empty,
            Topic = forumDao.ForumTopic ?? string.Empty
        };
    }
}