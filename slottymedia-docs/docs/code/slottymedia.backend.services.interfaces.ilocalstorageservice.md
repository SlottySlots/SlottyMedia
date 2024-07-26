# ILocalStorageService

Namespace: SlottyMedia.Backend.Services.Interfaces

This interface is used to abstract the Blazored.LocalStorage.

```csharp
public interface ILocalStorageService
```

## Methods

### **GetItem(String)**

This method is used to get an item from the local storage.

```csharp
Task<string> GetItem(string key)
```

#### Parameters

`key` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[Task&lt;String&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **SetItem(String, String)**

THis method is used to save an item in the local storage.

```csharp
Task SetItem(string key, string value)
```

#### Parameters

`key` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`value` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **RemoveItem(String)**

This method is used to remove an item from the local storage.

```csharp
Task RemoveItem(string key)
```

#### Parameters

`key` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **Clear()**

This method is used to clear the local storage.

```csharp
Task Clear()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
