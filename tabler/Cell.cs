using System.Drawing;

namespace tabler;

public enum TextAlign
{
    Left,
    Center,
    Right
}

public enum VerticalAlign
{
    Top,
    Center,
    Bottom
}

public enum TextWrap
{
    Wrap,
    NoWrap
}

public class Cell
{
    public ConsoleColor BackgroundColor = Console.BackgroundColor;
    public ConsoleColor ForegroundColor = Console.ForegroundColor;

    public TextAlign TextAlign = TextAlign.Left;
    public VerticalAlign VerticalAlign = VerticalAlign.Top;
    public TextWrap TextWrap = TextWrap.Wrap;

    public string Text = "";
    public int Width = 0;

    public int Height => Width == 0 ? 1 : (Text.Length - 1) / Width + 1;

    public List<string> Render(int rowHeight)
    {
        if (rowHeight < Height)
        {
            throw new Exception("Высота ячейки не может быть больше высоты строки");
        }

        if (rowHeight == Height)
        {
            return RenderText();
        }

        var result = RenderText();

        if (VerticalAlign == VerticalAlign.Top)
        {
            for (int i = 0; i < rowHeight - Height; i++)
            {
                result.Add(new string(' ', Width));
            }
        }
        else if (VerticalAlign == VerticalAlign.Bottom)
        {
            for (int i = 0; i < rowHeight - Height; i++)
            {
                result.Insert(0, new string(' ', Width));
            }
        }
        else
        {
            int padding = rowHeight - Height;
            int fix = padding % 2;
            padding /= 2;

            for (int i = 0; i < padding; i++)
            {
                result.Insert(0, new string(' ', Width));
            }

            for (int i = 0; i < padding + fix; i++)
            {
                result.Add(new string(' ', Width));
            }
        }

        return result;
    }

    private List<string> RenderText()
    {
        string text = Text;
        List<string> result = new();

        while (text.Length > 0)
        {
            result.Add(text.Length > Width ? text[..Width] : text);
            text = text.Length > Width ? text[Width..] : "";

            if (TextWrap == TextWrap.NoWrap) break;
        }

        switch (TextAlign)
        {
            case TextAlign.Left:
                result[^1] += new string(' ', Width - result[^1].Length);
                break;
            case TextAlign.Right:
                result[^1] = new string(' ', Width - result[^1].Length) + result[^1];
                break;
            case TextAlign.Center:
                int padding = Width - result[^1].Length;
                int fix = padding % 2;
                padding /= 2;
                result[^1] = new string(' ', padding) + result[^1] + new string(' ', padding + fix);
                break;
        }

        return result;
    }
}