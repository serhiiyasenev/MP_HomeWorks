using System;

namespace HomeWork4
{
    public static class Calc
    {

        public static int Sum(int n)
        {
            int sum = 0;
            for (int i = 1; i <= n; i++)
            {
                sum += i;
            }
            return sum;
        }

        public static string Terms(int number)
        {
            char[] terms = number.ToString().ToCharArray(0, number.ToString().Length);

            string numbers = null;

            for (int i = 0; i < terms.Length; i++)
            {
                string numberWithComma = terms[i] + ",";
                numbers = numbers + numberWithComma;
            }

            return numbers;
        }

        public static string TheirSum(string number)
        {
            char[] terms = number.ToCharArray(0, number.Length);

            int sum = 0;

            foreach (char valueTerm in terms)
            {
                sum = sum + Convert.ToInt32(Char.GetNumericValue(valueTerm));
            }

            return sum.ToString();
        }
    }
}