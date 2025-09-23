namespace Ejercicio.Models;

public class CirculoModel:FiguraModel
{
    public double? Radio { get; set; }

    public CirculoModel() { }
    public CirculoModel(int? id, double? area, double radio) : base(id, area)
    { 
        this.Radio = radio;
    }
}
