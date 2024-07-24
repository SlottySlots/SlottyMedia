using Supabase.Postgrest.Attributes;

namespace SlottyMedia.Backend.Models;

/// <summary>
/// This class represents the Comment table in the database.
/// </summary>
[Table("Comment")]
public class CommentDto
{
    [PrimaryKey("commentID", true)] public int CommentId { get; set; }
    [Column("parent_commentID")] public string? ParentCommentId { get; set; }
    [Column("creator_userID")] public string CreatorUserId { get; set; }
    [Column("corresponding_PostID")] public string PostId { get; set; }
    [Column("content")] public string Content { get; set; }
    [Column("created_at")] public DateTime CreatedAt { get; set; }
}