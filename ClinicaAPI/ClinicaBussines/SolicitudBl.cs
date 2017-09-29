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
    public class SolicitudBl
    {
        private static volatile SolicitudBl _instance;
        private static readonly object SyncRoot = new Object();

        private SolicitudBl() { }

        public static SolicitudBl Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (SyncRoot)
                    {
                        if (_instance == null)
                            _instance = new SolicitudBl();
                    }
                }
                return _instance;
            }
        }

        public List<Solicitud> List()
        {
            using (var context = new DataContext())
            {
                return context.Solicitudes.ToList();
            }
        }

        public List<Solicitud> List(int idEstado)
        {
            using (var context = new DataContext())
            {
                var result = (from c in context.Solicitudes
                                join h in context.HistoriaClinicas on c.IdHistoriaClinica equals h.Id
                                join pa in context.Pacientes on h.IdPaciente equals pa.Id
                                join e in context.Empleados on c.IdEmpleado equals e.Id
                                join p in context.Personas on e.IdPersona equals p.Id
                              select c)
                    .Include(c => c.HistoriaClinica).Include(c => c.HistoriaClinica.Paciente)
                    .Include(c => c.Empleado).Include(e => e.Empleado.Persona)
                    .Where(c => (int) c.Estado == idEstado)
                    .ToList();

                return result;
            }
        }

        public void Update(Solicitud solicitud)
        {
            using (var context = new DataContext())
            {
                var solicitudDb = context.Solicitudes.Find(solicitud.Id);
                if (solicitudDb != null)
                {
                    solicitudDb.Estado = solicitud.Estado;
                    context.SaveChanges();
                }
            }
        }

        public void Aprobar(int idSolicitud, int idCama)
        {
            using (var context = new DataContext())
            {
                var solicitudDb = context.Solicitudes.Find(idSolicitud);
                if (solicitudDb != null)
                {
                    var camaDb = context.Camas.Find(idCama);
                    if (camaDb != null)
                    {
                        camaDb.Estado = EstadoCama.Ocupado;

                        IngresoSalidaPaciente ingresoSalidaPaciente = new IngresoSalidaPaciente();
                        ingresoSalidaPaciente.IdCama = camaDb.Id;
                        ingresoSalidaPaciente.IdSolicitud = solicitudDb.Id;
                        ingresoSalidaPaciente.Estado = EstadoRegistroIngreso.Activado;
                        ingresoSalidaPaciente.FechaIngreso = DateTime.Now;
                        ingresoSalidaPaciente.Motivo = "Aprobacion de solicitud de ingreso.";
                        ingresoSalidaPaciente.FechaSalida =  DateTime.Now;
                        context.IngresoSalidaPacientes.Add(ingresoSalidaPaciente);
                    }
                    solicitudDb.Estado = EstadoSolicitud.Aprobado;
                    context.SaveChanges();
                }
            }
        }

        public void DesAprobar(int idSolicitud)
        {
            using (var context = new DataContext())
            {
                var solicitudDb = context.Solicitudes.Find(idSolicitud);
                if (solicitudDb != null)
                {
                    solicitudDb.Estado = EstadoSolicitud.Rechazado;
                    context.SaveChanges();
                }
            }
        }
    }
}
