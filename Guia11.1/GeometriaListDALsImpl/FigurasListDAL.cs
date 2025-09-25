using GeometriaListDALsImpl.Utilities;
using GeometriaModels;
using GeometriaModels.DALs;
using GeometriaModels.DALs.Utilities;

namespace GeometriaListDALsImpl;

public class FigurasListDAL : IFigurasDAL<ListTransaction>
{
    private int _id = 1;
    private readonly List<FiguraModel> _figuras = new List<FiguraModel>();

    public async Task<List<FiguraModel>> GetAll(IDALTransaction<ListTransaction>? transaccion = null)
    {
        if (transaccion?.GetInternalTransaction() is ListTransaction trans)
        {
            var lista=from copy in trans.GetWorkingCopy() where copy is FiguraModel select (FiguraModel)copy;
            return await Task.FromResult(lista.ToList());
        }
        return await Task.FromResult(_figuras);
    }

    public async Task<FiguraModel?> GetByKey(int idFigura, IDALTransaction<ListTransaction>? transaccion = null)
    {
        List<FiguraModel> lista = new List<FiguraModel>();
        if (transaccion?.GetInternalTransaction() is ListTransaction trans)
        {
            var list = from copy in trans.GetWorkingCopy() where copy is FiguraModel select (FiguraModel)copy;
            lista = list.ToList();
        }
        else
        {
            lista = _figuras;
        }

        var figura = lista.FirstOrDefault(f => f.Id == idFigura);
        return await Task.FromResult(figura);
    }

    public async Task<FiguraModel?> Add(FiguraModel nuevo, IDALTransaction<ListTransaction>? transaccion = null)
    {
        List<FiguraModel> lista = new List<FiguraModel>();
        if (transaccion?.GetInternalTransaction() is ListTransaction trans)
        {
            var list = from copy in trans.GetWorkingCopy() where copy is FiguraModel select (FiguraModel)copy;
            lista = list.ToList();
        }
        else
        {
            lista = _figuras;
        }

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
        List<FiguraModel> lista = new List<FiguraModel>();
        if (transaccion?.GetInternalTransaction() is ListTransaction trans)
        {
            var list = from copy in trans.GetWorkingCopy() where copy is FiguraModel select (FiguraModel)copy;
            lista = list.ToList();
        }
        else
        {
            lista = _figuras;
        }

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
        List<FiguraModel> lista=new List<FiguraModel>();
        if (transaccion?.GetInternalTransaction() is ListTransaction trans)
        {
            var list = from copy in trans.GetWorkingCopy() where copy is FiguraModel select (FiguraModel)copy;
            lista= list.ToList();
        }
        else
        {
            lista = _figuras;
        }

        var f = lista.FirstOrDefault(f => f.Id == idEntidad);

        if (f != null)
        {
            lista.Remove(f);
            return true;
        }

        return false;
    }

    async public Task ProcesarFiguras(IDALTransaction<ListTransaction>? transaccion = null)
    {
        //implementar...

    }
}