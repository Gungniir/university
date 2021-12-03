using System;
using System.Collections.Generic;
using lab8.consoler;
using lab8.factory;

namespace lab8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Создаём завод с машинками!");

            FactoryAF factory = FactoryAFFactory.MakeOne();
            
            Console.WriteLine("У нас уже очередь из покупателей!");

            {
                
                Table table = new();
                
                Row header = new();
                header.Cells.Add(new Cell
                {
                    Text = "Покупатели в очереди",
                    TextAlign = Cell.TextAlignEnum.Center
                });
                table.Rows.Add(header);
                
                for (int i = 0; i < factory.Customers.Count; i++)
                {
                    Row row = new();

                    row.Cells.Add(new Cell
                    {
                        Text = (i + 1).ToString(),
                        WidthMode = Cell.WidthModeEnum.Fixed,
                        FixedWidth = 5
                    });
                    
                    row.Cells.Add(new Cell
                    {
                        Text = factory.Customers[i].FIO
                    });
                    
                    table.Rows.Add(row);
                }
                
                Consoler.PrintTable(table);
            }
            
            Console.WriteLine("Создаём машинки!");

            List<Car> cars = Car.Factory().Count(20).Make();

            {
                Table table = new();
                
                Row header = new();
                header.Cells.Add(new Cell()
                {
                    Text = "Информация о машинках"
                });
                table.Rows.Add(header);
                
                for (int i = 0; i < cars.Count; i++)
                {
                    var car = cars[i];
                    
                    factory.AddCar(car);

                    Row row = new();
                    row.Cells.Add(new Cell
                    {
                        Text = "Машика " + (i + 1),
                        TextAlign = Cell.TextAlignEnum.Center
                    });
                    table.Rows.Add(row);

                    Row number = new();
                    number.Cells.Add(new Cell
                    {
                        Text = "Номер:",
                        WidthMode = Cell.WidthModeEnum.Fixed,
                        FixedWidth = 10
                    });
                    number.Cells.Add(new Cell
                    {
                        Text = car.Number.ToString()
                    });
                    table.Rows.Add(number);

                    Row size = new();
                    size.Cells.Add(new Cell
                    {
                        Text = "Размер п.:",
                        WidthMode = Cell.WidthModeEnum.Fixed,
                        FixedWidth = 10
                    });
                    size.Cells.Add(new Cell
                    {
                        Text = car.PedalSize().ToString()
                    });
                    table.Rows.Add(size);
                }
                
                Consoler.PrintTable(table);
            }
            
            Console.WriteLine("\nПродаём машины!\n");
            factory.SaleCar();

            {
                Table table = new();

                Row header = new();
                header.Cells.Add(new Cell
                {
                    Text = "Оставшиеся покупатели",
                    TextAlign = Cell.TextAlignEnum.Center
                });
                
                table.Rows.Add(header);

                foreach (var customer in factory.Customers)
                {
                    Row row = new();
                    row.Cells.Add(new Cell
                    {
                        Text = customer.FIO
                    });
                    table.Rows.Add(row);
                }
                
                Consoler.PrintTable(table);
            }
            
            Console.WriteLine();
            
            {
                Table table = new();

                Row header = new();
                header.Cells.Add(new Cell
                {
                    Text = "Довольные покупатели",
                    TextAlign = Cell.TextAlignEnum.Center
                });
                
                table.Rows.Add(header);

                foreach (var customer in factory.Clients)
                {
                    Row row = new();
                    row.Cells.Add(new Cell
                    {
                        Text = customer.FIO
                    });
                    row.Cells.Add(new Cell
                    {
                        Text = "Машина:",
                        WidthMode = Cell.WidthModeEnum.FitContent
                    });
                    row.Cells.Add(new Cell
                    {
                        Text = customer.Car.Number.ToString()
                    });
                    table.Rows.Add(row);
                }
                
                Consoler.PrintTable(table);
            }
        }
    }
}