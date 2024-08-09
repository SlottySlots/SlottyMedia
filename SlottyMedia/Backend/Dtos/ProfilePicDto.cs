using SlottyMedia.Database.Daos;

namespace SlottyMedia.Backend.Dtos;

/// <summary>
///     The Profile Picture Data Transfer Object
/// </summary>
public class ProfilePicDto
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ProfilePicDto" /> class.
    /// </summary>
    public ProfilePicDto()
    {
        UserId = Guid.Empty;
        ProfilePic = 0;
    }

    /// <summary>
    ///     Gets or sets the User Id.
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    ///     Gets or sets the Profile Picture in binary.
    /// </summary>
    public long ProfilePic { get; set; }

    /// <summary>
    ///     This method maps the ProfilePicDto to a UserDao.
    /// </summary>
    /// <returns></returns>
    public UserDao Mapper()
    {
        return new UserDao
        {
            UserId = UserId,
            ProfilePic = ProfilePic
        };
    }

    /// <summary>
    ///     This method maps the UserDao to a ProfilePicDto.
    /// </summary>
    /// <param name="userDao"></param>
    /// <returns></returns>
    public ProfilePicDto Mapper(UserDao userDao)
    {
        return new ProfilePicDto
        {
            UserId = userDao.UserId ?? Guid.Empty,
            ProfilePic = userDao.ProfilePic ?? 0
        };
    }
}