using System;

namespace lab4_task4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] mat = new int[10, 20];

            Random rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    mat[i, j] = rand.Next(0, 15);
                    Console.Write($"{mat[i,j],2} ");
                }
                Console.Write("\n");
            }

            for (int i = 0; i < 10; i++)
            {
                bool print = false;
                
                for (int j = 0; j < 20; j++)
                {
                    if (mat[i, j] == 5)
                    {
                        print = true;
                        break;
                    }
                }

                if (print)
                {
                    Console.WriteLine($"5 встречается в строке №{i+1}");
                }
            }
        }
    }
}