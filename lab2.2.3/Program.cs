// See https://aka.ms/new-console-template for more information

using lab2._2._3.Classes;
using lab2._2._3.Interfaces;

var system = new ProtectionSystem("Система защиты от атаки", 10);
var skyda = new Skyda(system);

List<IReactProtectionFail> reactors = new List<IReactProtectionFail>();
for (int i = 0; i < system.ProtectionLayerNumber; i++)
{
    reactors.Add(new BasicLayerNotifier(i + 1));
}
reactors.Add(new EndLayerNotifier(system.ProtectionLayerNumber));

reactors.ForEach(reactor => reactor.Subscribe(skyda));

int day = 0;
while (system.ProtectionCheck())
{
    day++;
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"День {day}:");
    Console.ResetColor();
    
    skyda.Attack();
    skyda.NotifyProtectionFall();
    
    reactors.ForEach(reactor => Console.WriteLine($"{reactor.GetType().Name}: {reactor.Message}"));
}
