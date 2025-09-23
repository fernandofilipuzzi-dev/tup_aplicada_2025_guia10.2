using FigurasModels.DALs.Utils;

namespace FigurasModels.DALs;

public interface IBaseDAL<T, K, M>
{
    Task<List<T>> GetAll(ITransactionDAL<M>? transaccion = null);
    Task<T?> GetByKey(K id, ITransactionDAL<M>? transaccion = null);
    Task<T?> Add(T nuevo, ITransactionDAL<M>? transaccion = null);
    Task<bool> Save(T actualizar, ITransactionDAL<M>? transaccion = null);
    Task<bool> Remove(K id, ITransactionDAL<M>? transaccion = null);
}