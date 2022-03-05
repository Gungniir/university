using lab2._1.Interfaces;

namespace lab2._1.Classes;

public class Fruit: IHealthyFood
{
    public string Name { get; set; } = "Фрукт";
    public bool Proteins { get; set; } = false;
    public bool Fats { get; set; } = false;
    public bool Carbonhydrates { get; set; } = true;
}