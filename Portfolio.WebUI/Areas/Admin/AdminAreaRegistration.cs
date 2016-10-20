using System.Web;
using System.Web.Mvc;

namespace Portfolio.WebUI.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        { 
           
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "AllProjects", id = UrlParameter.Optional }
            );

            context.MapRoute(
                "Active",
                "Admin/{action}/{id}",
                new { controller = "Projects", id = UrlParameter.Optional }
            );

           

        }
    }
}