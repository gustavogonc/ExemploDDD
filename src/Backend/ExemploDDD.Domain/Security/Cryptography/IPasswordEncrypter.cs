namespace ExemploDDD.Domain.Security.Cryptography;
public interface IPasswordEncrypter
{
    string Encrypt(string password);
    public bool IsValid(string password, string passwordHash);
}

