using System;
// ReSharper disable SuggestVarOrType_BuiltInTypes

namespace lab1_task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите стороны прямоугольника, а программа посчитает площадь и периметр :)");
            
            Console.Write("a: ");
            string a = Console.ReadLine();
            
            long x;
            
            try
            {
                x = long.Parse(a!);
            }
            catch (FormatException)
            {
                Console.WriteLine($"Не удалось распознать число \"{a}\"");
                return;
            }
            
            Console.Write("b: ");
            string b = Console.ReadLine();

            long y;
            
            try
            {
                y = long.Parse(b!);
            }
            catch (FormatException)
            {
                Console.WriteLine($"Не удалось распознать число \"{b}\"");
                return;
            }

            

            Console.WriteLine($"Периметр: {x*2+y*2}");
            Console.WriteLine($"Площадь: {x*y}");
            
        }
    }
}