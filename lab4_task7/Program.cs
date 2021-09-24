using System;

namespace lab4_task7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите N");
            Console.Write("N: ");

            int n = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Генерируем матрицу...");

            int[,] mat = new int[n, n];

            Random rand = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    mat[i, j] = rand.Next(0, 15);
                    Console.Write($"{mat[i, j],2} ");
                }

                Console.Write("\n");
            }

            Console.WriteLine("Меняем местами...");

            for (int i = 0; i < n / 2; i++)
            {
                (mat[i, i], mat[i, n - i - 1]) = (mat[i, n - i - 1], mat[i, i]);
            }
            
            Console.WriteLine("Вывод матрицы");

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"{mat[i,j],2} ");
                }
                Console.Write("\n");
            }
        }
    }
}