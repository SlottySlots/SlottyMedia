# AuthService

Namespace: SlottyMedia.Backend.Services

This class is used to implement the IAuthService.

```csharp
public class AuthService : SlottyMedia.Backend.Services.Interfaces.IAuthService
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [AuthService](./slottymedia.backend.services.authservice.md)<br>
Implements [IAuthService](./slottymedia.backend.services.interfaces.iauthservice.md)

## Constructors

### **AuthService(Client)**

This class is used to implement the IAuthService.

```csharp
public AuthService(Client supabaseClient)
```

#### Parameters

`supabaseClient` Client<br>

## Methods

### **GetAccessToken()**

This property is used to store the Supabase client.

```csharp
public Task<string> GetAccessToken()
```

#### Returns

[Task&lt;String&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **SignUp(String, String)**

This method is used to sign up the user.

```csharp
public Task<User> SignUp(string email, string password)
```

#### Parameters

`email` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`password` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[Task&lt;User&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **SignIn(String, String)**

This method is used to sign in the user.

```csharp
public Task<User> SignIn(string email, string password)
```

#### Parameters

`email` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`password` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[Task&lt;User&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **SignOut()**

This method is used to sign out the user.

```csharp
public Task SignOut()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **IsAuthenticated()**

This method is used to check if the user is authenticated.

```csharp
public bool IsAuthenticated()
```

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
