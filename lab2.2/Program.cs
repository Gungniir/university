// See https://aka.ms/new-console-template for more information

using lab2._2;
using lab2._2.commands;

MedicalCenter medicalCenter = new();
InstityteOfSpaceAndInformationTechnology isit = new();
HumanitarianInstityte hi = new();
MilitaryEngineeringInstityte mei = new();

void PrintError(string s)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"ERROR: {s}");
    Console.ResetColor();
}

void PrintWarn(string s)
{
    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.WriteLine($"WARN: {s}");
    Console.ResetColor();
}

void PrintInfo(string s)
{
    Console.ForegroundColor = ConsoleColor.DarkCyan;
    Console.WriteLine($"INFO: {s}");
    Console.ResetColor();
}

for (int i = 0; i < 20 * 6; i++)
{
    var student = Student.Random();

    switch (student.GroupName.Substring(0, 2))
    {
        case "КИ":
            isit.Students.Add(student);
            break;
        case "ГИ":
            hi.Students.Add(student);
            break;
        case "ВИ":
            mei.Students.Add(student);
            break;
        default:
            PrintError(
                $"Студент {student.Name} попал в группу {student.GroupName}, которая не принадлежит ни одниму из институтов");
            break;
    }
}

isit.SortStudents();
hi.SortStudents();
mei.SortStudents();

List<Instityte> institytes = new() {isit, hi, mei};

medicalCenter.Alarm += isit.MedicalCenter_Alarm;
medicalCenter.Alarm += hi.MedicalCenter_Alarm;
medicalCenter.Alarm += mei.MedicalCenter_Alarm;

CommandsContainer.Commands = new List<ICommand>
    {new InfectRandomStudent(institytes, medicalCenter), new ListStudents(institytes)};
CommandsContainer.Serve();