using lab2._1.Interfaces;

namespace lab2._1.Classes;

public class OlieveOil: IHealthyFood
{
    public string Name { get; set; } = "Оливковое масло";
    public bool Proteins { get; set; } = false;
    public bool Fats { get; set; } = true;
    public bool Carbonhydrates { get; set; } = false;
}