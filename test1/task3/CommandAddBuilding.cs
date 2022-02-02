namespace test1.task3;

public class CommandAddBuilding: ICommand
{
    public bool Equals(string? other)
    {
        return Signature.Equals(other);
    }

    public string Signature { get; } = "building:add";
    public string Description { get; } = "Добавить новое здание";

    private readonly IDatabase _db;

    public CommandAddBuilding(IDatabase db)
    {
        _db = db;
    }
    public void Run()
    {
        Console.WriteLine("Введите необходимые данные для создания строения");
        Console.Write("Адрес: ");
        string? adress = Console.ReadLine();

        if (string.IsNullOrEmpty(adress))
        {
            Console.WriteLine("Введена пустая строка. Данные не обновлены");
            return;
        }
        
        Console.Write("Срок амортизации (в годах): ");
        string? deprecationPeriodRaw = Console.ReadLine();

        if (string.IsNullOrEmpty(deprecationPeriodRaw))
        {
            Console.WriteLine("Введена пустая строка. Данные не обновлены");
            return;
        }

        int deprecationPeriod = int.Parse(deprecationPeriodRaw);
        
        Console.Write("Дата постройки (дд.мм.гггг): ");
        string? startDateRaw = Console.ReadLine();

        if (string.IsNullOrEmpty(startDateRaw))
        {
            Console.WriteLine("Введена пустая строка. Данные не обновлены");
            return;
        }
        
        DateOnly startDate = DateOnly.ParseExact(startDateRaw, "dd.MM.yyyy");
        
        Console.Write("Цена в момент постройки (в рублях): ");
        string? startPriceRaw = Console.ReadLine();

        if (string.IsNullOrEmpty(startPriceRaw))
        {
            Console.WriteLine("Введена пустая строка. Данные не обновлены");
            return;
        }

        decimal startPrice = decimal.Parse(startPriceRaw);
        
        Console.Write("Идентификатор ответсвенного лица: ");
        string? ownerIdRaw = Console.ReadLine();

        if (string.IsNullOrEmpty(ownerIdRaw))
        {
            Console.WriteLine("Введена пустая строка. Данные не обновлены");
            return;
        }

        int ownerId = int.Parse(ownerIdRaw);

        if (_db.SelectPersonById(ownerId) is null)
        {
            Console.WriteLine($"В системе не зарегестрирован работник с идентификатором {ownerId}. Данные не обновлены");
            return;
        }

        Building building = _db.InsertBuilding(new Building
        {
            Adress = adress,
            DeprecationPeriod = deprecationPeriod,
            StartDate = startDate,
            StartPrice = startPrice,
            OwnerId = ownerId
        });
            
        Console.WriteLine($"Добавлено новое здание по адресу {building.Adress}. Его идентификатор: {building.Id}");
    }
}