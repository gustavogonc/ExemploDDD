using ExemploDDD.Domain.Entities;
using ExemploDDD.Domain.Repositories.User;
using Microsoft.EntityFrameworkCore;

namespace ExemploDDD.Infraestructure.DataAccess.Repositories;
public class UserRepository : IUserReadOnlyRepository, IUserWriteOnlyRepository
{
    private readonly ExemploDDDDbContext _dbContext;
    public UserRepository(ExemploDDDDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task CreateUserAsync(User userRequest) => await _dbContext.Users.AddAsync(userRequest);

    public async Task<List<User>> ReturnActiveUsersAsync()
    {
        return await _dbContext.Users
             .AsNoTracking()
             .Where(user => user.Active)
             .ToListAsync();
    }

    public async Task<User> ReturnUserByEmailAsync(string email)
    {
        return await _dbContext
                     .Users
                     .AsNoTracking()
                     .SingleOrDefaultAsync(user => user.Email == email);
    }
}

