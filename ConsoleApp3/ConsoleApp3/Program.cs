using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var employees = new List<Employee>
            {
                new Employee { EmpId = 001, Name = "Tom", Department= "Sales"},
                new Employee { EmpId = 024, Name = "Joan", Department= "HR"},
                new Employee { EmpId = 023, Name = "Fred", Department= "Accounting" },
                new Employee { EmpId = 040, Name = "Mike", Department= "Sales" },
            };

            // Знайти елемент списку, де employee id дорівнює 023
            var match = employees.Find(p => p.EmpId == 023);
            var mathcEmployee = employees.FirstOrDefault(p => p.EmpId == 23);

            Console.WriteLine("empID: {0}\nName: {1}\nDepartment: {2}", match.EmpId, match.Name, match.Department);
            Console.WriteLine("--------------------------");
            Console.WriteLine("empID: {0}\nName: {1}\nDepartment: {2}", mathcEmployee?.EmpId, mathcEmployee?.Name, mathcEmployee?.Department);
            Console.ReadKey();
        }
    }

    internal class Employee
    {
        public int EmpId;
        public string Name;
        public string Department;
    }
}