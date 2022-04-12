namespace coder;

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

            ICommand? command = Commands.Find(command => command.Signature.StartsWith(input.Split(' ')[0]));

            if (command is null)
            {
                Console.WriteLine("Неизвестная комманда");
                continue;
            }


            command.Run(input);
        }
    }

    private static void PrintHelpPage()
    {
        Console.WriteLine("Список доступные комманд:");

        foreach (ICommand command in Commands)
        {
            Console.WriteLine($"{command.Signature} -- {command.Description}");
        }

        Console.WriteLine("help -- Вывести список всех доступных комманд");
    }
}