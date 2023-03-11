namespace lab2._2._3.Classes;

public class ProtectionFailEventArgs : EventArgs
{
    public int FailedProtectionLayersNumber { get; init; }
    public ProtectionSystem System { get; init; }
}