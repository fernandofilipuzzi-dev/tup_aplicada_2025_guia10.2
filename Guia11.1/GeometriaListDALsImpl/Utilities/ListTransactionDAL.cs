using FigurasModels.DALs.Utils;
using GeometriaListDALsImpl.Utilities;

namespace FigurasModels.DALs.MSQL.Utils;

public class ListTransactionDAL : ITransactionDAL<ListTransaction>
{
    private ListTransaction? _transaccion;

    public ListTransactionDAL()
    {
    }

    public void Commit()
    {
        if (_transaccion == null)
            throw new InvalidOperationException("Transaction has not been started.");
        _transaccion.Commit();
    }

    public void Rollback()
    {
        if (_transaccion == null)
            throw new InvalidOperationException("Transaction has not been started.");
        _transaccion.Rollback();
    }

    public async Task CommitAsync()
    {
        if (_transaccion == null)
            throw new InvalidOperationException("Transaction has not been started.");
        await Task.Run(() => _transaccion.Commit());
    }

    public async Task RollbackAsync()
    {
        if (_transaccion == null)
            throw new InvalidOperationException("Transaction has not been started.");
        await Task.Run(() => _transaccion.Rollback());
    }

    public void Dispose()
    {
        _transaccion = null;
    }

    public ListTransaction? GetInternalTransaction()
    {
        return _transaccion;
    }

    public async Task BeginTransaction()
    {
        _transaccion = new ListTransaction();
        await Task.CompletedTask;
    }
}