using System;
using System.Collections.Generic;

namespace lab10.consoler
{
    public class Row
    {
        public List<Cell> Cells { get; set; }

        public int Width { get; set; }

        public Row()
        {
            Cells = new List<Cell>();
        }

        public override string ToString()
        {
            int widthAvailable = Width;

            widthAvailable -= Cells.Count - 1;
            
            // Считаем сколько клеток с auto width

            int auto = 0;

            foreach (var cell in Cells)
            {
                if (cell.WidthMode == Cell.WidthModeEnum.Auto)
                {
                    auto++;
                }
                else
                {
                    widthAvailable -= cell.Width();
                }
            }
            
            // Печатаем

            string result = "|";
            int autoWidth = 0;
            int autoWidthLast = 0;
            
            if (auto != 0)
            {
                autoWidth = widthAvailable / auto;
                autoWidthLast = autoWidth + widthAvailable % auto;
            }

            foreach (var cell in Cells)
            {
                if (auto != 0 && cell.WidthMode == Cell.WidthModeEnum.Auto)
                {
                    cell.AvailableWidth = auto == 1 ? autoWidthLast : autoWidth;
                    auto--;
                }

                result += cell.ToString();
                
                result += "|";
            }

            return result;
        }
    }
}