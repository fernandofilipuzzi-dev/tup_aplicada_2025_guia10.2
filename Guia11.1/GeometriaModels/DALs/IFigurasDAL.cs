
using GeometriaModels.DALs.Utilities;

namespace GeometriaModels.DALs;

public interface IFigurasDAL<T>:IBaseDAL<FiguraModel, int, T>
{
    //agregar métodos específicos
    Task ProcesarFiguras(IDALTransaction<T>? transaccion = null);
}
