// See https://aka.ms/new-console-template for more information

using coder;
using lab2_3;
using tabler;

List<Teacher> teachers = new();

CommandsContainer.Commands = new List<ICommand>
    {new AddTeacherCommand(teachers), new ListTeacherCommand(teachers), new TopServicesCommand(teachers)};
CommandsContainer.Serve();