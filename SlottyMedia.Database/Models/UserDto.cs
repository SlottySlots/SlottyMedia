using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace SlottyMedia.Database.Models;

/// <summary>
/// This class represents the User table in the database.
/// </summary>
[Table("User")]
public class UserDto : BaseModel
{
    /// <summary>
    /// The ID of the User. This is the Primary Key. The User ID is generated by the Supabase Authentication Service.
    /// </summary>
    [PrimaryKey("userID", true)]
    public string UserId { get; set; }

    /// <summary>
    /// The ID of the Role the User has. This is a Foreign Key to the Role Table.
    /// </summary>
    [Column("roleID")]
    public string RoleId { get; set; }

    /// <summary>
    /// The Username of the User.
    /// </summary>
    [Column("userName")]
    public string UserName { get; set; }

    /// <summary>
    /// The Description of the User.
    /// </summary>
    [Column("description")]
    public string? Description { get; set; }

    /// <summary>
    /// The Profile Picture of the User.
    /// </summary>
    [Column("profilePic")]
    public long? ProfilePic { get; set; }

    /// <summary>
    /// The Date and Time the User was created.
    /// </summary>
    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
}