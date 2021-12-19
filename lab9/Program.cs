using System;
using lab9.classes;
using lab9.consoler;

namespace lab9
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Checkpoint checkpoint = new()
            {
                MasksCount = 5
            };
            
            Console.WriteLine("Создаём желающих песетить ИКИТ");
            for (int i = 0; i < 10; i++)
            {
                checkpoint.VisitorsWantToISIT.Add(Teacher.Generate());
                checkpoint.VisitorsWantToISIT.Add(Enrollee.Generate());
                checkpoint.VisitorsWantToISIT.Add(Student.Generate());
                checkpoint.VisitorsWantToISIT.Add(Dog.Generate());
                checkpoint.VisitorsWantToISIT.Add(Squirrel.Generate());
                checkpoint.VisitorsWantToISIT.Add(Dove.Generate());
            }
            
            Console.WriteLine("Открываем двери");
            
            checkpoint.Check();
            
            Console.WriteLine("Итого получили допуск");

            Table table = new();
            foreach (var visitor in checkpoint.VisitorsCanToISIT)
            {
                Row row = new();
                row.Cells.Add(new Cell
                {
                    Text = visitor.Name
                });
                table.Rows.Add(row);
            }
            Consoler.PrintTable(table);
        }
    }
}