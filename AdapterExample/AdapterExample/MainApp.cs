using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    class MainApp
    {
        static void Main(string[] args)
        {

            // Create adapter and place a request
            Target target = new Adapter();
            target.Request();

            // Wait for user
            Console.Read();
        }
    }
}
