namespace RestoranNikolic.Projekat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Prvi : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Lokacije",
                c => new
                    {
                        LokacijeID = c.Int(nullable: false, identity: true),
                        ZakazivanjeID = c.Int(nullable: false),
                        Mesto = c.String(nullable: false, maxLength: 30),
                        BrojTelefona = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.LokacijeID);
            
            CreateTable(
                "dbo.Zakazivanje",
                c => new
                    {
                        ZakazivanjeID = c.Int(nullable: false, identity: true),
                        MeniID = c.Int(nullable: false),
                        Ime = c.String(nullable: false, maxLength: 10),
                        Prezime = c.String(nullable: false, maxLength: 10),
                        BrojTelefona = c.String(nullable: false, maxLength: 10),
                        Datum = c.DateTime(nullable: false),
                        Lokacije_LokacijeID = c.Int(),
                    })
                .PrimaryKey(t => t.ZakazivanjeID)
                .ForeignKey("dbo.Lokacije", t => t.Lokacije_LokacijeID)
                .Index(t => t.Lokacije_LokacijeID);
            
            CreateTable(
                "dbo.Meni",
                c => new
                    {
                        MeniID = c.Int(nullable: false, identity: true),
                        RestoranID = c.Int(nullable: false),
                        Pasta = c.String(nullable: false, maxLength: 25),
                        Pizza = c.String(nullable: false, maxLength: 25),
                        Rostilj = c.String(nullable: false, maxLength: 25),
                        Alkohol = c.String(nullable: false, maxLength: 25),
                        Kafa = c.String(nullable: false, maxLength: 25),
                        BezalkoholnaPica = c.String(nullable: false, maxLength: 25),
                        Cena = c.String(nullable: false, maxLength: 25),
                        Zakazivanje_ZakazivanjeID = c.Int(),
                    })
                .PrimaryKey(t => t.MeniID)
                .ForeignKey("dbo.Zakazivanje", t => t.Zakazivanje_ZakazivanjeID)
                .Index(t => t.Zakazivanje_ZakazivanjeID);
            
            CreateTable(
                "dbo.Restoran",
                c => new
                    {
                        RestoranID = c.Int(nullable: false, identity: true),
                        Ime = c.String(nullable: false, maxLength: 25),
                        Meni_MeniID = c.Int(),
                    })
                .PrimaryKey(t => t.RestoranID)
                .ForeignKey("dbo.Meni", t => t.Meni_MeniID)
                .Index(t => t.Meni_MeniID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Zakazivanje", "Lokacije_LokacijeID", "dbo.Lokacije");
            DropForeignKey("dbo.Meni", "Zakazivanje_ZakazivanjeID", "dbo.Zakazivanje");
            DropForeignKey("dbo.Restoran", "Meni_MeniID", "dbo.Meni");
            DropIndex("dbo.Restoran", new[] { "Meni_MeniID" });
            DropIndex("dbo.Meni", new[] { "Zakazivanje_ZakazivanjeID" });
            DropIndex("dbo.Zakazivanje", new[] { "Lokacije_LokacijeID" });
            DropTable("dbo.Restoran");
            DropTable("dbo.Meni");
            DropTable("dbo.Zakazivanje");
            DropTable("dbo.Lokacije");
        }
    }
}
