# ProfilePicDto

Namespace: SlottyMedia.Backend.Dtos

The Profile Picture Data Transfer Object

```csharp
public class ProfilePicDto
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [ProfilePicDto](./slottymedia.backend.dtos.profilepicdto.md)

## Properties

### **UserId**

Gets or sets the User Id.

```csharp
public Guid UserId { get; set; }
```

#### Property Value

[Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

### **ProfilePic**

Gets or sets the Profile Picture in binary.

```csharp
public long ProfilePic { get; set; }
```

#### Property Value

[Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>

## Constructors

### **ProfilePicDto()**

Initializes a new instance of the [ProfilePicDto](./slottymedia.backend.dtos.profilepicdto.md) class.

```csharp
public ProfilePicDto()
```

## Methods

### **Mapper()**

This method maps the ProfilePicDto to a UserDao.

```csharp
public UserDao Mapper()
```

#### Returns

UserDao<br>

### **Mapper(UserDao)**

This method maps the UserDao to a ProfilePicDto.

```csharp
public ProfilePicDto Mapper(UserDao userDao)
```

#### Parameters

`userDao` UserDao<br>

#### Returns

[ProfilePicDto](./slottymedia.backend.dtos.profilepicdto.md)<br>
