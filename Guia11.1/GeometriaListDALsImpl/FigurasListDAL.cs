using Ejercicio.Models;
using FigurasModels.DALs.Utils;
using GeometriaListDALsImpl.Utilities;
using GeometriaModels.DALs;

namespace GeometriaListDALsImpl;

public class FigurasListDAL : IFigurasDAL<ListTransaction>
{
    private int _id = 1;
    private readonly List<FiguraModel> _figuras = new List<FiguraModel>();

    public async Task<List<FiguraModel>> GetAll(IDALTransaction<ListTransaction>? transaccion = null)
    {
        if (transaccion?.GetInternalTransaction() is ListTransaction trans)
        {
            return await Task.FromResult(trans.GetWorkingCopy());
        }
        return await Task.FromResult(_figuras);
    }

    public async Task<FiguraModel?> GetByKey(int idFigura, IDALTransaction<ListTransaction>? transaccion = null)
    {
        var lista = transaccion?.GetInternalTransaction() is ListTransaction trans
            ? trans.GetWorkingCopy()
            : _figuras;

        var figura = lista.FirstOrDefault(f => f.Id == idFigura);
        return await Task.FromResult(figura);
    }

    public async Task<FiguraModel?> Add(FiguraModel nuevo, IDALTransaction<ListTransaction>? transaccion = null)
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

    public async Task<bool> Save(FiguraModel entidad, IDALTransaction<ListTransaction>? transaccion = null)
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

    public async Task<bool> Remove(int idEntidad, IDALTransaction<ListTransaction>? transaccion = null)
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