using SlottyMedia.Database.Daos;

namespace SlottyMedia.Backend.Dtos;

/// <summary>
///     The Post Data Transfer Object
/// </summary>
public class PostDto
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="PostDto" /> class.
    /// </summary>
    public PostDto()
    {
        Forum = new ForumDto();
        PostId = Guid.Empty;
        UserId = Guid.Empty;
        Likes = new List<Guid>();
        CreatedAt = DateTime.MinValue;
        Content = string.Empty;
        Comments = new List<CommentDao>();
        Headline = string.Empty;
    }

    /// <summary>
    ///     Gets or sets the forum associated with the post.
    /// </summary>
    public ForumDto Forum { get; set; }

    /// <summary>
    ///     Gets or sets the post ID.
    /// </summary>
    public Guid PostId { get; set; }

    /// <summary>
    ///     Gets or sets the user ID of the user who created the post.
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    ///     Gets or sets the list of user IDs who liked the post.
    /// </summary>
    public List<Guid> Likes { get; set; }

    /// <summary>
    ///     Gets or sets the creation date of the post.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    ///     Gets or sets the headline of the post.
    /// </summary>
    public string Headline { get; set; }

    /// <summary>
    ///     Gets or sets the content of the post.
    /// </summary>
    public string Content { get; set; }

    /// <summary>
    ///     Gets or sets the comments on the post.
    /// </summary>
    public List<CommentDao> Comments { get; set; }


    /// <summary>
    ///     The Mapper for the Post Dto to the Post Dao.
    /// </summary>
    /// <returns></returns>
    public PostsDao Mapper()
    {
        var postDao = new PostsDao
        {
            PostId = PostId,
            Content = Content,
            CreatedAt = CreatedAt,
            UserId = UserId,
            ForumId = Forum.ForumId,
            Headline = Headline
        };
        return postDao;
    }

    /// <summary>
    ///     Maps the Post Dao to the Post Dto.
    /// </summary>
    /// <param name="post"></param>
    /// <returns></returns>
    public PostDto Mapper(PostsDao post)
    {
        //TODO Anpassen
        PostId = post.PostId ?? Guid.Empty;
        Content = post.Content ?? string.Empty;
        Forum = post.Forum == null ? new ForumDto() : new ForumDto();
        CreatedAt = post.CreatedAt;
        Comments = post.Comments ?? new List<CommentDao?>();
        UserId = post.UserId ?? Guid.Empty;
        Headline = post.Headline ?? string.Empty;
        return this;
    }
}