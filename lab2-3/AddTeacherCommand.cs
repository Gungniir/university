using coder;

namespace lab2_3;

public class AddTeacherCommand : CommandWithFlags
{
    public override string Signature => "add";
    public override string Description => "Добавить преподавателя";

    public override string HelpPage =>
        "add - команда для добавления нового препоадавателя\n" +
        "-r случайные данные\n" +
        "--help вывести это меню";

    public List<Teacher> Teachers { get; set; }

    public AddTeacherCommand(List<Teacher> teachers)
    {
        Teachers = teachers;
    }

    private readonly string[] _names =
    {
        "Курусь Владимир Ильич", "Викторова Татьяна Денисовна", "Иванов Иван Иванович",
        "Калинин Константин Александрович", "Арляпов Иван Афанасьевич"
    };

    private readonly string[] _insts = {"ИКИТ", "ПИ"};
    private readonly string[] _services = {"Discord", "Zoom", "WebinarSFU"};

    public override void Run(string command)
    {
        ParseFlags(command);

        if (HasFlag("help"))
        {
            Console.WriteLine(HelpPage);
            return;
        }

        if (HasFlag("r"))
        {
            Random random = new Random(DateTime.Now.Millisecond);
            Teacher teacher = new Teacher
            {
                Name = _names[random.Next(_names.Length)],
                Institute = _insts[random.Next(_insts.Length)],
                FavouriteService = _services[random.Next(_services.Length)],
            };
            teacher.FavouriteServiceColor = GetColorForService(teacher.FavouriteService);

            Console.WriteLine($"Имя: {teacher.Name}");
            Console.WriteLine($"Institute: {teacher.Institute}");
            Console.WriteLine($"FavouriteService: {teacher.FavouriteService}");

            if (Teachers.Find(teacher1 => teacher1.Name.Equals(teacher.Name)) != null)
            {
                Console.WriteLine("Такой преподаватель уже есть");
                return;
            }

            Teachers.Add(teacher);
        }
        else
        {
            Console.WriteLine("Введите имя преподавателя");
            string name = Console.ReadLine()!;

            if (Teachers.Find(teacher => teacher.Name.Equals(name)) != null)
            {
                Console.WriteLine("Такой преподаватель уже есть");
                return;
            }

            Console.WriteLine("Введите название института");
            string inst = Console.ReadLine()!;

            Console.WriteLine("Введите любимую платформу");
            string favo = Console.ReadLine()!;

            Teachers.Add(new Teacher
            {
                Name = name,
                Institute = inst,
                FavouriteService = favo,
                FavouriteServiceColor = GetColorForService(favo)
            });
        }
    }

    private ConsoleColor GetColorForService(string name)
    {
        int index = 0;

        foreach (var ch in name)
        {
            index = ch.GetHashCode();
        }

        var values = typeof(ConsoleColor).GetEnumValues();

        index %= values.Length;

        return (ConsoleColor) values.GetValue(index)!;
    }
}