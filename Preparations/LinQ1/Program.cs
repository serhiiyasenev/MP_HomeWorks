using System;
using System.Collections.Generic;
using System.Linq;

namespace LinQ1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<User> users = new List<User>
            {
                new User {Name="Том", Age=23, Languages = new List<string> {"английский", "немецкий" }},
                new User {Name="Боб", Age=27, Languages = new List<string> {"английский", "французский" }},
                new User {Name="Джон", Age=29, Languages = new List<string> {"английский", "испанский" }},
                new User {Name="Элис", Age=24, Languages = new List<string> {"испанский", "немецкий" }}
            };

            IEnumerable<User> selectedUsers = users.Where(u => u.Age > 25);

            IEnumerable<User> selectMany = users.Where(u => u.Age > 23 && u.Languages.Contains("испанский"));

            foreach (User user in selectedUsers)
                Console.WriteLine("{0} - {1}", user.Name, user.Age);

            Console.WriteLine("--------------------");

            foreach (User user in selectMany)
                Console.WriteLine("{0} - {1} - {2}", user.Name, user.Languages[0], user.Languages[1]);

            Console.ReadKey();
        }
    }
}