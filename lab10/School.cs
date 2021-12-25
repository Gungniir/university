using System.Collections.Generic;
using System.Linq;

namespace lab10
{
    public class School
    {
        public List<Worker> Workers { get; } = new();

        public (Worker, Worker) FindMinMaxEmployee()
        {
            Workers.Sort();

            return (Workers.First(), Workers.Last());
        }

        public static void Reward(ref (Worker, Worker) students)
        {
            students.Item1.CountLunch--;
            students.Item2.CountLunch++;
        }
    }
}