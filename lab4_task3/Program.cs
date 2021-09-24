using System;

namespace lab4_task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите N");
            int n = Convert.ToInt32(Console.ReadLine());
            int[,] ar = new int[n,n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.WriteLine($"Введите число с индексом ({i + 1},{j + 1})");
                    ar[i,j] = Convert.ToInt32(Console.ReadLine());
                }
            }

            int max = 0, index = n + 1;

            for (int i = 0; i < n; i++)
            {
                int sum = 0;
                
                for (int j = 0; j < n; j++)
                {
                    sum += ar[i, j];
                }

                Console.WriteLine($"Сумма элементов {i + 1} стоки равна {sum}");

                if (sum > max)
                {
                    index = i;
                    max = sum;
                }
            }

            Console.WriteLine($"Максимальная сумма в строке {index + 1}");
        }
    }
}