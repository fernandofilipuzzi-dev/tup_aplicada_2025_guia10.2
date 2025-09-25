using GeometriaModels.DALs;
using GeometriaModels.DALs.Utilities;
using GeometriaMSQLDALsImpl;
using GeometriaMSQLDALsImpl.Utilities;
using GeometriaServices;
using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

IConfiguration configuration = builder.Configuration;
builder.Services.Configure<ConnectionStrings>(configuration.GetSection("ConnectionStrings"));

/**/
#region Registro de DALs y transaccion
builder.Services.AddTransient<IDALTransaction<SqlTransaction>, MSQLDALTransaction>();
builder.Services.AddSingleton<IFigurasDAL<SqlTransaction>, FigurasMSQLDAL>();
#endregion

#region Registro de services.
builder.Services.AddSingleton<IFigurasService, FigurasService<SqlTransaction>>();
#endregion



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
