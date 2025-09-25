using GeometriaModels.DALs.Utilities;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;

namespace GeometriaMSQLDALsImpl.Utilities;

public class MSQLDALTransaction : IDALTransaction<SqlTransaction>
{
    private SqlTransaction? _transaccion;
    private SqlConnection? _sqlConnection;
    private readonly string _connectionString;

    public MSQLDALTransaction(string connectionString)
    {
        _connectionString = connectionString;
    }

    public MSQLDALTransaction(IOptions<ConnectionStrings> options)
    {
        _connectionString = options.Value.DefaultConnection
            ?? throw new ArgumentNullException(nameof(options.Value.DefaultConnection));
    }

    public async Task BeginTransaction()
    {
        _sqlConnection = new SqlConnection(_connectionString);
        await _sqlConnection.OpenAsync();
        _transaccion = _sqlConnection.BeginTransaction();
    }

    public void Commit()
    {
        _transaccion?.Commit();
    }

    public void Rollback()
    {
        _transaccion?.Rollback();
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

    public SqlTransaction? GetInternalTransaction()
    {
        return _transaccion;
    }

    public void Dispose()
    {
        _transaccion?.Dispose();
        _sqlConnection?.Dispose();
    }
}