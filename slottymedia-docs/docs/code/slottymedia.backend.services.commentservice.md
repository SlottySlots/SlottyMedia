# CommentService

Namespace: SlottyMedia.Backend.Services

```csharp
public class CommentService
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [CommentService](./slottymedia.backend.services.commentservice.md)

## Properties

### **DatabaseActions**

DatabaseActions property.

```csharp
public IDatabaseActions DatabaseActions { get; set; }
```

#### Property Value

IDatabaseActions<br>

## Constructors

### **CommentService(IDatabaseActions)**

Initializes a new instance of the [PostService](./slottymedia.backend.services.postservice.md) class.

```csharp
public CommentService(IDatabaseActions databaseActions)
```

#### Parameters

`databaseActions` IDatabaseActions<br>
The database actions interface.

## Methods

### **GetCommentById(Guid)**

```csharp
public Task<CommentDao> GetCommentById(Guid postId)
```

#### Parameters

`postId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

#### Returns

[Task&lt;CommentDao&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
