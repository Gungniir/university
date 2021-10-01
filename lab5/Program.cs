using System;
using System.Threading;

namespace lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вы недавно узналди, что у вас есть кошка (или кот)!");
            Console.WriteLine("Но сколько ему (ей) лет?");
            Console.Write("Количество лет: ");

            Cat cat = new Cat(Convert.ToUInt32(Console.ReadLine()));

            Console.WriteLine("Отлично, а как его (её) будут звать?");
            Console.WriteLine("(Если ещё не придумали, то нажмите enter)");
            Console.Write("Имя: ");
            
            string name = Console.ReadLine();

            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Что ж, ещё будет время придумать позже :)");
            }
            else
            {
                cat.Name = name;
            }

            uint day = 1;
            
            while (cat.Health > 0)
            {
               Console.WriteLine("----------------------------------");
               Console.WriteLine($"|            День {day++,3}            |");
               Console.WriteLine("|--------------------------------|");
               Console.WriteLine($"| Здоровье: {cat.Health,3} | Окрас: {cat.Color,7} |");
               Console.WriteLine("----------------------------------");

               Random rand = new Random();

               if (string.IsNullOrEmpty(cat.Name))
               {
                   Console.WriteLine("Новый день, а ваша котейка ещё без имени, исправим?");
                   Console.Write("Имя: ");
                   name = Console.ReadLine();

                   if (string.IsNullOrEmpty(name))
                   {
                       Console.WriteLine("Что ж, ещё будет время придумать позже :)");
                   }
                   else
                   {
                       cat.Name = name;
                   }
               }

               int hit, heal;
               switch (rand.Next(5))
               {
                   case 0:
                       Console.WriteLine("Ваше животное спит... Ничего необычного :)");
                       break;
                   case 1:
                       Console.WriteLine("Сегодня он стащил из вашего холодильника стухшую колбасу... Он отравился :(");
                       hit = rand.Next(1, 5);
                       cat.Punish(hit);
                       Console.WriteLine($"Здоровье упало на {hit} (новое значение: {cat.Health})");
                       break;
                   case 2:
                       Console.WriteLine($"Сегодня он стащил из холодильника ваши сосистки!");
                       heal = rand.Next(1, 10);
                       cat.Feed(heal);
                       Console.WriteLine($"Здоровье поднялось на {heal} (новое значение: {cat.Health})");
                       break;
                   case 3:
                       Console.WriteLine($"Сегодня он стащил из холодильника молоко!");
                       heal = rand.Next(1, 10);
                       cat.Feed(heal);
                       Console.WriteLine($"Здоровье поднялось на {heal} (новое значение: {cat.Health})");
                       break;
                   case 4:
                       Console.WriteLine($"Сегодня он жалобно мурлычит у ваших ног :)");
                       break;
                   case 5:
                       Console.WriteLine($"Он исцарапал вашу мебель...");
                       break;
               }
               
               Console.WriteLine("Что будем делать?");
               Console.WriteLine("Введите положительное число, чтобы накормить котейку, или отрицательное, чтобы наказать проказника");
               Console.Write("Кормим/Наказываем: ");
               
               int delta = Convert.ToInt32(Console.ReadLine());

               if (delta > 0)
               {
                   cat.Feed(delta);
                   Console.WriteLine("Сегодня котейка хорошо себя вел(а), покорими его (её) :)");
                   Console.WriteLine($"Здоровье поднялось на {delta} (новое значение: {cat.Health})");
               } else if (delta < 0)
               {
                   cat.Punish(-delta);
                   Console.WriteLine("Ух и проказник!!! Наказываем!");
                   Console.WriteLine($"Здоровье упало на {-delta} (новое значение: {cat.Health})");
               } else
               {
                   Console.WriteLine("Просто гладим :)");
               }
               
               Thread.Sleep(2000);
            }
            
            Console.WriteLine("----------------------------------");
            Console.WriteLine($"|            День {day,3}            |");
            Console.WriteLine("|--------------------------------|");
            Console.WriteLine($"| Здоровье: {cat.Health,3} | Окрас: {cat.Color,7} |");
            Console.WriteLine("----------------------------------");

            if (string.IsNullOrEmpty(cat.Name))
            {
                Console.WriteLine("К сожалению, котейка умер(ла) :(");
                Console.WriteLine("А вы так и не дали ему (ей) имя...");
            }
            else
            {
                Console.WriteLine($"К сожалению, {cat.Name} умер(ла) :(");
            }
            Console.WriteLine($"Она прожила с вами {day - 1} дней...");
        }
    }
}