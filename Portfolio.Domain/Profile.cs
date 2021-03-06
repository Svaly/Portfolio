using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Portfolio.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class Profile
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Imi�")]
        [Required(ErrorMessage = "Wpisz imi�")]
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


        public string Image { get; set; }
    }
}
