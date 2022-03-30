namespace lab2._2;

public class AlarmEventArgs : EventArgs
{
    public string InstityteName { get; init; }
    public string GroupName { get; init; }
    public string StudentName { get; init; }

    public AlarmEventArgs(Student student, Instityte instityte)
    {
        StudentName = student.Name;
        GroupName = student.GroupName;
        InstityteName = instityte.GetType().Name;
    }
}