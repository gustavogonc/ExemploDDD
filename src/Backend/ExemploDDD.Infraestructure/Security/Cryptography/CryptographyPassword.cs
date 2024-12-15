using ExemploDDD.Domain.Security.Cryptography;

namespace ExemploDDD.Infraestructure.Security.Cryptography;
public class CryptographyPassword : IPasswordEncrypter
{
    public string Encrypt(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    public bool IsValid(string password, string passwordHash)
    {
        return BCrypt.Net.BCrypt.Verify(password, passwordHash);
    }
}

