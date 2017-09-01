namespace ClinicaData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSolicitud : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Area",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Cama",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FechaAdquisicion = c.DateTime(nullable: false),
                        Descripcion = c.String(),
                        AppMedica = c.String(),
                        Garantia = c.String(),
                        Tipo = c.String(),
                        Marca = c.String(),
                        Modelo = c.String(),
                        Estado = c.String(),
                        IdInmueble = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Inmueble", t => t.IdInmueble, cascadeDelete: false)
                .Index(t => t.IdInmueble);
            
            CreateTable(
                "dbo.Inmueble",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FechaAdquisicion = c.DateTime(nullable: false),
                        DesInmueble = c.String(),
                        DesTipo = c.String(),
                        Estado = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Diagnostico",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                        IdEmpleado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Empleado", t => t.IdEmpleado, cascadeDelete: false)
                .Index(t => t.IdEmpleado);
            
            CreateTable(
                "dbo.Empleado",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FechaIngreso = c.DateTime(nullable: false),
                        Cargo = c.String(),
                        CorreoInst = c.String(),
                        Profesion = c.String(),
                        IdEspecialidad = c.Int(nullable: false),
                        IdArea = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Area", t => t.IdArea, cascadeDelete: false)
                .ForeignKey("dbo.Especialidad", t => t.IdEspecialidad, cascadeDelete: false)
                .Index(t => t.IdEspecialidad)
                .Index(t => t.IdArea);
            
            CreateTable(
                "dbo.Especialidad",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FactorRiesgoCriticidad",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ValorMaximo = c.Int(nullable: false),
                        ValorMinimo = c.Int(nullable: false),
                        IdFactorRiesgo = c.Int(nullable: false),
                        IdNivelCriticidad = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FactorRiesgo", t => t.IdFactorRiesgo, cascadeDelete: false)
                .ForeignKey("dbo.NivelCriticidad", t => t.IdNivelCriticidad, cascadeDelete: false)
                .Index(t => t.IdFactorRiesgo)
                .Index(t => t.IdNivelCriticidad);
            
            CreateTable(
                "dbo.FactorRiesgo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                        ValorMinimo = c.Int(nullable: false),
                        ValorMaximo = c.Int(nullable: false),
                        Codigo = c.String(),
                        Unidades = c.String(),
                        Grupo = c.String(),
                        CodUnidades = c.Int(nullable: false),
                        Padre = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NivelCriticidad",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                        Codigo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HistoriaClinica",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FechaRegistro = c.DateTime(nullable: false),
                        Observacion = c.String(),
                        GrupoSangineo = c.String(),
                        IdDiagnostico = c.Int(nullable: false),
                        IdTratamiento = c.Int(nullable: false),
                        IdPaciente = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Diagnostico", t => t.IdDiagnostico, cascadeDelete: false)
                .ForeignKey("dbo.Paciente", t => t.IdPaciente, cascadeDelete: false)
                .ForeignKey("dbo.Tratamiento", t => t.IdTratamiento, cascadeDelete: false)
                .Index(t => t.IdDiagnostico)
                .Index(t => t.IdTratamiento)
                .Index(t => t.IdPaciente);
            
            CreateTable(
                "dbo.Tratamiento",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IngresoSalidaPaciente",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FechaIngreso = c.DateTime(nullable: false),
                        FechaSalida = c.DateTime(nullable: false),
                        Motivo = c.String(),
                        Estado = c.String(),
                        IdCama = c.Int(nullable: false),
                        IdSolicitud = c.Int(nullable: false),
                        IdPaciente = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cama", t => t.IdCama, cascadeDelete: false)
                .ForeignKey("dbo.Paciente", t => t.IdPaciente, cascadeDelete: false)
                .ForeignKey("dbo.Solicitud", t => t.IdSolicitud, cascadeDelete: false)
                .Index(t => t.IdCama)
                .Index(t => t.IdSolicitud)
                .Index(t => t.IdPaciente);
            
            CreateTable(
                "dbo.Solicitud",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FechaRegistro = c.DateTime(nullable: false),
                        Observacion = c.String(),
                        IdHistoriaClinica = c.Int(nullable: false),
                        IdEmpleado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Empleado", t => t.IdEmpleado, cascadeDelete: false)
                .ForeignKey("dbo.HistoriaClinica", t => t.IdHistoriaClinica, cascadeDelete: false)
                .Index(t => t.IdHistoriaClinica)
                .Index(t => t.IdEmpleado);
            
            CreateTable(
                "dbo.Persona",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        TipoDocumento = c.String(),
                        NumeroDocumento = c.String(),
                        Sexo = c.String(),
                        Telefono = c.String(),
                        Direccion = c.String(),
                        Correo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RegistroEnfermeriaDetalle",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FechaRegistro = c.DateTime(nullable: false),
                        Observacion = c.String(),
                        Antecedentes = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RegistroEnfermeria",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FechaRegistro = c.DateTime(nullable: false),
                        Observacion = c.String(),
                        Antecedentes = c.String(),
                        IdHistoriaClinica = c.Int(nullable: false),
                        IdPaciente = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HistoriaClinica", t => t.IdHistoriaClinica, cascadeDelete: false)
                .ForeignKey("dbo.Paciente", t => t.IdPaciente, cascadeDelete: false)
                .Index(t => t.IdHistoriaClinica)
                .Index(t => t.IdPaciente);
            
            AddColumn("dbo.Paciente", "Estado", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RegistroEnfermeria", "IdPaciente", "dbo.Paciente");
            DropForeignKey("dbo.RegistroEnfermeria", "IdHistoriaClinica", "dbo.HistoriaClinica");
            DropForeignKey("dbo.IngresoSalidaPaciente", "IdSolicitud", "dbo.Solicitud");
            DropForeignKey("dbo.Solicitud", "IdHistoriaClinica", "dbo.HistoriaClinica");
            DropForeignKey("dbo.Solicitud", "IdEmpleado", "dbo.Empleado");
            DropForeignKey("dbo.IngresoSalidaPaciente", "IdPaciente", "dbo.Paciente");
            DropForeignKey("dbo.IngresoSalidaPaciente", "IdCama", "dbo.Cama");
            DropForeignKey("dbo.HistoriaClinica", "IdTratamiento", "dbo.Tratamiento");
            DropForeignKey("dbo.HistoriaClinica", "IdPaciente", "dbo.Paciente");
            DropForeignKey("dbo.HistoriaClinica", "IdDiagnostico", "dbo.Diagnostico");
            DropForeignKey("dbo.FactorRiesgoCriticidad", "IdNivelCriticidad", "dbo.NivelCriticidad");
            DropForeignKey("dbo.FactorRiesgoCriticidad", "IdFactorRiesgo", "dbo.FactorRiesgo");
            DropForeignKey("dbo.Diagnostico", "IdEmpleado", "dbo.Empleado");
            DropForeignKey("dbo.Empleado", "IdEspecialidad", "dbo.Especialidad");
            DropForeignKey("dbo.Empleado", "IdArea", "dbo.Area");
            DropForeignKey("dbo.Cama", "IdInmueble", "dbo.Inmueble");
            DropIndex("dbo.RegistroEnfermeria", new[] { "IdPaciente" });
            DropIndex("dbo.RegistroEnfermeria", new[] { "IdHistoriaClinica" });
            DropIndex("dbo.Solicitud", new[] { "IdEmpleado" });
            DropIndex("dbo.Solicitud", new[] { "IdHistoriaClinica" });
            DropIndex("dbo.IngresoSalidaPaciente", new[] { "IdPaciente" });
            DropIndex("dbo.IngresoSalidaPaciente", new[] { "IdSolicitud" });
            DropIndex("dbo.IngresoSalidaPaciente", new[] { "IdCama" });
            DropIndex("dbo.HistoriaClinica", new[] { "IdPaciente" });
            DropIndex("dbo.HistoriaClinica", new[] { "IdTratamiento" });
            DropIndex("dbo.HistoriaClinica", new[] { "IdDiagnostico" });
            DropIndex("dbo.FactorRiesgoCriticidad", new[] { "IdNivelCriticidad" });
            DropIndex("dbo.FactorRiesgoCriticidad", new[] { "IdFactorRiesgo" });
            DropIndex("dbo.Empleado", new[] { "IdArea" });
            DropIndex("dbo.Empleado", new[] { "IdEspecialidad" });
            DropIndex("dbo.Diagnostico", new[] { "IdEmpleado" });
            DropIndex("dbo.Cama", new[] { "IdInmueble" });
            DropColumn("dbo.Paciente", "Estado");
            DropTable("dbo.RegistroEnfermeria");
            DropTable("dbo.RegistroEnfermeriaDetalle");
            DropTable("dbo.Persona");
            DropTable("dbo.Solicitud");
            DropTable("dbo.IngresoSalidaPaciente");
            DropTable("dbo.Tratamiento");
            DropTable("dbo.HistoriaClinica");
            DropTable("dbo.NivelCriticidad");
            DropTable("dbo.FactorRiesgo");
            DropTable("dbo.FactorRiesgoCriticidad");
            DropTable("dbo.Especialidad");
            DropTable("dbo.Empleado");
            DropTable("dbo.Diagnostico");
            DropTable("dbo.Inmueble");
            DropTable("dbo.Cama");
            DropTable("dbo.Area");
        }
    }
}
