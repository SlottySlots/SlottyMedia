using System.ComponentModel;
using SlottyMedia.Backend.Models;

namespace SlottyMedia.Backend.ViewModel.Interfaces;

public interface ICounterVm
{
    public Task GetUserById(string userId);

    public UserDto User { get; set; }
}