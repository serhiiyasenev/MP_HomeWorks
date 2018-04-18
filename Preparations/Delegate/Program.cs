using System;
using System.Collections.Generic;
using System.Linq;

namespace Delegate
{
    // Создадим делегат
    delegate int IntOperation(int i, int j);

    class Program
    {
        // Организуем ряд методов
        static int Sum(int x, int y)
        {
            return x + y;
        }

        static int Prz(int x, int y)
        {
            return x * y;
        }

        static int Del(int x, int y)
        {
            return x / y;
        }

        static void Main()
        {
            // Сконструируем делегат
            IntOperation op1 = new IntOperation(Sum);

            int result = op1(5, 10);
            Console.WriteLine("Сумма: " + result);

            // Изменим ссылку на метод
            op1 = new IntOperation(Prz);
            result = op1(5, 10);
            Console.WriteLine("Произведение: " + result);

            Console.WriteLine("-----------------------");

            int[] ints = { 1, 2, 3, 4, 5, 6 };

            //  Объявление делегата
            Func<int, bool> GreaterThanTwo = i => i > 2;

            //  Выполнить запрос...
            IEnumerable<int> intsGreaterThanTwo = ints.Where(GreaterThanTwo);

            foreach (int i in intsGreaterThanTwo)
                Console.WriteLine(i);

            Console.WriteLine("-----------------------");

            string[] cars = { "Alfa Romeo", "Aston Martin", "Audi", "Nissan", "Chevrolet",  "Chrysler", "Dodge", "BMW",
                "Ferrari",  "Bentley", "Ford", "Lexus", "Mercedes", "Toyota", "Volvo", "Subaru", "Жигули :)"};

            IEnumerable<string> auto = cars.Concat(cars);

            foreach (string str in auto)
                Console.WriteLine(str);

            Console.ReadLine();
        }
    }
}