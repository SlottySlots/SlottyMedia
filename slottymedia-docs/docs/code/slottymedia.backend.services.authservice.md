# AuthService

Namespace: SlottyMedia.Backend.Services

This service is used to authenticate users

```csharp
public class AuthService : SlottyMedia.Backend.Services.Interfaces.IAuthService
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [AuthService](./slottymedia.backend.services.authservice.md)<br>
Implements [IAuthService](./slottymedia.backend.services.interfaces.iauthservice.md)

## Constructors

### **AuthService(Client, ICookieService)**

Initialize scoped service by ctor injection

```csharp
public AuthService(Client supabaseClient, ICookieService cookieService)
```

#### Parameters

`supabaseClient` Client<br>
Injected supabaseClient

`cookieService` [ICookieService](./slottymedia.backend.services.interfaces.icookieservice.md)<br>
Injected cookieService

## Methods

### **SignUp(String, String)**

This method is used to sign up the user. And save the session by using SaveSessionAsync. This will set cookies.

```csharp
public Task<Session> SignUp(string email, string password)
```

#### Parameters

`email` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Email of the user

`password` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Password of the user

#### Returns

[Task&lt;Session&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **SignIn(String, String)**

This method is used to sign in the user. And save the session by using SaveSessionAsync. This will set cookies.

```csharp
public Task<Session> SignIn(string email, string password)
```

#### Parameters

`email` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Email of the user

`password` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Password of the user

#### Returns

[Task&lt;Session&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **SaveSessionAsync(Session)**

Used to save cookies of a specific session

```csharp
public Task SaveSessionAsync(Session session)
```

#### Parameters

`session` Session<br>
Provides the session information, f.e. accessToken / refreshToken

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **RestoreSessionAsync()**

Restores a session by cookies, if they exist

```csharp
public Task<Session> RestoreSessionAsync()
```

#### Returns

[Task&lt;Session&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A session (might be the same as previously called, but can change if accessToken cookie is expired)

### **SetSession(String, String)**

Sets a session on the server-side via supabase client

```csharp
public Task<Session> SetSession(string accessToken, string refreshToken)
```

#### Parameters

`accessToken` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Provided AccessToken

`refreshToken` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Provided RefreshToken

#### Returns

[Task&lt;Session&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
Returns the Session set, by AccessToken and RefreshToken

### **SignOut()**

This method is used to sign out the user. It also removes cookies

```csharp
public Task SignOut()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **RefreshSession(String, String)**

Sets a session but forces to refresh a new accessToken, and thus a new session

```csharp
public Task<Session> RefreshSession(string accessToken, string refreshToken)
```

#### Parameters

`accessToken` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Provided AccessToken

`refreshToken` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Provided RefreshToken

#### Returns

[Task&lt;Session&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
Returns the session

### **IsAuthenticated()**

This method is used to check if the user is authenticated.

```csharp
public bool IsAuthenticated()
```

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **GetCurrentSession()**

Gets current user set on server side

```csharp
public Session GetCurrentSession()
```

#### Returns

Session<br>
Returns the session set on server side
