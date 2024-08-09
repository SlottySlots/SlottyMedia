namespace SlottyMedia.Backend.Dtos;

/// <summary>
///     The Friends of a User
/// </summary>
public class FriendsOfUserDto
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="FriendsOfUserDto" /> class.
    /// </summary>
    public FriendsOfUserDto()
    {
        UserId = Guid.Empty;
        Friends = new List<UserDto>();
    }

    /// <summary>
    ///     Gets or sets the User Id.
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    ///     Gets or sets the list of friends of the user.
    /// </summary>
    public List<UserDto> Friends { get; set; }
}