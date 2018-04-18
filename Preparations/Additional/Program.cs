using System;

namespace Additional
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(Termin());
            Console.ReadKey();
        }

        static int Termin()
        {
            int a = 1;
            int b = 3;
            if (a != 5)
                return a + b;
            return 0;
        }
    }
}
