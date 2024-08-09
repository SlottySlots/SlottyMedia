using SlottyMedia.Database;
using SlottyMedia.Database.Daos;
using Supabase;

namespace SlottyMedia.Tests.DatabaseTests.DatabaseModelsTests;

/// <summary>
///     Test class for the ForumDao model.
/// </summary>
[TestFixture]
public class ForumDaoTest
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
    }

    /// <summary>
    ///     Setup method to initialize a new ForumDao instance before each test.
    /// </summary>
    [SetUp]
    public void Setup()
    {
        _forumToWorkWith = new ForumDao
        {
            CreatorUserId = _userToWorkWith.UserId,
            ForumTopic = "I'm a Test Forum"
        };
    }

    /// <summary>
    ///     Tear down method to delete the test forum after each test.
    /// </summary>
    [TearDown]
    public async Task TearDown()
    {
        try
        {
            if (_forumToWorkWith.ForumId is null) return;

            var forum = await _databaseActions.GetEntityByField<ForumDao>("forumID",
                _forumToWorkWith.ForumId.ToString() ?? "");
            if (forum != null) await _databaseActions.Delete(forum);
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
            if (_userToWorkWith.UserId is null) return;

            var user = await _databaseActions.GetEntityByField<UserDao>("userID",
                _userToWorkWith.UserId.ToString() ?? "");
            if (user != null) await _databaseActions.Delete(user);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"TearDown failed with exception: {ex.Message}");
        }
    }

    private Client _supabaseClient;
    private IDatabaseActions _databaseActions;
    private ForumDao _forumToWorkWith;
    private UserDao _userToWorkWith;

    /// <summary>
    ///     Test method to insert a new forum into the database.
    /// </summary>
    [Test]
    public async Task Insert()
    {
        try
        {
            var insertedForum = await _databaseActions.Insert(_forumToWorkWith);
            Assert.Multiple(() =>
            {
                Assert.That(insertedForum, Is.Not.Null, "Inserted forum should not be null");
                Assert.That(insertedForum.CreatorUserId, Is.EqualTo(_forumToWorkWith.CreatorUserId),
                    "CreatorUserId should match");
                Assert.That(insertedForum.ForumTopic, Is.EqualTo(_forumToWorkWith.ForumTopic),
                    "ForumTopic should match");
            });

            _forumToWorkWith = insertedForum;
        }
        catch (DatabaseExceptions ex)
        {
            Assert.Fail($"Insert test failed with database exception: {ex.Message}");
        }
    }

    /// <summary>
    ///     Test method to update an existing forum in the database.
    /// </summary>
    [Test]
    public async Task Update()
    {
        try
        {
            var insertedForum = await _databaseActions.Insert(_forumToWorkWith);
            Assert.That(insertedForum, Is.Not.Null, "Inserted forum should not be null");

            insertedForum.ForumTopic = "I'm an updated Test Forum";
            var updatedForum = await _databaseActions.Update(insertedForum);

            Assert.Multiple(() =>
            {
                Assert.That(updatedForum, Is.Not.Null, "Updated forum should not be null");
                Assert.That(updatedForum.ForumId, Is.EqualTo(insertedForum.ForumId), "ForumId should match");
                Assert.That(updatedForum.CreatorUserId, Is.EqualTo(insertedForum.CreatorUserId),
                    "CreatorUserId should match");
                Assert.That(updatedForum.ForumTopic, Is.EqualTo(insertedForum.ForumTopic), "ForumTopic should match");
            });

            _forumToWorkWith = updatedForum;
        }
        catch (DatabaseExceptions ex)
        {
            Assert.Fail($"Update test failed with database exception: {ex.Message}");
        }
    }

    /// <summary>
    ///     Test method to delete an existing forum from the database.
    /// </summary>
    [Test]
    public async Task Delete()
    {
        try
        {
            var insertedForum = await _databaseActions.Insert(_forumToWorkWith);
            Assert.That(insertedForum, Is.Not.Null, "Inserted forum should not be null");

            var deletedForum = await _databaseActions.Delete(insertedForum);
            Assert.That(deletedForum, Is.True, "Deleted forum should not be false");
        }
        catch (DatabaseExceptions ex)
        {
            Assert.Fail($"Delete test failed with database exception: {ex.Message}");
        }
    }

    /// <summary>
    ///     Test method to retrieve a forum by a specific field from the database.
    /// </summary>
    [Test]
    public async Task GetEntityByField()
    {
        try
        {
            var insertedForum = await _databaseActions.Insert(_forumToWorkWith);
            Assert.Multiple(() =>
            {
                Assert.That(insertedForum, Is.Not.Null, "Inserted forum should not be null");
                Assert.That(insertedForum.ForumId, Is.Not.Null, "Inserted forum should have a ForumId");
            });

            var forum = await _databaseActions.GetEntityByField<ForumDao>("forumID",
                insertedForum.ForumId.ToString() ?? "");
            Assert.Multiple(() =>
            {
                Assert.That(forum, Is.Not.Null, "Retrieved forum should not be null");
                if (forum != null)
                {
                    Assert.That(forum.ForumId, Is.EqualTo(insertedForum.ForumId), "ForumId should match");
                    Assert.That(forum.CreatorUserId, Is.EqualTo(insertedForum.CreatorUserId),
                        "CreatorUserId should match");
                    Assert.That(forum.ForumTopic, Is.EqualTo(insertedForum.ForumTopic), "ForumTopic should match");

                    Assert.That(forum.CreatorUser, Is.Not.Null, "Retrieved forum should have a CreatorUser");
                    if (forum.CreatorUser != null)
                    {
                        Assert.That(forum.CreatorUser.UserId, Is.Not.Null,
                            "Retrieved forum's CreatorUser should have a UserId");
                        Assert.That(forum.CreatorUser.UserId, Is.EqualTo(insertedForum.CreatorUserId),
                            "CreatorUserId should match");
                    }
                }
            });

            _forumToWorkWith = forum;
        }
        catch (DatabaseExceptions ex)
        {
            Assert.Fail($"GetEntityByField test failed with database exception: {ex.Message}");
        }
    }
}