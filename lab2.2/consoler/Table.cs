using System;
using System.Collections.Generic;

namespace lab2._2.consoler
{
    public class Table
    {
        public List<Row> Rows { get; set; }

        public int Width { get; set; }

        public Table()
        {
            Rows = new List<Row>();
            Width = 100;
        }

        public void AddRow(List<Cell> cells)
        {
            Rows.Add(new Row
            {
                Cells = cells,
            });
        }

        public static string Constuct(List<List<Cell>> rows)
        {
            Table table = new();

            foreach (List<Cell> cells in rows)
            {
                table.AddRow(cells);
            }

            return table.ToString();
        }

        public static void Print(List<List<Cell>> rows)
        {
            Console.WriteLine(Constuct(rows));
        }

        public override string ToString()
        {
            var separator = "+" + new string('-', Width) + "+";

            var result = separator + "\n";

            var addSeparator = false;

            foreach (var row in Rows)
            {
                if (addSeparator)
                {
                    result += separator + "\n";
                }

                addSeparator = true;

                row.Width = Width;

                result += row + "\n";
            }

            result += separator;

            return result;
        }
    }
}