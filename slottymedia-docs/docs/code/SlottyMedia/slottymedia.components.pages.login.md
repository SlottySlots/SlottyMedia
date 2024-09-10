# Login

Namespace: SlottyMedia.Components.Pages

```csharp
public class Login : Microsoft.AspNetCore.Components.ComponentBase, Microsoft.AspNetCore.Components.IComponent, Microsoft.AspNetCore.Components.IHandleEvent, Microsoft.AspNetCore.Components.IHandleAfterRender
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → ComponentBase → [Login](./slottymedia.components.pages.login.md)<br>
Implements IComponent, IHandleEvent, IHandleAfterRender

## Properties

### **ViewModel**

The ViewModel for the login page

```csharp
public ISignInFormVm ViewModel { get; set; }
```

#### Property Value

[ISignInFormVm](./slottymedia.backend.viewmodel.partial.signin.isigninformvm.md)<br>

## Constructors

### **Login()**

```csharp
public Login()
```

## Methods

### **BuildRenderTree(RenderTreeBuilder)**

```csharp
protected void BuildRenderTree(RenderTreeBuilder __builder)
```

#### Parameters

`__builder` RenderTreeBuilder<br>
