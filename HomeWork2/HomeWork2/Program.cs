using System;

namespace HomeWork2
{
    class Program
    {
        public static void Main(string[] args)
        {
            int i = 100;
            string s = "Hello, world";

            Console.WriteLine("Before, i = " + i);
            i = ChangeInt(i);
            Console.WriteLine("After, i = " + i);

            Console.WriteLine("Before, s = " + s);
            s = ChangeString(s);
            Console.WriteLine("After, s = " + s);

            string s1 = "Hello, world.         ";
            s1 = s1.Trim();
            Console.WriteLine(s1 + " I was trimmed!");

            int ii = 123;
            object o = ii;
            //implicit boxing

            ii = 456;
            o = ii;
            //update

            Console.WriteLine("The value-type value = {0}", ii);
            Console.WriteLine("The object-type value = {0}", o);

            int x = 10000;
            Int16 y = (Int16)x;
            Console.WriteLine(y);
        }
        static int ChangeInt(int i)
        {
            i = 99;
            return i;
        }
        static string ChangeString(string s)
        {
            s = "Hello, I've been changed.";
            return s;
        }
    }
}

// Чему равно значение переменой i до вызова функции ChangeInt?  - 100
// После вызова? 100 
// Почему? потому, что не перприсваиваем (тут изменил код чтоб переприсвоить)

// Чему равно значение переменной s до вызова функции ChangeString? - "Hello, world"
// После вызова? "Hello, world"
// Почему? потому, что не перприсваиваем (тут изменил код чтоб переприсвоить)


//- Какие типы являются типами-значениями(value types)? - Целочисленные, decimal, bool, float, double, enum, struct;

//- Какие типы являются типами-ссылками(reference-types)? - object, string, class, interface, delegate

//- Какие различия между типами-значениями и типами-сылками? - Ссылочные типы хранятся в куче, в стеке будут храниться значимые

//Неизменяемость означает, что после того, как конструктор объекта завершил выполнение, этот экземпляр не может быть изменен.
//Это полезно, поскольку это означает, что вы можете передавать ссылки на объект вокруг, не беспокоясь о том, что кто-то другой 
//изменит его содержимое.Особенно при работе с concurrency нет проблем с блокировкой объектов, которые никогда не меняются.

//Concurrency: Если внутренняя структура неизменяемого объекта действительна, она всегда будет действительна. Нет никаких шансов, 
//что разные потоки могут создать недопустимое состояние внутри этого объекта.Следовательно, неизменяемыми объектами являются Thread Safe.

//Перечисление(enumeration) — это определяемый пользователем целочисленный тип.Когда вы объявляете перечисление, 
//то специфицируете набор допустимых значений, которые могут принимать экземпляры перечислений.