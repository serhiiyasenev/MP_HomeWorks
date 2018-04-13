using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static BlockingCollection<int> bc;

        static void producer()
        {
            for (int i = 0; i < 100; i++)
            {
                bc.Add(i * i);
                Console.WriteLine("Производится число " + i * i);
            }
            bc.CompleteAdding();
        }

        static void consumer()
        {
            int i;
            while (!bc.IsCompleted)
            {
                if (bc.TryTake(out i))
                    Console.WriteLine("Потребляется число: " + i);
            }
        }

        static void Main()
        {
            bc = new BlockingCollection<int>(4);

            // Создадим задачи поставщика и потребителя
            Task Pr = new Task(producer);
            Task Cn = new Task(consumer);

            // Запустим задачи
            Pr.Start();
            Cn.Start();

            try
            {
                Task.WaitAll(Cn, Pr);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                Cn.Dispose();
                Pr.Dispose();
                bc.Dispose();
            }

            Console.ReadLine();
        }
    }
}