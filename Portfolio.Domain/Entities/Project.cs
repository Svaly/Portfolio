using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Portfolio.Domain.Entities
{
    public class Project
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display (Name = "Tytuł")]
        [Required(ErrorMessage = "Wpisz tytuł")]
        [DataType(DataType.Text)]
        public string Title { get; set; }

        [Display(Name = "Kategoria")]
        [Required(ErrorMessage = "Wpisz kategorię")]
        [DataType(DataType.Text)]
        public string Category { get; set; }

        [Display(Name = "Opis")]
        [Required(ErrorMessage = "Wpisz opis")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "Data realizacji")]
        [Required(ErrorMessage = "Wprowadź datę realizacji")]
        [DataType(DataType.Date)]
        public DateTime RealizationDate { get; set; }

        [Display(Name = "Data dodania")]
        public DateTime AddedDate { get; set; }

        [Display(Name = "Data ostatniej edycji")]
        public DateTime LastEditDate { get; set; }

        [Display(Name = "Aktywny")]
        public string Active { get; set; }

       
    }
}
