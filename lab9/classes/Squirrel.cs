namespace lab9.classes
{
    public class Squirrel: Animal
    {
        public static Squirrel Generate()
        {
            return new Squirrel
            {
                Name = Faker.FullName(),
            };
        }
    }
}