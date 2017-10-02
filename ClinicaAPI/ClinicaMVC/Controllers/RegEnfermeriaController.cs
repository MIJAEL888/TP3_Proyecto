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
        private readonly RegistroIngresoBl _registroIngresoBl = RegistroIngresoBl.Instance;
        private readonly RegistroEnfermeriaBl _registroEnfermeriaBl = RegistroEnfermeriaBl.Instance;
        private readonly FactorRiesgoBl _factorRiesgoBl = FactorRiesgoBl.Instance;
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
                HrmTemperatura = rnd.Next(30, 45),
                HrmRitmoCard = rnd.Next(1, 20),
                HrmPsPd = rnd.Next(1, 20),
                HrmPcmPap = rnd.Next(1, 20),
                HrmPam = rnd.Next(1, 20),
                HrmGcIc = rnd.Next(1, 20),
                RespModalidad = rnd.Next(1, 4),
                RespVc = rnd.Next(1, 20),
                RespFr = rnd.Next(1, 20),
                RespPeeps = rnd.Next(1, 20),
                RespFio2 = rnd.Next(1, 20),
                RespSatO2 = rnd.Next(1, 20),
                NeuroPupila = rnd.Next(1, 4),
                NeuroEstadoConc = rnd.Next(1, 4),
                NeuroGlosgow = rnd.Next(1, 20),
                NeuroRamsay = rnd.Next(1, 20),
                NeuroMotSd = rnd.Next(1, 20),
                NeuroMotSi = rnd.Next(1, 20),
                HidriIngresos = rnd.Next(1, 20),
                HidriEgresos = rnd.Next(1, 20),
                IdIngresoSalidaPaciente = idRegistroIngreso
            };
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