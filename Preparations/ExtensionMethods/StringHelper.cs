using System;

namespace ExtensionMethods
{
    public static class StringHelper
    {
        // метод WordCount принимает на вход строку, возвращает число слов, 
        // т.е. число подстрок, разделённых пробелом, точкой или вопросительным знаком.

        public static int WordCount(this string str)
        {
            return str.Split(new[] { ' ', '.', '?', '!' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }
    }
}