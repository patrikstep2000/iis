using Newtonsoft.Json;
using RestSharp;
using SOAP.Models;
using SOAP.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Services;

namespace SOAP.Connector
{
    public static class MainConnector
    {
        private static RestClient client = new RestClient(new RestClientOptions("http://localhost:8080"));
        private static Token token = new Token() { Value = string.Empty};

        public static string getCharactersXML()
        {
            if (!JwtUtils.IsValid(token.Value))
            {
                var tokenRequest = new RestRequest("authenticate");
                tokenRequest.AddBody(new AuthModel() { Password = "admin", Username = "admin"});
                token = JsonConvert.DeserializeObject<Token>(client.Post(tokenRequest).Content);
            }
            var request = new RestRequest("characters");
            request.AddHeader("Authorization", $"Bearer {token.Value}");
            return client.Get(request).Content;
        }
    }
}