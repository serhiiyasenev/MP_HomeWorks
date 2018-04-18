using System.Net.Http;
using System.Threading.Tasks;

namespace Responce
{
    class Program
    {
        static void Main(string[] args)
        {

            Task<HttpResponseMessage> requestUri = GetAsync("requestUri");

            var uri = new Task<HttpResponseMessage>();

            Task<HttpResponseMessage> GetAsync(string requestUri)
            {
                return uri;
            }

            HttpClient client = new HttpClient();

            client.GetAsync()

        }
    }
}
