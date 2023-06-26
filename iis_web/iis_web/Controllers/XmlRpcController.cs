using iis_web.Connector;
using iis_web.Models;
using iis_web.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace iis_web.Controllers
{
    [JwtFilter]
    public class XmlRpcController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(SubmitModel model)
        {
            if(ModelState.IsValid) 
            {
                string temp = await XmlRpcConnector.GetCityTemp(model.Term);
                ViewBag.City = model.Term;
                ViewBag.Temp = temp;
            }
            return View();
        }
    }
}