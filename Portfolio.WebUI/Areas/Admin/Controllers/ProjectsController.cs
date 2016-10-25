using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Portfolio.Domain;
using Portfolio.Domain.Abstract;
using Portfolio.WebUI.Infrastructure;
using Portfolio.Domain.Infrastructure;


namespace Portfolio.WebUI.Areas.Admin.Controllers
{
    public class ProjectsController : Controller
    {
        private IProjectRepository projectRepository;

        public ProjectsController(IProjectRepository projectRepository)
        {
            this.projectRepository = projectRepository;
        }

        // GET: Home
        public ActionResult AllProjects()
        {
            return View(projectRepository.Projects);
        }    

        public ActionResult Create()
        {
            return View("Create", new Projects());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save([Bind(Include = "ID,Title,Category,Description,RealizationDate,AddedDate,LastEditDate,Active ")]Projects project)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Projects savedProject = projectRepository.SaveProject(project);
                    TempData["message_succes"] = string.Format("Zapisano {0}", project.Title);
                    return RedirectToAction("EditProject", new { controller = "Projects", action = "EditProject", projectId = savedProject.Id });
                }
            }
            catch (FailedInsertException ex)
            {
                TempData["message_warning"] = string.Format("{0} {1} spróbuj ponownie", ex.Message, project.Title);
                
            }
                return View("Create", project);
        }

        [HttpParamAction]
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult EditProject(int projectId)
        {
            Projects project = projectRepository.Projects.FirstOrDefault(p => p.Id == projectId);
            return View("Create", project);
        }

        [HttpParamAction]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Activate(int projectId )
        {
   
           Projects project = projectRepository.Projects.FirstOrDefault(p => p.Id == projectId);
            if (ModelState.IsValid && project!=null)
            {
                projectRepository.Activate(project);               
            }
            return RedirectToAction("AllProjects");
        }

        [HttpParamAction]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Deactivate(int projectId )
        {
         Projects project = projectRepository.Projects.FirstOrDefault(p => p.Id == projectId);
            if (ModelState.IsValid && project != null)
            {
                projectRepository.Deactivate(project);
            }
            return RedirectToAction("AllProjects");
        }

    }
}