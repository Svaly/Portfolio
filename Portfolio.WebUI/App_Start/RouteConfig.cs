using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Portfolio.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
   
            routes.MapRoute("Home", "{controller}/{action}/{id}", new { controller = "Home", action = "Index", id = UrlParameter.Optional }, new[] { "Portfolio.WebUI.Controllers" });
            routes.MapRoute("AdminHome", "Admin/{controller}/{action}/{id}", new {controller="Home", action = "Index", id = UrlParameter.Optional }, new[] { "Portfolio.WebUI.Areas.Admin.Controllers" });
            
        }
    }
}
