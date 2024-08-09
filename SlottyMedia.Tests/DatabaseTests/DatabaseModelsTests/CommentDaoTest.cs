using SlottyMedia.Database;
using SlottyMedia.Database.Daos;
using Supabase;

namespace SlottyMedia.Tests.DatabaseTests.DatabaseModelsTests;

/// <summary>
///     Test class for the CommentDto model.
/// </summary>
[TestFixture]
public class CommentDaoTest
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

        _postToWorkWith =
            await _databaseActions.Insert(InitializeModels.GetPostsDto(_forumToWorkWith, _userToWorkWith));
    }

    /// <summary>
    ///     Setup method to initialize a new CommentDto instance before each test.
    /// </summary>
    [SetUp]
    public void Setup()
    {
        _commentToWorkWith = new CommentDao
        {
            CreatorUserId = _userToWorkWith.UserId,
            PostId = _postToWorkWith.PostId,
            Content = "I'm a Test Comment"
        };
    }

    /// <summary>
    ///     Tear down method to delete the test comment after each test.
    /// </summary>
    [TearDown]
    public async Task TearDown()
    {
        try
        {
            if (_commentToWorkWith.CommentId is null) return;

            var comment =
                await _databaseActions.GetEntityByField<CommentDao>("commentID",
                    _commentToWorkWith.CommentId.ToString() ?? "");
            if (comment != null) await _databaseActions.Delete(comment);
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
            if (_postToWorkWith.PostId is null || _forumToWorkWith.ForumId is null ||
                _userToWorkWith.UserId is null) return;

            var post = await _databaseActions.GetEntityByField<PostsDao>("postID",
                _postToWorkWith.PostId.ToString() ?? "");
            if (post != null) await _databaseActions.Delete(post);

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
    private CommentDao _commentToWorkWith;
    private UserDao _userToWorkWith;
    private PostsDao _postToWorkWith;
    private ForumDao _forumToWorkWith;

    /// <summary>
    ///     Test method to insert a new comment into the database.
    /// </summary>
    [Test]
    public async Task Insert()
    {
        try
        {
            var insertedComment = await _databaseActions.Insert(_commentToWorkWith);
            Assert.That(insertedComment, Is.Not.Null, "Inserted comment should not be null");
            Assert.That(insertedComment.CreatorUserId, Is.EqualTo(_commentToWorkWith.CreatorUserId),
                "CreatorUserId should match");
            Assert.That(insertedComment.Content, Is.EqualTo(_commentToWorkWith.Content), "Content should match");

            _commentToWorkWith = insertedComment;
        }
        catch (DatabaseExceptions ex)
        {
            Assert.Fail($"Insert test failed with database exception: {ex.Message}");
        }
    }

    /// <summary>
    ///     Test method to update an existing comment in the database.
    /// </summary>
    [Test]
    public async Task Update()
    {
        try
        {
            var insertedComment = await _databaseActions.Insert(_commentToWorkWith);
            Assert.That(insertedComment, Is.Not.Null, "Inserted comment should not be null");

            insertedComment.Content = "I'm an updated Test Comment";
            var updatedComment = await _databaseActions.Update(insertedComment);

            Assert.Multiple(() =>
            {
                Assert.That(updatedComment, Is.Not.Null, "Updated comment should not be null");
                Assert.That(updatedComment.CreatorUserId, Is.EqualTo(insertedComment.CreatorUserId),
                    "CreatorUserId should match");
                Assert.That(updatedComment.Content, Is.EqualTo(insertedComment.Content), "Content should match");
            });
            _commentToWorkWith = updatedComment;
        }
        catch (DatabaseExceptions ex)
        {
            Assert.Fail($"Update test failed with database exception: {ex.Message}");
        }
    }

    /// <summary>
    ///     Test method to delete an existing comment from the database.
    /// </summary>
    [Test]
    public async Task Delete()
    {
        try
        {
            var insertedComment = await _databaseActions.Insert(_commentToWorkWith);
            Assert.That(insertedComment, Is.Not.Null, "Inserted comment should not be null");

            var deletedComment = await _databaseActions.Delete(insertedComment);
            Assert.That(deletedComment, Is.True, "Deleted comment should not be false");
        }
        catch (DatabaseExceptions ex)
        {
            Assert.Fail($"Delete test failed with database exception: {ex.Message}");
        }
    }

    /// <summary>
    ///     Test method to retrieve a comment by a specific field from the database.
    /// </summary>
    [Test]
    public async Task GetEntityByField()
    {
        try
        {
            var insertedComment = await _databaseActions.Insert(_commentToWorkWith);
            //var insertedSubcomment = await _databaseActions.Insert(_subcommentToWorkWith);
            Assert.Multiple(() =>
            {
                Assert.That(insertedComment, Is.Not.Null, "Inserted comment should not be null");
                Assert.That(insertedComment.CommentId, Is.Not.Null, "Inserted comment ID should not be null");
            });


            var comment =
                await _databaseActions.GetEntityByField<CommentDao>("commentID",
                    insertedComment.CommentId.ToString() ?? "");
            Assert.Multiple(() =>
            {
                Assert.That(comment, Is.Not.Null, "Retrieved comment should not be null");
                if (comment != null)
                {
                    Assert.That(comment.CreatorUserId, Is.Not.Null, "Retrieved comment should have a CreatorUserId");
                    Assert.That(comment.CreatorUserId, Is.EqualTo(insertedComment.CreatorUserId),
                        "CreatorUserId should match");
                    Assert.That(comment.Content, Is.EqualTo(insertedComment.Content), "Content should match");

                    Assert.That(comment.CreatorUser, Is.Not.Null, "Retrieved comment should have a CreatorUser");
                    if (comment.CreatorUser != null)
                    {
                        Assert.That(comment.CreatorUser.UserId, Is.Not.Null, "CreatorUser should have a UserId");
                        Assert.That(comment.CreatorUser.UserId, Is.EqualTo(insertedComment.CreatorUserId),
                            "CreatorUserId should match");
                    }

                    Assert.That(comment.Post, Is.Not.Null, "Retrieved comment should have a Post");
                    if (comment.Post != null)
                    {
                        Assert.That(comment.Post.PostId, Is.Not.Null, "Post should have a PostId");
                        Assert.That(comment.Post.PostId, Is.EqualTo(insertedComment.PostId), "PostId should match");

                        Assert.That(comment.Post.Forum, Is.Not.Null, "Post should have a Forum");
                        if (comment.Post.Forum != null)
                        {
                            Assert.That(comment.Post.Forum.ForumId, Is.Not.Null, "Forum should have a ForumId");
                            Assert.That(comment.Post.Forum.ForumId, Is.EqualTo(_forumToWorkWith.ForumId),
                                "ForumId should match");
                        }
                    }
                }
            });

            _commentToWorkWith = comment;
        }
        catch (DatabaseExceptions ex)
        {
            Assert.Fail($"GetEntityByField test failed with database exception: {ex.Message}");
        }
    }
}