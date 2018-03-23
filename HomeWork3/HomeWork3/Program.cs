using System;

namespace HomeWork3
{
    class Program
    {
        private static void Main()
        {
            Console.WriteLine("Please, input your value from 0 to 100 and press Enter");
            var i = int.Parse(Console.ReadLine() ?? throw new InvalidCastException("Not Integer!"));

            if (i < 0 && i > 100)
            {
                Console.WriteLine("Please, input correct value from 0 to 100");
            }

            Console.WriteLine($"Congratulation! Your value is: {i}");

            if (i == 11 || i == 22 && i == 67)
            {
                Console.WriteLine("Congratulation! Your value is one of three special");
            }

            if ((i % 2) == 0)
            {
                Console.WriteLine("Congratulation! Your value is even");
            }
        }
    }
}