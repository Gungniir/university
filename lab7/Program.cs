using System;

namespace lab7
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = {"Иван", "Владимир", "Михаил", "Алексей", "Кирилл", "Матвей", "Костя", "Виктор", "Денис", "Николай", "Александр"};
            string[] surnames = {"Ванюшкин", "Курусь", "Кибалин", "Викторов", "Нагель", "Казимирский", "Поздняков", "Пенский", "Калинин", "Ткачев", "Скурихин"};
            string[] qualifications = {"стажер", "кассир", "старший кассир"};

            Commander commander = new Commander();
            
            Random random = new Random();
            for (int i = 0; i < 8; i++)
            {
                Cashier cashier = new Cashier();
                cashier.Qualification = qualifications[random.Next(qualifications.Length)];

                cashier.FirstName = names[random.Next(names.Length)];
                cashier.LastName = surnames[random.Next(surnames.Length)];
                commander.Employees.Add(cashier);
            }
            
            commander.PrintBageForAllCashiers();
        }
    }
}