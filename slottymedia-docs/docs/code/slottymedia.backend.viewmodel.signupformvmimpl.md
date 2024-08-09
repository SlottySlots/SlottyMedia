# SignupFormVmImpl

Namespace: SlottyMedia.Backend.ViewModel

```csharp
public class SignupFormVmImpl : SlottyMedia.Backend.ViewModel.Interfaces.ISignupFormVm
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [SignupFormVmImpl](./slottymedia.backend.viewmodel.signupformvmimpl.md)<br>
Implements [ISignupFormVm](./slottymedia.backend.viewmodel.interfaces.isignupformvm.md)

## Properties

### **Username**

```csharp
public string Username { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **UsernameErrorMessage**

```csharp
public string UsernameErrorMessage { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Email**

```csharp
public string Email { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **EmailErrorMessage**

```csharp
public string EmailErrorMessage { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Password**

```csharp
public string Password { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **PasswordErrorMessage**

```csharp
public string PasswordErrorMessage { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **ServerErrorMessage**

```csharp
public string ServerErrorMessage { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

## Constructors

### **SignupFormVmImpl(ISignupService)**

```csharp
public SignupFormVmImpl(ISignupService signupService)
```

#### Parameters

`signupService` [ISignupService](./slottymedia.backend.services.interfaces.isignupservice.md)<br>

## Methods

### **SubmitSignupForm()**

```csharp
public Task SubmitSignupForm()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
