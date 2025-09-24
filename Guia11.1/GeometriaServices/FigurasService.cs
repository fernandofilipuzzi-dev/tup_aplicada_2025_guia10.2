using Ejercicio.Models;
using FigurasModels.DALs.Utils;
using GeometriaModels.DALs;

namespace GeometriaServices;

public class FigurasService<T> : IFigurasService
{
    //readonly private FigurasMSQLDAL _figurasDao;
    //private readonly IDALTransaction<SqlTransaction> _transaction;

    readonly private IFigurasDAL<T> _figurasDao;
    private readonly IDALTransaction<T> _transaction;

    public FigurasService(IFigurasDAL<T> figurasDao, IDALTransaction<T> transaction)
    {
        _figurasDao = figurasDao;
        _transaction = transaction;
    }

    async public Task<List<FiguraModel?>?> GetAll()
    {
        return await _figurasDao.GetAll();
    }

    async public Task<FiguraModel?> GetById(int id)
    {
        return await _figurasDao.GetByKey(id);
    }

    async public Task CrearNuevo(FiguraModel objeto)
    {
        await _figurasDao.Add(objeto);
    }

    async public Task Actualizar(FiguraModel objeto)
    {
        await _figurasDao.Save(objeto);
    }

    async public Task Eliminar(int id)
    {
        try
        {
            await _transaction.BeginTransaction();

            var objeto = await _figurasDao.GetByKey(id, _transaction);
            if (objeto != null)
            {
                await _figurasDao.Remove(id, _transaction);
            }

            await _transaction.CommitAsync();
        }
        catch (Exception ex)
        {
            await _transaction.RollbackAsync();
            throw ex;
        }
    }
}
