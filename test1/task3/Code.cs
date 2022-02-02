using test1.consoler;

namespace test1.task3
{
    public class Code : ICode
    {
        public string Name { get; } = "Управлиение зданиями и сооружениями";

        public string Description { get; } = "Привет! Эта программа поможает работать с фондом зданий предприятия!";

        public void Run()
        {
            IDatabase db = new NoDatabase();

            List<ICommand> commands = new List<ICommand>
            {
                new CommandAddPerson(db),
                new CommandIndexPersons(db),
                new CommandBuildingsPerson(db),
                new CommandAddBuilding(db),
                new CommandIndexBuilding(db),
                new CommandExpensiveBuilding(db),
                new CommandDeprecatedBuildings(db),
            };

            CommandHelp(commands);

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
                    CommandHelp(commands);
                    continue;
                }

                ICommand? command = commands.Find(command => command.Equals(input));

                if (command is null)
                {
                    Console.WriteLine("Неизвестная комманда");
                    continue;
                }


                command.Run();
            }
        }

        private void CommandHelp(List<ICommand> commands)
        {
            Console.WriteLine("Список доступные комманд:");

            foreach (ICommand command in commands)
            {
                Console.WriteLine($"{command.Signature} -- {command.Description}");
            }

            Console.WriteLine($"help -- Вывести список всех доступных комманд");
        }
    }
}