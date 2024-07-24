using System.ComponentModel;
using SlottyMedia.Backend.Models;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Backend.ViewModel.Interfaces;

namespace SlottyMedia.Backend.ViewModel;

public class CounterVm : ICounterVm, INotifyPropertyChanged
{
    private UserDto _user;
    private readonly IUserService _userService;
    public event PropertyChangedEventHandler PropertyChanged;

    public CounterVm(IUserService userService)
    {
        _user = new UserDto();
        _userService = userService;
    }

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public UserDto User
    {
        get => _user;
        set
        {
            _user = value;
            OnPropertyChanged(nameof(User));
        }
    }

    public async Task GetUserById(string userId)
    {
        User = await _userService.GetUserById(userId);
    }
}