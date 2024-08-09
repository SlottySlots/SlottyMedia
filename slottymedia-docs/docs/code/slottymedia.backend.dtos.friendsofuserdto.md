# FriendsOfUserDto

Namespace: SlottyMedia.Backend.Dtos

The Friends of a User

```csharp
public class FriendsOfUserDto
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [FriendsOfUserDto](./slottymedia.backend.dtos.friendsofuserdto.md)

## Properties

### **UserId**

Gets or sets the User Id.

```csharp
public Guid UserId { get; set; }
```

#### Property Value

[Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

### **Friends**

Gets or sets the list of friends of the user.

```csharp
public List<UserDto> Friends { get; set; }
```

#### Property Value

[List&lt;UserDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>

## Constructors

### **FriendsOfUserDto()**

Initializes a new instance of the [FriendsOfUserDto](./slottymedia.backend.dtos.friendsofuserdto.md) class.

```csharp
public FriendsOfUserDto()
```
