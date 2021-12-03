using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using lab8.factory;

namespace lab8
{
    public class FactoryAF
    {
        private List<Car> Cars { get; set; } = new();
        public List<Customer> Customers { get; set; } = new();
        public List<Customer> Clients { get; } = new();

        public void AddCar(Car car)
        {
            Cars.Add(car);
        }

        public void SaleCar()
        {
            foreach (Car car in Cars)
            {
                if (Customers.Count == 0)
                {
                    break;
                }
                
                Customers[0].Car = car;
                Clients.Add(Customers[0]);
                Customers.RemoveAt(0);
            }
            
            Cars = new List<Car>();
        }

        public static FactoryAFFactory Factory()
        {
            return new FactoryAFFactory();
        }
    }
}