using Microsoft.AspNetCore.Components;
using Microsoft.IdentityModel.Tokens;
using SlottyMedia.Backend.Dtos;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.LoggingProvider;

namespace SlottyMedia.Backend.ViewModel.Partial.MainLayout;

/// <inheritdoc />
public class PostSubmissionFormVmImpl : IPostSubmissionFormVm
{
    private static readonly Logging<PostSubmissionFormVmImpl> Logger = new();

    private readonly IAuthService _authService;
    private readonly IForumService _forumService;
    private readonly Logging<PostSubmissionFormVmImpl> _logger = new();
    private readonly NavigationManager _navigationManager;
    private readonly IPostService _postService;
    private readonly ISearchService _searchService;
    private readonly IUserService _userService;

    /// <summary>
    ///     Ctor used for dep inject
    /// </summary>
    public PostSubmissionFormVmImpl(
        IAuthService authService,
        IPostService postService,
        IForumService forumService,
        ISearchService searchService,
        NavigationManager navigationManager,
        IUserService userService)
    {
        _authService = authService;
        _postService = postService;
        _forumService = forumService;
        _searchService = searchService;
        _navigationManager = navigationManager;
        _userService = userService;
    }

    /// <inheritdoc />
    public string? Text { get; set; }

    /// <inheritdoc />
    public string? TextErrorMessage { get; set; }

    /// <inheritdoc />
    public string? SpacePrompt { get; set; }

    /// <inheritdoc />
    public string? SpaceName { get; set; }

    /// <inheritdoc />
    public List<string> SearchedSpaces { get; set; } = [];

    /// <inheritdoc />
    public string? SpaceErrorMessage { get; set; }

    /// <inheritdoc />
    public string? ServerErrorMessage { get; set; }

    /// <inheritdoc />
    public UserInformationDto UserInformation { get; set; } = new(true);

    /// <inheritdoc />
    public bool IsLoading { get; set; }

    /// <inheritdoc />
    public async Task HandleSpacePromptChange(ChangeEventArgs e, EventCallback<string?> promptValueChanged)
    {
        Logger.LogDebug($"User is searching for space in post submission form. Prompt: '{e.Value}'");
        if (e.Value is not null)
        {
            var newValue = e.Value.ToString();
            SpacePrompt = newValue;
            await promptValueChanged.InvokeAsync(newValue);
            var searchResults = await _searchService.SearchByTopic(newValue ?? "");
            SearchedSpaces = searchResults.Forums.Select(forum => forum.Topic).ToList();
        }
    }

    /// <inheritdoc />
    public void HandleSpaceSelection(string spaceName)
    {
        SpaceName = spaceName;
        SpacePrompt = null;
    }

    /// <inheritdoc />
    public void HandleSpaceDeselection()
    {
        SpaceName = null;
    }

    /// <inheritdoc />
    public async Task SubmitForm()
    {
        // reset all error messages when form is (re-)submitted
        _resetErrorMessages();

        // if no user is logged in (for whichever reason): display error
        // This case should never happen. The post submission form should only
        // be accessible to authenticated users!
        // This case is handled nonetheless for safety reasons.
        if (!_authService.IsAuthenticated())
        {
            Logger.LogWarn("An unauthenticated user is attempting to submit a post. Aborting post submission...");
            ServerErrorMessage = "You need to log in to submit a post";
            return;
        }

        // display error when fields are empty
        if (Text.IsNullOrEmpty())
        {
            TextErrorMessage = "Must provide some text in order to submit post";
            return;
        }

        if (SpaceName.IsNullOrEmpty())
        {
            SpaceErrorMessage = "Must provide a space for the post";
            return;
        }

        // attempt to submit post
        try
        {
            var userId = new Guid(_authService.GetCurrentSession()!.User!.Id!);
            // create space first if it doesn't exist
            var doesSpaceExist = await _forumService.ExistsByName(SpaceName!);
            if (!doesSpaceExist)
            {
                Logger.LogInfo($"Creating new space '{SpaceName}'...");
                await _forumService.InsertForum(userId, SpaceName!);
                Logger.LogInfo($"Successfully created space '{SpaceName}'");
            }

            // create post
            var forum = await _forumService.GetForumByName(SpaceName!);
            Logger.LogInfo("Creating post...");
            await _postService.InsertPost(Text!, userId, forum.ForumId);
            Logger.LogInfo("Successfully created post");
        }
        catch (Exception e)
        {
            Logger.LogError($"An error occurred during the post creation: {e.Message}");
            ServerErrorMessage = "An unknown error occurred. Try again later.";
            return;
        }

        // if no errors occurred: redirect to index page
        _navigationManager.NavigateTo("/", true);
    }

    /// <inheritdoc />
    public async Task Initialize(Guid? userId)
    {
        if (userId is not null && UserInformation.Username == "Username is loading..")
            try
            {
                IsLoading = true;
                var userInfo = await _userService.GetUserInfo(userId.Value, false, false);
                if (userInfo is not null) UserInformation = userInfo;
                IsLoading = false;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Failed to load user information");
            }
    }

    private void _resetErrorMessages()
    {
        TextErrorMessage = null;
        SpaceErrorMessage = null;
        ServerErrorMessage = null;
    }
}