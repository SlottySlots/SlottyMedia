# InputField&lt;TValue&gt;

Namespace: SlottyMedia.Components.Partial

```csharp
public class InputField<TValue> : Microsoft.AspNetCore.Components.ComponentBase, Microsoft.AspNetCore.Components.IComponent, Microsoft.AspNetCore.Components.IHandleEvent, Microsoft.AspNetCore.Components.IHandleAfterRender
```

#### Type Parameters

`TValue`<br>

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → ComponentBase → [InputField&lt;TValue&gt;](./slottymedia.components.partial.inputfield-1.md)<br>
Implements IComponent, IHandleEvent, IHandleAfterRender

## Properties

### **ChildContent**

```csharp
public RenderFragment ChildContent { get; set; }
```

#### Property Value

RenderFragment<br>

### **Id**

```csharp
public string Id { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Name**

```csharp
public string Name { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Placeholder**

```csharp
public string Placeholder { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Type**

```csharp
public string Type { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Value**

```csharp
public TValue Value { get; set; }
```

#### Property Value

TValue<br>

### **ValueChanged**

```csharp
public EventCallback<TValue> ValueChanged { get; set; }
```

#### Property Value

EventCallback&lt;TValue&gt;<br>

## Constructors

### **InputField()**

```csharp
public InputField()
```

## Methods

### **BuildRenderTree(RenderTreeBuilder)**

```csharp
protected void BuildRenderTree(RenderTreeBuilder __builder)
```

#### Parameters

`__builder` RenderTreeBuilder<br>
