using lab2._1.Interfaces;

namespace lab2._1.Classes;

public class Cart<T> where T: IFood
{
    public List<T> Foodstuffs { get; init; } = new();

    public void CartBalansing(List<T> foods)
    {
        if (!HasProteins())
        {
            Foodstuffs.Add(foods.First(food => food.Proteins));
        }
        if (!HasCarbonhydrates())
        {
            Foodstuffs.Add(foods.First(food => food.Carbonhydrates));
        }
        if (!HasFats())
        {
            Foodstuffs.Add(foods.First(food => food.Fats));
        }
    }
    
    public bool Isbalanced()
    {
        return HasProteins() && HasCarbonhydrates() && HasFats();
    }

    private bool HasProteins()
    {
        return Foodstuffs.Any(food => food.Proteins);
    }

    private bool HasCarbonhydrates()
    {
        return Foodstuffs.Any(food => food.Carbonhydrates);
    }

    private bool HasFats()
    {
        return Foodstuffs.Any(food => food.Fats);
    }
}