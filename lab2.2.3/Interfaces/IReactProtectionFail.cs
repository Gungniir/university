using lab2._2._3.Classes;

namespace lab2._2._3.Interfaces;

public interface IReactProtectionFail
{
    public int LayerReactorNumber { get; set; }
    public string Message { get; set; }

    public void Subscribe(Skyda skyda)
    {
        skyda.ProtectionFallHandler += OnProtectionFail;
    }
    
    public void OnProtectionFail(object sender, ProtectionFailEventArgs e);
}