using System.Linq.Expressions;
using Moq;
using SlottyMedia.Backend.Dtos;
using SlottyMedia.Backend.Services;
using SlottyMedia.Database;
using SlottyMedia.Database.Daos;
using Supabase.Postgrest;

namespace SlottyMedia.Tests.ServiceTests;

[TestFixture]
public class PostServiceTests
{
    [SetUp]
    public void Setup()
    {
        _mockDatabaseActions = new Mock<IDatabaseActions>();
        _postService = new PostService(_mockDatabaseActions.Object);
    }

    private Mock<IDatabaseActions> _mockDatabaseActions;
    private PostService _postService;

    /// <summary>
    ///     Tests that InsertPost returns the inserted post when the post is successfully inserted.
    /// </summary>
    [Test]
    public async Task InsertPost_ShouldReturnInsertedPost()
    {
        var post = new PostsDao
        {
            Headline = "Test Title",
            Content = "Test Content",
            UserId = Guid.NewGuid(),
            ForumId = Guid.NewGuid()
        };

        _mockDatabaseActions.Setup(x => x.Insert(It.IsAny<PostsDao>())).ReturnsAsync(post);

        var result = await _postService.InsertPost(post.Headline, post.Content, post.UserId ?? Guid.Empty,
            post.ForumId ?? Guid.Empty);

        Assert.That(result.Headline, Is.EqualTo(post.Headline));
        Assert.That(result.Content, Is.EqualTo(post.Content));
        Assert.That(result.UserId, Is.EqualTo(post.UserId));
    }

    /// <summary>
    ///     Tests that InsertPost returns null when an exception is thrown.
    /// </summary>
    [Test]
    public async Task InsertPost_ShouldReturnNull_WhenExceptionIsThrown()
    {
        var post = new PostsDao
        {
            Headline = "Test Title",
            Content = "Test Content",
            UserId = Guid.NewGuid(),
            ForumId = Guid.NewGuid()
        };

        _mockDatabaseActions.Setup(x => x.Insert(It.IsAny<PostsDao>())).ThrowsAsync(new Exception());

        var result = await _postService.InsertPost(post.Headline, post.Content, post.UserId ?? Guid.Empty,
            post.ForumId ?? Guid.Empty);

        Assert.That(result, Is.Null);
    }

    /// <summary>
    ///     Tests that UpdatePost returns the updated post when the post is successfully updated.
    /// </summary>
    [Test]
    public async Task UpdatePost_ShouldReturnUpdatedPost()
    {
        var post = new PostsDao
        {
            Headline = "Updated Title",
            Content = "Updated Content",
            UserId = Guid.NewGuid(),
            ForumId = Guid.NewGuid()
        };

        _mockDatabaseActions.Setup(x => x.Update(It.IsAny<PostsDao>())).ReturnsAsync(post);

        var result = await _postService.UpdatePost(new PostDto().Mapper(post));

        Assert.That(result.Headline, Is.EqualTo(post.Headline));
        Assert.That(result.Content, Is.EqualTo(post.Content));
        Assert.That(result.UserId, Is.EqualTo(post.UserId));
    }

    /// <summary>
    ///     Tests that UpdatePost returns null when an exception is thrown.
    /// </summary>
    [Test]
    public async Task UpdatePost_ShouldReturnNull_WhenExceptionIsThrown()
    {
        var post = new PostsDao
        {
            Headline = "Updated Title",
            Content = "Updated Content",
            UserId = Guid.NewGuid(),
            ForumId = Guid.NewGuid()
        };

        _mockDatabaseActions.Setup(x => x.Update(It.IsAny<PostsDao>())).ThrowsAsync(new Exception());

        var result = await _postService.UpdatePost(new PostDto().Mapper(post));

        Assert.That(result, Is.Null);
    }

    /// <summary>
    ///     Tests that DeletePost returns true when the post is successfully deleted.
    /// </summary>
    [Test]
    public async Task DeletePost_ShouldReturnTrue()
    {
        var post = new PostsDao
        {
            Headline = "Test Title",
            Content = "Test Content",
            UserId = Guid.NewGuid(),
            ForumId = Guid.NewGuid()
        };

        _mockDatabaseActions.Setup(x => x.Delete(It.IsAny<PostsDao>())).ReturnsAsync(true);

        var result = await _postService.DeletePost(new PostDto().Mapper(post));

        Assert.That(result, Is.True);
    }

