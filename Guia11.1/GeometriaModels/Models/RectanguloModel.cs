namespace Ejercicio.Models;

public class RectanguloModel:FiguraModel
{
    public double? Ancho { get; set; }
    public double? Largo { get; set; }

    public RectanguloModel() { }

    public RectanguloModel(int? id, double? area, double? ancho, double? largo):base(id, area)
    {
        this.Ancho = ancho;
        this.Largo = largo;
    }
}
