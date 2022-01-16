using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RestoranNikolic.Projekat.Models
{
    public class Meni
    {
        [Key]
        [Required(ErrorMessage = "ID je obavezan za unos!")]
        [DisplayName("ID")]
        public int MeniID { get; set; }
        [ForeignKey("Restoran")]
        [Required(ErrorMessage = "ID je obavezan!")]
        [DisplayName("ID")]
        public int RestoranID { get; set; }
        
        [DisplayName("Ime paste")]
        [StringLength(25)]
        [MaxLength(25), MinLength(5)]
        public string Pasta { get; set; }
       
        [DisplayName("Ime pizze")]
        [StringLength(25)]
        [MaxLength(25), MinLength(5)]
        public string Pizza { get; set; }
        
        [DisplayName("Ime rostilja")]
        [StringLength(25)]
        [MinLength(5), MaxLength(25)]
        public string Rostilj { get; set; }
        
        [DisplayName("Ime alkohola")]
        [StringLength(25)]
        [MinLength(5), MaxLength(25)]
        public string Alkohol { get; set; }
        
        [DisplayName("Ime kafe")]
        [StringLength(25)]
        [MinLength(5), MaxLength(25)]
        public string Kafa { get; set; }
  
        [DisplayName("Ime bezalkoholnog pica")]
        [StringLength(25)]
        [MinLength(5), MaxLength(25)]
        public string BezalkoholnaPica { get; set; }
        [Required(ErrorMessage = "Unos je obavezan!")]
        [DisplayName("Cena proizvoda")]
        [Range(100, 2000)]
        public string Cena { get; set; }

        public ICollection<Restoran> Restoran
        {
            get; set;
        }
        virtual public Zakazivanje Zakazivanje { get; set; }
    }
}
    