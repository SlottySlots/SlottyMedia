using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace SlottyMedia.Database.Daos;

/// <summary>
///     This class represents the Follower_User_Relation table in the database.
/// </summary>
[Table("Follower_User_Relation")]
public class FollowerUserRelationDao : BaseModel
{
    /// <summary>
    ///     Default constructor.
    /// </summary>
    public FollowerUserRelationDao()
    {
    }

    /// <summary>
    ///     Constructor to create a new FollowerUserRelation.
    /// </summary>
    /// <param name="followerUserId">The ID of the User who is following another User.</param>
    /// <param name="followedUserId">The ID of the User who is being followed.</param>
    public FollowerUserRelationDao(Guid followerUserId, Guid followedUserId)
    {
        FollowerUserId = followerUserId;
        FollowedUserId = followedUserId;
    }

    /// <summary>
    ///     The ID of the Follower_User_Relation. This is the Primary Key. It is auto-generated.
    /// </summary>
    [PrimaryKey("followerUserRelationID")]
    public Guid? FollowerUserRelationId { get; set; }

    /// <summary>
    ///     The User who is following another User. This is a Reference to the User Table.
    /// </summary>
    [Reference(typeof(UserDao), ReferenceAttribute.JoinType.Left,
        foreignKey: "User!Follower_User_Relation_userIsFollowing_fkey")]
    public UserDao? FollowerUser { get; set; }

    /// <summary>
    ///     The ID of the User who is following another User. This is a Foreign Key to the User Table.
    /// </summary>
    [Column("userIsFollowing")]
    public Guid? FollowerUserId { get; set; }

    /// <summary>
    ///     The User who is being followed. This is a Reference to the User Table.
    /// </summary>
    [Reference(typeof(UserDao), ReferenceAttribute.JoinType.Left,
        foreignKey: "User!Follower_User_Relation_userIsFollowed_fkey")]
    public UserDao? FollowedUser { get; set; }

    /// <summary>
    ///     The ID of the User who is being followed. This is a Foreign Key to the User Table.
    /// </summary>
    [Column("userIsFollowed")]
    public Guid? FollowedUserId { get; set; }

    /// <summary>
    ///     The Date and Time the Follower_User_Relation was created.
    /// </summary>
    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
}