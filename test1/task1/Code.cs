namespace test1.task1;

public class Code: ICode
{
    public string Name { get; } = "Бугалтер для студента";

    public string Description { get; } = "Привет! Эта программа поможет вам вычесть НДФЛ из вашей стипендии!";

    public void Run()
    {
        Console.Write("Введите вашу стипендию: ");

        decimal scholarship = 0;
        string input = Console.ReadLine() ?? string.Empty;
        decimal.TryParse(input, out scholarship);
        
        Console.WriteLine($"Ваша стипендия после подоходного налога: {scholarship * 0.87M :0.00}");
    }
}