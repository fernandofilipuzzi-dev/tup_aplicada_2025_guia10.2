using FigurasABM;
using FigurasModels.DALs.MSQL;
using FigurasModels.DALs.MSQL.Utils;
using FigurasModels.DALs.Utils;
using FigurasModels.Services;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

#region instanciación del DI
var services = new ServiceCollection();

var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
//usa el patron options - con Microsoft.Extensions.Options y  Microsoft.Extensions.Options.ConfigurationExtensions;
services.Configure<ConnectionStrings>(configuration.GetSection("ConnectionStrings"));
#endregion

services.AddScoped<ITransactionDAL<SqlTransaction>, MSQLTransaction>();

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
