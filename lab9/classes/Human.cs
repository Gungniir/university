using lab9.interfaces;

namespace lab9.classes
{
    public class Human: IVisitor, ICanHaveQR, ICanPutOnMask, ICanDisinfectHand
    {
        public string Name { get; set; }
        public bool IsHaveQR { get; set; } = false;
        public bool IsHaveMask { get; set; } = false;
    }
}