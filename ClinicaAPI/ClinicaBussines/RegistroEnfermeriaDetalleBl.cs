using System;
using System.Collections.Generic;
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
    }
}
