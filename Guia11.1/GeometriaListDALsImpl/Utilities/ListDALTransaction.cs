using Ejercicio.Models;
using FigurasModels.DALs.Utils;

namespace GeometriaListDALsImpl.Utilities;

public class ListDALTransaction : IDALTransaction<ListTransaction>
{
    private ListTransaction? _transaccion;

    public ListDALTransaction()
    {
    }

    public void Commit()
    {
        if (_transaccion == null)
            return;
            //throw new InvalidOperationException("Transaction has not been started.");
        _transaccion.Commit();
    }

    public void Rollback()
    {
        if (_transaccion == null)
            return;
            //throw new InvalidOperationException("Transaction has not been started.");
        _transaccion.Rollback();
    }

    public async Task CommitAsync()
    {
        if (_transaccion == null)
            return;
            //throw new InvalidOperationException("Transaction has not been started.");
        await Task.Run(() => _transaccion.Commit());
    }

    public async Task RollbackAsync()
    {
        if (_transaccion == null)
            return;
            //throw new InvalidOperationException("Transaction has not been started.");
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

    public List<FiguraModel> _workingCopy { get; set; }
    public async Task BeginTransaction()
    {
        _transaccion = new ListTransaction(_workingCopy);
        await Task.CompletedTask;
    }
}