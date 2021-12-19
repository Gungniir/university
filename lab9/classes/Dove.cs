namespace lab9.classes
{
    public class Dove: Animal
    {
        public static Dove Generate()
        {
            return new Dove
            {
                Name = Faker.FullName(),
            };
        }
    }
}