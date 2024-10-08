# AuthVmImpl

Namespace: SlottyMedia.Backend.ViewModel

This class implements the IAuthVmImpl interface

```csharp
public class AuthVmImpl : SlottyMedia.Backend.ViewModel.Interfaces.IAuthVm
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [AuthVmImpl](./slottymedia.backend.viewmodel.authvmimpl.md)<br>
Implements [IAuthVm](./slottymedia.backend.viewmodel.interfaces.iauthvm.md)

## Constructors

### **AuthVmImpl(IAuthService)**

This constructor initializes the AuthService

```csharp
public AuthVmImpl(IAuthService authVmImpl)
```

#### Parameters

`authVmImpl` [IAuthService](./slottymedia.backend.services.interfaces.iauthservice.md)<br>

## Methods

### **GetCurrentSession()**

```csharp
public Session GetCurrentSession()
```

#### Returns

Session<br>
