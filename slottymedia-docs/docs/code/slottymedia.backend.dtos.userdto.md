# UserDto

Namespace: SlottyMedia.Backend.Dtos

The User Data Transfer Object

```csharp
public class UserDto
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [UserDto](./slottymedia.backend.dtos.userdto.md)

## Properties

### **UserId**

Gets or sets the User Id.

```csharp
public Guid UserId { get; set; }
```

#### Property Value

[Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

### **Username**

Gets or sets the Username.

```csharp
public string Username { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Description**

Gets or sets the Description of the User.

```csharp
public string Description { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **CreatedAt**

Gets or sets the date and time when the User was created.

```csharp
public DateTime CreatedAt { get; set; }
```

#### Property Value

[DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime)<br>

### **RecentForums**

Gets or sets a list of the recent forums the User has visited.

```csharp
public List<string> RecentForums { get; set; }
```

#### Property Value

[List&lt;String&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>

## Constructors

### **UserDto()**

Initializes a new instance of the [UserDto](./slottymedia.backend.dtos.userdto.md) class.

```csharp
public UserDto()
```

## Methods

### **Mapper()**

This method maps the User Dto to the User Dao.

```csharp
public UserDao Mapper()
```

#### Returns

UserDao<br>

### **Mapper(UserDao)**

Maps the User Dao to the User Dto.

```csharp
public UserDto Mapper(UserDao user)
```

#### Parameters

`user` UserDao<br>

#### Returns

[UserDto](./slottymedia.backend.dtos.userdto.md)<br>
