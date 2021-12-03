using System;
using System.Collections.Generic;

namespace lab8.factory
{
    public class CarFactory
    {
        private int _count = 0;
        
        private static Car State()
        {
            Random random = new();
            Car car = new(random.Next(int.MaxValue), random.Next(100));
            
            return car;
        }

        public CarFactory Count(int count)
        {
            _count = count;
            
            return this;
        }

        public static Car MakeOne()
        {
            return State();
        }

        public List<Car> Make()
        {
            List<Car> cars = new();
            for (int i = 0; i < _count; i++)
            {
                cars.Add(MakeOne());
            }

            return cars;
        }
    }
}