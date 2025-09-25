using EjemploContenedorHost;
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

#region configuraciones e instanciación del DI
var services = new ServiceCollection();

var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
//usa el patron options - con Microsoft.Extensions.Options y  Microsoft.Extensions.Options.ConfigurationExtensions;
services.Configure<ConnectionStrings>(configuration.GetSection("ConnectionStrings"));
#endregion


#region Registro de DALs y transaccion
services.AddScoped<IDALTransaction<SqlTransaction>, MSQLDALTransaction>();
services.AddSingleton<IFigurasDAL<SqlTransaction>, FigurasMSQLDAL>();
#endregion

#region Registro de servicios
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
/**/

#region vistas
services.AddTransient<FormPrincipalView>();
#endregion

//
var serviceProvider = services.BuildServiceProvider();

// ejecución de la aplicación
ApplicationConfiguration.Initialize();
var form = serviceProvider.GetRequiredService<FormPrincipalView>();
Application.Run(form);
