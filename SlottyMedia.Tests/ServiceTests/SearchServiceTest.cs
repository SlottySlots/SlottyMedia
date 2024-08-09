using System.Linq.Expressions;
using Moq;
using SlottyMedia.Backend.Services;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Database;
using SlottyMedia.Database.Daos;
using Supabase.Postgrest;

namespace SlottyMedia.Tests.ServiceTests;

[TestFixture]
public class SearchServiceTests
{
    [SetUp]
    public void Setup()
    {
        _mockDatabaseActions = new Mock<IDatabaseActions>();
        _searchService = new SearchService(_mockDatabaseActions.Object);
    }

    private Mock<IDatabaseActions> _mockDatabaseActions;
    private ISearchService _searchService;

    [Test]
    public async Task SearchByUsernameOrTopic_ShouldReturnUserIds_WhenUsersFound()
    {
        var searchTerm = "testUser";
        var userResults = new List<UserDao> { new() { UserId = Guid.NewGuid() } };

        _mockDatabaseActions.Setup(x => x.GetEntitiesWithSelectorById(
                It.IsAny<Expression<Func<UserDao, object[]>>>(),
                It.IsAny<List<(string, Constants.Operator, string)>>(),
                It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<(string, Constants.Ordering, Constants.NullPosition)[]>()))!
            .ReturnsAsync(userResults);

        var result = await _searchService.SearchByUsernameOrTopic(searchTerm);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Users.Count, Is.EqualTo(1));
        Assert.That(result.Users[0].UserId, Is.EqualTo(userResults[0].UserId));
    }

    [Test]
    public async Task SearchByUsernameOrTopic_ShouldReturnTopicIds_WhenTopicsFound()
    {
        var searchTerm = "testTopic";
        var topicResults = new List<ForumDao> { new() { ForumId = Guid.NewGuid() } };

        _mockDatabaseActions.Setup(x => x.GetEntitiesWithSelectorById(
                It.IsAny<Expression<Func<ForumDao, object[]>>>(),
                It.IsAny<List<(string, Constants.Operator, string)>>(),
                It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<(string, Constants.Ordering, Constants.NullPosition)[]>()))!
            .ReturnsAsync(topicResults);

        var result = await _searchService.SearchByUsernameOrTopic(searchTerm);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Forums.Count, Is.EqualTo(1));
        Assert.That(result.Forums[0].ForumId, Is.EqualTo(topicResults[0].ForumId));
    }

    [Test]
    public async Task SearchByUsernameOrTopic_ShouldReturnEmptyList_WhenNoResultsFound()
    {
        var searchTerm = "nonExistent";
        var emptyResults = new List<UserDao>();

        _mockDatabaseActions.Setup(x => x.GetEntitiesWithSelectorById(
                It.IsAny<Expression<Func<UserDao, object[]>>>(),
                It.IsAny<List<(string, Constants.Operator, string)>>(),
                It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<(string, Constants.Ordering, Constants.NullPosition)[]>()))!
            .ReturnsAsync(emptyResults);

        _mockDatabaseActions.Setup(x => x.GetEntitiesWithSelectorById(
                It.IsAny<Expression<Func<ForumDao, object[]>>>(),
                It.IsAny<List<(string, Constants.Operator, string)>>(),
                It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<(string, Constants.Ordering, Constants.NullPosition)[]>()))!
            .ReturnsAsync(new List<ForumDao>());

        var result = await _searchService.SearchByUsernameOrTopic(searchTerm);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Users, Is.Empty);
        Assert.That(result.Forums, Is.Empty);
    }

    [Test]
    public void SearchByUsernameOrTopic_ShouldThrowException_WhenDatabaseThrowsException()
    {
        var searchTerm = "testUser";

        _mockDatabaseActions.Setup(x => x.GetEntitiesWithSelectorById(
                It.IsAny<Expression<Func<UserDao, object[]>>>(),
                It.IsAny<List<(string, Constants.Operator, string)>>(),
                It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<(string, Constants.Ordering, Constants.NullPosition)[]>()))
            .ThrowsAsync(new Exception("Database error"));

        Assert.ThrowsAsync<Exception>(async () => await _searchService.SearchByUsernameOrTopic(searchTerm));
    }
}