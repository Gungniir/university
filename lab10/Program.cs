using System;
using System.Linq;
using lab10.consoler;

namespace lab10
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            Random rand = new();
            School school = new();
            var enumValues = Enum.GetValues<Worker.EPosition>();
            Console.WriteLine("Генерируем людей");

            Table table = new();
            for (int i = 0; i < 10; i++)
            {
                school.Workers.Add(new Worker
                {
                    Number = i,
                    CountLunch = rand.Next(1,100),
                    CountPhone = rand.Next(1,100),
                    Position = enumValues[rand.Next(enumValues.Length)]
                });

                Row row = new Row();
                row.Cells.Add(new Cell()
                {
                    TextAlign = Cell.TextAlignEnum.Center,
                    Text = "Человек " + i
                });
                table.Rows.Add(row);

                row = new Row();
                row.Cells.Add(new Cell
                {
                    WidthMode = Cell.WidthModeEnum.Fixed,
                    FixedWidth = 20,
                    Text = "Кол-во обедов:"
                });
                row.Cells.Add(new Cell
                {
                    Text = school.Workers.Last().CountLunch.ToString()
                });
                table.Rows.Add(row);

                row = new Row();
                row.Cells.Add(new Cell
                {
                    WidthMode = Cell.WidthModeEnum.Fixed,
                    FixedWidth = 20,
                    Text = "Кол-во айфонов:"
                });
                row.Cells.Add(new Cell
                {
                    Text = school.Workers.Last().CountPhone.ToString()
                });
                table.Rows.Add(row);

                row = new Row();
                row.Cells.Add(new Cell
                {
                    WidthMode = Cell.WidthModeEnum.Fixed,
                    FixedWidth = 20,
                    Text = "Позиция:"
                });
                row.Cells.Add(new Cell
                {
                    Text = school.Workers.Last().Position.ToString()
                });
                table.Rows.Add(row);
            }
            
            Consoler.PrintTable(table);

            (Worker, Worker) workers = school.FindMinMaxEmployee();
            School.Reward(ref workers);
            
            Console.WriteLine($"Лучший работник (id: {workers.Item2.Number}) имеет позицию " + workers.Item2.Position + ". Он сделал телефонов: " + workers.Item2.CountPhone + ". Он получил обедов: " + workers.Item2.CountLunch);
            Console.WriteLine($"Худший работник (id: {workers.Item1.Number}) имеет позицию " + workers.Item1.Position + ". Он сделал телефонов: " + workers.Item1.CountPhone + ". Он получил обедов: " + workers.Item1.CountLunch);
        }
    }
}