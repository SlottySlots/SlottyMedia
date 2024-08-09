# SignupServiceImpl

Namespace: SlottyMedia.Backend.Services

```csharp
public class SignupServiceImpl : SlottyMedia.Backend.Services.Interfaces.ISignupService
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [SignupServiceImpl](./slottymedia.backend.services.signupserviceimpl.md)<br>
Implements [ISignupService](./slottymedia.backend.services.interfaces.isignupservice.md)

## Constructors

### **SignupServiceImpl(Client, IUserService, ICookieService)**

```csharp
public SignupServiceImpl(Client supabaseClient, IUserService userService, ICookieService cookieService)
```

#### Parameters

`supabaseClient` Client<br>

`userService` [IUserService](./slottymedia.backend.services.interfaces.iuserservice.md)<br>

`cookieService` [ICookieService](./slottymedia.backend.services.interfaces.icookieservice.md)<br>

## Methods

### **SignUp(String, String, String)**

```csharp
public Task<Session> SignUp(string username, string email, string password)
```

#### Parameters

`username` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`email` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`password` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[Task&lt;Session&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
