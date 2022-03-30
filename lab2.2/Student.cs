namespace lab2._2;

public class Student
{
    public static Student Random()
    {
        var random = new Random((int) (DateTime.Now.Ticks));
        string[] names = new[]
            {"Пупсень", "Вупсень", "Ивасинь", "Денисень", "Алексень", "Дианисень", "Вовасень", "Лешасень", "Васень"};
        string[] groups = new[] {"КИ99-20Б", "ВИ99-20Б", "ГИ99-20Б", "КИ99-21Б", "ВИ99-21Б", "ГИ99-21Б", "Отчислен"};

        return new Student
        {
            Name = names[random.Next(names.Length)],
            GroupName = groups[random.Next(groups.Length)],
            IsStudyDistance = false
        };
    }

    public string Name { get; set; } = "";
    public string GroupName { get; set; } = "";
    public bool IsStudyDistance { get; set; } = false;
}