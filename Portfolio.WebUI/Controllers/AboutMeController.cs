using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Portfolio.Domain.Abstract;

namespace Portfolio.WebUI.Controllers
{
    public class AboutMeController : Controller
    {
        private IProfileInfoRepository profileRepository;
        public AboutMeController(IProfileInfoRepository profileRepository)
        {
            this.profileRepository = profileRepository;
        }

        public ActionResult Index()
        {

            return View();
        }

        // GET: AboutMe
        public ActionResult GetAboutMe()
        {

            return PartialView("_About",profileRepository.Profile);
        }
    }
}