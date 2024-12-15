using ExemploDDD.Communication.Request;
using ExemploDDD.Communication.Response;

namespace ExemploDDD.Application.UseCases.Login;
public interface IDoLoginUseCase
{
    Task<ResponseRegisteredUserJson> Execute(RequestLoginJson request);
}

