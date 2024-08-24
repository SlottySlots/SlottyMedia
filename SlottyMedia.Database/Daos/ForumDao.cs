using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace SlottyMedia.Database.Daos;

/// <summary>
///     This class represents the Forum table in the database.
/// </summary>
[Table("Forum")]
public class ForumDao : BaseModel
{
    /// <summary>
    ///     The default constructor.
    /// </summary>
    public ForumDao()
    {
        CreatorUserId = Guid.Empty;
        ForumTopic = string.Empty;
        CreatedAt = DateTime.MinValue;
    }

    /// <summary>
    ///     The constructor with parameters.
    /// </summary>
    /// <param name="creatorUserId">The Id of the User who created the Forum</param>
    /// <param name="forumTopic">The Topic of the Forum</param>
    public ForumDao(Guid creatorUserId, string forumTopic)
    {
        CreatorUserId = creatorUserId;
        ForumTopic = forumTopic;
    }

    /// <summary>
    ///     The ID of the Forum. This is the Primary Key. It is auto-generated.
    /// </summary>
    [PrimaryKey("forumID")]
    public Guid? ForumId { get; set; }


    /// <summary>
    ///     The User who created the Forum. This is a Reference to the User Table.
    /// </summary>
    [Reference(typeof(UserDao), ReferenceAttribute.JoinType.Inner, true, "userID")]
    public UserDao? CreatorUser { get; set; }

    /// <summary>
    ///     The ID of the User who created the Forum. This is a Foreign Key to the User Table.
    /// </summary>
    [Column("creator_userID")]
    public Guid? CreatorUserId { get; set; }

    /// <summary>
    ///     The Title of the Forum.
    /// </summary>
    [Column("forumTopic")]
    public string? ForumTopic { get; set; }

    /// <summary>
    ///     Created Date and Time of the Forum.
    /// </summary>
    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    public override string ToString()
    {
        return $"ForumId: {ForumId}, CreatorUserId: {CreatorUserId}, ForumTopic: {ForumTopic}, CreatedAt: {CreatedAt}";
    }
}