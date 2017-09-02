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
                                join p in context.HistoriaClinicas on c.IdHistoriaClinica equals p.Id
                                join e in context.Empleados on c.IdEmpleado equals e.Id
                                join u in context.Personas on e.IdPersona equals u.Id
                                join pa in context.Pacientes on p.IdPaciente equals pa.Id
                              select c)
                    .Include(c => c.HistoriaClinica)
                    .Include(c => c.Empleado)
                    .Include(e => e.Empleado.Persona)
                    .Include(e => e.HistoriaClinica.Paciente)
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
