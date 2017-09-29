namespace ClinicaData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorreccionRegistroEnfermeria : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RegistroEnfermeria", "IdHistoriaClinica", "dbo.HistoriaClinica");
            DropIndex("dbo.RegistroEnfermeria", new[] { "IdHistoriaClinica" });
            AddColumn("dbo.RegistroEnfermeriaDetalle", "Valor", c => c.Int(nullable: false));
            AddColumn("dbo.RegistroEnfermeriaDetalle", "ValorString", c => c.String());
            AddColumn("dbo.RegistroEnfermeriaDetalle", "IdRegistroEnfermeria", c => c.Int(nullable: false));
            AddColumn("dbo.RegistroEnfermeriaDetalle", "IdFactorRiesgo", c => c.Int(nullable: false));
            AddColumn("dbo.RegistroEnfermeriaDetalle", "IdNivelCriticidad", c => c.Int(nullable: false));
            AddColumn("dbo.RegistroEnfermeria", "IdIngresoSalidaPaciente", c => c.Int(nullable: false));
            CreateIndex("dbo.RegistroEnfermeriaDetalle", "IdRegistroEnfermeria");
            CreateIndex("dbo.RegistroEnfermeriaDetalle", "IdFactorRiesgo");
            CreateIndex("dbo.RegistroEnfermeriaDetalle", "IdNivelCriticidad");
            CreateIndex("dbo.RegistroEnfermeria", "IdIngresoSalidaPaciente");
            AddForeignKey("dbo.RegistroEnfermeriaDetalle", "IdFactorRiesgo", "dbo.FactorRiesgo", "Id", cascadeDelete: false);
            AddForeignKey("dbo.RegistroEnfermeriaDetalle", "IdNivelCriticidad", "dbo.NivelCriticidad", "Id", cascadeDelete: false);
            AddForeignKey("dbo.RegistroEnfermeria", "IdIngresoSalidaPaciente", "dbo.IngresoSalidaPaciente", "Id", cascadeDelete: false);
            AddForeignKey("dbo.RegistroEnfermeriaDetalle", "IdRegistroEnfermeria", "dbo.RegistroEnfermeria", "Id", cascadeDelete: false);
            DropColumn("dbo.RegistroEnfermeriaDetalle", "Observacion");
            DropColumn("dbo.RegistroEnfermeriaDetalle", "Antecedentes");
            DropColumn("dbo.RegistroEnfermeria", "IdHistoriaClinica");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RegistroEnfermeria", "IdHistoriaClinica", c => c.Int(nullable: false));
            AddColumn("dbo.RegistroEnfermeriaDetalle", "Antecedentes", c => c.String());
            AddColumn("dbo.RegistroEnfermeriaDetalle", "Observacion", c => c.String());
            DropForeignKey("dbo.RegistroEnfermeriaDetalle", "IdRegistroEnfermeria", "dbo.RegistroEnfermeria");
            DropForeignKey("dbo.RegistroEnfermeria", "IdIngresoSalidaPaciente", "dbo.IngresoSalidaPaciente");
            DropForeignKey("dbo.RegistroEnfermeriaDetalle", "IdNivelCriticidad", "dbo.NivelCriticidad");
            DropForeignKey("dbo.RegistroEnfermeriaDetalle", "IdFactorRiesgo", "dbo.FactorRiesgo");
            DropIndex("dbo.RegistroEnfermeria", new[] { "IdIngresoSalidaPaciente" });
            DropIndex("dbo.RegistroEnfermeriaDetalle", new[] { "IdNivelCriticidad" });
            DropIndex("dbo.RegistroEnfermeriaDetalle", new[] { "IdFactorRiesgo" });
            DropIndex("dbo.RegistroEnfermeriaDetalle", new[] { "IdRegistroEnfermeria" });
            DropColumn("dbo.RegistroEnfermeria", "IdIngresoSalidaPaciente");
            DropColumn("dbo.RegistroEnfermeriaDetalle", "IdNivelCriticidad");
            DropColumn("dbo.RegistroEnfermeriaDetalle", "IdFactorRiesgo");
            DropColumn("dbo.RegistroEnfermeriaDetalle", "IdRegistroEnfermeria");
            DropColumn("dbo.RegistroEnfermeriaDetalle", "ValorString");
            DropColumn("dbo.RegistroEnfermeriaDetalle", "Valor");
            CreateIndex("dbo.RegistroEnfermeria", "IdHistoriaClinica");
            AddForeignKey("dbo.RegistroEnfermeria", "IdHistoriaClinica", "dbo.HistoriaClinica", "Id", cascadeDelete: true);
        }
    }
}
