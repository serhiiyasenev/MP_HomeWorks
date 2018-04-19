using System;

namespace Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Fibonacci(39));
            Console.ReadKey();
        }

        private static int Fibonacci(int n)
        {
            int nThFibonacci;

            if (n < 0)
            {
                nThFibonacci = 0;
            }
            else
            {
                if (n < 2)
                {
                    nThFibonacci = n;
                }
                else
                {
                    nThFibonacci = Fibonacci(n - 2) + Fibonacci(n - 1);
                }
            }
            return nThFibonacci;
        }
    }
}