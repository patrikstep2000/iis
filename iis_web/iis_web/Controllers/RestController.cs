using iis_web.Connector;
using iis_web.Models;
using iis_web.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace iis_web.Controllers
{
    [JwtFilter]
    public class RestController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> XSD()
        {
            Token token = new Token { Value = Request.Cookies.Get("AuthToken").Value };
            var locations = await MainConnector.GetList<Location>("locations",token);
            var episodes = await MainConnector.GetList<Episode>("episodes", token);

            ViewBag.Locations = locations.ConvertAll(l => new SelectListItem()
            {
                Text = l.Name,
                Value = l.ID.ToString(),
                Selected = false
            });

            ViewBag.Episodes = episodes.ConvertAll(e => new SelectListItem()
            {
                Text = e.Name,
                Value = e.ID.ToString(),
                Selected = false
            });

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> XSD(Character character)
        {
            Token token = new Token { Value = Request.Cookies.Get("AuthToken").Value };

            bool success = await MainConnector.PostCharacterXml("character/xsd", character, token);

            if(success)
            {
                return Json("OK");
            }

            return Json("NG");
        }

        [HttpGet]
        public async Task<ActionResult> RNG()
        {
            Token token = new Token { Value = Request.Cookies.Get("AuthToken").Value };
            var locations = await MainConnector.GetList<Location>("locations", token);
            var episodes = await MainConnector.GetList<Episode>("episodes", token);

            ViewBag.Locations = locations.ConvertAll(l => new SelectListItem()
            {
                Text = l.Name,
                Value = l.ID.ToString(),
                Selected = false
            });

            ViewBag.Episodes = episodes.ConvertAll(e => new SelectListItem()
            {
                Text = e.Name,
                Value = e.ID.ToString(),
                Selected = false
            });

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> RNG(Character character)
        {
            Token token = new Token { Value = Request.Cookies.Get("AuthToken").Value };

            bool success = await MainConnector.PostCharacterXml("character/rng", character, token);

            if (success)
            {
                return Json("OK");
            }

            return Json("NG");
        }
    }
}