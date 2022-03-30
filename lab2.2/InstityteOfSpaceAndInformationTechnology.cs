namespace lab2._2;

public class InstityteOfSpaceAndInformationTechnology : Instityte
{
    public override void MedicalCenter_Alarm(object sender, AlarmEventArgs args)
    {
        Console.WriteLine(
            $"\nК нам в ИКИТ поступила информация, что {args.StudentName} ({args.GroupName}) из {args.InstityteName} заболел");

        if (!args.InstityteName.Equals(GetType().Name))
        {
            Console.WriteLine(
                "Так как этот студент далеко (не в нашем институте), то делаем вид, что ничего не произошло :)");
            return;
        }

        Console.WriteLine("Кошмар!!! Тревога!!! Заболел один из наших!!! Все переходим на дистант!");

        foreach (Student student in Students)
        {
            student.IsStudyDistance = true;
            Console.WriteLine($"Студент {student.Name} ({student.GroupName}) - на дистант!");
        }

        Console.WriteLine("Фух, вроде, никого не пропустили...");
    }
}