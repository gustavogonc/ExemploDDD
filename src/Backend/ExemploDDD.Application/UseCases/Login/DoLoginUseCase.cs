using ExemploDDD.Communication.Request;
using ExemploDDD.Communication.Response;
using ExemploDDD.Domain.Repositories.User;
using ExemploDDD.Domain.Security.Cryptography;
using ExemploDDD.Domain.Security.Tokens;
using ExemploDDD.Exceptions.ExceptionBase;

namespace ExemploDDD.Application.UseCases.Login;
public class DoLoginUseCase : IDoLoginUseCase
{
    private readonly IUserReadOnlyRepository _repository;
    private readonly IPasswordEncrypter _passwordEncrypter;
    private readonly IAccessTokenGenerator _accessTokenGenerator;
    public DoLoginUseCase(IUserReadOnlyRepository repository, IPasswordEncrypter passwordEncrypter, IAccessTokenGenerator acessTokenGenerator)
    {
        _accessTokenGenerator = acessTokenGenerator;
        _repository = repository;
        _passwordEncrypter = passwordEncrypter;
    }
    public async Task<ResponseRegisteredUserJson> Execute(RequestLoginJson request)
    {
        var user = await _repository.ReturnUserByEmailAsync(request.Email);

        if (user is null || !_passwordEncrypter.IsValid(request.Password, user.Password))
        {
            throw new InvalidLoginException();
        }

        return new ResponseRegisteredUserJson
        {
            Name = user.Name,
            Tokens = new ResponseTokensJson
            {
                AccessToken = _accessTokenGenerator.Generate(user.Name, user.Email),
            }
        };
    }
}

