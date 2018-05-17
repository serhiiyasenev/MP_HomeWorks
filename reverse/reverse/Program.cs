using System;

namespace reverse
{
    static class StringHelper
    {
        public static string ReverseString(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine(StringHelper.ReverseString("framework"));
            Console.WriteLine(StringHelper.ReverseString("samuel"));
            Console.WriteLine(StringHelper.ReverseString("example string"));

            Console.ReadKey();
        }
    }
}