using System;

namespace ExtensionMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = "Hello Extension Methods";
            int i = s1.WordCount(); // i получит значение 3

            string s2 = "Съешь же ещё этих мягких французских булок, да выпей чаю.";
            int j = s2.WordCount(); // j получит значение 10

            Console.WriteLine($"'Hello Extension Methods' - кол-во слов = {i}");
            Console.WriteLine("'Съешь же ещё этих мягких французских булок, да выпей чаю.' " +
                              $"- кол-во слов = {j}");

            Console.ReadKey();
        }
    }
}