namespace lab9.classes
{
    public class Teacher: Human
    {
        public static Teacher Generate(Faker.Sex sex = Faker.Sex.Undefined)
        {
            return new Teacher
            {
                Name = Faker.FullName(sex),
                IsHaveMask = Faker.Bool(),
                IsHaveQR = Faker.Bool(),
            };
        }
    }
}