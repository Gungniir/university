// See https://aka.ms/new-console-template for more information

using lab2._1.Classes;
using lab2._1.consoler;
using lab2._1.Interfaces;

#region Подготовление и наполнение
Console.ForegroundColor = ConsoleColor.Cyan;

UMarket market = new();
market.Things.AddRange(new List<IThing>
{
    new ChocolateBar(),
    new Crisps(),
    new BalykCheese(),
    new Chicken(),
    new OlieveOil(),
    new Fruit(),
    new DumplingsMeat(),
    new Cheburek(),
    new DumplingsBerries(),
    new Pen(),
    new Notebook(),
});
Cart<IFood> cart = new();
Cart<ISnacks> snacksCart = new();
Cart<IHealthyFood> healthyCart = new();
Cart<ISemiFinishedFood> semiFinishedCart = new();

#endregion

#region Вывод доступных категорий
Table table = new();
table.Rows.Add(new Row
{
    Cells = new List<Cell>
    {
        new Cell
        {
            Text = "Привет! Выбери категорию!",
            TextAlign = Cell.TextAlignEnum.Center
        }
    }
});
table.Rows.Add(new Row
{
    Cells = new List<Cell>
    {
        new Cell
        {
            WidthMode = Cell.WidthModeEnum.FitContent,
            Text = "1",
        },
        new Cell
        {
            Text = "Вся еда",
        },
    }
});
table.Rows.Add(new Row
{
    Cells = new List<Cell>
    {
        new Cell
        {
            WidthMode = Cell.WidthModeEnum.FitContent,
            Text = "2",
        },
        new Cell
        {
            Text = "Снеки",
        },
    }
});
table.Rows.Add(new Row
{
    Cells = new List<Cell>
    {
        new Cell
        {
            WidthMode = Cell.WidthModeEnum.FitContent,
            Text = "3",
        },
        new Cell
        {
            Text = "Проодукты для приготовления",
        },
    }
});
table.Rows.Add(new Row
{
    Cells = new List<Cell>
    {
        new Cell
        {
            WidthMode = Cell.WidthModeEnum.FitContent,
            Text = "4",
        },
        new Cell
        {
            Text = "Полуфабрикаты",
        },
    }
});

Consoler.PrintTable(table);
#endregion

Console.Write("Категория: ");
int category = int.Parse(Console.ReadLine()!);

#region Вывод таоваров в категории
table = new();
table.Rows.Add(new Row
{
    Cells = new List<Cell>
    {
        new Cell
        {
            TextAlign = Cell.TextAlignEnum.Center,
            Text = "Доступные товары",
        },
    }
});
table.Rows.Add(new Row
{
    Cells = new List<Cell>
    {
        new Cell
        {
            TextAlign = Cell.TextAlignEnum.Center,
            Text = "Название товара",
        },
        new Cell
        {
            WidthMode = Cell.WidthModeEnum.FitContent,
            Text = "Б",
        },
        new Cell
        {
            WidthMode = Cell.WidthModeEnum.FitContent,
            Text = "Ж",
        },
        new Cell
        {
            WidthMode = Cell.WidthModeEnum.FitContent,
            Text = "У",
        },
    }
});
foreach (var thing1 in market.Things.Where(thing => thing is IFood))
{
    var thing = (IFood) thing1;
    if (thing is ISnacks && category != 1 && category != 2)
    {
        continue;
    }
    if (thing is IHealthyFood && category != 1 && category != 3)
    {
        continue;
    }
    if (thing is ISemiFinishedFood && category != 1 && category != 4)
    {
        continue;
    }
    
    table.Rows.Add(new Row
    {
        Cells = new List<Cell>
        {
            new Cell
            {
                Text = thing.Name,
            },
            new Cell
            {
                WidthMode = Cell.WidthModeEnum.FitContent,
                Text = thing.Proteins ? "+" : "-",
            },
            new Cell
            {
                WidthMode = Cell.WidthModeEnum.FitContent,
                Text = thing.Fats ? "+" : "-",
            },
            new Cell
            {
                WidthMode = Cell.WidthModeEnum.FitContent,
                Text = thing.Carbonhydrates ? "+" : "-",
            },
        }
    });
}

Consoler.PrintTable(table);
#endregion

