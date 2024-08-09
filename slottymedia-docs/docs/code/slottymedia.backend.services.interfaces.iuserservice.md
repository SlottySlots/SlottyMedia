# IUserService

Namespace: SlottyMedia.Backend.Services.Interfaces

This interface defines the methods which can be used to interact with the User table in the database.

```csharp
public interface IUserService
```

## Methods

### **GetUserById(Guid)**

This method returns a User object from the database based on the given userId.

```csharp
Task<UserDto> GetUserById(Guid userId)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The UserID inside the Database

#### Returns

[Task&lt;UserDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
UserDao

### **GetUserByUsername(String)**

Fetches a user by their username. Returns null if no user was found.

```csharp
Task<UserDto> GetUserByUsername(string username)
```

#### Parameters

`username` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The user's username

#### Returns

[Task&lt;UserDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
The queried user or null if no such user was found

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

`user` [UserDto](./slottymedia.backend.dtos.userdto.md)<br>
The User object

#### Returns

[Task&lt;UserDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
UserDao

### **DeleteUser(UserDto)**

This method deletes the given User object from the database.

```csharp
Task<bool> DeleteUser(UserDto user)
```

#### Parameters

`user` [UserDto](./slottymedia.backend.dtos.userdto.md)<br>
The User Object

#### Returns

[Task&lt;Boolean&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
Return if the User got deleted or not

### **GetProfilePic(Guid)**

This method returns the Profile Picture of the given User.

```csharp
Task<ProfilePicDto> GetProfilePic(Guid userId)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The ID of the User

#### Returns

[Task&lt;ProfilePicDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
Returns the Profile Picture of the User

### **GetUser(Guid, Int32)**

This method returns a UserDto object from the database based on the given userId.

```csharp
Task<UserDto> GetUser(Guid userId, int limit)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The Id of the user

`limit` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The maximum number of recent forums to retrieve

#### Returns

[Task&lt;UserDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
Returns the UserDto object

### **GetFriends(Guid)**

This method returns a list of friends for the given user.

```csharp
Task<FriendsOfUserDto> GetFriends(Guid userId)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The ID of the user

#### Returns

[Task&lt;FriendsOfUserDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
Returns a FriendsOfUserDto object containing the list of friends
