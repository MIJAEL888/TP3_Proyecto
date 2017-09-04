namespace ClinicaData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCriticidadHistoria : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HistoriaClinica", "Peso", c => c.String());
            AddColumn("dbo.HistoriaClinica", "Talla", c => c.String());
            AddColumn("dbo.HistoriaClinica", "IdNivelCriticidad", c => c.Int(nullable: false));
            CreateIndex("dbo.HistoriaClinica", "IdNivelCriticidad");
            AddForeignKey("dbo.HistoriaClinica", "IdNivelCriticidad", "dbo.NivelCriticidad", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HistoriaClinica", "IdNivelCriticidad", "dbo.NivelCriticidad");
            DropIndex("dbo.HistoriaClinica", new[] { "IdNivelCriticidad" });
            DropColumn("dbo.HistoriaClinica", "IdNivelCriticidad");
            DropColumn("dbo.HistoriaClinica", "Talla");
            DropColumn("dbo.HistoriaClinica", "Peso");
        }
    }
}
