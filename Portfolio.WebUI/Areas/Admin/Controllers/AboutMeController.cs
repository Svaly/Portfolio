using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Portfolio.Domain;
using Portfolio.Domain.Abstract;
using Portfolio.WebUI.Areas.Admin.Models;
using Portfolio.WebUI.Infrastructure;

namespace Portfolio.WebUI.Areas.Admin.Controllers
{
    public class AboutMeController : Controller
    {
        private IProfileInfoRepository profileRepository;
        private string imagePath = "~/images/";
        public AboutMeController(IProfileInfoRepository profileRepository)
        {
            this.profileRepository = profileRepository;
        }


        // GET: AboutMe
        public ActionResult Profile()
        {

             Profile profileFromDB = profileRepository.Profile;

             AboutMeViewModel profileToDispaly = new AboutMeViewModel();

            ViewBag.Image = "";
            if (profileFromDB!=null)
            {
                profileToDispaly.Description = profileFromDB.Description;
                profileToDispaly.Name = profileFromDB.Name;
                profileToDispaly.Surname = profileFromDB.Surname;
                ViewBag.Image = profileFromDB.Image;
            }

            return View("AboutMe", profileToDispaly);
        }


        public ActionResult Save(AboutMeViewModel model)
        {
       
            var validImageTypes = new string[]
            {
                "image/gif",
                "image/jpeg",
                "image/pjpeg",
                "image/png"
            };

         if (model.ImageUpload != null )
         {
             if (model.ImageUpload.ContentLength > 0 && !validImageTypes.Contains(model.ImageUpload.ContentType))
             {
                    ModelState.AddModelError("ImageUpload", "Please choose either a GIF, JPG or PNG image.");
             }
         }

            if (ModelState.IsValid)
            {
                Profile savedProfile = profileRepository.Profile;

                if (savedProfile == null)
                {
                    return new HttpNotFoundResult();
                }

                savedProfile.Description = model.Description;
                savedProfile.Name = model.Name;
                savedProfile.Surname = model.Surname;

                if (model.ImageUpload != null && model.ImageUpload.ContentLength > 0)
                {
                    if (System.IO.File.Exists(Path.Combine(Server.MapPath(imagePath), savedProfile.Image)))
                        {                   
                            try
                            {
                                System.IO.File.Delete(Path.Combine(Server.MapPath(imagePath), savedProfile.Image));
                            }
                            catch (System.IO.IOException e)
                            {
                            }
                    }


                    string renderedFileName = Path.GetRandomFileName();
                    string fileName = renderedFileName + Path.GetExtension(model.ImageUpload.FileName);
                    string filePath = Path.Combine(Server.MapPath(imagePath), fileName);
                    model.ImageUpload.SaveAs(filePath);
                    savedProfile.Image = fileName;
                }
                profileRepository.SaveProfile(savedProfile);
            }
            return RedirectToAction("Profile");
        }

    }
}