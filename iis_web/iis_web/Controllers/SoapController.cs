using iis_web.CharacterSoapService;
using iis_web.Connector;
using iis_web.Models;
using iis_web.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace iis_web.Controllers
{
    [JwtFilter]
    public class SoapController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Index(SubmitModel model)
        {
            if(ModelState.IsValid)
            {
                CharacterSoapClient client = new CharacterSoapClient();
                var xml = client.Search(model.Term);
                Characters characters = XmlUtils.DeserializeXml<Characters>(xml);
                ViewBag.Characters = characters.CharactersList;
            }

            return View();
        }

        [HttpGet]
        public async Task<ActionResult> Validate()
        {
            Token token = new Token { Value = Request.Cookies.Get("AuthToken").Value };
            bool valid = await MainConnector.Validate(token);
            return Json(valid, JsonRequestBehavior.AllowGet);
        }
    }
}