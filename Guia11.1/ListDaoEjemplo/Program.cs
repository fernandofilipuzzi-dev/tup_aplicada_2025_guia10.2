
using GeometriaListDALsImpl;
using GeometriaListDALsImpl.Utilities;
using GeometriaModels;
using GeometriaModels.DALs;
using GeometriaModels.DALs.Utilities;
using GeometriaServices;

IDALTransaction<ListTransaction> transaction = new ListDALTransaction();

IFigurasDAL<ListTransaction> figurasDAL= new FigurasListDAL();

IFigurasService figuraService = new FigurasService<ListTransaction>(figurasDAL, transaction);

await figuraService.ProcesarFiguras();


figuraService.CrearNuevo(new RectanguloModel() { Id=1, Ancho = 12 });

foreach (var figura in await figuraService.GetAll())
{
    Console.WriteLine($"Id: {figura?.Id},  Area: {figura?.Area}");
}
