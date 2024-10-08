# Tag

Namespace: SlottyMedia.Components.Partial

```csharp
public class Tag : Microsoft.AspNetCore.Components.ComponentBase, Microsoft.AspNetCore.Components.IComponent, Microsoft.AspNetCore.Components.IHandleEvent, Microsoft.AspNetCore.Components.IHandleAfterRender
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → ComponentBase → [Tag](./slottymedia.components.partial.tag.md)<br>
Implements IComponent, IHandleEvent, IHandleAfterRender

## Properties

### **ChildContent**

This component represents a tag.

```csharp
public RenderFragment ChildContent { get; set; }
```

#### Property Value

RenderFragment<br>

#### Exceptions

[ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/system.argumentexception)<br>
If an illegal color was provided.

### **Color**

The tag's color.
 Should be one of 'savoy-blue', 'grape', 'fandango', 'crayola-orange', 'jasmine'.
 Default is 'fandango'.

```csharp
public string Color { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Class**

Additional CSS classes to apply to the outermost container of this component.

```csharp
public string Class { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **OnClick**

An event that is triggered when this tag is clicked.

```csharp
public EventCallback OnClick { get; set; }
```

#### Property Value

EventCallback<br>

## Constructors

### **Tag()**

```csharp
public Tag()
```

## Methods

### **BuildRenderTree(RenderTreeBuilder)**

```csharp
protected void BuildRenderTree(RenderTreeBuilder __builder)
```

#### Parameters

`__builder` RenderTreeBuilder<br>
