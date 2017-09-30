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
    public class DiagnosticoGravedadBl
    {
        readonly HistoriaClinicaBl _historiaClinicaBl = HistoriaClinicaBl.Instance;
        readonly RegistroIngresoBl _registroIngresoBl = RegistroIngresoBl.Instance;
        private static volatile DiagnosticoGravedadBl _instance;
        private static readonly object SyncRoot = new Object();

        private DiagnosticoGravedadBl() { }

        public static DiagnosticoGravedadBl Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (SyncRoot)
                    {
                        if (_instance == null)
                            _instance = new DiagnosticoGravedadBl();
                    }
                }
                return _instance;
            }
        }

        public List<DiagnosticoGravedad> List()
        {
            using (var context = new DataContext())
            {
                return context.DiagnosticoGravedades.ToList();
            }
        }

        public List<DiagnosticoGravedad> List(int idIngreso)
        {
            using (var context = new DataContext())
            {
                var result = (from c in context.DiagnosticoGravedades
                        join e in context.Empleados on c.IdEmpleado equals e.Id
                        join n in context.NivelCriticidades on c.IdNivelCriticidad equals n.Id
                        join i in context.IngresoSalidaPacientes on c.IdIngresoSalidaPaciente equals i.Id
                        join p in context.Personas on e.IdPersona equals p.Id
                        select c)
                    .Include(c => c.Empleado).Include(c => c.Empleado.Persona)
                    .Include(c => c.NivelCriticidad).Include(e => e.IngresoSalidaPaciente)
                    .Where(c => c.IdIngresoSalidaPaciente == idIngreso)
                    .ToList();
                return result;
            }
        }
        public DiagnosticoGravedad Save(DiagnosticoGravedad diagnosticoGravedad)
        {
            diagnosticoGravedad.FechaRegistro = DateTime.Now;
            var ingresoSalidaPaciente = _registroIngresoBl.Get(diagnosticoGravedad.IdIngresoSalidaPaciente);
            using (var context = new DataContext())
            {
                var historiaDb = context.HistoriaClinicas.Find(ingresoSalidaPaciente.Solicitud.IdHistoriaClinica);
                if (historiaDb != null)
                {
                    historiaDb.IdNivelCriticidad = diagnosticoGravedad.IdNivelCriticidad;
                    _historiaClinicaBl.Update(historiaDb);
                }

                context.DiagnosticoGravedades.Add(diagnosticoGravedad);
                context.SaveChanges();
            }
            return diagnosticoGravedad;
        }
    }
}
