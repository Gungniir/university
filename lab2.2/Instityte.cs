namespace lab2._2;

public abstract class Instityte
{
    public List<Student> Students = new();

    public abstract void MedicalCenter_Alarm(object sender, AlarmEventArgs args);

    public void SortStudents()
    {
        Students.Sort((a, b) =>
            a.GroupName.Equals(b.GroupName)
                ? string.CompareOrdinal(a.Name, b.Name)
                : string.CompareOrdinal(a.GroupName, b.GroupName));
    }
}