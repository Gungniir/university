using System.Globalization;
using test1.consoler;

namespace test1.task3;

public class CommandDeprecatedBuildings: ICommand
{
    public bool Equals(string? other)
    {
        return Signature.Equals(other);
    }

    public string Signature { get; } = "building:deprecated";
    public string Description { get; } = "Отобразить список всех зданий, у которых прошёл срок амортизации";

    private readonly IDatabase _db;

    public CommandDeprecatedBuildings(IDatabase db)
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
                        Text = "Стоимость",
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

            foreach (Building building in _db.SelectDeprecatedBuildings())
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
                            Text = building.StartPrice.ToString(CultureInfo.CurrentCulture),
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