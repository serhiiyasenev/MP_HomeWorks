using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HttpClient
{
    public class Program
    {
        public static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                Test(); //async, passes through immediately
            }
            Console.WriteLine("FIRST"); //prints sooner than pages
            Thread.Sleep(TimeSpan.FromSeconds(5)); //just to get the output from Test()
            Console.ReadKey();
        }

        static async void Test()
        {
            string r = await DownloadPage("http://stackoverflow.com");
            Console.WriteLine("-----------------------");

            StringBuilder builder = new StringBuilder(r);
            string r1 = builder.ToString().Substring(150, 151);
            Console.WriteLine(r1);
        }

        static async Task<string> DownloadPage(string url)
        {
            using (var client = new System.Net.Http.HttpClient())
            {
                using (var r = await client.GetAsync(new Uri(url)))
                {
                    string result = await r.Content.ReadAsStringAsync();

                    return result;
                }
            }
        }
    }
}