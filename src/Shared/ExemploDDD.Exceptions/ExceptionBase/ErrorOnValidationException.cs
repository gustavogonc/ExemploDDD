using System.Net;

namespace ExemploDDD.Exceptions.ExceptionBase;
public class ErrorOnValidationException : ExemploDDDException
{
    private readonly IList<string> _errorMessages;

    public ErrorOnValidationException(IList<string> erros) : base(string.Empty)
    {
        _errorMessages = erros;
    }
    public override IList<string> GetErrorMessages() => _errorMessages;

    public override HttpStatusCode GetStatusCode() => HttpStatusCode.BadRequest;
}

