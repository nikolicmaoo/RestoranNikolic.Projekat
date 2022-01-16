using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RestoranNikolic.Projekat.Models
{
    public class Lokacije
    {
        [Key]
        [Required(ErrorMessage = "Unos ID-a je obavezan!")]
        [DisplayName("ID")]
        public int LokacijeID { get; set; }
        [Required(ErrorMessage = "Unos ID-a je obavezan!")]
        [ForeignKey("Zakazivanje")]
        [DisplayName("ID")]
        public int ZakazivanjeID { get; set; }
        [Required(ErrorMessage = "Unos adrese je obavezan!")]
        [StringLength(30)]
        [DisplayName("Adresa")]
        public string Mesto { get; set; }
        [Required(ErrorMessage = "Unos broja telefona je obavezan!")]
        [StringLength(10)]
        [DisplayName("Broj telefona")]
        public string BrojTelefona { get; set; }

        public ICollection<Zakazivanje> Zakazivanje { get; set; }
    }
}