using SlottyMedia.Backend.Models;

namespace SlottyMedia.Backend.Services.Interfaces;

public interface IUserService
{
    Task<UserDto> GetUserById(string userId);
    Task<UserDto> CreateUser(string userId, string username, string? description = null, long? profilePicture = null);
    Task<UserDto> UpdateUser(UserDto user);
    Task<bool> DeleteUser(UserDto user);
}