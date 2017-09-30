using System;
using ClinicaData;
using ClinicaEntity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using log4net;

namespace ClinicaBussines
{
    public class UsuarioBl
    {
        private static readonly ILog Log =
              LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private static volatile UsuarioBl _instance;
        private static readonly object SyncRoot = new Object();

        private UsuarioBl() { }

        public static UsuarioBl Instance
        {
            get
            {
                if (_instance != null) return _instance;
                lock (SyncRoot)
                {
                    if (_instance == null)
                        _instance = new UsuarioBl();
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

        public Usuario Get(string correoUsuario, string contrasenia)
        {
            Log.Info("Validando credenciales del usuario");
            using (var context = new DataContext())
            {
                var result = (from u in context.Usuarios
                              join r in context.RolUsuarios on u.IdRolUsuario equals r.Id
                              join e in context.Empleados on u.IdEmpleado equals e.Id
                              join p in context.Personas on e.IdPersona equals p.Id
                              select u)
                    .Include(c => c.RolUsuario)
                    .Include(c => c.Empleado)
                    .Include(c => c.Empleado.Persona)
                    .SingleOrDefault(c => c.CorreoUsuario == correoUsuario 
                            && c.Contrasenia == contrasenia);

                return result;
            }
        }

    }
}
