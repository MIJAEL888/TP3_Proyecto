using System;
using ClinicaData;
using ClinicaEntity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ClinicaBussines
{
    public class UsuarioBl
    {
        private static volatile UsuarioBl _instance;
        private static readonly object SyncRoot = new Object();

        private UsuarioBl() { }

        public static UsuarioBl Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (SyncRoot)
                    {
                        if (_instance == null)
                            _instance = new UsuarioBl();
                    }
                }
                return _instance;
            }
        }

        public Usuario Get(int idUsuario)
        {
            using (var context = new DataContext())
            {
                return context.Usuarios.Find(idUsuario);
            }
        }
    }
}
