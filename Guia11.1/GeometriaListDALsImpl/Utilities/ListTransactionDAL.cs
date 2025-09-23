using FigurasModels.DALs.Utils;
using GeometriaListDALsImpl.Utilities;

namespace FigurasModels.DALs.MSQL.Utils;

public class ListTransactionDAL : ITransactionDAL<ListTransaction>
{
    private ListTransaction _transaccion;

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

    public ListTransaction GetInternalTransaction()
    {
        return _transaccion;
    }

    async public Task BeginTransaction()
    {
        await Task.CompletedTask;
    }
}