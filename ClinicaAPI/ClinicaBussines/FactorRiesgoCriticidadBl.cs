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
    public class FactorRiesgoCriticidadBl
    {
        private static volatile FactorRiesgoCriticidadBl _instance;
        private static readonly object SyncRoot = new Object();

        private FactorRiesgoCriticidadBl() { }

        public static FactorRiesgoCriticidadBl Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (SyncRoot)
                    {
                        if (_instance == null)
                            _instance = new FactorRiesgoCriticidadBl();
                    }
                }
                return _instance;
            }
        }
        public FactorRiesgoCriticidad Get(string codigo, int valor)
        {
            using (var context = new DataContext())
            {
                var result = (from i in context.FactorRiesgoCriticidades
                              join f in context.FactorRiesgos on i.IdFactorRiesgo equals f.Id
                              join n in context.NivelCriticidades on i.IdNivelCriticidad equals n.Id
                        select i)
                    .Include(c => c.NivelCriticidad)
                    .Include(c => c.FactorRiesgo)
                    .FirstOrDefault(c => c.FactorRiesgo.Codigo == codigo && 
                                 c.ValorMaximo > valor && 
                                 c.ValorMinimo <= valor);
                return result;
            }
        }

    }
}
