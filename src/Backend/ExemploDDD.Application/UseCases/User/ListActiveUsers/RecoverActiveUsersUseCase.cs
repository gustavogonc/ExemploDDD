using AutoMapper;
using ExemploDDD.Communication.Response;
using ExemploDDD.Domain.Repositories.User;

namespace ExemploDDD.Application.UseCases.User.ListActiveUsers;
public class RecoverActiveUsersUseCase : IRecoverActiveUsersUseCase
{
    private readonly IUserReadOnlyRepository _repository;
    private readonly IMapper _mapper;
    public RecoverActiveUsersUseCase(IUserReadOnlyRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<IList<ResponseUserProfileJson>> ExecuteAsync()
    {
        var users = await _repository.ReturnActiveUsersAsync();
        return _mapper.Map<IList<ResponseUserProfileJson>>(users);
    }
}

