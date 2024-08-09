using SlottyMedia.Backend.Dtos;
using SlottyMedia.Database;

namespace SlottyMedia.Backend.Services.Interfaces;

/// <summary>
///     Interface for post-related services.
/// </summary>
public interface IPostService
{
    /// <summary>
    ///     DatabaseActions property.
    /// </summary>
    public IDatabaseActions DatabaseActions { get; set; }

    /// <summary>
    ///     Retrieves a list of post titles from a forum for a given user, limited by the specified number.
    /// </summary>
    /// <param name="userId">The ID of the user.</param>
    /// <param name="startOfSet"></param>
    /// <param name="endOfSet"></param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of post titles.</returns>
    public Task<List<string>> GetPostsFromForum(Guid userId, int startOfSet, int endOfSet);

    /// <summary>
    ///     Inserts a new post into the database.
    /// </summary>
    /// <param name="title">The title of the post.</param>
    /// <param name="content">The content of the post</param>
    /// <param name="creatorUserId">The UserId who created the post</param>
    /// <param name="forumId">The forum in which the post was posted</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the inserted post.</returns>
    public Task<PostDto> InsertPost(string title, string content, Guid creatorUserId, Guid forumId);

    /// <summary>
    ///     Updates an existing post in the database.
    /// </summary>
    /// <param name="post">The post to update.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the updated post.</returns>
    Task<PostDto> UpdatePost(PostDto post);

    /// <summary>
    ///     Deletes a post from the database.
    /// </summary>
    /// <param name="post">The the post to delete.</param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result indicates whether the deletion was
    ///     successful.
    /// </returns>
    Task<bool> DeletePost(PostDto post);
}