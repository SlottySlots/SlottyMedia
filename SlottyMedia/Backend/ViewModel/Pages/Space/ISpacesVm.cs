﻿using SlottyMedia.Backend.Dtos;
using SlottyMedia.Components.Pages;

namespace SlottyMedia.Backend.ViewModel.Pages.Space;

/// <summary>
///     This ViewModel represents the state of the <see cref="Spaces" /> Page.
/// </summary>
public interface ISpacesVm
{
    /// <summary>
    ///     A list containing all spaces that should be rendered
    /// </summary>
    List<ForumDto> Forums { get; }

    /// <summary>
    ///     Indicates whether the ViewModel is currently loading data.
    /// </summary>
    public bool IsLoading { get; }

    /// <summary>
    ///     Fetches all forums and populates the <see cref="Forums" /> property.
    /// </summary>
    Task LoadForums();
}