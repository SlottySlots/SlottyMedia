# IPostService

Namespace: SlottyMedia.Backend.Services.Interfaces

Interface for post-related services.

```csharp
public interface IPostService
```

## Properties

### **DatabaseActions**

DatabaseActions property.

```csharp
public abstract IDatabaseActions DatabaseActions { get; set; }
```

#### Property Value

IDatabaseActions<br>

## Methods

### **GetPostsFromForum(Guid, Int32, Int32)**

Retrieves a list of post titles from a forum for a given user, limited by the specified number.

```csharp
Task<List<string>> GetPostsFromForum(Guid userId, int startOfSet, int endOfSet)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The ID of the user.

`startOfSet` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

`endOfSet` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

#### Returns

[Task&lt;List&lt;String&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A task that represents the asynchronous operation. The task result contains a list of post titles.

### **InsertPost(String, String, Guid, Guid)**

Inserts a new post into the database.

```csharp
Task<PostDto> InsertPost(string title, string content, Guid creatorUserId, Guid forumId)
```

#### Parameters

`title` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The title of the post.

`content` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The content of the post

`creatorUserId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The UserId who created the post

`forumId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The forum in which the post was posted

#### Returns

[Task&lt;PostDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A task that represents the asynchronous operation. The task result contains the inserted post.

### **UpdatePost(PostDto)**

Updates an existing post in the database.

```csharp
Task<PostDto> UpdatePost(PostDto post)
```

#### Parameters

`post` [PostDto](./slottymedia.backend.dtos.postdto.md)<br>
The post to update.

#### Returns

[Task&lt;PostDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A task that represents the asynchronous operation. The task result contains the updated post.

### **DeletePost(PostDto)**

Deletes a post from the database.

```csharp
Task<bool> DeletePost(PostDto post)
```

#### Parameters

`post` [PostDto](./slottymedia.backend.dtos.postdto.md)<br>
The the post to delete.

#### Returns

[Task&lt;Boolean&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A task that represents the asynchronous operation. The task result indicates whether the deletion was
 successful.