Console.WriteLine("Введите названия товаров, чтобы добавить его в корзину");
while (true)
{
    Console.Write("Название товара (\\q для выхода): ");
    var name = Console.ReadLine()!;

    if (name == "\\q") break;

    IFood food;
    try
    {
        IThing? thing = market.Things.Where(localThing => localThing is IFood).First(localThing => localThing.Name == name);

        if (thing is not IFood)
        {
            throw new InvalidOperationException();
        }

        if (thing is ISnacks && category != 1 && category != 2)
        {
            throw new InvalidOperationException();
        }

        if (thing is IHealthyFood && category != 1 && category != 3)
        {
            throw new InvalidOperationException();
        }

        if (thing is ISemiFinishedFood && category != 1 && category != 4)
        {
            throw new InvalidOperationException();
        }

        food = (IFood) thing;
    }
    catch (InvalidOperationException e)
    {
        Console.WriteLine("Товар не найден");
        continue;
    }

    switch (category)
    {
        case 1:
            cart.Foodstuffs.Add(food);
            break;
        case 2:
            snacksCart.Foodstuffs.Add((ISnacks) food);
            break;
        case 3:
            healthyCart.Foodstuffs.Add((IHealthyFood) food);
            break;
        case 4:
            semiFinishedCart.Foodstuffs.Add((ISemiFinishedFood) food);
            break;
    }
}

while (category == 1 && !cart.Isbalanced() || category == 2 && !snacksCart.Isbalanced() || category == 3 && !healthyCart.Isbalanced() || category == 4 && !semiFinishedCart.Isbalanced())
{
    Console.WriteLine("Ваша корзина не сбалансирована по белкам, жирам и углеводам");
    Console.Write("Сбалансировать('+' - да, '-' - нет): ");
    string sign = Console.ReadLine()!;

    if (sign == "-")
    {
        break;
    }

    if (sign == "+")
    {
        try
        {
            switch (category)
            {
                case 2:
                    snacksCart.CartBalansing(market.Things.Where(thing => thing is ISnacks).Cast<ISnacks>().ToList());
                    break;
                case 3:
                    healthyCart.CartBalansing(market.Things.Where(thing => thing is IHealthyFood).Cast<IHealthyFood>().ToList());
                    break;
                case 4:
                    semiFinishedCart.CartBalansing(market.Things.Where(thing => thing is ISemiFinishedFood).Cast<ISemiFinishedFood>().ToList());
                    break;
                default:
                    cart.CartBalansing(market.Things.Where(thing => thing is IFood).Cast<IFood>().ToList());
                    break;
            }
            break;
        }
        catch (InvalidOperationException e)
        {
            Console.WriteLine("Невозможно сбалансировать корзину");
        }
    }
    else
    {
        Console.WriteLine("Не удалось распознать");
    }
}

table = new();
table.Rows.Add(new Row
{
    Cells = new List<Cell>
    {
        new Cell
        {
            TextAlign = Cell.TextAlignEnum.Center,
            Text = "Ваша корзина"
        }
    }
});
table.Rows.Add(new Row
{
    Cells = new List<Cell>
    {
        new Cell
        {
            TextAlign = Cell.TextAlignEnum.Center,
            Text = "Название товара",
        },
        new Cell
        {
            WidthMode = Cell.WidthModeEnum.FitContent,
            Text = "Б",
        },
        new Cell
        {
            WidthMode = Cell.WidthModeEnum.FitContent,
            Text = "Ж",
        },
        new Cell
        {
            WidthMode = Cell.WidthModeEnum.FitContent,
            Text = "У",
        },
    }
});

List<IFood> list = category switch
{
    1 => cart.Foodstuffs,
    2 => snacksCart.Foodstuffs.Cast<IFood>().ToList(),
    3 => healthyCart.Foodstuffs.Cast<IFood>().ToList(),
    _ => semiFinishedCart.Foodstuffs.Cast<IFood>().ToList()
};

foreach (var thing in list)
{
    table.Rows.Add(new Row
    {
        Cells = new List<Cell>
        {
            new Cell
            {
                Text = thing.Name,
            },
            new Cell
            {
                WidthMode = Cell.WidthModeEnum.FitContent,
                Text = thing.Proteins ? "+" : "-",
            },
            new Cell
            {
                WidthMode = Cell.WidthModeEnum.FitContent,
                Text = thing.Fats ? "+" : "-",
            },
            new Cell
            {
                WidthMode = Cell.WidthModeEnum.FitContent,
                Text = thing.Carbonhydrates ? "+" : "-",
            },
        }
    });
}

Consoler.PrintTable(table);