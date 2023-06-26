using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using System.Xml;
using System.Xml.Linq;

namespace iis_web.Connector
{
    public static class XmlRpcConnector
    {
        private static RestClient client = new RestClient(new RestClientOptions("http://localhost:3050"));

        public async static Task<string> GetCityTemp(string city)
        {
            var request = new RestRequest();

            string body =
                "<methodCall>" +
                    "<methodName>Grad.getTemperatureByCityName</methodName>" +
                    "<params>" +
                        "<param>" +
                            $"<value><string>{city}</string></value>" +
                        "</param>" +
                    "</params>" +
                "</methodCall>";

            request.AddHeader("Content-Type", "text/xml");
            request.AddBody(body);
            string resXml = (await client.PostAsync(request)).Content;

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(resXml);

            var nsmgr = new XmlNamespaceManager(doc.NameTable);
            nsmgr.AddNamespace("xsl", "http://www.w3.org/1999/XSL/Transform");

            XmlNode node = doc.SelectSingleNode("//Temp", nsmgr);

            if(node != null)
            {
                return node.InnerText;
            }
            else
            {
                return "Error";
            }
            
        }
    }
}