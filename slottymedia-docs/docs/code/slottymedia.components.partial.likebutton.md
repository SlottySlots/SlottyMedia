# LikeButton

Namespace: SlottyMedia.Components.Partial

```csharp
public class LikeButton : Microsoft.AspNetCore.Components.ComponentBase, Microsoft.AspNetCore.Components.IComponent, Microsoft.AspNetCore.Components.IHandleEvent, Microsoft.AspNetCore.Components.IHandleAfterRender
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → ComponentBase → [LikeButton](./slottymedia.components.partial.likebutton.md)<br>
Implements IComponent, IHandleEvent, IHandleAfterRender

## Properties

### **Class**

Additional CSS classes to apply to the outer SVG image.

```csharp
public string Class { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Initial**

The button's initial value. If true, this button is "turned on".

```csharp
public Nullable<bool> Initial { get; set; }
```

#### Property Value

[Nullable&lt;Boolean&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>

### **OnClick**

An event that is triggered when this button is clicked. The callback's parameter
 is a boolean that represents the button's new state.

```csharp
public Nullable<EventCallback<bool>> OnClick { get; set; }
```

#### Property Value

[Nullable&lt;EventCallback&lt;Boolean&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>

## Constructors

### **LikeButton()**

```csharp
public LikeButton()
```

## Methods

### **BuildRenderTree(RenderTreeBuilder)**

```csharp
protected void BuildRenderTree(RenderTreeBuilder __builder)
```

#### Parameters

`__builder` RenderTreeBuilder<br>

### **OnInitialized()**

```csharp
protected void OnInitialized()
```
