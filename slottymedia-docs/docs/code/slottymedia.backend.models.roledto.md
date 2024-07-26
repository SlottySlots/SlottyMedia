# RoleDto

Namespace: SlottyMedia.Backend.Models

This class represents the Role table in the database.

```csharp
public class RoleDto : Supabase.Postgrest.Models.BaseModel
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → BaseModel → [RoleDto](./slottymedia.backend.models.roledto.md)

## Properties

### **RoleId**

```csharp
public string RoleId { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **RoleName**

```csharp
public string RoleName { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Description**

```csharp
public string Description { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **CreatedAt**

```csharp
public DateTime CreatedAt { get; set; }
```

#### Property Value

[DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime)<br>

### **BaseUrl**

```csharp
public string BaseUrl { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **RequestClientOptions**

```csharp
public ClientOptions RequestClientOptions { get; set; }
```

#### Property Value

ClientOptions<br>

### **TableName**

```csharp
public string TableName { get; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **PrimaryKey**

```csharp
public Dictionary<PrimaryKeyAttribute, object> PrimaryKey { get; }
```

#### Property Value

[Dictionary&lt;PrimaryKeyAttribute, Object&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2)<br>

## Constructors

### **RoleDto()**

```csharp
public RoleDto()
```
