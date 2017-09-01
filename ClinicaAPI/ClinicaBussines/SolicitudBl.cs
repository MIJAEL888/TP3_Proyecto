using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicaData;
using ClinicaEntity;

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
                              select c)
                    .Include(c => c.HistoriaClinica)
                    .Include(c => c.Empleado)
                    .Where(c => (int) c.Estado == idEstado)
                    .ToList();

                return result;
            }
        }

        public void Update(Solicitud solicitud)
        {
            using (var context = new DataContext())
            {
                var citaDb = context.Solicitudes.Find(solicitud.Id);
                if (citaDb != null)
                {
                    citaDb.Estado = solicitud.Estado;
                    context.SaveChanges();
                }
            }
        }

        //public void Anular(int idCita)
        //{
        //    using (var context = new DataContext())
        //    {
        //        var citaDb = context.Citas.Find(idCita);
        //        if (citaDb != null)
        //        {
        //            var turnoDb = context.Turnos.Find(citaDb.IdTurno);
        //            if (turnoDb != null)
        //            {
        //                turnoDb.EstadoTurno = EstadoTurno.Libre;
        //            }
        //            citaDb.EstadoCita = EstadoCita.Anulado;
        //            context.SaveChanges();
        //        }
        //    }
        //}
    }
}
