# UserService

Namespace: SlottyMedia.Backend.Services

```csharp
public class UserService : SlottyMedia.Backend.Services.Interfaces.IUserService
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [UserService](./slottymedia.backend.services.userservice.md)<br>
Implements [IUserService](./slottymedia.backend.services.interfaces.iuserservice.md)

## Constructors

### **UserService(Client)**

```csharp
public UserService(Client supabaseClient)
```

#### Parameters

`supabaseClient` Client<br>

## Methods

### **CreateUser(String, String, String, Nullable&lt;Int64&gt;)**

```csharp
public Task<UserDto> CreateUser(string userId, string username, string description, Nullable<long> profilePicture)
```

#### Parameters

`userId` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`username` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`description` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`profilePicture` [Nullable&lt;Int64&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>

#### Returns

[Task&lt;UserDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **DeleteUser(UserDto)**

```csharp
public Task<bool> DeleteUser(UserDto user)
```

#### Parameters

`user` [UserDto](./slottymedia.backend.models.userdto.md)<br>

#### Returns

[Task&lt;Boolean&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **GetUserById(String)**

```csharp
public Task<UserDto> GetUserById(string userId)
```

#### Parameters

`userId` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[Task&lt;UserDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **UpdateUser(UserDto)**

```csharp
public Task<UserDto> UpdateUser(UserDto user)
```

#### Parameters

`user` [UserDto](./slottymedia.backend.models.userdto.md)<br>

#### Returns

[Task&lt;UserDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
