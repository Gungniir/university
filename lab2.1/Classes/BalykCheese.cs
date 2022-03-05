using lab2._1.Interfaces;

namespace lab2._1.Classes;

public class BalykCheese: ISnacks
{
    public string Name { get; set; } = "Сыр";
    public bool Proteins { get; set; } = true;
    public bool Fats { get; set; } = false;
    public bool Carbonhydrates { get; set; } = false;
}