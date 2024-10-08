﻿using SlottyMedia.Database.Daos;
using SlottyMedia.Database.Exceptions;

namespace SlottyMedia.Database.Repository.SearchRepo;

/// <summary>
///     Interface for the Forum Search Repository.
/// </summary>
public interface IForumSearchRepository : IDatabaseRepository<ForumDao>
{
    /// <summary>
    ///     Gets forums by a specific topic with pagination.
    /// </summary>
    /// <param name="topic">The topic to search for.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of forums.</returns>
    /// <exception cref="DatabaseMissingItemException">Thrown when the entity is not found in the database.</exception>
    /// <exception cref="GeneralDatabaseException">Thrown when an unexpected error occurs.</exception>
    /// <exception cref="DatabaseJsonConvertFailed">Thrown when the Database Result was not able to be converted to a Class Dao</exception>
    public Task<List<ForumDao>> GetForumsByTopic(string topic);
}