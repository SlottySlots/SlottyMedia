# UserService

Namespace: SlottyMedia.Backend.Services

This class is the User Service. It is responsible for handling all User related operations.

```csharp
public class UserService : SlottyMedia.Backend.Services.Interfaces.IUserService
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [UserService](./slottymedia.backend.services.userservice.md)<br>
Implements [IUserService](./slottymedia.backend.services.interfaces.iuserservice.md)

## Constructors

### **UserService(IDatabaseActions, IPostService)**

This constructor creates a new UserService object.

```csharp
public UserService(IDatabaseActions databaseActions, IPostService postService)
```

#### Parameters

`databaseActions` IDatabaseActions<br>
This parameter is used to interact with the database

`postService` [IPostService](./slottymedia.backend.services.interfaces.ipostservice.md)<br>
This parameter is used to interact with the post service

## Methods

### **CreateUser(String, String, String, Nullable&lt;Int64&gt;)**

This method creates a new User object in the database and returns the created object.

```csharp
public Task<UserDto> CreateUser(string userId, string username, string description, Nullable<long> profilePicture)
```

#### Parameters

`userId` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The ID we get from the Supabase Authentication Service

`username` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The Username of the User

`description` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The Description of the User

`profilePicture` [Nullable&lt;Int64&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The Profile Picture of the User

#### Returns

[Task&lt;UserDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
Returns the Created UserDao. If it was unable to create a User, it will return null

### **DeleteUser(UserDto)**

This method deletes the given User object from the database.

```csharp
public Task<bool> DeleteUser(UserDto user)
```

#### Parameters

`user` [UserDto](./slottymedia.backend.dtos.userdto.md)<br>
The User Object to delete

#### Returns

[Task&lt;Boolean&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
Returns whether it was possible to Delete the User or not. If it was possible it will return true.

### **GetUserById(Guid)**

This method returns a User object from the database based on the given userId.

```csharp
public Task<UserDto> GetUserById(Guid userId)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The ID of the User to get from the Database

#### Returns

[Task&lt;UserDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
Returns the User Object from the Database. If no User was found, null will be returned

### **GetUserByUsername(String)**

This method fetches a user by their username. Returns null if no user was found.

```csharp
public Task<UserDto> GetUserByUsername(string username)
```

#### Parameters

`username` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[Task&lt;UserDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **UpdateUser(UserDto)**

This method updates the given User object in the database and returns the updated object.

```csharp
public Task<UserDto> UpdateUser(UserDto user)
```

#### Parameters

`user` [UserDto](./slottymedia.backend.dtos.userdto.md)<br>
The updated User Dto

#### Returns

[Task&lt;UserDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
Returns the Updated User Interface. If it was unable to Update the User, it will return null.

### **GetProfilePic(Guid)**

This method returns the Profile Picture of the given User.

```csharp
public Task<ProfilePicDto> GetProfilePic(Guid userId)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The ID of the User

#### Returns

[Task&lt;ProfilePicDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
Returns the Profile Picture of the User

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>
Throws an exception if the user is not found

### **GetUser(Guid, Int32)**

This method returns a UserDto object from the database based on the given userId.

```csharp
public Task<UserDto> GetUser(Guid userId, int recentForums)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The Id of the user

`recentForums` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The maximum number of recent forums to retrieve

#### Returns

[Task&lt;UserDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
Returns the UserDto object

### **GetFriends(Guid)**

This method returns a list of friends for the given user.

```csharp
public Task<FriendsOfUserDto> GetFriends(Guid userId)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The ID of the user

#### Returns

[Task&lt;FriendsOfUserDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
Returns a FriendsOfUserDto object containing the list of friends
