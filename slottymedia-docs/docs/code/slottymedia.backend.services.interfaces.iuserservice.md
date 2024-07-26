# IUserService

Namespace: SlottyMedia.Backend.Services.Interfaces

This interface defines the methods which can be used to interact with the User table in the database.

```csharp
public interface IUserService
```

## Methods

### **GetUserById(String)**

This method returns a User object from the database based on the given userId.

```csharp
Task<UserDto> GetUserById(string userId)
```

#### Parameters

`userId` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The UserID inside the Database

#### Returns

[Task&lt;UserDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
UserDto

### **CreateUser(String, String, String, Nullable&lt;Int64&gt;)**

This method creates a new User object in the database and returns the created object.

```csharp
Task<UserDto> CreateUser(string userId, string username, string description, Nullable<long> profilePicture)
```

#### Parameters

`userId` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The UserID from the Authentication Service

`username` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The Username, which the User set himself

`description` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The Description about the User

`profilePicture` [Nullable&lt;Int64&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The ProfilePicture

#### Returns

[Task&lt;UserDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
UserDto

### **UpdateUser(UserDto)**

This method updates the given User object in the database and returns the updated object.

```csharp
Task<UserDto> UpdateUser(UserDto user)
```

#### Parameters

`user` [UserDto](./slottymedia.backend.models.userdto.md)<br>
The User object

#### Returns

[Task&lt;UserDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
UserDto

### **DeleteUser(UserDto)**

This method deletes the given User object from the database.

```csharp
Task<bool> DeleteUser(UserDto user)
```

#### Parameters

`user` [UserDto](./slottymedia.backend.models.userdto.md)<br>
The User Object

#### Returns

[Task&lt;Boolean&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
Return if the User got deleted or not
