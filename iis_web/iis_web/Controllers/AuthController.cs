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
    [Authorize]
    public class AuthController : Controller
    {
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login()
        {
            ViewBag.IsValid = true;
            if(User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Rest");
            }
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Login(string username, string password)
        {
            try
            {
                Token t = await AuthConnector.Login(username, password);

                if (t != null)
                {
                    Response.Cookies.Set(new HttpCookie("AuthToken", t.Value));
                    FormsAuthentication.SetAuthCookie(username, true);
                    return RedirectToAction("Index", "Rest");
                }
                ViewBag.IsValid = false;
                return View();
            }
            catch
            {
                ViewBag.IsValid = false;
                return View();
            }
        }

        public ActionResult Logout()
        {
            Response.Cookies.Clear();
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}