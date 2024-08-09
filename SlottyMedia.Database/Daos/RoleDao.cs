using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace SlottyMedia.Database.Daos;

/// <summary>
///     This class represents the Role table in the database.
/// </summary>
[Table("Role")]
public class RoleDao : BaseModel
{
    /// <summary>
    ///     The ID of the Role. This is the Primary Key. It is auto-generated.
    /// </summary>
    [PrimaryKey("roleID", true)]
    public Guid? RoleId { get; set; }

    /// <summary>
    ///     The Name of the Role.
    /// </summary>
    [Column("role")]
    public string? RoleName { get; set; }

    /// <summary>
    ///     The Description of the Role.
    /// </summary>
    [Column("description")]
    public string? Description { get; set; }

    /// <summary>
    ///     The Date and Time the Role was created.
    /// </summary>
    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
}