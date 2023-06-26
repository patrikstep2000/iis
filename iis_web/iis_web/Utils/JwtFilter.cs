using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace iis_web.Utils
{
    public class JwtFilter : ActionFilterAttribute, IActionFilter
    {
        private static List<string> PUBLIC_ROUTES = new List<string>() { "Login", "Logout" };

        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!PUBLIC_ROUTES.Contains(filterContext.ActionDescriptor.ActionName))
            {
                string token = string.Empty;
                HttpCookie cookie = filterContext.HttpContext.Request.Cookies.Get("AuthToken");
                if(cookie != null) {
                    token += cookie.Value;
                };
                if (!JwtUtils.IsValid(token))
                {
                    FormsAuthentication.SignOut();
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary{ { "controller", "Auth" }, { "action", "Login" } });
                }
            }

            base.OnActionExecuting(filterContext);
        }
    }
}