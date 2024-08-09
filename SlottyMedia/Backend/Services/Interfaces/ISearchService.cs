using SlottyMedia.Backend.Dtos;

namespace SlottyMedia.Backend.Services.Interfaces;

/// <summary>
///     This interface is used to define the Search Service.
/// </summary>
public interface ISearchService
{
    /// <summary>
    ///     This method searches for a user by username or topic.
    /// </summary>
    /// <param name="searchTerm"></param>
    /// <returns></returns>
    public Task<SearchDto> SearchByUsernameOrTopic(string searchTerm);
}