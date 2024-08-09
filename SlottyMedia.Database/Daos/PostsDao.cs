using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace SlottyMedia.Database.Daos;

/// <summary>
///     This class represents the Posts table in the database.
/// </summary>
[Table("Posts")]
public class PostsDao : BaseModel
{
    public PostsDao()
    {
    }

    public PostsDao(Guid userId, Guid forumId, string headline, string content)
    {
        UserId = userId;
        ForumId = forumId;
        Headline = headline;
        Content = content;
    }

    /// <summary>
    ///     The ID of the Post. This is the Primary Key. It is auto-generated.
    /// </summary>
    [PrimaryKey("postID")]
    public Guid? PostId { get; set; }

    /// <summary>
    ///     The User who created the Post. This is a Reference to the User Table. It is a Foreign Key. Be aware, that this
    ///     Field will not be filled when you insert the Post into the Database.
    /// </summary>
    [Reference(typeof(UserDao), true, true, "userID")]
    public UserDao? User { get; set; }

    /// <summary>
    ///     The ID of the User who created the Post. This is a Foreign Key to the User Table.
    /// </summary>
    [Column("creator_userID")]
    public Guid? UserId { get; set; }

    /// <summary>
    ///     The Forum the Post is associated with. This is a Reference to the Forum Table. It is a Foreign Key. Be aware, that
    ///     this
    ///     Field will not be filled when you insert the Post into the Database.
    /// </summary>
    [Reference(typeof(ForumDao), ReferenceAttribute.JoinType.Inner, true, "forumID")]
    public ForumDao? Forum { get; set; }

    /// <summary>
    ///     The ID of the Forum the Post is associated with. This is a Foreign Key to the Forum Table.
    /// </summary>
    [Column("associated_forumID")]
    public Guid? ForumId { get; set; }

    /// <summary>
    ///     The Headline of the Post.
    /// </summary>
    [Column("headline")]
    public string? Headline { get; set; }

    /// <summary>
    ///     The Content of the Post.
    /// </summary>
    [Column("content")]
    public string? Content { get; set; }

    [Reference(typeof(CommentDao), ReferenceAttribute.JoinType.Left, true, "corresponding_PostID")]
    public List<CommentDao?>? Comments { get; set; }

    /// <summary>
    ///     The Date and Time the Post was created.
    /// </summary>
    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
}