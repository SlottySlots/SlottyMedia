using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace SlottyMedia.Backend.Models;

/// <summary>
/// This class represents the User_Like_Post_Relation table in the database.
/// </summary>
[Table("User_Like_Post_Relation")]
public class UserLikePostRelationDto : BaseModel
{
    [PrimaryKey("userLikePostRelationID", true)]
    public int UserLikePostRelationId { get; set; }

    [Column("userID")] public string UserId { get; set; }

    [Reference(typeof(PostsDto))] public int PostId { get; set; }

    [Column("created_at")] public DateTime CreatedAt { get; set; }
}