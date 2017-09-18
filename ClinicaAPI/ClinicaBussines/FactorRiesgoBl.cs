using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicaData;
using ClinicaEntity;

namespace ClinicaBussines
{
    public class FactorRiesgoBl
    {
        private static volatile FactorRiesgoBl _instance;
        private static readonly object SyncRoot = new Object();

        private FactorRiesgoBl() { }

        public static FactorRiesgoBl Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (SyncRoot)
                    {
                        if (_instance == null)
                            _instance = new FactorRiesgoBl();
                    }
                }
                return _instance;
            }
        }

        public FactorRiesgo Get(int id)
        {
            using (var context = new DataContext())
            {
                var result = (from i in context.FactorRiesgos
                              select i)
                    .Single(c => c.Id == id);
                return result;
            }
        }
        public FactorRiesgo Get(string codigo)
        {
            using (var context = new DataContext())
            {
                var result = (from i in context.FactorRiesgos
                              select i)
                    .Single(c => c.Codigo == codigo);
                return result;
            }
        }
    }
}
