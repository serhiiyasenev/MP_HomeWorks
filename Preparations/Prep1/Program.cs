using System;

namespace Prep1
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new S();
            using (s)
            {
                Console.WriteLine(s.GetDispose());
            }
            Console.WriteLine(s.GetDispose());
            Console.ReadKey();
        }
    }
}