using System;
using ClinicaData;
using ClinicaEntity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ClinicaBussines
{
    public class TipoAtencionBl
    {
        private static volatile TipoAtencionBl _instance;
        private static readonly object SyncRoot = new Object();

        private TipoAtencionBl() { }

        public static TipoAtencionBl Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (SyncRoot)
                    {
                        if (_instance == null)
                            _instance = new TipoAtencionBl();
                    }
                }
                return _instance;
            }
        }

        public List<TipoAtencion> List()
        {
            using (var context = new DataContext())
            {
                return context.TipoAtenciones.ToList();
            }
        }
    }
}
