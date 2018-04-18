using System;

namespace Preparations
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj1 = new A();
            obj1.Foo();

            B obj2 = new B();
            obj2.Foo();

            A obj3 = new B();
            obj3.Foo();

            Console.ReadKey();
        }
    }
}
