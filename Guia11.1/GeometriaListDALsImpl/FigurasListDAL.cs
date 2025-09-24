using Ejercicio.Models;
using FigurasModels.DALs;
using FigurasModels.DALs.Utils;
using GeometriaListDALsImpl.Utilities;

namespace GeometriaListDALsImpl;

public class FigurasListDAL : IBaseDAL<FiguraModel, int, ListTransaction>
{
    private int _id = 1;
    private readonly List<FiguraModel> _figuras = new List<FiguraModel>();

    public async Task<List<FiguraModel>> GetAll(ITransactionDAL<ListTransaction>? transaccion = null)
    {
        if (transaccion?.GetInternalTransaction() is ListTransaction trans)
        {
            return await Task.FromResult(trans.GetWorkingCopy());
        }
        return await Task.FromResult(_figuras);
    }

    public async Task<FiguraModel?> GetByKey(int idFigura, ITransactionDAL<ListTransaction>? transaccion = null)
    {
        var lista = transaccion?.GetInternalTransaction() is ListTransaction trans
            ? trans.GetWorkingCopy()
            : _figuras;

        var figura = lista.FirstOrDefault(f => f.Id == idFigura);
        return await Task.FromResult(figura);
    }

    public async Task<FiguraModel?> Add(FiguraModel nuevo, ITransactionDAL<ListTransaction>? transaccion = null)
    {
        var lista = transaccion?.GetInternalTransaction() is ListTransaction trans
            ? trans.GetWorkingCopy()
            : _figuras;

        var f = lista.FirstOrDefault(f => f.Id == nuevo.Id);

        if (f == null)
        {
            nuevo.Id = _id++;
            lista.Add(nuevo);
            return nuevo;
        }
        return null;
    }

    public async Task<bool> Save(FiguraModel entidad, ITransactionDAL<ListTransaction>? transaccion = null)
    {
        var lista = transaccion?.GetInternalTransaction() is ListTransaction trans
            ? trans.GetWorkingCopy()
            : _figuras;

        var f = lista.FirstOrDefault(f => f.Id == entidad.Id);

        if (f == null)
        {
            lista.Add(entidad);
            return true;
        }
        return false;
    }

    public async Task<bool> Remove(int idEntidad, ITransactionDAL<ListTransaction>? transaccion = null)
    {
        var lista = transaccion?.GetInternalTransaction() is ListTransaction trans
            ? trans.GetWorkingCopy()
            : _figuras;

        var f = lista.FirstOrDefault(f => f.Id == idEntidad);

        if (f != null)
        {
            lista.Remove(f);
            return true;
        }

        return false;
    }
}