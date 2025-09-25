
using GeometriaListDALsImpl;
using GeometriaListDALsImpl.Utilities;
using GeometriaModels.DALs;
using GeometriaModels.DALs.Utilities;
using GeometriaServices;

IDALTransaction<ListTransaction> transaction = new ListDALTransaction();

IFigurasDAL<ListTransaction> figurasDAL= new FigurasListDAL();

IFigurasService service=new FigurasService<ListTransaction>(figurasDAL, transaction);