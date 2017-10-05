using System;
using System.Data.Entity;
using System.Linq;
using ClinicaData;
using ClinicaEntity;
using ClinicaUtil;
using log4net;

namespace ClinicaBussines
{
    public class RegistroEnfermeriaBl
    {
        private static readonly ILog Log =
              LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        readonly FactorRiesgoCriticidadBl _factorRiesgoCriticidadBl = FactorRiesgoCriticidadBl.Instance;
        readonly FactorRiesgoBl _factorRiesgoBl = FactorRiesgoBl.Instance;
        readonly RegistroEnfermeriaDetalleBl _registroEnfermeriaDetalleBl = RegistroEnfermeriaDetalleBl.Instance;

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
                context.SaveChanges();
            }
            return registroEnfermeria;
        }

        public RegistroEnfermeria Get(int idRegistro)
        {
            using (var context = new DataContext())
            {
                var result = (from i in context.RegistroEnfermerias
                             join ri in context.IngresoSalidaPacientes  on i.IdIngresoSalidaPaciente equals ri.Id 
                              select i)
                    .Include(c => c.IngresoSalidaPaciente)
                    .SingleOrDefault(c => c.Id == idRegistro);
                return result;
            }
        }

        public int SaveDetails(RegistroEnfermeriaModel registroEnfermeriaModel)
        {
            var registroEnfermeria = new RegistroEnfermeria
            {
                IdIngresoSalidaPaciente = registroEnfermeriaModel.IdIngresoSalidaPaciente,
                FechaRegistro = DateTime.Now,
                Observacion = "Alguna observacion de la enfermera"
            };
            registroEnfermeria = Save(registroEnfermeria);

            #region SetRegistroEnfermeriaDetalle
            //Hermodinamico
            var registroHrmTemperatura = new RegistroEnfermeriaDetalle
            {
                FechaRegistro = DateTime.Now,
                Valor = registroEnfermeriaModel.HrmTemperatura,
                ValorString = registroEnfermeriaModel.HrmTemperatura.ToString(),
                IdRegistroEnfermeria = registroEnfermeria.Id,
                IdFactorRiesgo = _factorRiesgoBl.Get(Constantes.FatoresRiesgo.HrmTemperatura).Id,
                IdNivelCriticidad = _factorRiesgoCriticidadBl.Get(Constantes.FatoresRiesgo.HrmTemperatura, registroEnfermeriaModel.HrmTemperatura).NivelCriticidad.Id
            };
            var registroHrmRitmoCard = new RegistroEnfermeriaDetalle
            {
                FechaRegistro = DateTime.Now,
                Valor = registroEnfermeriaModel.HrmRitmoCard,
                ValorString = registroEnfermeriaModel.HrmRitmoCard.ToString(),
                IdRegistroEnfermeria = registroEnfermeria.Id,
                IdFactorRiesgo = _factorRiesgoBl.Get(Constantes.FatoresRiesgo.HrmRitmoCard).Id,
                IdNivelCriticidad = _factorRiesgoCriticidadBl.Get(Constantes.FatoresRiesgo.HrmRitmoCard, registroEnfermeriaModel.HrmRitmoCard).NivelCriticidad.Id
            };
            var registroHrmPsPd= new RegistroEnfermeriaDetalle
            {
                FechaRegistro = DateTime.Now,
                Valor = registroEnfermeriaModel.HrmPsPd,
                ValorString = registroEnfermeriaModel.HrmPsPd.ToString(),
                IdRegistroEnfermeria = registroEnfermeria.Id,
                IdFactorRiesgo = _factorRiesgoBl.Get(Constantes.FatoresRiesgo.HrmPsPd).Id,
                IdNivelCriticidad = _factorRiesgoCriticidadBl.Get(Constantes.FatoresRiesgo.HrmPsPd, registroEnfermeriaModel.HrmPsPd).NivelCriticidad.Id
            };
            var registroHrmPcmPap = new RegistroEnfermeriaDetalle
            {
                FechaRegistro = DateTime.Now,
                Valor = registroEnfermeriaModel.HrmPcmPap,
                ValorString = registroEnfermeriaModel.HrmPcmPap.ToString(),
                IdRegistroEnfermeria = registroEnfermeria.Id,
                IdFactorRiesgo = _factorRiesgoBl.Get(Constantes.FatoresRiesgo.HrmPcmPap).Id,
                IdNivelCriticidad = _factorRiesgoCriticidadBl.Get(Constantes.FatoresRiesgo.HrmPcmPap, registroEnfermeriaModel.HrmPcmPap).NivelCriticidad.Id
            };
            var registroHrmPam = new RegistroEnfermeriaDetalle
            {
                FechaRegistro = DateTime.Now,
                Valor = registroEnfermeriaModel.HrmPam,
                ValorString = registroEnfermeriaModel.HrmPam.ToString(),
                IdRegistroEnfermeria = registroEnfermeria.Id,
                IdFactorRiesgo = _factorRiesgoBl.Get(Constantes.FatoresRiesgo.HrmPam).Id,
                IdNivelCriticidad = _factorRiesgoCriticidadBl.Get(Constantes.FatoresRiesgo.HrmPam, registroEnfermeriaModel.HrmPam).NivelCriticidad.Id
            };
            var registroHrmGcIc = new RegistroEnfermeriaDetalle
            {
                FechaRegistro = DateTime.Now,
                Valor = registroEnfermeriaModel.HrmGcIc,
                ValorString = registroEnfermeriaModel.HrmGcIc.ToString(),
                IdRegistroEnfermeria = registroEnfermeria.Id,
                IdFactorRiesgo = _factorRiesgoBl.Get(Constantes.FatoresRiesgo.HrmGcIc).Id,
                IdNivelCriticidad = _factorRiesgoCriticidadBl.Get(Constantes.FatoresRiesgo.HrmGcIc, registroEnfermeriaModel.HrmGcIc).NivelCriticidad.Id
            };
            // respiratorio
            var registroRespModalidad = new RegistroEnfermeriaDetalle
            {
                FechaRegistro = DateTime.Now,
                Valor = registroEnfermeriaModel.RespModalidad,
                ValorString = registroEnfermeriaModel.RespModalidad.ToString(),
                IdRegistroEnfermeria = registroEnfermeria.Id,
                IdFactorRiesgo = _factorRiesgoBl.Get(Constantes.FatoresRiesgo.RespModalidad).Id,
                IdNivelCriticidad = _factorRiesgoCriticidadBl.Get(Constantes.FatoresRiesgo.RespModalidad, registroEnfermeriaModel.RespModalidad).NivelCriticidad.Id
            };
            var registroRespVc = new RegistroEnfermeriaDetalle
            {
                FechaRegistro = DateTime.Now,
                Valor = registroEnfermeriaModel.RespVc,
                ValorString = registroEnfermeriaModel.RespVc.ToString(),
                IdRegistroEnfermeria = registroEnfermeria.Id,
                IdFactorRiesgo = _factorRiesgoBl.Get(Constantes.FatoresRiesgo.RespVc).Id,
                IdNivelCriticidad = _factorRiesgoCriticidadBl.Get(Constantes.FatoresRiesgo.RespVc, registroEnfermeriaModel.RespVc).NivelCriticidad.Id
            };
            var registroRespFr = new RegistroEnfermeriaDetalle
            {
                FechaRegistro = DateTime.Now,
                Valor = registroEnfermeriaModel.RespFr,
                ValorString = registroEnfermeriaModel.RespFr.ToString(),
                IdRegistroEnfermeria = registroEnfermeria.Id,
                IdFactorRiesgo = _factorRiesgoBl.Get(Constantes.FatoresRiesgo.RespFr).Id,
                IdNivelCriticidad = _factorRiesgoCriticidadBl.Get(Constantes.FatoresRiesgo.RespFr, registroEnfermeriaModel.RespFr).NivelCriticidad.Id
            };
            var registroRespPeeps = new RegistroEnfermeriaDetalle
            {
                FechaRegistro = DateTime.Now,
                Valor = registroEnfermeriaModel.RespPeeps,
                ValorString = registroEnfermeriaModel.RespPeeps.ToString(),
                IdRegistroEnfermeria = registroEnfermeria.Id,
                IdFactorRiesgo = _factorRiesgoBl.Get(Constantes.FatoresRiesgo.RespPeeps).Id,
                IdNivelCriticidad = _factorRiesgoCriticidadBl.Get(Constantes.FatoresRiesgo.RespPeeps, registroEnfermeriaModel.RespPeeps).NivelCriticidad.Id
            };
            var registroRespFio2 = new RegistroEnfermeriaDetalle
            {
                FechaRegistro = DateTime.Now,
                Valor = registroEnfermeriaModel.RespFio2,
                ValorString = registroEnfermeriaModel.RespFio2.ToString(),
                IdRegistroEnfermeria = registroEnfermeria.Id,
                IdFactorRiesgo = _factorRiesgoBl.Get(Constantes.FatoresRiesgo.RespFio2).Id,
                IdNivelCriticidad = _factorRiesgoCriticidadBl.Get(Constantes.FatoresRiesgo.RespFio2, registroEnfermeriaModel.RespFio2).NivelCriticidad.Id
            };
            var registroRespSatO2 = new RegistroEnfermeriaDetalle
            {
                FechaRegistro = DateTime.Now,
                Valor = registroEnfermeriaModel.RespSatO2,
                ValorString = registroEnfermeriaModel.RespSatO2.ToString(),
                IdRegistroEnfermeria = registroEnfermeria.Id,
                IdFactorRiesgo = _factorRiesgoBl.Get(Constantes.FatoresRiesgo.RespSatO2).Id,
                IdNivelCriticidad = _factorRiesgoCriticidadBl.Get(Constantes.FatoresRiesgo.RespSatO2, registroEnfermeriaModel.RespSatO2).NivelCriticidad.Id
            };

            //Neurologico
            var registroNeuroPupila = new RegistroEnfermeriaDetalle
            {
                FechaRegistro = DateTime.Now,
                Valor = registroEnfermeriaModel.NeuroPupila,
                ValorString = registroEnfermeriaModel.NeuroPupila.ToString(),
                IdRegistroEnfermeria = registroEnfermeria.Id,
                IdFactorRiesgo = _factorRiesgoBl.Get(Constantes.FatoresRiesgo.NeuroPupila).Id,
                IdNivelCriticidad = _factorRiesgoCriticidadBl.Get(Constantes.FatoresRiesgo.NeuroPupila, registroEnfermeriaModel.NeuroPupila).NivelCriticidad.Id
            };
            var registroNeuroEstadoConc = new RegistroEnfermeriaDetalle
            {
                FechaRegistro = DateTime.Now,
                Valor = registroEnfermeriaModel.NeuroEstadoConc,
                ValorString = registroEnfermeriaModel.NeuroEstadoConc.ToString(),
                IdRegistroEnfermeria = registroEnfermeria.Id,
                IdFactorRiesgo = _factorRiesgoBl.Get(Constantes.FatoresRiesgo.NeuroEstadoConc).Id,
                IdNivelCriticidad = _factorRiesgoCriticidadBl.Get(Constantes.FatoresRiesgo.NeuroEstadoConc, registroEnfermeriaModel.NeuroEstadoConc).NivelCriticidad.Id
            };
            var registroNeuroGlosgow = new RegistroEnfermeriaDetalle
            {
                FechaRegistro = DateTime.Now,
                Valor = registroEnfermeriaModel.NeuroGlosgow,
                ValorString = registroEnfermeriaModel.NeuroGlosgow.ToString(),
                IdRegistroEnfermeria = registroEnfermeria.Id,
                IdFactorRiesgo = _factorRiesgoBl.Get(Constantes.FatoresRiesgo.NeuroGlosgow).Id,
                IdNivelCriticidad = _factorRiesgoCriticidadBl.Get(Constantes.FatoresRiesgo.NeuroGlosgow, registroEnfermeriaModel.NeuroGlosgow).NivelCriticidad.Id
            };
            var registroNeuroRamsay = new RegistroEnfermeriaDetalle
            {
                FechaRegistro = DateTime.Now,
                Valor = registroEnfermeriaModel.NeuroRamsay,
                ValorString = registroEnfermeriaModel.NeuroRamsay.ToString(),
                IdRegistroEnfermeria = registroEnfermeria.Id,
                IdFactorRiesgo = _factorRiesgoBl.Get(Constantes.FatoresRiesgo.NeuroRamsay).Id,
                IdNivelCriticidad = _factorRiesgoCriticidadBl.Get(Constantes.FatoresRiesgo.NeuroRamsay, registroEnfermeriaModel.NeuroRamsay).NivelCriticidad.Id
            };
            var registroNeuroMotSd = new RegistroEnfermeriaDetalle
            {
                FechaRegistro = DateTime.Now,
                Valor = registroEnfermeriaModel.NeuroMotSd,
                ValorString = registroEnfermeriaModel.NeuroMotSd.ToString(),
                IdRegistroEnfermeria = registroEnfermeria.Id,
                IdFactorRiesgo = _factorRiesgoBl.Get(Constantes.FatoresRiesgo.NeuroMotSd).Id,
                IdNivelCriticidad = _factorRiesgoCriticidadBl.Get(Constantes.FatoresRiesgo.NeuroMotSd, registroEnfermeriaModel.NeuroMotSd).NivelCriticidad.Id
            };
            var registroNeuroMotSi = new RegistroEnfermeriaDetalle
            {
                FechaRegistro = DateTime.Now,
                Valor = registroEnfermeriaModel.NeuroMotSi,
                ValorString = registroEnfermeriaModel.NeuroMotSi.ToString(),
                IdRegistroEnfermeria = registroEnfermeria.Id,
                IdFactorRiesgo = _factorRiesgoBl.Get(Constantes.FatoresRiesgo.NeuroMotSi).Id,
                IdNivelCriticidad = _factorRiesgoCriticidadBl.Get(Constantes.FatoresRiesgo.NeuroMotSi, registroEnfermeriaModel.NeuroMotSi).NivelCriticidad.Id
            };
            //Hidrico
            var registroHidriIngresos = new RegistroEnfermeriaDetalle
            {
                FechaRegistro = DateTime.Now,
                Valor = registroEnfermeriaModel.HidriIngresos,
                ValorString = registroEnfermeriaModel.HidriIngresos.ToString(),
                IdRegistroEnfermeria = registroEnfermeria.Id,
                IdFactorRiesgo = _factorRiesgoBl.Get(Constantes.FatoresRiesgo.HidriIngresos).Id,
                IdNivelCriticidad = _factorRiesgoCriticidadBl.Get(Constantes.FatoresRiesgo.HidriIngresos, registroEnfermeriaModel.HidriIngresos).NivelCriticidad.Id
            };
            var registroHidriEgresos = new RegistroEnfermeriaDetalle
            {
                FechaRegistro = DateTime.Now,
                Valor = registroEnfermeriaModel.HidriEgresos,
                ValorString = registroEnfermeriaModel.HidriEgresos.ToString(),
                IdRegistroEnfermeria = registroEnfermeria.Id,
                IdFactorRiesgo = _factorRiesgoBl.Get(Constantes.FatoresRiesgo.HidriEgresos).Id,
                IdNivelCriticidad = _factorRiesgoCriticidadBl.Get(Constantes.FatoresRiesgo.HidriEgresos, registroEnfermeriaModel.HidriEgresos).NivelCriticidad.Id
            };
            #endregion

            using (var context = new DataContext())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.RegistroEnfermeriaDetalles.Add(registroHrmTemperatura);
                        context.RegistroEnfermeriaDetalles.Add(registroHrmRitmoCard);
                        context.RegistroEnfermeriaDetalles.Add(registroHrmPsPd);
                        context.RegistroEnfermeriaDetalles.Add(registroHrmPcmPap);
                        context.RegistroEnfermeriaDetalles.Add(registroHrmPam);
                        context.RegistroEnfermeriaDetalles.Add(registroHrmGcIc);

                        context.RegistroEnfermeriaDetalles.Add(registroRespModalidad);
                        context.RegistroEnfermeriaDetalles.Add(registroRespVc);
                        context.RegistroEnfermeriaDetalles.Add(registroRespFr);
                        context.RegistroEnfermeriaDetalles.Add(registroRespPeeps);
                        context.RegistroEnfermeriaDetalles.Add(registroRespFio2);
                        context.RegistroEnfermeriaDetalles.Add(registroRespSatO2);

                        context.RegistroEnfermeriaDetalles.Add(registroNeuroPupila);
                        context.RegistroEnfermeriaDetalles.Add(registroNeuroEstadoConc);
                        context.RegistroEnfermeriaDetalles.Add(registroNeuroGlosgow);
                        context.RegistroEnfermeriaDetalles.Add(registroNeuroRamsay);
                        context.RegistroEnfermeriaDetalles.Add(registroNeuroMotSd);
                        context.RegistroEnfermeriaDetalles.Add(registroNeuroMotSi);

                        context.RegistroEnfermeriaDetalles.Add(registroHidriIngresos);
                        context.RegistroEnfermeriaDetalles.Add(registroHidriEgresos);
                        // do your changes
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                    }
                    catch (Exception e)
                    {
                        Log.Error(e.Message);
                        dbContextTransaction.Rollback();
                    }
                }
               
            }
            return 1;

        }

        public RegistroEnfermeriaModel GetDetails(int idRegistro)
        {
            RegistroEnfermeriaModel model = new RegistroEnfermeriaModel
            {
                RegistroEnfermeria = Get(idRegistro),
                HrmTemperatura = _registroEnfermeriaDetalleBl.Get(idRegistro, Constantes.FatoresRiesgo.HrmTemperatura).Valor,
                HrmRitmoCard = _registroEnfermeriaDetalleBl.Get(idRegistro, Constantes.FatoresRiesgo.HrmRitmoCard).Valor,
                HrmPsPd = _registroEnfermeriaDetalleBl.Get(idRegistro, Constantes.FatoresRiesgo.HrmPsPd).Valor,
                HrmPcmPap = _registroEnfermeriaDetalleBl.Get(idRegistro, Constantes.FatoresRiesgo.HrmPcmPap).Valor,
                HrmPam = _registroEnfermeriaDetalleBl.Get(idRegistro, Constantes.FatoresRiesgo.HrmPam).Valor,
                HrmGcIc = _registroEnfermeriaDetalleBl.Get(idRegistro, Constantes.FatoresRiesgo.HrmGcIc).Valor,
                RespModalidad = _registroEnfermeriaDetalleBl.Get(idRegistro, Constantes.FatoresRiesgo.RespModalidad).Valor,
                RespVc = _registroEnfermeriaDetalleBl.Get(idRegistro, Constantes.FatoresRiesgo.RespVc).Valor,
                RespFr = _registroEnfermeriaDetalleBl.Get(idRegistro, Constantes.FatoresRiesgo.RespFr).Valor,
                RespPeeps = _registroEnfermeriaDetalleBl.Get(idRegistro, Constantes.FatoresRiesgo.RespPeeps).Valor,
                RespFio2 = _registroEnfermeriaDetalleBl.Get(idRegistro, Constantes.FatoresRiesgo.RespFio2).Valor,
                RespSatO2 = _registroEnfermeriaDetalleBl.Get(idRegistro, Constantes.FatoresRiesgo.RespSatO2).Valor,
                NeuroPupila = _registroEnfermeriaDetalleBl.Get(idRegistro, Constantes.FatoresRiesgo.NeuroPupila).Valor,
                NeuroEstadoConc = _registroEnfermeriaDetalleBl.Get(idRegistro, Constantes.FatoresRiesgo.NeuroEstadoConc).Valor,
                NeuroGlosgow = _registroEnfermeriaDetalleBl.Get(idRegistro, Constantes.FatoresRiesgo.NeuroGlosgow).Valor,
                NeuroRamsay = _registroEnfermeriaDetalleBl.Get(idRegistro, Constantes.FatoresRiesgo.NeuroRamsay).Valor,
                NeuroMotSd = _registroEnfermeriaDetalleBl.Get(idRegistro, Constantes.FatoresRiesgo.NeuroMotSd).Valor,
                NeuroMotSi = _registroEnfermeriaDetalleBl.Get(idRegistro, Constantes.FatoresRiesgo.NeuroMotSi).Valor,
                HidriIngresos = _registroEnfermeriaDetalleBl.Get(idRegistro, Constantes.FatoresRiesgo.HidriIngresos).Valor,
                HidriEgresos = _registroEnfermeriaDetalleBl.Get(idRegistro, Constantes.FatoresRiesgo.HidriEgresos).Valor,
            };
            return model;
        }
    }
}
