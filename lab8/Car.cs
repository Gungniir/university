using lab8.factory;

namespace lab8
{
    public class Car
    {
        public int Number { get; set; }
        private Engine Engine { get; } = new();

        public Car(int number, int size)
        {
            Number = number;
            Engine.Size = size;
        }

        public int PedalSize()
        {
            return Engine.Size;
        }

        public static CarFactory Factory()
        {
            return new CarFactory();
        }
    }
}