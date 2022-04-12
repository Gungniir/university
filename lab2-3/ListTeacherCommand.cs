using coder;
using tabler;

namespace lab2_3;

public class ListTeacherCommand : CommandWithFlags
{
    public override string Signature => "list";
    public override string Description => "Отобразить список проподавателей";

    public override string HelpPage =>
        "add - команда для добавления нового препоадавателя\n" +
        "-r случайные данные\n" +
        "--help вывести это меню";

    public List<Teacher> Teachers { get; set; }

    public ListTeacherCommand(List<Teacher> teachers)
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
                Text = "ID",
                ForegroundColor = ConsoleColor.Cyan,
                TextAlign = TextAlign.Center,
                Width = 2
            },
            new Cell
            {
                Text = "ФИО",
                ForegroundColor = ConsoleColor.Cyan,
                TextAlign = TextAlign.Center,
            },
            new Cell
            {
                Text = "Институт",
                ForegroundColor = ConsoleColor.Cyan,
                TextAlign = TextAlign.Center,
                Width = 8
            },
            new Cell
            {
                Text = "Сервис",
                ForegroundColor = ConsoleColor.Cyan,
                TextAlign = TextAlign.Center,
                Width = 15
            },
        });

        for (var index = 0; index < Teachers.Count; index++)
        {
            Teacher teacher = Teachers[index];
            table.AddRow(new List<Cell>
            {
                new Cell
                {
                    Text = index.ToString(),
                    Width = 2
                },
                new Cell
                {
                    Text = teacher.ShortName(),
                },
                new Cell
                {
                    Text = teacher.Institute,
                    Width = 8
                },
                new Cell
                {
                    Text = "[" + teacher.FavouriteService + "]",
                    ForegroundColor = teacher.FavouriteServiceColor,
                    Width = 15
                }
            });
        }

        table.Print();
    }
}