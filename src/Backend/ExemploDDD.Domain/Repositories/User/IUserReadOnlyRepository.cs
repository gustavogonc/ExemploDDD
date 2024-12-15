namespace ExemploDDD.Domain.Repositories.User;

public interface IUserReadOnlyRepository
{
    Task<Entities.User> ReturnUserByEmailAsync(string email);
    Task<List<Entities.User>> ReturnActiveUsersAsync();
}

