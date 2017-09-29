namespace ClinicaData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDiagnosticoGravedad : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Usuario", "IdPersona", "dbo.Persona");
            DropIndex("dbo.Usuario", new[] { "IdPersona" });
            CreateTable(
                "dbo.DiagnosticoGravedad",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Observacion = c.String(),
                        Detalle = c.String(),
                        FechaRegistro = c.DateTime(nullable: false),
                        IdNivelCriticidad = c.Int(nullable: false),
                        IdEmpleado = c.Int(nullable: false),
                        IdIngresoSalidaPaciente = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Empleado", t => t.IdEmpleado, cascadeDelete: false)
                .ForeignKey("dbo.IngresoSalidaPaciente", t => t.IdIngresoSalidaPaciente, cascadeDelete: false)
                .ForeignKey("dbo.NivelCriticidad", t => t.IdNivelCriticidad, cascadeDelete: false)
                .Index(t => t.IdNivelCriticidad)
                .Index(t => t.IdEmpleado)
                .Index(t => t.IdIngresoSalidaPaciente);
            
            AddColumn("dbo.Usuario", "IdEmpleado", c => c.Int(nullable: false));
            CreateIndex("dbo.Usuario", "IdEmpleado");
            AddForeignKey("dbo.Usuario", "IdEmpleado", "dbo.Empleado", "Id", cascadeDelete: false);
            DropColumn("dbo.Usuario", "IdPersona");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Usuario", "IdPersona", c => c.Int(nullable: false));
            DropForeignKey("dbo.DiagnosticoGravedad", "IdNivelCriticidad", "dbo.NivelCriticidad");
            DropForeignKey("dbo.DiagnosticoGravedad", "IdIngresoSalidaPaciente", "dbo.IngresoSalidaPaciente");
            DropForeignKey("dbo.DiagnosticoGravedad", "IdEmpleado", "dbo.Empleado");
            DropForeignKey("dbo.Usuario", "IdEmpleado", "dbo.Empleado");
            DropIndex("dbo.DiagnosticoGravedad", new[] { "IdIngresoSalidaPaciente" });
            DropIndex("dbo.DiagnosticoGravedad", new[] { "IdEmpleado" });
            DropIndex("dbo.DiagnosticoGravedad", new[] { "IdNivelCriticidad" });
            DropIndex("dbo.Usuario", new[] { "IdEmpleado" });
            DropColumn("dbo.Usuario", "IdEmpleado");
            DropTable("dbo.DiagnosticoGravedad");
            CreateIndex("dbo.Usuario", "IdPersona");
            AddForeignKey("dbo.Usuario", "IdPersona", "dbo.Persona", "Id", cascadeDelete: true);
        }
    }
}
