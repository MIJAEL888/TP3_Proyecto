using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicaData;
using ClinicaEntity;
using ClinicaUtil;
using log4net;

namespace ClinicaBussines
{
    public class SolicitudBl
    {
        readonly Email _email = Email.Instance;
        private static readonly ILog Log =
            LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static volatile SolicitudBl _instance;
        private static readonly object SyncRoot = new Object();

        private SolicitudBl() { }

        public static SolicitudBl Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (SyncRoot)
                    {
                        if (_instance == null)
                            _instance = new SolicitudBl();
                    }
                }
                return _instance;
            }
        }

        public List<Solicitud> List()
        {
            using (var context = new DataContext())
            {
                return context.Solicitudes.ToList();
            }
        }

        public List<Solicitud> List(int idEstado)
        {
            using (var context = new DataContext())
            {
                var result = (from c in context.Solicitudes
                                join h in context.HistoriaClinicas on c.IdHistoriaClinica equals h.Id
                                join pa in context.Pacientes on h.IdPaciente equals pa.Id
                                join e in context.Empleados on c.IdEmpleado equals e.Id
                                join p in context.Personas on e.IdPersona equals p.Id
                              select c)
                    .Include(c => c.HistoriaClinica).Include(c => c.HistoriaClinica.Paciente)
                    .Include(c => c.Empleado).Include(e => e.Empleado.Persona)
                    .Where(c => (int) c.Estado == idEstado)
                    .ToList();

                return result;
            }
        }

        public Solicitud Get(int id)
        {
            using (var context = new DataContext())
            {
                var result = (from c in context.Solicitudes
                        join h in context.HistoriaClinicas on c.IdHistoriaClinica equals h.Id
                        join pa in context.Pacientes on h.IdPaciente equals pa.Id
                        join e in context.Empleados on c.IdEmpleado equals e.Id
                        join p in context.Personas on e.IdPersona equals p.Id
                        select c).Include(c => c.HistoriaClinica)
                    .Include(c => c.HistoriaClinica.Paciente).Include(c => c.Empleado)
                    .Include(e => e.Empleado.Persona)
                    .SingleOrDefault(c => c.Id == id);

                return result;
            }
        }

        public void Update(Solicitud solicitud)
        {
            using (var context = new DataContext())
            {
                var solicitudDb = context.Solicitudes.Find(solicitud.Id);
                if (solicitudDb != null)
                {
                    solicitudDb.Estado = solicitud.Estado;
                    context.SaveChanges();
                }
            }
        }

        public void Aprobar(int idSolicitud, int idCama, Usuario usuario)
        {
            Log.Info("Arpobar solicitud UCI");
            using (var context = new DataContext())
            {
                var solicitudDb = context.Solicitudes.Find(idSolicitud);
                if (solicitudDb != null)
                {
                    var camaDb = context.Camas.Find(idCama);
                    if (camaDb != null)
                    {
                        camaDb.Estado = EstadoCama.Ocupado;

                        IngresoSalidaPaciente ingresoSalidaPaciente = new IngresoSalidaPaciente
                        {
                            IdCama = camaDb.Id,
                            IdSolicitud = solicitudDb.Id,
                            Estado = EstadoRegistroIngreso.Activado,
                            FechaIngreso = DateTime.Now,
                            Motivo = "Aprobacion de solicitud de ingreso.",
                            FechaSalida = DateTime.Now
                        };
                        context.IngresoSalidaPacientes.Add(ingresoSalidaPaciente);
                    }
                    solicitudDb.Estado = EstadoSolicitud.Aprobado;
                    context.SaveChanges();
                    try
                    {
                        _email.SendMail(GetMensajeAprobacion("Doctor 1", solicitudDb.Id, usuario.Empleado.Persona.Nombre, "Aprobado"), 
                            "Aprobacion UCI", usuario.Empleado.CorreoInst);
                    }
                    catch (Exception e)
                    {
                        Log.Error("Error al enviar el correo");
                    }
                }
            }
                
        }

        public void DesAprobar(int idSolicitud, Usuario usuario)
        {
            Log.Info("Desaprobar solicitud UCI");
            using (var context = new DataContext())
            {
                var solicitudDb = context.Solicitudes.Find(idSolicitud);
                if (solicitudDb != null)
                {
                    solicitudDb.Estado = EstadoSolicitud.Rechazado;
                    context.SaveChanges();
                    try
                    {
                        _email.SendMail(GetMensajeAprobacion("Doctor 1", solicitudDb.Id,  usuario.Empleado.Persona.Nombre, "Desaprobado"), 
                            "Desarpobacion UCI", usuario.Empleado.CorreoInst);
                    }
                    catch (Exception e)
                    {
                        Log.Error("Error al enviar el correo");
                    }
                    
                }
                
            }
            
        }

        public string GetMensajeAprobacion(string nombreDoctor, int idSolicitud, string nombrePaciente, string estado)
        {
            return "<table border='0' cellpadding='0' cellspacing='0' height='100%' width='100%' id='bodyTable' style='font-family: sans-serif;'>" +
                   "<tr>" +
                   "<td align='center' valign='top'>" +
                   "<table border='0' cellpadding='10' cellspacing='0' width='600' id='emailContainer'>" +
                   "<tr>" +
                   "<td align='center' valign='top'>" +
                   "<table border='0' cellspacing='0' width='100%' id='emailHeader'>" +
                   "<tr>" +
                   "<td align='center' valign='top'>" +
                   "Respuesta de solicitud de ingreso a UCI: " + estado +
                   "</td>" +
                   "</tr>" +
                   "</table>" +
                   "</td>" +
                   "</tr>" +
                   "<tr>" +
                   "<td align='center' valign='top'>" +
                   "<table border='0' cellpadding='0' cellspacing='0' width='100%' style='max-width: 500px;' class='responsive-table'>" +
                   "<tr>" +
                   "<td style='padding: 10px 0 0 0; border-top: 1px dashed #aaaaaa;'>" +
                   "<table cellspacing='0' cellpadding='0' border='0' width='100%'>" +
                   "<tr>" +
                   "<td valign='top' class='mobile-wrapper'>" +
                   "Doctor: " + nombreDoctor +
                   "</td>" +
                   "</tr>" +
                   "</table>" +
                   "</td>" +
                   "</tr>" +
                   "<tr>" +
                   "<td>" +
                   "<table cellspacing='0' cellpadding='0' border='0' width='100%'>" +
                   "<tr>" +
                   "<td valign='top' style='padding: 0;' class='mobile-wrapper'>" +
                   "Paciente: " + nombrePaciente +
                   "</td>" +
                   "</tr>" +
                   "</table>" +
                   "</td>" +
                   "</tr>" +
                   "<tr>" +
                   "<td>" +
                   "<table cellspacing='0' cellpadding='0' border='0' width='100%'>" +
                   "<tr>" +
                   "<td valign='top' style='padding: 0;' class='mobile-wrapper'>" +
                   "Numero de solicitud: " + idSolicitud +
                   "</td>" +
                   "</tr>" +
                   "</table>" +
                   "</td>" +
                   "</tr>" +
                   "<tr>" +
                   "<td style='padding: 10px 0 0px 0; border-bottom: 1px dashed #aaaaaa;'>" +
                   "</td>" +
                   "</tr>" +
                   "</table>" +
                   "</td>" +
                   "</tr>" +
                   "</table>" +
                   "</td>" +
                   "</tr>" +
                   "</table>";
        }
    }
}
