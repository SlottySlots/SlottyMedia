using Bogus;
using SlottyMedia.Database.Daos;

namespace SlottyMedia.DatabaseSeeding;

internal class Rules
{
    /// <summary>
    ///     This method creates the rules for the UserDao.
    /// </summary>
    /// <returns></returns>
    internal Faker<UserDao> UserRules()
    {
        var userFaker = new Faker<UserDao>()
            .RuleFor(u => u.UserId, f => f.Random.Guid())
            .RuleFor(u => u.RoleId, Guid.Parse("c0589855-a81c-451d-8587-3061926a1f3a"))
            .RuleFor(u => u.UserName, f => f.Internet.UserName())
            .RuleFor(u => u.Description, f => f.Lorem.Sentence())
            .RuleFor(u => u.ProfilePic, f => f.Random.Long(1, 1000))
            .RuleFor(u => u.CreatedAt, f => f.Date.Past());
        return userFaker;
    }

    /// <summary>
    ///     This method creates the rules for the ForumDao.
    /// </summary>
    /// <param name="userFaker"></param>
    /// <returns></returns>
    internal Faker<ForumDao> ForumRules(List<Guid> userIds)
    {
        var forumFaker = new Faker<ForumDao>()
            .RuleFor(f => f.ForumId, f => f.Random.Guid())
            .RuleFor(f => f.CreatorUserId, f => userIds[f.Random.Int(0, userIds.Count - 1)])
            .RuleFor(f => f.ForumTopic, f => f.Lorem.Sentence())
            .RuleFor(f => f.CreatedAt, f => f.Date.Past());
        return forumFaker;
    }

    /// <summary>
    ///     This method creates the rules for the PostsDao.
    /// </summary>
    /// <param name="userFaker"></param>
    /// <param name="forumFaker"></param>
    /// <returns></returns>
    internal Faker<PostsDao> PostRules(List<Guid> userIds, List<Guid> forumIds)
    {
        var postFaker = new Faker<PostsDao>()
            .RuleFor(p => p.PostId, f => f.Random.Guid())
            .RuleFor(p => p.UserId, f => userIds[f.Random.Int(0, userIds.Count - 1)])
            .RuleFor(p => p.ForumId, f => forumIds[f.Random.Int(0, forumIds.Count - 1)])
            .RuleFor(p => p.Headline, f => f.Lorem.Sentence())
            .RuleFor(p => p.Content, f => f.Lorem.Paragraphs())
            .RuleFor(p => p.CreatedAt, f => f.Date.Past());
        return postFaker;
    }

    /// <summary>
    ///     This method creates the rules for the CommentDto.
    /// </summary>
    /// <param name="userFaker"></param>
    /// <param name="postFaker"></param>
    /// <returns></returns>
    internal Faker<CommentDao> CommentRules(List<Guid> userIds, List<Guid> postIds)
    {
        var commentFaker = new Faker<CommentDao>()
            .RuleFor(c => c.CommentId, f => f.Random.Guid())
            .RuleFor(c => c.CreatorUserId, f => userIds[f.Random.Int(0, userIds.Count - 1)])
            .RuleFor(c => c.PostId, f => postIds[f.Random.Int(0, userIds.Count - 1)])
            .RuleFor(c => c.Content, f => f.Lorem.Paragraph())
            .RuleFor(c => c.CreatedAt, f => f.Date.Past());
        return commentFaker;
    }

    /// <summary>
    ///     This method creates the rules for the FollowerUserRelationDao.
    /// </summary>
    /// <param name="userFaker"></param>
    /// <returns></returns>
    internal Faker<FollowerUserRelationDao> FollowerUserRelationRules(List<Guid> userIds)
    {
        if (userIds.Count < 2)
            throw new ArgumentException("At least two userIds are required to generate follower relations.");

        var existingRelations = new HashSet<(Guid, Guid)>();
        var followerUserRelationFaker = new Faker<FollowerUserRelationDao>()
            .RuleFor(f => f.FollowerUserRelationId, f => f.Random.Guid())
            .RuleFor(f => f.FollowerUserId, f =>
            {
                Guid followerId;
                Guid followedId;
                do
                {
                    followerId = userIds[f.Random.Int(0, userIds.Count - 1)];
                    followedId = userIds[f.Random.Int(0, userIds.Count - 1)];
                } while (followerId == followedId || existingRelations.Contains((followerId, followedId)));

                existingRelations.Add((followerId, followedId));
                return followerId;
            })
            .RuleFor(f => f.FollowedUserId,
                (f, relation) =>
                {
                    return existingRelations.FirstOrDefault(r => r.Item1 == relation.FollowerUserId).Item2;
                })
            .RuleFor(f => f.CreatedAt, f => f.Date.Past());

        return followerUserRelationFaker;
    }

    /// <summary>
    ///     This method creates the rules for the UserLikePostRelationDao.
    /// </summary>
    /// <param name="userFaker"></param>
    /// <param name="postFaker"></param>
    /// <returns></returns>
    internal Faker<UserLikePostRelationDao> UserLikePostRelationRules(List<Guid> userIds, List<Guid> postIds)
    {
        var existingRelations = new HashSet<(Guid, Guid)>();
        var userLikePostRelationFaker = new Faker<UserLikePostRelationDao>()
            .RuleFor(ul => ul.UserLikePostRelationId, f => f.Random.Guid())
            .RuleFor(ul => ul.UserId, f =>
            {
                Guid userId;
                Guid postId;
                do
                {
                    userId = userIds[f.Random.Int(0, userIds.Count - 1)];
                    postId = postIds[f.Random.Int(0, postIds.Count - 1)];
                } while (existingRelations.Contains((userId, postId)));

                existingRelations.Add((userId, postId));
                return userId;
            })
            .RuleFor(ul => ul.PostId,
                (f, relation) => { return existingRelations.FirstOrDefault(r => r.Item1 == relation.UserId).Item2; })
            .RuleFor(ul => ul.CreatedAt, f => f.Date.Past());

        return userLikePostRelationFaker;
    }
}