using lab9.interfaces;

namespace lab9.classes
{
    public class Student: Human
    {
        public static Student Generate()
        {
            return new Student
            {
                Name = Faker.FullName(),
                IsHaveMask = Faker.Bool(),
                IsHaveQR = Faker.Bool(),
            };
        }
    }
}