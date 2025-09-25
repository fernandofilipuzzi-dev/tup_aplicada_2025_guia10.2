using FigurasABM;

using GeometriaListDALsImpl;
using GeometriaListDALsImpl.Utilities;
using GeometriaModels.DALs;
using GeometriaModels.DALs.Utilities;
using GeometriaMSQLDALsImpl;
using GeometriaMSQLDALsImpl.Utilities;
using GeometriaServices;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

//host es el contenedor principal de la aplicación.
var host = Host.CreateDefaultBuilder()
.ConfigureServices((context, services) =>
{
    IConfiguration configuration = context.Configuration;
    services.Configure<ConnectionStrings>(configuration.GetSection("ConnectionStrings"));

    /**/
    #region Registro de DALs y transaccion
    services.AddScoped<IDALTransaction<SqlTransaction>, MSQLDALTransaction>();
    services.AddSingleton<IFigurasDAL<SqlTransaction>, FigurasMSQLDAL>();
    #endregion

    #region Registro de services.
    services.AddSingleton<IFigurasService, FigurasService<SqlTransaction>>();
    #endregion

    /**/
    /*
    #region Registro de DALs y transaccion
    services.AddScoped<IDALTransaction<ListTransaction>, ListDALTransaction>();
    services.AddSingleton<IFigurasDAL<ListTransaction>, FigurasListDAL>();
    #endregion

    #region Registro de servicios
    services.AddSingleton<IFigurasService, FigurasService<ListTransaction>>();
    #endregion
    */


    services.AddTransient<FormPrincipalView>();
})
.Build();

ApplicationConfiguration.Initialize();
var form = host.Services.GetRequiredService<FormPrincipalView>();
Application.Run(form);


