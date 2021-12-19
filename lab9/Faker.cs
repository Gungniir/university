using System;

namespace lab9
{
    
    public static class Faker
    {
        public enum Sex
        {
            Undefined,
            Male,
            Female,
        }

        private static readonly Random Random = new();
        
        private static readonly string[] NamesMale = new[] {"Владимир", "Алексей", "Иван", "Денис", "Илья", "Евгений", "Афанасий", "Владислав", "Максим", "Сергей", "Игорь", "Павел", "Егор", "Ярослав"};
        private static readonly string[] LastNamesMale = new[] {"Курусь", "Навальный", "Ванюшкин", "Викторов", "Арляпов", "Казимирский", "Ситников", "Яковлев", "Голосов", "Байкалов", "Матюков", "Белоусов", "Кибалин", "Малютин"};

        private static readonly string[] NamesFemale = new[] {"Татьяна", "Светлана", "Евгения", "Ирина", "Оксана", "Диана", "Василиса", "Елизавета", "Анастасия", "Екатерина", "Юлия", "Ольга", "Нина"};
        private static readonly string[] LastNamesFemale = new[] {"Викторова", "Кириенко", "Кусь", "Калинина", "Курусь", "Арляпова", "Казимирская", "Лиженкина", "Визул", "Малютина", "Голосова", "Щербакова", "Навальная"};

        public static string FullName(Sex sex = Sex.Undefined)
        {
            if (sex == Sex.Undefined)
            {
                sex = Random.Next(0, 2) == 0 ? Sex.Male : Sex.Female;
            }

            switch (sex)
            {
                case Sex.Male:
                    return NamesMale[Random.Next(NamesMale.Length)] + ' ' +
                           LastNamesMale[Random.Next(LastNamesMale.Length)];
                default:
                    return NamesFemale[Random.Next(NamesFemale.Length)] + ' ' +
                           LastNamesFemale[Random.Next(LastNamesFemale.Length)];
            }
        }

        public static bool Bool()
        {
            return Random.Next(2) == 1;
        }
    }
}