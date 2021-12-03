using lab8.factory;

namespace lab8
{
    public class Customer
    {
        public string FIO { get; set; }
        public Car Car { get; set; }

        public static CustomerFactory Factory()
        {
            return new CustomerFactory();
        }
    }
}