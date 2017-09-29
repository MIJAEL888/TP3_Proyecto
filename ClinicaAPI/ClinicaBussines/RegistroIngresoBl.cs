using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicaData;
using ClinicaEntity;
using ClinicaUtil;

namespace ClinicaBussines
{
    public class RegistroIngresoBl
    {
        private static volatile RegistroIngresoBl _instance;
        private static readonly object SyncRoot = new Object();

        private RegistroIngresoBl() { }

        public static RegistroIngresoBl Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (SyncRoot)
                    {
                        if (_instance == null)
                            _instance = new RegistroIngresoBl();
                    }
                }
                return _instance;
            }
        }

        public List<IngresoSalidaPaciente> List(int idEstado)
        {
            using (var context = new DataContext())
            {
                var result = (from i in context.IngresoSalidaPacientes
                              join cm in context.Camas on i.IdCama equals cm.Id
                              join c in context.Solicitudes on i.IdSolicitud equals c.Id
                              join h in context.HistoriaClinicas on c.IdHistoriaClinica equals h.Id
                              join n in context.NivelCriticidades on h.IdNivelCriticidad equals n.Id
                              join d in context.Diagnosticos on h.IdDiagnostico equals d.Id
                              join t in context.Tratamientos on h.IdTratamiento equals t.Id
                              join pa in context.Pacientes on h.IdPaciente equals pa.Id
                              join e in context.Empleados on c.IdEmpleado equals e.Id
                              join p in context.Personas on e.IdPersona equals p.Id
                              select i)
                    .Include(c => c.Cama)
                    .Include(c => c.Solicitud)
                    .Include(c => c.Solicitud.HistoriaClinica)
                    .Include(c => c.Solicitud.HistoriaClinica.Paciente)
                    .Include(c => c.Solicitud.HistoriaClinica.Diagnostico)
                    .Include(c => c.Solicitud.HistoriaClinica.Tratamiento)
                    .Include(c => c.Solicitud.HistoriaClinica.NivelCriticidad)
                    .Include(c => c.Solicitud.Empleado)
                    .Include(e => e.Solicitud.Empleado.Persona)
                    .Where(c => (int)c.Estado == idEstado)
                    .ToList();

                return result;
            }
        }

        public List<IngresoSalidaPaciente> List(int idEstado, string nombre)
        {
            using (var context = new DataContext())
            {
                var result = (from i in context.IngresoSalidaPacientes
                        join cm in context.Camas on i.IdCama equals cm.Id
                        join c in context.Solicitudes on i.IdSolicitud equals c.Id
                        join h in context.HistoriaClinicas on c.IdHistoriaClinica equals h.Id
                        join n in context.NivelCriticidades on h.IdNivelCriticidad equals n.Id
                        join d in context.Diagnosticos on h.IdDiagnostico equals d.Id
                        join t in context.Tratamientos on h.IdTratamiento equals t.Id
                        join pa in context.Pacientes on h.IdPaciente equals pa.Id
                        join e in context.Empleados on c.IdEmpleado equals e.Id
                        join p in context.Personas on e.IdPersona equals p.Id
                        select i)
                    .Include(c => c.Cama)
                    .Include(c => c.Solicitud)
                    .Include(c => c.Solicitud.HistoriaClinica)
                    .Include(c => c.Solicitud.HistoriaClinica.Paciente)
                    .Include(c => c.Solicitud.HistoriaClinica.Diagnostico)
                    .Include(c => c.Solicitud.HistoriaClinica.Tratamiento)
                    .Include(c => c.Solicitud.HistoriaClinica.NivelCriticidad)
                    .Include(c => c.Solicitud.Empleado)
                    .Include(e => e.Solicitud.Empleado.Persona)
                    .Where(c => c.Solicitud.HistoriaClinica.Paciente.Nombre.Contains(nombre) && (int)c.Estado == idEstado)
                    .ToList();

                return result;
            }
        }

        public IngresoSalidaPaciente Get(int id)
        {
            using (var context = new DataContext())
            {
                var result = (from i in context.IngresoSalidaPacientes
                        join cm in context.Camas on i.IdCama equals cm.Id
                        join c in context.Solicitudes on i.IdSolicitud equals c.Id
                        join h in context.HistoriaClinicas on c.IdHistoriaClinica equals h.Id
                        join n in context.NivelCriticidades on h.IdNivelCriticidad equals n.Id
                        join d in context.Diagnosticos on h.IdDiagnostico equals d.Id
                        join t in context.Tratamientos on h.IdTratamiento equals t.Id
                        join pa in context.Pacientes on h.IdPaciente equals pa.Id
                        join e in context.Empleados on c.IdEmpleado equals e.Id
                        join p in context.Personas on e.IdPersona equals p.Id
                        select i)
                    .Include(c => c.Cama)
                    .Include(c => c.Solicitud)
                    .Include(c => c.Solicitud.HistoriaClinica)
                    .Include(c => c.Solicitud.HistoriaClinica.Paciente)
                    .Include(c => c.Solicitud.HistoriaClinica.Diagnostico)
                    .Include(c => c.Solicitud.HistoriaClinica.Tratamiento)
                    .Include(c => c.Solicitud.HistoriaClinica.NivelCriticidad)
                    .Include(c => c.Solicitud.Empleado)
                    .Include(e => e.Solicitud.Empleado.Persona)
                    .Single(c => c.Id == id);
                return result;
            }
        }

        public void Save(IngresoSalidaPaciente ingresoSalida)
        {
            using (var context = new DataContext())
            {
                context.IngresoSalidaPacientes.Add(ingresoSalida);
                context.SaveChanges();
            }
        }
    }
}
