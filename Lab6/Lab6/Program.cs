using System;
using System.Linq;
using System.Reflection;

namespace Lab6
{
    public abstract class Animal
    {
        public string Color { get; set; }
        public float Weight { get; set; }

        public Animal(string color, float weight)
        {
            Color = color;
            Weight = weight;
        }

        public abstract string MakeSound();
    }

    public abstract class AnimalWithTail : Animal
    {
        public float TailLength { get; set; }

        public AnimalWithTail(string color, float weight, float tailLength) : base(color, weight)
        {
            Color = color;
            Weight = weight;
            TailLength = tailLength;
        }
    }

    public class Cat : AnimalWithTail
    {
        public Cat(string color, float weight, float tailLength) : base(color, weight, tailLength)
        {
        }

        private string Purr()
        {
            string purrrrrrrr = "purrrrrrrr";
            return purrrrrrrr;
        }

        private string Meow()
        {
            string meow = "Meow";
            return meow;
        }

        public override string MakeSound()
        {
            return Purr() + Meow();
        }

        public override string ToString()
        {
            string thisCatToString = $"This is a Cat, Color = {Color}, Weight = {Weight}, TailLength = {TailLength}";
            return thisCatToString;
        }
    }

    public class Dog : AnimalWithTail
    {
        public Dog(string color, float weight, float tailLength) : base(color, weight, tailLength)
        {
        }

        public override string MakeSound()
        {
            string dogSound = "Woof";
            return dogSound;
        }

        public override string ToString()
        {
            string thisDogToString = $"This is a Dog, Color = {Color}, Weight = {Weight}, TailLength = {TailLength}";
            return thisDogToString;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            PrintClassInfo(typeof(Animal));
            PrintClassInfo(typeof(AnimalWithTail));
            PrintClassInfo(typeof(Cat));
            PrintClassInfo(typeof(Dog));
            Console.WriteLine(new Cat("Balck", 2, 1));
            Console.WriteLine(new Dog("Brown", 5, 2));
            Console.ReadKey();
        }

        private static void PrintClassInfo(Type type)
        {
            var props = type.GetProperties();
            var fields = type.GetFields().Concat(type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)).ToArray();
            var constructors = type.GetConstructors();
            var methods = type.GetMethods();

            var sortLambda =
                new Func<MemberInfo, MemberInfo, int>(
                    (first, second) =>
                            String.Compare(first.Name, second.Name, StringComparison.Ordinal));
            Array.Sort(props, sortLambda.Invoke);
            Array.Sort(fields, sortLambda.Invoke);
            Array.Sort(constructors, sortLambda.Invoke);
            Array.Sort(methods, sortLambda.Invoke);
            foreach (var propertyInfo in props)
            {
                Console.WriteLine(
                    $"{propertyInfo.Name}, {propertyInfo.PropertyType}, {propertyInfo.CanRead}, {propertyInfo.CanWrite}");
            }
            foreach (var fieldInfo in fields)
            {
                Console.WriteLine(
                    $"{fieldInfo.Name}, {fieldInfo.FieldType}, {fieldInfo.IsPrivate}, {fieldInfo.IsPublic}, {fieldInfo.IsStatic}, {fieldInfo.IsInitOnly}, {fieldInfo.IsLiteral}");
            }
            foreach (var constructorInfo in constructors)
            {
                Console.WriteLine(
                    $"{constructorInfo.Name}, {constructorInfo.DeclaringType}, {constructorInfo.IsPublic}, {string.Join(", ", constructorInfo.GetParameters().ToArray<object>())}");
            }
            foreach (var methodInfo in methods)
            {
                Console.WriteLine(
                    $"{methodInfo.Name}, {methodInfo.DeclaringType}, {methodInfo.IsPublic}, {string.Join(", ", methodInfo.GetParameters().ToArray<object>())}");
            }
        }
    }
}