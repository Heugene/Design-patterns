﻿namespace Strategy
{
    // Код взятий з https://www.dofactory.com/net/strategy-design-pattern
    // Причин для модифікації не бачу, враховуючи те, що це навчальна демонстрація.


    /// <summary>
    /// Strategy Design Pattern
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            // Two contexts following different strategies
            SortedList studentRecords = new SortedList();
            studentRecords.Add("Samual");
            studentRecords.Add("Jimmy");
            studentRecords.Add("Sandra");
            studentRecords.Add("Vivek");
            studentRecords.Add("Anna");
            studentRecords.SetSortStrategy(new QuickSort());
            studentRecords.Sort();
            studentRecords.SetSortStrategy(new ShellSort());
            studentRecords.Sort();
            studentRecords.SetSortStrategy(new MergeSort());
            studentRecords.Sort();
            // Wait for user
            Console.ReadKey();
        }
    }
    /// <summary>
    /// The 'Strategy' abstract class
    /// </summary>
    public abstract class SortStrategy
    {
        public abstract void Sort(List<string> list);
    }
    /// <summary>
    /// A 'ConcreteStrategy' class
    /// </summary>
    public class QuickSort : SortStrategy
    {
        public override void Sort(List<string> list)
        {
            list.Sort();  // Default is Quicksort
            Console.WriteLine("QuickSorted list ");
        }
    }
    /// <summary>
    /// A 'ConcreteStrategy' class
    /// </summary>
    public class ShellSort : SortStrategy
    {
        public override void Sort(List<string> list)
        {
            //list.ShellSort();  not-implemented
            Console.WriteLine("ShellSorted list ");
        }
    }
    /// <summary>
    /// A 'ConcreteStrategy' class
    /// </summary>
    public class MergeSort : SortStrategy
    {
        public override void Sort(List<string> list)
        {
            //list.MergeSort(); not-implemented
            Console.WriteLine("MergeSorted list ");
        }
    }
    /// <summary>
    /// The 'Context' class
    /// </summary>
    public class SortedList
    {
        private List<string> list = new List<string>();
        private SortStrategy sortstrategy;
        public void SetSortStrategy(SortStrategy sortstrategy)
        {
            this.sortstrategy = sortstrategy;
        }
        public void Add(string name)
        {
            list.Add(name);
        }
        public void Sort()
        {
            sortstrategy.Sort(list);
            // Iterate over list and display results
            foreach (string name in list)
            {
                Console.WriteLine(" " + name);
            }
            Console.WriteLine();
        }
    }
}
