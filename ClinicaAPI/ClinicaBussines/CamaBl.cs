using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicaData;
using ClinicaEntity;
using ClinicaUtil;

namespace ClinicaBussines
{
    public class CamaBl
    {
        private static volatile CamaBl _instance;
        private static readonly object SyncRoot = new Object();

        private CamaBl() { }

        public static CamaBl Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (SyncRoot)
                    {
                        if (_instance == null)
                            _instance = new CamaBl();
                    }
                }
                return _instance;
            }
        }

        public List<Cama> List()
        {
            using (var context = new DataContext())
            {
                return context.Camas.ToList();
            }
        }

        public List<Cama> List(int idEstado)
        {
            using (var context = new DataContext())
            {
                var result = (from c in context.Camas
                        select c)
                    .Where(c => (int) c.Estado == idEstado)
                    .ToList();

                return result;
            }
        }
    }
}
