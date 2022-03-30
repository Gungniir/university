namespace lab2._2;

public class MilitaryEngineeringInstityte : Instityte
{
    public override void MedicalCenter_Alarm(object sender, AlarmEventArgs args)
    {
        Console.WriteLine(
            $"\nК нам в ВИИ поступила информация, что {args.StudentName} ({args.GroupName}) из {args.InstityteName} заболел");

        if (!args.InstityteName.Equals(GetType().Name))
        {
            Console.WriteLine(
                "Так как этот студент далеко (не в нашем институте), то расскажем всем, что у нас в ВИИ никто не болеет, так как все крыпкие :)");
            return;
        }

        Console.WriteLine("Заболел один из наших... Отчислить его! Нельзя? Ладно... Переведём всю группу на дистант");

        foreach (Student student in Students.FindAll(student => student.GroupName.Equals(args.GroupName)))
        {
            student.IsStudyDistance = true;
            Console.WriteLine($"Студент {student.Name} ({student.GroupName}) - на дистант!");
        }

        Console.WriteLine("Так, а теперь возвращаемся к учёбе");
    }
}