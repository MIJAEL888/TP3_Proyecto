using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicaData;
using ClinicaEntity;
using ClinicaUtil;

namespace ClinicaBussines
{
    public class FactorRiesgoBl
    {
        readonly RegistroEnfermeriaDetalleBl _registroEnfermeriaDetalleBl = RegistroEnfermeriaDetalleBl.Instance;
        readonly NivelCriticidadBl _nivelCriticidadBl = NivelCriticidadBl.Instance;
        private static volatile FactorRiesgoBl _instance;
        private static readonly object SyncRoot = new Object();

        private FactorRiesgoBl() { }

        public static FactorRiesgoBl Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (SyncRoot)
                    {
                        if (_instance == null)
                            _instance = new FactorRiesgoBl();
                    }
                }
                return _instance;
            }
        }

        public FactorRiesgo Get(int id)
        {
            using (var context = new DataContext())
            {
                var result = (from i in context.FactorRiesgos
                              select i)
                    .Single(c => c.Id == id);
                return result;
            }
        }
        public FactorRiesgo Get(string codigo)
        {
            using (var context = new DataContext())
            {
                var result = (from i in context.FactorRiesgos
                              select i)
                    .Single(c => c.Codigo == codigo);
                return result;
            }
        }
        public List<FactorRiesgo> List(int idPadre)
        {
            using (var context = new DataContext())
            {
                var result = (from d in context.FactorRiesgos
                        select d)
                    .Where(c => c.Padre == idPadre)
                    .ToList();
                return result;
            }
        }
        public List<FactorRiesgo> ListByValue(int idRegistroIngreso)
        {
            var enfermeriaDetalles = _registroEnfermeriaDetalleBl.List(idRegistroIngreso);
            var factoresPadre = List(0);
            foreach (var factor in factoresPadre)
            {
                factor.IdRegistroIngreso = idRegistroIngreso;
                factor.FactorRiesgosHijos = new List<FactorRiesgo>();
                var factoresHijo = List(factor.Id);
                foreach (var factorHijo in factoresHijo)
                {
                    factorHijo.Values = enfermeriaDetalles.Where(c => c.IdFactorRiesgo == factorHijo.Id).Select(c => c.Valor).ToList();
                    factorHijo.IdRegistros = enfermeriaDetalles.Where(c => c.IdFactorRiesgo == factorHijo.Id).Select(c => c.IdRegistroEnfermeria).ToList();
                    factor.FactorRiesgosHijos.Add(factorHijo);
                }
                factor.RegistroEnfermerias = enfermeriaDetalles.GroupBy(item => item.IdRegistroEnfermeria)
                .Select(group => group.First().RegistroEnfermeria)
                .ToList();
            }
            return factoresPadre;
        }

        public List<FactorRiesgo> ListByCriticidad(int idRegistroIngreso)
        {
            var enfermeriaDetalles = _registroEnfermeriaDetalleBl.List(idRegistroIngreso);
            var factoresPadre = List(0);
            foreach (var factor in factoresPadre)
            {
                factor.IdRegistroIngreso = idRegistroIngreso;
                factor.FactorRiesgosHijos = new List<FactorRiesgo>();
                factor.NivelCriticidades = new List<NivelCriticidad>();
                var nivelCriticidades = _nivelCriticidadBl.List();
                var factoresHijo = List(factor.Id);
                foreach (var criticidad in nivelCriticidades)
                {
                    criticidad.Values = new List<int>();
                    foreach (var factorHijo in factoresHijo)
                    {
                        criticidad.Values.Add(enfermeriaDetalles.Count(c => c.IdFactorRiesgo == factorHijo.Id && 
                                                          c.IdNivelCriticidad == criticidad.Id));
                    }
                    factor.NivelCriticidades.Add(criticidad);
                }
                factor.FactorRiesgosHijos =  factoresHijo;
            }
            return factoresPadre;
        }

        public List<FactorRiesgo> ListByCriticidad(int idRegistroIngreso, int cantidad)
        {
            var enfermeriaDetalles = _registroEnfermeriaDetalleBl.List(idRegistroIngreso);
            var factoresPadre = List(0);
            foreach (var factor in factoresPadre)
            {
                factor.IdRegistroIngreso = idRegistroIngreso;
                factor.FactorRiesgosHijos = new List<FactorRiesgo>();
                var factoresHijo = List(factor.Id);
                foreach (var factorHijo in factoresHijo)
                {
                    if (cantidad != 0)
                        factorHijo.Values = enfermeriaDetalles.Where(c => c.IdFactorRiesgo == factorHijo.Id)
                                                          .Select(c => c.IdNivelCriticidad).Reverse().Take(cantidad).ToList();
                    else factorHijo.Values = enfermeriaDetalles.Where(c => c.IdFactorRiesgo == factorHijo.Id)
                        .Select(c => c.IdNivelCriticidad).Reverse().ToList();

                    factorHijo.IdRegistros = enfermeriaDetalles.Where(c => c.IdFactorRiesgo == factorHijo.Id)
                        .Select(c => c.IdRegistroEnfermeria).Reverse().ToList();

                    factor.FactorRiesgosHijos.Add(factorHijo);
                }
                if (cantidad != 0)
                    factor.RegistroEnfermerias = enfermeriaDetalles.GroupBy(item => item.IdRegistroEnfermeria)
                        .Select(group => group.First().RegistroEnfermeria).Reverse().Take(cantidad)
                        .ToList();
                else
                    factor.RegistroEnfermerias = enfermeriaDetalles.GroupBy(item => item.IdRegistroEnfermeria)
                        .Select(group => group.First().RegistroEnfermeria).Reverse()
                        .ToList();
            }
            return factoresPadre;
        }
    }
}
