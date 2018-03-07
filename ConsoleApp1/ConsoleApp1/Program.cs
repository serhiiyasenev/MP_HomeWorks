using System;
using System.Text;

class Program
{
    static void Main()
    {
        StringBuilder builder = new StringBuilder("This is an example string that is an example.");
        builder.Replace("an", "the"); // Replaces 'an' with 'the'.
        Console.WriteLine(builder.ToString());
        Console.ReadLine();
    }
}