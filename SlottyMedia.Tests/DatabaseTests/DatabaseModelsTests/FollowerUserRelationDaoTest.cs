using SlottyMedia.Database;
using SlottyMedia.Database.Daos;
using Supabase;

namespace SlottyMedia.Tests.DatabaseTests.DatabaseModelsTests;

/// <summary>
///     Test class for the FollowerUserRelationDao model.
/// </summary>
[TestFixture]
public class FollowerUserRelationDaoTest
{
    /// <summary>
    ///     One-time setup method to initialize Supabase client and insert test data.
    /// </summary>
    [OneTimeSetUp]
    public async Task OneTimeSetup()
    {
        _supabaseClient = InitializeSupabaseClient.GetSupabaseClient();
        _databaseActions = new DatabaseActions(_supabaseClient);

        _followerUser = await _databaseActions.Insert(InitializeModels.GetUserDto());

        _followedUser = await _databaseActions.Insert(InitializeModels.GetUserDto());
    }

    /// <summary>
    ///     Setup method to initialize a new FollowerUserRelationDao instance before each test.
    /// </summary>
    [SetUp]
    public void Setup()
    {
        _relationToWorkWith = new FollowerUserRelationDao
        {
            FollowerUserId = _followerUser.UserId,
            FollowedUserId = _followedUser.UserId
        };
    }

    /// <summary>
    ///     Tear down method to delete the test relation after each test.
    /// </summary>
    [TearDown]
    public async Task TearDown()
    {
        try
        {
            if (_relationToWorkWith.FollowerUserRelationId is null) return;

            var relation = await _databaseActions.GetEntityByField<FollowerUserRelationDao>("followerUserRelationID",
                _relationToWorkWith.FollowerUserRelationId.ToString() ?? "");
            if (relation != null) await _databaseActions.Delete(relation);
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
            if (_followerUser.UserId is null || _followedUser.UserId is null) return;

            var follower =
                await _databaseActions.GetEntityByField<UserDao>("userID", _followerUser.UserId.ToString() ?? "");
            if (follower != null) await _databaseActions.Delete(follower);

            var followed =
                await _databaseActions.GetEntityByField<UserDao>("userID", _followedUser.UserId.ToString() ?? "");
            if (followed != null) await _databaseActions.Delete(followed);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"OneTimeTearDown failed with exception: {ex.Message}");
        }
    }

    private Client _supabaseClient;
    private IDatabaseActions _databaseActions;
    private FollowerUserRelationDao _relationToWorkWith;
    private UserDao _followerUser;
    private UserDao _followedUser;

    /// <summary>
    ///     Test method to insert a new follower-user relation into the database.
    /// </summary>
    [Test]
    public async Task Insert()
    {
        try
        {
            var insertedRelation = await _databaseActions.Insert(_relationToWorkWith);
            Assert.Multiple(() =>
            {
                Assert.That(insertedRelation, Is.Not.Null, "Inserted relation should not be null");
                Assert.That(insertedRelation.FollowerUserId, Is.EqualTo(_relationToWorkWith.FollowerUserId),
                    "FollowerUserId should match");
                Assert.That(insertedRelation.FollowedUserId, Is.EqualTo(_relationToWorkWith.FollowedUserId),
                    "FollowedUserId should match");
            });

            _relationToWorkWith = insertedRelation;
        }
        catch (DatabaseExceptions ex)
        {
            Assert.Fail($"Insert test failed with database exception: {ex.Message}");
        }
    }

    /// <summary>
    ///     Test method to delete an existing follower-user relation from the database.
    /// </summary>
    [Test]
    public async Task Delete()
    {
        try
        {
            var insertedRelation = await _databaseActions.Insert(_relationToWorkWith);
            Assert.That(insertedRelation, Is.Not.Null, "Inserted relation should not be null");

            var deletedRelation = await _databaseActions.Delete(insertedRelation);
            Assert.That(deletedRelation, Is.True, "Deleted relation should not be false");
        }
        catch (DatabaseExceptions ex)
        {
            Assert.Fail($"Delete test failed with database exception: {ex.Message}");
        }
    }

    /// <summary>
    ///     Test method to retrieve a follower-user relation by a specific field from the database.
    /// </summary>
    [Test]
    public async Task GetEntityByField()
    {
        try
        {
            var insertedRelation = await _databaseActions.Insert(_relationToWorkWith);
            Assert.Multiple(() =>
            {
                Assert.That(insertedRelation, Is.Not.Null, "Inserted relation should not be null");
                Assert.That(insertedRelation.FollowerUserRelationId, Is.Not.Null,
                    "Inserted relation should have a FollowerUserRelationId");
            });

            var relation = await _databaseActions.GetEntityByField<FollowerUserRelationDao>("followerUserRelationID",
                insertedRelation.FollowerUserRelationId.ToString() ?? "");
            Assert.Multiple(() =>
            {
                Assert.That(relation, Is.Not.Null, "Retrieved relation should not be null");
                if (relation != null)
                {
                    Assert.That(relation.FollowerUserId, Is.EqualTo(insertedRelation.FollowerUserId),
                        "FollowerUserId should match");
                    Assert.That(relation.FollowedUserId, Is.EqualTo(insertedRelation.FollowedUserId),
                        "FollowedUserId should match");
                    Assert.That(relation.CreatedAt, Is.EqualTo(insertedRelation.CreatedAt), "CreatedAt should match");
                }
            });

            _relationToWorkWith = relation;
        }
        catch (DatabaseExceptions ex)
        {
            Assert.Fail($"GetEntityByField test failed with database exception: {ex.Message}");
        }
    }
}