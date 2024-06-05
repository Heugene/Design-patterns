namespace DoubleCheckedLocking
{
    // Код взятий з https://en.wikipedia.org/wiki/Double-checked_locking
    // Причин для модифікації не бачу, враховуючи те, що це навчальна демонстрація.


    //In .NET Framework 4.0, the Lazy<T> class was introduced,
    //which internally uses double-checked locking by default (ExecutionAndPublication mode)
    //to store either the exception that was thrown during construction, or the result of
    //the function that was passed to Lazy<T>

    public class MySingleton
    {
        private static readonly Lazy<MySingleton> _mySingleton = new Lazy<MySingleton>(() => new MySingleton());

        private MySingleton() { }

        public static MySingleton Instance => _mySingleton.Value;
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MySingleton.Instance);
        }
    }
}
