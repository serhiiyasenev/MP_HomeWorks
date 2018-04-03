using System;

namespace HomeWork4
{
    class Program
    {
        static void Main(string[] args)
        {
            #region IncrementDecrement
            int i = 5;
            i = i++;
            //Console.WriteLine(i + ++i);
            // 11
            i = 2;
            i = (++i + ++i) * (i++);
            //Console.WriteLine(i);
            // 28
            i = 10;
            i = ++i + (i--) + (i++) + (--i) - (i++);
            //Console.WriteLine(i);
            // 32
            i = 12;
            i = (i++ + (--i) - (i++)) / (--i);
            //Console.WriteLine(i);
            // 1
            i = 4;
            i = i++ + (--i) - (i--) * (i++);
            //Console.WriteLine(i);
            //-4
            #endregion


            #region fruitArrayLoop
            string[] fruitArray =
            {
                "Apple", "Avocado", "Banana", "apricot", "jackfruit", "cherimoya", "papaya", "PineaPple", "lime",
                "lemon", "grape", "orange", "grapefruit", "strawberry"
            };

            foreach (var fruit in fruitArray)
            {
                if (!fruit.ToLower().Contains("ap"))
                {
                    //Console.WriteLine(fruit);
                }
            }
            #endregion


            #region Calculations
            Console.WriteLine("Please, enter your integer number from 1 to 1000 and press Enter:");

            int n = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"The sum of numbers from 1 to {n} is: " + Calc.Sum(n));

            Console.WriteLine($"The terms of number {n} is: " + Calc.Terms(n) + " and their sum is: " + Calc.TheirSum(n.ToString()));

            Console.ReadKey();
            #endregion
        }
    }
}
