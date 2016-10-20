using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Portfolio.Domain.Abstract;
using Portfolio.Domain.Entities;
using Portfolio.WebUI.Infrastructure;

namespace Portfolio.WebUI.Areas.Admin.Controllers
{
    public class ImagesController : Controller
    {

        private IImageRepository imageRepository;
        private string imagePath = "~/images/";

        public ImagesController(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }
        
        public ActionResult ProjectImages(int id)
        {
            int projectId = id;
            IEnumerable<Image> images = GetImagesByProjectId(projectId);

            if (images.Any())
            {
                return PartialView("ProjectImages", images);
            }
            else
            {
                return null;
            }        
        }

        [HttpPost]
        public ActionResult Delete(int projectId, int Id)
        {    
                Image deletedImage = imageRepository.Delete(Id);
                if (deletedImage != null)
                {
                    TempData["message_succes"] = string.Format("Usunięto {0}", deletedImage.Name);
                }           
            return RedirectToAction("ProjectImages", projectId);
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file, int id)
        {
            int projectId = id;

            if (file != null)
            {
                string renderedFileName = Path.GetRandomFileName();
                string fileName = renderedFileName + Path.GetExtension(file.FileName); 
                string filePath = Path.Combine(Server.MapPath(imagePath), fileName);
                file.SaveAs(filePath);

                string thumbnailName = renderedFileName + "_thumb.jpg";
                string thumbnailPath = Path.Combine(Server.MapPath(imagePath), thumbnailName);

                FileHelper.SaveResizedImage(filePath, thumbnailPath, 150,150);

                Image savedImage = new Image();
                savedImage.ProjectId = projectId;
                savedImage.Name = fileName;
                savedImage.ThumbnailName = thumbnailName;
                
                imageRepository.Add(savedImage);
            }
            return RedirectToAction("EditProject",  new { controller = "Projects", action = "EditProject", projectId = id });
        }

        private IEnumerable<Image> GetImagesByProjectId(int projectId)
        {
            IEnumerable<Image> images = imageRepository.Images.Where(i => i.ProjectId == projectId)
               .OrderBy(i => i.Id)
               .Select(i => new Image { Id = i.Id, ProjectId = i.ProjectId, Name = i.Name, ThumbnailName = i.ThumbnailName })
               .ToList();
            return images;
        }

    }
}