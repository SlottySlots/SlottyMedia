# CounterVm

Namespace: SlottyMedia.Backend.ViewModel

```csharp
public class CounterVm : SlottyMedia.Backend.ViewModel.Interfaces.ICounterVm, System.ComponentModel.INotifyPropertyChanged
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [CounterVm](./slottymedia.backend.viewmodel.countervm.md)<br>
Implements [ICounterVm](./slottymedia.backend.viewmodel.interfaces.icountervm.md), INotifyPropertyChanged

## Properties

### **User**

```csharp
public UserDto User { get; set; }
```

#### Property Value

[UserDto](./slottymedia.backend.models.userdto.md)<br>

## Constructors

### **CounterVm(IUserService)**

```csharp
public CounterVm(IUserService userService)
```

#### Parameters

`userService` [IUserService](./slottymedia.backend.services.interfaces.iuserservice.md)<br>

## Methods

### **OnPropertyChanged(String)**

```csharp
protected void OnPropertyChanged(string propertyName)
```

#### Parameters

`propertyName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **GetUserById(String)**

```csharp
public Task GetUserById(string userId)
```

#### Parameters

`userId` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

## Events

### **PropertyChanged**

```csharp
public event PropertyChangedEventHandler PropertyChanged;
```
