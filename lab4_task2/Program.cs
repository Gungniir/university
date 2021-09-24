using System;

namespace lab4_task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите N");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] ar = new int[n];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Введите {i + 1} число");
                ar[i] = Convert.ToInt32(Console.ReadLine());
            }

            int index = 0, value = 0;

            for (int i = 0; i < n; i++)
            {
                if (ar[i] >= 0)
                {
                    continue;
                }

                index = i;
                value = ar[i];
            }

            if (value == 0)
            {
                Console.WriteLine("Отрицательных чисел в массиве нет");
                return;
            } 

            Console.WriteLine($"Последнее отрицательно число ({value}) стоит в массиве под индексом {index}");
        }
    }
}