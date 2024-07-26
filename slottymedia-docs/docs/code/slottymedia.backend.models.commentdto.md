# CommentDto

Namespace: SlottyMedia.Backend.Models

This class represents the Comment table in the database.

```csharp
public class CommentDto
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [CommentDto](./slottymedia.backend.models.commentdto.md)

## Properties

### **CommentId**

```csharp
public int CommentId { get; set; }
```

#### Property Value

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

### **ParentCommentId**

```csharp
public string ParentCommentId { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **CreatorUserId**

```csharp
public string CreatorUserId { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **PostId**

```csharp
public string PostId { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Content**

```csharp
public string Content { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **CreatedAt**

```csharp
public DateTime CreatedAt { get; set; }
```

#### Property Value

[DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime)<br>

## Constructors

### **CommentDto()**

```csharp
public CommentDto()
```
