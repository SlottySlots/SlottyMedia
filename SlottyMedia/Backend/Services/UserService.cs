using SlottyMedia.Backend.Dtos;
using SlottyMedia.Backend.Exceptions.Services.UserExceptions;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Database;
using SlottyMedia.Database.Daos;
using SlottyMedia.Database.Exceptions;

namespace SlottyMedia.Backend.Services;

/// <summary>
///     This class is the User Service. It is responsible for handling all User related operations.
/// </summary>
public class UserService : IUserService
{
    private readonly IDatabaseActions _databaseActions;
    private readonly IPostService _postService;

    /// <summary>
    ///     This constructor creates a new UserService object.
    /// </summary>
    /// <param name="databaseActions">This parameter is used to interact with the database</param>
    /// <param name="postService">This parameter is used to interact with the post service</param>
    public UserService(IDatabaseActions databaseActions, IPostService postService)
    {
        _databaseActions = databaseActions;
        _postService = postService;
    }

    /// <summary>
    ///     This method creates a new User object in the database and returns the created object. This method does not check if
    ///     the User already exists.
    /// </summary>
    /// <param name="userId">The ID we get from the Supabase Authentication Service</param>
    /// <param name="username">The Username of the User</param>
    /// <param name="description">The Description of the User (optional)</param>
    /// <param name="profilePicture">The Profile Picture of the User (optional)</param>
    /// <returns>Returns the created UserDto. If it was unable to create a User, it will throw an exception.</returns>
    public async Task<UserDto> CreateUser(string userId, string username, string email, Guid roleId,
        string? description = null,
        long? profilePicture = null)
    {
        var user = new UserDao
        {
            UserId = Guid.Parse(userId),
            UserName = username,
            Description = description ?? string.Empty,
            ProfilePic = profilePicture ?? 0,
            Email = email,
            RoleId = roleId
        };

        try
        {
            var result = await _databaseActions.Insert(user);
            return new UserDto().Mapper(result);
        }
        catch (DatabaseIudActionException ex)
        {
            throw new UserIudException("An error occurred while creating the user", ex);
        }
        catch (GeneralDatabaseException ex)
        {
            throw new UserGeneralException("A database error occurred while creating the user", ex);
        }
        catch (Exception ex)
        {
            throw new UserGeneralException("An error occurred while creating the user", ex);
        }
    }

    /// <summary>
    ///     This method deletes the given User object from the database.
    /// </summary>
    /// <param name="user">The UserDto object to delete</param>
    /// <returns>Returns true if the User was successfully deleted, otherwise false.</returns>
    public async Task<bool> DeleteUser(UserDto user)
    {
        try
        {
            return await _databaseActions.Delete(user.Mapper());
        }
        catch (DatabaseIudActionException ex)
        {
            throw new UserIudException("An error occurred while deleting the user", ex);
        }
        catch (GeneralDatabaseException ex)
        {
            throw new UserGeneralException("An error occurred while deleting the user", ex);
        }
        catch (Exception ex)
        {
            throw new UserGeneralException("An error occurred while deleting the user", ex);
        }
    }

    /// <summary>
    ///     This method returns a User object from the database based on the given userId.
    /// </summary>
    /// <param name="userId">The ID of the User to get from the Database</param>
    /// <returns>Returns the UserDto object from the Database. If no User was found, it will throw an exception.</returns>
    public async Task<UserDto> GetUserById(Guid userId)
    {
        try
        {
            var user = await _databaseActions.GetEntityByField<UserDao>("userID", userId.ToString());
            return new UserDto().Mapper(user);
        }
        catch (DatabaseMissingItemException ex)
        {
            throw new UserNotFoundException($"User with the given ID was not found. ID: {userId}", ex);
        }
        catch (GeneralDatabaseException ex)
        {
            throw new UserGeneralException("An error occurred while fetching the user", ex);
        }
        catch (Exception ex)
        {
            throw new UserGeneralException("An error occurred while fetching the user", ex);
        }
    }

    /// <summary>
    ///     Gets a UserDTO by its username (usernames are duplicate free)
    /// </summary>
    /// <param name="username">
    ///     Username used for retrieving a user
    /// </param>
    /// <returns>
    ///     The corresponding UserDTO
    /// </returns>
    public virtual async Task<bool> CheckIfUserExistsByUserName(string username)
    {
        try
        {
            var result = await _databaseActions.CheckIfEntityExists<UserDao>("userName", username);
            return result;
        }
        catch (GeneralDatabaseException ex)
        {
            throw new UserGeneralException("An error occurred while checking if the the user exists", ex);
        }
        catch (Exception ex)
        {
            throw new UserGeneralException("A general error occurred while checking if the the user exists", ex);
        }
    }

