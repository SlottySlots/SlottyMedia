# ILikeService

Namespace: SlottyMedia.Backend.Services.Interfaces

Interface for LikeService which handles operations related to likes on posts.

```csharp
public interface ILikeService
```

## Methods

### **InsertLike(Guid, Guid)**

Inserts a like for a given post by a user.

```csharp
Task<bool> InsertLike(Guid userId, Guid postId)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The ID of the user who likes the post.

`postId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The ID of the post to be liked.

#### Returns

[Task&lt;Boolean&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A task that represents the asynchronous operation. The task result contains a boolean indicating whether the
 like was successfully inserted.

#### Exceptions

[LikeIudException](./slottymedia.backend.exceptions.services.likeexceptions.likeiudexception.md)<br>
Thrown when an error occurs during Insert, Update, or Delete operations.

[LikeGeneralException](./slottymedia.backend.exceptions.services.likeexceptions.likegeneralexception.md)<br>
Thrown when a general error occurs.

### **DeleteLike(Guid, Guid)**

Deletes a like for a given post by a user.

```csharp
Task<bool> DeleteLike(Guid userId, Guid postId)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The ID of the user who unlikes the post.

`postId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The ID of the post to be unliked.

#### Returns

[Task&lt;Boolean&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A task that represents the asynchronous operation. The task result contains a boolean indicating whether the
 like was successfully deleted.

#### Exceptions

[LikeNotFoundException](./slottymedia.backend.exceptions.services.likeexceptions.likenotfoundexception.md)<br>
Thrown when the like is not found.

[LikeIudException](./slottymedia.backend.exceptions.services.likeexceptions.likeiudexception.md)<br>
Thrown when an error occurs during Insert, Update, or Delete operations.

[LikeGeneralException](./slottymedia.backend.exceptions.services.likeexceptions.likegeneralexception.md)<br>
Thrown when a general error occurs.

### **GetLikesForPost(Guid)**

Retrieves a list of user IDs who liked a given post.

```csharp
Task<List<Guid>> GetLikesForPost(Guid postId)
```

#### Parameters

`postId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The ID of the post for which to retrieve likes.

#### Returns

[Task&lt;List&lt;Guid&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A task that represents the asynchronous operation. The task result contains a list of user IDs who liked the
 post.

#### Exceptions

[LikeNotFoundException](./slottymedia.backend.exceptions.services.likeexceptions.likenotfoundexception.md)<br>
Thrown when the likes are not found.

[LikeGeneralException](./slottymedia.backend.exceptions.services.likeexceptions.likegeneralexception.md)<br>
Thrown when a general error occurs.
