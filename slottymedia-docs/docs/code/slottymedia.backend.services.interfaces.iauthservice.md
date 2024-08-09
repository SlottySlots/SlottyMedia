# IAuthService

Namespace: SlottyMedia.Backend.Services.Interfaces

Interface providing a contract to authenticate a user via supabase

```csharp
public interface IAuthService
```

## Methods

### **SignUp(String, String)**

#### Caution

This method is deprecated, use ISignupService instead.

---

This method is used to sign up the user.

```csharp
Task<Session> SignUp(string email, string password)
```

#### Parameters

`email` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`password` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[Task&lt;Session&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **SignIn(String, String)**

This method is used to sign in the user.

```csharp
Task<Session> SignIn(string email, string password)
```

#### Parameters

`email` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`password` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[Task&lt;Session&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **SignOut()**

This method is used to sign out the user.

```csharp
Task SignOut()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **RestoreSessionAsync()**

Should restore a session by reading in accessToken, refreshToken Cookie

```csharp
Task<Session> RestoreSessionAsync()
```

#### Returns

[Task&lt;Session&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
Returns a supabase session

### **SaveSessionAsync(Session)**

Saves the accessToken, refreshToken in form of a cookie in the clients browser

```csharp
Task SaveSessionAsync(Session session)
```

#### Parameters

`session` Session<br>
Session on which the tokens are extracted

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
Returns the sessions again

### **IsAuthenticated()**

Checks if a session exists

```csharp
bool IsAuthenticated()
```

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **SetSession(String, String)**

Sets a session in form of a cookie on the client side by using wwwroot/js/cookies.js

```csharp
Task<Session> SetSession(string accessToken, string refreshToken)
```

#### Parameters

`accessToken` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
AccessToken about to be set as cookie

`refreshToken` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
RefreshToken about to be set as cookie

#### Returns

[Task&lt;Session&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
Returns the session which was set

### **RefreshSession(String, String)**

Restores a session on server- and client-side and refreshes a accessToken if necessary

```csharp
Task<Session> RefreshSession(string accessToken, string refreshToken)
```

#### Parameters

`accessToken` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
AccessToken for restoration

`refreshToken` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
RefreshToken for restoration

#### Returns

[Task&lt;Session&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
Returns the new session

### **GetCurrentSession()**

Gets the current session set by the client

```csharp
Session GetCurrentSession()
```

#### Returns

Session<br>
Returns the session
