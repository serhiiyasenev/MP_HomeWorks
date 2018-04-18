using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AsParallel
{
    class Program
    {
        static void Main(string[] args)
        {
            string timeUnits = "(Milliseconds)";

            IEnumerable<int> results = ParallelEnumerable.Range(0, 10)
                .WithMergeOptions(ParallelMergeOptions.FullyBuffered)
                .Select(i =>
                {
                    System.Threading.Thread.Sleep(1000);
                    return i;
                });

            Stopwatch sw = Stopwatch.StartNew();

            foreach (int i in results)
            {
                Console.WriteLine("Значение: {0}, Время: {1} {2}", i, sw.ElapsedMilliseconds, timeUnits);
            }

            Console.WriteLine("----------------------");

            IEnumerable results1 = ParallelEnumerable.Range(0, 10)
                .WithMergeOptions(ParallelMergeOptions.NotBuffered)
                .Select(i =>
                {
                    System.Threading.Thread.Sleep(1000);
                    return i;
                });

            Stopwatch sw1 = Stopwatch.StartNew();

            foreach (int ii in results1)
            {
                Console.WriteLine("Значение: {0}, Время: {1} {2}", ii, sw1.ElapsedMilliseconds, timeUnits);
            }

            Console.ReadKey();
        }
    }
}