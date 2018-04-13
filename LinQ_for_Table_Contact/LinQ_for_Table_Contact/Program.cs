using System;
using System.Collections.Generic;
using System.Linq;

namespace LinQ_for_Table_Contact
{
    class Programs
    {
        static void Main()
        {

            List<Contact> contactsList = new List<Contact>
            {
                new Contact("Alfreds Futterkiste", "Maria Anders", "Germany"),
                new Contact("Centro commercial Moctezuma", "Francisco Chang", "Mexico"),
                new Contact("Ernst Handel", "Rolan Mendel", "Ausria"),
                new Contact("Island Trading", "Helen Bennett", "UK"),
                new Contact("Laughing Bacchuss Winecellars", "Yoshi Tannamuri", "Canada"),
                new Contact("Magazzini Alimentari Riuniti", "Giovanni Rovelli", "Italy"),
                new Contact("Island Trading", "Maria Mendel", "USA")
            };


            IEnumerable<string> contacts = contactsList.Where(c => c.Company.Equals("Island Trading"))
                .Where(c => c.Country.StartsWith("U"))
                .Select(c => c.Company).Distinct();

            foreach (var contact in contacts)
            {
                Console.WriteLine($"Company: {contact}");
                Console.WriteLine("--------------------");
            }

            Console.ReadLine();
        }
    }
}
