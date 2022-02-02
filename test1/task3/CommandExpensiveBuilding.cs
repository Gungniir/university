using System.Globalization;
using test1.consoler;

namespace test1.task3;

public class CommandExpensiveBuilding : ICommand
{
    public bool Equals(string? other)
    {
        return Signature.Equals(other);
    }

    public string Signature { get; } = "building:expensive";
    public string Description { get; } = "Вывести самое дорого здание (без учёта амортизации)";

    private readonly IDatabase _db;

    public CommandExpensiveBuilding(IDatabase db)
    {
        _db = db;
    }

    public void Run()
    {
        Table table = new Table
        {
            Width = 200,
        };


        Building? building = _db.SelectExpensiveBuilding();


        if (building is null)
        {
            Console.WriteLine("В системе не задано ни одно здание");
            return;
        }

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

        Consoler.PrintTable(table);
    }
}