# Session 17 - Continue to Authentication and Authorization

[Click here to download the lecture](https://www.idrive.com/idrive/sh/sh?k=p6a9r6e0o7)

## Authentication

Authentication is knowing the identity of the user. For example, Alice logs in with her username and password, and the server uses the password to authenticate Alice.

## Authorization

Authorization is deciding whether a user is allowed to perform an action. For example, Alice has permission to get a resource but not create a resource.

## Password Encryption

```cs
using System.Security.Cryptography;
using System.Text;

public static string EncryptPassword(string password)
{
    // Create a new instance of the SHA256 algorithm
    using (var sha256 = SHA256.Create())
    {
        // Convert the password string to a byte array
        byte[] bytes = Encoding.UTF8.GetBytes(password);

        // Compute the hash value of the byte array
        byte[] hash = sha256.ComputeHash(bytes);

        // Convert the hash value to a string and return it
        return Convert.ToBase64String(hash);
    }
}
```
