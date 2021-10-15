namespace lab7
{
    public class Cashier : Employee
    {
        public string Qualification { get; set; }

        public override string GetFullName()
        {
            return base.GetFullName() + " | " + Qualification;
        }
    }
}