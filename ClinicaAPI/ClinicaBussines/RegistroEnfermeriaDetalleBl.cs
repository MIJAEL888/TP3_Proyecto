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
    public class RegistroEnfermeriaDetalleBl
    {
        private static volatile RegistroEnfermeriaDetalleBl _instance;
        private static readonly object SyncRoot = new Object();

        private RegistroEnfermeriaDetalleBl() { }

        public static RegistroEnfermeriaDetalleBl Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (SyncRoot)
                    {
                        if (_instance == null)
                            _instance = new RegistroEnfermeriaDetalleBl();
                    }
                }
                return _instance;
            }
        }

        public void Save(RegistroEnfermeriaDetalle registroEnfermeriaDetalle)
        {
            using (var context = new DataContext())
            {
                context.RegistroEnfermeriaDetalles.Add(registroEnfermeriaDetalle);
                context.SaveChanges();
            }
        }
        public RegistroEnfermeriaDetalle Get(int idRegistro, string codigoFactor)
        {
            using (var context = new DataContext())
            {
                var result = (from i in context.RegistroEnfermeriaDetalles
                        join f in context.FactorRiesgos on i.IdFactorRiesgo equals f.Id
                        join n in context.NivelCriticidades on i.IdNivelCriticidad equals  n.Id
                        select i)
                    .Include(c => c.FactorRiesgo)
                    .Include(c => c.NivelCriticidad)
                    .SingleOrDefault(c => c.IdRegistroEnfermeria == idRegistro && c.FactorRiesgo.Codigo.Equals(codigoFactor));
                return result;
            }
        }

        public List<RegistroEnfermeriaDetalle> List(int idRegistroIngreso)
        {
            using (var context = new DataContext())
            {
                var result = (from d in context.RegistroEnfermeriaDetalles
                            join r in context.RegistroEnfermerias on d.IdRegistroEnfermeria equals r.Id
                            join i in context.IngresoSalidaPacientes on r.IdIngresoSalidaPaciente equals i.Id
                            join f in context.FactorRiesgos on d.IdFactorRiesgo equals f.Id
                            join n in context.NivelCriticidades on d.IdNivelCriticidad equals n.Id 
                            select d)
                    .Include(c => c.RegistroEnfermeria).Include(c => c.RegistroEnfermeria.IngresoSalidaPaciente)
                    .Include(c => c.FactorRiesgo).Include(e => e.NivelCriticidad)
                    .Where(c => c.RegistroEnfermeria.IdIngresoSalidaPaciente == idRegistroIngreso)
                    .ToList();
                return result;
            }
        }

        
    }
}
