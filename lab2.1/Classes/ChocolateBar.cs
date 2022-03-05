using lab2._1.Interfaces;

namespace lab2._1.Classes;

public class ChocolateBar: ISnacks
{
    public string Name { get; set; } = "Шоколадка";
    public bool Proteins { get; set; } = false;
    public bool Fats { get; set; } = false;
    public bool Carbonhydrates { get; set; } = true;
}