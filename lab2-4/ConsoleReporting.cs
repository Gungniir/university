using System.Reflection;
using lab2_4.attributes;
using tabler;

namespace lab2_4;

public static class ConsoleReporting
{
    public static void Parse(List<object> objects)
    {
        if (objects.Count == 0)
        {
            Console.WriteLine("Передан пустой массив");
            return;
        }

        Type type = objects[0].GetType();

        if (!type.IsClass)
        {
            Console.WriteLine("Массив состоит не из объектов");
            return;
        }

        var members = type.GetMembers(BindingFlags.Instance | BindingFlags.Public | BindingFlags.GetField |
                                      BindingFlags.GetProperty);

        List<FieldInfo> fields = new();
        List<PropertyInfo> props = new();

        foreach (var member in members)
        {
            if (member.GetCustomAttributes().Any(attribute => attribute is NotPrintableAttribute))
            {
                continue;
            }

            if (member is FieldInfo f)
            {
                fields.Add(f);
            }
            else if (member is PropertyInfo {CanRead: true} p)
            {
                props.Add(p);
            }
        }

        if (type.GetCustomAttributes().Any(attribute => attribute is HorizontalAlignmentAttribute))
        {
            HorizontalPrint(objects, props, fields, type.Name);
        }
        else
        {
            VerticalPrint(objects, props, fields, type.Name);
        }
    }

    private static void HorizontalPrint(List<object> objects, List<PropertyInfo> props, List<FieldInfo> fields,
        string objectName)
    {
        int padding = 150 - objectName.Length;
        int fix = padding % 2;
        padding /= 2;

        Console.WriteLine(new string('=', padding) + objectName + new string('=', padding + fix));
        foreach (var obj in objects)
        {
            foreach (var prop in props)
            {
                Console.Write($"{prop.Name}: {prop.GetValue(obj)} |");
            }

            foreach (var field in fields)
            {
                Console.Write($"{field.Name}: {field.GetValue(obj)} |");
            }

            Console.WriteLine();
        }

        Console.WriteLine(new string('=', 150));
    }

    private static void VerticalPrint(List<object> objects, List<PropertyInfo> props, List<FieldInfo> fields,
        string objectName)
    {
        Table table = new();
        table.AddRow(new List<Cell>
        {
            new()
            {
                Text = objectName,
                ForegroundColor = ConsoleColor.Blue,
                VerticalAlign = VerticalAlign.Center,
                TextAlign = TextAlign.Center
            }
        });

        List<Cell> header = props.Select(prop => new Cell
        {
            Text = prop.Name, ForegroundColor = ConsoleColor.Cyan, VerticalAlign = VerticalAlign.Center,
            TextAlign = TextAlign.Center
        }).ToList();

        header.AddRange(fields.Select(filed => new Cell
        {
            Text = filed.Name, ForegroundColor = ConsoleColor.Cyan, VerticalAlign = VerticalAlign.Center,
            TextAlign = TextAlign.Center
        }));

        table.AddRow(header);

        foreach (var obj in objects)
        {
            List<Cell> row = new();

            row.AddRange(props.Select(prop => new Cell
                {Text = prop.GetValue(obj)?.ToString() ?? "[Не удалось получить значение]",}));
            row.AddRange(fields.Select(field => new Cell
                {Text = field.GetValue(obj)?.ToString() ?? "[Не удалось получить значение]",}));

            table.AddRow(row);
        }

        table.Print();
    }
}