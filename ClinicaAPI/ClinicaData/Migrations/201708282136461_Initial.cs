namespace ClinicaData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cita",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EstadoCita = c.Int(nullable: false),
                        Observacion = c.String(),
                        IdDoctor = c.Int(nullable: false),
                        IdTurno = c.Int(nullable: false),
                        IdPaciente = c.Int(nullable: false),
                        IdTipoAtencion = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Doctor", t => t.IdDoctor, cascadeDelete: false)
                .ForeignKey("dbo.Paciente", t => t.IdPaciente, cascadeDelete: false)
                .ForeignKey("dbo.TipoAtencion", t => t.IdTipoAtencion, cascadeDelete: false)
                .ForeignKey("dbo.Turno", t => t.IdTurno, cascadeDelete: false)
                .Index(t => t.IdDoctor)
                .Index(t => t.IdTurno)
                .Index(t => t.IdPaciente)
                .Index(t => t.IdTipoAtencion);
            
            CreateTable(
                "dbo.Doctor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Cargo = c.String(),
                        TipoDocumento = c.String(),
                        NumeroDocumento = c.String(),
                        Sexo = c.String(),
                        Telefono = c.String(),
                        Direccion = c.String(),
                        Correo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Paciente",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        FechaNacimiento = c.DateTime(nullable: false),
                        TipoDocumento = c.String(),
                        NumeroDocumento = c.String(),
                        Sexo = c.String(),
                        Telefono = c.String(),
                        Direccion = c.String(),
                        Correo = c.String(),
                        IdUsuario = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuario", t => t.IdUsuario, cascadeDelete: false)
                .Index(t => t.IdUsuario);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Contrasenia = c.String(),
                        FechaCreacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TipoAtencion",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tipo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Turno",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Observacion = c.String(),
                        FechaInicio = c.DateTime(nullable: false),
                        FechaFin = c.DateTime(nullable: false),
                        EstadoTurno = c.Int(nullable: false),
                        IdDoctor = c.Int(nullable: false),
                        IdSala = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Doctor", t => t.IdDoctor, cascadeDelete: false)
                .ForeignKey("dbo.Sala", t => t.IdSala, cascadeDelete: false)
                .Index(t => t.IdDoctor)
                .Index(t => t.IdSala);
            
            CreateTable(
                "dbo.Sala",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Codigo = c.String(),
                        Ubicacion = c.String(),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cita", "IdTurno", "dbo.Turno");
            DropForeignKey("dbo.Turno", "IdSala", "dbo.Sala");
            DropForeignKey("dbo.Turno", "IdDoctor", "dbo.Doctor");
            DropForeignKey("dbo.Cita", "IdTipoAtencion", "dbo.TipoAtencion");
            DropForeignKey("dbo.Cita", "IdPaciente", "dbo.Paciente");
            DropForeignKey("dbo.Paciente", "IdUsuario", "dbo.Usuario");
            DropForeignKey("dbo.Cita", "IdDoctor", "dbo.Doctor");
            DropIndex("dbo.Turno", new[] { "IdSala" });
            DropIndex("dbo.Turno", new[] { "IdDoctor" });
            DropIndex("dbo.Paciente", new[] { "IdUsuario" });
            DropIndex("dbo.Cita", new[] { "IdTipoAtencion" });
            DropIndex("dbo.Cita", new[] { "IdPaciente" });
            DropIndex("dbo.Cita", new[] { "IdTurno" });
            DropIndex("dbo.Cita", new[] { "IdDoctor" });
            DropTable("dbo.Sala");
            DropTable("dbo.Turno");
            DropTable("dbo.TipoAtencion");
            DropTable("dbo.Usuario");
            DropTable("dbo.Paciente");
            DropTable("dbo.Doctor");
            DropTable("dbo.Cita");
        }
    }
}
