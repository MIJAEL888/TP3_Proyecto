using ClinicaData;
using ClinicaEntity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ClinicaBussines
{
    public class PacienteBl
    {
        public List<Paciente> List(int idUsuario)
        {
            using (var context = new DataContext())
            {
                var pacientes = context.Pacientes
                    .Where(c => c.IdUsuario.Equals(idUsuario))
                    .Include(t => t.Usuario)
                    .ToList();
                return pacientes;
            }
        }
    }
}
