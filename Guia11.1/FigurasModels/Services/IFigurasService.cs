
using Ejercicio.Models;

namespace FigurasModels.Services;

public interface IFigurasService
{
    Task<List<FiguraModel?>?> GetAll();
    Task<FiguraModel?> GetById(int id);
    Task CrearNuevo(FiguraModel objeto);
    Task Actualizar(FiguraModel objeto);
    Task Eliminar(int id);
}
