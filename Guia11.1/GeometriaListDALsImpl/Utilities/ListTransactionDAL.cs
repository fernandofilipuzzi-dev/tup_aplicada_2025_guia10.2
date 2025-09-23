using FigurasModels.DALs.Utils;

namespace FigurasModels.DALs.MSQL.Utils;

public class ListTransactionDAL : ITransactionDAL<ListTransactionDAL>
{
    private ListTransactionDAL _transaccion;

    private readonly SqlConnection _sqlConnection;

    public ListTransactionDAL()
    {
    }

    public void Commit()
    {
        _transaccion.Commit();
    }

    public void Rollback()
    {
        _transaccion.Rollback();
    }

    public async Task CommitAsync()
    {
        await Task.CompletedTask;
    }

    public async Task RollbackAsync()
    {
        await Task.CompletedTask;
    }

    public void Dispose()
    {
        
    }

    public SqlTransaction GetInternalTransaction()
    {
        return _transaccion;
    }

    async public Task BeginTransaction()
    {
        await Task.CompletedTask;
    }
}