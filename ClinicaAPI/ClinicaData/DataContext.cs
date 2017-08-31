using ClinicaEntity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaData
{
    public class DataContext : DbContext
    {
        public DbSet<TipoAtencion> TipoAtenciones { get; set; }
        public DbSet<Sala> Salas { get; set; }
        public DbSet<Doctor> Doctores { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Turno> Turnos { get; set; }
        public DbSet<Cita> Citas { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Cama> Camas { get; set; }
        public DbSet<Diagnostico> Diagnosticos { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Especialidad> Especialidades { get; set; }
        public DbSet<FactorRiesgo> FactorRiesgos { get; set; }
        public DbSet<FactorRiesgoCriticidad> FactorRiesgoCriticidades { get; set; }
        public DbSet<HistoriaClinica> HistoriaClinicas { get; set; }
        public DbSet<IngresoSalidaPaciente> IngresoSalidaPacientes { get; set; }
        public DbSet<Inmueble> Inmuebles { get; set; }
        public DbSet<NivelCriticidad> NivelCriticidades { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<RegistroEnfermeria> RegistroEnfermerias { get; set; }
        public DbSet<RegistroEnfermeriaDetalle> RegistroEnfermeriaDetalles { get; set; }
        public DbSet<Solicitud> Solicituds{ get; set; }
        public DbSet<Tratamiento> Tratamientos { get; set; }

        public DataContext(): base("ClinicaDb") 
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