    /// <summary>
    ///     This method updates the given User object in the database and returns the updated object.
    /// </summary>
    /// <param name="user">The updated UserDto</param>
    /// <returns>Returns the updated UserDto. If it was unable to update the User, it will throw an exception.</returns>
    public async Task<UserDto> UpdateUser(UserDto user)
    {
        try
        {
            var result = await _databaseActions.Update(user.Mapper());
            return new UserDto().Mapper(result);
        }
        catch (DatabaseIudActionException ex)
        {
            throw new UserIudException("An error occurred while updating the user", ex);
        }
        catch (GeneralDatabaseException ex)
        {
            throw new UserGeneralException("An error occurred while updating the user", ex);
        }
        catch (Exception ex)
        {
            throw new UserGeneralException("An error occurred while updating the user", ex);
        }
    }

    /// <summary>
    ///     This method returns the Profile Picture of the given User.
    /// </summary>
    /// <param name="userId">The ID of the User</param>
    /// <returns>Returns the ProfilePicDto containing the Profile Picture of the User.</returns>
    /// <exception cref="UserNotFoundException">Throws an exception if the user is not found</exception>
    public async Task<ProfilePicDto> GetProfilePic(Guid userId)
    {
        try
        {
            var user = await GetUserDaoById(userId);
            return new ProfilePicDto
            {
                UserId = userId,
                ProfilePic = user.ProfilePic ?? 0
            };
        }
        catch (DatabaseMissingItemException ex)
        {
            throw new UserNotFoundException($"User with the given ID was not found. ID: {userId}", ex);
        }
        catch (GeneralDatabaseException ex)
        {
            throw new UserGeneralException("An error occurred while fetching the profile picture", ex);
        }
    }

    /// <summary>
    ///     This method returns a UserDto object from the database based on the given userId.
    /// </summary>
    /// <param name="userId">The ID of the user</param>
    /// <param name="recentForums">The maximum number of recent forums to retrieve</param>
    /// <returns>Returns the UserDto object with recent forums.</returns>
    public async Task<UserDto> GetUser(Guid userId, int recentForums = 5)
    {
        try
        {
            var result = await _databaseActions.GetEntitieWithSelectorById<UserDao>(
                x => new object[] { x.UserId!, x.UserName!, x.Description!, x.CreatedAt }, "userID", userId.ToString());
            var user = new UserDto().Mapper(result);
            user.RecentForums = await _postService.GetPostsFromForum(userId, 0, recentForums);

            return user;
        }
        catch (DatabaseMissingItemException ex)
        {
            throw new UserNotFoundException($"User with the given ID was not found. ID: {userId}", ex);
        }
        catch (GeneralDatabaseException ex)
        {
            throw new UserGeneralException("An error occurred while fetching the user", ex);
        }
        catch (Exception ex)
        {
            throw new UserGeneralException("An error occurred while fetching the user", ex);
        }
    }

    /// <summary>
    ///     This method returns a list of friends for the given user.
    /// </summary>
    /// <param name="userId">The ID of the user</param>
    /// <returns>Returns a FriendsOfUserDto object containing the list of friends.</returns>
    public async Task<FriendsOfUserDto> GetFriends(Guid userId)
    {
        try
        {
            var friends = await _databaseActions.GetEntitiesWithSelectorById<FollowerUserRelationDao>(
                x => new object[] { x.FollowedUserId! }, "followerUserID", userId.ToString());
            var friendList = new FriendsOfUserDto
            {
                UserId = userId,
                Friends = new List<UserDto>()
            };

            foreach (var friend in friends)
                if (friend.FollowerUser != null)
                    friendList.Friends.Add(new UserDto().Mapper(friend.FollowerUser));

            return friendList;
        }
        catch (DatabaseMissingItemException ex)
        {
            throw new UserNotFoundException($"User with the given ID was not found. ID: {userId}", ex);
        }
        catch (GeneralDatabaseException ex)
        {
            throw new UserGeneralException("An error occurred while fetching the friends", ex);
        }
        catch (Exception ex)
        {
            throw new UserGeneralException("An error occurred while fetching the friends", ex);
        }
    }

    /// <summary>
    ///     This method returns a UserDao object from the database based on the given userId.
    /// </summary>
    /// <param name="userId">The ID of the User to get from the Database</param>
    /// <returns>Returns the UserDao object from the Database. If no User was found, it will throw an exception.</returns>
    private async Task<UserDao> GetUserDaoById(Guid userId)
    {
        try
        {
            var user = await _databaseActions.GetEntityByField<UserDao>("userID", userId.ToString());
            return user;
        }
        catch (DatabaseMissingItemException ex)
        {
            throw new UserNotFoundException($"User with the given ID was not found. ID: {userId}", ex);
        }
        catch (GeneralDatabaseException ex)
        {
            throw new UserGeneralException("An error occurred while fetching the user", ex);
        }
    }
}