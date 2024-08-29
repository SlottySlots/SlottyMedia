using SlottyMedia.Backend.Dtos;
using SlottyMedia.Backend.Exceptions.Services.UserExceptions;
using SlottyMedia.Database.Daos;

namespace SlottyMedia.Backend.Services.Interfaces;

/// <summary>
///     This interface defines the methods which can be used to interact with the User table in the database.
/// </summary>
public interface IUserService
{
    /// <summary>
    ///     This method returns a User object from the database based on the given userId.
    /// </summary>
    /// <param name="userId">The UserID inside the Database</param>
    /// <returns>UserDao</returns>
    Task<UserDto> GetUserDtoById(Guid userId);

    /// <summary>
    ///     Fetches a user by their username. Returns null if no user was found.
    /// </summary>
    /// <param name="username">The user's username</param>
    /// <returns>The queried user or null if no such user was found</returns>
    Task<bool> CheckIfUserExistsByUserName(string username);

    /// <summary>
    ///     This method creates a new User object in the database and returns the created object.
    /// </summary>
    /// <param name="userId">The UserID from the Authentication Service</param>
    /// <param name="username">The Username, which the User set himself</param>
    /// <param name="email">The Email of the User</param>
    /// <param name="roleId">The Role ID of the User</param>
    /// <param name="description">The Description about the User</param>
    /// <param name="profilePicture">The ProfilePicture</param>
    /// <returns>UserDto</returns>
    Task CreateUser(string userId, string username, string email, Guid roleId, string? description = null,
        string? profilePicture = null);

    /// <summary>
    ///     This method updates the given User object in the database and returns the updated object.
    /// </summary>
    /// <param name="user">The User object</param>
    /// <returns>UserDao</returns>
    Task UpdateUser(UserDao user);

    /// <summary>
    ///     This method deletes the given User object from the database.
    /// </summary>
    /// <param name="user">The User Object</param>
    /// <returns name="bool">Return if the User got deleted or not</returns>
    Task DeleteUser(UserDto user);

    /// <summary>
    ///     This method returns the Profile Picture of the given User.
    /// </summary>
    /// <param name="userId">The ID of the User</param>
    /// <returns>Returns the Profile Picture of the User</returns>
    Task<ProfilePicDto> GetProfilePic(Guid userId);

    /// <summary>
    ///     This method returns a UserDto object from the database based on the given userId.
    /// </summary>
    /// <param name="userId">The Id of the user</param>
    /// <param name="limit">The maximum number of recent forums to retrieve</param>
    /// <returns>Returns the UserDto object</returns>
    Task<UserDto> GetUser(Guid userId, int limit = 5);

    /// <summary>
    ///     This method returns a list of friends for the given user.
    /// </summary>
    /// <param name="userId">The ID of the user</param>
    /// <returns>Returns a FriendsOfUserDto object containing the list of friends</returns>
    Task<FriendsOfUserDto> GetFriends(Guid userId);

    /// <summary>
    ///     This method retrieves the count of friends for a given user from the database.
    /// </summary>
    /// <param name="userId">The ID of the user whose friends count is to be retrieved.</param>
    /// <returns>Returns the count of friends for the specified user.</returns>
    /// <exception cref="UserGeneralException">
    ///     Thrown when a general database error occurs while fetching the friends count.
    /// </exception>
    public Task<int> GetCountOfUserFriends(Guid userId);

    /// <summary>
    ///     Gets all spaces a user has wrote in
    /// </summary>
    /// <param name="userId">
    ///     User from which it should be retrieved
    /// </param>
    /// <returns>
    ///     Returns the amount of spaces as task
    /// </returns>
    public Task<int> GetCountOfUserSpaces(Guid userId);

    /// <summary>
    ///     Updates the given UserDto object in the database and returns the updated object.
    /// </summary>
    /// <param name="user">The UserDto object to be updated.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the updated UserDto object.</returns>
    public Task UpdateUser(UserDto user);

    public Task<UserDao> GetUserDaoById(Guid userId);
}