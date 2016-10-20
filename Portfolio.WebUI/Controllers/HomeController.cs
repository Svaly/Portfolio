using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Portfolio.Domain.Abstract;
using Portfolio.Domain.Entities;

namespace Portfolio.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IProjectRepository projectRepository;

        public HomeController(IProjectRepository projectRepository)
        {
            this.projectRepository = projectRepository;
        }

        // GET: Home
        public ActionResult Index()
        {
            return View(projectRepository.Projects);
        }
    }
}