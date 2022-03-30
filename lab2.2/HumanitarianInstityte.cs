namespace lab2._2;

public class HumanitarianInstityte : Instityte
{
    public override void MedicalCenter_Alarm(object sender, AlarmEventArgs args)
    {
        Console.WriteLine(
            $"\nК нам в ГИ поступила информация, что {args.StudentName} ({args.GroupName}) из {args.InstityteName} заболел");

        if (!args.InstityteName.Equals(GetType().Name))
        {
            Console.WriteLine(
                "Так как этот студент далеко (не в нашем институте), то воспользуемся случаем и переманим по телефону парочку студентов у них :)");
            return;
        }

        Console.WriteLine(
            "Ох... заболел один из наших... Давайте всё замнём? Всё равно все студенты любят ходить на очные пары, верно?");

        foreach (Student student in Students.FindAll(student =>
                     student.Name.Equals(args.StudentName) && student.GroupName.Equals(args.GroupName)))
        {
            student.IsStudyDistance = true;
            Console.WriteLine($"Студент {student.Name} ({student.GroupName}) - на дистант!");
        }

        Console.WriteLine("Так, а теперь возвращаемся к учёбе");
    }
}