using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RestoranNikolic.Projekat.Models
{
    public class Zakazivanje
    {
        [Key]
        [Required(ErrorMessage = "ID je obavezan za unos!")]
        [DisplayName("ID")]
        public int ZakazivanjeID { get; set; }
        [Required(ErrorMessage = "ID je obavezan za unos!")]
        [ForeignKey("Meni")]
        [DisplayName("ID")]
        public int MeniID { get; set; }
        [Required(ErrorMessage = "Ime je obavezno za unos!")]
        [StringLength(10)]
        [DisplayName("Unesite Vaše ime")]
        public string Ime { get; set; }
        [Required(ErrorMessage = "Prezime je obavezno za unos!")]
        [StringLength(10)]
        [DisplayName("Unesite Vaše prezime")]
        public string Prezime { get; set; }
        [Required(ErrorMessage = "Broj telefona je obavezan za unos!")]
        [StringLength(10)]
        [DisplayName("Unesite Vaš broj telefona")]
        public string BrojTelefona { get; set; }
        [Required(ErrorMessage = "Datum je obavezan za unos!")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Datum { get; set; }

        public ICollection<Meni> Meni { get; set; }

        virtual public Lokacije Lokacije { get; set; }
    }
}