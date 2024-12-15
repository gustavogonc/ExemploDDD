namespace ExemploDDD.Domain.Repositories;
public interface IUnitOfWork
{
    Task Commit();
}

