# SearchDto

Namespace: SlottyMedia.Backend.Dtos

The Search Data Transfer Object

```csharp
public class SearchDto
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [SearchDto](./slottymedia.backend.dtos.searchdto.md)

## Properties

### **Users**

Gets or sets the users who match the search.

```csharp
public List<UserDto> Users { get; set; }
```

#### Property Value

[List&lt;UserDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>

### **Forums**

Gets or sets the forum that matches the search.

```csharp
public List<ForumDto> Forums { get; set; }
```

#### Property Value

[List&lt;ForumDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>

## Constructors

### **SearchDto()**

Initializes a new instance of the [SearchDto](./slottymedia.backend.dtos.searchdto.md) class.

```csharp
public SearchDto()
```
