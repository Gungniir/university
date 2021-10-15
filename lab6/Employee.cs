using System;

namespace lab6
{
    public class Employee
    {
        public string Name { get; set; }
        public DateTime DateOfEmployment { get; set; }

        public string Say()
        {
            return Name;
        }

        public virtual int WorkTime()
        {
            return 0;
        }

        public virtual string WhatYouDo()
        {
            return "Работаю";
        }
    }
}