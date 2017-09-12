using System;
using ClinicaData;
using ClinicaEntity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ClinicaUtil;

namespace ClinicaBussines
{
    public class TurnoBl
    {
        private static volatile TurnoBl _instance;
        private static readonly object SyncRoot = new Object();

        private TurnoBl() { }

        public static TurnoBl Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (SyncRoot)
                    {
                        if (_instance == null)
                            _instance = new TurnoBl();
                    }
                }
                return _instance;
            }
        }

        public List<Turno> List(int idDoctor)
        {
            using (var context = new DataContext())
            {
                var results = (from t in context.Turnos
                               join d in context.Pacientes on t.IdDoctor equals d.Id
                               where t.EstadoTurno == EstadoTurno.Libre
                               select t)
                    .Include(c => c.Doctor)
                    .Include(c => c.Sala)
                    .ToList();
                return results;
            }
        }
    }
}
