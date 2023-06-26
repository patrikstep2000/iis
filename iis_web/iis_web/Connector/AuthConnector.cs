using iis_web.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace iis_web.Connector
{
    public static class AuthConnector
    {
        private static RestClient client = new RestClient(new RestClientOptions("http://localhost:8080"));

        public async static Task<Token>Login(string username, string password)
        {
            User user = new User(username, password);
            var request = new RestRequest("authenticate");
            request.AddJsonBody(user);

            string t = (await client.PostAsync(request)).Content;

            Token token = JsonConvert.DeserializeObject<Token>(t);

            return token;
        }
    }
}