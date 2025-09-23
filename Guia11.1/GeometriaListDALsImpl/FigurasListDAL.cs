using Ejercicio.Models;
using FigurasModels.DALs;
using FigurasModels.DALs.MSQL.Utils;
using FigurasModels.DALs.Utils;

namespace GeometriaListDALsImpl;

public class FigurasListDAL : IBaseDAL<FiguraModel, int, ListTransactionDAL>
{
    int id = 1;
    List<FiguraModel> figuras = new List<FiguraModel>();
 
    async public Task<List<FiguraModel>> GetAll(ITransactionDAL<ListTransactionDAL>? transaccion = null)
    {
        return await Task.FromResult(figuras);
    }

    async public Task<FiguraModel?> GetByKey(int idFigura, ITransactionDAL<ListTransactionDAL>? transaccion = null)
    {
        FiguraModel figura = (from f in figuras where f.Id == idFigura select f).FirstOrDefault();
        return await Task.FromResult(figura);
    }

    async public Task<FiguraModel?> Add(FiguraModel nuevo, ITransactionDAL<ListTransactionDAL>? transaccion = null)
    {
        FiguraModel f = await GetByKey(nuevo.Id ?? 0);

        if (f == null)
        {
            figuras.Add(nuevo);
            nuevo.Id = id++;
            return nuevo;
        }
        return null;
    }

    async public Task<bool> Save(FiguraModel entidad, ITransactionDAL<ListTransactionDAL>? transaccion = null)
    {
        FiguraModel f = await GetByKey(entidad.Id ?? 0);

        if (f == null)
        {
            figuras.Add(entidad);
            return true;
        }
        return false;
    }

    async public Task<bool> Remove(int idEntidad, ITransactionDAL<ListTransactionDAL>? transaccion = null)
    {
        FiguraModel f = await GetByKey(idEntidad);

        if (f != null)
        {
            figuras.Remove(f);
            return true;
        }

        return false;
    }
}
