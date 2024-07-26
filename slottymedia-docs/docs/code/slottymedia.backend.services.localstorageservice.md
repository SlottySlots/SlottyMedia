# LocalStorageService

Namespace: SlottyMedia.Backend.Services

```csharp
public class LocalStorageService : SlottyMedia.Backend.Services.Interfaces.ILocalStorageService
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [LocalStorageService](./slottymedia.backend.services.localstorageservice.md)<br>
Implements [ILocalStorageService](./slottymedia.backend.services.interfaces.ilocalstorageservice.md)

## Constructors

### **LocalStorageService(ILocalStorageService)**

```csharp
public LocalStorageService(ILocalStorageService storageService)
```

#### Parameters

`storageService` ILocalStorageService<br>

## Methods

### **GetItem(String)**

```csharp
public Task<string> GetItem(string key)
```

#### Parameters

`key` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[Task&lt;String&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **SetItem(String, String)**

```csharp
public Task SetItem(string key, string value)
```

#### Parameters

`key` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`value` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **RemoveItem(String)**

```csharp
public Task RemoveItem(string key)
```

#### Parameters

`key` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **Clear()**

```csharp
public Task Clear()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
