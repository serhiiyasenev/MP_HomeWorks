using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please, input your name:");
            var name = Console.ReadLine();

            Console.WriteLine($"Hello {name}!");
            Console.ReadKey();
        }
    }
}
