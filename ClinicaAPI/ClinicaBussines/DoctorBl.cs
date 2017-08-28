using ClinicaData;
using ClinicaEntity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ClinicaBussines
{
    public class DoctorBl
    {
        public List<Doctor> List()
        {
            using (var context = new DataContext())
            {
                return context.Doctores
                    .ToList();
            }
        }
    }
}
