using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestoranNikolic.Projekat.Models
{
    public class Restoran
    {
        [Key]
        [Required(ErrorMessage = "ID je obavezan za unos!")]
        public int RestoranID { get; set; }
        [Required(ErrorMessage = "Ime restorana je obavezno za unos!")]
        [StringLength(25)]
        public string Ime { get; set; }

        virtual public Meni Meni { get; set; }
    }
}