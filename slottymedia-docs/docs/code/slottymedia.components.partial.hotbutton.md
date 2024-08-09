# HotButton

Namespace: SlottyMedia.Components.Partial

```csharp
public class HotButton : Microsoft.AspNetCore.Components.ComponentBase, Microsoft.AspNetCore.Components.IComponent, Microsoft.AspNetCore.Components.IHandleEvent, Microsoft.AspNetCore.Components.IHandleAfterRender
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → ComponentBase → [HotButton](./slottymedia.components.partial.hotbutton.md)<br>
Implements IComponent, IHandleEvent, IHandleAfterRender

## Properties

### **Class**

Additional CSS classes to add to this button.

```csharp
public string Class { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Type**

This button's type (see HTML5 specifications).

```csharp
public string Type { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **ChildContent**

This button's child content, ideally just a string.

```csharp
public RenderFragment ChildContent { get; set; }
```

#### Property Value

RenderFragment<br>

### **OnClick**

An event that is triggered when this button is clicked.

```csharp
public Nullable<EventCallback> OnClick { get; set; }
```

#### Property Value

[Nullable&lt;EventCallback&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>

## Constructors

### **HotButton()**

```csharp
public HotButton()
```

## Methods

### **BuildRenderTree(RenderTreeBuilder)**

```csharp
protected void BuildRenderTree(RenderTreeBuilder __builder)
```

#### Parameters

`__builder` RenderTreeBuilder<br>
