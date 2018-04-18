using System;
using System.Collections.Generic;
using System.Linq;

namespace Yield
{
    class Program
    {
        static IEnumerable<int> Generator(int max)
        {
            Random r = new Random();

            while (true)
            {
                yield return r.Next(max);
            }
        }
        static void Main(string[] args)
        {
            Collection col = new Collection();

            foreach (var item in col)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(new string('-', 20));

            foreach (var item in Generator(100).Take(10))
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
    }
}