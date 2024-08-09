using SlottyMedia.Backend.Dtos;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Database;
using SlottyMedia.Database.Daos;
using Supabase.Postgrest;

namespace SlottyMedia.Backend.Services;

/// <summary>
///     Service for searching users and topics.
/// </summary>
public class SearchService : ISearchService
{
    private readonly IDatabaseActions _databaseActions;

    /// <summary>
    ///     Constructor to initialize the database actions dependency.
    /// </summary>
    /// <param name="databaseActions">The database actions dependency.</param>
    public SearchService(IDatabaseActions databaseActions)
    {
        _databaseActions = databaseActions;
    }

    /// <summary>
    ///     Method to search for users or topics by a given search term.
    /// </summary>
    /// <param name="searchTerm">The search term to look for.</param>
    /// <returns>Returns a list of user or topic IDs that match the search term.</returns>
    public async Task<SearchDto> SearchByUsernameOrTopic(string searchTerm)
    {
        var userSearch = new List<(string, Constants.Operator, string)>
        {
            ("userName", Constants.Operator.Equals, searchTerm)
        };

        var topicSearch = new List<(string, Constants.Operator, string)>
        {
            ("forumTopic", Constants.Operator.Equals, searchTerm)
        };
        var userResults = await _databaseActions.GetEntitiesWithSelectorById<UserDao>(
            u => new object[] { u.UserId! }, userSearch);
        var topicResults = await _databaseActions.GetEntitiesWithSelectorById<ForumDao>(
            f => new object[] { f.ForumId! }, topicSearch);
        if (userResults is null) userResults = new List<UserDao>()!;

        if (topicResults is null) topicResults = new List<ForumDao>()!;

        var searchResult = new SearchDto();

        searchResult.Users.AddRange(userResults.Select(x => new UserDto().Mapper(x)));
        searchResult.Forums.AddRange(topicResults.Select(x => new ForumDto().Mapper(x)));

        return searchResult;
    }
}