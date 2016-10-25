using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.HtmlControls;
using Portfolio.Domain.Abstract;
using Portfolio.Domain;

namespace Portfolio.WebUI.Controllers
{
    public class ImagesController : Controller
    {
        private IImageRepository imageRepository;
        private string imagePath = "~/images/";

        public ImagesController(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }


        // GET: Images
        public ActionResult ProjectThumbnail(int projectId)
        {
            Images image =imageRepository.Images.FirstOrDefault(i => i.ProjectId == projectId);

            if (image != null)
            {
                string imgLink = imagePath + image.ThumbnailName;
                return Content(imgLink);
            }
            return Content("");
        }
    }
}