using test1.consoler;

namespace test1.task3;

public class CommandBuildingsPerson: ICommand
{
    public bool Equals(string? other)
    {
        return Signature.Equals(other);
    }

    public string Signature { get; } = "person:buildings";
    public string Description { get; } = "Отобразить список всех зданий, акрепленных за определенным сотрудником";

    private readonly IDatabase _db;

    public CommandBuildingsPerson(IDatabase db)
    {
        _db = db;
    }
    
    public void Run()
    {
        Console.Write("Идентификатор ответсвенного лица: ");
        string? ownerIdRaw = Console.ReadLine();

        if (string.IsNullOrEmpty(ownerIdRaw))
        {
            Console.WriteLine("Введена пустая строка");
            return;
        }

        int ownerId = int.Parse(ownerIdRaw);

        Person? person = _db.SelectPersonById(ownerId);
        
        if (person is null)
        {
            Console.WriteLine($"В системе не зарегестрирован работник с идентификатором {ownerId}");
            return;
        }
        
        Table table = new Table
            {
                Width = 200,
            };
            
            table.Rows.Add(new Row
            {
                Cells = new List<Cell>
                {
                    new Cell
                    {
                        Text = "Информация о зданиях",
                        TextAlign = Cell.TextAlignEnum.Center
                    }
                }
            });
            
            table.Rows.Add(new Row
            {
                Cells = new List<Cell>
                {
                    new Cell
                    {
                        Text = "ID",
                        FixedWidth = 4,
                        WidthMode = Cell.WidthModeEnum.Fixed,
                    },
                    new Cell
                    {
                        Text = "Адрес",
                        TextAlign = Cell.TextAlignEnum.Center,
                    },
                    new Cell
                    {
                        Text = "Срок амортизации",
                        TextAlign = Cell.TextAlignEnum.Center,
                    },
                    new Cell
                    {
                        Text = "Дата постройки",
                        TextAlign = Cell.TextAlignEnum.Center,
                    },
                    new Cell
                    {
                        Text = "Ответсвенное лицо",
                        FixedWidth = 40,
                        TextAlign = Cell.TextAlignEnum.Center,
                        WidthMode = Cell.WidthModeEnum.Fixed,
                    },
                }
            });

            foreach (Building building in person.GetBuildings(_db))
            {
                table.Rows.Add(new Row
                {
                    Cells = new List<Cell>
                    {
                        new Cell
                        {
                            Text = building.Id.ToString(),
                            FixedWidth = 4,
                            WidthMode = Cell.WidthModeEnum.Fixed,
                        },
                        new Cell
                        {
                            Text = building.Adress,
                        },
                        new Cell
                        {
                            Text = $"{building.DeprecationPeriod} лет",
                        },
                        new Cell
                        {
                            Text = building.StartDate.ToString("dd.MM.yyyy"),
                        },
                        new Cell
                        {
                            Text = _db.SelectPersonById(building.OwnerId)!.Fio,
                            FixedWidth = 40,
                            WidthMode = Cell.WidthModeEnum.Fixed,
                        },
                    }
                }); 
            }
            
            Consoler.PrintTable(table);
    }
}