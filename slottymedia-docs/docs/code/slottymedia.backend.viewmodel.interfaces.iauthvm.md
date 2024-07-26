# IAuthVm

Namespace: SlottyMedia.Backend.ViewModel.Interfaces

```csharp
public interface IAuthVm
```

## Methods

### **SignUp(String, String)**

```csharp
Task<User> SignUp(string username, string password)
```

#### Parameters

`username` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`password` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[Task&lt;User&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **SignIn(String, String)**

```csharp
Task<User> SignIn(string username, string password)
```

#### Parameters

`username` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`password` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[Task&lt;User&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **SignOut()**

```csharp
Task<bool> SignOut()
```

#### Returns

[Task&lt;Boolean&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **GetAccessTokenAfterSignIn(String, String)**

```csharp
Task<string> GetAccessTokenAfterSignIn(string username, string password)
```

#### Parameters

`username` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`password` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[Task&lt;String&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
