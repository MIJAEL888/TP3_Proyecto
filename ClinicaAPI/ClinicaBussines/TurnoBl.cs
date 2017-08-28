using ClinicaData;
using ClinicaEntity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ClinicaBussines
{
    public class TurnoBl
    {
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
