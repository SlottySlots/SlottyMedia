using SlottyMedia.Backend.Dtos;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Database;
using SlottyMedia.Database.Daos;
using Supabase.Postgrest;

namespace SlottyMedia.Backend.Services;

/// <summary>
///     This class represents the Post Service. It is used to interact with the Post table in the database.
/// </summary>
public class PostService : IPostService
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="PostService" /> class.
    /// </summary>
    /// <param name="databaseActions">The database actions interface.</param>
    public PostService(IDatabaseActions databaseActions)
    {
        DatabaseActions = databaseActions;
    }

    /// <summary>
    ///     Gets or sets the database actions interface.
    /// </summary>
    public IDatabaseActions DatabaseActions { get; set; }

    /// <summary>
    ///     Inserts a new post into the database.
    /// </summary>
    /// <param name="title">The title of the post.</param>
    /// <param name="content">The content of the post.</param>
    /// <param name="creatorUserId">The ID of the user who created the post.</param>
    /// <param name="forumId">The ID of the forum where the post is created.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the inserted post.</returns>
    public async Task<PostDto> InsertPost(string title, string content, Guid creatorUserId, Guid forumId)
    {
        try
        {
            // Create a new post object
            var post = new PostsDao
            {
                Headline = title,
                Content = content,
                UserId = creatorUserId,
                ForumId = forumId
            };

            // Insert the post into the database
            var insertedPost = await DatabaseActions.Insert(post);
            return new PostDto().Mapper(insertedPost);
        }
        catch (Exception ex)
        {
            // TODO: Implement error handling
            return null;
        }
    }

    /// <summary>
    ///     Updates an existing post in the database.
    /// </summary>
    /// <param name="post">The post to update.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the updated post.</returns>
    public async Task<PostDto> UpdatePost(PostDto post)
    {
        try
        {
            // Update the post in the database
            var updatedPost = await DatabaseActions.Update(post.Mapper());
            return new PostDto().Mapper(updatedPost);
        }
        catch (Exception ex)
        {
            // TODO: Implement error handling
            return null;
        }
    }

    /// <summary>
    ///     Deletes a post from the database.
    /// </summary>
    /// <param name="post">The post to delete.</param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result indicates whether the deletion was
    ///     successful.
    /// </returns>
    public async Task<bool> DeletePost(PostDto post)
    {
        try
        {
            // Delete the post from the database
            var result = await DatabaseActions.Delete(post.Mapper());
            return result;
        }
        catch (Exception ex)
        {
            // TODO: Implement error handling
            return false;
        }
    }

    /// <summary>
    ///     Retrieves a list of post titles from a forum for a given user, limited by the specified number.
    /// </summary>
    /// <param name="userId">The ID of the user.</param>
    /// <param name="startOfSet">The starting index of the set.</param>
    /// <param name="endOfSet">The ending index of the set.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of post titles.</returns>
    public async Task<List<string>> GetPostsFromForum(Guid userId, int startOfSet, int endOfSet)
    {
        try
        {
            // Fetch posts from the database based on the user ID and limit
            var posts = await DatabaseActions.GetEntitiesWithSelectorById<PostsDao>(
                x => new object[] { x.Forum! },
                "creator_userID",
                userId.ToString(), startOfSet, endOfSet,
                ("created_at", Constants.Ordering.Descending, Constants.NullPosition.Last)
            );

            // Return the list of forum names associated with the posts
            return posts.Select(post => post.Forum.ForumTopic).ToList();
        }
        catch (Exception ex)
        {
            // TODO: Implement error handling
            return new List<string>();
        }
    }

    /// <summary>
    ///     Retrieves a list of posts from the database based on the given userId.
    /// </summary>
    /// <param name="userId">The ID of the user.</param>
    /// <param name="startOfSet">The starting index of the set.</param>
    /// <param name="endOfSet">The ending index of the set.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of PostDto objects.</returns>
    public async Task<List<PostDto>> GetPostsByUserId(Guid userId, int startOfSet, int endOfSet)
    {
        try
        {
            // Fetch posts from the database based on the user ID and limit
            var posts = await DatabaseActions.GetEntitiesWithSelectorById<PostsDao>(
                x => new object[] { x.PostId!, x.Content!, x.Forum!, x.CreatedAt },
                new List<(string, Constants.Operator, string)>
                {
                    ("creator_userID", Constants.Operator.Equals, userId.ToString())
                },
                startOfSet,
                endOfSet,
                ("created_at", Constants.Ordering.Descending, Constants.NullPosition.Last)
            );

            // Convert the posts to PostDto objects
            return ConvertPostsToPostDtos(posts);
        }
        catch (Exception)
        {
            // TODO: Implement error handling
            return new List<PostDto>();
        }
    }

    /// <summary>
    ///     Retrieves a list of posts from the database based on the given userId and forumId.
    /// </summary>
    /// <param name="userId">The ID of the user.</param>
    /// <param name="startOfSet">The starting index of the set.</param>
    /// <param name="endOfSet">The ending index of the set.</param>
    /// <param name="forumId">The ID of the forum.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of PostDto objects.</returns>
    public async Task<List<PostDto>> GetPostsByUserIdByForumId(Guid userId, int startOfSet, int endOfSet, Guid forumId)
    {
        try
        {
            // Fetch posts from the database based on the user ID, forum ID, and limit
            var posts = await DatabaseActions.GetEntitiesWithSelectorById<PostsDao>(
                x => new object[] { x.PostId!, x.Content!, x.Forum!, x.CreatedAt },
                new List<(string, Constants.Operator, string)>
                {
                    ("creator_userID", Constants.Operator.Equals, userId.ToString()),
                    ("associated_forumID", Constants.Operator.Equals, forumId.ToString())
                },
                startOfSet,
                endOfSet,
                ("created_at", Constants.Ordering.Descending, Constants.NullPosition.Last)
            );

            // Convert the posts to PostDto objects
            return ConvertPostsToPostDtos(posts);
        }
        catch (Exception)
        {
            // TODO: Implement error handling
            return new List<PostDto>();
        }
    }

    /// <summary>
    ///     Retrieves a list of posts from the database based on the given forumId.
    /// </summary>
    /// <param name="forumId">The ID of the forum.</param>
    /// <param name="startOfSet">The starting index of the set.</param>
    /// <param name="endOfSet">The ending index of the set.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of PostDto objects.</returns>
    public async Task<List<PostDto>> GetPostsByForumId(Guid forumId, int startOfSet, int endOfSet)
    {
        try
        {
            // Fetch posts from the database based on the forum ID and limit
            var posts = await DatabaseActions.GetEntitiesWithSelectorById<PostsDao>(
                x => new object[] { x.PostId!, x.Content!, x.Forum!, x.CreatedAt },
                new List<(string, Constants.Operator, string)>
                {
                    ("associated_forumID", Constants.Operator.Equals, forumId.ToString())
                },
                startOfSet,
                endOfSet,
                ("created_at", Constants.Ordering.Descending, Constants.NullPosition.Last)
            );

            // Convert the posts to PostDto objects
            return ConvertPostsToPostDtos(posts);
        }
        catch (Exception)
        {
            // TODO: Implement error handling
            return new List<PostDto>();
        }
    }

    /// <summary>
    ///     Converts a list of PostsDao objects to a list of PostDto objects.
    /// </summary>
    /// <param name="posts">The list of PostsDao objects.</param>
    /// <returns>A list of PostDto objects.</returns>
    private List<PostDto> ConvertPostsToPostDtos(List<PostsDao> posts)
    {
        return posts.Select(post => new PostDto().Mapper(post)).ToList();
    }
}