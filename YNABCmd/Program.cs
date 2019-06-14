using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace YNABCmd
{
    class Program
    {
        static void Main(string[] args)
        {
            string accessToken = "878dc3ab1201afce375c017cc4c935c6f69d4515934a752f3286f16a40f772ff";

            Console.WriteLine("Hello World!");

            HttpClient _client = new HttpClient();
            _client.BaseAddress = new Uri("https://api.youneedabudget.com/v1/");
            _client.DefaultRequestHeaders.Authorization
                         = new AuthenticationHeaderValue("Bearer", accessToken);

            _client.Dispose();
        }
    }
}
