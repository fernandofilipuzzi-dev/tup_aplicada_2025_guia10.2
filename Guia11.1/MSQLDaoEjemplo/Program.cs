

using GeometriaModels.DALs;
using GeometriaModels.DALs.Utilities;
using GeometriaMSQLDALsImpl;
using GeometriaMSQLDALsImpl.Utilities;
using GeometriaServices;
using Microsoft.Data.SqlClient;


string connectionString = "Data Source=TSP;Initial Catalog=Guia11_1_GeometriaDataBase_DB;Integrated Security=True;Persist Security Info=False;Pooling=False;Multiple Active Result Sets=False;Encrypt=True;Trust Server Certificate=True;Command Timeout=0";

IFigurasDAL<SqlTransaction> figuraDao=new FigurasMSQLDAL(connectionString);

IDALTransaction<SqlTransaction> transaction = new MSQLDALTransaction(connectionString);

IFigurasService figuraService = new FigurasService<SqlTransaction>(figuraDao, transaction);

await figuraService.ProcesarFiguras();

foreach (var figura in await figuraService.GetAll())
{
    Console.WriteLine($"Id: {figura?.Id},  Area: {figura?.Area}");
}

