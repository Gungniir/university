using System;
using System.Collections.Generic;

namespace lab8.factory
{
    public class FactoryAFFactory
    {
        private int _count = 0;

        private static FactoryAF State()
        {
            Random random = new Random();
            FactoryAF factory = new FactoryAF
            {
                Customers = Customer.Factory().Count(random.Next(5,20)).Make()
            };

            return factory;
        }

        public FactoryAFFactory Count(int count)
        {
            _count = count;
            
            return this;
        }

        public static FactoryAF MakeOne()
        {
            return State();
        }

        public List<FactoryAF> Make()
        {
            List<FactoryAF> factories = new List<FactoryAF>();
            for (int i = 0; i < _count; i++)
            {
                factories.Add(MakeOne());
            }

            return factories;
        }
    }
}