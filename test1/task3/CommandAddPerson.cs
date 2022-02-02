namespace test1.task3;

public class CommandAddPerson: ICommand
{
    public string Signature { get; } = "person:add";
    public string Description { get; } = "Добавить нового сотрудника";

    private readonly IDatabase _db;

    public CommandAddPerson(IDatabase db)
    {
        _db = db;
    }
    
    public void Run()
    {
        Console.WriteLine("Введите необходимые данные для создания сотрудника");
        Console.Write("ФИО: ");
        string? input = Console.ReadLine();

        if (string.IsNullOrEmpty(input))
        {
            Console.WriteLine("Введена пустая строка. Данные не обновлены");
            return;
        }

        Console.Write("Должность: ");
        string? position = Console.ReadLine();

        if (string.IsNullOrEmpty(position))
        {
            Console.WriteLine("Введена пустая строка. Данные не обновлены");
            return;
        }

        Person person = _db.InsertPerson(new Person
        {
            Fio = input,
            Position = position
        });
            
        Console.WriteLine($"Добавлен новый сотрудник {person.Fio}. Его идентификатор: {person.Id}");
    }

    public bool Equals(string? other)
    {
        return Signature.Equals(other);
    }
}