using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace SlottyMedia.Backend.Models;

/// <summary>
/// This class represents the Role table in the database.
/// </summary>
[Table("Role")]
public class RoleDto : BaseModel
{
    [PrimaryKey("roleID", true)] public string RoleId { get; set; }

    [Column("role")] public string RoleName { get; set; }

    [Column("description")] public string Description { get; set; }

    [Column("created_at")] public DateTime CreatedAt { get; set; }
}