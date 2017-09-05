namespace ClinicaData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStateRegistroIngreso : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.IngresoSalidaPaciente", "IdPaciente", "dbo.Paciente");
            DropIndex("dbo.IngresoSalidaPaciente", new[] { "IdPaciente" });
            AlterColumn("dbo.IngresoSalidaPaciente", "Estado", c => c.Int(nullable: false));
            DropColumn("dbo.IngresoSalidaPaciente", "IdPaciente");
        }
        
        public override void Down()
        {
            AddColumn("dbo.IngresoSalidaPaciente", "IdPaciente", c => c.Int(nullable: false));
            AlterColumn("dbo.IngresoSalidaPaciente", "Estado", c => c.String());
            CreateIndex("dbo.IngresoSalidaPaciente", "IdPaciente");
            AddForeignKey("dbo.IngresoSalidaPaciente", "IdPaciente", "dbo.Paciente", "Id", cascadeDelete: false);
        }
    }
}
