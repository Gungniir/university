Console.Write("Введите, сколько студентов будет подтягиваться: ");

int n = int.Parse(Console.ReadLine()!);

List<int> results = new List<int>();

for (int i = 0; i < n; i++)
{
    Console.Write($"Сколько раз подтянулся студент №{i+1}: ");
    results.Add(int.Parse(Console.ReadLine()!));
}

int five = 0;
int four = 0;
int three = 0;

foreach (int result in results)
{
    if (result >= 16)
    {
        five++;
        continue;
    }
    if (result >= 14)
    {
        four++;
        continue;
    }
    if (result >= 12)
    {
        three++;
        continue;
    }
}

Console.WriteLine($"Кол-во троечников: {three}");
Console.WriteLine($"Кол-во хорошистов: {four}");
Console.WriteLine($"Кол-во отличников: {five}");

