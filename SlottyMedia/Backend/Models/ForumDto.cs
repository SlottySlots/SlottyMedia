using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace SlottyMedia.Backend.Models;

[Table("Forum")]
public class ForumDto : BaseModel
{
    [PrimaryKey("forumID", true)] public int ForumId { get; set; }

    [Reference(typeof(UserDto))] public string CreatorUserId { get; set; }

    [Column("forumTopic")] public string ForumTopic { get; set; }

    [Column("created_at")] public DateTime CreatedAt { get; set; }
}