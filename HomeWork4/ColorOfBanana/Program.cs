using System;

namespace ColorOfBanana
{
    class Program
    {
        private static void Main()
        {
            Console.WriteLine("What is the color of Banana?");

            string bananaColor = Console.ReadLine();

            Console.WriteLine(IsGuessed(bananaColor) ? "Yes! You guessed!" : "Try again!");

            Console.ReadKey();
        }

        public static bool IsGuessed(string color)
        {
            bool isGuessed = string.Equals(color.ToLower(), Colors.Yellow.ToString().ToLower(), StringComparison.Ordinal);

            return isGuessed;
        }
    }
}