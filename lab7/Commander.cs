using System;
using System.Collections.Generic;
using Microsoft.VisualBasic;

namespace lab7
{
    public class Commander
    {
        public Commander()
        {
            Employees = new List<Employee>();
            TomorrowEmployees = new List<Employee>();
        }
        
        public List<Employee> Employees { get; set; }
        public List<Employee> TomorrowEmployees { get; set; }

        public void PrintTeam()
        {
            _printHr();
            _printMiddle("Завтрашняя смена");
            _printHr();
            foreach (Employee employee in TomorrowEmployees)
            {
                _print(employee.GetFullName());
            }
            _printHr();
        }

        public static void PrintBage(Cashier cashier)
        {
            _printHr();
            _printMiddle("Кассир Командора");
            _printHr();
            _print(cashier.GetFullName());
            _printHr();
        }

        public void PrintBageForAllCashiers()
        {
            foreach (Employee employee in Employees)
            {
                if (employee is not Cashier)
                {
                    continue;
                }
                
                _printHr();
                _printMiddle("Кассир Командора");
                _printHr();
                _print(employee.GetFullName());
                _printHr();

                Console.WriteLine();
            }
        }

        private static void _printHr()
        {
            Console.WriteLine("+" + new string('-', 50) + "+");
        }

        private static void _print(string text)
        {
            Console.WriteLine("| " + text + new string(' ', 50-2-text.Length) + " |");
        }

        private static void _printMiddle(string text)
        {
            Console.WriteLine("| " + new string(' ', (50-2-text.Length)/2) + text + new string(' ', (50-2-text.Length)/2 + (50-2-text.Length)%2) + " |");
        }
    }
}