# PostDto

Namespace: SlottyMedia.Backend.Dtos

The Post Data Transfer Object

```csharp
public class PostDto
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [PostDto](./slottymedia.backend.dtos.postdto.md)

## Properties

### **Forum**

Gets or sets the forum associated with the post.

```csharp
public ForumDto Forum { get; set; }
```

#### Property Value

[ForumDto](./slottymedia.backend.dtos.forumdto.md)<br>

### **PostId**

Gets or sets the post ID.

```csharp
public Guid PostId { get; set; }
```

#### Property Value

[Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

### **UserId**

Gets or sets the user ID of the user who created the post.

```csharp
public Guid UserId { get; set; }
```

#### Property Value

[Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

### **Likes**

Gets or sets the list of user IDs who liked the post.

```csharp
public List<Guid> Likes { get; set; }
```

#### Property Value

[List&lt;Guid&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>

### **CreatedAt**

Gets or sets the creation date of the post.

```csharp
public DateTime CreatedAt { get; set; }
```

#### Property Value

[DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime)<br>

### **Headline**

Gets or sets the headline of the post.

```csharp
public string Headline { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Content**

Gets or sets the content of the post.

```csharp
public string Content { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Comments**

Gets or sets the comments on the post.

```csharp
public List<CommentDao> Comments { get; set; }
```

#### Property Value

[List&lt;CommentDao&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>

## Constructors

### **PostDto()**

Initializes a new instance of the [PostDto](./slottymedia.backend.dtos.postdto.md) class.

```csharp
public PostDto()
```

## Methods

### **Mapper()**

The Mapper for the Post Dto to the Post Dao.

```csharp
public PostsDao Mapper()
```

#### Returns

PostsDao<br>

### **Mapper(PostsDao)**

Maps the Post Dao to the Post Dto.

```csharp
public PostDto Mapper(PostsDao post)
```

#### Parameters

`post` PostsDao<br>

#### Returns

[PostDto](./slottymedia.backend.dtos.postdto.md)<br>
