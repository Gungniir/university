namespace lab2._1.Interfaces;

public interface IFood: IThing
{
    public bool Proteins { get; set; }
    public bool Fats { get; set; }
    public bool Carbonhydrates { get; set; }
}