using ExemploDDD.Communication.Response;

namespace ExemploDDD.Application.UseCases.User.ListActiveUsers;
public interface IRecoverActiveUsersUseCase
{
    Task<IList<ResponseUserProfileJson>> ExecuteAsync();
}

