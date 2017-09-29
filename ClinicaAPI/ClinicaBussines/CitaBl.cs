using System;
using ClinicaData;
using ClinicaEntity;
using ClinicaUtil;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ClinicaBussines
{
    public class CitaBl
    {
        private static volatile CitaBl _instance;
        private static readonly object SyncRoot = new Object();

        private CitaBl() { }

        public static CitaBl Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (SyncRoot)
                    {
                        if (_instance == null)
                            _instance = new CitaBl();
                    }
                }
                return _instance;
            }
        }

        public List<Cita> List()
        {
            using (var context = new DataContext())
            {
                return context.Citas.ToList();
            }
        }

        public List<Cita> List(int idUsuario)
        {
            using (var context = new DataContext())
            {
                var result = (from c in context.Citas
                             join p in context.Pacientes on c.IdPaciente equals p.Id
                             join u in context.Usuarios on p.IdUsuario equals u.Id
                             select c)
                             .Include(c => c.Doctor)
                             .Include(c => c.Paciente)
                             .Include(c => c.TipoAtencion)
                             .Include(c => c.Turno)
                             .ToList();

                return result;
            }
        }

        public void Save(Cita cita)
        {
            using (var context = new DataContext())
            {
                context.Citas.Add(cita);
                var turnoDb = context.Turnos.Find(cita.IdTurno);
                if (turnoDb != null)
                {
                    turnoDb.EstadoTurno = EstadoTurno.Asignado;
                }
                context.SaveChanges();
            }
        }

        public void Update(Cita cita)
        {
            using (var context = new DataContext())
            {
                var citaDb = context.Citas.Find(cita.Id);
                if(citaDb != null)
                {
                    citaDb.EstadoCita = cita.EstadoCita;
                    context.SaveChanges();
                }
            }
        }

        public void Anular(int idCita)
        {
            using (var context = new DataContext())
            {
                var citaDb = context.Citas.Find(idCita);
                if (citaDb != null)
                {
                    var turnoDb = context.Turnos.Find(citaDb.IdTurno);
                    if (turnoDb != null)
                    {
                        turnoDb.EstadoTurno = EstadoTurno.Libre;
                    }
                    citaDb.EstadoCita = EstadoCita.Anulado;
                    context.SaveChanges();
                }
            }
        }
    }
}
