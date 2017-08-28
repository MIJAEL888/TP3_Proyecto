using ClinicaData;
using ClinicaEntity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ClinicaBussines
{
    public class UsuarioBl
    {
        public Usuario Get(int idUsuario)
        {
            using (var context = new DataContext())
            {
                return context.Usuarios.Find(idUsuario);
            }
        }
    }
}
