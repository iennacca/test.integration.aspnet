using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Text;
using System.Threading.Tasks;

namespace test.webform.ui.Utilities
{
    static public class AsyncRestClient
    {
        public static async Task<string> RunAsync(string baseRequestUri, string contentType)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(contentType));

                // New code:
                HttpResponseMessage response = await client.GetAsync(baseRequestUri);
                if (response.IsSuccessStatusCode)
                {
                    var returnValue = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("{0}", returnValue);
                    return returnValue;
                }
                return String.Empty;
            }
        }
    }
}