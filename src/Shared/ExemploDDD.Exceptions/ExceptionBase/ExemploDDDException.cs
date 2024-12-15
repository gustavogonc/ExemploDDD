using System.Net;

namespace ExemploDDD.Exceptions.ExceptionBase;
public abstract class ExemploDDDException : SystemException
{
    protected ExemploDDDException(string message): base(message) { }
    public abstract IList<string> GetErrorMessages();
    public abstract HttpStatusCode GetStatusCode();
}

