using System;
using System.Collections.Generic;
using System.Linq;

namespace LinQ
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] teams = { "Бавария", "Боруссия", "Реал Мадрид", "Манчестер Сити", "ПСЖ", "Барселона" };

            IOrderedEnumerable<string> selectedTeams = from t in teams // определяем каждый объект из teams как t
                                                       where t.ToUpper().StartsWith("Б") //фильтрация по критерию
                                                       orderby t  // упорядочиваем по возрастанию
                                                       select t; // выбираем объект

            IEnumerable<string> selectedClubs = teams.Where(t => t.ToUpper().StartsWith("Б")).
                Select(t => t).OrderByDescending(t => t);

            int numberInSelectedTeams = (from t in teams where t.ToUpper().StartsWith("Б") select t).Count();

            int numberInSelectedClubs = teams.Count(t => t.ToUpper().StartsWith("Б"));

            foreach (string t in selectedTeams)
            {
                Console.WriteLine($"selectedTeams: {t}");
            }
            Console.WriteLine("--------------------------");
            foreach (string c in selectedClubs)
            {
                Console.WriteLine($"selectedClubs: {c}");
            }
            Console.WriteLine("--------------------------");

            Console.WriteLine($"numberInSelectedTeams: {numberInSelectedTeams}");
            Console.WriteLine($"numberInSelectedClubs: {numberInSelectedClubs}");

            Console.ReadKey();
        }
    }
}