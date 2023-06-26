using SOAP.Connector;
using SOAP.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Services;
using System.Xml;
using System.Xml.Linq;

namespace SOAP
{
    /// <summary>
    /// Summary description for Character
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Character : System.Web.Services.WebService
    {
        private const string FILE_PATH = "C:\\Users\\Patrik\\Desktop\\iis\\main_iis\\target\\classes\\characters.xml";

        [WebMethod]
        public string Search(string term)
        {
            string charactersXML = MainConnector.getCharactersXML();
            FileUtils.CreateFile(FILE_PATH, charactersXML);

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(charactersXML);

            XmlNodeList nodes = doc.SelectNodes($"/characters/character[contains(./name, '{term}')]");
            StringBuilder str = new StringBuilder();
            str.Append("<characters>");
            foreach (XmlNode node in nodes)
            {
                str.AppendLine(node.OuterXml);
            }
            str.Append("</characters>");

            return str.ToString();
        }
    }
}
