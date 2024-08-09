# ISignupFormVm

Namespace: SlottyMedia.Backend.ViewModel.Interfaces

This ViewModel is used for the app's signup page. It represents the
 form's internal state and provides functionalities for submitting the
 form as well.

```csharp
public interface ISignupFormVm
```

## Properties

### **Username**

The form's username

```csharp
public abstract string Username { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **UsernameErrorMessage**

An optional error message that is caused by the username

```csharp
public abstract string UsernameErrorMessage { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Email**

The form's email address

```csharp
public abstract string Email { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **EmailErrorMessage**

An optional error message that is caused by the email address

```csharp
public abstract string EmailErrorMessage { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Password**

The form's password

```csharp
public abstract string Password { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **PasswordErrorMessage**

An optional error message that is caused by the password

```csharp
public abstract string PasswordErrorMessage { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **ServerErrorMessage**

An optional error message that is caused by some internal server error

```csharp
public abstract string ServerErrorMessage { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

## Methods

### **SubmitSignupForm()**

Attempts to submit the form. If this is successful, then the user was signed up
 successfully and cookies have been set. Otherwise, an exception is thrown.

```csharp
Task SubmitSignupForm()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

#### Exceptions

[ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/system.argumentexception)<br>
If an input field was left empty but was required

[UsernameAlreadyExistsException](./slottymedia.backend.exceptions.usernamealreadyexistsexception.md)<br>
If the username is already in use

[EmailAlreadyExistsException](./slottymedia.backend.exceptions.emailalreadyexistsexception.md)<br>
If the email address is already in use
