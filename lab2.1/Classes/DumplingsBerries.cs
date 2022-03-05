using lab2._1.Interfaces;

namespace lab2._1.Classes;

public class DumplingsBerries: ISemiFinishedFood
{
    public string Name { get; set; } = "Вареники";
    public bool Proteins { get; set; } = false;
    public bool Fats { get; set; } = false;
    public bool Carbonhydrates { get; set; } = true;
}