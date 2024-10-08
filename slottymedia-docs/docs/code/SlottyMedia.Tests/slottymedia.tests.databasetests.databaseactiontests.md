# DatabaseActionTests

Namespace: SlottyMedia.Tests.DatabaseTests

Tests for DatabaseActions class.

```csharp
public class DatabaseActionTests : BaseDatabaseTestClass
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [BaseDatabaseTestClass](./slottymedia.tests.databasetests.basedatabasetestclass.md) → [DatabaseActionTests](./slottymedia.tests.databasetests.databaseactiontests.md)

## Properties

### **UserId**

The UserId of the User

```csharp
public Guid UserId { get; set; }
```

#### Property Value

[Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

### **DatabaseActions**

The DatabaseActions Object

```csharp
public DatabaseActions DatabaseActions { get; set; }
```

#### Property Value

DatabaseActions<br>

### **UserToWorkWith**

The User to work with

```csharp
public UserDao UserToWorkWith { get; set; }
```

#### Property Value

UserDao<br>

## Constructors

### **DatabaseActionTests()**

```csharp
public DatabaseActionTests()
```

## Methods

### **Setup()**

Sets up the test environment by initializing the user model.

```csharp
public void Setup()
```

### **TearDown()**

Cleans up the test environment by deleting the user if it exists.

```csharp
public Task TearDown()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **Insert()**

Tests the Insert method of DatabaseActions.

```csharp
public Task Insert()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **Insert_Failure()**

Tests the Insert method of DatabaseActions for failure.

```csharp
public void Insert_Failure()
```

### **Update()**

Tests the Update method of DatabaseActions.

```csharp
public Task Update()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **Update_Failure()**

Tests the Update method of DatabaseActions for failure.

```csharp
public void Update_Failure()
```

### **Delete()**

Tests the Delete method of DatabaseActions.

```csharp
public Task Delete()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **Delete_Failure()**

Tests the Delete method of DatabaseActions for failure.

```csharp
public void Delete_Failure()
```

### **GetEntityByField()**

Tests the GetEntityByField method of DatabaseActions.

```csharp
public Task GetEntityByField()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **GetEntityByField_Failure()**

Tests the GetEntityByField method of DatabaseActions for failure.

```csharp
public void GetEntityByField_Failure()
```

### **GetEntitieWithSelectorById()**

Tests the GetEntitieWithSelectorById method of DatabaseActions.

```csharp
public Task GetEntitieWithSelectorById()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **GetEntitieWithSelectorById_Failure()**

Tests the GetEntitieWithSelectorById method of DatabaseActions for failure.

```csharp
public void GetEntitieWithSelectorById_Failure()
```

### **GetEntitiesWithSelectorById()**

Tests the GetEntitiesWithSelectorById method of DatabaseActions.

```csharp
public Task GetEntitiesWithSelectorById()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **GetEntitiesWithSelectorById_Failure()**

Tests the GetEntitiesWithSelectorById method of DatabaseActions for failure.

```csharp
public void GetEntitiesWithSelectorById_Failure()
```

### **GetCountByField()**

Tests the GetCountByField method of DatabaseActions.

```csharp
public Task GetCountByField()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

#### Exceptions

T:SlottyMedia.Database.Exceptions.GeneralDatabaseException<br>
Thrown when there is a database-related error during the test execution.

**Remarks:**

This test ensures that the GetCountByField method correctly returns the count of users
 with a specific field and value. It first inserts a user into the database to ensure
 there is at least one entry, then retrieves the count of users with the specific field
 and value, and asserts that the count is greater than 0.
