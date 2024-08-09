using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace SlottyMedia.Database.Daos;

/// <summary>
///     This class represents the Comment table in the database.
/// </summary>
[Table("Comment")]
public class CommentDao : BaseModel
{
    /// <summary>
    ///     Default constructor.
    /// </summary>
    public CommentDao()
    {
        ParentComment = new List<CommentDao?>();
    }

    /// <summary>
    ///     This constructor is used to create a new Comment. The CommentId is auto-generated.
    /// </summary>
    /// <param name="creatorUserId">The user who created the comment</param>
    /// <param name="postId">The postId of the comment</param>
    /// <param name="content">The content of the comment</param>
    /// <param name="parentCommentId">The ID of the parent comment, if any</param>
    public CommentDao(Guid creatorUserId, Guid postId, string content, Guid? parentCommentId = null)
    {
        ParentCommentId = parentCommentId;
        CreatorUserId = creatorUserId;
        PostId = postId;
        Content = content;
        ParentComment = new List<CommentDao?>();
    }

    /// <summary>
    ///     The ID of the Comment. This is the Primary Key. It is auto-generated.
    /// </summary>
    [PrimaryKey("commentID")]
    public Guid? CommentId { get; set; }

    /// <summary>
    ///     The ID of the Parent Comment. This is only set when there is a Parent Comment.
    /// </summary>
    [Column("parent_commentID")]
    public Guid? ParentCommentId { get; set; }

    /// <summary>
    ///     The list of parent comments.
    /// </summary>
    [Reference(typeof(CommentDao), ReferenceAttribute.JoinType.Left, true, "parent_commentID")]
    public List<CommentDao?> ParentComment { get; set; }

    /// <summary>
    ///     The User who created the Comment. This is a Reference to the User Table. It is a Foreign Key.
    /// </summary>
    [Reference(typeof(UserDao), ReferenceAttribute.JoinType.Inner, true, "userID")]
    public UserDao? CreatorUser { get; set; }

    /// <summary>
    ///     The ID of the User who created the Comment. This is a Foreign Key to the User Table.
    /// </summary>
    [Column("creator_UserID")]
    public Guid? CreatorUserId { get; set; }

    /// <summary>
    ///     The Post the Comment is related to. This is a Reference to the Post Table. It is a Foreign Key.
    /// </summary>
    [Reference(typeof(PostsDao), ReferenceAttribute.JoinType.Inner, true, "postID")]
    public PostsDao? Post { get; set; }

    /// <summary>
    ///     The ID of the Post the Comment is related to. This is a Foreign Key to the Post Table.
    /// </summary>
    [Column("corresponding_PostID")]
    public Guid? PostId { get; set; }

    /// <summary>
    ///     The Content of the Comment.
    /// </summary>
    [Column("content")]
    public string? Content { get; set; }

    /// <summary>
    ///     The Date and Time the Comment was created.
    /// </summary>
    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
}