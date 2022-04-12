namespace tabler;

public class Table
{
    public List<List<Cell>> Rows = new();

    public int Width = 150;

    public void AddRow(List<Cell> cells)
    {
        Rows.Add(cells);
    }

    public void Print()
    {
        Console.ResetColor();
        Console.WriteLine("+" + new string('-', Width - 2) + "+");

        foreach (var row in Rows)
        {
            int height = row.Count > 0 ? row.MaxBy(cell => cell.Height)!.Height : 1;
            int width = row.Sum(cell => cell.Width) + (row.Count - 1) * 3 + 4;
            int flexible = row.FindAll(cell => cell.Width == 0).Count;
            int flexibleWidth = flexible > 0 ? (Width - width) / flexible : 0;
            int fix = Width - width - flexibleWidth * flexible;

            List<List<string>> renderedRow = new();
            row.ForEach(cell =>
            {
                if (cell.Width == 0)
                {
                    cell.Width = flexibleWidth;
                }

                renderedRow.Add(cell.Render(height));
            });

            for (int i = 0; i < height; i++)
            {
                Console.ResetColor();
                Console.Write("|");

                for (var index = 0; index < row.Count; index++)
                {
                    var cell = row[index];
                    Console.BackgroundColor = cell.BackgroundColor;
                    Console.ForegroundColor = cell.ForegroundColor;

                    Console.Write(" " + renderedRow[index][i] + (index == row.Count - 1 ? new string(' ', fix) : "") +
                                  " ");

                    Console.ResetColor();
                    Console.Write("|");
                }

                Console.WriteLine();
            }

            Console.ResetColor();
            Console.WriteLine("+" + new string('-', Width - 2) + "+");
        }
    }
}