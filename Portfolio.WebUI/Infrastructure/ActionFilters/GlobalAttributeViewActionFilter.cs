using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portfolio.WebUI.Infrastructure.ActionFilters
{
    public class GlobalAttributeViewActionFilter : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            dynamic ViewBag = filterContext.Controller.ViewBag;

            ViewBag.imagePath = "~/images/";
        }


    }
}