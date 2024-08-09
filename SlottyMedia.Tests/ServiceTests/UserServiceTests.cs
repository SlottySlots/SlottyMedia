using System.Linq.Expressions;
using Moq;
using SlottyMedia.Backend.Dtos;
using SlottyMedia.Backend.Services;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Database;
using SlottyMedia.Database.Daos;

namespace SlottyMedia.Tests.ServiceTests;

/// <summary>
///     Test class for UserService.
/// </summary>
[TestFixture]
public class UserServiceTests
{
    /// <summary>
    ///     Sets up the test environment before each test.
    /// </summary>
    [SetUp]
    public void Setup()
    {
        _mockDatabaseActions = new Mock<IDatabaseActions>();
        _mockPostService = new Mock<IPostService>();
        _mockPostService.Object.DatabaseActions = _mockDatabaseActions.Object;
        _userService = new UserService(_mockDatabaseActions.Object, _mockPostService.Object);
    }

    private Mock<IDatabaseActions> _mockDatabaseActions;
    private IUserService _userService;
    private Mock<IPostService> _mockPostService;

    /// <summary>
    ///     Tests that CreateUser returns a User when the user is successfully created.
    /// </summary>
    [Test]
    public async Task CreateUser_ShouldReturnUser_WhenUserIsCreated()
    {
        var userId = Guid.NewGuid();
        var username = "testUsername";
        var user = new UserDao { UserId = userId, UserName = username };
        _mockDatabaseActions.Setup(x => x.Insert(It.IsAny<UserDao>())).ReturnsAsync(user);

        var result = await _userService.CreateUser(userId.ToString(), username);

        var resultDao = result.Mapper();

        Assert.That(result, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(resultDao.UserId ?? Guid.Empty, Is.EqualTo(userId));
            Assert.That(resultDao.UserName, Is.EqualTo(username));
        });
    }

    /// <summary>
    ///     Tests that CreateUser returns null when an exception is thrown.
    /// </summary>
    [Test]
    public async Task CreateUser_ShouldReturnNull_WhenExceptionIsThrown()
    {
        var userId = Guid.NewGuid();
        var username = "testUsername";
        _mockDatabaseActions.Setup(x => x.Insert(It.IsAny<UserDao>())).ThrowsAsync(new Exception());

        var result = await _userService.CreateUser(userId.ToString(), username);

        Assert.That(result, Is.Null);
    }

    /// <summary>
    ///     Tests that DeleteUser returns true when the user is successfully deleted.
    /// </summary>
    [Test]
    public async Task DeleteUser_ShouldReturnTrue_WhenUserIsDeleted()
    {
        var user = new UserDao { UserId = Guid.NewGuid() };
        _mockDatabaseActions.Setup(x => x.Delete(It.IsAny<UserDao>())).ReturnsAsync(true);

        var result = await _userService.DeleteUser(new UserDto().Mapper(user));

        Assert.That(result, Is.True);
    }

    /// <summary>
    ///     Tests that DeleteUser returns false when an exception is thrown.
    /// </summary>
    [Test]
    public async Task DeleteUser_ShouldReturnFalse_WhenExceptionIsThrown()
    {
        var user = new UserDao { UserId = Guid.NewGuid() };
        _mockDatabaseActions.Setup(x => x.Delete(It.IsAny<UserDao>())).ThrowsAsync(new Exception());

        var result = await _userService.DeleteUser(new UserDto().Mapper(user));

        Assert.That(result, Is.False);
    }

    /// <summary>
    ///     Tests that GetUserById returns a User when the user exists.
    /// </summary>
    [Test]
    public async Task GetUserById_ShouldReturnUser_WhenUserExists()
    {
        var userId = Guid.NewGuid();
        var user = new UserDao { UserId = userId };
        _mockDatabaseActions.Setup(x => x.GetEntityByField<UserDao>("userID", userId.ToString())).ReturnsAsync(user);

        var result = await _userService.GetUserById(userId);

        var resultDao = result.Mapper();

        Assert.That(resultDao, Is.Not.Null);
        Assert.That(resultDao.UserId ?? Guid.Empty, Is.EqualTo(userId));
    }

    /// <summary>
    ///     Tests that GetUserById returns null when an exception is thrown.
    /// </summary>
    [Test]
    public async Task GetUserById_ShouldReturnNull_WhenExceptionIsThrown()
    {
        var userId = Guid.NewGuid();
        _mockDatabaseActions.Setup(x => x.GetEntityByField<UserDao>("userID", userId.ToString()))
            .ThrowsAsync(new Exception());

        var result = await _userService.GetUserById(userId);

        Assert.That(result, Is.Null);
    }

    /// <summary>
    ///     Tests that UpdateUser returns the updated User when the user is successfully updated.
    /// </summary>
    [Test]
    public async Task UpdateUser_ShouldReturnUpdatedUser_WhenUserIsUpdated()
    {
        var user = new UserDao { UserId = Guid.NewGuid(), UserName = "updatedUsername" };
        _mockDatabaseActions.Setup(x => x.Update(It.IsAny<UserDao>())).ReturnsAsync(user);

        var result = await _userService.UpdateUser(new UserDto().Mapper(user));
        var resultDao = result.Mapper();

        Assert.That(resultDao, Is.Not.Null);
        Assert.That(resultDao.UserName, Is.EqualTo("updatedUsername"));
    }

    /// <summary>
    ///     Tests that UpdateUser returns null when an exception is thrown.
    /// </summary>
    [Test]
    public async Task UpdateUser_ShouldReturnNull_WhenExceptionIsThrown()
    {
        var user = new UserDao { UserId = Guid.NewGuid(), UserName = "updatedUsername" };
        _mockDatabaseActions.Setup(x => x.Update(It.IsAny<UserDao>())).ThrowsAsync(new Exception());

        var result = await _userService.UpdateUser(new UserDto().Mapper(user));

        Assert.That(result, Is.Null);
    }

    /// <summary>
    ///     Tests that GetProfilePic returns the profile picture when the user exists.
    /// </summary>
    [Test]
    public async Task GetProfilePic_ShouldReturnProfilePic_WhenUserExists()
    {
        var userId = Guid.NewGuid();
        var user = new UserDao { UserId = userId, ProfilePic = 123 };
        _mockDatabaseActions.Setup(x => x.GetEntityByField<UserDao>("userID", userId.ToString())).ReturnsAsync(user);

        var result = await _userService.GetProfilePic(userId);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.ProfilePic, Is.EqualTo(123));
    }

    /// <summary>
    ///     Tests that GetProfilePic returns the default profile picture when an exception is thrown.
    /// </summary>
    [Test]
    public async Task GetProfilePic_ShouldReturnDefaultProfilePic_WhenExceptionIsThrown()
    {
        var userId = Guid.NewGuid();
        _mockDatabaseActions.Setup(x => x.GetEntityByField<UserDao>("userID", userId.ToString()))
            .ThrowsAsync(new Exception());

        var result = await _userService.GetProfilePic(userId);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.ProfilePic, Is.EqualTo(0));
    }

    /// <summary>
    ///     Tests that GetUser returns a UserDto when the user exists.
    /// </summary>
    [Test]
    public async Task GetUser_ShouldReturnUserDto_WhenUserExists()
    {
        var userId = Guid.NewGuid();
        var user = new UserDao
        {
            UserId = userId, UserName = "testUsername", Description = "testDescription",
            CreatedAt = DateTime.Now
        };

        var forum = new ForumDao { ForumId = Guid.NewGuid(), ForumTopic = "Test Forum" };

        var posts = new List<PostsDao>
        {
            new() { PostId = Guid.NewGuid(), Content = "Test Post 1", ForumId = forum.ForumId },
            new() { PostId = Guid.NewGuid(), Content = "Test Post 2", ForumId = forum.ForumId }
        };

        var forumName = new List<string> { forum.ForumTopic };

        _mockDatabaseActions
            .Setup(x => x.GetEntitieWithSelectorById(It.IsAny<Expression<Func<UserDao, object[]>>>(), "userID",
                userId.ToString())).ReturnsAsync(user);
        _mockPostService
            .Setup(x => x.GetPostsFromForum(userId, 0, 5)).ReturnsAsync(forumName);

        var result = await _userService.GetUser(userId);

        Assert.That(result, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(result.UserId, Is.EqualTo(userId));
            Assert.That(result.Username, Is.EqualTo("testUsername"));
            Assert.That(result.Description, Is.EqualTo("testDescription"));
            Assert.That(result.CreatedAt, Is.EqualTo(user.CreatedAt));
            Assert.That(result.RecentForums, Is.EqualTo(forumName));
        });
    }

    /// <summary>
    ///     Tests that GetUser returns a default UserDto when an exception is thrown.
    /// </summary>
    [Test]
    public async Task GetUser_ShouldReturnDefaultUserDto_WhenExceptionIsThrown()
    {
        var userId = Guid.NewGuid();
        _mockDatabaseActions
            .Setup(x => x.GetEntitieWithSelectorById(It.IsAny<Expression<Func<UserDao, object[]>>>(), "userID",
                userId.ToString())).ThrowsAsync(new Exception());

        var result = await _userService.GetUser(userId);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.UserId, Is.EqualTo(Guid.Empty));
    }

    /// <summary>
    ///     Tests that GetFriends returns a list of friends when the user has friends.
    /// </summary>
    [Test]
    public async Task GetFriends_ShouldReturnFriendsList_WhenUserHasFriends()
    {
        var userId = Guid.NewGuid();
        var friendId = Guid.NewGuid();
        var friendUser = new UserDao { UserId = friendId, UserName = "friendUsername" };
        var friends = new List<FollowerUserRelationDao>
            { new() { FollowerUserId = userId, FollowedUserId = friendId, FollowerUser = friendUser } };
        _mockDatabaseActions
            .Setup(x => x.GetEntitiesWithSelectorById(It.IsAny<Expression<Func<FollowerUserRelationDao, object[]>>>(),
                "followerUserID", userId.ToString(), -1, -1))
            .ReturnsAsync(friends);

        var result = await _userService.GetFriends(userId);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Friends, Has.Count.EqualTo(1));
        Assert.That(result.Friends[0].Username, Is.EqualTo("friendUsername"));
    }

    /// <summary>
    ///     Tests that GetFriends returns a default FriendsOfUserDto when an exception is thrown.
    /// </summary>
    [Test]
    public async Task GetFriends_ShouldReturnDefaultFriendsList_WhenExceptionIsThrown()
    {
        var userId = Guid.NewGuid();
        _mockDatabaseActions
            .Setup(x => x.GetEntitiesWithSelectorById(It.IsAny<Expression<Func<FollowerUserRelationDao, object[]>>>(),
                "followerUserID", userId.ToString(), -1, -1))
            .ThrowsAsync(new Exception());

        var result = await _userService.GetFriends(userId);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Friends, Is.Empty);
    }
}