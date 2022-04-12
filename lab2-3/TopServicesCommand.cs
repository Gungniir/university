using coder;
using tabler;

namespace lab2_3;

public class TopServicesCommand : CommandWithFlags
{
    public override string Signature => "top";
    public override string Description => "Отобразить топ-3 любимых сервисов";

    public override string HelpPage =>
        "top - команда для отображения любимых севрисов\n" +
        "--help вывести это меню";

    public List<Teacher> Teachers { get; set; }

    public TopServicesCommand(List<Teacher> teachers)
    {
        Teachers = teachers;
    }

    public override void Run(string command)
    {
        ParseFlags(command);

        if (HasFlag("help"))
        {
            Console.WriteLine(HelpPage);
            return;
        }

        Table table = new();

        table.AddRow(new List<Cell>
        {
            new Cell
            {
                Text = "Место",
                ForegroundColor = ConsoleColor.Cyan,
                TextAlign = TextAlign.Center,
                Width = 5
            },
            new Cell
            {
                Text = "Название",
                ForegroundColor = ConsoleColor.Cyan,
                TextAlign = TextAlign.Center,
            },
            new Cell
            {
                Text = "Количество использований",
                ForegroundColor = ConsoleColor.Cyan,
                TextAlign = TextAlign.Center,
                Width = 24
            },
        });

        var result = Teachers.GroupBy(teacher => teacher.FavouriteService)
            .Select(teachers => (teachers.Key, teachers.Count(), teachers.First().FavouriteServiceColor))
            .OrderByDescending(teachers => teachers.Item2).Take(3).ToList();

        for (int i = 0; i < result.Count; i++)
        {
            var tuple = result[i];

            table.AddRow(new List<Cell>
            {
                new Cell
                {
                    Text = i.ToString(),
                    Width = 5
                },
                new Cell
                {
                    Text = "[" + tuple.Key + "]",
                    ForegroundColor = tuple.FavouriteServiceColor
                },
                new Cell
                {
                    Text = tuple.Item2.ToString(),
                    Width = 24
                },
            });
        }

        table.Print();
    }
}