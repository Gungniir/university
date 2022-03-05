using lab2._1.Interfaces;

namespace lab2._1.Classes;

public class DumplingsMeat: ISemiFinishedFood
{
    public string Name { get; set; } = "Пельмеши";
    public bool Proteins { get; set; } = true;
    public bool Fats { get; set; } = false;
    public bool Carbonhydrates { get; set; } = false;
}