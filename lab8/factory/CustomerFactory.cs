using System;
using System.Collections.Generic;

namespace lab8.factory
{
    public class CustomerFactory
    {
        private int _count = 0;
        private static readonly string[] Names = {"Иван", "Никита", "Андрей", "Александр", "Денис", "Александра", "Елизавета", "Виолетта", "Евгения"};
        
        private static Customer State()
        {
            Random random = new Random();
            Customer customer = new Customer
            {
                FIO = Names[random.Next(Names.Length)]
            };

            return customer;
        }

        public CustomerFactory Count(int count)
        {
            _count = count;
            
            return this;
        }

        public static Customer MakeOne()
        {
            return State();
        }

        public List<Customer> Make()
        {
            List<Customer> customers = new List<Customer>();
            for (int i = 0; i < _count; i++)
            {
                customers.Add(MakeOne());
            }

            return customers;
        }
    }
}