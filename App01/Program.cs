using Newtonsoft.Json;
using RestSharp;
using System;

namespace App01
{
    class Program
    {
        static void Main(string[] args)
        {
            var c = new RestClient(new Uri("https://api.github.com"));

            var r = new RestRequest(Method.GET);

            var result =  c.Execute(r);
            dynamic x = JsonConvert.DeserializeObject(result.Content);
            Console.WriteLine(result.Content);
            Console.WriteLine(x["emojis_url"]);
            //Console.WriteLine(x["email_url"]);
        }
    }
}
