namespace ClinicaData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSeedInfo : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RegistroEnfermeria", "IdPaciente", "dbo.Paciente");
            DropIndex("dbo.RegistroEnfermeria", new[] { "IdPaciente" });
            DropColumn("dbo.RegistroEnfermeria", "IdPaciente");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RegistroEnfermeria", "IdPaciente", c => c.Int(nullable: false));
            CreateIndex("dbo.RegistroEnfermeria", "IdPaciente");
            AddForeignKey("dbo.RegistroEnfermeria", "IdPaciente", "dbo.Paciente", "Id", cascadeDelete: false);
        }
    }
}
