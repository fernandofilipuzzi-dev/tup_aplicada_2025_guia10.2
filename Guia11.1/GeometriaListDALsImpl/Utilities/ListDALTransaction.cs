
using GeometriaModels.DALs.Utilities;

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
        _transaccion.Commit();
    }

    public void Rollback()
    {
        if (_transaccion == null)
            return;
        _transaccion.Rollback();
    }

    public async Task CommitAsync()
    {
        if (_transaccion == null)
            return;
        await Task.Run(() => _transaccion.Commit());
    }

    public async Task RollbackAsync()
    {
        if (_transaccion == null)
            return;
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

    public List<object> _workingCopy { get; set; }
    public async Task BeginTransaction()
    {
        _transaccion = new ListTransaction(_workingCopy);
        await Task.CompletedTask;
    }
}