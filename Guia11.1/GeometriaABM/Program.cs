using FigurasABM;
using FigurasModels.DALs.Utils;
using GeometriaMSQLDALsImpl;
using GeometriaMSQLDALsImpl.Utilities;
using GeometriaServices;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

#region instanciación del DI
var services = new ServiceCollection();

var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
//usa el patron options - con Microsoft.Extensions.Options y  Microsoft.Extensions.Options.ConfigurationExtensions;
services.Configure<ConnectionStrings>(configuration.GetSection("ConnectionStrings"));
#endregion

services.AddScoped<ITransactionDAL<SqlTransaction>, MSQLTransactionDAL>();

#region registro de DALs
services.AddSingleton<FigurasMSQLDAL>();
#endregion

#region registro de servicios
services.AddSingleton<IFigurasService, FigurasService>();
#endregion

#region vistas
services.AddTransient<FormPrincipalView>();
#endregion

//
var serviceProvider = services.BuildServiceProvider();

// ejecución de la aplicación
ApplicationConfiguration.Initialize();
var form = serviceProvider.GetRequiredService<FormPrincipalView>();
Application.Run(form);
