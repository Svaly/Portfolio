using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System;
using System.Collections.Generic;

namespace Portfolio.Domain
{ 
    public partial class Projects
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Projects()
        {
            this.Images = new HashSet<Images>();
        }

        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Tytu³")]
        [Required(ErrorMessage = "Wpisz tytu³")]
        [DataType(DataType.Text)]
        public string Title { get; set; }

        [Display(Name = "Kategoria")]
        [Required(ErrorMessage = "Wpisz kategoriê")]
        [DataType(DataType.Text)]
        public string Category { get; set; }

        [Display(Name = "Opis")]
        [Required(ErrorMessage = "Wpisz opis")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "Data realizacji")]
        [Required(ErrorMessage = "WprowadŸ datê realizacji")]
        [DataType(DataType.Date)]
        public System.DateTime RealizationDate { get; set; }

        [Display(Name = "Data dodania")]
        public System.DateTime AddedDate { get; set; }

        [Display(Name = "Data ostatniej edycji")]
        public System.DateTime LastEditDate { get; set; }

        [Display(Name = "Aktywny")]
        public string Active { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Images> Images { get; set; }
    }
}
