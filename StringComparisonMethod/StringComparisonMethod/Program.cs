using System;

namespace StringComparisonMethod
{
    class Program
    {
        public static void Main()
        {
            string string1 = "1.2.3";
            string string2 = "4.5.6";
            Console.WriteLine(StringHelper.CompareVersions(string1, string2));
            Console.WriteLine("-------------");

            string1 = "1";
            string2 = "1.0";
            Console.WriteLine(StringHelper.CompareVersions(string1, string2));
            Console.WriteLine("-------------");

            string1 = "1.1.0";
            string2 = "1.0.1";
            Console.WriteLine(StringHelper.CompareVersions(string1, string2));
            Console.ReadLine();
        }
    }
}