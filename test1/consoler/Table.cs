using System;
using System.Collections.Generic;

namespace test1.consoler
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