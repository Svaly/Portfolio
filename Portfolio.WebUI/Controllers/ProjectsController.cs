using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Portfolio.Domain.Abstract;
using Portfolio.WebUI.Controllers;
namespace Portfolio.WebUI.Controllers
{
    public class ProjectsController : Controller
    {
        private IProjectRepository projectRepository;

        public ProjectsController(IProjectRepository projectRepository)
        {
            this.projectRepository = projectRepository;
        }


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AllProjects()
        {
            return PartialView("_ActiveProjects", projectRepository.Projects);
        }
    }
}