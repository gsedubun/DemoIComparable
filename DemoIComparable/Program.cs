using System;
using System.Collections.Generic;

namespace DemoIComparable
{
    class Program
    {
        private static WorkDay workday1 = new WorkDay { Day = 1, DayName = "Monday" };
        private static WorkDay workday2 = new WorkDay { Day = 2, DayName = "Tuesday" };
        private static WorkDay workday3 = new WorkDay { Day = 3, DayName = "Wednesday" };
        private static WorkDay workday4 = new WorkDay { Day = 4, DayName = "Thursday" };
        private static WorkDay workday5 = new WorkDay { Day = 5, DayName = "Friday" };
        private static Shift shift1 = new Shift { Start = TimeSpan.Parse("08:00"), End = TimeSpan.Parse("12:00"), Name = "Shift 1" };
        private static Shift shift2 = new Shift { Start = TimeSpan.Parse("12:00"), End = TimeSpan.Parse("16:00"), Name = "Shift 2" };
        private static Shift shift3 = new Shift { Start = TimeSpan.Parse("16:00"), End = TimeSpan.Parse("20:00"), Name = "Shift 3" };

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            List<Schedule> list = new List<Schedule>
            {
                new Schedule
                {
                    Shift = shift1,
                    WorkDay= workday1
                },
                new Schedule
                {
                    Shift = shift2,
                    WorkDay= workday4
                },
                new Schedule
                {
                    Shift = shift1,
                    WorkDay= workday2
                },
                new Schedule
                {
                    Shift = shift2,
                    WorkDay= workday1
                },
                new Schedule
                {
                    Shift = shift1,
                    WorkDay= workday5
                },
                new Schedule
                {
                    Shift = shift2,
                    WorkDay= workday3
                },

            };
            Console.WriteLine("Before Sorting");
            foreach (var item in list)
            {
                Console.WriteLine($"{item.WorkDay.DayName} - on {item.Shift.Name} from {item.Shift.Start} to {item.Shift.End}.");
            }
            Console.WriteLine("\n\n\n\n");

            list.Sort();
            Console.WriteLine("After Sorting");
            foreach (var item in list)
            {
                Console.WriteLine($"{item.WorkDay.DayName} - on {item.Shift.Name} from {item.Shift.Start} to {item.Shift.End}.");
            }

            Console.ReadKey();
        }
    }
    class Schedule : IComparable<Schedule>
    {
        public int CompareTo(Schedule other)
        {
            int result = 0;
            if (WorkDay.Day < other.WorkDay.Day)
            {
                result = -2;
            }
            else if (WorkDay.Day > other.WorkDay.Day)
            {
                result = 2;
            }
            result += Shift.CompareTo(other.Shift);

            return result;
        }

        public WorkDay WorkDay { get; set; }
        public Shift Shift { get; set; }
    }

    public struct WorkDay : IComparable<WorkDay>
    {
        public int Day { get; set; }
        public string DayName { get; set; }

        public int CompareTo(WorkDay other)
        {
            if (Day > other.Day)
                return 1;
            else if(Day<other.Day)
                return -1;
            return 0;
        }
    }

    public struct Shift : IComparable<Shift>
    {
        public string Name { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }

        public int CompareTo(Shift other)
        {
            if (Start > other.Start)
                return 1;
            else if(Start< other.Start)
                return -1;
            return 0;
        }
    }


}
