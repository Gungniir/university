using lab2._2.consoler;

namespace lab2._2.commands;

public class ListStudents : ICommand
{
    public string Signature { get; } = "list:students";
    public string Description { get; } = "Вывести список всех студентов или конектроног института";
    public List<Instityte> Institytes { get; }

    public ListStudents(List<Instityte> institytes)
    {
        Institytes = institytes;
    }

    public void Run()
    {
        Console.WriteLine("Введите номер института или 0, если хотите вывести информацию о всех студентах");
        Console.WriteLine("Список институтов:");
        for (int i = 0; i < Institytes.Count; i++)
        {
            Console.WriteLine($"{i + 1} - {Institytes[i].GetType().Name}");
        }

        int index;
        Console.Write("> ");
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out index) && index <= Institytes.Count)
            {
                break;
            }

            Console.WriteLine("Неверный номер");
            Console.Write("> ");
        }

        List<Student> students = index == 0
            ? (from instityte in Institytes from student in instityte.Students select student).ToList()
            : Institytes[index - 1].Students;

        Table table = new Table();
        table.AddRow(new List<Cell>
        {
            new Cell
            {
                Text = "Имя студента",
                TextAlign = Cell.TextAlignEnum.Center,
            },
            new Cell
            {
                Text = "Группа",
                TextAlign = Cell.TextAlignEnum.Center,
                FixedWidth = 20,
                WidthMode = Cell.WidthModeEnum.Fixed
            },
            new Cell
            {
                Text = "Дистант",
                TextAlign = Cell.TextAlignEnum.Center,
                FixedWidth = 10,
                WidthMode = Cell.WidthModeEnum.Fixed
            },
        });

        foreach (Student student in students)
        {
            table.AddRow(new List<Cell>
            {
                new Cell
                {
                    Text = student.Name,
                },
                new Cell
                {
                    Text = student.GroupName,
                    FixedWidth = 20,
                    WidthMode = Cell.WidthModeEnum.Fixed
                },
                new Cell
                {
                    Text = student.IsStudyDistance ? "Да" : "Нет",
                    FixedWidth = 10,
                    WidthMode = Cell.WidthModeEnum.Fixed
                },
            });
        }

        Consoler.PrintTable(table);
    }
}