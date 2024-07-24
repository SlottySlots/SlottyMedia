using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace SlottyMedia.Backend.Models;

/// <summary>
/// This class represents the Forum table in the database.
/// </summary>
[Table("Forum")]
public class ForumDto : BaseModel
{
    [PrimaryKey("forumID", true)] public int ForumId { get; set; }

    [Column("creator_userID")] public string CreatorUserId { get; set; }

    [Column("forumTopic")] public string ForumTopic { get; set; }

    [Column("created_at")] public DateTime CreatedAt { get; set; }
}