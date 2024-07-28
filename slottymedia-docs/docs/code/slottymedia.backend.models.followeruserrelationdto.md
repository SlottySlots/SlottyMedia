# FollowerUserRelationDto

Namespace: SlottyMedia.Backend.Models

This class represents the Follower_User_Relation table in the database.

```csharp
public class FollowerUserRelationDto : Supabase.Postgrest.Models.BaseModel
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → BaseModel → [FollowerUserRelationDto](./slottymedia.backend.models.followeruserrelationdto.md)

## Properties

### **FollowerUserRelationId**

The ID of the Follower_User_Relation. This is the Primary Key. It is auto-generated.

```csharp
public int FollowerUserRelationId { get; set; }
```

#### Property Value

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

### **FollowerUserId**

The ID of the User who is following another User. This is a Foreign Key to the User Table.

```csharp
public string FollowerUserId { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **FollowedUserId**

The ID of the User who is being followed. This is a Foreign Key to the User Table.

```csharp
public string FollowedUserId { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **CreatedAt**

The Date and Time the Follower_User_Relation was created.

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

### **FollowerUserRelationDto()**

```csharp
public FollowerUserRelationDto()
```
