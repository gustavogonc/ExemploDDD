namespace ExemploDDD.Domain.Security.Tokens;
public interface IAccessTokenGenerator
{
    public string Generate(string name, string email);
}

