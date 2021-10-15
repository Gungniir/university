using System;
using System.Collections.Generic;
using Microsoft.VisualBasic;

namespace lab6
{
    public class PostOffice
    {
        public List<Employee> Employees { get; set; }

        public void Poll()
        {
            foreach (Employee employee in Employees)
            {
                _printHr();
                _print($"Работник: {employee.Name}");
                _printHr();
                _print("Как вас зовут?");
                _print(employee.Say());
                _printHr();
                _print("Что вы делаете?");
                _print(employee.WhatYouDo());
                _printHr();
                _print("И давно вы тут работаете?");
                string n = employee switch
                {
                    Cashier => "д.",
                    Operator => "м.",
                    _ => "г."
                };
                _print($"{employee.WorkTime()} {n}");
                _printHr();
                
                Console.WriteLine();
            }
        }

        private void _printHr()
        {
            Console.WriteLine("+" + new string('-', 50) + "+");
        }

        private void _print(string text)
        {
            Console.WriteLine("| " + text + new string(' ', 50-2-text.Length) + " |");
        }
    }
}