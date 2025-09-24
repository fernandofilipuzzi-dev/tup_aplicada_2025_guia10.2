using Ejercicio.Models;
using FigurasModels.DALs;
using FigurasModels.DALs.Utils;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;

namespace GeometriaMSQLDALsImpl;

public class FigurasMSQLDAL : IBaseDAL<FiguraModel, int, SqlTransaction>
{
    private readonly string _connectionString;

    public FigurasMSQLDAL(IOptions<ConnectionStrings> options)
    {
        _connectionString = options.Value.DefaultConnection;
    }

    async public Task<List<FiguraModel>> GetAll(ITransactionDAL<SqlTransaction>? transaccion = null)
    {
        List<FiguraModel> figuras = new List<FiguraModel>();

        #region conexion y comando sql
        string query = @"
SELECT f.Id,
	   f.Tipo,
	   f.Area,
	   f.Ancho,
	   f.Largo,
	   f.Radio
FROM Figuras f
ORDER BY f.Id
";
 
        var conn = await GetOpenedConnectionAsync(transaccion);

        using SqlCommand command = new SqlCommand(query, conn, transaccion?.GetInternalTransaction());

        using SqlDataReader dataReader = await command.ExecuteReaderAsync();
        #endregion

        while (await dataReader.ReadAsync())
        {
            figuras.Add(this.ReadAsObjeto(dataReader));
        }

        return figuras;
    }

    async public Task<FiguraModel?> GetByKey(int idFigura, ITransactionDAL<SqlTransaction>? transaccion = null)
    {
        FiguraModel figura = null;

        string query = @"
SELECT TOP 1    f.Id,
	           f.Tipo AS Tipo,
	           f.Area,
	           f.Ancho,
	           f.Largo,
	           f.Radio
FROM Figuras f
WHERE f.Id=@Id
ORDER BY f.Area
";

        try
        {
            SqlConnection conn = await GetOpenedConnectionAsync(transaccion);

            #region comando sql
            using SqlCommand cmd = new SqlCommand(query, conn, transaccion?.GetInternalTransaction());
            cmd.Parameters.AddWithValue("@Id", idFigura);
            #endregion

            using SqlDataReader dataReader = await cmd.ExecuteReaderAsync();

            if (await dataReader.ReadAsync())
            {
                figura = this.ReadAsObjeto(dataReader);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return figura;
    }

    async public Task<FiguraModel?> Add(FiguraModel nuevo, ITransactionDAL<SqlTransaction>? transaccion = null)
    {
        int tipo = 0;
        double? ancho = null;
        double? largo = null;
        double? radio = null;

        string query = @"
INSERT INTO Figuras (Tipo, Ancho, Largo, Radio)
OUTPUT INSERTED.Id
VALUES
(@Tipo, @Ancho, @Largo, @Radio)
";
        try
        {
            using SqlConnection conn = await GetOpenedConnectionAsync(transaccion);

            using SqlCommand comm = new SqlCommand(query, conn, transaccion?.GetInternalTransaction());

            if (nuevo is RectanguloModel r)
            {
                tipo = 1;
                ancho = r.Ancho;
                largo = r.Largo;
            }
            else if (nuevo is CirculoModel c)
            {
                tipo = 2;
                radio = c.Radio;
            }

            comm.Parameters.AddWithValue("@Tipo", tipo);
            comm.Parameters.AddWithValue("@Ancho", ancho ?? (object)DBNull.Value);
            comm.Parameters.AddWithValue("@Largo", largo ?? (object)DBNull.Value);
            comm.Parameters.AddWithValue("@Radio", radio ?? (object)DBNull.Value);

            object idObject = await comm.ExecuteScalarAsync();

            nuevo.Id = Convert.ToInt32(idObject);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex}");
        }
        return nuevo;
    }

    async public Task<bool> Save(FiguraModel entidad, ITransactionDAL<SqlTransaction>? transaccion = null)
    {
        int id = 0;
        double? area = null;
        double? ancho = null;
        double? largo = null;
        double? radio = null;

        string query = @"
UPDATE Figuras SET Area=@Area, Ancho=@Ancho, Largo=@Largo, Radio=@Radio
WHERE Id=@Id_Figura
";
        try
        {
            using SqlConnection conn = await GetOpenedConnectionAsync(transaccion);

            using SqlCommand comm = new SqlCommand(query, conn, transaccion?.GetInternalTransaction());

            id = entidad.Id ?? 0;
            if (entidad is RectanguloModel r)
            {
                ancho = r.Ancho;
                largo = r.Largo;
            }
            else if (entidad is CirculoModel c)
            {
                radio = c.Radio;
            }
            area = entidad.Area;

            comm.Parameters.AddWithValue("@Id_Figura", id);
            comm.Parameters.AddWithValue("@Area", area ?? (object)DBNull.Value);
            comm.Parameters.AddWithValue("@Ancho", ancho ?? (object)DBNull.Value);
            comm.Parameters.AddWithValue("@Largo", largo ?? (object)DBNull.Value);
            comm.Parameters.AddWithValue("@Radio", radio ?? (object)DBNull.Value);

            int cantidad = await comm.ExecuteNonQueryAsync();

            return id > cantidad;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex}");
        }
        return false;
    }

    async public Task<bool> Remove(int idFigura, ITransactionDAL<SqlTransaction>? transaccion = null)
    {
        string query = @"
DELETE 
FROM Figuras 
WHERE Id=@Id_Figura
";

        try
        {
            SqlConnection conn = await GetOpenedConnectionAsync(transaccion);

            #region sqlcommand
            using SqlCommand cmd = new SqlCommand(query, conn, transaccion?.GetInternalTransaction());
            cmd.Parameters.AddWithValue("@Id_Figura", idFigura);
            #endregion

            int cantidad = await cmd.ExecuteNonQueryAsync();

            return cantidad > 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }

        return false;
    }

    private async Task<SqlConnection> GetOpenedConnectionAsync(ITransactionDAL<SqlTransaction>? transaccion)
    {
        var conexion = transaccion?.GetInternalTransaction()?.Connection ?? new SqlConnection(_connectionString);
        if (conexion.State == System.Data.ConnectionState.Closed)
        {
            await conexion.OpenAsync();
        }
        return conexion;
    }

    private FiguraModel ReadAsObjeto(SqlDataReader dataReader)
    {
        #region parseo
        int? id = dataReader["Id"] != DBNull.Value ? Convert.ToInt32(dataReader["Id"]) : null;
        int? tipo = dataReader["Tipo"] != DBNull.Value ? Convert.ToInt32(dataReader["Tipo"]) : null;
        double? area = Convert.ToInt32(dataReader["Area"] != DBNull.Value ? dataReader["Area"] : null);
        double? ancho = Convert.ToInt32(dataReader["Ancho"] != DBNull.Value ? dataReader["Ancho"] : null);
        double? largo = Convert.ToInt32(dataReader["Largo"] != DBNull.Value ? dataReader["Largo"] : null);
        double? radio = Convert.ToInt32(dataReader["Radio"] != DBNull.Value ? dataReader["Radio"] : null);
        #endregion

        FiguraModel entidad = null;
        if (tipo == 1)
        {
            entidad = new RectanguloModel() { Id = id, Area = area, Ancho = ancho, Largo = largo };
        }
        else if (tipo == 2)
        {
            entidad = new CirculoModel() { Id = id, Area = area, Radio = radio };
        }
        return entidad;
    }
}
