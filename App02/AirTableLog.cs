using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App02
{
    class AirTableLog : ILog
    {

        private const string apiKey = "keyTKhNKuIEE0HYqd";
        private RestClient client = new RestClient("https://api.airtable.com/v0/appNBmB71JjXSxBkm/LogItems");


        public void Write(string message)
        {
            RestRequest req = CreateRequest(message);
            client.Execute(req);
        }

        private static RestRequest CreateRequest(string message)
        {
            var req = new RestRequest(Method.POST);

            req.AddHeader("Authorization", $"Bearer {apiKey}");
            req.AddHeader("Content-Type", "application/json");

            req.AddJsonBody(new
            {
                fields = new
                {
                    Name = message
                }
            });
            return req;
        }

    }
}