# ICounterVm

Namespace: SlottyMedia.Backend.ViewModel.Interfaces

This interface represents the CounterVm class.

```csharp
public interface ICounterVm
```

## Properties

### **User**

This is the User Object which can be accessed by the View.

```csharp
public abstract UserDto User { get; set; }
```

#### Property Value

[UserDto](./slottymedia.backend.dtos.userdto.md)<br>

## Methods

### **GetUserById(String)**

This Method gets a user by their ID.

```csharp
Task GetUserById(string userId)
```

#### Parameters

`userId` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
