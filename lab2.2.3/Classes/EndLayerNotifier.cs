using lab2._2._3.Interfaces;

namespace lab2._2._3.Classes;

public class EndLayerNotifier : IReactProtectionFail
{
    public int LayerReactorNumber { get; set; }
    public string Message { get; set; }

    public EndLayerNotifier(int layer)
    {
        LayerReactorNumber = layer;
    }
    
    public void OnProtectionFail(object sender, ProtectionFailEventArgs e)
    {
        if (LayerReactorNumber != e.FailedProtectionLayersNumber)
        {
            return;
        }
        
        Message = $"Все слои в системе {e.System.Title} были нарушены в течении {(e.System.Date - DateTime.Today).Days} дней";
    }
}