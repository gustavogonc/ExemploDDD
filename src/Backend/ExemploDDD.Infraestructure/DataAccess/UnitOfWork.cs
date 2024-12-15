using ExemploDDD.Domain.Repositories;

namespace ExemploDDD.Infraestructure.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ExemploDDDDbContext _dbContext;
        public UnitOfWork(ExemploDDDDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Commit() => await _dbContext.SaveChangesAsync();
    }
}
