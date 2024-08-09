# ForumDto

Namespace: SlottyMedia.Backend.Dtos

The Forum Data Transfer Object

```csharp
public class ForumDto
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [ForumDto](./slottymedia.backend.dtos.forumdto.md)

## Properties

### **ForumId**

The Forum Id.

```csharp
public Guid ForumId { get; set; }
```

#### Property Value

[Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

### **Topic**

The Topic of the Forum.v

```csharp
public string Topic { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

## Constructors

### **ForumDto()**

The default constructor.

```csharp
public ForumDto()
```

## Methods

### **Mapper()**

This method maps the ForumDto to a ForumDao.

```csharp
public ForumDao Mapper()
```

#### Returns

ForumDao<br>

### **Mapper(ForumDao)**

THis method maps the ForumDao to a ForumDto.

```csharp
public ForumDto Mapper(ForumDao forumDao)
```

#### Parameters

`forumDao` ForumDao<br>

#### Returns

[ForumDto](./slottymedia.backend.dtos.forumdto.md)<br>
