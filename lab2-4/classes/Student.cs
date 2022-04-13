using lab2_4.attributes;

namespace lab2_4.classes;

public class Student
{
    public string Name { get; set; } = "";
    public string Institute { get; set; } = "";
    public DateTime DateOfBirth { get; set; }
    [NotPrintable] public string Inn = "";
}