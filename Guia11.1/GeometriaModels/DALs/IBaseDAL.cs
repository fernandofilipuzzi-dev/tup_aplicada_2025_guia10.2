
using GeometriaModels.DALs.Utilities;

namespace GeometriaModels.DALs;

public interface IBaseDAL<E, K, T>
{
    Task<List<E>> GetAll(IDALTransaction<T>? transaccion = null);
    Task<E?> GetByKey(K id, IDALTransaction<T>? transaccion = null);
    Task<E?> Add(E nuevo, IDALTransaction<T>? transaccion = null);
    Task<bool> Save(E actualizar, IDALTransaction<T>? transaccion = null);
    Task<bool> Remove(K id, IDALTransaction<T>? transaccion = null);   
}