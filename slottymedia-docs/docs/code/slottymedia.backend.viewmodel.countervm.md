# CounterVm

Namespace: SlottyMedia.Backend.ViewModel

This class represents the Counter ViewModel.

```csharp
public class CounterVm : SlottyMedia.Backend.ViewModel.Interfaces.ICounterVm, System.ComponentModel.INotifyPropertyChanged
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [CounterVm](./slottymedia.backend.viewmodel.countervm.md)<br>
Implements [ICounterVm](./slottymedia.backend.viewmodel.interfaces.icountervm.md), INotifyPropertyChanged

## Properties

### **User**

Gets or sets the User object. This object can be accessed by the View. When the User object changes, the View will
 be notified.

```csharp
public UserDto User { get; set; }
```

#### Property Value

[UserDto](./slottymedia.backend.dtos.userdto.md)<br>

## Constructors

### **CounterVm(IUserService, UserDto)**

Initializes a new instance of the [CounterVm](./slottymedia.backend.viewmodel.countervm.md) class. It creates a new UserDao object and sets the
 UserService.

```csharp
public CounterVm(IUserService userService, UserDto user)
```

#### Parameters

`userService` [IUserService](./slottymedia.backend.services.interfaces.iuserservice.md)<br>
The user service to interact with the database.

`user` [UserDto](./slottymedia.backend.dtos.userdto.md)<br>
A new UserDao object

## Methods

### **GetUserById(String)**

Gets a user by their ID.

```csharp
public Task GetUserById(string userId)
```

#### Parameters

`userId` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The ID of the user to retrieve.

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **OnPropertyChanged(String)**

This method is called when a property value changes, to notify the View.

```csharp
protected void OnPropertyChanged(string propertyName)
```

#### Parameters

`propertyName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The name of the property

## Events

### **PropertyChanged**

Event that is triggered when a property value changes.

```csharp
public event PropertyChangedEventHandler PropertyChanged;
```
