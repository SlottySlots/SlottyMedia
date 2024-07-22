using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace SlottyMedia.Backend.Models;

[Table("Posts")]
public class PostsDto : BaseModel
{
    [PrimaryKey("postID", true)] public int PostId { get; set; }

    [Reference(typeof(UserDto))] public string UserId { get; set; }

    [Reference(typeof(ForumDto))] public int ForumId { get; set; }

    [Column("headline")] public string Headline { get; set; }

    [Column("content")] public string Content { get; set; }

    [Column("created_at")] public DateTime CreatedAt { get; set; }
}