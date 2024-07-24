using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace SlottyMedia.Backend.Models;

/// <summary>
/// This class represents the Posts table in the database.
/// </summary>
[Table("Posts")]
public class PostsDto : BaseModel
{
    [PrimaryKey("postID", true)] public int PostId { get; set; }

    [Column("creator_userID")] public string UserId { get; set; }

    [Column("associated_forumID")] public int ForumId { get; set; }

    [Column("headline")] public string Headline { get; set; }

    [Column("content")] public string Content { get; set; }

    [Column("created_at")] public DateTime CreatedAt { get; set; }
}