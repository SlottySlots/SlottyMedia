# AuthVm

Namespace: SlottyMedia.Backend.ViewModel

This class is used to implement the IAuthVm.

```csharp
public class AuthVm : SlottyMedia.Backend.ViewModel.Interfaces.IAuthVm
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [AuthVm](./slottymedia.backend.viewmodel.authvm.md)<br>
Implements [IAuthVm](./slottymedia.backend.viewmodel.interfaces.iauthvm.md)

## Properties

### **Username**

This property is used to store the username.

```csharp
public string Username { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Password**

This property is used to store the password.

```csharp
public string Password { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

## Constructors

### **AuthVm(IAuthService)**

This constructor is used to inject the IAuthService.

```csharp
public AuthVm(IAuthService authService)
```

#### Parameters

`authService` [IAuthService](./slottymedia.backend.services.interfaces.iauthservice.md)<br>

## Methods

### **SignIn(String, String)**

This method is used to sign in the user.

```csharp
public Task<User> SignIn(string username, string password)
```

#### Parameters

`username` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`password` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[Task&lt;User&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **SignUp(String, String)**

This method is used to sign up the user.

```csharp
public Task<User> SignUp(string username, string password)
```

#### Parameters

`username` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`password` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[Task&lt;User&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **SignOut()**

This method is used to sign out the user.

```csharp
public Task<bool> SignOut()
```

#### Returns

[Task&lt;Boolean&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **GetAccessTokenAfterSignIn(String, String)**

This method is used to get the access token after sign in.

```csharp
public Task<string> GetAccessTokenAfterSignIn(string username, string password)
```

#### Parameters

`username` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`password` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[Task&lt;String&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
