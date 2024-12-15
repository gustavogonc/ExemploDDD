using ExemploDDD.Communication.Response;
using ExemploDDD.Domain.Repositories.User;

namespace ExemploDDD.Application.UseCases.User.ListActiveUsers;
public class RecoverActiveUsersUseCase : IRecoverActiveUsersUseCase
{
    private readonly IUserReadOnlyRepository _repository;
    public RecoverActiveUsersUseCase(IUserReadOnlyRepository repository)
    {
        _repository = repository;
    }
    public Task<IList<ResponseUserProfileJson>> ExecuteAsync()
    {
        throw new NotImplementedException();
    }
}

