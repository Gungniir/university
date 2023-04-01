// See https://aka.ms/new-console-template for more information

using lab2_4;
using lab2_4.classes;

List<Student> students = new()
{
    new()
    {
        Name = "Владимир",
        Institute = "ИКИТ",
        DateOfBirth = DateTime.Parse("2003-10-08 10:00:00"),
        Inn = "255-655-655-255"
    },
    new()
    {
        Name = "Татьяна",
        Institute = "ИКИТ",
        DateOfBirth = DateTime.Parse("2003-02-21 10:00:00"),
        Inn = "255-655-655-254"
    },
    new()
    {
        Name = "Константин",
        Institute = "Отчислен",
        DateOfBirth = DateTime.Parse("2004-03-12 10:00:00"),
        Inn = "255-655-655-257"
    },
    new()
    {
        Name = "Иван",
        Institute = "СибГМУ",
        DateOfBirth = DateTime.Now,
        Inn = "255-655-655-252"
    },
};

List<Project> projects = new()
{
    new()
    {
        Name = "Покорение ИКИТа",
        Description = "Нужно доучиться хотя бы 4 года",
        Secret = "Нужно сдать все экзамены",
        StudentId = 1
    },
    new()
    {
        Name = "Странное что-то",
        Description = "Нужно сделать что-то странное",
        Secret = "Нужно сделать что-то странное",
        StudentId = 3
    }
};

ConsoleReporting.Parse(students.Cast<object>().ToList());
ConsoleReporting.Parse(projects.Cast<object>().ToList());