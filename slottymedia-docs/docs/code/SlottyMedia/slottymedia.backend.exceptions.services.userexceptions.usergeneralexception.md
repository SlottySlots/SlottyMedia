# UserGeneralException

Namespace: SlottyMedia.Backend.Exceptions.Services.UserExceptions

This exception is thrown when a general exception occurs. For example when interacting with the database there
 is the option, that Exceptions which aren't predictable can occur. In this case, this exception is thrown.

```csharp
public class UserGeneralException : SlottyMedia.LoggingProvider.BaseException`1[[SlottyMedia.Backend.Exceptions.Services.UserExceptions.UserGeneralException, SlottyMedia, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]], System.Runtime.Serialization.ISerializable
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception) → BaseException&lt;UserGeneralException&gt; → [UserGeneralException](./slottymedia.backend.exceptions.services.userexceptions.usergeneralexception.md)<br>
Implements [ISerializable](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.serialization.iserializable)

## Properties

### **TargetSite**

```csharp
public MethodBase TargetSite { get; }
```

#### Property Value

[MethodBase](https://docs.microsoft.com/en-us/dotnet/api/system.reflection.methodbase)<br>

### **Message**

```csharp
public string Message { get; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Data**

```csharp
public IDictionary Data { get; }
```

#### Property Value

[IDictionary](https://docs.microsoft.com/en-us/dotnet/api/system.collections.idictionary)<br>

### **InnerException**

```csharp
public Exception InnerException { get; }
```

#### Property Value

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **HelpLink**

```csharp
public string HelpLink { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Source**

```csharp
public string Source { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **HResult**

```csharp
public int HResult { get; set; }
```

#### Property Value

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

### **StackTrace**

```csharp
public string StackTrace { get; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

## Constructors

### **UserGeneralException(String)**

This constructor creates a new UserGeneralException object.

```csharp
public UserGeneralException(string message)
```

#### Parameters

`message` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **UserGeneralException(String, Exception)**

This constructor creates a new UserGeneralException object.

```csharp
public UserGeneralException(string message, Exception innerException)
```

#### Parameters

`message` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`innerException` [Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>
