namespace FigurasModels.DALs.Utils;

public interface ITransactionDAL<T> : IDisposable
{
    void Commit();
    void Rollback();

    Task CommitAsync();

    Task RollbackAsync();

    T GetInternalTransaction();

    Task BeginTransaction();
}

