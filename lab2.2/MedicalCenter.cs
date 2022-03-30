namespace lab2._2;

public delegate void AlarmHandler(object sender, AlarmEventArgs args);

public class MedicalCenter
{
    public event AlarmHandler Alarm;

    public void OnAlarm(Student student, Instityte instityte)
    {
        Alarm(this, new AlarmEventArgs(student, instityte));
    }
}