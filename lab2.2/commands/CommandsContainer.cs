namespace lab2._2.commands;

public static class CommandsContainer
{
    public static List<ICommand> Commands { get; set; } = new();

    public static void Serve()
    {
        PrintHelpPage();

        while (true)
        {
            Console.Write("> ");
            string? input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
            {
                break;
            }


            if (input == "help")
            {
                PrintHelpPage();
                continue;
            }

            ICommand? command = Commands.Find(command => command.Signature.Equals(input));

            if (command is null)
            {
                Console.WriteLine("Неизвестная комманда");
                continue;
            }


            command.Run();
        }
    }

    private static void PrintHelpPage()
    {
        Console.WriteLine("Список доступные комманд:");

        foreach (ICommand command in Commands)
        {
            Console.WriteLine($"{command.Signature} -- {command.Description}");
        }

        Console.WriteLine($"help -- Вывести список всех доступных комманд");
    }
}