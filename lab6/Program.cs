using System;
using System.Collections.Generic;

namespace lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = {"Иван", "Владимир", "Михаил", "Алексей", "Кирилл", "Матвей", "Костя", "Виктор", "Денис", "Николай", "Александр"};
            string[] surnames = {"Ванюшкин", "Курусь", "Кибалин", "Викторов", "Нагель", "Казимирский", "Поздняков", "Пенский", "Калинин", "Ткачев", "Скурихин"};

            PostOffice postOffice = new PostOffice();
            postOffice.Employees = new List<Employee>();
            
            Random random = new Random();
            for (int i = 0; i < 8; i++)
            {
                Employee employee;
                switch (random.Next(0,2))
                {
                    case 0:
                        employee = new Postman();
                        break;
                    case 1:
                        employee = new Cashier();
                        break;
                    default:
                        employee = new Operator();
                        break;
                }
                employee.Name = names[random.Next(names.Length - 1)] + " " +
                                surnames[random.Next(surnames.Length - 1)];
                employee.DateOfEmployment = new DateTime(random.Next(2000, 2020), random.Next(1,12), random.Next(1,28));
                postOffice.Employees.Add(employee);
            }
            
            postOffice.Poll();
        }
    }
}