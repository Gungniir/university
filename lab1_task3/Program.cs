using System;

namespace lab1_task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Депозитарный калькулятор");
            Console.WriteLine("Введите необходимые параметры для рассчета ниже");

            int deposit;
            Console.Write("Сумма депозита ($): ");
            try
            {
                deposit = int.Parse(Console.ReadLine()!);
            }
            catch (Exception)
            {
                Console.WriteLine("Не удалось распознать число...");
                return;
            }

            int rate;
            Console.Write("Ставка (% годовых): ");
            try
            {
                rate = int.Parse(Console.ReadLine()!);
            }
            catch (Exception)
            {
                Console.WriteLine("Не удалось распознать число...");
                return;
            }

            int duration;
            Console.Write("Время (в месяцах): ");
            try
            {
                duration = int.Parse(Console.ReadLine()!);
            }
            catch (Exception)
            {
                Console.WriteLine("Не удалось распознать число...");
                return;
            }

            int income = deposit * rate * duration / 12 / 100;
            
            Console.WriteLine($"Прибыль: {income}$, общая сумма выплаты: {deposit + income}$");
        }
    }
}