    /// <summary>
    ///     Tests that DeletePost returns false when an exception is thrown.
    /// </summary>
    [Test]
    public async Task DeletePost_ShouldReturnFalse_WhenExceptionIsThrown()
    {
        var post = new PostsDao
        {
            Headline = "Test Title",
            Content = "Test Content",
            UserId = Guid.NewGuid(),
            ForumId = Guid.NewGuid()
        };

        _mockDatabaseActions.Setup(x => x.Delete(It.IsAny<PostsDao>())).ThrowsAsync(new Exception());

        var result = await _postService.DeletePost(new PostDto().Mapper(post));

        Assert.That(result, Is.False);
    }

    /// <summary>
    ///     Tests that GetPostsFromForum returns a list of post titles when the posts are successfully retrieved.
    /// </summary>
    [Test]
    public async Task GetPostsFromForum_ShouldReturnListOfPostTitles()
    {
        var userId = Guid.NewGuid();
        var posts = new List<PostsDao>
        {
            new() { Forum = new ForumDao { ForumTopic = "Forum1" } },
            new() { Forum = new ForumDao { ForumTopic = "Forum2" } }
        };

        var tuple = ("created_at", Constants.Ordering.Descending, Constants.NullPosition.Last);

        _mockDatabaseActions.Setup(x => x.GetEntitiesWithSelectorById(It.IsAny<Expression<Func<PostsDao, object[]>>>(),
                "creator_userID", userId.ToString(), 0, 10,
                tuple))!
            .ReturnsAsync(posts);

        var result = await _postService.GetPostsFromForum(userId, 0, 10);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Count, Is.EqualTo(2));
        Assert.That(result[0], Is.EqualTo("Forum1"));
        Assert.That(result[1], Is.EqualTo("Forum2"));
    }

    /// <summary>
    ///     Tests that GetPostsFromForum returns an empty list when an exception is thrown.
    /// </summary>
    [Test]
    public async Task GetPostsFromForum_ShouldReturnEmptyList_WhenExceptionIsThrown()
    {
        var userId = Guid.NewGuid();

        _mockDatabaseActions.Setup(x => x.GetEntitiesWithSelectorById(It.IsAny<Expression<Func<PostsDao, object[]>>>(),
                "creator_userID", userId.ToString(), 0, 10))
            .ThrowsAsync(new Exception());

        var result = await _postService.GetPostsFromForum(userId, 0, 10);

        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.Empty);
    }

    /// <summary>
    ///     Tests that GetPostsByUserId returns a list of PostDto when the posts are successfully retrieved.
    /// </summary>
    [Test]
    public async Task GetPostsByUserId_ShouldReturnListOfPostDtos()
    {
        var userId = Guid.NewGuid();
        var posts = new List<PostsDao>
        {
            new() { PostId = Guid.NewGuid(), Content = "Content1", Forum = new ForumDao(), CreatedAt = DateTime.Now },
            new() { PostId = Guid.NewGuid(), Content = "Content2", Forum = new ForumDao(), CreatedAt = DateTime.Now }
        };

        var search = new List<(string, Constants.Operator, string)>
        {
            ("creator_userID", Constants.Operator.Equals, userId.ToString())
        };

        var tuple = ("created_at", Constants.Ordering.Descending, Constants.NullPosition.Last);

        _mockDatabaseActions.Setup(x => x.GetEntitiesWithSelectorById(It.IsAny<Expression<Func<PostsDao, object[]>>>(),
                search, 0, 10,
                tuple))
            .ReturnsAsync(posts);

        var result = await _postService.GetPostsByUserId(userId, 0, 10);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Count, Is.EqualTo(2));
        Assert.That(result[0].Content, Is.EqualTo("Content1"));
        Assert.That(result[1].Content, Is.EqualTo("Content2"));
    }

    /// <summary>
    ///     Tests that GetPostsByUserId returns an empty list when an exception is thrown.
    /// </summary>
    [Test]
    public async Task GetPostsByUserId_ShouldReturnEmptyList_WhenExceptionIsThrown()
    {
        var userId = Guid.NewGuid();

        var search = new List<(string, Constants.Operator, string)>
        {
            ("creator_userID", Constants.Operator.Equals, userId.ToString())
        };

        _mockDatabaseActions.Setup(x => x.GetEntitiesWithSelectorById(It.IsAny<Expression<Func<PostsDao, object[]>>>(),
                search, 0, 10))
            .ThrowsAsync(new Exception());

        var result = await _postService.GetPostsByUserId(userId, 0, 10);

        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.Empty);
    }

    /// <summary>
    ///     Tests that GetPostsByUserIdByForumId returns a list of PostDto when the posts are successfully retrieved.
    /// </summary>
    [Test]
    public async Task GetPostsByUserIdByForumId_ShouldReturnListOfPostDtos()
    {
        var userId = Guid.NewGuid();
        var forumId = Guid.NewGuid();
        var posts = new List<PostsDao>
        {
            new() { PostId = Guid.NewGuid(), Content = "Content1", Forum = new ForumDao(), CreatedAt = DateTime.Now },
            new() { PostId = Guid.NewGuid(), Content = "Content2", Forum = new ForumDao(), CreatedAt = DateTime.Now }
        };

        var search = new List<(string, Constants.Operator, string)>
        {
            ("creator_userID", Constants.Operator.Equals, userId.ToString()),
            ("associated_forumID", Constants.Operator.Equals, forumId.ToString())
        };

        var tuple = ("created_at", Constants.Ordering.Descending, Constants.NullPosition.Last);

        _mockDatabaseActions.Setup(x => x.GetEntitiesWithSelectorById(It.IsAny<Expression<Func<PostsDao, object[]>>>(),
                search, 0, 10, tuple))
            .ReturnsAsync(posts);

        var result = await _postService.GetPostsByUserIdByForumId(userId, 0, 10, forumId);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Count, Is.EqualTo(2));
        Assert.That(result[0].Content, Is.EqualTo("Content1"));
        Assert.That(result[1].Content, Is.EqualTo("Content2"));
    }

    /// <summary>
    ///     Tests that GetPostsByUserIdByForumId returns an empty list when an exception is thrown.
    /// </summary>
    [Test]
    public async Task GetPostsByUserIdByForumId_ShouldReturnEmptyList_WhenExceptionIsThrown()
    {
        var userId = Guid.NewGuid();
        var forumId = Guid.NewGuid();

        var search = new List<(string, Constants.Operator, string)>
        {
            ("creator_userID", Constants.Operator.Equals, userId.ToString()),
            ("associated_forumID", Constants.Operator.Equals, forumId.ToString())
        };

        _mockDatabaseActions.Setup(x => x.GetEntitiesWithSelectorById(It.IsAny<Expression<Func<PostsDao, object[]>>>(),
                search, 0, 10))
            .ThrowsAsync(new Exception());

        var result = await _postService.GetPostsByUserIdByForumId(userId, 0, 10, forumId);

        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.Empty);
    }

    /// <summary>
    ///     Tests that GetPostsByForumId returns a list of PostDto when the posts are successfully retrieved.
    /// </summary>
    [Test]
    public async Task GetPostsByForumId_ShouldReturnListOfPostDtos()
    {
        var forumId = Guid.NewGuid();
        var posts = new List<PostsDao>
        {
            new() { PostId = Guid.NewGuid(), Content = "Content1", Forum = new ForumDao(), CreatedAt = DateTime.Now },
            new() { PostId = Guid.NewGuid(), Content = "Content2", Forum = new ForumDao(), CreatedAt = DateTime.Now }
        };

        var search = new List<(string, Constants.Operator, string)>
            { ("associated_forumID", Constants.Operator.Equals, forumId.ToString()) };

        var tuple = ("created_at", Constants.Ordering.Descending, Constants.NullPosition.Last);

        _mockDatabaseActions.Setup(x => x.GetEntitiesWithSelectorById(It.IsAny<Expression<Func<PostsDao, object[]>>>(),
                search, 0, 10,
                tuple))
            .ReturnsAsync(posts);

        var result = await _postService.GetPostsByForumId(forumId, 0, 10);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Count, Is.EqualTo(2));
        Assert.That(result[0].Content, Is.EqualTo("Content1"));
        Assert.That(result[1].Content, Is.EqualTo("Content2"));
    }

    /// <summary>
    ///     Tests that GetPostsByForumId returns an empty list when an exception is thrown.
    /// </summary>
    [Test]
    public async Task GetPostsByForumId_ShouldReturnEmptyList_WhenExceptionIsThrown()
    {
        var forumId = Guid.NewGuid();

        var search = new List<(string, Constants.Operator, string)>
            { ("associated_forumID", Constants.Operator.Equals, forumId.ToString()) };

        _mockDatabaseActions.Setup(x => x.GetEntitiesWithSelectorById(It.IsAny<Expression<Func<PostsDao, object[]>>>(),
                search, 0, 10))
            .ThrowsAsync(new Exception());

        var result = await _postService.GetPostsByForumId(forumId, 0, 10);

        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.Empty);
    }
}