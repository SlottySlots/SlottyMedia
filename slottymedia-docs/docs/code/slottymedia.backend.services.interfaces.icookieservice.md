# ICookieService

Namespace: SlottyMedia.Backend.Services.Interfaces

Provides a contract for setting cookies on the clients server

```csharp
public interface ICookieService
```

## Methods

### **SetCookie(String, String, Int32)**

Should set a cookie on the clients browser

```csharp
ValueTask SetCookie(string name, string value, int days)
```

#### Parameters

`name` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Name of the cookies

`value` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Value of the cookie

`days` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
Expiration offset in days

#### Returns

[ValueTask](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask)<br>
Returns a valuetask

### **GetCookie(String)**

Gets a cookie

```csharp
ValueTask<string> GetCookie(string name)
```

#### Parameters

`name` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Name to identify cookie

#### Returns

[ValueTask&lt;String&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask-1)<br>
Returns a ValueTask of type string

### **RemoveCookie(String)**

Removes a cookie on the client side by setting its duration below zero

```csharp
ValueTask<string> RemoveCookie(string name)
```

#### Parameters

`name` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Name to identify cookie

#### Returns

[ValueTask&lt;String&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask-1)<br>
Returns the cookie which was deleted
