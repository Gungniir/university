using test1;
using test1.consoler;

List<ICode> programs = new() {new test1.task1.Code(), new test1.task2.Code(), new test1.task3.Code()};

while (true)
{
    Table table = new();
    table.Width = 200;
    table.Rows.Add(new Row
    {
        Cells = new List<Cell>
        {
            new Cell
            {
                FixedWidth = 3,
                WidthMode = Cell.WidthModeEnum.Fixed,
                Text = "№"
            },
            new Cell
            {
                FixedWidth = 30,
                WidthMode = Cell.WidthModeEnum.Fixed,
                Text = "Навзание"
            },
            new Cell
            {
                Text = "Описание"
            },
        }
    });

    for (var index = 0; index < programs.Count; index++)
    {
        ICode program = programs[index];
        table.Rows.Add(new Row
        {
            Cells = new List<Cell>
            {
                new Cell
                {
                    FixedWidth = 3,
                    WidthMode = Cell.WidthModeEnum.Fixed,
                    Text = $"{index + 1}"
                },
                new Cell
                {
                    FixedWidth = 30,
                    WidthMode = Cell.WidthModeEnum.Fixed,
                    Text = program.Name
                },
                new Cell
                {
                    Text = program.Description
                },
            }
        });
    }

    Consoler.PrintTable(table);

    Console.Write("№");
    int id = int.Parse(Console.ReadLine()!) - 1;

    programs[id].Run();
}