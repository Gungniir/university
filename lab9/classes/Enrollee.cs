namespace lab9.classes
{
    public class Enrollee: Human
    {
        public static Enrollee Generate(Faker.Sex sex = Faker.Sex.Undefined)
        {
            return new Enrollee
            {
                Name = Faker.FullName(sex),
                IsHaveMask = Faker.Bool(),
                IsHaveQR = Faker.Bool(),
            };
        }
    }
}