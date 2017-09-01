namespace ClinicaData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPersonEmpleado : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Empleado", "IdPersona", c => c.Int(nullable: false));
            CreateIndex("dbo.Empleado", "IdPersona");
            AddForeignKey("dbo.Empleado", "IdPersona", "dbo.Persona", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Empleado", "IdPersona", "dbo.Persona");
            DropIndex("dbo.Empleado", new[] { "IdPersona" });
            DropColumn("dbo.Empleado", "IdPersona");
        }
    }
}
