using ExemploDDD.Domain.Repositories;

namespace ExemploDDD.Infraestructure.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        public async Task Commit()
        {
            throw new NotImplementedException();
        }
    }
}
