﻿using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Backend.ViewModel.Interfaces;
using Supabase.Gotrue;

namespace SlottyMedia.Backend.ViewModel;

/// <summary>
///     This class implements the IAuthVm interface
/// </summary>
public class AuthVm : IAuthVm
{
    private readonly IAuthService _authService;

    /// <summary>
    ///     This constructor initializes the AuthService
    /// </summary>
    /// <param name="authVmImpl"></param>
    public AuthVm(IAuthService authVmImpl)
    {
        _authService = authVmImpl;
    }

    /// <inheritdoc />
    public Session? GetCurrentSession()
    {
        return _authService.GetCurrentSession();
    }

    /// <inheritdoc />
    public Guid GetCurrentUserId()
    {
        var currentSession = GetCurrentSession();
        return Guid.Parse(currentSession?.User!.Id!);
    }

    /// <inheritdoc />
    public bool IsAuthenticated()
    {
        return _authService.IsAuthenticated();
    }
}