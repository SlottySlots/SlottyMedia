using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Database;
using SlottyMedia.Database.Models;
using Supabase.Gotrue;
using Client = Supabase.Client;

namespace SlottyMedia.Backend.Services;

public class UserService : IUserService
{
    private readonly Client _supabaseClient;
    private readonly DatabaseActions _databaseActions;

    /// <summary>
    /// This constructor creates a new UserService object.
    /// </summary>
    /// <param name="supabaseClient">Supabase Client to interact with the database</param>
    public UserService(Client supabaseClient)
    {
        _supabaseClient = supabaseClient;
        _databaseActions = new DatabaseActions(supabaseClient);
    }

    /// <summary>
    /// This method creates a new User object in the database and returns the created object.
    /// </summary>
    /// <param name="userId">The ID we get from the Supabase Authentication Service</param>
    /// <param name="username">The Username of the User</param>
    /// <param name="description">The Description of the User</param>
    /// <param name="profilePicture">The Profile Picture of the User</param>
    /// <returns>Returns the Created UserDto. If it was unable to create a User, it will return null</returns>
    public async Task<UserDto?> CreateUser(string userId, string username, string? description = null,
        long? profilePicture = null)
    {
        var user = new UserDto
        {
            UserId = userId,
            UserName = username,
            Description = description ?? string.Empty,
            ProfilePic = profilePicture ?? 0
        };
        try
        {
             return await _databaseActions.Insert(user);
        }
        catch (Exception e)
        {
            //TODO Implement how we should handle errors in the View
            return null;
        }
    }

    /// <summary>
    /// This method deletes the given User object from the database.
    /// </summary>
    /// <param name="user">The User Object to delete</param>
    /// <returns>Returns wheter it was possible to Delete the User or not. IF it was Possible it will return true.</returns>
    public async Task<bool> DeleteUser(UserDto user)
    {
        try
        {
            return await _databaseActions.Delete(user);
        }
        catch (Exception e)
        {
            //TODO Implement how we should handle errors in the View
            return false;
        }
        
    }

    /// <summary>
    /// This method returns a User object from the database based on the given userId.
    /// </summary>
    /// <param name="userId">The ID of the User to get from the Database</param>
    /// <returns>Returns the User Object from the Database. If no User was found, null will be returned</returns>
    public async Task<UserDto?> GetUserById(string userId)
    {
        try
        {
return await _databaseActions.GetEntityByField<UserDto>("userID", userId);
        }
        catch (Exception e)
        {
            //TODO Implement how we should handle errors in the View
            return null;
        }
    }

    /// <summary>
    /// This method updates the given User object in the database and returns the updated object.
    /// </summary>
    /// <param name="user">The updated User Dto</param>
    /// <returns>Returns the Updated User Interface. If it was unable to Update the User, it will return null.</returns>
    public async Task<UserDto?> UpdateUser(UserDto user)
    {
        try
        {
return await _databaseActions.Update(user);
        }
        catch (Exception e)
        {
            //TODO Implement how we should handle errors in the View
            return null;
        }
    }
}