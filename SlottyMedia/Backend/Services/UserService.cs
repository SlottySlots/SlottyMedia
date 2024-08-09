using SlottyMedia.Backend.Dtos;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Database;
using SlottyMedia.Database.Daos;

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
    ///     This method creates a new User object in the database and returns the created object.
    /// </summary>
    /// <param name="userId">The ID we get from the Supabase Authentication Service</param>
    /// <param name="username">The Username of the User</param>
    /// <param name="description">The Description of the User</param>
    /// <param name="profilePicture">The Profile Picture of the User</param>
    /// <returns>Returns the Created UserDao. If it was unable to create a User, it will return null</returns>
    public async Task<UserDto> CreateUser(string userId, string username, string? description = null,
        long? profilePicture = null)
    {
        var user = new UserDao
        {
            UserId = Guid.Parse(userId),
            UserName = username,
            Description = description ?? string.Empty,
            ProfilePic = profilePicture ?? 0
        };

        try
        {
            var result = await _databaseActions.Insert(user);
            return new UserDto().Mapper(result);
        }
        catch (Exception ex)
        {
            // Log the exception and return null
            // TODO: Implement proper error handling
            return null;
        }
    }

    /// <summary>
    ///     This method deletes the given User object from the database.
    /// </summary>
    /// <param name="user">The User Object to delete</param>
    /// <returns>Returns whether it was possible to Delete the User or not. If it was possible it will return true.</returns>
    public async Task<bool> DeleteUser(UserDto user)
    {
        try
        {
            return await _databaseActions.Delete(user.Mapper());
        }
        catch (Exception ex)
        {
            // Log the exception and return false
            // TODO: Implement proper error handling
            return false;
        }
    }

    /// <summary>
    ///     This method returns a User object from the database based on the given userId.
    /// </summary>
    /// <param name="userId">The ID of the User to get from the Database</param>
    /// <returns>Returns the User Object from the Database. If no User was found, null will be returned</returns>
    public async Task<UserDto> GetUserById(Guid userId)
    {
        try
        {
            var user = await _databaseActions.GetEntityByField<UserDao>("userID", userId.ToString());
            if (user is null) throw new Exception("User not found");

            return new UserDto().Mapper(user);
        }
        catch (Exception ex)
        {
            // Log the exception and return null
            // TODO: Implement proper error handling
            return null;
        }
    }

    /// <summary>
    ///     This method fetches a user by their username. Returns null if no user was found.
    /// </summary>
    /// <param name="username"></param>
    /// <returns></returns>
    public async Task<UserDto?> GetUserByUsername(string username)
    {
        try
        {
            var result = await _databaseActions.GetEntityByField<UserDao>("userName", username);
            return new UserDto().Mapper(result);
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    /// <summary>
    ///     This method updates the given User object in the database and returns the updated object.
    /// </summary>
    /// <param name="user">The updated User Dto</param>
    /// <returns>Returns the Updated User Interface. If it was unable to Update the User, it will return null.</returns>
    public async Task<UserDto> UpdateUser(UserDto user)
    {
        try
        {
            var result = await _databaseActions.Update(user.Mapper());
            return new UserDto().Mapper(result);
        }
        catch (Exception ex)
        {
            // Log the exception and return null
            // TODO: Implement proper error handling
            return null;
        }
    }

    /// <summary>
    ///     This method returns the Profile Picture of the given User.
    /// </summary>
    /// <param name="userId">The ID of the User</param>
    /// <returns>Returns the Profile Picture of the User</returns>
    /// <exception cref="Exception">Throws an exception if the user is not found</exception>
    public async Task<ProfilePicDto> GetProfilePic(Guid userId)
    {
        try
        {
            var user = await GetUserDaoById(userId);
            if (user == null) throw new Exception("User not found");
            return new ProfilePicDto
            {
                UserId = userId,
                ProfilePic = user.ProfilePic ?? 0
            };
        }
        catch (Exception ex)
        {
            // Log the exception and return a default ProfilePicDto
            // TODO: Implement proper error handling
            return new ProfilePicDto();
        }
    }

    /// <summary>
    ///     This method returns a UserDto object from the database based on the given userId.
    /// </summary>
    /// <param name="userId">The Id of the user</param>
    /// <param name="recentForums">The maximum number of recent forums to retrieve</param>
    /// <returns>Returns the UserDto object</returns>
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
        catch (Exception ex)
        {
            // Log the exception and return a default UserDto
            // TODO: Implement proper error handling
            return new UserDto();
        }
    }

    /// <summary>
    ///     This method returns a list of friends for the given user.
    /// </summary>
    /// <param name="userId">The ID of the user</param>
    /// <returns>Returns a FriendsOfUserDto object containing the list of friends</returns>
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
        catch (Exception ex)
        {
            // Log the exception and return a default FriendsOfUserDto
            // TODO: Implement proper error handling
            return new FriendsOfUserDto();
        }
    }

    /// <summary>
    ///     This method returns a User object from the database based on the given userId.
    /// </summary>
    /// <param name="userId">The ID of the User to get from the Database</param>
    /// <returns>Returns the User Object from the Database. If no User was found, null will be returned</returns>
    private async Task<UserDao> GetUserDaoById(Guid userId)
    {
        try
        {
            var user = await _databaseActions.GetEntityByField<UserDao>("userID", userId.ToString());
            if (user is null) throw new Exception("User not found");

            return user;
        }
        catch (Exception ex)
        {
            // Log the exception and return null
            // TODO: Implement proper error handling
            return null;
        }
    }
}