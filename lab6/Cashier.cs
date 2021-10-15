using System;

namespace lab6
{
    public class Cashier : Employee
    {
        public override int WorkTime()
        {
            return DateTime.Now.Subtract(DateOfEmployment).Days;
        }

        public override string WhatYouDo()
        {
            return "Пополняю транспортные карты";
        }
    }
}