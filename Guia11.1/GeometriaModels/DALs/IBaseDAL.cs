using FigurasModels.DALs.Utils;

namespace FigurasModels.DALs;

public interface IBaseDAL<T, K, M>
{
    Task<List<T>> GetAll(ITransaction<M>? transaccion = null);
    Task<T?> GetByKey(K id, ITransaction<M>? transaccion = null);
    Task<T?> Add(T nuevo, ITransaction<M>? transaccion = null);
    Task<bool> Save(T actualizar, ITransaction<M>? transaccion = null);
    Task<bool> Remove(K id, ITransaction<M>? transaccion = null);
}