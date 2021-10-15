using System;

namespace lab6
{
    public class Operator : Employee
    {
        public override int WorkTime()
        {
            return DateTime.Now.Subtract(DateOfEmployment).Days / 30;
        }

        public override string WhatYouDo()
        {
            return "Ищу посылку";
        }
    }
}