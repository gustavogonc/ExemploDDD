using ExemploDDD.Communication.Request;

namespace ExemploDDD.Application.UseCases.User.Register;
public interface IRegisterUserUseCase
{
    Task ExecuteAsync(RegisterUserRequest userRequest);
}

