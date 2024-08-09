using System.Linq.Expressions;
using SlottyMedia.Database;
using SlottyMedia.Database.Daos;
using Supabase;

namespace SlottyMedia.Tests.DatabaseTests;

/// <summary>
///     Tests for DatabaseActions class.
/// </summary>
[TestFixture]
public class DatabaseActionTests
{
    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        _supabaseClient = InitializeSupabaseClient.GetSupabaseClient();
        _databaseActions = new DatabaseActions(_supabaseClient);
    }

    [SetUp]
    public void Setup()
    {
        _userToWorkWith = InitializeModels.GetUserDto();
    }

    [TearDown]
    public async Task TearDown()
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
    private UserDao _userToWorkWith;

    /// <summary>
    ///     Tests the Insert method of DatabaseActions.
    /// </summary>
    [Test]
    public async Task Insert()
    {
        try
        {
            var insertedUser = await _databaseActions.Insert(_userToWorkWith);
            Assert.Multiple(() =>
            {
                Assert.That(insertedUser, Is.Not.Null, "Inserted user should not be null");
                Assert.That(insertedUser.UserId, Is.EqualTo(_userToWorkWith.UserId), "UserId should match");
                Assert.That(insertedUser.UserName, Is.EqualTo(_userToWorkWith.UserName), "UserName should match");
                Assert.That(insertedUser.Description, Is.EqualTo(_userToWorkWith.Description),
                    "Description should match");
            });
        }
        catch (DatabaseExceptions ex)
        {
            Assert.Fail($"Insert test failed with database exception: {ex.Message}");
        }
    }

    /// <summary>
    ///     Tests the Insert method of DatabaseActions for failure.
    /// </summary>
    [Test]
    public void Insert_Failure()
    {
        var invalidUser = new UserDao(); // Create an invalid user to simulate failure
        Assert.ThrowsAsync<DatabaseExceptions>(async () => await _databaseActions.Insert(invalidUser));
    }

    /// <summary>
    ///     Tests the Update method of DatabaseActions.
    /// </summary>
    [Test]
    public async Task Update()
    {
        try
        {
            var insertedUser = await _databaseActions.Insert(_userToWorkWith);
            Assert.That(insertedUser, Is.Not.Null, "Inserted user should not be null");

            insertedUser.Description = "Please don't delete me, I'm updated";
            var updatedUser = await _databaseActions.Update(insertedUser);

            Assert.Multiple(() =>
            {
                Assert.That(updatedUser, Is.Not.Null, "Updated user should not be null");
                Assert.That(updatedUser.UserId, Is.EqualTo(insertedUser.UserId), "UserId should match");
                Assert.That(updatedUser.UserName, Is.EqualTo(insertedUser.UserName), "UserName should match");
                Assert.That(updatedUser.Description, Is.EqualTo(insertedUser.Description), "Description should match");
            });
        }
        catch (DatabaseExceptions ex)
        {
            Assert.Fail($"Update test failed with database exception: {ex.Message}");
        }
    }

    /// <summary>
    ///     Tests the Update method of DatabaseActions for failure.
    /// </summary>
    [Test]
    public void Update_Failure()
    {
        var invalidUser = new UserDao(); // Create an invalid user to simulate failure
        Assert.ThrowsAsync<DatabaseExceptions>(async () => await _databaseActions.Update(invalidUser));
    }

    /// <summary>
    ///     Tests the Delete method of DatabaseActions.
    /// </summary>
    [Test]
    public async Task Delete()
    {
        try
        {
            var insertedUser = await _databaseActions.Insert(_userToWorkWith);
            Assert.That(insertedUser, Is.Not.Null, "Inserted user should not be null");

            var deletedUser = await _databaseActions.Delete(insertedUser);
            Assert.That(deletedUser, Is.True, "Deleted user should not be false");
        }
        catch (DatabaseExceptions ex)
        {
            Assert.Fail($"Delete test failed with database exception: {ex.Message}");
        }
    }

    /// <summary>
    ///     Tests the Delete method of DatabaseActions for failure.
    /// </summary>
    [Test]
    public void Delete_Failure()
    {
        var invalidUser = new UserDao(); // Create an invalid user to simulate failure
        Assert.ThrowsAsync<DatabaseExceptions>(async () => await _databaseActions.Delete(invalidUser));
    }

    /// <summary>
    ///     Tests the GetEntityByField method of DatabaseActions.
    /// </summary>
    [Test]
    public async Task GetEntityByField()
    {
        try
        {
            var insertedUser = await _databaseActions.Insert(_userToWorkWith);
            Assert.Multiple(() =>
            {
                Assert.That(insertedUser, Is.Not.Null, "Inserted user should not be null");
                Assert.That(insertedUser.UserId, Is.Not.Null, "Inserted user's UserId should not be null");
            });

            var user = await _databaseActions.GetEntityByField<UserDao>("userID", insertedUser.UserId.ToString() ?? "");
            Assert.Multiple(() =>
            {
                Assert.That(user, Is.Not.Null, "Retrieved user should not be null");
                if (user != null)
                {
                    Assert.That(user.UserId, Is.EqualTo(insertedUser.UserId), "UserId should match");
                    Assert.That(user.UserName, Is.EqualTo(insertedUser.UserName), "UserName should match");
                    Assert.That(user.Description, Is.EqualTo(insertedUser.Description), "Description should match");

                    Assert.That(user.Role, Is.Not.Null, "Retrieved user should have a Role");
                    if (user.Role != null)
                    {
                        Assert.That(user.Role.RoleId, Is.Not.Null, "Retrieved user's Role should have a RoleId");
                        Assert.That(user.Role.RoleId, Is.EqualTo(_userToWorkWith.RoleId), "Role should match");
                    }
                }
            });
        }
        catch (DatabaseExceptions ex)
        {
            Assert.Fail($"GetEntityByField test failed with database exception: {ex.Message}");
        }
    }

    /// <summary>
    ///     Tests the GetEntityByField method of DatabaseActions for failure.
    /// </summary>
    [Test]
    public void GetEntityByField_Failure()
    {
        Assert.ThrowsAsync<DatabaseExceptions>(async () =>
            await _databaseActions.GetEntityByField<UserDao>("userID", "invalid-id"));
    }

    /// <summary>
    ///     Tests the GetEntitieWithSelectorById method of DatabaseActions.
    /// </summary>
    [Test]
    public async Task GetEntitieWithSelectorById()
    {
        try
        {
            var insertedUser = await _databaseActions.Insert(_userToWorkWith);
            Assert.Multiple(() =>
            {
                Assert.That(insertedUser, Is.Not.Null, "Inserted user should not be null");
                Assert.That(insertedUser.UserId, Is.Not.Null, "Inserted user's UserId should not be null");
            });

            Expression<Func<UserDao, object[]>> selector = u => new object[] { u.UserId!, u.UserName!, u.Description! };
            var user = await _databaseActions.GetEntitieWithSelectorById(selector, "userID",
                insertedUser.UserId.ToString() ?? "");
            Assert.Multiple(() =>
            {
                Assert.That(user, Is.Not.Null, "Retrieved user should not be null");

                Assert.That(user.UserId, Is.EqualTo(insertedUser.UserId), "UserId should match");
                Assert.That(user.UserName, Is.EqualTo(insertedUser.UserName), "UserName should match");
                Assert.That(user.Description, Is.EqualTo(insertedUser.Description), "Description should match");

                // Check that fields not included in the selector are not returned
                Assert.That(user.RoleId, Is.Null, "Retrieved user should not have a RoleId");
                Assert.That(user.CreatedAt, Is.Default, "Retrieved user should not have a CreatedAt");
                Assert.That(user.ProfilePic, Is.Null, "Retrieved user should not have a ProfilePicture");
            });
        }
        catch (DatabaseExceptions ex)
        {
            Assert.Fail($"GetEntitieWithSelectorById test failed with database exception: {ex.Message}");
        }
    }

    /// <summary>
    ///     Tests the GetEntitieWithSelectorById method of DatabaseActions for failure.
    /// </summary>
    [Test]
    public void GetEntitieWithSelectorById_Failure()
    {
        Expression<Func<UserDao, object[]>> selector = u => new object[] { u.UserId!, u.UserName!, u.Description! };
        Assert.ThrowsAsync<DatabaseExceptions>(async () =>
            await _databaseActions.GetEntitieWithSelectorById(selector, "userID", "invalid-id"));
    }

    /// <summary>
    ///     Tests the GetEntitiesWithSelectorById method of DatabaseActions.
    /// </summary>
    [Test]
    public async Task GetEntitiesWithSelectorById()
    {
        try
        {
            var insertedUser = await _databaseActions.Insert(_userToWorkWith);
            Assert.Multiple(() =>
            {
                Assert.That(insertedUser, Is.Not.Null, "Inserted user should not be null");
                Assert.That(insertedUser.UserId, Is.Not.Null, "Inserted user's UserId should not be null");
            });

            Expression<Func<UserDao, object[]>> selector = u => new object[] { u.UserId!, u.UserName!, u.Description! };
            var users = await _databaseActions.GetEntitiesWithSelectorById(selector, "userID",
                insertedUser.UserId.ToString() ?? "");
            Assert.Multiple(() =>
            {
                Assert.That(users, Is.Not.Null, "Retrieved users list should not be null");
                Assert.That(users.Count, Is.GreaterThan(0), "Retrieved users list should contain at least one user");

                foreach (var user in users)
                {
                    Assert.That(user, Is.Not.Null, "Retrieved user should not be null");

                    Assert.That(user.UserId, Is.EqualTo(insertedUser.UserId), "UserId should match");
                    Assert.That(user.UserName, Is.EqualTo(insertedUser.UserName), "UserName should match");
                    Assert.That(user.Description, Is.EqualTo(insertedUser.Description), "Description should match");

                    // Check that fields not included in the selector are not returned
                    Assert.That(user.RoleId, Is.Null, "Retrieved user should not have a RoleId");
                    Assert.That(user.CreatedAt, Is.Default, "Retrieved user should not have a CreatedAt");
                    Assert.That(user.ProfilePic, Is.Null, "Retrieved user should not have a ProfilePicture");
                }
            });
        }
        catch (DatabaseExceptions ex)
        {
            Assert.Fail($"GetEntitiesWithSelectorById test failed with database exception: {ex.Message}");
        }
    }

    /// <summary>
    ///     Tests the GetEntitiesWithSelectorById method of DatabaseActions for failure.
    /// </summary>
    [Test]
    public void GetEntitiesWithSelectorById_Failure()
    {
        Expression<Func<UserDao, object[]>> selector = u => new object[] { u.UserId!, u.UserName!, u.Description! };
        Assert.ThrowsAsync<DatabaseExceptions>(async () =>
            await _databaseActions.GetEntitiesWithSelectorById(selector, "userID", "invalid-id"));
    }
}