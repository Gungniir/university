namespace test1.task2
{
    public class Code: ICode
    {
        public string Name { get; } = "Алгоритмик";

        public string Description { get; } = "Привет! Эта программа показывает, что тот, кто её написал, умеет работать с листами!";

        public void Run()
        {
            Console.WriteLine("Обязательно ввести одно число, потом можете ввести пустую строку, чтобы закончить ввод");
            
            List<int> arr = new();

            Console.Write($"Число №{arr.Count + 1}: ");
            string input = Console.ReadLine() ?? String.Empty;
            
            while (!string.IsNullOrEmpty(input))
            {
                arr.Add(int.Parse(input));
                
                Console.Write($"Число №{arr.Count + 1}: ");
                input = Console.ReadLine() ?? String.Empty;
            }

            double average = arr.Average();

            int max = arr[0];
            int min = arr[0];

            foreach (int i in arr)
            {
                double delta = Math.Abs(average - i);
                
                if (delta > Math.Abs(average - max))
                {
                    max = i;
                }
                
                if (delta < Math.Abs(average - min))
                {
                    min = i;
                }
            }
            
            Console.WriteLine($"Среднее значение: {average:0.00}");
            Console.WriteLine($"Наиболее удалённое значение: {max}");
            Console.WriteLine($"Наиболее близкое значение: {min}");
        }
    }
}