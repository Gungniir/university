using lab9.interfaces;

namespace lab9.classes
{
    public class Dog: Animal, ICanPutOnMask
    {
        public bool IsHaveMask { get; set; }
        
        public static Dog Generate()
        {
            return new Dog
            {
                Name = Faker.FullName(),
                IsHaveMask = Faker.Bool()
            };
        }
    }
}