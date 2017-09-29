using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using ClinicaBussines;
using ClinicaEntity;
using ClinicaMVC.Models;
using ClinicaUtil;

namespace ClinicaMVC.Controllers
{
    [SessionFilter]
    public class RegEnfermeriaController : BaseController
    {
        readonly RegistroIngresoBl _registroIngresoBl = RegistroIngresoBl.Instance;
        readonly RegistroEnfermeriaBl _registroEnfermeriaBl = RegistroEnfermeriaBl.Instance;
        readonly FactorRiesgoBl _factorRiesgoBl = FactorRiesgoBl.Instance;
        //readonly RegistroEnfermeriaDetalleBl _registroEnfermeriaDetalleBl = RegistroEnfermeriaDetalleBl.Instance;

        // GET: RegEnfermeria
        public ActionResult Index()
        {
            //RegEnfermeriaViewModel model = new RegEnfermeriaViewModel
            //{
            //    IngresoSalidaPacientes = _registroIngresoBl.List((int)EstadoRegistroIngreso.Activado)
            //};
            
            return View(new RegEnfermeriaViewModel());
        }

        public ActionResult Nuevo(int idRegistroIngreso)
        {
            Random rnd = new Random();

            RegEnfermeriaViewModel model = new RegEnfermeriaViewModel
            {
                IngresoSalidaPaciente = _registroIngresoBl.Get(idRegistroIngreso),
                HrmTemperatura = rnd.Next(0, 70),
                HrmRitmoCard = rnd.Next(0, 100),
                HrmPsPd = rnd.Next(0, 100),
                HrmPcmPap = rnd.Next(0, 100),
                HrmPam = rnd.Next(0, 100),
                HrmGcIc = rnd.Next(0, 100),
                RespModalidad = rnd.Next(0, 100),
                RespVc = rnd.Next(0, 100),
                RespFr = rnd.Next(0, 100),
                RespPeeps = rnd.Next(0, 100),
                RespFio2 = rnd.Next(0, 100),
                RespSatO2 = rnd.Next(0, 100),
                NeuroPupila = rnd.Next(0, 100),
                NeuroEstadoConc = rnd.Next(0, 100),
                NeuroGlosgow = rnd.Next(0, 100),
                NeuroRamsay = rnd.Next(0, 100),
                NeuroMotSd = rnd.Next(0, 100),
                NeuroMotSi = rnd.Next(0, 100),
                HidriIngresos = rnd.Next(0, 100),
                HidriEgresos = rnd.Next(0, 100)
            };
            model.IdIngresoSalidaPaciente = idRegistroIngreso;
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Save(RegEnfermeriaViewModel model)
        {
            try
            {
                var registroEnfermeriaModel = Mapper.Map<RegEnfermeriaViewModel, RegistroEnfermeriaModel>(model);
                _registroEnfermeriaBl.SaveDetails(registroEnfermeriaModel);
                return Json("Se guardo la informacion sin problemas.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, e.Message);
            }
        }

        public JsonResult GetValuesFactor(int idRegistroIngreso)
        {
            return Json(_factorRiesgoBl.ListByValue(idRegistroIngreso));
        }
    }
}