using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Text;
using System.Threading.Tasks;

using test.integration.common.WebApi;

namespace test.webform.ui.Utilities
{
    static public class AsyncRestClient
    {
        public static async Task<string> GetRequest(string baseRequestUri, string contentType)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(contentType));

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

        public static async Task<string> RunRequest(string baseRequestUri, string contentType, HttpVerb method)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(contentType));

                HttpResponseMessage response;

                switch (method)
                {
                    case HttpVerb.GET:
                        response = await client.GetAsync(baseRequestUri); break;
                    default:
                        throw new NotImplementedException("This operation is not yet implemented.");
                }

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