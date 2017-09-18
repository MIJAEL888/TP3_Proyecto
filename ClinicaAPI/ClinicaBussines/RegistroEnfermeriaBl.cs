using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ClinicaData;
using ClinicaEntity;

namespace ClinicaBussines
{
    public class RegistroEnfermeriaBl
    {
        readonly RegistroIngresoBl _registroIngresoBl = RegistroIngresoBl.Instance;
        readonly NivelCriticidadBl _nivelCriticidadBl = NivelCriticidadBl.Instance;

        private static volatile RegistroEnfermeriaBl _instance;
        private static readonly object SyncRoot = new Object();

        private RegistroEnfermeriaBl() { }

        public static RegistroEnfermeriaBl Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (SyncRoot)
                    {
                        if (_instance == null)
                            _instance = new RegistroEnfermeriaBl();
                    }
                }
                return _instance;
            }
        }

        public RegistroEnfermeria Save(RegistroEnfermeria registroEnfermeria)
        {
            using (var context = new DataContext())
            {
                context.RegistroEnfermerias.Add(registroEnfermeria);
                registroEnfermeria.Id =context.SaveChanges();
            }
            return registroEnfermeria;
        }

        public int SaveDetails(RegistroEnfermeriaModel registroEnfermeriaModel)
        {
            var registroEnfermeria = new RegistroEnfermeria
            {
                IdIngresoSalidaPaciente = registroEnfermeriaModel.IdIngresoSalidaPaciente,
                FechaRegistro = DateTime.Now,
                Observacion = "Alguna observacion de la enfermera",
            };


            using (var context = new DataContext())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        // do your changes
                        context.SaveChanges();
                        registroEnfermeria = Save(registroEnfermeria);
                        // do another changes
                        context.SaveChanges();

                        dbContextTransaction.Commit();
                    }
                    catch (Exception)
                    {
                        dbContextTransaction.Rollback();
                    }
                }
               
            }
            return 1;

        }

    }
}
