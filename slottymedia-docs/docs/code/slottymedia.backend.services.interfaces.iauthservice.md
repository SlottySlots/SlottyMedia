# IAuthService

Namespace: SlottyMedia.Backend.Services.Interfaces

This interface is used to abstract the authentication service.

```csharp
public interface IAuthService
```

## Methods

### **SignUp(String, String)**

This method is used to sign up the user.

```csharp
Task<User> SignUp(string email, string password)
```

#### Parameters

`email` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`password` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[Task&lt;User&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **SignIn(String, String)**

This method is used to sign in the user.

```csharp
Task<User> SignIn(string email, string password)
```

#### Parameters

`email` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`password` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[Task&lt;User&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **SignOut()**

This method is used to sign out the user.

```csharp
Task SignOut()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **IsAuthenticated()**

This method is used to check if the user is authenticated.

```csharp
bool IsAuthenticated()
```

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **GetAccessToken()**

```csharp
Task<string> GetAccessToken()
```

#### Returns

[Task&lt;String&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
