using ClinicaData;
using ClinicaEntity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ClinicaBussines
{
    public class TipoAtencionBl
    {
        public List<TipoAtencion> List()
        {
            using (var context = new DataContext())
            {
                return context.TipoAtenciones.ToList();
            }
        }
    }
}
