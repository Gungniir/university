using System;

namespace lab2._2.consoler
{
    public class Consoler
    {
        public static int Width { get; set; }

        public static void PrintTable(Table table)
        {
            Console.Write(table);
            Console.Write("\n");
        }
    }
}