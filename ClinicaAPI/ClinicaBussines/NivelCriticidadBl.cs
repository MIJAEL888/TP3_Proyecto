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
    public class NivelCriticidadBl
    {
        private static volatile NivelCriticidadBl _instance;
        private static readonly object SyncRoot = new Object();

        private NivelCriticidadBl() { }

        public static NivelCriticidadBl Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (SyncRoot)
                    {
                        if (_instance == null)
                            _instance = new NivelCriticidadBl();
                    }
                }
                return _instance;
            }
        }

        public NivelCriticidad Get(int id)
        {
            using (var context = new DataContext())
            {
                var result = (from i in context.NivelCriticidades
                              select i)
                    .Single(c => c.Id == id);
                return result;
            }
        }

        public NivelCriticidad Get(string codigo)
        {
            using (var context = new DataContext())
            {
                var result = (from i in context.NivelCriticidades
                              select i)
                    .Single(c => c.Codigo == codigo);
                return result;
            }
        }

        public NivelCriticidad Get(string codigo, int valor)
        {
            using (var context = new DataContext())
            {
                var result = (from i in context.NivelCriticidades
                        select i)
                    .Single(c => c.Codigo == codigo);
                return result;
            }
        }
    }
}
