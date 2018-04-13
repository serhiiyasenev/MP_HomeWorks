using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        Task t = DisplayResultAsync();
        t.Wait();
        Console.ReadLine();
    }
    static async Task DisplayResultAsync()
    {
        int num = 5;

        int result = await FactorialAsync(num);
        Thread.Sleep(3000);
        Console.WriteLine("Факториал числа {0} равен {1}", num, result);
    }

    static Task<int> FactorialAsync(int x)
    {
        int result = 1;

        return Task.Run(() =>
        {
            for (int i = 1; i <= x; i++)
            {
                result *= i;
            }
            return result;
        });
    }
}