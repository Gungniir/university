namespace lab2._2._3.Classes;

public class ProtectionSystem
{
    public string Title { get; set; } = "";
    public DateTime Date { get; set; } = DateTime.Now;
    public int ProtectionLayerNumber { get; set; }
    public int FailedProtectionLayerNumber { get; set; }
    
    public ProtectionSystem(string title, int protectionLayerNumber)
    {
        Title = title;
        ProtectionLayerNumber = protectionLayerNumber;
    }
    
    private readonly Random _random = new Random(DateTime.Now.Millisecond);

    public virtual bool ProtectionCheck()
    {
        Date = Date.Add(TimeSpan.FromDays(1));
        return FailedProtectionLayerNumber < ProtectionLayerNumber;
    }

    public virtual  void GetAttack()
    {
        if (FailedProtectionLayerNumber >= ProtectionLayerNumber)
        {
            return;
        }
        
        FailedProtectionLayerNumber += _random.Next(0, 2);
    }
}