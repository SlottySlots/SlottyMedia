using System.ComponentModel;
using SlottyMedia.Backend.Models;

namespace SlottyMedia.Backend.ViewModel.Interfaces;

/// <summary>
/// This interface represents the CounterVm class.
/// </summary>
public interface ICounterVm
{
    /// <summary>
    /// This Method gets a user by their ID.
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public Task GetUserById(string userId);

    /// <summary>
    /// This is the User Object which can be accessed by the View.
    /// </summary>
    public UserDto User { get; set; }
}