using System.Net;

namespace ExemploDDD.Exceptions.ExceptionBase;
public class InvalidLoginException : ExemploDDDException
{
    public InvalidLoginException() : base("Email or password invalid")
    {
        
    }
    public override IList<string> GetErrorMessages() => [Message];

    public override HttpStatusCode GetStatusCode() => HttpStatusCode.Unauthorized;
}

