using System;
using System.Collections.Generic;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            //створення екземпляру класу узагальнення
            CustomList<Coffee> coffeCustomList = new CustomList<Coffee>();
            Coffee coffee1 = new Coffee(1, "Galka", "Ukraine");
            Coffee coffee2 = new Coffee(2, "Nescafe", "Italy");
            coffeCustomList.Add(coffee1);
            coffeCustomList.Add(coffee2);

            CustomList<Tea> teaCustomList = new CustomList<Tea>();
            Tea tea1 = new Tea("Nuri", "Ukraine");
            Tea tea2 = new Tea("Gita", "Ceylon");
            teaCustomList.Add(tea1);
            teaCustomList.Add(tea2);

            foreach (var coffee in coffeCustomList.List)
            {
                Console.WriteLine("Coffe Name: {0}, Coffe Origin: {1}", coffee.Name, coffee.Origin);
            }

            Console.WriteLine("----------------");

            foreach (var tea in teaCustomList.List)
            {
                Console.WriteLine("Tea Name: {0}, Tea Origin: {1}", tea.Name, tea.Origin);
            }

            Console.WriteLine("----------------");

            Console.WriteLine(coffeCustomList.List[0].Name);
            Console.WriteLine(teaCustomList.List[0].Name);

            Console.ReadKey();
        }
    }

    public class CustomList<T> : List<T>
    {
        public readonly IList<T> List = new List<T>();

        public new void Add(T item)
        {
            List.Add(item);
        }
        public new void Remove(T item)
        {
            List.Remove(item);
        }

        public new T this[int i] => List[i];

    }

    public class Coffee
    {
        public int Id;
        public string Name;
        public string Origin;

        public Coffee(int id, string name, string origin)
        {
            Id = id;
            Name = name;
            Origin = origin;
        }
    }

    public class Tea
    {
        public string Name;
        public string Origin;

        public Tea(string name, string origin)
        {
            Name = name;
            Origin = origin;
        }
    }
}