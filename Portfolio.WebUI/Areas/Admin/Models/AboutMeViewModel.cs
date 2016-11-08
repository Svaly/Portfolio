using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Portfolio.WebUI.Areas.Admin.Models
{
    public class AboutMeViewModel
    {

        [Display(Name = "Imię")]
        [Required(ErrorMessage = "Wpisz imię")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Display(Name = "Nazwisko")]
        [Required(ErrorMessage = "Wpisz nazwisko")]
        [DataType(DataType.Text)]
        public string Surname { get; set; }

        [Display(Name = "Opis")]
        [Required(ErrorMessage = "Wpisz opis")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "Wybierz nową grafikę")]
        [DataType(DataType.Upload)]
        public HttpPostedFileBase ImageUpload { get; set; }

    }
}