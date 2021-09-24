using System;
using System.Collections.Generic;
using System.Linq;

namespace lab4_task1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Введите N");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] ar = new int[n];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Введите {i + 1} число");
                ar[i] = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("Введите P");
            int p = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите Q");
            int q = Convert.ToInt32(Console.ReadLine());

            int answer = 0;

            foreach (int item in ar)
            {
                if (item > p && item < q)
                {
                    answer++;
                }
            }

            Console.WriteLine($"Итого в массиве лежит {answer} чисел между p и q");
        }
    }
}