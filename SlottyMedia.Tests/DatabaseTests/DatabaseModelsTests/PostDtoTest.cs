using SlottyMedia.Database;
using SlottyMedia.Database.Daos;
using Supabase;

namespace SlottyMedia.Tests.DatabaseTests.DatabaseModelsTests;

/// <summary>
///     Test class for the PostsDao model.
/// </summary>
[TestFixture]
public class PostDtoTest
{
    /// <summary>
    ///     One-time setup method to initialize Supabase client and insert test data.
    /// </summary>
    [OneTimeSetUp]
    public async Task OneTimeSetup()
    {
        _supabaseClient = InitializeSupabaseClient.GetSupabaseClient();
        _databaseActions = new DatabaseActions(_supabaseClient);

        _userToWorkWith = await _databaseActions.Insert(InitializeModels.GetUserDto());

        _forumToWorkWith = await _databaseActions.Insert(InitializeModels.GetForumDto(_userToWorkWith));
    }

    /// <summary>
    ///     Setup method to initialize a new PostsDao instance before each test.
    /// </summary>
    [SetUp]
    public void Setup()
    {
        _postToWorkWith = new PostsDao
        {
            ForumId = _forumToWorkWith.ForumId,
            UserId = _userToWorkWith.UserId,
            Headline = "I'm a Test Posts Headline",
            Content = "I'm a Test Post"
        };
    }

    /// <summary>
    ///     Tear down method to delete the test post after each test.
    /// </summary>
    [TearDown]
    public async Task TearDown()
    {
        try
        {
            if (_postToWorkWith.PostId is null) return;

            var post = await _databaseActions.GetEntityByField<PostsDao>("postID",
                _postToWorkWith.PostId.ToString() ?? "");
            if (post != null) await _databaseActions.Delete(post);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"TearDown failed with exception: {ex.Message}");
        }
    }

    /// <summary>
    ///     One-time tear down method to delete the test data after all tests are run.
    /// </summary>
    [OneTimeTearDown]
    public async Task OneTimeTearDown()
    {
        try
        {
            if (_forumToWorkWith.ForumId is null || _userToWorkWith.UserId is null) return;

            var forum = await _databaseActions.GetEntityByField<ForumDao>("forumID",
                _forumToWorkWith.ForumId.ToString() ?? "");
            if (forum != null) await _databaseActions.Delete(forum);

            var user = await _databaseActions.GetEntityByField<UserDao>("userID",
                _userToWorkWith.UserId.ToString() ?? "");
            if (user != null) await _databaseActions.Delete(user);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"OneTimeTearDown failed with exception: {ex.Message}");
        }
    }

    private Client _supabaseClient;
    private IDatabaseActions _databaseActions;
    private PostsDao _postToWorkWith;
    private UserDao _userToWorkWith;
    private ForumDao _forumToWorkWith;

    /// <summary>
    ///     Test method to insert a new post into the database.
    /// </summary>
    [Test]
    public async Task Insert()
    {
        try
        {
            var insertedPost = await _databaseActions.Insert(_postToWorkWith);
            Assert.Multiple(() =>
            {
                Assert.That(insertedPost, Is.Not.Null, "Inserted post should not be null");
                Assert.That(insertedPost.UserId, Is.EqualTo(_postToWorkWith.UserId), "CreatorUserId should match");
                Assert.That(insertedPost.Content, Is.EqualTo(_postToWorkWith.Content), "Content should match");
            });

            _postToWorkWith = insertedPost;
        }
        catch (DatabaseExceptions ex)
        {
            Assert.Fail($"Insert test failed with database exception: {ex.Message}");
        }
    }

    /// <summary>
    ///     Test method to update an existing post in the database.
    /// </summary>
    [Test]
    public async Task Update()
    {
        try
        {
            var insertedPost = await _databaseActions.Insert(_postToWorkWith);
            Assert.That(insertedPost, Is.Not.Null, "Inserted post should not be null");

            insertedPost.Content = "I'm an updated Test Post";
            var updatedPost = await _databaseActions.Update(insertedPost);

            Assert.Multiple(() =>
            {
                Assert.That(updatedPost, Is.Not.Null, "Updated post should not be null");
                Assert.That(updatedPost.PostId, Is.EqualTo(insertedPost.PostId), "PostId should match");
                Assert.That(updatedPost.UserId, Is.EqualTo(insertedPost.UserId), "CreatorUserId should match");
                Assert.That(updatedPost.Content, Is.EqualTo(insertedPost.Content), "Content should match");
            });

            _postToWorkWith = updatedPost;
        }
        catch (DatabaseExceptions ex)
        {
            Assert.Fail($"Update test failed with database exception: {ex.Message}");
        }
    }

    /// <summary>
    ///     Test method to delete an existing post from the database.
    /// </summary>
    [Test]
    public async Task Delete()
    {
        try
        {
            var insertedPost = await _databaseActions.Insert(_postToWorkWith);
            Assert.That(insertedPost, Is.Not.Null, "Inserted post should not be null");

            var deletedPost = await _databaseActions.Delete(insertedPost);
            Assert.That(deletedPost, Is.True, "Deleted post should not be false");
        }
        catch (DatabaseExceptions ex)
        {
            Assert.Fail($"Delete test failed with database exception: {ex.Message}");
        }
    }

    /// <summary>
    ///     Test method to retrieve a post by a specific field from the database.
    /// </summary>
    [Test]
    public async Task GetEntityByField()
    {
        try
        {
            var insertedPost = await _databaseActions.Insert(_postToWorkWith);
            Assert.Multiple(() =>
            {
                Assert.That(insertedPost, Is.Not.Null, "Inserted post should not be null");
                Assert.That(insertedPost.PostId, Is.Not.Null, "Inserted post's PostId should not be null");
            });

            var post = await _databaseActions.GetEntityByField<PostsDao>("postID",
                insertedPost.PostId.ToString() ?? string.Empty);
            Assert.Multiple(() =>
            {
                Assert.That(post, Is.Not.Null, "Retrieved post should not be null");
                if (post != null)
                {
                    Assert.That(post.PostId, Is.EqualTo(insertedPost.PostId), "PostId should match");
                    Assert.That(post.UserId, Is.EqualTo(insertedPost.UserId), "CreatorUserId should match");
                    Assert.That(post.Content, Is.EqualTo(insertedPost.Content), "Content should match");

                    Assert.That(post.User is not null, "User should not be null");
                    if (post.User != null)
                        Assert.That(post.User.UserId, Is.EqualTo(insertedPost.UserId), "User's UserId should match");

                    Assert.That(post.Forum is not null, "Forum should not be null");
                    if (post.Forum != null)
                        Assert.That(post.Forum.ForumId, Is.EqualTo(insertedPost.ForumId),
                            "Forum's ForumId should match");
                }
            });

            _postToWorkWith = post;
        }
        catch (DatabaseExceptions ex)
        {
            Assert.Fail($"GetEntityByField test failed with database exception: {ex.Message}");
        }
    }
}