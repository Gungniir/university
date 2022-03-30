using lab2._2.consoler;

namespace lab2._2.commands;

public class InfectRandomStudent : ICommand
{
    public string Signature { get; } = "infect:student";
    public string Description { get; } = "Заразить случайного студента коронавирусом";
    public List<Instityte> Institytes { get; }
    public MedicalCenter MedicalCenter { get; }

    public InfectRandomStudent(List<Instityte> institytes, MedicalCenter medicalCenter)
    {
        Institytes = institytes;
        MedicalCenter = medicalCenter;
    }

    public void Run()
    {
        Random random = new Random((int) (DateTime.Now.Ticks));

        Instityte instityte = Institytes[random.Next(Institytes.Count)];
        Student student = instityte.Students[random.Next(instityte.Students.Count)];

        Console.WriteLine(
            $"Заразили студента {student.Name} из группы {student.GroupName} из института {instityte.GetType().Name}");
        Console.WriteLine("Рассылаем уведомления через медцентр...");

        MedicalCenter.OnAlarm(student, instityte);

        Console.WriteLine("Все уведомления были разосланы");
    }
}