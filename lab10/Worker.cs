using System;

namespace lab10
{
    public struct Worker : IComparable<Worker>
    {
        public enum EPosition
        {
            PreSchool,
            MiddleSchool,
            HighSchool
        }
        
        public int Number { get; set; }
        public int CountPhone { get; set; }
        public int CountLunch { get; set; }
        public EPosition Position { get; set; }


        public int CompareTo(Worker worker)
        {
            if (CountPhone == worker.CountPhone)
            {
                return Position - worker.Position;
            }

            return CountPhone - worker.CountPhone;
        }
    }
}