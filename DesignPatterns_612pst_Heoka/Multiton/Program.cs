using System;
using System.Collections.Generic;

namespace Multiton
{
    // Код взятий з https://en.wikipedia.org/wiki/Multiton_pattern
    // Причин для модифікації не бачу, враховуючи те, що це навчальна демонстрація.

    public enum MultitonType
    {
        Zero,
        One,
        Two
    }

    public class Multiton
    {
        private static readonly Dictionary<MultitonType, Multiton> instances =
            new Dictionary<MultitonType, Multiton>();

        private MultitonType type;

        private Multiton(MultitonType type)
        {
            this.type = type;
        }

        public static Multiton GetInstance(MultitonType type)
        {
            // Lazy init (not thread safe as written)
            // Recommend using Double Check Locking if needing thread safety
            if (!instances.TryGetValue(type, out var instance))
            {
                instance = new Multiton(type);

                instances.Add(type, instance);
            }

            return instance;
        }

        public override string ToString()
        {
            return "My type is " + this.type;
        }

        // Sample usage
        public static void Main()
        {
            var m0 = Multiton.GetInstance(MultitonType.Zero);
            var m1 = Multiton.GetInstance(MultitonType.One);
            var m2 = Multiton.GetInstance(MultitonType.Two);

            Console.WriteLine(m0);
            Console.WriteLine(m1);
            Console.WriteLine(m2);
        }
    }
}
