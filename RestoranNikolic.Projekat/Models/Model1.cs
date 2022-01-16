using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace RestoranNikolic.Projekat.Models
{
    public class Model1 : DbContext
    {
        
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Restoran> Restoran_set { get; set; }
        public virtual DbSet<Meni> Meni_set { get; set; }
        public virtual DbSet<Zakazivanje> Zakazivanje_set { get; set; }
        public virtual DbSet<Lokacije> Lokacije_set { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)

        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}