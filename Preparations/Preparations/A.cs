using System;

namespace Preparations
{
    public class A
    {
        public virtual void Foo()
        {
            Console.WriteLine("Class A - virtual void");
        }
    }
    public class B : A
    {
        public override void Foo()
        {
            Console.WriteLine("Class B - override void");
        }
    }
}