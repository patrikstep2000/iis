using iis_web.Models;
using iis_web.Utils;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Serialization;

namespace iis_web.Connector
{
    public static class MainConnector
    {
        private static RestClient client = new RestClient(new RestClientOptions("http://localhost:8080"));

        public async static Task<bool> PostCharacterXml(string url, Character character, Token token)
        {
            try
            {
                var request = new RestRequest(url);
                request.AddHeader("Authorization", $"Bearer {token.Value}");
                string charXml = XmlUtils.Serialize(character);
                request.AddBody(charXml);
                request.AddHeader("Content-Type", "text/xml");
                var res = await client.PostAsync(request);

                return res.IsSuccessful;
            }
            catch
            {
                return false;
            }
        }

        public async static Task<List<T>> GetList<T>(string url, Token token)
        {
            var request = new RestRequest(url);
            request.AddHeader("Authorization", $"Bearer {token.Value}");
            return JsonConvert.DeserializeObject<List<T>>((await client.GetAsync(request)).Content);
        }

        public async static Task<bool> Validate(Token token)
        {
            var request = new RestRequest("xml/validate");
            request.AddHeader("Authorization", $"Bearer {token.Value}");
            return bool.Parse((await client.GetAsync(request)).Content);
        }
    }
}