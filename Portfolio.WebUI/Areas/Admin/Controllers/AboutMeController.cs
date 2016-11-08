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
            if (profileFromDB != null)
            {
                profileToDispaly.Description = profileFromDB.Description;
                profileToDispaly.Name = profileFromDB.Name;
                profileToDispaly.Surname = profileFromDB.Surname;
                ViewBag.Image = profileFromDB.Image;
            }

            return View("AboutMe", profileToDispaly);
        }

        [HttpPost]
        public ActionResult Save(AboutMeViewModel profileToSave)
        {
            if (ModelState.IsValid)
            {
                Profile editedProfile = profileRepository.Profile;

                if (profileToSave.ImageUpload != null)
                {
                    try
                    {
                        ImageIsValid(profileToSave);
                        if (editedProfile.Image != null)
                        {
                            DeleteOldImage(editedProfile.Image);
                        }
                        editedProfile.Image = SaveNewImage(profileToSave);
                    }
                    catch (Exception ex)
                    {
                        TempData["message_warning"] = String.Format("{0}, spróbuj ponownie", ex.Message);
                        return RedirectToAction("Profile");
                    }
                }
                else
                {
                    editedProfile.Image = "";
                }           
                editedProfile.Description = profileToSave.Description;
                editedProfile.Name = profileToSave.Name;
                editedProfile.Surname = profileToSave.Surname;

                profileRepository.SaveProfile(editedProfile);
                TempData["message_succes"] = "Zapisano pomyślnie";
            }
            return RedirectToAction("Profile");
        }





        public void ImageIsValid(AboutMeViewModel model)
        {
            var validImageTypes = new string[]
            {
                "image/gif",
                "image/jpeg",
                "image/pjpeg",
                "image/png"
            };
            if (model.ImageUpload.ContentLength > 0 && !validImageTypes.Contains(model.ImageUpload.ContentType))
            {
                throw new InvalidDataException("Nieprawidłowe rozszeżenie pliku");
            }
            
        }

        public void DeleteOldImage(string imgName)
        {
            if (System.IO.File.Exists(Path.Combine(Server.MapPath(imagePath), imgName)))
            {
                try
                {
                    System.IO.File.Delete(Path.Combine(Server.MapPath(imagePath), imgName));
                }
                catch (System.IO.IOException e)
                {
                    throw new IOException("Błąd zmiany zdjęcia");
                }
            }
         
        }

        public string SaveNewImage(AboutMeViewModel model)
        {       
                string renderedFileName = Path.GetRandomFileName();
                string fileName = renderedFileName + Path.GetExtension(model.ImageUpload.FileName);
                string filePath = Path.Combine(Server.MapPath(imagePath), fileName);
                model.ImageUpload.SaveAs(filePath);
            return fileName;
            }
        }


    }
