namespace lab2._2._3.Classes;

public delegate void ProtectionFallEventHandler(object sender, ProtectionFailEventArgs e);

public class Skyda
{
    public int KnownFailedProtectionLayerNumber { get; set; }
    public ProtectionSystem ProtectionSystem { get; set; }
    public event ProtectionFallEventHandler ProtectionFallHandler; 

    public Skyda(ProtectionSystem protectionSystem)
    {
        ProtectionSystem = protectionSystem;
    }
    
    public virtual void Attack()
    {
        ProtectionSystem.GetAttack();
    }

    public virtual void NotifyProtectionFall()
    {
        if (ProtectionSystem.FailedProtectionLayerNumber > KnownFailedProtectionLayerNumber)
        {
            ProtectionFallHandler.Invoke(this, new ProtectionFailEventArgs
            {
                System = ProtectionSystem,
                FailedProtectionLayersNumber = ProtectionSystem.FailedProtectionLayerNumber 
            });
            KnownFailedProtectionLayerNumber = ProtectionSystem.FailedProtectionLayerNumber;
        }
    }
}