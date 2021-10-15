using System;

namespace lab6
{
    public class Postman : Employee
    {
        public override int WorkTime()
        {
            return DateTime.Now.Subtract(DateOfEmployment).Days / 365;
        }

        public override string WhatYouDo()
        {
            return "Разношу почту, не мешайте";
        }
    }
}