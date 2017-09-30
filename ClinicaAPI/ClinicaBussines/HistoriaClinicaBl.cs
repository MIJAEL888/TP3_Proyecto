using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicaData;
using ClinicaEntity;
using log4net;
using log4net.Core;

namespace ClinicaBussines
{
    public class HistoriaClinicaBl
    {
        private static readonly ILog Log =
            LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private static volatile HistoriaClinicaBl _instance;
        private static readonly object SyncRoot = new Object();

        private HistoriaClinicaBl() { }

        public static HistoriaClinicaBl Instance
        {
            get
            {
                if (_instance != null) return _instance;
                lock (SyncRoot)
                {
                    if (_instance == null)
                        _instance = new HistoriaClinicaBl();
                }
                return _instance;
            }
        }

        public void Update(HistoriaClinica historiaClinica)
        {
            Log.Info("Guradando información de historia.");
            using (var context = new DataContext())
            {
                var historiaDb = context.HistoriaClinicas.Find(historiaClinica.Id);
                if (historiaDb == null) return;
                historiaDb.IdNivelCriticidad = historiaClinica.IdNivelCriticidad;
                context.SaveChanges();
            }
        }
    }
}
