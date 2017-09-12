using System;
using ClinicaData;
using ClinicaEntity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ClinicaBussines
{
    public class PacienteBl
    {
        private static volatile PacienteBl _instance;
        private static readonly object SyncRoot = new Object();

        private PacienteBl() { }

        public static PacienteBl Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (SyncRoot)
                    {
                        if (_instance == null)
                            _instance = new PacienteBl();
                    }
                }
                return _instance;
            }
        }

        public List<Paciente> List(int idUsuario)
        {
            using (var context = new DataContext())
            {
                var pacientes = context.Pacientes
                    .Where(c => c.IdUsuario.Equals(idUsuario))
                    .Include(t => t.Usuario)
                    .ToList();
                return pacientes;
            }
        }
    }
}
