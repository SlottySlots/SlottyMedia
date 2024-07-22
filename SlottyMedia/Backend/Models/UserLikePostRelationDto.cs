using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace SlottyMedia.Backend.Models;

[Table("User_Like_Post_Relation")]
public class UserLikePostRelationDto : BaseModel
{
    [PrimaryKey("userLikePostRelationID", true)]
    public int UserLikePostRelationId { get; set; }

    [Reference(typeof(UserDto))] public string UserId { get; set; }

    [Reference(typeof(PostsDto))] public int PostId { get; set; }

    [Column("created_at")] public DateTime CreatedAt { get; set; }
}