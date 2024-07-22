using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace SlottyMedia.Backend.Models;

[Table("User")]
public class UserDto : BaseModel
{
    [PrimaryKey("userID", false)] public string UserId { get; set; }

    // [Reference(typeof(RoleDto), columnName: "role")]
    // public int RoleId { get; set; }

    [Column("userName")] public string UserName { get; set; }

    [Column("description")] public string? Description { get; set; }

    [Column("profilePic")] public long? ProfilePic { get; set; }

    [Column("created_at")] public DateTime CreatedAt { get; set; }
}