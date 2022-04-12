namespace lab2_3;

public class Teacher
{
    public string Name = "";
    public string Institute = "";
    public string FavouriteService = "";
    public ConsoleColor FavouriteServiceColor = ConsoleColor.Green;
}

public static class TeacherExtension
{
    public static string ShortName(this Teacher teacher)
    {
        var names = teacher.Name.Split(' ');
        return names.Length == 3 ? $"{names[0]} {names[1][0]}. {names[2][0]}." : teacher.Name;
    }
}