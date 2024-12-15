namespace ExemploDDD.Domain.Repositories.User;
public interface IUserWriteOnlyRepository
{
    Task CreateUserAsync(Entities.User userRequest);
}

