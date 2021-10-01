namespace lab5
{
    public class Cat
    {
        private string _name;
        private int _health = 100;

        public Cat(uint age)
        {
            Age = age;
        }

        public Cat(string name, uint age)
        {
            Name = name;
            Age = age;
        }

        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrEmpty(Name))
                {
                    _name = value;
                }
            }
        }

        public uint Age { get; init; }

        public int Health
        {
            get => _health;
            set => _health = value;
        }

        public string Color => (Health > 0) ? "Зелёный" : "Белый";

        public void Feed(int foodCount)
        {
            Health += foodCount;
        }

        public void Punish(int hit)
        {
            Health -= hit;
        }
    }
}