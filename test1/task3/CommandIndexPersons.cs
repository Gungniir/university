using test1.consoler;

namespace test1.task3;

public class CommandIndexPersons: ICommand
{
    public bool Equals(string? other)
    {
        return Signature.Equals(other);
    }

    public string Signature { get; } = "person:index";
    public string Description { get; } = "Отобразить список всех сотрудников";

    private readonly IDatabase _db;

    public CommandIndexPersons(IDatabase db)
    {
        _db = db;
    }
    
    public void Run()
    {
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
                        Text = "Информация о сотрудниках",
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
                        Text = "ФИО",
                        TextAlign = Cell.TextAlignEnum.Center,
                    },
                    new Cell
                    {
                        Text = "Должнсть",
                        TextAlign = Cell.TextAlignEnum.Center,
                    },
                    new Cell
                    {
                        Text = "Кол-во закрепленного имущества",
                        FixedWidth = 32,
                        WidthMode = Cell.WidthModeEnum.Fixed,
                    },
                }
            });

            foreach (Person person in _db.SelectAllPersons())
            {
               
                table.Rows.Add(new Row
                {
                    Cells = new List<Cell>
                    {
                        new Cell
                        {
                            Text = person.Id.ToString(),
                            FixedWidth = 4,
                            WidthMode = Cell.WidthModeEnum.Fixed,
                        },
                        new Cell
                        {
                            Text = person.Fio,
                        },
                        new Cell
                        {
                            Text = person.Position,
                        },
                        new Cell
                        {
                            Text = person.GetBuildings(_db).Count.ToString(),
                            FixedWidth = 32,
                            WidthMode = Cell.WidthModeEnum.Fixed,
                        },
                    }
                }); 
            }
            
            Consoler.PrintTable(table);
    }
}