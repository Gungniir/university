using lab2._2._3.Interfaces;

namespace lab2._2._3.Classes;

public class BasicLayerNotifier : IReactProtectionFail
{
    public int LayerReactorNumber { get; set; }
    public string Message { get; set; }

    public BasicLayerNotifier(int layer)
    {
        LayerReactorNumber = layer;
    }
    
    public void OnProtectionFail(object sender, ProtectionFailEventArgs e)
    {
        if (LayerReactorNumber != e.FailedProtectionLayersNumber)
        {
            return;
        }
        
        Message = $"{e.System.Date.ToShortDateString()}: Слой защиты {e.FailedProtectionLayersNumber} в системе {e.System.Title} был нарушен";
    }
}