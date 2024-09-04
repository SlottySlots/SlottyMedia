﻿using SlottyMedia.Backend.Dtos;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Backend.ViewModel.Interfaces;
using SlottyMedia.Database.Pagination;
using SlottyMedia.LoggingProvider;

namespace SlottyMedia.Backend.ViewModel;

/// <inheritdoc />
public class SpacesVmImpl : ISpacesVm
{
    private static readonly Logging<SpacesVmImpl> Logger = new();
    private readonly IForumService _forumService;

    /// <summary>Initializes this ViewModel</summary>
    public SpacesVmImpl(IForumService forumService)
    {
        _forumService = forumService ?? throw new ArgumentNullException(nameof(forumService));
        Forums = new List<ForumDto>();
    }

    /// <inheritdoc />
    public List<ForumDto> Forums { get; private set; }

    /// <inheritdoc />
    public async Task LoadForums()
    {
        try
        {
            var page = await _forumService.GetAllForums(PageRequest.OfSize(10));
            Forums = page.Content;
        }
        catch (Exception ex)
        {
            Logger.LogError($"An error occurred while loading forums: {ex.Message}");
        }
    }
}